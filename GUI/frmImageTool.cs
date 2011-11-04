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

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            
            using (SaveFileDialog dlgSave = new SaveFileDialog())
            {
                dlgSave.Title = "Select where to save the training set to...";
                dlgSave.Filter = "ENFORM Set File (*.eset)|*.eset|Text File (*.txt) |*.txt|Any file (*.*)|*.*";

                if (dlgSave.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter w = new StreamWriter(dlgSave.FileName, false))
                    {
                        bool flipper =false;
                        
                        DirectoryInfo root = new DirectoryInfo(txtPath.Text);
                        DirectoryInfo[] catagories = root.GetDirectories();

                        int[] counts = new int[catagories.Length];
                        int i = 0;
                        int total = 0;

                        foreach (DirectoryInfo catagory in catagories)
                        {

                            FileInfo[] files = catagory.GetFiles();
                            

                            int count = files.Length;
                            lstLog.Items.Add("Found catagory: " + catagory.Name + " Size: " + count.ToString());
                            counts[i++] = count;
                            total += count;

                            foreach (FileInfo file in files)
                            {
                                w.WriteLine("0," + Convert.ToInt32(flipper).ToString() + "," + Convert.ToInt32(!flipper).ToString() + "," + file.FullName);
                                flipper = !flipper;
                            }
                            
                        }
                        lstLog.Items.Add("Total Images: " + total.ToString());

                    }
                }
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo root = new DirectoryInfo(txtPath.Text);
            DirectoryInfo[] catagories = root.GetDirectories();
            for (int i = 0; i < catagories.Length; i++)
            {
                if (catagories[i].Name.Contains("96"))
                {
                    catagories[i].Delete(true);
                }
                else
                {
                    catagories[i].MoveTo(catagories[i].FullName.Replace("600", ""));
                }

            }
        }

        private void btnNormalize_Click(object sender, EventArgs e)
        {
            DirectoryInfo root = new DirectoryInfo(txtPath.Text);
            DirectoryInfo[] catagories = root.GetDirectories();
            foreach (DirectoryInfo catagory in catagories)
            {
                FileInfo[] files = catagory.GetFiles("*.jpg");
                foreach (FileInfo file in files)
                {
                    Image image = Image.FromFile(file.FullName);
                    float ratio = 384.0f / ((float)image.Height);
                    int width = (int)(ratio * image.Width);

                    Bitmap b = AForge.Imaging.Image.Clone((Bitmap)image, System.Drawing.Imaging.PixelFormat.Format24bppRgb); 

                    AForge.Imaging.Filters.ResizeBicubic bc = new AForge.Imaging.Filters.ResizeBicubic(width, 384);

                    AForge.Imaging.Filters.Crop cp = new AForge.Imaging.Filters.Crop(new Rectangle((image.Width - 256)/2, 0, 256, 384));
                    b =bc.Apply(b);
                    b = cp.Apply(b);
                    b.Save(file.FullName+".new.jpg");
                    image.Dispose();
                    file.Delete();
                    new FileInfo(file.FullName + ".new.jpg").MoveTo(file.FullName);

                    
                }

            }
        }
    }
}
