namespace ENFORM.GUI
{
    partial class frmResultsAnalyser
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
            this.btnDeleteRuns = new System.Windows.Forms.Button();
            this.btnAddRun = new System.Windows.Forms.Button();
            this.lstRuns = new System.Windows.Forms.ListView();
            this.clmRunName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFullFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnProcess = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDeleteRuns
            // 
            this.btnDeleteRuns.Location = new System.Drawing.Point(127, 376);
            this.btnDeleteRuns.Name = "btnDeleteRuns";
            this.btnDeleteRuns.Size = new System.Drawing.Size(117, 23);
            this.btnDeleteRuns.TabIndex = 5;
            this.btnDeleteRuns.Text = "Remove";
            this.btnDeleteRuns.UseVisualStyleBackColor = true;
            // 
            // btnAddRun
            // 
            this.btnAddRun.Location = new System.Drawing.Point(12, 376);
            this.btnAddRun.Name = "btnAddRun";
            this.btnAddRun.Size = new System.Drawing.Size(109, 23);
            this.btnAddRun.TabIndex = 4;
            this.btnAddRun.Text = "Add ";
            this.btnAddRun.UseVisualStyleBackColor = true;
            this.btnAddRun.Click += new System.EventHandler(this.btnAddRun_Click);
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
            this.lstRuns.TabIndex = 3;
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
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(264, 12);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 6;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(376, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmResultsAnalyser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 438);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnDeleteRuns);
            this.Controls.Add(this.btnAddRun);
            this.Controls.Add(this.lstRuns);
            this.Name = "frmResultsAnalyser";
            this.Text = "ResultsAnalyser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteRuns;
        private System.Windows.Forms.Button btnAddRun;
        private System.Windows.Forms.ListView lstRuns;
        private System.Windows.Forms.ColumnHeader clmRunName;
        private System.Windows.Forms.ColumnHeader clmDone;
        private System.Windows.Forms.ColumnHeader clmFullFilename;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button button1;

    }
}