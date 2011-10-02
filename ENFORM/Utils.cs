using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
namespace ENFORM
{
    public static class Utils
    {

        private static frmLogBox logbox;
        public delegate void logDelegate(string message);
        public delegate void setPosDelegate(int x, int y);
        public delegate void closeLogDelegate();
        

        static Utils()
        {
            (new System.Threading.Thread(() =>
            {
                (logbox = new frmLogBox()).ShowDialog();
            })).Start();         
        }

        public static double[] getImageWeights(Image image, InputGroup[] inputGroups)
        {
            Bitmap bitmap = (Bitmap)image;
            double[] outputs = new double[image.Width * image.Height * inputGroups.Length];
            int outputIndex = 0;

            foreach (InputGroup inputGroup in inputGroups)
            {
                for (int i = 0; i < inputGroup.Segments; i++)
                {
                    for (int j = 0; j < inputGroup.Segments; j++)
                    {
                        outputs[outputIndex++] = ((double)bitmap.GetPixel(j, i).R) / 255.0;
                    }

                }
            }
            return outputs;
        }

        private static void setPos(int x, int y)
        {
            logbox.Location = new Point(x, y);
            logbox.BringToFront();

        }

        private static void closeLogBox()
        {
            logbox.Close();
        }

        private static void log(string message)
        {
            logbox.AddLogEntry(message);
        }


        public static void CloseLogBox()
        {
            if (logbox.InvokeRequired)
            {
                logbox.Invoke(new closeLogDelegate(closeLogBox));
            }
            else
            {
                closeLogBox();
            }
        }

        public static void Log(string message)
        {
            if (logbox != null)
            {
                //if (!logbox.Visible)
                //{
                    
               //     logbox.Show();
               // }
                if (logbox.InvokeRequired)
                {
                    logbox.Invoke(new logDelegate(log), new object[] { message });
                }
                else
                {
                    log(message);
                }
            }
         }

        public static void Log(string format, params object[] args)
        {
            Log(String.Format(format, args));

        }

        public static void SetLogWindowLocation(int x, int y)
        {
            //Wait until logbox thread creates form
            while (logbox == null)
            {
                Thread.Sleep(10);
            }
            
            if (logbox.InvokeRequired)
            {
                logbox.Invoke(new setPosDelegate(setPos), new object[] { x, y });
            }
            else
            {
                setPos(x, y);
            }

        }
    }
}
