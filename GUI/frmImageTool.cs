using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ENFORM.GUI
{
    public partial class frmImageTool : Form
    {
        public frmImageTool()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlgFolder = new FolderBrowserDialog())
            {
                dlgFolder.Description = "Select a folder to scan for images...";
                if (dlgFolder.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = dlgFolder.SelectedPath;
                }           


            }
        }
    }
}
