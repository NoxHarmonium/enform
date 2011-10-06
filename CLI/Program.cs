using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ENFORM.Core;
using System.Threading;

namespace ENFORM.CLI
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            int runCount = 0;
            int threadCount = 0;
            List<string> files = new List<string>();
            
            Console.WriteLine("ENFORM Command Line Interface");
            Console.WriteLine("By Sean Dawson");
            Console.WriteLine("Switching to file logging system now...");
            Thread.CurrentThread.Name = "Main Thread";
            Utils.Logger.StartLogger();

            Utils.Logger.Log("Attempting to load file...");

            if (File.Exists(args[0]))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(args[0]))
                    {
                        reader.ReadLine();
                        string[] param = reader.ReadLine().Split(new char[] {','});
                        runCount = Convert.ToInt32(param[0]);
                        threadCount = Convert.ToInt32(param[1]);
                        while (!reader.EndOfStream)
                        {
                            files.Add(reader.ReadLine());
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

        }
    }
}
