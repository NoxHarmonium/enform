using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ENFORM
{
    public partial class NameDialog : Form
    {
        public string NameText
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
            }
        }

        public int SampleType
        {
            get
            {
                return 1-cmbSampleType.SelectedIndex;
            }
            set
            {
                cmbSampleType.SelectedIndex = 1-value;
            }
        }
        
        public NameDialog()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void NameDialog_Load(object sender, EventArgs e)
        {
            
        }

       


    }
}
