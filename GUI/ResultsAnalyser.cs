using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ENFORM.Core;
using System.IO;

namespace ENFORM.GUI
{
    public partial class frmResultsAnalyser : Form
    {
        public frmResultsAnalyser()
        {
            InitializeComponent();
        }

        private void btnAddRun_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlgLoad = new OpenFileDialog())
            {
                dlgLoad.AddExtension = true;
                dlgLoad.DefaultExt = "erun";
                dlgLoad.Filter = "ENFORM run file(*.erun)|*.erun";
                dlgLoad.Title = "Open run file...";
                dlgLoad.Multiselect = true;

                if (dlgLoad.ShowDialog() == DialogResult.OK)
                {
                    foreach (string filename in dlgLoad.FileNames)
                    {

                        ListViewItem item = new ListViewItem(
                            new string[] { 
                            filename.Substring(filename.LastIndexOf("\\")+1),
                            "",filename});
                        lstRuns.Items.Add(item);
                    }


                }


            } 
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Do you want to also write out time as well as fitness?", "Write time?", MessageBoxButtons.YesNo);
            
            for (int i = 0; i < lstRuns.Items.Count; i++)
            {

                
                string file = lstRuns.Items[i].SubItems[2].Text;
                Utils.Logger.Log("Processing file: " + file);
                float[] averageResults = getAverageResults(file);
                float[] averageTimes = null;
                if (r == DialogResult.Yes)
                {
                    averageTimes = getAverageTimes(file);
                }
                Utils.Logger.Log("Writing file: " + file + ".txt");
                using (StreamWriter writer = new StreamWriter(file + ".txt", false))
                {
                    for (int j = 0; j< averageResults.Length; j++)
                    {
                        if (r == DialogResult.Yes)
                        {
                            writer.WriteLine(averageTimes[j].ToString() + "," + averageResults[j].ToString());
                        }
                        else
                        {
                            writer.WriteLine(averageResults[j].ToString());
                        }
                    }
                    writer.Close();
                }
            
            }
        }

        private float[] getAverageResults(string filename)
        {

            DataAccess dataAccess = new DataAccess(filename);
            Run[] runs = dataAccess.GetRuns();
            float[][] results = new float[runs.Length][];
            for (int j = 0; j < runs.Length; j++)
            {
                results[j] = dataAccess.GetResults(runs[j]);
            }
            
            int maxResultLength = 0;
            int mrlIndex = -1;
            for (int j = 0; j < results.Length; j++)
            {
                if (results[j].Length > maxResultLength)
                {
                    maxResultLength = results[j].Length;
                    mrlIndex = j;
                }
            }

            for (int j = 0; j < maxResultLength; j++)
            {
                float total = 0.0f;
                int z = 0;
                for (int k = 0; k < results.Length; k++)
                {
                    if (j < results[k].Length) 
                    {
                        total += results[k][j];
                        z++;
                    }
                }
                
                total /= z;
                if (float.IsNaN(total))
                {
                    throw new Exception("");
                }
                results[mrlIndex][j] = total;
            }

            return results[0];
        }

        private float[] getAverageTimes(string filename)
        {

            DataAccess dataAccess = new DataAccess(filename);
            Run[] runs = dataAccess.GetRuns();
            float[][] results = new float[runs.Length][];
            for (int j = 0; j < runs.Length; j++)
            {
                results[j] = dataAccess.GetTimes(runs[j]);
            }

            int maxResultLength = 0;
            int mrlIndex = -1;
            for (int j = 0; j < results.Length; j++)
            {
                if (results[j].Length > maxResultLength)
                {
                    maxResultLength = results[j].Length;
                    mrlIndex = j;
                }
            }

            for (int j = 0; j < maxResultLength; j++)
            {
                float total = 0.0f;
                int z = 0;
                for (int k = 0; k < results.Length; k++)
                {
                    if (results[k].Length < k)
                    {
                        total += results[k][j];
                        z++;
                    }
                }

                total /= z;
                if (float.IsNaN(total))
                {
                    throw new Exception("ddd");
                }
                results[mrlIndex][j] = total;
            }

            return results[0];
        }
    }
}
