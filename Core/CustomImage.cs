using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ENFORM
{
    public class CustomImage 
    {
        private string name = "";
        private Bitmap image;
        private bool editable;

        public bool Editable
        {
            get { return editable; }
            set { editable = value; }
        }

        public Bitmap InternalBitmap
        {
          get { return image; }
          set { image = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public CustomImage(int width, int height, string name, bool editable)
        {
            image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            g.FillRectangle(Brushes.White, new Rectangle(0, 0, width, height));


            this.name = name;
            this.editable = editable;
        }
        public CustomImage(Bitmap internalImage, string name, bool editable)
        {
            image = internalImage;
            this.name = name;
            this.editable = editable;
        }
    }
}
