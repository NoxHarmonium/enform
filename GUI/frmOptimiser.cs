using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Collections;
using NeuronDotNet.Core;
using NeuronDotNet.Core.Backpropagation;
using System.Diagnostics;
using ENFORM.Core;
using System.IO;

namespace ENFORM.GUI
{
    public partial class frmOptimiser : Form
    {
        // event raised before the door opens
        public delegate void ThreadProgressChangedHandler(int tabIndex,double meanErrorSquared, int currentEpoch, string message);
        private delegate void UpdateTabHandler ( int tabIndex, double meanErrorSquared, int currentEpoch, string message );
        public event ThreadProgressChangedHandler ThreadProgressChanged;

        //private Dictionary<
        
        private int currentRun = 0;
        private int runs = 0;

        private Thread[] threads;

        private Queue<Job> jobs = new Queue<Job>();       

        [ThreadStatic]    
        static int updateCount;
        [ThreadStatic]
        static Job currentJob;
        [ThreadStatic]
        static float[] results;
        [ThreadStatic]
        static int iteration;
        [ThreadStatic]
        static Stopwatch stopWatch;
        

        
        
        public frmOptimiser()
        {
            InitializeComponent();
        }

        private void frmOptimisor_Load(object sender, EventArgs e)
        {
            numThreads.Maximum = System.Environment.ProcessorCount - 1;
            numThreads_ValueChanged(null, null);
            this.ThreadProgressChanged += new ThreadProgressChangedHandler(frmOptimiser_ThreadProgressChanged);
        }

        private void updateTab(int tabIndex, double meanErrorSquared, int currentEpoch, string message)
        {
            OptimisationStatus status = (OptimisationStatus)tabThreads.TabPages[tabIndex].Controls[0];
            status.MeanErrorSquared = meanErrorSquared;
            status.CurrentEpoch = currentEpoch;
            status.Message = message;


        }

        void frmOptimiser_ThreadProgressChanged(int tabIndex,double meanErrorSquared,int currentEpoch,string message)
        {
            OptimisationStatus status = (OptimisationStatus)tabThreads.TabPages[tabIndex].Controls[0];
            object[] o = new object[4];
            o[0] = tabIndex;
            o[1] = meanErrorSquared;
            o[2] = currentEpoch;
            o[3] = message;

            if (status.InvokeRequired)
            {
                BeginInvoke(new UpdateTabHandler(updateTab),o);
            }
            else
            {
                status.MeanErrorSquared = meanErrorSquared;
                status.CurrentEpoch = currentEpoch;
            }

        }

        private void numThreads_ValueChanged(object sender, EventArgs e)
        {
            tabThreads.TabPages.Clear();
            for (int i = 0; i < numThreads.Value; i++)
            {
                TabPage tab = new TabPage("Thread " + Convert.ToString(i+1));
                tab.Controls.Add(new OptimisationStatus());
                tabThreads.TabPages.Add(tab);
            }

            threads = new Thread[(int)numThreads.Value];
            //tabThreads.TabPages.Add(
        }

        private void btnAddRun_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlgLoad = new OpenFileDialog())
            {
                dlgLoad.AddExtension = true;
                dlgLoad.DefaultExt = "erun";
                dlgLoad.Filter = "ENFORM run file(*.erun)|*.erun";
                dlgLoad.Title = "Open run file...";
                dlgLoad.Multiselect = true;
               
                if (dlgLoad.ShowDialog() == DialogResult.OK)
                {
                    foreach (string filename in dlgLoad.FileNames)
                    {

                        ListViewItem item = new ListViewItem(
                            new string[] { 
                            filename.Substring(filename.LastIndexOf("\\")+1),
                            "",filename});
                        lstRuns.Items.Add(item);
                    }


                }


            } 
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lstRuns.Enabled = false;
            grpProperties.Enabled = false;

            for (int i = 0; i < lstRuns.Items.Count; i++ )
            {
                currentRun = i;
                lblCurrentRunValue.Text = lstRuns.Items[i].SubItems[0].Text;

                beginRun(lstRuns.Items[i].SubItems[2].Text);
                

            }




        }

        private void beginRun(string filename)
        {
            runs = (int)numRuns.Value;

            for (int i = 0; i < runs; i++)
            {
                jobs.Enqueue(new Job(filename));
            }

            
            for (int i = 0; i < numThreads.Value; i++)
            {
             /*   
                BackgroundWorker worker = new BackgroundWorker();
               
                worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
                worker.WorkerReportsProgress = true;
                worker.WorkerSupportsCancellation = true;
                worker.RunWorkerAsync(i);
                backgroundWorkers.Add(worker);
              * */
                
                threads[i] = new Thread(new ParameterizedThreadStart(runThread));
                threads[i].Name = i.ToString();

                
                threads[i].Start(i);
                
                

            }
          
           
            
                       

        }

        void runThread(object o)
        {
            stopWatch = new Stopwatch();
            iteration = 0;
            updateCount = 0;
            results = new float[2000000];

            // Thread.CurrentThread.Name = o.ToString();
            while (Thread.CurrentThread.IsAlive)
            {

                //Thread.CurrentThread.Name = o.ToString();
                Job job = null;
                lock (jobs)
                {
                    if (jobs.Count > 0)
                    {
                        job = jobs.Dequeue();                       
                    }
                }
                if (job == null)
                {
                    changeThreadProgress(Int32.Parse(Thread.CurrentThread.Name), -1, -1, "No more jobs!");
                    return;
                }

                currentJob = job;
                iteration = 0;
                if (stopWatch.IsRunning)
                    stopWatch.Stop();              

                stopWatch.Reset();

                Optimiser optimiser = new Optimiser(job.Filename);
           
                optimiser.Network.EndEpochEvent += new NeuronDotNet.Core.TrainingEpochEventHandler(Network_EndEpochEvent);
                
                //BackgroundWorker worker = (BackgroundWorker)sender;
                double mes = 1;
                
                stopWatch.Start();
                DateTime startTime = DateTime.Now;
                mes = optimiser.Optimise();

                changeThreadProgress(Int32.Parse(Thread.CurrentThread.Name), optimiser.Network.MeanSquaredError, optimiser.MaxIterations,"Writing results...");
                DateTime endTime = DateTime.Now;
                
                
                DataAccess dataAccess = new DataAccess(job.Filename);

                dataAccess.SaveResult(job.ID,optimiser.Network, iteration, results, startTime,endTime);
                    
                    //worker.ReportProgress((int)e.Argument, mes);
               

            }

        }

        void Network_EndEpochEvent(object sender, NeuronDotNet.Core.TrainingEpochEventArgs e)
        {
            INetwork network = (INetwork) sender;
            
            results[iteration] = (float)network.MeanSquaredError;
            results[iteration + 1] = (float) stopWatch.Elapsed.TotalMilliseconds;
            
            iteration += 2;
            //Updating the UI thread bottlenecks performance
            if (updateCount++ > 100)
            {
                changeThreadProgress(Int32.Parse(Thread.CurrentThread.Name), network.MeanSquaredError, e.TrainingIteration,"Optimising");
                updateCount = 0;
            }
        }

       


        private void btnStop_Click(object sender, EventArgs e)
        {
            lstRuns.Enabled = true;
            grpProperties.Enabled = true;

            for (int i = 0; i < numThreads.Value; i++)
            {
                if (threads[i] != null && threads[i].ThreadState == System.Threading.ThreadState.Running)
                {
                    threads[i].Abort();
                }
            }
            
        }

        private void changeThreadProgress(int tabIndex, double meanErrorSquared, int currentEpoch, string message)
        {
            if (ThreadProgressChanged != null)
            {
                ThreadProgressChanged(tabIndex,meanErrorSquared, currentEpoch, message);
            }
        }

        private void frmOptimiser_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnStop_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        
        }

        private void frmOptimiser_Shown(object sender, EventArgs e)
        {
            //Utils.SetLogWindowLocation(this.Location.X, this.Location.Y + this.Size.Height + 10);
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveBatch_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlgSave = new SaveFileDialog())
            {
                dlgSave.AddExtension = true;
                dlgSave.DefaultExt = "ebat";
                dlgSave.Filter = "ENFORM batch file(*.ebat)|*.ebat";
                dlgSave.Title = "Save batch file...";
             

                if (dlgSave.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(dlgSave.FileName))
                    {
                        writer.WriteLine("ENFORM batch file");
                        writer.WriteLine(numRuns.Value.ToString() + "," + numThreads.Value.ToString());
                        for (int i = 0; i < lstRuns.Items.Count; i++)
                        {
                            writer.WriteLine(new FileInfo(lstRuns.Items[i].SubItems[2].Text).Name);
                        }
                        writer.Close();
                    }
                    
                }


            } 
        }
       
    }
}
