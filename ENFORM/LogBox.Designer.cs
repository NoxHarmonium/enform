namespace ENFORM.GUI
{
    partial class frmLogBox
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
            this.txtLogBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtLogBox
            // 
            this.txtLogBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogBox.Location = new System.Drawing.Point(12, 12);
            this.txtLogBox.Multiline = true;
            this.txtLogBox.Name = "txtLogBox";
            this.txtLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogBox.Size = new System.Drawing.Size(855, 238);
            this.txtLogBox.TabIndex = 0;
            // 
            // frmLogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 262);
            this.Controls.Add(this.txtLogBox);
            this.Name = "frmLogBox";
            this.Text = "ENFORM Log";
            this.Load += new System.EventHandler(this.LogBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogBox;
    }
}