using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NeuronDotNet.Core;
using NeuronDotNet.Core.Backpropagation;
using ENFORM.Core;
using System.IO;
using CustomControls;

namespace ENFORM.GUI
{
    public partial class frmNetworkTester : Form
    {
        private string testImageFilename = "";
        private SourceItem currentSource;
        private string currentRunFile;
        

        
        public frmNetworkTester()
        {
            InitializeComponent();
            //cmbSampleType.SelectedIndex = 0;
        }

        private void btnOpenTestImage_Click(object sender, EventArgs e)
        {
            MyOpenFileDialogControl dlgLoad = new MyOpenFileDialogControl();

            dlgLoad.FileDlgInitialDirectory = "./";

            dlgLoad.FileDlgCaption = "Select file to add to test set...";
            dlgLoad.FileDlgFilter = "Image Files (*.png,*.jpg,*.bmp,*.ppm)|*.png;*.jpg;*.bmp;*.ppm";

            DialogResult r = dlgLoad.ShowDialog();

            if (r == DialogResult.OK)
            {

                testImageFilename = dlgLoad.FileDlgFileName;

                //SourceItem item = new SourceItem(controlex.Filename, 0);
                //ListViewItem newItem = lstInputs.Items.Add(new ListViewItem(item.GetStringValues()));
                //sourceItems.Add(newItem.GetHashCode(), item);
            }

            currentSource = new SourceItem(testImageFilename, cmbSampleType.SelectedIndex);
            redrawPipeline();
            calculateFitness();
           
        }

        private void cmbSampleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentSource != null)
            {
                currentSource.SampleType = cmbSampleType.SelectedIndex;
                calculateFitness();
            }
        }

        private void btnLoadRunFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlgLoad = new OpenFileDialog())
            {
                dlgLoad.AddExtension = true;
                dlgLoad.DefaultExt = "erun";
                dlgLoad.Filter = "ENFORM run file(*.erun)|*.erun";
                dlgLoad.Title = "Open run file...";
                dlgLoad.Multiselect = false;

                if (dlgLoad.ShowDialog() == DialogResult.OK)
                {
                    loadRuns(dlgLoad.FileName);
                    currentRunFile = dlgLoad.FileName;
                    this.Text = "Network Tester - " + new FileInfo(dlgLoad.FileName).Name; 
                   

                }

            } 
        }

        private void loadRuns(string filename)
        {
            Utils.Logger.Log("Getting runs...");
            lstRuns.Items.Clear();
            DataAccess dataAccess = new DataAccess(filename);
            Run[] runs = dataAccess.GetRuns();
            foreach (Run run in runs)
            {
                lstRuns.Items.Add(new ListViewItem(run.ToStringArray()));
            }

            lstInputGroups.Items.Clear();
            InputGroup[] groups = dataAccess.GetInputGroups();
            foreach (InputGroup group in groups)
            {
                lstInputGroups.Items.Add(group);

            }

        }

        private void redrawPipeline()
        {
            if (currentRunFile != "" && currentSource != null)
            {

                DataAccess dataAccess = new DataAccess(currentRunFile);

                int width = Convert.ToInt32(dataAccess.GetParameter("Master_Width"));
                int height = Convert.ToInt32(dataAccess.GetParameter("Master_Height"));
                bool aspect = Convert.ToBoolean(dataAccess.GetParameter("Master_Aspect"));
                int scalingMethod = Convert.ToInt32(dataAccess.GetParameter("Master_Resize"));

                chkContastStretch.Checked = Convert.ToBoolean(dataAccess.GetParameter("Filter_Stretch"));
                chkHistogram.Checked = Convert.ToBoolean(dataAccess.GetParameter("Filter_Histo"));
                chkGaussian.Checked = Convert.ToBoolean(dataAccess.GetParameter("Filter_Gaussian"));
                numBlurStrength.Value = Convert.ToInt32(dataAccess.GetParameter("Filter_BlurStr"));
                chkContrast.Checked = Convert.ToBoolean(dataAccess.GetParameter("Filter_Contrast"));
                numContrast.Value = Convert.ToDecimal(dataAccess.GetParameter("Filter_ContrastStr"));
                chkGreyscale.Checked = Convert.ToBoolean(dataAccess.GetParameter("Filter_Greyscale"));
                chkBradley.Checked = Convert.ToBoolean(dataAccess.GetParameter("Filter_Bradley"));
                chkThreshold.Checked = Convert.ToBoolean(dataAccess.GetParameter("Filter_Threshold"));
                numThreshold.Value = Convert.ToDecimal(dataAccess.GetParameter("Filter_ThresholdStr"));




                Preprocessor preprocessor = new Preprocessor();
                preprocessor.Bradley = chkBradley.Checked;
                preprocessor.ContrastAdjustment = chkContrast.Checked;
                preprocessor.ContrastStrength = numContrast.Value;
                preprocessor.ContrastStretch = chkContastStretch.Checked;
                preprocessor.FilterLevel = 1;
                preprocessor.Gaussian = chkGaussian.Checked;
                preprocessor.GaussianStrength = numBlurStrength.Value;
                preprocessor.Greyscale = chkGreyscale.Checked;
                preprocessor.Histogram = chkHistogram.Checked;
                preprocessor.ImageSize = new Size(width, height);
                preprocessor.KeepAspectRatio = aspect;
                preprocessor.ScalingMethod = (ScalingMethods)scalingMethod;
                preprocessor.Threshold = chkThreshold.Checked;
                preprocessor.ThresholdStrength = numThreshold.Value;
                imgTestImage.LoadImage(preprocessor.Process((Bitmap)currentSource.InternalImage));
            }
        }

        private void lstRuns_SelectedIndexChanged(object sender, EventArgs e)
        {

            calculateFitness();
            

                
            
        }

        private double calculateFitness()
        {
            DataAccess dataAccess = new DataAccess(currentRunFile);
            if (currentRunFile != "" && currentSource != null && lstRuns.SelectedItems.Count > 0)
            {
                

                int width = Convert.ToInt32(dataAccess.GetParameter("Master_Width"));
                int height = Convert.ToInt32(dataAccess.GetParameter("Master_Height"));
                bool aspect = Convert.ToBoolean(dataAccess.GetParameter("Master_Aspect"));
                int scalingMethod = Convert.ToInt32(dataAccess.GetParameter("Master_Resize"));

                chkContastStretch.Checked = Convert.ToBoolean(dataAccess.GetParameter("Filter_Stretch"));
                chkHistogram.Checked = Convert.ToBoolean(dataAccess.GetParameter("Filter_Histo"));
                chkGaussian.Checked = Convert.ToBoolean(dataAccess.GetParameter("Filter_Gaussian"));
                numBlurStrength.Value = Convert.ToInt32(dataAccess.GetParameter("Filter_BlurStr"));
                chkContrast.Checked = Convert.ToBoolean(dataAccess.GetParameter("Filter_Contrast"));
                numContrast.Value = Convert.ToDecimal(dataAccess.GetParameter("Filter_ContrastStr"));
                chkGreyscale.Checked = Convert.ToBoolean(dataAccess.GetParameter("Filter_Greyscale"));
                chkBradley.Checked = Convert.ToBoolean(dataAccess.GetParameter("Filter_Bradley"));
                chkThreshold.Checked = Convert.ToBoolean(dataAccess.GetParameter("Filter_Threshold"));
                numThreshold.Value = Convert.ToDecimal(dataAccess.GetParameter("Filter_ThresholdStr"));




                Preprocessor preprocessor = new Preprocessor();
                preprocessor.Bradley = chkBradley.Checked;
                preprocessor.ContrastAdjustment = chkContrast.Checked;
                preprocessor.ContrastStrength = numContrast.Value;
                preprocessor.ContrastStretch = chkContastStretch.Checked;
                preprocessor.FilterLevel = 1;
                preprocessor.Gaussian = chkGaussian.Checked;
                preprocessor.GaussianStrength = numBlurStrength.Value;
                preprocessor.Greyscale = chkGreyscale.Checked;
                preprocessor.Histogram = chkHistogram.Checked;
                preprocessor.ImageSize = new Size(width, height);
                preprocessor.KeepAspectRatio = aspect;
                preprocessor.ScalingMethod = (ScalingMethods)scalingMethod;
                preprocessor.Threshold = chkThreshold.Checked;
                preprocessor.ThresholdStrength = numThreshold.Value;
                
                Network network = dataAccess.GetNetwork(int.Parse(lstRuns.SelectedItems[0].SubItems[5].Text));
                currentSource.Preprocessor = preprocessor;
                Bitmap b = (Bitmap)currentSource.InternalImage;
                double[] result = network.Run(Utils.getImageWeights(b, (InputGroup[])lstInputGroups.Items.Cast<InputGroup>().ToArray<InputGroup>()));
                b.Dispose();
                lblFitness.Text = "Fitness: " + result[0].ToString();
                return result[0];
            }
            return -1.0 ;
        }

        private void lblFitness_Click(object sender, EventArgs e)
        {

        }

        private void frmNetworkTester_Shown(object sender, EventArgs e)
        {
            //Utils.SetLogWindowLocation(this.Location.X, this.Location.Y + this.Size.Height + 10);

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            using (MyOpenFileDialogControl dlgLoad = new MyOpenFileDialogControl())
            {
                dlgLoad.FileDlgCaption = "Select a ERun file...";
                dlgLoad.FileDlgFilter = "ENFORM Set File (*.eset)|*.eset|Text File (*.txt) |*.txt|Any file (*.*)|*.*";


                if (dlgLoad.ShowDialog() == DialogResult.OK)
                {

                    
                    if ((dlgLoad.MSDialog as OpenFileDialog).FileNames.Length > 0)
                    {
                        double total = 0.0;
                        int count = 0;
                        using (StreamReader r = new StreamReader(dlgLoad.FileDlgFileName))
                        {
                            while (!r.EndOfStream)
                            {
                                string[] s = r.ReadLine().Split(',');
                                string use = s[2].Trim();
                                string filename = s[3];
                                if (use == "1")
                                {
                                    try
                                    {
                                    SourceItem item = new SourceItem(filename, dlgLoad.SampleType);
                                    currentSource = item;
                                   
                                        total += calculateFitness();
                                        count++;
                                    }
                                    catch (Exception)
                                    {
                                        
                                    }
                                }
                            }

                        }

                        MessageBox.Show("Average fitness = " + (total / (double) count).ToString());

                    }

                    //SourceItem item = new SourceItem(controlex.Filename, 0);
                    //ListViewItem newItem = lstInputs.Items.Add(new ListViewItem(item.GetStringValues()));
                    //sourceItems.Add(newItem.GetHashCode(), item);
                }

            }
        }
    }
}
