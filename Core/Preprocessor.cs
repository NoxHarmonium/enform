using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace ENFORM.Core
{
    public class Preprocessor
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

            int aWidth = newWidth;
            if (KeepAspectRatio)
            {
                if (image.Width < image.Height)
                {
                    double ratio = (double)newWidth / (double)image.Width;
                    aWidth = (int)((double)image.Width * ratio);
                }
                else
                {
                    double ratio = (double)newHeight / (double)image.Height;
                    aWidth = (int)((double)image.Width * ratio);
                }
                

            }


            AForge.Imaging.Filters.Crop cropper = new AForge.Imaging.Filters.Crop(new Rectangle(0, 0, newWidth, newHeight));

            Utils.Logger.Log("->Scaling and cropping...");
            if (ScalingMethod == ScalingMethods.Nearest_Neighbor || ScalingMethod == ScalingMethods.Bicubic)
            {
                Utils.Logger.Log("-->Nearest Neighbor...");
                AForge.Imaging.Filters.ResizeNearestNeighbor resizer = new AForge.Imaging.Filters.ResizeNearestNeighbor(aWidth, newHeight);
                image = resizer.Apply((Bitmap)image);
                Utils.Logger.Log("-->Cropping...");
                image = cropper.Apply(image);
            }
            if (ScalingMethod == ScalingMethods.Bicubic)
            {
                Utils.Logger.Log("-->Bicubic resize is not implimented for now.\nNReverting to nearest neighbor...");
                AForge.Imaging.Filters.ResizeNearestNeighbor resizer = new AForge.Imaging.Filters.ResizeNearestNeighbor(aWidth, newHeight);
                image = resizer.Apply((Bitmap)image);
                Utils.Logger.Log("-->Cropping...");
                image = cropper.Apply(image);
            }
            if (ScalingMethod == ScalingMethods.Bilinear)
            {
                Utils.Logger.Log("-->Bilinear...");
                AForge.Imaging.Filters.ResizeBilinear resizer = new AForge.Imaging.Filters.ResizeBilinear(aWidth, newHeight);
                image = resizer.Apply((Bitmap)image);
                Utils.Logger.Log("-->Cropping...");
                image = cropper.Apply(image);
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
            Utils.Logger.Log("Converting to 32 bit...");
           
           image = convertFormatTo32(image);



           
            if (filterLevel >= 1)
            {
                Utils.Logger.Log("Advanced filters...");
                if (ContrastStretch)
                {
                    Utils.Logger.Log("->Contrast Stretch...");
                    AForge.Imaging.Filters.ContrastStretch stretcher = new AForge.Imaging.Filters.ContrastStretch();
                    image = stretcher.Apply(image);

                }



                if (Histogram)
                {
                    Utils.Logger.Log("->Histogram EQ...");
                    AForge.Imaging.Filters.HistogramEqualization histogrammer = new AForge.Imaging.Filters.HistogramEqualization();
                    image = histogrammer.Apply(image);

                }

                if (Gaussian)
                {
                    Utils.Logger.Log("->Gaussian Blur..");
                    AForge.Imaging.Filters.GaussianBlur blurrer = new AForge.Imaging.Filters.GaussianBlur();
                    blurrer.Size = (int)GaussianStrength;
                    image = blurrer.Apply(image);
                }

                if (ContrastAdjustment)
                {
                    Utils.Logger.Log("->Contrast Adjustment..");
                    AForge.Imaging.Filters.ContrastCorrection contraster = new AForge.Imaging.Filters.ContrastCorrection();
                    contraster.Factor = (float)ContrastStrength;
                    image = contraster.Apply(image);
                }


                if (Greyscale)
                {
                    
                    Utils.Logger.Log("->Greyscale..");
                    //image = convertFormatTo32(image);
                    image = AForge.Imaging.Filters.Grayscale.CommonAlgorithms.BT709.Apply(image);
                    //Greyscale downgrades format
                    // image  = convertFormatTo32(image.InternalBitmap);
                }
                if (Threshold)
                {
                    Utils.Logger.Log("->Threshold..");
                    //image.InternalBitmap = convertFormatToGS(image.InternalBitmap);
                    AForge.Imaging.Filters.Threshold thresholder = new AForge.Imaging.Filters.Threshold();
                    thresholder.ThresholdValue = (int)(((double)ThresholdStrength / 10.0) * 255.0);
                    image = thresholder.Apply(image);

                }
                if (Bradley)
                {
                    Utils.Logger.Log("->Bradley..");
                    AForge.Imaging.Filters.BradleyLocalThresholding bradlifier = new AForge.Imaging.Filters.BradleyLocalThresholding();

                    image = bradlifier.Apply(image);

                }
            }

            if (filterLevel >= 0)
            {
                Utils.Logger.Log("Basic resize...");
                image = resize(image, ImageSize.Width, ImageSize.Height);
            }
            Utils.Logger.Log("Preprocessor finished...");
            if (image.Width != this.imageSize.Width || image.Height != this.imageSize.Height)
            {
                //throw new Exception("WTF?");
            }
            return image;

        }
               
            
              

    }
}
