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

namespace ENFORM
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
            using (OpenFileDialog dlgOpen = new OpenFileDialog())
            {
                dlgOpen.InitialDirectory = "./";
                dlgOpen.Multiselect = false;
                dlgOpen.Title = "Select file to add to test set...";
                dlgOpen.Filter = "Image Files |*.png;*.jpg;*.bmp";
                DialogResult r = dlgOpen.ShowDialog(this);
                if (r == DialogResult.OK)
                {
                    testImageFilename = dlgOpen.FileName;
                }

                currentSource = new SourceItem(testImageFilename, cmbSampleType.SelectedIndex);
                redrawPipeline();
            }
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
                   

                }

            } 
        }

        private void loadRuns(string filename)
        {
            lstRuns.Items.Clear();
            DataAccess dataAccess = new DataAccess(filename);
            Run[] runs = dataAccess.GetRuns();
            foreach (Run run in runs)
            {
                lstRuns.Items.Add(new ListViewItem(run.ToStringArray()));
            }

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

        private void calculateFitness()
        {
            DataAccess dataAccess = new DataAccess(currentRunFile);
            if (currentRunFile != "" && currentSource != null && lstRuns.SelectedItems.Count > 0)
            {
                Network network = dataAccess.GetNetwork(int.Parse(lstRuns.SelectedItems[0].SubItems[5].Text));
                double[] result = network.Run(Utils.getImageWeights(currentSource.InternalImage, (InputGroup[])lstInputGroups.Items.Cast<InputGroup>().ToArray<InputGroup>()));
                lblFitness.Text = "Fitness: " + result[0].ToString();
            }
        }

        private void lblFitness_Click(object sender, EventArgs e)
        {

        }

        private void frmNetworkTester_Shown(object sender, EventArgs e)
        {
            Utils.SetLogWindowLocation(this.Location.X, this.Location.Y + this.Size.Height + 10);

        }
    }
}
