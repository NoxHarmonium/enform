namespace ENFORM
{
    partial class frmNetworkTester
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
            this.lstRuns = new System.Windows.Forms.ListView();
            this.clmRunID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmEndTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmMinFitness = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOpenTestImage = new System.Windows.Forms.Button();
            this.btnLoadRunFile = new System.Windows.Forms.Button();
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
            this.lstInputGroups = new System.Windows.Forms.ListBox();
            this.imgTestImage = new ENFORM.ImageViewer();
            this.lblFitness = new System.Windows.Forms.Label();
            this.cmbSampleType = new System.Windows.Forms.ComboBox();
            this.grpFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlurStrength)).BeginInit();
            this.SuspendLayout();
            // 
            // lstRuns
            // 
            this.lstRuns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmRunID,
            this.clmStartTime,
            this.clmEndTime,
            this.clmStatus,
            this.clmMinFitness});
            this.lstRuns.FullRowSelect = true;
            this.lstRuns.Location = new System.Drawing.Point(13, 11);
            this.lstRuns.MultiSelect = false;
            this.lstRuns.Name = "lstRuns";
            this.lstRuns.Size = new System.Drawing.Size(463, 334);
            this.lstRuns.TabIndex = 1;
            this.lstRuns.UseCompatibleStateImageBehavior = false;
            this.lstRuns.View = System.Windows.Forms.View.Details;
            this.lstRuns.SelectedIndexChanged += new System.EventHandler(this.lstRuns_SelectedIndexChanged);
            // 
            // clmRunID
            // 
            this.clmRunID.Text = "Run ID";
            // 
            // clmStartTime
            // 
            this.clmStartTime.Text = "Start Time";
            this.clmStartTime.Width = 140;
            // 
            // clmEndTime
            // 
            this.clmEndTime.Text = "End Time";
            this.clmEndTime.Width = 113;
            // 
            // clmStatus
            // 
            this.clmStatus.Text = "Status";
            // 
            // clmMinFitness
            // 
            this.clmMinFitness.Text = "Min Fitness";
            this.clmMinFitness.Width = 84;
            // 
            // btnOpenTestImage
            // 
            this.btnOpenTestImage.Location = new System.Drawing.Point(705, 352);
            this.btnOpenTestImage.Name = "btnOpenTestImage";
            this.btnOpenTestImage.Size = new System.Drawing.Size(111, 23);
            this.btnOpenTestImage.TabIndex = 2;
            this.btnOpenTestImage.Text = "Load Test Image";
            this.btnOpenTestImage.UseVisualStyleBackColor = true;
            this.btnOpenTestImage.Click += new System.EventHandler(this.btnOpenTestImage_Click);
            // 
            // btnLoadRunFile
            // 
            this.btnLoadRunFile.Location = new System.Drawing.Point(13, 351);
            this.btnLoadRunFile.Name = "btnLoadRunFile";
            this.btnLoadRunFile.Size = new System.Drawing.Size(107, 23);
            this.btnLoadRunFile.TabIndex = 4;
            this.btnLoadRunFile.Text = "Load Run File";
            this.btnLoadRunFile.UseVisualStyleBackColor = true;
            this.btnLoadRunFile.Click += new System.EventHandler(this.btnLoadRunFile_Click);
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
            this.grpFilters.Location = new System.Drawing.Point(482, 12);
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Size = new System.Drawing.Size(198, 268);
            this.grpFilters.TabIndex = 5;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "Filters";
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
            // lstInputGroups
            // 
            this.lstInputGroups.FormattingEnabled = true;
            this.lstInputGroups.Location = new System.Drawing.Point(482, 286);
            this.lstInputGroups.Name = "lstInputGroups";
            this.lstInputGroups.Size = new System.Drawing.Size(198, 56);
            this.lstInputGroups.TabIndex = 6;
            // 
            // imgTestImage
            // 
            this.imgTestImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgTestImage.DrawingColour = System.Drawing.Color.Black;
            this.imgTestImage.Location = new System.Drawing.Point(696, 12);
            this.imgTestImage.Name = "imgTestImage";
            this.imgTestImage.ScalingMethod = ENFORM.ScalingMethods.Nearest_Neighbor;
            this.imgTestImage.Size = new System.Drawing.Size(258, 334);
            this.imgTestImage.TabIndex = 0;
            // 
            // lblFitness
            // 
            this.lblFitness.AutoSize = true;
            this.lblFitness.Location = new System.Drawing.Point(482, 353);
            this.lblFitness.Name = "lblFitness";
            this.lblFitness.Size = new System.Drawing.Size(43, 13);
            this.lblFitness.TabIndex = 7;
            this.lblFitness.Text = "Fitness:";
            this.lblFitness.Click += new System.EventHandler(this.lblFitness_Click);
            // 
            // cmbSampleType
            // 
            this.cmbSampleType.FormattingEnabled = true;
            this.cmbSampleType.Items.AddRange(new object[] {
            "Positive Sample",
            "Negitive Sample"});
            this.cmbSampleType.Location = new System.Drawing.Point(822, 353);
            this.cmbSampleType.Name = "cmbSampleType";
            this.cmbSampleType.Size = new System.Drawing.Size(141, 21);
            this.cmbSampleType.TabIndex = 3;
            this.cmbSampleType.SelectedIndexChanged += new System.EventHandler(this.cmbSampleType_SelectedIndexChanged);
            // 
            // frmNetworkTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 381);
            this.Controls.Add(this.lblFitness);
            this.Controls.Add(this.lstInputGroups);
            this.Controls.Add(this.grpFilters);
            this.Controls.Add(this.btnLoadRunFile);
            this.Controls.Add(this.cmbSampleType);
            this.Controls.Add(this.btnOpenTestImage);
            this.Controls.Add(this.lstRuns);
            this.Controls.Add(this.imgTestImage);
            this.Name = "frmNetworkTester";
            this.Text = "Network Tester";
            this.grpFilters.ResumeLayout(false);
            this.grpFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlurStrength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageViewer imgTestImage;
        private System.Windows.Forms.ListView lstRuns;
        private System.Windows.Forms.Button btnOpenTestImage;
        private System.Windows.Forms.Button btnLoadRunFile;
        private System.Windows.Forms.ColumnHeader clmRunID;
        private System.Windows.Forms.ColumnHeader clmStartTime;
        private System.Windows.Forms.ColumnHeader clmEndTime;
        private System.Windows.Forms.ColumnHeader clmStatus;
        private System.Windows.Forms.ColumnHeader clmMinFitness;
        private System.Windows.Forms.GroupBox grpFilters;
        private System.Windows.Forms.CheckBox chkBradley;
        private System.Windows.Forms.NumericUpDown numThreshold;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.CheckBox chkThreshold;
        private System.Windows.Forms.NumericUpDown numContrast;
        private System.Windows.Forms.Label lblContrast;
        private System.Windows.Forms.CheckBox chkContrast;
        private System.Windows.Forms.Label lblBlurStrength;
        private System.Windows.Forms.NumericUpDown numBlurStrength;
        private System.Windows.Forms.CheckBox chkGaussian;
        private System.Windows.Forms.CheckBox chkHistogram;
        private System.Windows.Forms.CheckBox chkContastStretch;
        private System.Windows.Forms.CheckBox chkGreyscale;
        private System.Windows.Forms.ListBox lstInputGroups;
        private System.Windows.Forms.Label lblFitness;
        private System.Windows.Forms.ComboBox cmbSampleType;
    }
}