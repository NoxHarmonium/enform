using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ENFORM
{
    public delegate void ColourSelectedHandler(object sender, Color selectedColour);


    public partial class ColourPicker : UserControl
    {

        public event ColourSelectedHandler ColourSelected;
        protected virtual void OnColourSelected(Color selectedColor)
        {
            if (ColourSelected != null)
            {
                ColourSelected(this, selectedColour);
            }
        }
        protected Color selectedColour;
        
        public ColourPicker()
        {
            InitializeComponent();
        }

        public Color SelectedColour
        {
            get
            {
                return selectedColour;
            }

        }

        private void ColourPicker_Load(object sender, EventArgs e)
        {

        }

        private void ColourPicker_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < 26; i++)
            {
                int greyLevel = i * 10;
                if (greyLevel == 250)
                {
                    greyLevel = 255;
                }

                g.FillRectangle(new SolidBrush(Color.FromArgb(greyLevel, greyLevel, greyLevel)), new Rectangle(i * 10, 0, 10, 20));
            }
        }

        private void ColourPicker_MouseClick(object sender, MouseEventArgs e)
        {
            int greyLevel = e.X ;
            if (greyLevel == 250)
            {
                greyLevel = 255;
            }
            selectedColour = Color.FromArgb(greyLevel, greyLevel, greyLevel);
            OnColourSelected(selectedColour);
            
        }
    }
}
