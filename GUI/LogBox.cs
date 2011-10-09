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
    public partial class frmLogBox : Form
    {
        private Dictionary<string, TabPage> threadTabs = new Dictionary<string, TabPage>();
        
        public frmLogBox()
        {
            InitializeComponent();
        }

        private void LogBox_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
        }

        public void AddLogEntry(string message,string thread)
        {
            if (!threadTabs.ContainsKey(thread))
            {
                
                TabPage tab = new TabPage();
                tab.Location = new System.Drawing.Point(4, 22);
                tab.Name = "tab" + thread.Trim().Replace(' ', '_');
                tab.Padding = new System.Windows.Forms.Padding(3);
                tab.Size = new System.Drawing.Size(859, 226);
                tab.Text = thread;
                tab.UseVisualStyleBackColor = true;
                threadTabs[thread] = tab;
                tabControl1.TabPages.Add(tab);

                TextBox txtLogBox = new TextBox();
                txtLogBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtLogBox.Location = new System.Drawing.Point(6, 6);
                txtLogBox.Multiline = true;
                txtLogBox.Name = "txtLogBox";
                txtLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
                txtLogBox.Size = new System.Drawing.Size(847, 214);
                txtLogBox.TabIndex = 1;
                tab.Controls.Add(txtLogBox);
                txtLogBox.Text += "[" + DateTime.Now.ToLongTimeString() + "] - " + message + Environment.NewLine;
                txtLogBox.SelectionStart = txtLogBox.Text.Length;
                txtLogBox.ScrollToCaret();
                txtLogBox.Refresh();
            }
            else
            {
                TabPage tab = threadTabs[thread];
                TextBox txtLogBox = (TextBox) tab.Controls[0];
                txtLogBox.Text += "[" + DateTime.Now.ToLongTimeString() + "] - " + message + Environment.NewLine;
                txtLogBox.SelectionStart = txtLogBox.Text.Length;
                txtLogBox.ScrollToCaret();
                txtLogBox.Refresh();
            }
            
            /*
            txtLogBox.Text += "[" + DateTime.Now.ToLongTimeString() + "] - " + message + Environment.NewLine;
            txtLogBox.SelectionStart = txtLogBox.Text.Length;
            txtLogBox.ScrollToCaret();
            txtLogBox.Refresh();
             */

        }
    }
}
