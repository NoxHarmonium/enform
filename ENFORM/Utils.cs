using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace ENFORM
{
    public static class Utils
    {

        private static frmLogBox logbox;

        static Utils()
        {
            logbox = new frmLogBox();
            logbox.Owner = null;
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

        public static void Log(string message)
        {
            if (logbox != null)
            {
                if (!logbox.Visible)
                {
                    logbox.Show();
                }
                logbox.AddLogEntry(message);
            }
         }

        public static void SetLogWindowLocation(int x, int y)
        {
            logbox.Location = new Point(x, y);

        }
    }
}
