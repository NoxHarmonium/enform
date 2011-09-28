namespace ENFORM
{
    partial class OptimisationStatus
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMeanError = new System.Windows.Forms.Label();
            this.lblMeanErrorValue = new System.Windows.Forms.Label();
            this.lblOptimisor = new System.Windows.Forms.Label();
            this.lblOptimisorValue = new System.Windows.Forms.Label();
            this.lblCurrentEpoch = new System.Windows.Forms.Label();
            this.lblCurrentEpochValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMeanError
            // 
            this.lblMeanError.AutoSize = true;
            this.lblMeanError.Location = new System.Drawing.Point(3, 59);
            this.lblMeanError.Name = "lblMeanError";
            this.lblMeanError.Size = new System.Drawing.Size(105, 13);
            this.lblMeanError.TabIndex = 0;
            this.lblMeanError.Text = "Mean Error Squared:";
            // 
            // lblMeanErrorValue
            // 
            this.lblMeanErrorValue.AutoSize = true;
            this.lblMeanErrorValue.Location = new System.Drawing.Point(114, 59);
            this.lblMeanErrorValue.Name = "lblMeanErrorValue";
            this.lblMeanErrorValue.Size = new System.Drawing.Size(27, 13);
            this.lblMeanErrorValue.TabIndex = 1;
            this.lblMeanErrorValue.Text = "N/A";
            // 
            // lblOptimisor
            // 
            this.lblOptimisor.AutoSize = true;
            this.lblOptimisor.Location = new System.Drawing.Point(55, 11);
            this.lblOptimisor.Name = "lblOptimisor";
            this.lblOptimisor.Size = new System.Drawing.Size(53, 13);
            this.lblOptimisor.TabIndex = 2;
            this.lblOptimisor.Text = "Optimiser:";
            // 
            // lblOptimisorValue
            // 
            this.lblOptimisorValue.AutoSize = true;
            this.lblOptimisorValue.Location = new System.Drawing.Point(114, 11);
            this.lblOptimisorValue.Name = "lblOptimisorValue";
            this.lblOptimisorValue.Size = new System.Drawing.Size(92, 13);
            this.lblOptimisorValue.TabIndex = 3;
            this.lblOptimisorValue.Text = "Back Propogation";
            // 
            // lblCurrentEpoch
            // 
            this.lblCurrentEpoch.AutoSize = true;
            this.lblCurrentEpoch.Location = new System.Drawing.Point(30, 34);
            this.lblCurrentEpoch.Name = "lblCurrentEpoch";
            this.lblCurrentEpoch.Size = new System.Drawing.Size(78, 13);
            this.lblCurrentEpoch.TabIndex = 4;
            this.lblCurrentEpoch.Text = "Current Epoch:";
            // 
            // lblCurrentEpochValue
            // 
            this.lblCurrentEpochValue.AutoSize = true;
            this.lblCurrentEpochValue.Location = new System.Drawing.Point(114, 34);
            this.lblCurrentEpochValue.Name = "lblCurrentEpochValue";
            this.lblCurrentEpochValue.Size = new System.Drawing.Size(27, 13);
            this.lblCurrentEpochValue.TabIndex = 5;
            this.lblCurrentEpochValue.Text = "N/A";
            // 
            // OptimisationStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCurrentEpochValue);
            this.Controls.Add(this.lblCurrentEpoch);
            this.Controls.Add(this.lblOptimisorValue);
            this.Controls.Add(this.lblOptimisor);
            this.Controls.Add(this.lblMeanErrorValue);
            this.Controls.Add(this.lblMeanError);
            this.Name = "OptimisationStatus";
            this.Size = new System.Drawing.Size(304, 361);
            this.Load += new System.EventHandler(this.OptimisationStatus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMeanError;
        private System.Windows.Forms.Label lblMeanErrorValue;
        private System.Windows.Forms.Label lblOptimisor;
        private System.Windows.Forms.Label lblOptimisorValue;
        private System.Windows.Forms.Label lblCurrentEpoch;
        private System.Windows.Forms.Label lblCurrentEpochValue;
    }
}
