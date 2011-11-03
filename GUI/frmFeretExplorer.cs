using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ENFORM.GUI
{
    public partial class frmFeretExplorer : Form
    {
        private Dictionary<feretDataSet.facesRow, Boolean> rowIndex = new Dictionary<feretDataSet.facesRow, Boolean>();
        
        public frmFeretExplorer()
        {
            InitializeComponent();
        }

        private void frmFeretExplorer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'feretDataSet.faces' table. You can move, or remove it, as needed.
            this.facesTableAdapter.Fill(this.feretDataSet.faces);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void refresh()
        {
            try
            {
                lstSelect.Items.Clear();
                feretDataSet.facesRow[] rows = (feretDataSet.facesRow[]) feretDataSet.faces.Select(txtQuery.Text);
                foreach (feretDataSet.facesRow row in rows)
                {
                    lstSelect.Items.Add(new ListViewItem(row.subjectid.ToString(), rowIndex[row].ToString()));
                }

                txtQuery.ForeColor = Color.Black;
            }
            catch (Exception)
            {
                txtQuery.ForeColor = Color.Red;
            }

        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            feretDataSet.faces.Rows.Clear();
            int rejectCount = 0;

            using (FolderBrowserDialog dlgFolder = new FolderBrowserDialog())
            {
                if (dlgFolder.ShowDialog() == DialogResult.OK)
                {
                    
                    string rootPath = dlgFolder.SelectedPath;
                    DirectoryInfo dvd1 = new DirectoryInfo(rootPath + "\\dvd1\\data\\ground_truths\\name_value");
                    foreach (DirectoryInfo face in dvd1.GetDirectories())
                    {
                        try
                        {
                            string id = face.Name;
                            FileInfo[] files = face.GetFiles();

                            string rootFile = "";
                            using (StreamReader r = new StreamReader(face.FullName + "\\" + face.Name + ".txt"))
                            {
                                rootFile = r.ReadToEnd();
                            }

                            string[] entries = rootFile.Split('\n');
                            feretDataSet.facesRow row = feretDataSet.faces.NewfacesRow();

                            for (int i = 0; i < entries.Length; i++)
                            {
                                entries[i] = entries[i].Substring(entries[i].IndexOf('=') + 1);

                            }
                            row.subjectid = Convert.ToInt32(face.Name);
                            row.gender = entries[1];
                            row.yob = Convert.ToInt32(entries[2]);
                            row.race = entries[3];
                            string childFile = "";

                            foreach (FileInfo file in files)
                            {
                                if (file.Name.Contains("fa"))
                                {
                                    using (StreamReader r = new StreamReader(file.FullName))
                                    {
                                        childFile = r.ReadToEnd();
                                        break;
                                    }
                                }

                            }


                            entries = childFile.Split('\n');
                            for (int i = 0; i < entries.Length; i++)
                            {
                                entries[i] = entries[i].Substring(entries[i].IndexOf('=') + 1);

                            }

                            row.expression = entries[9];
                            row.yaw = Convert.ToInt32(entries[10]);
                            row.pitch = Convert.ToInt32(entries[11]);
                            row.roll = Convert.ToInt32(entries[12]);
                            row.glasses = Convert.ToInt32(toBool(entries[13]));
                            row.beard = Convert.ToInt32(toBool(entries[14]));
                            row.mustache = Convert.ToInt32(toBool(entries[15]));
                            row.lex = Convert.ToInt32(entries[16].Split(' ')[0]);
                            row.ley = Convert.ToInt32(entries[16].Split(' ')[1]);
                            row.rex = Convert.ToInt32(entries[17].Split(' ')[0]);
                            row.rey = Convert.ToInt32(entries[17].Split(' ')[1]);
                            row.nosex = Convert.ToInt32(entries[18].Split(' ')[0]);
                            row.nosey = Convert.ToInt32(entries[18].Split(' ')[1]);
                            row.mouthx = Convert.ToInt32(entries[19].Split(' ')[0]);
                            row.mouthy = Convert.ToInt32(entries[19].Split(' ')[0]);
                            row.stage = Convert.ToInt32(entries[20].Substring(entries[20].Length - 5));
                            row.collection = Convert.ToInt32(entries[21].Substring(entries[20].Length - 5));
                            row.environment = Convert.ToInt32(entries[22].Substring(entries[21].Length - 5));
                            row.weather = entries[25];
                            row.pose = entries[8];

                            feretDataSet.faces.AddfacesRow(row);
                        }
                        catch (Exception)
                        {
                            rejectCount++;

                        }



                    }


                }

                


            }

            MessageBox.Show("Reject count: " + rejectCount.ToString());
            generateIndex();
            refresh();
        }

        private bool toBool(string value)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch (Exception)
            {
                return value.Equals("YES", StringComparison.CurrentCultureIgnoreCase);

            }

        }

        private void generateIndex()
        {
            rowIndex.Clear();
            foreach (feretDataSet.facesRow row in feretDataSet.faces.Rows)
            {
                rowIndex.Add(row, false);
            }

        }
        private void facesBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void txtQuery_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
