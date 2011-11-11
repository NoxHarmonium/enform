using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ENFORM.Core;

namespace ENFORM.GUI
{
 
    
    public partial class ImageViewer : UserControl
    {
        protected bool editable = false;
        protected CustomImage customImage;
        protected System.Drawing.Image currentImage;
        protected bool drawing = false;
        protected Color drawingColour = Color.Black;
        protected bool drawInputGroupOverlay = false;
        protected InputGroupType inputGroupType;
        protected int segments;
        private ScalingMethods scalingMethod = ScalingMethods.Nearest_Neighbor;

        public ScalingMethods ScalingMethod
        {
            get { return scalingMethod; }
            set { scalingMethod = value; }
        }

        public ImageViewer()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(ImageViewer_Paint);
            
        }

        void ImageViewer_Paint(object sender, PaintEventArgs e)
        {
            if (currentImage != null)
            {
                this.LoadImage(currentImage);
            }
        }
        public Color DrawingColour
        {
            get
            {
                return drawingColour;
            }
            set
            {
                drawingColour = value;
            }
        }

        public void DrawInputGroupOverlay(InputGroupType type, int segments)
        {
            drawInputGroupOverlay = true;

            this.segments = segments;
            this.inputGroupType = type;



        }

        public void LoadImage(System.Drawing.Image image)
        {

            currentImage = image;
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            double ratio = ((double)image.Width / (double)this.Width);
            
            Bitmap overlay = new Bitmap(image.Width, image.Height);
            Graphics gOverlay = Graphics.FromImage(overlay);

            int newWidth = (int)((double)image.Width / ratio);
            int newHeight = (int)((double)image.Height / ratio);

            if (drawInputGroupOverlay)
            {

                if (inputGroupType == InputGroupType.Horozontal || inputGroupType == InputGroupType.Grid)
                {


                    for (int i = 1; i < segments; i++)
                    {
                        gOverlay.DrawLine(new Pen(Brushes.Red, 0.5f), 0, (int)Math.Round((double)i * ((double)image.Height / (double)segments)), image.Width, (int)Math.Round((double)i * ((double)image.Height / (double)segments)));

                    }

                }

                if (inputGroupType == InputGroupType.Vertical || inputGroupType == InputGroupType.Grid)
                {

                    for (int i = 1; i < segments; i++)
                    {
                        gOverlay.DrawLine(Pens.Red, (int)Math.Round((double)i * ((double)image.Width / (double)segments)), 0, (int)Math.Round((double)i * ((double)image.Width / (double)segments)), image.Height);

                    }

                }


            }
            

        

           

            if( scalingMethod == ENFORM.Core.ScalingMethods.Bicubic)
            {
                MessageBox.Show("Not implimented yet, reverting to nearest neighbor...");
                /*
                scalingMethod = ENFORM.ScalingMethod.Nearest_Neighbor;
                AForge.Imaging.Filters.ResizeBicubic resize = new AForge.Imaging.Filters.ResizeBicubic(newWidth, newHeight);
                g.DrawImage(resize.Apply((Bitmap)image), new Point(0, 0));
                g.DrawImage(resize.Apply((Bitmap)overlay), new Point(0, 0));
                 * */
                scalingMethod = ENFORM.Core.ScalingMethods.Nearest_Neighbor;
            }
            if (scalingMethod == ENFORM.Core.ScalingMethods.Bilinear)
            {
                AForge.Imaging.Filters.ResizeBilinear resize = new AForge.Imaging.Filters.ResizeBilinear(newWidth, newHeight);
                g.DrawImage(resize.Apply((Bitmap)image), new Point(0, 0));
                g.DrawImage(resize.Apply((Bitmap)overlay), new Point(0, 0));
            }
            if (scalingMethod == ENFORM.Core.ScalingMethods.Nearest_Neighbor)
            {
                AForge.Imaging.Filters.ResizeNearestNeighbor resize = new AForge.Imaging.Filters.ResizeNearestNeighbor(newWidth, newHeight);
                g.DrawImage(resize.Apply((Bitmap)image), new Point(0, 0));
                AForge.Imaging.Filters.ResizeNearestNeighbor resizeB = new AForge.Imaging.Filters.ResizeNearestNeighbor(newWidth, newHeight);
                g.DrawImage(resizeB.Apply((Bitmap)overlay), new Point(0, 0));
            }

            
           
            //g.DrawImage(resize.Apply((Bitmap)image), new Point(0,0));
           // g.DrawImage(resize.Apply((Bitmap)overlay), new Point(0,0));
           
            editable = true;
        }

      

        private void ImageViewer_MouseClick(object sender, MouseEventArgs e)
        {
            if (editable)
            {
                Graphics g = Graphics.FromImage(currentImage);

                double ratio = ((double)currentImage.Width / (double)this.Width);
                //g.DrawLine(new Pen(new SolidBrush(Color.Black),1f),new Point ((int)((double)e.X*ratio),(int)((double)e.Y*ratio)),new Point ((int)((double)e.X*ratio),(int)((double)e.Y*ratio)));
                g.FillRectangle(new SolidBrush(drawingColour), new Rectangle((int)((double)e.X * ratio), (int)((double)e.Y * ratio), 1, 1));

                LoadImage(currentImage);
                editable = true;
            }
        }

        private void ImageViewer_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing && editable)
            {
                Graphics g = Graphics.FromImage(currentImage);

                double ratio = ((double)currentImage.Width / (double)this.Width);
                //g.DrawLine(new Pen(new SolidBrush(Color.Black),1f),new Point ((int)((double)e.X*ratio),(int)((double)e.Y*ratio)),new Point ((int)((double)e.X*ratio),(int)((double)e.Y*ratio)));
                g.FillRectangle(new SolidBrush(drawingColour), new Rectangle((int)((double)e.X * ratio), (int)((double)e.Y * ratio), 1, 1));

                LoadImage(currentImage);
                editable = true;
            }
        }

        private void ImageViewer_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
        }

        private void ImageViewer_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;
        }

        private void ImageViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
