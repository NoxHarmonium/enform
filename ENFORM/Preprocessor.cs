using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ENFORM
{
    class Preprocessor
    {
        private int filterLevel = 0;

        public int FilterLevel
        {
            get { return filterLevel; }
            set { filterLevel = value; }
        }
        private bool contrastStretch = false;

        public bool ContrastStretch
        {
            get { return contrastStretch; }
            set { contrastStretch = value; }
        }
        private bool histogram = false;

        public bool Histogram
        {
            get { return histogram; }
            set { histogram = value; }
        }
        private bool gaussian = false;

        public bool Gaussian
        {
            get { return gaussian; }
            set { gaussian = value; }
        }
        private decimal gaussianStrength = 3.0m;

        public decimal GaussianStrength
        {
            get { return gaussianStrength; }
            set { gaussianStrength = value; }
        }
        private bool contrastAdjustment = false;

        public bool ContrastAdjustment
        {
            get { return contrastAdjustment; }
            set { contrastAdjustment = value; }
        }
        private decimal contrastStrength = 0.0m;

        public decimal ContrastStrength
        {
            get { return contrastStrength; }
            set { contrastStrength = value; }
        }
        private bool greyscale = true;

        public bool Greyscale
        {
            get { return greyscale; }
            set { greyscale = value; }
        }
        private bool threshold = false;

        public bool Threshold
        {
            get { return threshold; }
            set { threshold = value; }
        }
        private bool bradley = false;

        public bool Bradley
        {
            get { return bradley; }
            set { bradley = value; }
        }
        private decimal thresholdStrength = 0.0m;

        public decimal ThresholdStrength
        {
            get { return thresholdStrength; }
            set { thresholdStrength = value; }
        }

        private Size imageSize = new Size();

        public Size ImageSize
        {
            get { return imageSize; }
            set { imageSize = value; }
        }

        private ScalingMethods scalingMethod = ScalingMethods.Nearest_Neighbor;

        public ScalingMethods ScalingMethod
        {
            get { return scalingMethod; }
            set { scalingMethod = value; }
        }

        private bool keepAspectRatio = true;

        public bool KeepAspectRatio
        {
            get { return keepAspectRatio; }
            set { keepAspectRatio = value; }
        }

        private Bitmap resize(Bitmap image, int newWidth, int newHeight)
        {


            if (KeepAspectRatio)
            {

                double ratio = (double)newHeight / (double)image.Height;
                newWidth = (int)((double)image.Width * ratio);

            }

            AForge.Imaging.Filters.Crop cropper = new AForge.Imaging.Filters.Crop(new Rectangle(0, 0, newWidth, newHeight));

            if (ScalingMethod == ScalingMethods.Nearest_Neighbor || ScalingMethod == ScalingMethods.Bicubic)
            {
                AForge.Imaging.Filters.ResizeNearestNeighbor resizer = new AForge.Imaging.Filters.ResizeNearestNeighbor(newWidth, newHeight);
                image = cropper.Apply(resizer.Apply((Bitmap)image));
            }
            if (ScalingMethod == ScalingMethods.Bicubic)
            {
                MessageBox.Show("Bicubic resize is not implimented for now.\nNReverting to nearest neighbor...");
                //AForge.Imaging.Filters.ResizeBicubic resizer = new AForge.Imaging.Filters.ResizeBicubic(newWidth, newHeight);
                //image = cropper.Apply(resizer.Apply((Bitmap)image));
            }
            if (ScalingMethod == ScalingMethods.Bilinear)
            {
                AForge.Imaging.Filters.ResizeBilinear resizer = new AForge.Imaging.Filters.ResizeBilinear(newWidth, newHeight);
                image = cropper.Apply(resizer.Apply((Bitmap)image));
            }

            return image;
        }


        Bitmap convertFormatTo32(Bitmap image)
        {
            return AForge.Imaging.Image.Clone(image, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            /*
            return image.Clone(
                new Rectangle(0,
                    0,
                    image.Size.Width,
                    image.Size.Height),
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            */

        }

        Bitmap convertFormatToGS(Bitmap image)
        {
            return AForge.Imaging.Image.Clone(image, System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);
            
            /*
            return image.Clone(
                new Rectangle(0,
                    0,
                    image.Size.Width,
                    image.Size.Height),
                    System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);
            */

        }

        public Bitmap Process(Bitmap image)
        {
            Bitmap filteredImage = convertFormatTo32(image);



            if (filterLevel >= 0)
            {
                filteredImage = resize(filteredImage, ImageSize.Width, ImageSize.Height);
            }
            if (filterLevel >= 1)
            {

                if (ContrastStretch)
                {
                    AForge.Imaging.Filters.ContrastStretch stretcher = new AForge.Imaging.Filters.ContrastStretch();
                    filteredImage = stretcher.Apply(filteredImage);

                }



                if (Histogram)
                {
                    AForge.Imaging.Filters.HistogramEqualization histogrammer = new AForge.Imaging.Filters.HistogramEqualization();
                    filteredImage = histogrammer.Apply(filteredImage);

                }

                if (Gaussian)
                {
                    AForge.Imaging.Filters.GaussianBlur blurrer = new AForge.Imaging.Filters.GaussianBlur();
                    blurrer.Size = (int)GaussianStrength;
                    filteredImage = blurrer.Apply(filteredImage);
                }

                if (ContrastAdjustment)
                {
                    AForge.Imaging.Filters.ContrastCorrection contraster = new AForge.Imaging.Filters.ContrastCorrection();
                    contraster.Factor = (float)ContrastStrength;
                    filteredImage = contraster.Apply(filteredImage);
                }


                if (Greyscale)
                {
                    filteredImage = AForge.Imaging.Filters.Grayscale.CommonAlgorithms.BT709.Apply(filteredImage);
                    //Greyscale downgrades format
                    // filteredImage  = convertFormatTo32(filteredImage.InternalBitmap);
                }
                if (Threshold)
                {
                    //filteredImage.InternalBitmap = convertFormatToGS(filteredImage.InternalBitmap);
                    AForge.Imaging.Filters.Threshold thresholder = new AForge.Imaging.Filters.Threshold();
                    thresholder.ThresholdValue = (int)(((double)ThresholdStrength / 10.0) * 255.0);
                    filteredImage = thresholder.Apply(filteredImage);

                }
                if (Bradley)
                {
                    AForge.Imaging.Filters.BradleyLocalThresholding bradlifier = new AForge.Imaging.Filters.BradleyLocalThresholding();

                    filteredImage = bradlifier.Apply(filteredImage);

                }
            }

            return filteredImage;

        }
               
            
              

    }
}
