namespace ENFORM.GUI
{
    partial class frmOptimiser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptimiser));
            this.lstRuns = new System.Windows.Forms.ListView();
            this.clmRunName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFullFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddRun = new System.Windows.Forms.Button();
            this.btnDeleteRuns = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.grpProperties = new System.Windows.Forms.GroupBox();
            this.numThreads = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numRuns = new System.Windows.Forms.NumericUpDown();
            this.lblRuns = new System.Windows.Forms.Label();
            this.tabThreads = new System.Windows.Forms.TabControl();
            this.tabFirstThread = new System.Windows.Forms.TabPage();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblCurrentRunValue = new System.Windows.Forms.Label();
            this.lblCurrentRun = new System.Windows.Forms.Label();
            this.btnSaveBatch = new System.Windows.Forms.Button();
            this.grpProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRuns)).BeginInit();
            this.tabThreads.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstRuns
            // 
            this.lstRuns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmRunName,
            this.clmDone,
            this.clmFullFilename});
            this.lstRuns.Location = new System.Drawing.Point(12, 12);
            this.lstRuns.Name = "lstRuns";
            this.lstRuns.Size = new System.Drawing.Size(232, 358);
            this.lstRuns.TabIndex = 0;
            this.lstRuns.UseCompatibleStateImageBehavior = false;
            this.lstRuns.View = System.Windows.Forms.View.Details;
            // 
            // clmRunName
            // 
            this.clmRunName.Text = "Name";
            this.clmRunName.Width = 207;
            // 
            // clmDone
            // 
            this.clmDone.Text = "F";
            this.clmDone.Width = 21;
            // 
            // clmFullFilename
            // 
            this.clmFullFilename.Text = "Full Filename";
            // 
            // btnAddRun
            // 
            this.btnAddRun.Location = new System.Drawing.Point(12, 376);
            this.btnAddRun.Name = "btnAddRun";
            this.btnAddRun.Size = new System.Drawing.Size(109, 23);
            this.btnAddRun.TabIndex = 1;
            this.btnAddRun.Text = "Add ";
            this.btnAddRun.UseVisualStyleBackColor = true;
            this.btnAddRun.Click += new System.EventHandler(this.btnAddRun_Click);
            // 
            // btnDeleteRuns
            // 
            this.btnDeleteRuns.Location = new System.Drawing.Point(127, 376);
            this.btnDeleteRuns.Name = "btnDeleteRuns";
            this.btnDeleteRuns.Size = new System.Drawing.Size(117, 23);
            this.btnDeleteRuns.TabIndex = 2;
            this.btnDeleteRuns.Text = "Remove";
            this.btnDeleteRuns.UseVisualStyleBackColor = true;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveUp.Image")));
            this.btnMoveUp.Location = new System.Drawing.Point(250, 9);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(28, 23);
            this.btnMoveUp.TabIndex = 3;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveDown.Image")));
            this.btnMoveDown.Location = new System.Drawing.Point(250, 38);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(28, 23);
            this.btnMoveDown.TabIndex = 4;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // grpProperties
            // 
            this.grpProperties.Controls.Add(this.numThreads);
            this.grpProperties.Controls.Add(this.label1);
            this.grpProperties.Controls.Add(this.numRuns);
            this.grpProperties.Controls.Add(this.lblRuns);
            this.grpProperties.Location = new System.Drawing.Point(285, 12);
            this.grpProperties.Name = "grpProperties";
            this.grpProperties.Size = new System.Drawing.Size(179, 173);
            this.grpProperties.TabIndex = 5;
            this.grpProperties.TabStop = false;
            this.grpProperties.Text = "Master Properties";
            // 
            // numThreads
            // 
            this.numThreads.Location = new System.Drawing.Point(123, 46);
            this.numThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThreads.Name = "numThreads";
            this.numThreads.Size = new System.Drawing.Size(45, 20);
            this.numThreads.TabIndex = 3;
            this.numThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThreads.ValueChanged += new System.EventHandler(this.numThreads_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of threads:";
            // 
            // numRuns
            // 
            this.numRuns.Location = new System.Drawing.Point(123, 20);
            this.numRuns.Name = "numRuns";
            this.numRuns.Size = new System.Drawing.Size(45, 20);
            this.numRuns.TabIndex = 1;
            this.numRuns.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblRuns
            // 
            this.lblRuns.AutoSize = true;
            this.lblRuns.Location = new System.Drawing.Point(7, 20);
            this.lblRuns.Name = "lblRuns";
            this.lblRuns.Size = new System.Drawing.Size(109, 13);
            this.lblRuns.TabIndex = 0;
            this.lblRuns.Text = "Number of runs each:";
            // 
            // tabThreads
            // 
            this.tabThreads.Controls.Add(this.tabFirstThread);
            this.tabThreads.Location = new System.Drawing.Point(470, 12);
            this.tabThreads.Name = "tabThreads";
            this.tabThreads.SelectedIndex = 0;
            this.tabThreads.Size = new System.Drawing.Size(312, 387);
            this.tabThreads.TabIndex = 6;
            // 
            // tabFirstThread
            // 
            this.tabFirstThread.Location = new System.Drawing.Point(4, 22);
            this.tabFirstThread.Name = "tabFirstThread";
            this.tabFirstThread.Padding = new System.Windows.Forms.Padding(3);
            this.tabFirstThread.Size = new System.Drawing.Size(304, 361);
            this.tabFirstThread.TabIndex = 0;
            this.tabFirstThread.Text = "Thread 1";
            this.tabFirstThread.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(295, 376);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(378, 376);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.lblCurrentRunValue);
            this.grpInfo.Controls.Add(this.lblCurrentRun);
            this.grpInfo.Location = new System.Drawing.Point(285, 191);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(179, 173);
            this.grpInfo.TabIndex = 9;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Info";
            // 
            // lblCurrentRunValue
            // 
            this.lblCurrentRunValue.AutoSize = true;
            this.lblCurrentRunValue.Location = new System.Drawing.Point(80, 20);
            this.lblCurrentRunValue.Name = "lblCurrentRunValue";
            this.lblCurrentRunValue.Size = new System.Drawing.Size(27, 13);
            this.lblCurrentRunValue.TabIndex = 1;
            this.lblCurrentRunValue.Text = "N/A";
            // 
            // lblCurrentRun
            // 
            this.lblCurrentRun.AutoSize = true;
            this.lblCurrentRun.Location = new System.Drawing.Point(7, 20);
            this.lblCurrentRun.Name = "lblCurrentRun";
            this.lblCurrentRun.Size = new System.Drawing.Size(67, 13);
            this.lblCurrentRun.TabIndex = 0;
            this.lblCurrentRun.Text = "Current Run:";
            // 
            // btnSaveBatch
            // 
            this.btnSaveBatch.Location = new System.Drawing.Point(13, 406);
            this.btnSaveBatch.Name = "btnSaveBatch";
            this.btnSaveBatch.Size = new System.Drawing.Size(108, 23);
            this.btnSaveBatch.TabIndex = 10;
            this.btnSaveBatch.Text = "Save Batch File";
            this.btnSaveBatch.UseVisualStyleBackColor = true;
            this.btnSaveBatch.Click += new System.EventHandler(this.btnSaveBatch_Click);
            // 
            // frmOptimiser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 435);
            this.Controls.Add(this.btnSaveBatch);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tabThreads);
            this.Controls.Add(this.grpProperties);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnDeleteRuns);
            this.Controls.Add(this.btnAddRun);
            this.Controls.Add(this.lstRuns);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmOptimiser";
            this.Text = "Optimiser - ENFORM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOptimiser_FormClosing);
            this.Load += new System.EventHandler(this.frmOptimisor_Load);
            this.Shown += new System.EventHandler(this.frmOptimiser_Shown);
            this.grpProperties.ResumeLayout(false);
            this.grpProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRuns)).EndInit();
            this.tabThreads.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstRuns;
        private System.Windows.Forms.Button btnAddRun;
        private System.Windows.Forms.Button btnDeleteRuns;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.ColumnHeader clmRunName;
        private System.Windows.Forms.ColumnHeader clmDone;
        private System.Windows.Forms.GroupBox grpProperties;
        private System.Windows.Forms.NumericUpDown numThreads;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numRuns;
        private System.Windows.Forms.Label lblRuns;
        private System.Windows.Forms.TabControl tabThreads;
        private System.Windows.Forms.TabPage tabFirstThread;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ColumnHeader clmFullFilename;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblCurrentRunValue;
        private System.Windows.Forms.Label lblCurrentRun;
        private System.Windows.Forms.Button btnSaveBatch;
    }
}