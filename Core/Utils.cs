using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
namespace ENFORM.Core
{
    public static class Utils
    {

        //private static frmLogBox logbox;
        private static bool ready = false;
        private static ILogger logger;

        public static ILogger Logger
        {
            get { return logger; }
            set { logger = value; }
        }
        
        

        static Utils()
        {
            
           
        }

        static void logbox_Shown(object sender, EventArgs e)
        {
            ready = true;
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

       

       

       


    }
}
