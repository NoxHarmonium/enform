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
using NeuronDotNet.Core.Initializers;
using ENFORM.Core;


namespace ENFORM.GUI
{
    public partial class frmRunEditor : Form
    {

        protected List<CustomImage> customImages = new System.Collections.Generic.List<CustomImage>();
        protected Dictionary<int,SourceItem> sourceItems = new Dictionary<int,SourceItem>();
        
        protected bool keepAspectRatio = true;
        protected int filterLevel = 0;
        protected CustomImage currentImage = null;
        protected SourceItem currentSource = null;
        protected Optimiser optimisor;

        public frmRunEditor()
        {
            InitializeComponent();
            cmbInputGroup.SelectedIndex = 0;
            cmbScalingMethod.SelectedIndex = 0;
            
        }

      

        private void btnLoadImages_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.InitialDirectory = "./";
            dlgOpen.Multiselect = true;
            dlgOpen.Title = "Select file to add to test set...";
            dlgOpen.Filter = "Image Files |*.png;*.jpg;*.bmp";
            DialogResult r = dlgOpen.ShowDialog(this);
            if (r == DialogResult.OK)
            {
                if (dlgOpen.FileNames.Length > 0)
                {
                    foreach (String s in dlgOpen.FileNames)
                    {
                        SourceItem item = new SourceItem(s, 0);
                        
                        ListViewItem newItem = lstInputs.Items.Add(new ListViewItem(item.GetStringValues()));
                        sourceItems.Add(newItem.GetHashCode(),item);
                        
                    }
                }
            }

            if (lstInputs.SelectedItems.Count == 0 && lstInputs.Items.Count > 0)
            {
                lstInputs.Focus();
                lstInputs.Items[0].Selected = true;
            }

            
        }

 


        private void lstInputs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtHeight.Text == "" || txtWidth.Text == "")
            {
                imageViewer1.LoadImage(ENFORM.GUI.Properties.Resources.Error);
                return;
            }
            
            if (lstInputs.SelectedItems.Count >= 1)
            {
                try
                {
                    int sourceHash = lstInputs.SelectedItems[0].GetHashCode();
                    SourceItem item = sourceItems[sourceHash];
                    currentSource = item;
                    redrawPipeline();
                    
                    
                }                    
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading the selected file as an image.\n" + ex.Message + ex.StackTrace);
                    imageViewer1.LoadImage(ENFORM.GUI.Properties.Resources.Error);
                    
                }
                     

            }
        }

        private Bitmap resize(Bitmap image, int newWidth, int newHeight)
        {

            
            if (keepAspectRatio)
            {
                
                double ratio = (double)newHeight / (double)image.Height;
                newWidth = (int)((double)image.Width * ratio);
                
            }

            AForge.Imaging.Filters.Crop cropper = new AForge.Imaging.Filters.Crop(new Rectangle(0, 0, newWidth, newHeight));

            if (cmbScalingMethod.SelectedIndex == 0)
            {
                AForge.Imaging.Filters.ResizeNearestNeighbor resizer = new AForge.Imaging.Filters.ResizeNearestNeighbor(newWidth, newHeight); 
                image = cropper.Apply(resizer.Apply((Bitmap)image));
            }
            if (cmbScalingMethod.SelectedIndex == 1)
            {
                AForge.Imaging.Filters.ResizeBicubic resizer = new AForge.Imaging.Filters.ResizeBicubic(newWidth, newHeight);
                image = cropper.Apply(resizer.Apply((Bitmap)image));
            }
            if (cmbScalingMethod.SelectedIndex == 2)
            {
                AForge.Imaging.Filters.ResizeBilinear resizer = new AForge.Imaging.Filters.ResizeBilinear(newWidth, newHeight);
                image = cropper.Apply(resizer.Apply((Bitmap)image));
            }
            
            return image;
        }

        private void btnNewImage_Click(object sender, EventArgs e)
        {
            NameDialog dlgName = new NameDialog();
            DialogResult r = dlgName.ShowDialog(this);

            if (r == DialogResult.OK)
            {
                Size itemSize = new Size(Convert.ToInt32(txtWidth.Text), Convert.ToInt32(txtHeight.Text));
                SourceItem item = new SourceItem(itemSize, dlgName.SampleType, dlgName.NameText);               
                ListViewItem newItem = lstInputs.Items.Add(new ListViewItem(item.GetStringValues()));                
                sourceItems.Add(newItem.GetHashCode(), item);
                
              
                
            }
            if (lstInputs.SelectedItems.Count == 0 && lstInputs.Items.Count > 0)
            {
                lstInputs.Focus();
                lstInputs.Items[0].Selected = true;
            }
        }

        private void chkAspect_CheckedChanged(object sender, EventArgs e)
        {
            keepAspectRatio = chkAspect.Checked;
            this.lstInputs_SelectedIndexChanged(null, null);
        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                redrawPipeline();
                txtDimensions.Text = calculateTotalWeights().ToString();
            }
            catch (Exception)
            {
                imageViewer1.LoadImage(ENFORM.GUI.Properties.Resources.Error);
                txtDimensions.Text = "Error";
            }

        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                redrawPipeline();
                txtDimensions.Text = calculateTotalWeights().ToString();
            }
            catch (Exception)
            {
                imageViewer1.LoadImage(ENFORM.GUI.Properties.Resources.Error);
                txtDimensions.Text = "Error";
            }
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
  
            
        }

        private void imageViewer1_Paint(object sender, PaintEventArgs e)
        {
            redrawPipeline();
        }

        private void imageViewer1_Load(object sender, EventArgs e)
        {

        }

        private void colourPicker1_Load(object sender, EventArgs e)
        {
            colourPicker1.ColourSelected += new ColourSelectedHandler(colourPicker1_ColourSelected);
        }

        void colourPicker1_ColourSelected(object sender, Color selectedColour)
        {
            imageViewer1.DrawingColour = selectedColour;
        }

        Bitmap convertFormatTo32(Bitmap image)
        {
            return image.Clone(
                new Rectangle(0,
                    0,
                    image.Size.Width,
                    image.Size.Height),
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb);


        }

        Bitmap convertFormatToGS(Bitmap image)
        {
            return image.Clone(
                new Rectangle(0,
                    0,
                    image.Size.Width,
                    image.Size.Height),
                    System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);


        }




        void redrawPipeline()
        {

            if (currentSource == null)
            {
                return;
            }

            Preprocessor preprocessor = new Preprocessor();
            preprocessor.Bradley = chkBradley.Checked;
            preprocessor.ContrastAdjustment = chkContrast.Checked;
            preprocessor.ContrastStrength = numContrast.Value;
            preprocessor.ContrastStretch = chkContastStretch.Checked;
            preprocessor.FilterLevel = filterLevel;
            preprocessor.Gaussian = chkGaussian.Checked;
            preprocessor.GaussianStrength = numBlurStrength.Value;
            preprocessor.Greyscale = chkGreyscale.Checked;
            preprocessor.Histogram = chkHistogram.Checked;
            preprocessor.ImageSize = new Size(Int32.Parse(txtWidth.Text), Int32.Parse(txtHeight.Text));
            preprocessor.KeepAspectRatio = chkAspect.Checked;
            preprocessor.ScalingMethod = (ScalingMethods)cmbScalingMethod.SelectedIndex;
            preprocessor.Threshold = chkThreshold.Checked;
            preprocessor.ThresholdStrength = numThreshold.Value;

            imageViewer1.LoadImage(preprocessor.Process((Bitmap)currentSource.InternalImage));

            if (filterLevel >= 2)
            {
                if (lstInputGroups.SelectedItem != null)
                {
                    InputGroup inputGroup = (InputGroup) lstInputGroups.SelectedItem;
                    imageViewer1.DrawInputGroupOverlay(inputGroup.InputGroupType, inputGroup.Segments);
                }
            }

            
          
           
            
        }

        private void tabInnerTestData_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterLevel = tabInnerTestData.SelectedIndex;
            redrawPipeline();
        }

        private void chkGaussian_CheckedChanged(object sender, EventArgs e)
        {
            lblBlurStrength.Enabled = chkGaussian.Checked;
            numBlurStrength.Enabled = chkGaussian.Checked;
            redrawPipeline();
        }

        private void numBlurStrength_ValueChanged(object sender, EventArgs e)
        {
            redrawPipeline();
        }

        private void chkContrast_CheckedChanged(object sender, EventArgs e)
        {
            lblContrast.Enabled = chkContrast.Enabled;
            numContrast.Enabled = chkContrast.Enabled;
            redrawPipeline();
        }

        private void numContrast_ValueChanged(object sender, EventArgs e)
        {
            redrawPipeline();
        }

        private void chkContastStretch_CheckedChanged(object sender, EventArgs e)
        {
            redrawPipeline();
        }

        private void chkThreshold_CheckedChanged(object sender, EventArgs e)
        {
            lblThreshold.Enabled = chkThreshold.Enabled;
            numThreshold.Enabled = chkThreshold.Enabled;
            redrawPipeline();
        }

        private void numThreshold_ValueChanged(object sender, EventArgs e)
        {
            redrawPipeline();
        }

        private void grpFilters_Enter(object sender, EventArgs e)
        {

        }

        private void chkBradley_CheckedChanged(object sender, EventArgs e)
        {
            redrawPipeline();
        }

        private void chkHistogram_CheckedChanged(object sender, EventArgs e)
        {
            redrawPipeline();
        }

        private void grpInputProperties_Enter(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           while (lstInputs.SelectedItems.Count > 0)
           {
               ListViewItem item = lstInputs.SelectedItems[0];
               sourceItems.Remove(item.GetHashCode());
               lstInputs.Items.Remove(item);
           }
           calculateHiddenNodeCount();
           txtDimensions.Text = calculateTotalWeights().ToString();
            
        }

        private void lstInputGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstInputGroups.SelectedIndices.Count > 0)
            {
                lblSegments.Enabled = true;
                numSegments.Enabled = true;
                btnRemoveInputGroup.Enabled = true;
                InputGroup inputGroup = (InputGroup)lstInputGroups.SelectedItem;
                if (inputGroup.InputGroupType == InputGroupType.Grid)
                {
                    numSegments.Value = inputGroup.Segments;
                }
                else
                {
                    numSegments.Value = inputGroup.Segments;
                }
                
                redrawPipeline();
            }
            else
            {
                lblSegments.Enabled = false;
                numSegments.Enabled = false;
                btnRemoveInputGroup.Enabled = false;
            }
            calculateHiddenNodeCount();
            txtDimensions.Text = calculateTotalWeights().ToString();
        }

        private void btnAddInputGroup_Click(object sender, EventArgs e)
        {
            if (cmbInputGroup.SelectedIndex == 0)
            {
                lstInputGroups.Items.Add(new InputGroup(InputGroupType.Grid, 2));

            }
            if (cmbInputGroup.SelectedIndex == 1)
            {
                lstInputGroups.Items.Add(new InputGroup(InputGroupType.Horozontal, 4));

            }
            if (cmbInputGroup.SelectedIndex == 2)
            {
                lstInputGroups.Items.Add(new InputGroup(InputGroupType.Vertical, 4));

            }
            calculateHiddenNodeCount();
            txtDimensions.Text = calculateTotalWeights().ToString();

            
        }

        private void numSegments_ValueChanged(object sender, EventArgs e)
        {
            if (lstInputGroups.SelectedIndices.Count > 0)
            {
                InputGroup inputGroup = (InputGroup)lstInputGroups.SelectedItem;
                if (inputGroup.InputGroupType == InputGroupType.Grid)
                {
                    inputGroup.Segments = (int)numSegments.Value;
                }
                else
                {
                    inputGroup.Segments = (int)numSegments.Value;
                }
                redrawPipeline();
                calculateHiddenNodeCount();
                txtDimensions.Text = calculateTotalWeights().ToString();
            }
        }

        private void cmbScalingMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbScalingMethod.SelectedIndex == 0)
            {
                imageViewer1.ScalingMethod = ScalingMethods.Nearest_Neighbor;
            }
            if (cmbScalingMethod.SelectedIndex == 1)
            {
                imageViewer1.ScalingMethod = ScalingMethods.Bicubic;
            }
            if (cmbScalingMethod.SelectedIndex == 2)
            {
                imageViewer1.ScalingMethod = ScalingMethods.Bilinear;
            }
            redrawPipeline();
        }

        private int calculateTotalWeights()
        {
            int inputNodes = Convert.ToInt32(txtWidth.Text) * Convert.ToInt32(txtHeight.Text);
            int hiddenNodes = calculateHiddenNodeCount();
            int outputNodes = 1;
            int total = inputNodes;
            total += hiddenNodes;
            total += outputNodes;
            total += lstInputGroups.Items.Count * inputNodes;
            total += hiddenNodes * outputNodes;



            return total;

        }


        private int calculateHiddenNodeCount()
        {
            int total = 0;
            foreach (InputGroup inputGroup in lstInputGroups.Items)
            {
                if (inputGroup.InputGroupType == InputGroupType.Grid)
                {
                    total += (inputGroup.Segments) * (inputGroup.Segments);
                }
                else
                {
                    total += inputGroup.Segments;
                }

            }
            lblTotalHiddenNodes.Text = total.ToString();
            return total;
        }

        private void btnRemoveInputGroup_Click(object sender, EventArgs e)
        {
            lstInputGroups.Items.Remove(lstInputGroups.SelectedItem);
            calculateHiddenNodeCount();
            redrawPipeline();
        }

        private void cacheAll()
        {
            foreach (SourceItem item in sourceItems.Values)
            {
                if (!item.Cached)
                {
                    item.Cache();
                }
            }


        }

        private void btnSaveRun_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlgSave = new SaveFileDialog())
            {
                dlgSave.AddExtension = true;
                dlgSave.DefaultExt = "erun";
                dlgSave.Filter = "ENFORM run file(*.erun)|*.erun";
                dlgSave.Title = "Save run file as...";
                if (dlgSave.ShowDialog() == DialogResult.OK)
                {
                    if (chkEmbed.Checked)
                    {
                        cacheAll();
                    }
                    
                    DataAccess dataAccess = new DataAccess(dlgSave.FileName);
                    dataAccess.ClearFile();
                    for (int i = 0; i < lstInputGroups.Items.Count; i++)
                    {
                        dataAccess.AddInputGroup(i, (InputGroup)lstInputGroups.Items[i]);                        
                    }

                    Dictionary<int, SourceItem>.ValueCollection values = sourceItems.Values;
                    int count = 0;
                    foreach (SourceItem item in values)
                    {
                        dataAccess.AddSource(count++,item);
                    }

                    dataAccess.SetParameter("Master_Width", txtWidth.Text);
                    dataAccess.SetParameter("Master_Height", txtHeight.Text);
                    dataAccess.SetParameter("Master_Aspect", chkAspect.Checked.ToString());
                    dataAccess.SetParameter("Master_Resize", cmbScalingMethod.SelectedIndex.ToString());
                    dataAccess.SetParameter("Filter_Stretch", chkContastStretch.Checked.ToString());
                    dataAccess.SetParameter("Filter_Histo", chkHistogram.Checked.ToString());
                    dataAccess.SetParameter("Filter_Gaussian", chkGaussian.Checked.ToString());
                    dataAccess.SetParameter("Filter_BlurStr", numBlurStrength.Value.ToString());
                    dataAccess.SetParameter("Filter_Contrast", chkContrast.Checked.ToString());
                    dataAccess.SetParameter("Filter_ContrastStr", numContrast.Value.ToString());
                    dataAccess.SetParameter("Filter_Greyscale", chkGreyscale.Checked.ToString());
                    dataAccess.SetParameter("Filter_Bradley", chkBradley.Checked.ToString());
                    dataAccess.SetParameter("Filter_Threshold", chkThreshold.Checked.ToString());
                    dataAccess.SetParameter("Filter_ThresholdStr", numThreshold.Value.ToString());

                    dataAccess.SetParameter("Opt_Global_MaxIterations", txtMaxIterations.Text);
                    dataAccess.SetParameter("Opt_Global_MinError", txtMinimumError.Text);
                    dataAccess.SetParameter("Opt_Global_MaxTime", txtMaxTime.Text);

                    dataAccess.SetParameter("Opt_Bp_Enabled", chkBackPropogation.Checked.ToString());
                    if (chkBackPropogation.Checked)
                    {
                        dataAccess.SetParameter("Opt_Bp_LearningType", cmbLearningRateType.SelectedIndex.ToString());
                        dataAccess.SetParameter("Opt_Bp_InitialLearnRate", txtInitialRate.Text);
                        dataAccess.SetParameter("Opt_Bp_FinalLearnRate", txtFinalRate.Text);
                        dataAccess.SetParameter("Opt_Bp_JitterEpoch", txtJitterEpoch.Text);
                        dataAccess.SetParameter("Opt_Bp_JitterNoiseLimit", txtJitterNoiseLimit.Text);
                      
                    }

                    dataAccess.SetParameter("Opt_Pso_Enabled", chkPSO.Checked.ToString());
                    if (chkPSO.Checked)
                    {
                        dataAccess.SetParameter("Opt_Pso_MinP", txtMinP.Text);
                        dataAccess.SetParameter("Opt_Pso_MaxP", txtMaxP.Text);
                        dataAccess.SetParameter("Opt_Pso_MinI", txtMinI.Text);
                        dataAccess.SetParameter("Opt_Pso_MaxI", txtMaxI.Text);
                        dataAccess.SetParameter("Opt_Pso_Quant",txtQuant.Text);

                        dataAccess.SetParameter("Opt_Pso_Clamping", cmbClamping.SelectedIndex.ToString());
                        dataAccess.SetParameter("Opt_Pso_InitLinks", cmbInitLinks.SelectedIndex.ToString());
                        dataAccess.SetParameter("Opt_Pso_Randomness", cmbPSORandom.SelectedIndex.ToString());
                        dataAccess.SetParameter("Opt_Pso_ParticleOrder", cmbRandOrder.SelectedIndex.ToString());
                        dataAccess.SetParameter("Opt_Pso_Rotation", cmbRotation.SelectedIndex.ToString());
                        
                        dataAccess.SetParameter("Opt_Pso_Dimensions", txtDimensions.Text);
                        dataAccess.SetParameter("Opt_Pso_Particles", txtSwarmSize.Text);
                        dataAccess.SetParameter("Opt_Pso_k", txtK.Text);
                        dataAccess.SetParameter("Opt_Pso_p", txtP.Text);
                        dataAccess.SetParameter("Opt_Pso_w", txtW.Text);
                        dataAccess.SetParameter("Opt_Pso_c", txtC.Text);

                        dataAccess.SetParameter("Opt_Pso_AutoParticles", chkAutoSwarmSize.Checked.ToString());
                        dataAccess.SetParameter("Opt_Pso_AutoK", chkAutoK.Checked.ToString());
                        dataAccess.SetParameter("Opt_Pso_AutoP", chkAutoP.Checked.ToString());
                        dataAccess.SetParameter("Opt_Pso_AutoW", chkAutoW.Checked.ToString());
                        dataAccess.SetParameter("Opt_Pso_AutoC", chkAutoC.Checked.ToString());


                    }
                    


                    
                }

            
            } 
        }

        private void btnLoadRun_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlgLoad = new OpenFileDialog())
            {
                dlgLoad.AddExtension = true;
                dlgLoad.DefaultExt = "erun";
                dlgLoad.Filter = "ENFORM run file(*.erun)|*.erun";
                dlgLoad.Title = "Open run file...";
                if (dlgLoad.ShowDialog() == DialogResult.OK)
                {
                    DataAccess dataAccess = new DataAccess(dlgLoad.FileName);
                    SourceItem[] sources = dataAccess.GetSourceItems();
                    foreach (SourceItem source in sources)
                    {
                        ListViewItem newItem = lstInputs.Items.Add(new ListViewItem(source.GetStringValues()));
                        sourceItems.Add(newItem.GetHashCode(), source);
                    }
                    InputGroup[] groups = dataAccess.GetInputGroups();
                    lstInputGroups.Items.Clear();
                    foreach (InputGroup group in groups)
                    {
                        lstInputGroups.Items.Add(group);

                    }



                    txtWidth.Text =  dataAccess.GetParameter("Master_Width");
                    txtHeight.Text = dataAccess.GetParameter("Master_Height");
                    chkAspect.Checked = Convert.ToBoolean(dataAccess.GetParameter("Master_Aspect"));
                    cmbScalingMethod.SelectedIndex = Convert.ToInt32(dataAccess.GetParameter("Master_Resize"));
                    chkContastStretch.Checked = Convert.ToBoolean(dataAccess.GetParameter("Filter_Stretch"));
                    chkHistogram.Checked = Convert.ToBoolean(dataAccess.GetParameter("Filter_Histo"));
                    chkGaussian.Checked = Convert.ToBoolean(dataAccess.GetParameter("Filter_Gaussian"));
                    numBlurStrength.Value = Convert.ToInt32(dataAccess.GetParameter("Filter_BlurStr"));
                    chkContrast.Checked = Convert.ToBoolean(dataAccess.GetParameter("Filter_Contrast"));
                    numContrast.Value = Convert.ToDecimal(dataAccess.GetParameter("Filter_ContrastStr"));
                    chkGreyscale.Checked = Convert.ToBoolean(dataAccess.GetParameter("Filter_Greyscale"));
                    chkBradley.Checked = Convert.ToBoolean(dataAccess.GetParameter("Filter_Bradley"));
                    chkThreshold.Checked  = Convert.ToBoolean(dataAccess.GetParameter("Filter_Threshold"));
                    numThreshold.Value  = Convert.ToDecimal(dataAccess.GetParameter("Filter_ThresholdStr"));

                    try
                    {
                        txtMaxIterations.Text = dataAccess.GetParameter("Opt_Global_MaxIterations");
                        txtMinimumError.Text = dataAccess.GetParameter("Opt_Global_MinError");
                        txtMaxTime.Text = dataAccess.GetParameter("Opt_Global_MaxTime");
                    }                    
                    catch (Exception)
                    {
                        Utils.Logger.Log("Warning: Error reading global parameters");
                    }

                    try
                    {
                        chkBackPropogation.Checked = Convert.ToBoolean(dataAccess.GetParameter("Opt_Bp_Enabled"));
                        cmbLearningRateType.SelectedIndex = Convert.ToInt32(dataAccess.GetParameter("Opt_Bp_LearningType"));
                        txtInitialRate.Text = dataAccess.GetParameter("Opt_Bp_InitialLearnRate");
                        txtFinalRate.Text = dataAccess.GetParameter("Opt_Bp_FinalLearnRate");
                        txtJitterEpoch.Text = dataAccess.GetParameter("Opt_Bp_JitterEpoch");
                        txtJitterNoiseLimit.Text = dataAccess.GetParameter("Opt_Bp_JitterNoiseLimit");
                    

                    }
                    catch (Exception)
                    {
                        Utils.Logger.Log("Warning: Error reading backprop parameters");
                    }
                    try
                    {

                        chkPSO.Checked = Convert.ToBoolean(dataAccess.GetParameter("Opt_Pso_Enabled"));

                        txtMinP.Text = dataAccess.GetParameter("Opt_Pso_MinP");
                        txtMaxP.Text = dataAccess.GetParameter("Opt_Pso_MaxP");
                        txtMinI.Text = dataAccess.GetParameter("Opt_Pso_MinI");
                        txtMaxI.Text = dataAccess.GetParameter("Opt_Pso_MaxI");
                        txtQuant.Text = dataAccess.GetParameter("Opt_Pso_Quant");

                        cmbClamping.SelectedIndex = Convert.ToInt32(dataAccess.GetParameter("Opt_Pso_Clamping"));
                        cmbInitLinks.SelectedIndex = Convert.ToInt32(dataAccess.GetParameter("Opt_Pso_InitLinks"));
                        cmbPSORandom.SelectedIndex = Convert.ToInt32(dataAccess.GetParameter("Opt_Pso_Randomness"));
                        cmbRandOrder.SelectedIndex = Convert.ToInt32(dataAccess.GetParameter("Opt_Pso_ParticleOrder"));
                        cmbRotation.SelectedIndex = Convert.ToInt32(dataAccess.GetParameter("Opt_Pso_Rotation"));

                        txtDimensions.Text = dataAccess.GetParameter("Opt_Pso_Dimensions");
                        txtSwarmSize.Text = dataAccess.GetParameter("Opt_Pso_Particles");
                        txtK.Text = dataAccess.GetParameter("Opt_Pso_k");
                        txtP.Text = dataAccess.GetParameter("Opt_Pso_p");
                        txtW.Text = dataAccess.GetParameter("Opt_Pso_w");
                        txtC.Text = dataAccess.GetParameter("Opt_Pso_c");

                        chkAutoSwarmSize.Checked = Convert.ToBoolean(dataAccess.GetParameter("Opt_Pso_AutoParticles"));
                        chkAutoK.Checked = Convert.ToBoolean(dataAccess.GetParameter("Opt_Pso_AutoK"));
                        chkAutoP.Checked = Convert.ToBoolean(dataAccess.GetParameter("Opt_Pso_AutoP"));
                        chkAutoW.Checked = Convert.ToBoolean(dataAccess.GetParameter("Opt_Pso_AutoW"));
                        chkAutoC.Checked = Convert.ToBoolean(dataAccess.GetParameter("Opt_Pso_AutoC"));
                    }
                    catch (Exception)
                    {
                        Utils.Logger.Log("Warning: Error reading PSO parameters");
                    }




                }


            } 
        }

        private void chkBackPropogation_CheckedChanged(object sender, EventArgs e)
        {
            grpBackPropogation.Enabled = chkBackPropogation.Checked;
            
        }

        private void chkPSO_CheckedChanged(object sender, EventArgs e)
        {
            grpPSO.Enabled = chkPSO.Checked;
        }    

       

       

        

        private void lstInputs_DoubleClick(object sender, EventArgs e)
        {
            if (lstInputs.SelectedItems.Count == 1)
            {
                int itemHash = lstInputs.SelectedItems[0].GetHashCode();

                ListViewItem listItem = lstInputs.SelectedItems[0];
                SourceItem item = sourceItems[itemHash];
                NameDialog dlgName = new NameDialog();

                dlgName.NameText = item.Name;
                dlgName.SampleType = item.SampleType;
                dlgName.ShowDialog();

                if (dlgName.DialogResult == DialogResult.OK)
                {
                    item.Name = dlgName.NameText;
                    item.SampleType = dlgName.SampleType;

                    sourceItems.Remove(itemHash);
                    int index = lstInputs.Items.IndexOf(listItem);
                    lstInputs.Items.Remove(lstInputs.SelectedItems[0]);
                    ListViewItem newItem = lstInputs.Items.Insert(index, new ListViewItem(item.GetStringValues()));
                    sourceItems.Add(newItem.GetHashCode(), item);
                }

                



            }
        }

        private void cmbLearningRateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLearningRateType.SelectedIndex == 0)
            {
                txtFinalRate.Enabled = false;
            }
            else
            {
                txtFinalRate.Enabled = true;
            }
        }

        private void frmRunEditor_Load(object sender, EventArgs e)
        {
            cmbLearningRateType.SelectedIndex = 0;
            txtMaxIterations.Text = int.MaxValue.ToString();
            cmbClamping.SelectedIndex = 1;
            cmbInitLinks.SelectedIndex = 0;
            cmbPSORandom.SelectedIndex = 1;
            cmbRandOrder.SelectedIndex = 0;
            cmbRotation.SelectedIndex = 0;
            txtW.Text = Convert.ToString(1.0 / (2.0 * Math.Log(2)));
            txtC.Text = Convert.ToString(0.5 + Math.Log(2));
            txtP.Text = Convert.ToString(1.0-Math.Pow(1.0-(1.0/Convert.ToDouble(txtSwarmSize.Text)),Convert.ToDouble(txtK.Text)));

            txtDimensions.Text = calculateTotalWeights().ToString();
            
            
        }

        private void btnTestSegments_Click(object sender, EventArgs e)
        {
            if (!currentSource.Cached)
            {
                currentSource.Cache();
            }
            InputGroup inputGroup = (InputGroup)lstInputGroups.SelectedItem;
            int subImageCount = inputGroup.Segments;
            if (inputGroup.InputGroupType == InputGroupType.Grid)
            {
                subImageCount = subImageCount * subImageCount;
            }

            Bitmap[] subImages = new Bitmap[subImageCount];
            for (int i = 0; i < subImages.Length; i++)
            {
                subImages[i] = new Bitmap((currentSource.InternalImage.Width / inputGroup.Segments),
                                           (currentSource.InternalImage.Height / inputGroup.Segments));
            }
            int pixelCount = 0;

            for (int j = 0; j < currentSource.InternalImage.Height; j++)
            {
                for (int i = 0; i < currentSource.InternalImage.Width; i++)
                {
                    int segment = inputGroup.GetSegment(pixelCount, currentSource.InternalImage.Width, currentSource.InternalImage.Height);
                    int segmentx = i % (currentSource.InternalImage.Width / inputGroup.Segments);
                    int segmenty = j % (currentSource.InternalImage.Height / inputGroup.Segments);

                    subImages[segment].SetPixel(segmentx, segmenty,
                        ((Bitmap)currentSource.InternalImage).GetPixel(i,j));                      

                    pixelCount++;

                    
                }

            }
            
           for (int i = 0; i < subImages.Length; i++)
           {
                subImages[i].Save("C:\\temp\\segment" + i.ToString() + ".png");    
           }
           

        }

        private void frmRunEditor_Shown(object sender, EventArgs e)
        {
            //Utils.SetLogWindowLocation(this.Location.X, this.Location.Y + this.Size.Height + 10);
        }

        private void cmbRotation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRotation.SelectedIndex == 1)
            {
                MessageBox.Show("Experimental code, completely valid only for 2 dimensions.\n" +
                    "Uses a rotated hypercube for the probability distribution.\n " +
                    "Can be really slow!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           
            }
        }

        private void PSOScrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            pnlPSO.AutoScroll = true;
        }

        private void lblc_Click(object sender, EventArgs e)
        {

        }

        private void txtDimensions_TextChanged(object sender, EventArgs e)
        {
            if (chkAutoSwarmSize.Checked)
            {
                try
                {
                    txtSwarmSize.Text = Convert.ToString(Math.Ceiling(10 + (2 * Math.Sqrt(Convert.ToDouble(txtDimensions.Text)))));
                }
                catch (Exception)
                {
                    txtSwarmSize.Text = "Error";
                }
            }
            
            
        }

        private void txtK_TextChanged(object sender, EventArgs e)
        {
            if (chkAutoP.Checked)
            {
                try
                {
                    txtP.Text = Convert.ToString(1.0 - Math.Pow(1.0 - (1.0 / Convert.ToDouble(txtSwarmSize.Text)), Convert.ToDouble(txtK.Text)));
                }
                catch (Exception)
                {
                    txtP.Text = "Error";
                }
            }
            
            
        }

        private void txtSwarmSize_TextChanged(object sender, EventArgs e)
        {
            if (chkAutoP.Checked)
            {
                try
                {
                    txtP.Text = Convert.ToString(1.0 - Math.Pow(1.0 - (1.0 / Convert.ToDouble(txtSwarmSize.Text)), Convert.ToDouble(txtK.Text)));
                }
                catch (Exception)
                {
                    txtP.Text = "Error";
                }
            }
            
           
        }

        private void chkAutoK_CheckedChanged(object sender, EventArgs e)
        {
            txtK.Enabled = !chkAutoK.Checked;
        }

        private void chkAutoW_CheckedChanged(object sender, EventArgs e)
        {
            txtW.Enabled = !chkAutoW.Checked;
            if (chkAutoW.Checked)
            {
                txtW.Text = Convert.ToString(1.0 / (2.0 * Math.Log(2)));
            }
           
        }

        private void chkAutoP_CheckedChanged(object sender, EventArgs e)
        {
            txtP.Enabled = !chkAutoP.Checked;
            if (chkAutoP.Checked)
            {
                txtP.Text = Convert.ToString(1.0 - Math.Pow(1.0 - (1.0 / Convert.ToDouble(txtSwarmSize.Text)), Convert.ToDouble(txtK.Text)));
            }
        }

        private void chkAutoC_CheckedChanged(object sender, EventArgs e)
        {
            txtC.Enabled = !chkAutoC.Checked;
            if (chkAutoC.Checked)
            {
                txtC.Text = Convert.ToString(0.5 + Math.Log(2));
            }
        }

        private void chkAutoSwarmSize_CheckedChanged(object sender, EventArgs e)
        {
            txtSwarmSize.Enabled = !chkAutoSwarmSize.Checked;
            if (chkAutoSwarmSize.Checked)
            {
                txtSwarmSize.Text = Convert.ToString(Math.Ceiling(10 + (2 * Math.Sqrt(Convert.ToDouble(txtDimensions.Text)))));
            }
        }

       
   

       

        
      

        
    }
}
