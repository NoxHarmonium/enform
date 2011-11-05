using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPSO_2007;
using NeuronDotNet.Core;
using NeuronDotNet.Core.Initializers;
using NeuronDotNet.Core.PSO;
using ENFORM.Core;
using ENFORM.Core.Logging;
using System.Threading;

namespace ENFORM.GUI
{
    public partial class frmMainMenu : Form
    {
        //private PSONetwork network;
        
        public frmMainMenu()
        {
            //Thread.CurrentThread.Name = "Main UI Thread";
            InitializeComponent();
            Utils.Logger = new SQLiteLogger();
            
            Utils.Logger.StartLogger();
            Utils.Logger.Log("ENFORM booting up....");
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            
            
        }

        private void btnRunEditor_Click(object sender, EventArgs e)
        {
            frmRunEditor editor = new frmRunEditor();
            Utils.Logger.Log("Opening run editor....");
            editor.Show(this);

        }

        private void btnLaunchOptimiser_Click(object sender, EventArgs e)
        {
            frmOptimiser optimisor = new frmOptimiser();

            Utils.Logger.Log("Opening optimiser....");

            optimisor.Show(this);
            //Utils.SetLogWindowLocation(this.Location.X, this.Location.Y + this.Size.Height + 10);

        }

        private void btnLaunchTester_Click(object sender, EventArgs e)
        {
            frmNetworkTester tester = new frmNetworkTester();

            Utils.Logger.Log("Opening network tester....");
            tester.Show(this);
            //Utils.SetLogWindowLocation(this.Location.X, this.Location.Y + this.Size.Height + 10);

        }

        private void btnAnalyser_Click(object sender, EventArgs e)
        {
            frmResultsAnalyser analyser = new frmResultsAnalyser();

            Utils.Logger.Log("Opening results analyser....");
            analyser.Show(this);

        }

        private void frmMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.Logger.StopLogger();
        }

      

        private void frmMainMenu_Shown(object sender, EventArgs e)
        {
            try
            {
                ((GUILogger)Utils.Logger).SetLogWindowLocation(this.Location.X, this.Location.Y + this.Size.Height + 50);
            }
            catch (Exception)
            {

            }
        }


        //private double getFitness(double[] weights)
        //{
        //    network.AllWeights = weights;          
        //    network.Run(new double[] { 0.2, 0.4, 0.222, 0.75, 0.9 });
        //    double[] output = network.OutputLayer.GetOutput();

        //    return Math.Abs(output[0] - 0.9) + Math.Abs(output[1] - 0.2);


        //}



        private void btnTestPSO_Click(object sender, EventArgs e)
        {

           
            /*
            LinearLayer inputLayer = new LinearLayer(5);
            SigmoidLayer hiddenLayer = new SigmoidLayer(2);        
            SigmoidLayer outputLayer = new SigmoidLayer(2);

            hiddenLayer.Initializer = new NormalizedRandomFunction();


            new PSOConnector(inputLayer, hiddenLayer);
            new PSOConnector(hiddenLayer, outputLayer);
            network = new PSONetwork(inputLayer, outputLayer);            
            
            Algorithm a = new Algorithm(new Problem(OptimisationProblem.Neural_Network,new Problem.FitnessHandler(getFitness),network.AllWeights));
            a.StartRun();
            int z  = 0;
            while (a.Error > 0 && z++ < 2000)
            {
                a.NextIteration();
                if (z % 500 == 0)
                {
                    //Utils.Logger.Log(getFitness(a.BestResult).ToString());
                }
            }
            a.EndRun();
            a.Finish();
             
            */
        }

        private void btnFaceExplorer_Click(object sender, EventArgs e)
        {
            frmFeretExplorer explorer = new frmFeretExplorer();

            Utils.Logger.Log("Opening face explorer....");
            explorer.Show(this);
        }

        private void btnImageTool_Click(object sender, EventArgs e)
        {
            frmImageTool imageTool = new frmImageTool();
            imageTool.Show(this);
        }

       

       

        
    }
}
