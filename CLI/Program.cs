using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ENFORM.Core;
using System.Threading;
using System.Diagnostics;
using ENFORM.Core.Logging;

namespace ENFORM.CLI
{
    class Program
    {

        static private Thread[] threads;

        static private Queue<Job> jobs = new Queue<Job>();
        static private int runCount = -1;
        static private int threadCount = -1;
        static private string rootDir = "";

    

        static void Main(string[] args)
        {
         
            
            List<string> files = new List<string>();

            Console.WriteLine("ENFORM Command Line Interface");
            Console.WriteLine("By Sean Dawson");
            Console.WriteLine("Switching to file logging system now...");
                   
            
            Thread.CurrentThread.Name = "Main Thread";
            Utils.Logger = new SQLiteLogger();
            Utils.Logger.StartLogger();

            if (args.Length == 2)
            {
                try
                {
                    if (Convert.ToInt32(args[1]) == 1)
                    {
                        SQLiteLogger l = (SQLiteLogger)Utils.Logger;

                        l.WriteToStdOut= true;
                    }
                }
                catch (Exception)
                {

                }
            }


            Utils.Logger.Log("Attempting to load file...");

            if (args.Length > 0 && File.Exists(args[0]))
            {
                try
                {
                    rootDir = new FileInfo(args[0]).Directory.FullName;
                    
                    using (StreamReader reader = new StreamReader(args[0]))
                    {
                        reader.ReadLine();
                        string[] param = reader.ReadLine().Split(new char[] { ',' });
                        runCount = Convert.ToInt32(param[0]);
                        threadCount = Convert.ToInt32(param[1]);
                        threads = new Thread[threadCount];
                        while (!reader.EndOfStream)
                        {
                            files.Add(rootDir+ "/" + reader.ReadLine());
                        }
                    }

                }
                catch (Exception e)
                {
                    Utils.Logger.Log("Error loading batch file:");
                    Utils.Logger.Log(e.Message);
                    Utils.Logger.Log(e.StackTrace);
                }
            }
            else
            {
                Console.WriteLine("Error passing command line parameters.\nExiting...");
                Utils.Logger.Log("Error parsing command lines:");
                return;
            }
            Utils.Logger.Log("Loading up runs...");
            foreach (string filename in files)
            {
                beginRun(filename);
            }
            for (int i = 0; i < threadCount; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(runThread));
                threads[i].Name = i.ToString();
                threads[i].Start(i);
            }
            Utils.Logger.Log("Waiting on threads...");
            foreach (Thread t in threads)
            {
                t.Join();
            }
            Utils.Logger.Log("All threads closed...");
            Utils.Logger.Log("Exiting...");
            Utils.Logger.StopLogger();
        }


        static private void runThread(object o)
        {

          

            Job currentJob;

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
                    Utils.Logger.Log("Jobs done!");
                    return;
                }

                currentJob = job;
                Utils.Logger.Log("Optimising job: " + job.Filename);

                Optimiser optimiser = new Optimiser(job.Filename);                

                double mes = 1;

                mes = optimiser.Optimise();
            }

        }

        static private void beginRun(string filename)
        {
            

            for (int i = 0; i < runCount; i++)
            {
                jobs.Enqueue(new Job(filename));
            }


            





        }
    }
}
