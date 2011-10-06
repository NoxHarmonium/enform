using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ENFORM.GUI
{
    public partial class OptimisationStatus : UserControl
    {
        public double MeanErrorSquared
        {
            get
            {
                return Convert.ToDouble(lblMeanErrorValue.Text);
            }
            
            set
            {
                lblMeanErrorValue.Text = value.ToString();
            }

        }

        public String OptimisationMethod
        {
            get
            {
                return lblOptimisorValue.Text;
            }
            set
            {
                lblOptimisorValue.Text = value;
            }


        }

        public int CurrentEpoch
        {
            get
            {
                return Int32.Parse(lblCurrentEpochValue.Text);

            }
            set
            {
                lblCurrentEpochValue.Text = value.ToString();
            }

        }

        public string Message
        {
            get
            {
                return lblMessageValue.Text;
            }
            set
            {
                lblMessageValue.Text = value;
            }

        }
        
        public OptimisationStatus()
        {
            InitializeComponent();
        }

        private void OptimisationStatus_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
