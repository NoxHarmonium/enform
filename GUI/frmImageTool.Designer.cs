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
            this.SuspendLayout();
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(13, 13);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(32, 13);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Path:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(51, 10);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(392, 20);
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
            // ImageTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 458);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblPath);
            this.Name = "ImageTool";
            this.Text = "ImageTool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBrowse;
    }
}