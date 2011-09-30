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
    public partial class frmLogBox : Form
    {
        public frmLogBox()
        {
            InitializeComponent();
        }

        private void LogBox_Load(object sender, EventArgs e)
        {

        }

        public void AddLogEntry(string message)
        {
            txtLogBox.Text += "[" + DateTime.Now.ToLongTimeString() + "] - " + message + Environment.NewLine;
            txtLogBox.SelectionStart = txtLogBox.Text.Length;
            txtLogBox.ScrollToCaret();
            txtLogBox.Refresh();

        }
    }
}
