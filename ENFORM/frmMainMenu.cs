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
            Utils.Log("ENFORM booting up....");
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
           
            
        }

        private void btnRunEditor_Click(object sender, EventArgs e)
        {
            using (frmRunEditor editor = new frmRunEditor())
            {
                Utils.Log("Opening run editor....");
                
                editor.ShowDialog(this);
                Utils.SetLogWindowLocation(this.Location.X, this.Location.Y + this.Size.Height + 10);
                
                
            }
        }

        private void btnLaunchOptimiser_Click(object sender, EventArgs e)
        {
            using (frmOptimiser optimisor = new frmOptimiser())
            {
                Utils.Log("Opening optimser....");
                
                optimisor.ShowDialog(this);
                Utils.SetLogWindowLocation(this.Location.X, this.Location.Y + this.Size.Height + 10);
            }
        }

        private void btnLaunchTester_Click(object sender, EventArgs e)
        {
            using (frmNetworkTester tester = new frmNetworkTester())
            {
                Utils.Log("Opening network tester....");               
                tester.ShowDialog(this);
                Utils.SetLogWindowLocation(this.Location.X, this.Location.Y + this.Size.Height + 10);
            }
        }

        private void frmMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utils.CloseLogBox();
        }

      

        private void frmMainMenu_Shown(object sender, EventArgs e)
        {
            Utils.SetLogWindowLocation(this.Location.X, this.Location.Y + this.Size.Height + 10);
        }

        private void btnTestPSO_Click(object sender, EventArgs e)
        {
            SPSO_2007.Algorithm a = new SPSO_2007.Algorithm();
            a.StartRun();           
            while (a.Error > 0.01)
            {
                a.NextIteration();
            }
            a.EndRun();
            a.Finish();
            
        }

       

        
    }
}
