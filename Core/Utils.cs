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

        private static Logging.ILogger logger;

        public static Logging.ILogger Logger
        {
            get { return logger; }
            set { logger = value; }
        }
        
        

        static Utils()
        {
            
           
        }

        


       


        public static double[] getImageWeights(Image image, InputGroup[] inputGroups)
        {
            Bitmap bitmap = (Bitmap)image;
            double[] outputs = new double[image.Width * image.Height * inputGroups.Length];
            int outputIndex = 0;

            foreach (InputGroup inputGroup in inputGroups)
            {
                for (int i = 0; i < image.Width; i++)
                {
                    for (int j = 0; j < image.Height; j++)
                    {
                        outputs[outputIndex++] = ((double)bitmap.GetPixel(i, j).R) / 255.0;
                    }

                }
            }
            if (outputs.Length != 150)
            {
                throw new Exception("wtf");
            }
            return outputs;
        }

       

       

       


    }
}
