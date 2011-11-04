namespace ENFORM.GUI
{
    partial class frmImageTool
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
            this.lblPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.numMaxImages = new System.Windows.Forms.NumericUpDown();
            this.lblMaxImages = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNormalize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxImages)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(47, 13);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(32, 13);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Path:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(85, 10);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(358, 20);
            this.txtPath.TabIndex = 1;
            this.txtPath.Text = "S:\\Inanimate\\RoyaltyFree";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(449, 8);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // numMaxImages
            // 
            this.numMaxImages.Location = new System.Drawing.Point(85, 36);
            this.numMaxImages.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMaxImages.Name = "numMaxImages";
            this.numMaxImages.Size = new System.Drawing.Size(89, 20);
            this.numMaxImages.TabIndex = 3;
            this.numMaxImages.Value = new decimal(new int[] {
            806,
            0,
            0,
            0});
            // 
            // lblMaxImages
            // 
            this.lblMaxImages.AutoSize = true;
            this.lblMaxImages.Location = new System.Drawing.Point(12, 38);
            this.lblMaxImages.Name = "lblMaxImages";
            this.lblMaxImages.Size = new System.Drawing.Size(67, 13);
            this.lblMaxImages.TabIndex = 4;
            this.lblMaxImages.Text = "Max Images:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(15, 228);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(95, 23);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate list file";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lstLog
            // 
            this.lstLog.FormattingEnabled = true;
            this.lstLog.Location = new System.Drawing.Point(15, 62);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(515, 160);
            this.lstLog.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Fix names";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNormalize
            // 
            this.btnNormalize.Location = new System.Drawing.Point(217, 228);
            this.btnNormalize.Name = "btnNormalize";
            this.btnNormalize.Size = new System.Drawing.Size(103, 23);
            this.btnNormalize.TabIndex = 8;
            this.btnNormalize.Text = "Normalize Images";
            this.btnNormalize.UseVisualStyleBackColor = true;
            this.btnNormalize.Click += new System.EventHandler(this.btnNormalize_Click);
            // 
            // frmImageTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 266);
            this.Controls.Add(this.btnNormalize);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblMaxImages);
            this.Controls.Add(this.numMaxImages);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblPath);
            this.Name = "frmImageTool";
            this.Text = "ImageTool";
            ((System.ComponentModel.ISupportInitialize)(this.numMaxImages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.NumericUpDown numMaxImages;
        private System.Windows.Forms.Label lblMaxImages;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNormalize;
    }
}