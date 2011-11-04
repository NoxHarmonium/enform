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
            this.facesTableAdapter = new ENFORM.GUI.feretDataSetTableAdapters.facesTableAdapter();
            this.imageViewer1 = new ENFORM.GUI.ImageViewer();
            this.lstInfo = new System.Windows.Forms.ListView();
            this.clmKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnLoadData = new System.Windows.Forms.Button();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.lblQuery = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.subjectidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trainingsetDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.testingsetDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.selectedIndexBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.selectedSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.selectedSet = new ENFORM.GUI.selectedSet();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lblToolStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSaveSetList = new System.Windows.Forms.Button();
            this.btnSelectAlternate = new System.Windows.Forms.Button();
            this.btnSelectNone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.feretDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedIndexBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedSet)).BeginInit();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // feretDataSet
            // 
            this.feretDataSet.DataSetName = "feretDataSet";
            this.feretDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // facesTableAdapter
            // 
            this.facesTableAdapter.ClearBeforeFill = true;
            // 
            // imageViewer1
            // 
            this.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewer1.DrawingColour = System.Drawing.Color.Black;
            this.imageViewer1.Location = new System.Drawing.Point(356, 12);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.ScalingMethod = ENFORM.Core.ScalingMethods.Nearest_Neighbor;
            this.imageViewer1.Size = new System.Drawing.Size(258, 360);
            this.imageViewer1.TabIndex = 1;
            // 
            // lstInfo
            // 
            this.lstInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmKey,
            this.clmValue});
            this.lstInfo.Location = new System.Drawing.Point(165, 12);
            this.lstInfo.Name = "lstInfo";
            this.lstInfo.Size = new System.Drawing.Size(185, 457);
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
            this.btnLoadData.Location = new System.Drawing.Point(12, 514);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 5;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(56, 488);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(477, 20);
            this.txtQuery.TabIndex = 6;
            this.txtQuery.TextChanged += new System.EventHandler(this.txtQuery_TextChanged);
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.Location = new System.Drawing.Point(12, 491);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(38, 13);
            this.lblQuery.TabIndex = 7;
            this.lblQuery.Text = "Query:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.subjectidDataGridViewTextBoxColumn,
            this.trainingsetDataGridViewCheckBoxColumn,
            this.testingsetDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.selectedIndexBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(147, 457);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // subjectidDataGridViewTextBoxColumn
            // 
            this.subjectidDataGridViewTextBoxColumn.DataPropertyName = "subjectid";
            this.subjectidDataGridViewTextBoxColumn.HeaderText = "ID";
            this.subjectidDataGridViewTextBoxColumn.Name = "subjectidDataGridViewTextBoxColumn";
            this.subjectidDataGridViewTextBoxColumn.ReadOnly = true;
            this.subjectidDataGridViewTextBoxColumn.Width = 30;
            // 
            // trainingsetDataGridViewCheckBoxColumn
            // 
            this.trainingsetDataGridViewCheckBoxColumn.DataPropertyName = "trainingset";
            this.trainingsetDataGridViewCheckBoxColumn.HeaderText = "tRs";
            this.trainingsetDataGridViewCheckBoxColumn.Name = "trainingsetDataGridViewCheckBoxColumn";
            this.trainingsetDataGridViewCheckBoxColumn.Width = 30;
            // 
            // testingsetDataGridViewCheckBoxColumn
            // 
            this.testingsetDataGridViewCheckBoxColumn.DataPropertyName = "testingset";
            this.testingsetDataGridViewCheckBoxColumn.HeaderText = "tEs";
            this.testingsetDataGridViewCheckBoxColumn.Name = "testingsetDataGridViewCheckBoxColumn";
            this.testingsetDataGridViewCheckBoxColumn.Width = 30;
            // 
            // selectedIndexBindingSource
            // 
            this.selectedIndexBindingSource.DataMember = "SelectedIndex";
            this.selectedIndexBindingSource.DataSource = this.selectedSetBindingSource;
            // 
            // selectedSetBindingSource
            // 
            this.selectedSetBindingSource.AllowNew = true;
            this.selectedSetBindingSource.DataSource = this.selectedSet;
            this.selectedSetBindingSource.Position = 0;
            // 
            // selectedSet
            // 
            this.selectedSet.DataSetName = "selectedSet";
            this.selectedSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblToolStrip});
            this.statusBar.Location = new System.Drawing.Point(0, 546);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(621, 22);
            this.statusBar.TabIndex = 9;
            this.statusBar.Text = "statusStrip1";
            // 
            // lblToolStrip
            // 
            this.lblToolStrip.Name = "lblToolStrip";
            this.lblToolStrip.Size = new System.Drawing.Size(118, 17);
            this.lblToolStrip.Text = "toolStripStatusLabel1";
            // 
            // btnSaveSetList
            // 
            this.btnSaveSetList.Location = new System.Drawing.Point(93, 514);
            this.btnSaveSetList.Name = "btnSaveSetList";
            this.btnSaveSetList.Size = new System.Drawing.Size(100, 23);
            this.btnSaveSetList.TabIndex = 10;
            this.btnSaveSetList.Text = "Save Set List";
            this.btnSaveSetList.UseVisualStyleBackColor = true;
            this.btnSaveSetList.Click += new System.EventHandler(this.btnSaveSetList_Click);
            // 
            // btnSelectAlternate
            // 
            this.btnSelectAlternate.Location = new System.Drawing.Point(199, 514);
            this.btnSelectAlternate.Name = "btnSelectAlternate";
            this.btnSelectAlternate.Size = new System.Drawing.Size(100, 23);
            this.btnSelectAlternate.TabIndex = 11;
            this.btnSelectAlternate.Text = "Select Alternate";
            this.btnSelectAlternate.UseVisualStyleBackColor = true;
            this.btnSelectAlternate.Click += new System.EventHandler(this.btnSelectAlternate_Click);
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Location = new System.Drawing.Point(305, 514);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(100, 23);
            this.btnSelectNone.TabIndex = 12;
            this.btnSelectNone.Text = "Select None";
            this.btnSelectNone.UseVisualStyleBackColor = true;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // frmFeretExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 568);
            this.Controls.Add(this.btnSelectNone);
            this.Controls.Add(this.btnSelectAlternate);
            this.Controls.Add(this.btnSaveSetList);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblQuery);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.lstInfo);
            this.Controls.Add(this.imageViewer1);
            this.Name = "frmFeretExplorer";
            this.Text = "frmFeretExplorer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFeretExplorer_FormClosing);
            this.Load += new System.EventHandler(this.frmFeretExplorer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.feretDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedIndexBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedSet)).EndInit();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private feretDataSet feretDataSet;
        private feretDataSetTableAdapters.facesTableAdapter facesTableAdapter;
        private ImageViewer imageViewer1;
        private System.Windows.Forms.ListView lstInfo;
        private System.Windows.Forms.ColumnHeader clmKey;
        private System.Windows.Forms.ColumnHeader clmValue;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Label lblQuery;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource selectedSetBindingSource;
        private selectedSet selectedSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn trainingsetDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn testingsetDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource selectedIndexBindingSource;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel lblToolStrip;
        private System.Windows.Forms.Button btnSaveSetList;
        private System.Windows.Forms.Button btnSelectAlternate;
        private System.Windows.Forms.Button btnSelectNone;
    }
}