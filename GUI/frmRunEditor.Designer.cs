﻿namespace ENFORM.GUI
{
    partial class frmRunEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRunEditor));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabTestData = new System.Windows.Forms.TabPage();
            this.lstInputs = new System.Windows.Forms.ListView();
            this.clmName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmExpectedOutput = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabInnerTestData = new System.Windows.Forms.TabControl();
            this.tabSources = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNewImage = new System.Windows.Forms.Button();
            this.grpInputProperties = new System.Windows.Forms.GroupBox();
            this.lblScalingMethod = new System.Windows.Forms.Label();
            this.cmbScalingMethod = new System.Windows.Forms.ComboBox();
            this.chkAspect = new System.Windows.Forms.CheckBox();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.btnLoadImages = new System.Windows.Forms.Button();
            this.btnGetFERETImages = new System.Windows.Forms.Button();
            this.tabPreproc = new System.Windows.Forms.TabPage();
            this.grpFilters = new System.Windows.Forms.GroupBox();
            this.chkBradley = new System.Windows.Forms.CheckBox();
            this.numThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.chkThreshold = new System.Windows.Forms.CheckBox();
            this.numContrast = new System.Windows.Forms.NumericUpDown();
            this.lblContrast = new System.Windows.Forms.Label();
            this.chkContrast = new System.Windows.Forms.CheckBox();
            this.lblBlurStrength = new System.Windows.Forms.Label();
            this.numBlurStrength = new System.Windows.Forms.NumericUpDown();
            this.chkGaussian = new System.Windows.Forms.CheckBox();
            this.chkHistogram = new System.Windows.Forms.CheckBox();
            this.chkContastStretch = new System.Windows.Forms.CheckBox();
            this.chkGreyscale = new System.Windows.Forms.CheckBox();
            this.tabGroups = new System.Windows.Forms.TabPage();
            this.btnTestSegments = new System.Windows.Forms.Button();
            this.btnRemoveInputGroup = new System.Windows.Forms.Button();
            this.lblTotalHiddenNodes = new System.Windows.Forms.Label();
            this.lblTotalInputNodesStatic = new System.Windows.Forms.Label();
            this.numSegments = new System.Windows.Forms.NumericUpDown();
            this.lblSegments = new System.Windows.Forms.Label();
            this.btnAddInputGroup = new System.Windows.Forms.Button();
            this.cmbInputGroup = new System.Windows.Forms.ComboBox();
            this.lstInputGroups = new System.Windows.Forms.ListBox();
            this.tabOptimisation = new System.Windows.Forms.TabPage();
            this.grpEndCond = new System.Windows.Forms.GroupBox();
            this.lblBufferSize = new System.Windows.Forms.Label();
            this.txtBufferSize = new System.Windows.Forms.TextBox();
            this.txtMaxTime = new System.Windows.Forms.TextBox();
            this.lblMaxTime = new System.Windows.Forms.Label();
            this.lblMinError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMinimumError = new System.Windows.Forms.TextBox();
            this.txtMaxIterations = new System.Windows.Forms.TextBox();
            this.chkPSO = new System.Windows.Forms.CheckBox();
            this.grpPSO = new System.Windows.Forms.GroupBox();
            this.pnlPSO = new System.Windows.Forms.Panel();
            this.grpPSOParams = new System.Windows.Forms.GroupBox();
            this.chkAutoC = new System.Windows.Forms.CheckBox();
            this.chkAutoP = new System.Windows.Forms.CheckBox();
            this.chkAutoW = new System.Windows.Forms.CheckBox();
            this.chkAutoSwarmSize = new System.Windows.Forms.CheckBox();
            this.chkAutoK = new System.Windows.Forms.CheckBox();
            this.lblc = new System.Windows.Forms.Label();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtW = new System.Windows.Forms.TextBox();
            this.txtP = new System.Windows.Forms.TextBox();
            this.txtK = new System.Windows.Forms.TextBox();
            this.lblW = new System.Windows.Forms.Label();
            this.lblP = new System.Windows.Forms.Label();
            this.lblK = new System.Windows.Forms.Label();
            this.txtDimensions = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSwarmSize = new System.Windows.Forms.TextBox();
            this.lblSwarmSize = new System.Windows.Forms.Label();
            this.cmbRotation = new System.Windows.Forms.ComboBox();
            this.lblRotation = new System.Windows.Forms.Label();
            this.cmbPSORandom = new System.Windows.Forms.ComboBox();
            this.lblRandOrder = new System.Windows.Forms.Label();
            this.cmbRandOrder = new System.Windows.Forms.ComboBox();
            this.lblPSORandom = new System.Windows.Forms.Label();
            this.cmbInitLinks = new System.Windows.Forms.ComboBox();
            this.lblInitLinks = new System.Windows.Forms.Label();
            this.lblClamping = new System.Windows.Forms.Label();
            this.cmbClamping = new System.Windows.Forms.ComboBox();
            this.grpSwarm = new System.Windows.Forms.GroupBox();
            this.txtQuant = new System.Windows.Forms.TextBox();
            this.lblQuant = new System.Windows.Forms.Label();
            this.lblMaxI = new System.Windows.Forms.Label();
            this.txtMaxI = new System.Windows.Forms.TextBox();
            this.txtMinI = new System.Windows.Forms.TextBox();
            this.txtMaxP = new System.Windows.Forms.TextBox();
            this.txtMinP = new System.Windows.Forms.TextBox();
            this.lblMinI = new System.Windows.Forms.Label();
            this.lblMaxP = new System.Windows.Forms.Label();
            this.lblMinP = new System.Windows.Forms.Label();
            this.chkBackPropogation = new System.Windows.Forms.CheckBox();
            this.grpBackPropogation = new System.Windows.Forms.GroupBox();
            this.grpJitter = new System.Windows.Forms.GroupBox();
            this.lblJitterNoiseLimit = new System.Windows.Forms.Label();
            this.lblJitterEpoch = new System.Windows.Forms.Label();
            this.txtJitterNoiseLimit = new System.Windows.Forms.TextBox();
            this.txtJitterEpoch = new System.Windows.Forms.TextBox();
            this.grpLearningRate = new System.Windows.Forms.GroupBox();
            this.lblFinalRate = new System.Windows.Forms.Label();
            this.txtFinalRate = new System.Windows.Forms.TextBox();
            this.txtInitialRate = new System.Windows.Forms.TextBox();
            this.lblInitialRate = new System.Windows.Forms.Label();
            this.lblLearningRateType = new System.Windows.Forms.Label();
            this.cmbLearningRateType = new System.Windows.Forms.ComboBox();
            this.tabSaveLoad = new System.Windows.Forms.TabPage();
            this.chkEmbed = new System.Windows.Forms.CheckBox();
            this.btnLoadRun = new System.Windows.Forms.Button();
            this.btnSaveRun = new System.Windows.Forms.Button();
            this.colourPicker1 = new ENFORM.GUI.ColourPicker();
            this.imageViewer1 = new ENFORM.GUI.ImageViewer();
            this.lblVMax = new System.Windows.Forms.Label();
            this.txtVMax = new System.Windows.Forms.TextBox();
            this.tabMain.SuspendLayout();
            this.tabTestData.SuspendLayout();
            this.tabInnerTestData.SuspendLayout();
            this.tabSources.SuspendLayout();
            this.grpInputProperties.SuspendLayout();
            this.tabPreproc.SuspendLayout();
            this.grpFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlurStrength)).BeginInit();
            this.tabGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSegments)).BeginInit();
            this.tabOptimisation.SuspendLayout();
            this.grpEndCond.SuspendLayout();
            this.grpPSO.SuspendLayout();
            this.pnlPSO.SuspendLayout();
            this.grpPSOParams.SuspendLayout();
            this.grpSwarm.SuspendLayout();
            this.grpBackPropogation.SuspendLayout();
            this.grpJitter.SuspendLayout();
            this.grpLearningRate.SuspendLayout();
            this.tabSaveLoad.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabTestData);
            this.tabMain.Controls.Add(this.tabOptimisation);
            this.tabMain.Controls.Add(this.tabSaveLoad);
            this.tabMain.Location = new System.Drawing.Point(276, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(517, 412);
            this.tabMain.TabIndex = 0;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tabTestData
            // 
            this.tabTestData.Controls.Add(this.lstInputs);
            this.tabTestData.Controls.Add(this.tabInnerTestData);
            this.tabTestData.Location = new System.Drawing.Point(4, 22);
            this.tabTestData.Name = "tabTestData";
            this.tabTestData.Padding = new System.Windows.Forms.Padding(3);
            this.tabTestData.Size = new System.Drawing.Size(509, 386);
            this.tabTestData.TabIndex = 0;
            this.tabTestData.Text = "Test Data";
            this.tabTestData.UseVisualStyleBackColor = true;
            // 
            // lstInputs
            // 
            this.lstInputs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmExpectedOutput,
            this.clmType,
            this.clmSize});
            this.lstInputs.Location = new System.Drawing.Point(258, 28);
            this.lstInputs.Name = "lstInputs";
            this.lstInputs.Size = new System.Drawing.Size(248, 351);
            this.lstInputs.TabIndex = 1;
            this.lstInputs.UseCompatibleStateImageBehavior = false;
            this.lstInputs.View = System.Windows.Forms.View.Details;
            this.lstInputs.SelectedIndexChanged += new System.EventHandler(this.lstInputs_SelectedIndexChanged);
            this.lstInputs.DoubleClick += new System.EventHandler(this.lstInputs_DoubleClick);
            // 
            // clmName
            // 
            this.clmName.Text = "Name";
            this.clmName.Width = 137;
            // 
            // clmExpectedOutput
            // 
            this.clmExpectedOutput.Text = "e";
            this.clmExpectedOutput.Width = 21;
            // 
            // clmType
            // 
            this.clmType.Text = "Type";
            // 
            // clmSize
            // 
            this.clmSize.Text = "Size";
            // 
            // tabInnerTestData
            // 
            this.tabInnerTestData.Controls.Add(this.tabSources);
            this.tabInnerTestData.Controls.Add(this.tabPreproc);
            this.tabInnerTestData.Controls.Add(this.tabGroups);
            this.tabInnerTestData.Location = new System.Drawing.Point(0, 3);
            this.tabInnerTestData.Name = "tabInnerTestData";
            this.tabInnerTestData.SelectedIndex = 0;
            this.tabInnerTestData.Size = new System.Drawing.Size(256, 376);
            this.tabInnerTestData.TabIndex = 10;
            this.tabInnerTestData.SelectedIndexChanged += new System.EventHandler(this.tabInnerTestData_SelectedIndexChanged);
            // 
            // tabSources
            // 
            this.tabSources.Controls.Add(this.btnDelete);
            this.tabSources.Controls.Add(this.btnNewImage);
            this.tabSources.Controls.Add(this.grpInputProperties);
            this.tabSources.Controls.Add(this.btnLoadImages);
            this.tabSources.Controls.Add(this.btnGetFERETImages);
            this.tabSources.Location = new System.Drawing.Point(4, 22);
            this.tabSources.Name = "tabSources";
            this.tabSources.Padding = new System.Windows.Forms.Padding(3);
            this.tabSources.Size = new System.Drawing.Size(248, 350);
            this.tabSources.TabIndex = 0;
            this.tabSources.Text = "Sources";
            this.tabSources.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(9, 171);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(236, 50);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete image/s from list";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNewImage
            // 
            this.btnNewImage.Image = ((System.Drawing.Image)(resources.GetObject("btnNewImage.Image")));
            this.btnNewImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewImage.Location = new System.Drawing.Point(6, 3);
            this.btnNewImage.Name = "btnNewImage";
            this.btnNewImage.Size = new System.Drawing.Size(239, 50);
            this.btnNewImage.TabIndex = 2;
            this.btnNewImage.Text = "Add new custom image...";
            this.btnNewImage.UseVisualStyleBackColor = true;
            this.btnNewImage.Click += new System.EventHandler(this.btnNewImage_Click);
            // 
            // grpInputProperties
            // 
            this.grpInputProperties.Controls.Add(this.lblScalingMethod);
            this.grpInputProperties.Controls.Add(this.cmbScalingMethod);
            this.grpInputProperties.Controls.Add(this.chkAspect);
            this.grpInputProperties.Controls.Add(this.lblWidth);
            this.grpInputProperties.Controls.Add(this.lblHeight);
            this.grpInputProperties.Controls.Add(this.txtWidth);
            this.grpInputProperties.Controls.Add(this.txtHeight);
            this.grpInputProperties.Location = new System.Drawing.Point(6, 227);
            this.grpInputProperties.Name = "grpInputProperties";
            this.grpInputProperties.Size = new System.Drawing.Size(232, 120);
            this.grpInputProperties.TabIndex = 9;
            this.grpInputProperties.TabStop = false;
            this.grpInputProperties.Text = "Master Properties";
            this.grpInputProperties.Enter += new System.EventHandler(this.grpInputProperties_Enter);
            // 
            // lblScalingMethod
            // 
            this.lblScalingMethod.AutoSize = true;
            this.lblScalingMethod.Location = new System.Drawing.Point(0, 90);
            this.lblScalingMethod.Name = "lblScalingMethod";
            this.lblScalingMethod.Size = new System.Drawing.Size(81, 13);
            this.lblScalingMethod.TabIndex = 11;
            this.lblScalingMethod.Text = "Resize Method:";
            // 
            // cmbScalingMethod
            // 
            this.cmbScalingMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScalingMethod.FormattingEnabled = true;
            this.cmbScalingMethod.Items.AddRange(new object[] {
            "Nearest_Neighbor",
            "Bicubic",
            "Bilinear"});
            this.cmbScalingMethod.Location = new System.Drawing.Point(87, 87);
            this.cmbScalingMethod.Name = "cmbScalingMethod";
            this.cmbScalingMethod.Size = new System.Drawing.Size(109, 21);
            this.cmbScalingMethod.TabIndex = 10;
            this.cmbScalingMethod.SelectedIndexChanged += new System.EventHandler(this.cmbScalingMethod_SelectedIndexChanged);
            // 
            // chkAspect
            // 
            this.chkAspect.AutoSize = true;
            this.chkAspect.Checked = true;
            this.chkAspect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAspect.Location = new System.Drawing.Point(56, 64);
            this.chkAspect.Name = "chkAspect";
            this.chkAspect.Size = new System.Drawing.Size(140, 17);
            this.chkAspect.TabIndex = 9;
            this.chkAspect.Text = "Keep aspect ratio (Crop)";
            this.chkAspect.UseVisualStyleBackColor = true;
            this.chkAspect.CheckedChanged += new System.EventHandler(this.chkAspect_CheckedChanged);
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(9, 16);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(38, 13);
            this.lblWidth.TabIndex = 7;
            this.lblWidth.Text = "Width:";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(9, 41);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(41, 13);
            this.lblHeight.TabIndex = 8;
            this.lblHeight.Text = "Height:";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(50, 13);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(176, 20);
            this.txtWidth.TabIndex = 5;
            this.txtWidth.Text = "250";
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(50, 38);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(176, 20);
            this.txtHeight.TabIndex = 6;
            this.txtHeight.Text = "330";
            this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
            // 
            // btnLoadImages
            // 
            this.btnLoadImages.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadImages.Image")));
            this.btnLoadImages.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadImages.Location = new System.Drawing.Point(6, 59);
            this.btnLoadImages.Name = "btnLoadImages";
            this.btnLoadImages.Size = new System.Drawing.Size(239, 50);
            this.btnLoadImages.TabIndex = 3;
            this.btnLoadImages.Text = "Add images from file system...";
            this.btnLoadImages.UseVisualStyleBackColor = true;
            this.btnLoadImages.Click += new System.EventHandler(this.btnLoadImages_Click);
            // 
            // btnGetFERETImages
            // 
            this.btnGetFERETImages.Image = ((System.Drawing.Image)(resources.GetObject("btnGetFERETImages.Image")));
            this.btnGetFERETImages.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetFERETImages.Location = new System.Drawing.Point(9, 115);
            this.btnGetFERETImages.Name = "btnGetFERETImages";
            this.btnGetFERETImages.Size = new System.Drawing.Size(236, 50);
            this.btnGetFERETImages.TabIndex = 4;
            this.btnGetFERETImages.Text = "Add images from EList file";
            this.btnGetFERETImages.UseVisualStyleBackColor = true;
            this.btnGetFERETImages.Click += new System.EventHandler(this.btnGetFERETImages_Click);
            // 
            // tabPreproc
            // 
            this.tabPreproc.Controls.Add(this.grpFilters);
            this.tabPreproc.Location = new System.Drawing.Point(4, 22);
            this.tabPreproc.Name = "tabPreproc";
            this.tabPreproc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPreproc.Size = new System.Drawing.Size(248, 350);
            this.tabPreproc.TabIndex = 1;
            this.tabPreproc.Text = "Pre-Processing";
            this.tabPreproc.UseVisualStyleBackColor = true;
            // 
            // grpFilters
            // 
            this.grpFilters.Controls.Add(this.chkBradley);
            this.grpFilters.Controls.Add(this.numThreshold);
            this.grpFilters.Controls.Add(this.lblThreshold);
            this.grpFilters.Controls.Add(this.chkThreshold);
            this.grpFilters.Controls.Add(this.numContrast);
            this.grpFilters.Controls.Add(this.lblContrast);
            this.grpFilters.Controls.Add(this.chkContrast);
            this.grpFilters.Controls.Add(this.lblBlurStrength);
            this.grpFilters.Controls.Add(this.numBlurStrength);
            this.grpFilters.Controls.Add(this.chkGaussian);
            this.grpFilters.Controls.Add(this.chkHistogram);
            this.grpFilters.Controls.Add(this.chkContastStretch);
            this.grpFilters.Controls.Add(this.chkGreyscale);
            this.grpFilters.Location = new System.Drawing.Point(6, 6);
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Size = new System.Drawing.Size(198, 268);
            this.grpFilters.TabIndex = 2;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "Filters";
            this.grpFilters.Enter += new System.EventHandler(this.grpFilters_Enter);
            // 
            // chkBradley
            // 
            this.chkBradley.AutoSize = true;
            this.chkBradley.Location = new System.Drawing.Point(15, 186);
            this.chkBradley.Name = "chkBradley";
            this.chkBradley.Size = new System.Drawing.Size(160, 17);
            this.chkBradley.TabIndex = 25;
            this.chkBradley.Text = "Apply bradley local threshold";
            this.chkBradley.UseVisualStyleBackColor = true;
            this.chkBradley.CheckStateChanged += new System.EventHandler(this.chkBradley_CheckedChanged);
            // 
            // numThreshold
            // 
            this.numThreshold.DecimalPlaces = 1;
            this.numThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numThreshold.Location = new System.Drawing.Point(87, 232);
            this.numThreshold.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numThreshold.Name = "numThreshold";
            this.numThreshold.Size = new System.Drawing.Size(70, 20);
            this.numThreshold.TabIndex = 24;
            this.numThreshold.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numThreshold.ValueChanged += new System.EventHandler(this.numThreshold_ValueChanged);
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Location = new System.Drawing.Point(32, 234);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(47, 13);
            this.lblThreshold.TabIndex = 23;
            this.lblThreshold.Text = "Strength";
            // 
            // chkThreshold
            // 
            this.chkThreshold.AutoSize = true;
            this.chkThreshold.Location = new System.Drawing.Point(15, 209);
            this.chkThreshold.Name = "chkThreshold";
            this.chkThreshold.Size = new System.Drawing.Size(98, 17);
            this.chkThreshold.TabIndex = 22;
            this.chkThreshold.Text = "Apply threshold";
            this.chkThreshold.UseVisualStyleBackColor = true;
            this.chkThreshold.CheckStateChanged += new System.EventHandler(this.chkThreshold_CheckedChanged);
            // 
            // numContrast
            // 
            this.numContrast.DecimalPlaces = 1;
            this.numContrast.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numContrast.Location = new System.Drawing.Point(87, 137);
            this.numContrast.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numContrast.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numContrast.Name = "numContrast";
            this.numContrast.Size = new System.Drawing.Size(70, 20);
            this.numContrast.TabIndex = 18;
            this.numContrast.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numContrast.ValueChanged += new System.EventHandler(this.numContrast_ValueChanged);
            // 
            // lblContrast
            // 
            this.lblContrast.AutoSize = true;
            this.lblContrast.Location = new System.Drawing.Point(32, 139);
            this.lblContrast.Name = "lblContrast";
            this.lblContrast.Size = new System.Drawing.Size(49, 13);
            this.lblContrast.TabIndex = 17;
            this.lblContrast.Text = "Contrast:";
            // 
            // chkContrast
            // 
            this.chkContrast.AutoSize = true;
            this.chkContrast.Location = new System.Drawing.Point(15, 114);
            this.chkContrast.Name = "chkContrast";
            this.chkContrast.Size = new System.Drawing.Size(157, 17);
            this.chkContrast.TabIndex = 16;
            this.chkContrast.Text = "Perform contrast adjustment";
            this.chkContrast.UseVisualStyleBackColor = true;
            this.chkContrast.CheckStateChanged += new System.EventHandler(this.chkContrast_CheckedChanged);
            // 
            // lblBlurStrength
            // 
            this.lblBlurStrength.AutoSize = true;
            this.lblBlurStrength.Location = new System.Drawing.Point(12, 89);
            this.lblBlurStrength.Name = "lblBlurStrength";
            this.lblBlurStrength.Size = new System.Drawing.Size(69, 13);
            this.lblBlurStrength.TabIndex = 15;
            this.lblBlurStrength.Text = "Blur strength:";
            // 
            // numBlurStrength
            // 
            this.numBlurStrength.Location = new System.Drawing.Point(87, 88);
            this.numBlurStrength.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.numBlurStrength.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numBlurStrength.Name = "numBlurStrength";
            this.numBlurStrength.Size = new System.Drawing.Size(70, 20);
            this.numBlurStrength.TabIndex = 14;
            this.numBlurStrength.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numBlurStrength.ValueChanged += new System.EventHandler(this.numBlurStrength_ValueChanged);
            // 
            // chkGaussian
            // 
            this.chkGaussian.AutoSize = true;
            this.chkGaussian.Location = new System.Drawing.Point(15, 65);
            this.chkGaussian.Name = "chkGaussian";
            this.chkGaussian.Size = new System.Drawing.Size(127, 17);
            this.chkGaussian.TabIndex = 13;
            this.chkGaussian.Text = "Perform gaussian blur";
            this.chkGaussian.UseVisualStyleBackColor = true;
            this.chkGaussian.CheckedChanged += new System.EventHandler(this.chkGaussian_CheckedChanged);
            // 
            // chkHistogram
            // 
            this.chkHistogram.AutoSize = true;
            this.chkHistogram.Location = new System.Drawing.Point(15, 42);
            this.chkHistogram.Name = "chkHistogram";
            this.chkHistogram.Size = new System.Drawing.Size(150, 17);
            this.chkHistogram.TabIndex = 12;
            this.chkHistogram.Text = "Apply histogram correction";
            this.chkHistogram.UseVisualStyleBackColor = true;
            this.chkHistogram.CheckedChanged += new System.EventHandler(this.chkHistogram_CheckedChanged);
            // 
            // chkContastStretch
            // 
            this.chkContastStretch.AutoSize = true;
            this.chkContastStretch.Location = new System.Drawing.Point(15, 19);
            this.chkContastStretch.Name = "chkContastStretch";
            this.chkContastStretch.Size = new System.Drawing.Size(102, 17);
            this.chkContastStretch.TabIndex = 7;
            this.chkContastStretch.Text = "Stretch Contrast";
            this.chkContastStretch.UseVisualStyleBackColor = true;
            this.chkContastStretch.CheckedChanged += new System.EventHandler(this.chkContastStretch_CheckedChanged);
            // 
            // chkGreyscale
            // 
            this.chkGreyscale.AutoSize = true;
            this.chkGreyscale.Checked = true;
            this.chkGreyscale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGreyscale.Enabled = false;
            this.chkGreyscale.Location = new System.Drawing.Point(15, 163);
            this.chkGreyscale.Name = "chkGreyscale";
            this.chkGreyscale.Size = new System.Drawing.Size(123, 17);
            this.chkGreyscale.TabIndex = 0;
            this.chkGreyscale.Text = "Convert to greyscale";
            this.chkGreyscale.UseVisualStyleBackColor = true;
            // 
            // tabGroups
            // 
            this.tabGroups.Controls.Add(this.btnTestSegments);
            this.tabGroups.Controls.Add(this.btnRemoveInputGroup);
            this.tabGroups.Controls.Add(this.lblTotalHiddenNodes);
            this.tabGroups.Controls.Add(this.lblTotalInputNodesStatic);
            this.tabGroups.Controls.Add(this.numSegments);
            this.tabGroups.Controls.Add(this.lblSegments);
            this.tabGroups.Controls.Add(this.btnAddInputGroup);
            this.tabGroups.Controls.Add(this.cmbInputGroup);
            this.tabGroups.Controls.Add(this.lstInputGroups);
            this.tabGroups.Location = new System.Drawing.Point(4, 22);
            this.tabGroups.Name = "tabGroups";
            this.tabGroups.Size = new System.Drawing.Size(248, 350);
            this.tabGroups.TabIndex = 2;
            this.tabGroups.Text = "Input Groups";
            this.tabGroups.UseVisualStyleBackColor = true;
            // 
            // btnTestSegments
            // 
            this.btnTestSegments.Location = new System.Drawing.Point(24, 236);
            this.btnTestSegments.Name = "btnTestSegments";
            this.btnTestSegments.Size = new System.Drawing.Size(75, 23);
            this.btnTestSegments.TabIndex = 8;
            this.btnTestSegments.Text = "Test Segmentation";
            this.btnTestSegments.UseVisualStyleBackColor = true;
            this.btnTestSegments.Click += new System.EventHandler(this.btnTestSegments_Click);
            // 
            // btnRemoveInputGroup
            // 
            this.btnRemoveInputGroup.Enabled = false;
            this.btnRemoveInputGroup.Location = new System.Drawing.Point(147, 133);
            this.btnRemoveInputGroup.Name = "btnRemoveInputGroup";
            this.btnRemoveInputGroup.Size = new System.Drawing.Size(68, 23);
            this.btnRemoveInputGroup.TabIndex = 7;
            this.btnRemoveInputGroup.Text = "Remove";
            this.btnRemoveInputGroup.UseVisualStyleBackColor = true;
            this.btnRemoveInputGroup.Click += new System.EventHandler(this.btnRemoveInputGroup_Click);
            // 
            // lblTotalHiddenNodes
            // 
            this.lblTotalHiddenNodes.AutoSize = true;
            this.lblTotalHiddenNodes.Location = new System.Drawing.Point(148, 185);
            this.lblTotalHiddenNodes.Name = "lblTotalHiddenNodes";
            this.lblTotalHiddenNodes.Size = new System.Drawing.Size(13, 13);
            this.lblTotalHiddenNodes.TabIndex = 6;
            this.lblTotalHiddenNodes.Text = "0";
            this.lblTotalHiddenNodes.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTotalInputNodesStatic
            // 
            this.lblTotalInputNodesStatic.AutoSize = true;
            this.lblTotalInputNodesStatic.Location = new System.Drawing.Point(37, 185);
            this.lblTotalInputNodesStatic.Name = "lblTotalInputNodesStatic";
            this.lblTotalInputNodesStatic.Size = new System.Drawing.Size(105, 13);
            this.lblTotalInputNodesStatic.TabIndex = 5;
            this.lblTotalInputNodesStatic.Text = "Total Hidden Nodes:";
            // 
            // numSegments
            // 
            this.numSegments.Enabled = false;
            this.numSegments.Location = new System.Drawing.Point(147, 162);
            this.numSegments.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSegments.Name = "numSegments";
            this.numSegments.Size = new System.Drawing.Size(68, 20);
            this.numSegments.TabIndex = 4;
            this.numSegments.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numSegments.ValueChanged += new System.EventHandler(this.numSegments_ValueChanged);
            // 
            // lblSegments
            // 
            this.lblSegments.AutoSize = true;
            this.lblSegments.Enabled = false;
            this.lblSegments.Location = new System.Drawing.Point(84, 164);
            this.lblSegments.Name = "lblSegments";
            this.lblSegments.Size = new System.Drawing.Size(57, 13);
            this.lblSegments.TabIndex = 3;
            this.lblSegments.Text = "Segments:";
            // 
            // btnAddInputGroup
            // 
            this.btnAddInputGroup.Location = new System.Drawing.Point(167, 3);
            this.btnAddInputGroup.Name = "btnAddInputGroup";
            this.btnAddInputGroup.Size = new System.Drawing.Size(48, 23);
            this.btnAddInputGroup.TabIndex = 2;
            this.btnAddInputGroup.Text = "Add";
            this.btnAddInputGroup.UseVisualStyleBackColor = true;
            this.btnAddInputGroup.Click += new System.EventHandler(this.btnAddInputGroup_Click);
            // 
            // cmbInputGroup
            // 
            this.cmbInputGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInputGroup.FormattingEnabled = true;
            this.cmbInputGroup.Items.AddRange(new object[] {
            "Grid",
            "Horozontal",
            "Vertical"});
            this.cmbInputGroup.Location = new System.Drawing.Point(3, 3);
            this.cmbInputGroup.Name = "cmbInputGroup";
            this.cmbInputGroup.Size = new System.Drawing.Size(158, 21);
            this.cmbInputGroup.TabIndex = 1;
            // 
            // lstInputGroups
            // 
            this.lstInputGroups.FormattingEnabled = true;
            this.lstInputGroups.Location = new System.Drawing.Point(3, 32);
            this.lstInputGroups.Name = "lstInputGroups";
            this.lstInputGroups.Size = new System.Drawing.Size(212, 95);
            this.lstInputGroups.TabIndex = 0;
            this.lstInputGroups.SelectedIndexChanged += new System.EventHandler(this.lstInputGroups_SelectedIndexChanged);
            // 
            // tabOptimisation
            // 
            this.tabOptimisation.Controls.Add(this.grpEndCond);
            this.tabOptimisation.Controls.Add(this.chkPSO);
            this.tabOptimisation.Controls.Add(this.grpPSO);
            this.tabOptimisation.Controls.Add(this.chkBackPropogation);
            this.tabOptimisation.Controls.Add(this.grpBackPropogation);
            this.tabOptimisation.Location = new System.Drawing.Point(4, 22);
            this.tabOptimisation.Name = "tabOptimisation";
            this.tabOptimisation.Size = new System.Drawing.Size(509, 386);
            this.tabOptimisation.TabIndex = 2;
            this.tabOptimisation.Text = "Optimisation";
            this.tabOptimisation.UseVisualStyleBackColor = true;
            // 
            // grpEndCond
            // 
            this.grpEndCond.Controls.Add(this.lblBufferSize);
            this.grpEndCond.Controls.Add(this.txtBufferSize);
            this.grpEndCond.Controls.Add(this.txtMaxTime);
            this.grpEndCond.Controls.Add(this.lblMaxTime);
            this.grpEndCond.Controls.Add(this.lblMinError);
            this.grpEndCond.Controls.Add(this.label2);
            this.grpEndCond.Controls.Add(this.txtMinimumError);
            this.grpEndCond.Controls.Add(this.txtMaxIterations);
            this.grpEndCond.Location = new System.Drawing.Point(14, 253);
            this.grpEndCond.Name = "grpEndCond";
            this.grpEndCond.Size = new System.Drawing.Size(222, 124);
            this.grpEndCond.TabIndex = 4;
            this.grpEndCond.TabStop = false;
            this.grpEndCond.Text = "Global Parameters";
            // 
            // lblBufferSize
            // 
            this.lblBufferSize.AutoSize = true;
            this.lblBufferSize.Location = new System.Drawing.Point(49, 101);
            this.lblBufferSize.Name = "lblBufferSize";
            this.lblBufferSize.Size = new System.Drawing.Size(61, 13);
            this.lblBufferSize.TabIndex = 12;
            this.lblBufferSize.Text = "Buffer Size:";
            // 
            // txtBufferSize
            // 
            this.txtBufferSize.Location = new System.Drawing.Point(116, 98);
            this.txtBufferSize.Name = "txtBufferSize";
            this.txtBufferSize.Size = new System.Drawing.Size(100, 20);
            this.txtBufferSize.TabIndex = 11;
            this.txtBufferSize.Text = "100000";
            // 
            // txtMaxTime
            // 
            this.txtMaxTime.Location = new System.Drawing.Point(116, 71);
            this.txtMaxTime.Name = "txtMaxTime";
            this.txtMaxTime.Size = new System.Drawing.Size(100, 20);
            this.txtMaxTime.TabIndex = 10;
            this.txtMaxTime.Text = "0";
            // 
            // lblMaxTime
            // 
            this.lblMaxTime.AutoSize = true;
            this.lblMaxTime.Location = new System.Drawing.Point(55, 73);
            this.lblMaxTime.Name = "lblMaxTime";
            this.lblMaxTime.Size = new System.Drawing.Size(56, 13);
            this.lblMaxTime.TabIndex = 9;
            this.lblMaxTime.Text = "Max Time:";
            // 
            // lblMinError
            // 
            this.lblMinError.AutoSize = true;
            this.lblMinError.Location = new System.Drawing.Point(34, 48);
            this.lblMinError.Name = "lblMinError";
            this.lblMinError.Size = new System.Drawing.Size(76, 13);
            this.lblMinError.TabIndex = 8;
            this.lblMinError.Text = "Minimum Error:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Max Iterations:";
            // 
            // txtMinimumError
            // 
            this.txtMinimumError.Location = new System.Drawing.Point(116, 45);
            this.txtMinimumError.Name = "txtMinimumError";
            this.txtMinimumError.Size = new System.Drawing.Size(100, 20);
            this.txtMinimumError.TabIndex = 6;
            this.txtMinimumError.Text = "0";
            // 
            // txtMaxIterations
            // 
            this.txtMaxIterations.Location = new System.Drawing.Point(116, 19);
            this.txtMaxIterations.Name = "txtMaxIterations";
            this.txtMaxIterations.Size = new System.Drawing.Size(100, 20);
            this.txtMaxIterations.TabIndex = 5;
            this.txtMaxIterations.Text = "0";
            // 
            // chkPSO
            // 
            this.chkPSO.AutoSize = true;
            this.chkPSO.Location = new System.Drawing.Point(248, 5);
            this.chkPSO.Name = "chkPSO";
            this.chkPSO.Size = new System.Drawing.Size(178, 17);
            this.chkPSO.TabIndex = 3;
            this.chkPSO.Text = "Use Particle Swarm Optimisation";
            this.chkPSO.UseVisualStyleBackColor = true;
            this.chkPSO.CheckedChanged += new System.EventHandler(this.chkPSO_CheckedChanged);
            // 
            // grpPSO
            // 
            this.grpPSO.Controls.Add(this.pnlPSO);
            this.grpPSO.Enabled = false;
            this.grpPSO.Location = new System.Drawing.Point(248, 28);
            this.grpPSO.Name = "grpPSO";
            this.grpPSO.Size = new System.Drawing.Size(248, 355);
            this.grpPSO.TabIndex = 2;
            this.grpPSO.TabStop = false;
            this.grpPSO.Text = "PSO";
            // 
            // pnlPSO
            // 
            this.pnlPSO.AutoScroll = true;
            this.pnlPSO.Controls.Add(this.grpPSOParams);
            this.pnlPSO.Controls.Add(this.grpSwarm);
            this.pnlPSO.Location = new System.Drawing.Point(0, 13);
            this.pnlPSO.Name = "pnlPSO";
            this.pnlPSO.Size = new System.Drawing.Size(242, 336);
            this.pnlPSO.TabIndex = 3;
            // 
            // grpPSOParams
            // 
            this.grpPSOParams.Controls.Add(this.chkAutoC);
            this.grpPSOParams.Controls.Add(this.chkAutoP);
            this.grpPSOParams.Controls.Add(this.chkAutoW);
            this.grpPSOParams.Controls.Add(this.chkAutoSwarmSize);
            this.grpPSOParams.Controls.Add(this.chkAutoK);
            this.grpPSOParams.Controls.Add(this.lblc);
            this.grpPSOParams.Controls.Add(this.txtC);
            this.grpPSOParams.Controls.Add(this.txtW);
            this.grpPSOParams.Controls.Add(this.txtP);
            this.grpPSOParams.Controls.Add(this.txtK);
            this.grpPSOParams.Controls.Add(this.lblW);
            this.grpPSOParams.Controls.Add(this.lblP);
            this.grpPSOParams.Controls.Add(this.lblK);
            this.grpPSOParams.Controls.Add(this.txtDimensions);
            this.grpPSOParams.Controls.Add(this.label3);
            this.grpPSOParams.Controls.Add(this.txtSwarmSize);
            this.grpPSOParams.Controls.Add(this.lblSwarmSize);
            this.grpPSOParams.Controls.Add(this.cmbRotation);
            this.grpPSOParams.Controls.Add(this.lblRotation);
            this.grpPSOParams.Controls.Add(this.cmbPSORandom);
            this.grpPSOParams.Controls.Add(this.lblRandOrder);
            this.grpPSOParams.Controls.Add(this.cmbRandOrder);
            this.grpPSOParams.Controls.Add(this.lblPSORandom);
            this.grpPSOParams.Controls.Add(this.cmbInitLinks);
            this.grpPSOParams.Controls.Add(this.lblInitLinks);
            this.grpPSOParams.Controls.Add(this.lblClamping);
            this.grpPSOParams.Controls.Add(this.cmbClamping);
            this.grpPSOParams.Location = new System.Drawing.Point(6, 109);
            this.grpPSOParams.Name = "grpPSOParams";
            this.grpPSOParams.Size = new System.Drawing.Size(217, 282);
            this.grpPSOParams.TabIndex = 4;
            this.grpPSOParams.TabStop = false;
            this.grpPSOParams.Text = "General Parameters";
            // 
            // chkAutoC
            // 
            this.chkAutoC.AutoSize = true;
            this.chkAutoC.Checked = true;
            this.chkAutoC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoC.Location = new System.Drawing.Point(196, 243);
            this.chkAutoC.Name = "chkAutoC";
            this.chkAutoC.Size = new System.Drawing.Size(15, 14);
            this.chkAutoC.TabIndex = 27;
            this.chkAutoC.UseVisualStyleBackColor = true;
            this.chkAutoC.CheckedChanged += new System.EventHandler(this.chkAutoC_CheckedChanged);
            // 
            // chkAutoP
            // 
            this.chkAutoP.AutoSize = true;
            this.chkAutoP.Checked = true;
            this.chkAutoP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoP.Location = new System.Drawing.Point(196, 218);
            this.chkAutoP.Name = "chkAutoP";
            this.chkAutoP.Size = new System.Drawing.Size(15, 14);
            this.chkAutoP.TabIndex = 26;
            this.chkAutoP.UseVisualStyleBackColor = true;
            this.chkAutoP.CheckedChanged += new System.EventHandler(this.chkAutoP_CheckedChanged);
            // 
            // chkAutoW
            // 
            this.chkAutoW.AutoSize = true;
            this.chkAutoW.Checked = true;
            this.chkAutoW.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoW.Location = new System.Drawing.Point(80, 244);
            this.chkAutoW.Name = "chkAutoW";
            this.chkAutoW.Size = new System.Drawing.Size(15, 14);
            this.chkAutoW.TabIndex = 25;
            this.chkAutoW.UseVisualStyleBackColor = true;
            this.chkAutoW.CheckedChanged += new System.EventHandler(this.chkAutoW_CheckedChanged);
            // 
            // chkAutoSwarmSize
            // 
            this.chkAutoSwarmSize.AutoSize = true;
            this.chkAutoSwarmSize.Checked = true;
            this.chkAutoSwarmSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoSwarmSize.Location = new System.Drawing.Point(135, 183);
            this.chkAutoSwarmSize.Name = "chkAutoSwarmSize";
            this.chkAutoSwarmSize.Size = new System.Drawing.Size(15, 14);
            this.chkAutoSwarmSize.TabIndex = 24;
            this.chkAutoSwarmSize.UseVisualStyleBackColor = true;
            this.chkAutoSwarmSize.CheckedChanged += new System.EventHandler(this.chkAutoSwarmSize_CheckedChanged);
            // 
            // chkAutoK
            // 
            this.chkAutoK.AutoSize = true;
            this.chkAutoK.Checked = true;
            this.chkAutoK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoK.Location = new System.Drawing.Point(80, 218);
            this.chkAutoK.Name = "chkAutoK";
            this.chkAutoK.Size = new System.Drawing.Size(15, 14);
            this.chkAutoK.TabIndex = 23;
            this.chkAutoK.UseVisualStyleBackColor = true;
            this.chkAutoK.CheckedChanged += new System.EventHandler(this.chkAutoK_CheckedChanged);
            // 
            // lblc
            // 
            this.lblc.AutoSize = true;
            this.lblc.Location = new System.Drawing.Point(118, 244);
            this.lblc.Name = "lblc";
            this.lblc.Size = new System.Drawing.Size(16, 13);
            this.lblc.TabIndex = 22;
            this.lblc.Text = "c:";
            // 
            // txtC
            // 
            this.txtC.Enabled = false;
            this.txtC.Location = new System.Drawing.Point(144, 241);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(46, 20);
            this.txtC.TabIndex = 21;
            this.txtC.Text = "0";
            // 
            // txtW
            // 
            this.txtW.Enabled = false;
            this.txtW.Location = new System.Drawing.Point(28, 241);
            this.txtW.Name = "txtW";
            this.txtW.Size = new System.Drawing.Size(46, 20);
            this.txtW.TabIndex = 20;
            this.txtW.Text = "0";
            // 
            // txtP
            // 
            this.txtP.Enabled = false;
            this.txtP.Location = new System.Drawing.Point(144, 215);
            this.txtP.Name = "txtP";
            this.txtP.Size = new System.Drawing.Size(46, 20);
            this.txtP.TabIndex = 19;
            this.txtP.Text = "0";
            // 
            // txtK
            // 
            this.txtK.Enabled = false;
            this.txtK.Location = new System.Drawing.Point(28, 215);
            this.txtK.Name = "txtK";
            this.txtK.Size = new System.Drawing.Size(46, 20);
            this.txtK.TabIndex = 18;
            this.txtK.Text = "3";
            this.txtK.TextChanged += new System.EventHandler(this.txtK_TextChanged);
            // 
            // lblW
            // 
            this.lblW.AutoSize = true;
            this.lblW.Location = new System.Drawing.Point(5, 244);
            this.lblW.Name = "lblW";
            this.lblW.Size = new System.Drawing.Size(18, 13);
            this.lblW.TabIndex = 17;
            this.lblW.Text = "w:";
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.Location = new System.Drawing.Point(122, 218);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(16, 13);
            this.lblP.TabIndex = 16;
            this.lblP.Text = "p:";
            // 
            // lblK
            // 
            this.lblK.AutoSize = true;
            this.lblK.Location = new System.Drawing.Point(5, 219);
            this.lblK.Name = "lblK";
            this.lblK.Size = new System.Drawing.Size(16, 13);
            this.lblK.TabIndex = 15;
            this.lblK.Text = "k:";
            // 
            // txtDimensions
            // 
            this.txtDimensions.Enabled = false;
            this.txtDimensions.Location = new System.Drawing.Point(83, 152);
            this.txtDimensions.Name = "txtDimensions";
            this.txtDimensions.Size = new System.Drawing.Size(46, 20);
            this.txtDimensions.TabIndex = 13;
            this.txtDimensions.Text = "10";
            this.txtDimensions.TextChanged += new System.EventHandler(this.txtDimensions_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "D:";
            // 
            // txtSwarmSize
            // 
            this.txtSwarmSize.Enabled = false;
            this.txtSwarmSize.Location = new System.Drawing.Point(83, 180);
            this.txtSwarmSize.Name = "txtSwarmSize";
            this.txtSwarmSize.Size = new System.Drawing.Size(46, 20);
            this.txtSwarmSize.TabIndex = 11;
            this.txtSwarmSize.Text = "0";
            this.txtSwarmSize.TextChanged += new System.EventHandler(this.txtSwarmSize_TextChanged);
            // 
            // lblSwarmSize
            // 
            this.lblSwarmSize.AutoSize = true;
            this.lblSwarmSize.Location = new System.Drawing.Point(28, 183);
            this.lblSwarmSize.Name = "lblSwarmSize";
            this.lblSwarmSize.Size = new System.Drawing.Size(50, 13);
            this.lblSwarmSize.TabIndex = 10;
            this.lblSwarmSize.Text = "Particles:";
            // 
            // cmbRotation
            // 
            this.cmbRotation.FormattingEnabled = true;
            this.cmbRotation.Items.AddRange(new object[] {
            "Sensitive to rotation",
            "Unsensitive"});
            this.cmbRotation.Location = new System.Drawing.Point(83, 127);
            this.cmbRotation.Name = "cmbRotation";
            this.cmbRotation.Size = new System.Drawing.Size(121, 21);
            this.cmbRotation.TabIndex = 9;
            this.cmbRotation.SelectedIndexChanged += new System.EventHandler(this.cmbRotation_SelectedIndexChanged);
            // 
            // lblRotation
            // 
            this.lblRotation.AutoSize = true;
            this.lblRotation.Location = new System.Drawing.Point(27, 130);
            this.lblRotation.Name = "lblRotation";
            this.lblRotation.Size = new System.Drawing.Size(50, 13);
            this.lblRotation.TabIndex = 8;
            this.lblRotation.Text = "Rotation:";
            // 
            // cmbPSORandom
            // 
            this.cmbPSORandom.Enabled = false;
            this.cmbPSORandom.FormattingEnabled = true;
            this.cmbPSORandom.Items.AddRange(new object[] {
            "Kiss (unimplimented)",
            "Mersenne Twister"});
            this.cmbPSORandom.Location = new System.Drawing.Point(83, 73);
            this.cmbPSORandom.Name = "cmbPSORandom";
            this.cmbPSORandom.Size = new System.Drawing.Size(121, 21);
            this.cmbPSORandom.TabIndex = 5;
            // 
            // lblRandOrder
            // 
            this.lblRandOrder.AutoSize = true;
            this.lblRandOrder.Location = new System.Drawing.Point(6, 103);
            this.lblRandOrder.Name = "lblRandOrder";
            this.lblRandOrder.Size = new System.Drawing.Size(72, 13);
            this.lblRandOrder.TabIndex = 7;
            this.lblRandOrder.Text = "Particle order:";
            // 
            // cmbRandOrder
            // 
            this.cmbRandOrder.FormattingEnabled = true;
            this.cmbRandOrder.Items.AddRange(new object[] {
            "Particles modified in order",
            "Particles modified randomly"});
            this.cmbRandOrder.Location = new System.Drawing.Point(83, 100);
            this.cmbRandOrder.Name = "cmbRandOrder";
            this.cmbRandOrder.Size = new System.Drawing.Size(121, 21);
            this.cmbRandOrder.TabIndex = 6;
            // 
            // lblPSORandom
            // 
            this.lblPSORandom.AutoSize = true;
            this.lblPSORandom.Location = new System.Drawing.Point(6, 76);
            this.lblPSORandom.Name = "lblPSORandom";
            this.lblPSORandom.Size = new System.Drawing.Size(72, 13);
            this.lblPSORandom.TabIndex = 4;
            this.lblPSORandom.Text = "Randomness:";
            // 
            // cmbInitLinks
            // 
            this.cmbInitLinks.FormattingEnabled = true;
            this.cmbInitLinks.Items.AddRange(new object[] {
            "Reinit after failure",
            "Reinit after success"});
            this.cmbInitLinks.Location = new System.Drawing.Point(83, 46);
            this.cmbInitLinks.Name = "cmbInitLinks";
            this.cmbInitLinks.Size = new System.Drawing.Size(121, 21);
            this.cmbInitLinks.TabIndex = 3;
            // 
            // lblInitLinks
            // 
            this.lblInitLinks.AutoSize = true;
            this.lblInitLinks.Location = new System.Drawing.Point(25, 48);
            this.lblInitLinks.Name = "lblInitLinks";
            this.lblInitLinks.Size = new System.Drawing.Size(52, 13);
            this.lblInitLinks.TabIndex = 2;
            this.lblInitLinks.Text = "Init Links:";
            // 
            // lblClamping
            // 
            this.lblClamping.AutoSize = true;
            this.lblClamping.Location = new System.Drawing.Point(25, 22);
            this.lblClamping.Name = "lblClamping";
            this.lblClamping.Size = new System.Drawing.Size(53, 13);
            this.lblClamping.TabIndex = 1;
            this.lblClamping.Text = "Clamping:";
            // 
            // cmbClamping
            // 
            this.cmbClamping.FormattingEnabled = true;
            this.cmbClamping.Items.AddRange(new object[] {
            "No Clamping",
            "Classical (Bounded)"});
            this.cmbClamping.Location = new System.Drawing.Point(83, 19);
            this.cmbClamping.Name = "cmbClamping";
            this.cmbClamping.Size = new System.Drawing.Size(121, 21);
            this.cmbClamping.TabIndex = 0;
            // 
            // grpSwarm
            // 
            this.grpSwarm.Controls.Add(this.txtVMax);
            this.grpSwarm.Controls.Add(this.lblVMax);
            this.grpSwarm.Controls.Add(this.txtQuant);
            this.grpSwarm.Controls.Add(this.lblQuant);
            this.grpSwarm.Controls.Add(this.lblMaxI);
            this.grpSwarm.Controls.Add(this.txtMaxI);
            this.grpSwarm.Controls.Add(this.txtMinI);
            this.grpSwarm.Controls.Add(this.txtMaxP);
            this.grpSwarm.Controls.Add(this.txtMinP);
            this.grpSwarm.Controls.Add(this.lblMinI);
            this.grpSwarm.Controls.Add(this.lblMaxP);
            this.grpSwarm.Controls.Add(this.lblMinP);
            this.grpSwarm.Location = new System.Drawing.Point(3, 6);
            this.grpSwarm.Name = "grpSwarm";
            this.grpSwarm.Size = new System.Drawing.Size(217, 97);
            this.grpSwarm.TabIndex = 2;
            this.grpSwarm.TabStop = false;
            this.grpSwarm.Text = "Swarm Parameters";
            // 
            // txtQuant
            // 
            this.txtQuant.Location = new System.Drawing.Point(49, 64);
            this.txtQuant.Name = "txtQuant";
            this.txtQuant.Size = new System.Drawing.Size(46, 20);
            this.txtQuant.TabIndex = 9;
            this.txtQuant.Text = "0.0";
            // 
            // lblQuant
            // 
            this.lblQuant.AutoSize = true;
            this.lblQuant.Location = new System.Drawing.Point(4, 67);
            this.lblQuant.Name = "lblQuant";
            this.lblQuant.Size = new System.Drawing.Size(39, 13);
            this.lblQuant.TabIndex = 8;
            this.lblQuant.Text = "Quant:";
            // 
            // lblMaxI
            // 
            this.lblMaxI.AutoSize = true;
            this.lblMaxI.Location = new System.Drawing.Point(108, 42);
            this.lblMaxI.Name = "lblMaxI";
            this.lblMaxI.Size = new System.Drawing.Size(36, 13);
            this.lblMaxI.TabIndex = 7;
            this.lblMaxI.Text = "Max I:";
            // 
            // txtMaxI
            // 
            this.txtMaxI.Location = new System.Drawing.Point(147, 39);
            this.txtMaxI.Name = "txtMaxI";
            this.txtMaxI.Size = new System.Drawing.Size(46, 20);
            this.txtMaxI.TabIndex = 6;
            this.txtMaxI.Text = "1.0";
            // 
            // txtMinI
            // 
            this.txtMinI.Location = new System.Drawing.Point(49, 39);
            this.txtMinI.Name = "txtMinI";
            this.txtMinI.Size = new System.Drawing.Size(46, 20);
            this.txtMinI.TabIndex = 5;
            this.txtMinI.Text = "-1.0";
            // 
            // txtMaxP
            // 
            this.txtMaxP.Location = new System.Drawing.Point(147, 13);
            this.txtMaxP.Name = "txtMaxP";
            this.txtMaxP.Size = new System.Drawing.Size(46, 20);
            this.txtMaxP.TabIndex = 4;
            this.txtMaxP.Text = "1.0";
            // 
            // txtMinP
            // 
            this.txtMinP.Location = new System.Drawing.Point(49, 13);
            this.txtMinP.Name = "txtMinP";
            this.txtMinP.Size = new System.Drawing.Size(46, 20);
            this.txtMinP.TabIndex = 3;
            this.txtMinP.Text = "-1.0";
            // 
            // lblMinI
            // 
            this.lblMinI.AutoSize = true;
            this.lblMinI.Location = new System.Drawing.Point(10, 42);
            this.lblMinI.Name = "lblMinI";
            this.lblMinI.Size = new System.Drawing.Size(33, 13);
            this.lblMinI.TabIndex = 2;
            this.lblMinI.Text = "Min I:";
            // 
            // lblMaxP
            // 
            this.lblMaxP.AutoSize = true;
            this.lblMaxP.Location = new System.Drawing.Point(101, 17);
            this.lblMaxP.Name = "lblMaxP";
            this.lblMaxP.Size = new System.Drawing.Size(40, 13);
            this.lblMaxP.TabIndex = 1;
            this.lblMaxP.Text = "Max P:";
            // 
            // lblMinP
            // 
            this.lblMinP.AutoSize = true;
            this.lblMinP.Location = new System.Drawing.Point(6, 16);
            this.lblMinP.Name = "lblMinP";
            this.lblMinP.Size = new System.Drawing.Size(37, 13);
            this.lblMinP.TabIndex = 0;
            this.lblMinP.Text = "Min P:";
            // 
            // chkBackPropogation
            // 
            this.chkBackPropogation.AutoSize = true;
            this.chkBackPropogation.Location = new System.Drawing.Point(4, 5);
            this.chkBackPropogation.Name = "chkBackPropogation";
            this.chkBackPropogation.Size = new System.Drawing.Size(129, 17);
            this.chkBackPropogation.TabIndex = 1;
            this.chkBackPropogation.Text = "Use Backpropogation";
            this.chkBackPropogation.UseVisualStyleBackColor = true;
            this.chkBackPropogation.CheckedChanged += new System.EventHandler(this.chkBackPropogation_CheckedChanged);
            // 
            // grpBackPropogation
            // 
            this.grpBackPropogation.Controls.Add(this.grpJitter);
            this.grpBackPropogation.Controls.Add(this.grpLearningRate);
            this.grpBackPropogation.Enabled = false;
            this.grpBackPropogation.Location = new System.Drawing.Point(4, 28);
            this.grpBackPropogation.Name = "grpBackPropogation";
            this.grpBackPropogation.Size = new System.Drawing.Size(238, 211);
            this.grpBackPropogation.TabIndex = 0;
            this.grpBackPropogation.TabStop = false;
            this.grpBackPropogation.Text = "Back Propogation";
            // 
            // grpJitter
            // 
            this.grpJitter.Controls.Add(this.lblJitterNoiseLimit);
            this.grpJitter.Controls.Add(this.lblJitterEpoch);
            this.grpJitter.Controls.Add(this.txtJitterNoiseLimit);
            this.grpJitter.Controls.Add(this.txtJitterEpoch);
            this.grpJitter.Location = new System.Drawing.Point(10, 123);
            this.grpJitter.Name = "grpJitter";
            this.grpJitter.Size = new System.Drawing.Size(222, 77);
            this.grpJitter.TabIndex = 3;
            this.grpJitter.TabStop = false;
            this.grpJitter.Text = "Jitter Parameters";
            // 
            // lblJitterNoiseLimit
            // 
            this.lblJitterNoiseLimit.AutoSize = true;
            this.lblJitterNoiseLimit.Location = new System.Drawing.Point(24, 48);
            this.lblJitterNoiseLimit.Name = "lblJitterNoiseLimit";
            this.lblJitterNoiseLimit.Size = new System.Drawing.Size(86, 13);
            this.lblJitterNoiseLimit.TabIndex = 8;
            this.lblJitterNoiseLimit.Text = "Jitter Noise Limit:";
            // 
            // lblJitterEpoch
            // 
            this.lblJitterEpoch.AutoSize = true;
            this.lblJitterEpoch.Location = new System.Drawing.Point(44, 22);
            this.lblJitterEpoch.Name = "lblJitterEpoch";
            this.lblJitterEpoch.Size = new System.Drawing.Size(66, 13);
            this.lblJitterEpoch.TabIndex = 7;
            this.lblJitterEpoch.Text = "Jitter Epoch:";
            // 
            // txtJitterNoiseLimit
            // 
            this.txtJitterNoiseLimit.Location = new System.Drawing.Point(116, 45);
            this.txtJitterNoiseLimit.Name = "txtJitterNoiseLimit";
            this.txtJitterNoiseLimit.Size = new System.Drawing.Size(100, 20);
            this.txtJitterNoiseLimit.TabIndex = 6;
            this.txtJitterNoiseLimit.Text = "0.03";
            // 
            // txtJitterEpoch
            // 
            this.txtJitterEpoch.Location = new System.Drawing.Point(116, 19);
            this.txtJitterEpoch.Name = "txtJitterEpoch";
            this.txtJitterEpoch.Size = new System.Drawing.Size(100, 20);
            this.txtJitterEpoch.TabIndex = 5;
            this.txtJitterEpoch.Text = "73";
            // 
            // grpLearningRate
            // 
            this.grpLearningRate.Controls.Add(this.lblFinalRate);
            this.grpLearningRate.Controls.Add(this.txtFinalRate);
            this.grpLearningRate.Controls.Add(this.txtInitialRate);
            this.grpLearningRate.Controls.Add(this.lblInitialRate);
            this.grpLearningRate.Controls.Add(this.lblLearningRateType);
            this.grpLearningRate.Controls.Add(this.cmbLearningRateType);
            this.grpLearningRate.Location = new System.Drawing.Point(10, 19);
            this.grpLearningRate.Name = "grpLearningRate";
            this.grpLearningRate.Size = new System.Drawing.Size(222, 97);
            this.grpLearningRate.TabIndex = 2;
            this.grpLearningRate.TabStop = false;
            this.grpLearningRate.Text = "Learning Rate Parameters";
            // 
            // lblFinalRate
            // 
            this.lblFinalRate.AutoSize = true;
            this.lblFinalRate.Location = new System.Drawing.Point(53, 73);
            this.lblFinalRate.Name = "lblFinalRate";
            this.lblFinalRate.Size = new System.Drawing.Size(58, 13);
            this.lblFinalRate.TabIndex = 5;
            this.lblFinalRate.Text = "Final Rate:";
            // 
            // txtFinalRate
            // 
            this.txtFinalRate.Location = new System.Drawing.Point(116, 70);
            this.txtFinalRate.Name = "txtFinalRate";
            this.txtFinalRate.Size = new System.Drawing.Size(100, 20);
            this.txtFinalRate.TabIndex = 4;
            this.txtFinalRate.Text = "0.3";
            // 
            // txtInitialRate
            // 
            this.txtInitialRate.Location = new System.Drawing.Point(116, 46);
            this.txtInitialRate.Name = "txtInitialRate";
            this.txtInitialRate.Size = new System.Drawing.Size(100, 20);
            this.txtInitialRate.TabIndex = 3;
            this.txtInitialRate.Text = "0.3";
            // 
            // lblInitialRate
            // 
            this.lblInitialRate.AutoSize = true;
            this.lblInitialRate.Location = new System.Drawing.Point(51, 49);
            this.lblInitialRate.Name = "lblInitialRate";
            this.lblInitialRate.Size = new System.Drawing.Size(60, 13);
            this.lblInitialRate.TabIndex = 2;
            this.lblInitialRate.Text = "Initial Rate:";
            // 
            // lblLearningRateType
            // 
            this.lblLearningRateType.AutoSize = true;
            this.lblLearningRateType.Location = new System.Drawing.Point(76, 22);
            this.lblLearningRateType.Name = "lblLearningRateType";
            this.lblLearningRateType.Size = new System.Drawing.Size(34, 13);
            this.lblLearningRateType.TabIndex = 1;
            this.lblLearningRateType.Text = "Type:";
            // 
            // cmbLearningRateType
            // 
            this.cmbLearningRateType.FormattingEnabled = true;
            this.cmbLearningRateType.Items.AddRange(new object[] {
            "Fixed",
            "Exponential",
            "Hyperbolic",
            "Linear"});
            this.cmbLearningRateType.Location = new System.Drawing.Point(116, 19);
            this.cmbLearningRateType.Name = "cmbLearningRateType";
            this.cmbLearningRateType.Size = new System.Drawing.Size(100, 21);
            this.cmbLearningRateType.TabIndex = 0;
            this.cmbLearningRateType.SelectedIndexChanged += new System.EventHandler(this.cmbLearningRateType_SelectedIndexChanged);
            // 
            // tabSaveLoad
            // 
            this.tabSaveLoad.Controls.Add(this.chkEmbed);
            this.tabSaveLoad.Controls.Add(this.btnLoadRun);
            this.tabSaveLoad.Controls.Add(this.btnSaveRun);
            this.tabSaveLoad.Location = new System.Drawing.Point(4, 22);
            this.tabSaveLoad.Name = "tabSaveLoad";
            this.tabSaveLoad.Size = new System.Drawing.Size(509, 386);
            this.tabSaveLoad.TabIndex = 4;
            this.tabSaveLoad.Text = "Save/Load";
            this.tabSaveLoad.UseVisualStyleBackColor = true;
            // 
            // chkEmbed
            // 
            this.chkEmbed.AutoSize = true;
            this.chkEmbed.Checked = true;
            this.chkEmbed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEmbed.Enabled = false;
            this.chkEmbed.Location = new System.Drawing.Point(248, 3);
            this.chkEmbed.Name = "chkEmbed";
            this.chkEmbed.Size = new System.Drawing.Size(108, 17);
            this.chkEmbed.TabIndex = 9;
            this.chkEmbed.Text = "Embed all images";
            this.chkEmbed.UseVisualStyleBackColor = true;
            // 
            // btnLoadRun
            // 
            this.btnLoadRun.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadRun.Image")));
            this.btnLoadRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadRun.Location = new System.Drawing.Point(3, 59);
            this.btnLoadRun.Name = "btnLoadRun";
            this.btnLoadRun.Size = new System.Drawing.Size(239, 50);
            this.btnLoadRun.TabIndex = 8;
            this.btnLoadRun.Text = "Load run file...";
            this.btnLoadRun.UseVisualStyleBackColor = true;
            this.btnLoadRun.Click += new System.EventHandler(this.btnLoadRun_Click);
            // 
            // btnSaveRun
            // 
            this.btnSaveRun.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveRun.Image")));
            this.btnSaveRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveRun.Location = new System.Drawing.Point(3, 3);
            this.btnSaveRun.Name = "btnSaveRun";
            this.btnSaveRun.Size = new System.Drawing.Size(239, 50);
            this.btnSaveRun.TabIndex = 7;
            this.btnSaveRun.Text = "Save run file...";
            this.btnSaveRun.UseVisualStyleBackColor = true;
            this.btnSaveRun.Click += new System.EventHandler(this.btnSaveRun_Click);
            // 
            // colourPicker1
            // 
            this.colourPicker1.Location = new System.Drawing.Point(10, 393);
            this.colourPicker1.Name = "colourPicker1";
            this.colourPicker1.Size = new System.Drawing.Size(260, 20);
            this.colourPicker1.TabIndex = 2;
            this.colourPicker1.Load += new System.EventHandler(this.colourPicker1_Load);
            // 
            // imageViewer1
            // 
            this.imageViewer1.DrawingColour = System.Drawing.Color.Black;
            this.imageViewer1.Location = new System.Drawing.Point(10, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.ScalingMethod = ENFORM.Core.ScalingMethods.Nearest_Neighbor;
            this.imageViewer1.Size = new System.Drawing.Size(258, 334);
            this.imageViewer1.TabIndex = 3;
            // 
            // lblVMax
            // 
            this.lblVMax.AutoSize = true;
            this.lblVMax.Location = new System.Drawing.Point(101, 67);
            this.lblVMax.Name = "lblVMax";
            this.lblVMax.Size = new System.Drawing.Size(40, 13);
            this.lblVMax.TabIndex = 10;
            this.lblVMax.Text = "Max V:";
            // 
            // txtVMax
            // 
            this.txtVMax.Location = new System.Drawing.Point(147, 64);
            this.txtVMax.Name = "txtVMax";
            this.txtVMax.Size = new System.Drawing.Size(46, 20);
            this.txtVMax.TabIndex = 11;
            this.txtVMax.Text = "1.0";
            // 
            // frmRunEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 425);
            this.Controls.Add(this.imageViewer1);
            this.Controls.Add(this.colourPicker1);
            this.Controls.Add(this.tabMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmRunEditor";
            this.Text = "Run Editor - ENFORM";
            this.Load += new System.EventHandler(this.frmRunEditor_Load);
            this.Shown += new System.EventHandler(this.frmRunEditor_Shown);
            this.tabMain.ResumeLayout(false);
            this.tabTestData.ResumeLayout(false);
            this.tabInnerTestData.ResumeLayout(false);
            this.tabSources.ResumeLayout(false);
            this.grpInputProperties.ResumeLayout(false);
            this.grpInputProperties.PerformLayout();
            this.tabPreproc.ResumeLayout(false);
            this.grpFilters.ResumeLayout(false);
            this.grpFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlurStrength)).EndInit();
            this.tabGroups.ResumeLayout(false);
            this.tabGroups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSegments)).EndInit();
            this.tabOptimisation.ResumeLayout(false);
            this.tabOptimisation.PerformLayout();
            this.grpEndCond.ResumeLayout(false);
            this.grpEndCond.PerformLayout();
            this.grpPSO.ResumeLayout(false);
            this.pnlPSO.ResumeLayout(false);
            this.grpPSOParams.ResumeLayout(false);
            this.grpPSOParams.PerformLayout();
            this.grpSwarm.ResumeLayout(false);
            this.grpSwarm.PerformLayout();
            this.grpBackPropogation.ResumeLayout(false);
            this.grpJitter.ResumeLayout(false);
            this.grpJitter.PerformLayout();
            this.grpLearningRate.ResumeLayout(false);
            this.grpLearningRate.PerformLayout();
            this.tabSaveLoad.ResumeLayout(false);
            this.tabSaveLoad.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabTestData;
        private System.Windows.Forms.ListView lstInputs;
        private System.Windows.Forms.ColumnHeader clmName;
        private System.Windows.Forms.ColumnHeader clmType;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Button btnGetFERETImages;
        private System.Windows.Forms.Button btnLoadImages;
        private System.Windows.Forms.Button btnNewImage;
        private System.Windows.Forms.GroupBox grpInputProperties;     
        private System.Windows.Forms.ColumnHeader clmSize;
        private System.Windows.Forms.CheckBox chkAspect;
        private ColourPicker colourPicker1;
        private System.Windows.Forms.TabControl tabInnerTestData;
        private System.Windows.Forms.TabPage tabSources;
        private System.Windows.Forms.TabPage tabPreproc;
        private System.Windows.Forms.TabPage tabGroups;
        private System.Windows.Forms.GroupBox grpFilters;
        private System.Windows.Forms.CheckBox chkGreyscale;
        private System.Windows.Forms.CheckBox chkContastStretch;
        private System.Windows.Forms.CheckBox chkHistogram;
        private System.Windows.Forms.NumericUpDown numContrast;
        private System.Windows.Forms.Label lblContrast;
        private System.Windows.Forms.CheckBox chkContrast;
        private System.Windows.Forms.Label lblBlurStrength;
        private System.Windows.Forms.NumericUpDown numBlurStrength;
        private System.Windows.Forms.CheckBox chkGaussian;
        private System.Windows.Forms.NumericUpDown numThreshold;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.CheckBox chkThreshold;
        private System.Windows.Forms.CheckBox chkBradley;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddInputGroup;
        private System.Windows.Forms.ComboBox cmbInputGroup;
        private System.Windows.Forms.ListBox lstInputGroups;
        private System.Windows.Forms.NumericUpDown numSegments;
        private System.Windows.Forms.Label lblSegments;
        private System.Windows.Forms.Label lblScalingMethod;
        private System.Windows.Forms.ComboBox cmbScalingMethod;
        private System.Windows.Forms.Label lblTotalHiddenNodes;
        private System.Windows.Forms.Label lblTotalInputNodesStatic;
        private System.Windows.Forms.Button btnRemoveInputGroup;
        private System.Windows.Forms.ColumnHeader clmExpectedOutput;
        private System.Windows.Forms.TabPage tabOptimisation;
        private System.Windows.Forms.CheckBox chkPSO;
        private System.Windows.Forms.GroupBox grpPSO;
        private System.Windows.Forms.CheckBox chkBackPropogation;
        private System.Windows.Forms.GroupBox grpBackPropogation;
        private System.Windows.Forms.TabPage tabSaveLoad;
        private System.Windows.Forms.CheckBox chkEmbed;
        private System.Windows.Forms.Button btnLoadRun;
        private System.Windows.Forms.Button btnSaveRun;
        private System.Windows.Forms.GroupBox grpLearningRate;
        private System.Windows.Forms.Label lblFinalRate;
        private System.Windows.Forms.TextBox txtFinalRate;
        private System.Windows.Forms.TextBox txtInitialRate;
        private System.Windows.Forms.Label lblInitialRate;
        private System.Windows.Forms.Label lblLearningRateType;
        private System.Windows.Forms.ComboBox cmbLearningRateType;
        private System.Windows.Forms.GroupBox grpJitter;
        private System.Windows.Forms.Label lblJitterNoiseLimit;
        private System.Windows.Forms.Label lblJitterEpoch;
        private System.Windows.Forms.TextBox txtJitterNoiseLimit;
        private System.Windows.Forms.TextBox txtJitterEpoch;
        private System.Windows.Forms.GroupBox grpEndCond;
        private System.Windows.Forms.Label lblMinError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMinimumError;
        private System.Windows.Forms.TextBox txtMaxIterations;
        private System.Windows.Forms.Button btnTestSegments;
        private System.Windows.Forms.TextBox txtMaxTime;
        private System.Windows.Forms.Label lblMaxTime;
        private System.Windows.Forms.Panel pnlPSO;
        private System.Windows.Forms.GroupBox grpSwarm;
        private System.Windows.Forms.TextBox txtQuant;
        private System.Windows.Forms.Label lblQuant;
        private System.Windows.Forms.Label lblMaxI;
        private System.Windows.Forms.TextBox txtMaxI;
        private System.Windows.Forms.TextBox txtMinI;
        private System.Windows.Forms.TextBox txtMaxP;
        private System.Windows.Forms.TextBox txtMinP;
        private System.Windows.Forms.Label lblMinI;
        private System.Windows.Forms.Label lblMaxP;
        private System.Windows.Forms.Label lblMinP;
        private System.Windows.Forms.GroupBox grpPSOParams;
        private System.Windows.Forms.Label lblc;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.TextBox txtW;
        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.TextBox txtK;
        private System.Windows.Forms.Label lblW;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.Label lblK;
        private System.Windows.Forms.TextBox txtDimensions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSwarmSize;
        private System.Windows.Forms.Label lblSwarmSize;
        private System.Windows.Forms.ComboBox cmbRotation;
        private System.Windows.Forms.Label lblRotation;
        private System.Windows.Forms.ComboBox cmbPSORandom;
        private System.Windows.Forms.Label lblRandOrder;
        private System.Windows.Forms.ComboBox cmbRandOrder;
        private System.Windows.Forms.Label lblPSORandom;
        private System.Windows.Forms.ComboBox cmbInitLinks;
        private System.Windows.Forms.Label lblInitLinks;
        private System.Windows.Forms.Label lblClamping;
        private System.Windows.Forms.ComboBox cmbClamping;
        private System.Windows.Forms.CheckBox chkAutoC;
        private System.Windows.Forms.CheckBox chkAutoP;
        private System.Windows.Forms.CheckBox chkAutoW;
        private System.Windows.Forms.CheckBox chkAutoSwarmSize;
        private System.Windows.Forms.CheckBox chkAutoK;
        private System.Windows.Forms.Label lblBufferSize;
        private System.Windows.Forms.TextBox txtBufferSize;
        private ImageViewer imageViewer1;
        private System.Windows.Forms.TextBox txtVMax;
        private System.Windows.Forms.Label lblVMax;
    }
}

