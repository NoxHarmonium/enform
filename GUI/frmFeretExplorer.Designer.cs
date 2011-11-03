namespace ENFORM.GUI
{
    partial class frmFeretExplorer
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
            this.components = new System.ComponentModel.Container();
            this.feretDataSet = new ENFORM.GUI.feretDataSet();
            this.facesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facesTableAdapter = new ENFORM.GUI.feretDataSetTableAdapters.facesTableAdapter();
            this.imageViewer1 = new ENFORM.GUI.ImageViewer();
            this.lstSelect = new System.Windows.Forms.ListView();
            this.clmFaceID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmSelected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstInfo = new System.Windows.Forms.ListView();
            this.clmKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnLoadData = new System.Windows.Forms.Button();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.lblQuery = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.feretDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // feretDataSet
            // 
            this.feretDataSet.DataSetName = "feretDataSet";
            this.feretDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // facesBindingSource
            // 
            this.facesBindingSource.DataMember = "faces";
            this.facesBindingSource.DataSource = this.feretDataSet;
            this.facesBindingSource.CurrentChanged += new System.EventHandler(this.facesBindingSource_CurrentChanged);
            // 
            // facesTableAdapter
            // 
            this.facesTableAdapter.ClearBeforeFill = true;
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.DrawingColour = System.Drawing.Color.Black;
            this.imageViewer1.Location = new System.Drawing.Point(343, 10);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.ScalingMethod = ENFORM.Core.ScalingMethods.Nearest_Neighbor;
            this.imageViewer1.Size = new System.Drawing.Size(258, 334);
            this.imageViewer1.TabIndex = 1;
            // 
            // lstSelect
            // 
            this.lstSelect.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmFaceID,
            this.clmSelected});
            this.lstSelect.Location = new System.Drawing.Point(12, 12);
            this.lstSelect.Name = "lstSelect";
            this.lstSelect.Size = new System.Drawing.Size(134, 332);
            this.lstSelect.TabIndex = 3;
            this.lstSelect.UseCompatibleStateImageBehavior = false;
            this.lstSelect.View = System.Windows.Forms.View.Details;
            // 
            // clmFaceID
            // 
            this.clmFaceID.Text = "ID";
            // 
            // clmSelected
            // 
            this.clmSelected.Text = " ";
            // 
            // lstInfo
            // 
            this.lstInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmKey,
            this.clmValue});
            this.lstInfo.Location = new System.Drawing.Point(152, 12);
            this.lstInfo.Name = "lstInfo";
            this.lstInfo.Size = new System.Drawing.Size(185, 332);
            this.lstInfo.TabIndex = 4;
            this.lstInfo.UseCompatibleStateImageBehavior = false;
            this.lstInfo.View = System.Windows.Forms.View.Details;
            // 
            // clmKey
            // 
            this.clmKey.Text = "Key";
            // 
            // clmValue
            // 
            this.clmValue.Text = "Value";
            this.clmValue.Width = 115;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(12, 451);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 5;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(56, 355);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(477, 20);
            this.txtQuery.TabIndex = 6;
            this.txtQuery.TextChanged += new System.EventHandler(this.txtQuery_TextChanged);
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.Location = new System.Drawing.Point(12, 358);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(38, 13);
            this.lblQuery.TabIndex = 7;
            this.lblQuery.Text = "Query:";
            // 
            // frmFeretExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 486);
            this.Controls.Add(this.lblQuery);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.lstInfo);
            this.Controls.Add(this.lstSelect);
            this.Controls.Add(this.imageViewer1);
            this.Name = "frmFeretExplorer";
            this.Text = "frmFeretExplorer";
            this.Load += new System.EventHandler(this.frmFeretExplorer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.feretDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private feretDataSet feretDataSet;
        private System.Windows.Forms.BindingSource facesBindingSource;
        private feretDataSetTableAdapters.facesTableAdapter facesTableAdapter;
        private ImageViewer imageViewer1;
        private System.Windows.Forms.ListView lstSelect;
        private System.Windows.Forms.ColumnHeader clmFaceID;
        private System.Windows.Forms.ColumnHeader clmSelected;
        private System.Windows.Forms.ListView lstInfo;
        private System.Windows.Forms.ColumnHeader clmKey;
        private System.Windows.Forms.ColumnHeader clmValue;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Label lblQuery;
    }
}