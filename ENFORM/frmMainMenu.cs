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
            Utils.Log("ENFORM booting up....");
            Utils.SetLogWindowLocation(this.Location.X, this.Location.Y + this.Size.Height + 10);
        }

        private void btnRunEditor_Click(object sender, EventArgs e)
        {
            using (frmRunEditor editor = new frmRunEditor())
            {
                editor.ShowDialog(this);
                
                Utils.Log("Opening run editor....");
                Utils.SetLogWindowLocation(editor.Location.X, editor.Location.Y + editor.Size.Height + 10);
            }
        }

        private void btnLaunchOptimiser_Click(object sender, EventArgs e)
        {
            using (frmOptimiser optimisor = new frmOptimiser())
            {
                optimisor.Show(this);
                Utils.Log("Opening optimsor....");
                Utils.SetLogWindowLocation(optimisor.Location.X, optimisor.Location.Y + optimisor.Size.Height + 10);
            }
        }

        private void btnLaunchTester_Click(object sender, EventArgs e)
        {
            using (frmNetworkTester tester = new frmNetworkTester())
            {
                tester.Show(this);
                Utils.Log("Opening network tester....");
                Utils.SetLogWindowLocation(tester.Location.X, tester.Location.Y + tester.Size.Height + 10);
            }
        }
    }
}
