namespace ENFORM
{
    partial class frmMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnRunEditor = new System.Windows.Forms.Button();
            this.btnLaunchOptimiser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(10, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(130, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ENFORM";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.Location = new System.Drawing.Point(14, 46);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(485, 16);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Experimental Neural Facial recognition Optimisation Reporting and Management";
            // 
            // btnRunEditor
            // 
            this.btnRunEditor.Image = ((System.Drawing.Image)(resources.GetObject("btnRunEditor.Image")));
            this.btnRunEditor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunEditor.Location = new System.Drawing.Point(12, 84);
            this.btnRunEditor.Name = "btnRunEditor";
            this.btnRunEditor.Size = new System.Drawing.Size(220, 61);
            this.btnRunEditor.TabIndex = 2;
            this.btnRunEditor.Text = "Launch Run Editor";
            this.btnRunEditor.UseVisualStyleBackColor = true;
            this.btnRunEditor.Click += new System.EventHandler(this.btnRunEditor_Click);
            // 
            // btnLaunchOptimiser
            // 
            this.btnLaunchOptimiser.Image = ((System.Drawing.Image)(resources.GetObject("btnLaunchOptimiser.Image")));
            this.btnLaunchOptimiser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLaunchOptimiser.Location = new System.Drawing.Point(12, 151);
            this.btnLaunchOptimiser.Name = "btnLaunchOptimiser";
            this.btnLaunchOptimiser.Size = new System.Drawing.Size(220, 61);
            this.btnLaunchOptimiser.TabIndex = 3;
            this.btnLaunchOptimiser.Text = "Launch Optimiser";
            this.btnLaunchOptimiser.UseVisualStyleBackColor = true;
            this.btnLaunchOptimiser.Click += new System.EventHandler(this.btnLaunchOptimiser_Click);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 429);
            this.Controls.Add(this.btnLaunchOptimiser);
            this.Controls.Add(this.btnRunEditor);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmMainMenu";
            this.Text = "Main Menu - ENFORM";
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnRunEditor;
        private System.Windows.Forms.Button btnLaunchOptimiser;
    }
}