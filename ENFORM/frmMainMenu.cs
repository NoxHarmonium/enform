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
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnRunEditor_Click(object sender, EventArgs e)
        {
            frmRunEditor editor = new frmRunEditor();
            editor.ShowDialog(this);
        }

        private void btnLaunchOptimiser_Click(object sender, EventArgs e)
        {
            frmOptimiser optimisor = new frmOptimiser();
            optimisor.ShowDialog(this);
        }
    }
}
