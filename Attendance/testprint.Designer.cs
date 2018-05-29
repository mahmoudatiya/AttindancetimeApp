namespace Attendance
{
    partial class testprint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(testprint));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.attendanceTimeDataSet = new Attendance.AttendanceTimeDataSet();
            this.checkInBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkInTableAdapter = new Attendance.AttendanceTimeDataSetTableAdapters.CheckInTableAdapter();
            this.btnprintdoc = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.checkInIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fingerPrintIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkInDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationNaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceTimeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkInBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // attendanceTimeDataSet
            // 
            this.attendanceTimeDataSet.DataSetName = "AttendanceTimeDataSet";
            this.attendanceTimeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // checkInBindingSource
            // 
            this.checkInBindingSource.DataMember = "CheckIn";
            this.checkInBindingSource.DataSource = this.attendanceTimeDataSet;
            // 
            // checkInTableAdapter
            // 
            this.checkInTableAdapter.ClearBeforeFill = true;
            // 
            // btnprintdoc
            // 
            this.btnprintdoc.Location = new System.Drawing.Point(545, 491);
            this.btnprintdoc.Name = "btnprintdoc";
            this.btnprintdoc.Size = new System.Drawing.Size(75, 23);
            this.btnprintdoc.TabIndex = 1;
            this.btnprintdoc.Text = "print";
            this.btnprintdoc.UseVisualStyleBackColor = true;
            this.btnprintdoc.Click += new System.EventHandler(this.btnprintdoc_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.reportViewer1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(41, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 447);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkInIDDataGridViewTextBoxColumn,
            this.fingerPrintIDDataGridViewTextBoxColumn,
            this.employeeIDDataGridViewTextBoxColumn,
            this.checkInDataGridViewTextBoxColumn,
            this.monthDataGridViewTextBoxColumn,
            this.date1DataGridViewTextBoxColumn,
            this.locationNaDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.checkInBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(773, 219);
            this.dataGridView1.TabIndex = 1;
            // 
            // checkInIDDataGridViewTextBoxColumn
            // 
            this.checkInIDDataGridViewTextBoxColumn.DataPropertyName = "CheckInID";
            this.checkInIDDataGridViewTextBoxColumn.HeaderText = "CheckInID";
            this.checkInIDDataGridViewTextBoxColumn.Name = "checkInIDDataGridViewTextBoxColumn";
            this.checkInIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fingerPrintIDDataGridViewTextBoxColumn
            // 
            this.fingerPrintIDDataGridViewTextBoxColumn.DataPropertyName = "FingerPrintID";
            this.fingerPrintIDDataGridViewTextBoxColumn.HeaderText = "FingerPrintID";
            this.fingerPrintIDDataGridViewTextBoxColumn.Name = "fingerPrintIDDataGridViewTextBoxColumn";
            // 
            // employeeIDDataGridViewTextBoxColumn
            // 
            this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "EmployeeID";
            this.employeeIDDataGridViewTextBoxColumn.HeaderText = "EmployeeID";
            this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
            // 
            // checkInDataGridViewTextBoxColumn
            // 
            this.checkInDataGridViewTextBoxColumn.DataPropertyName = "CheckIn";
            this.checkInDataGridViewTextBoxColumn.HeaderText = "CheckIn";
            this.checkInDataGridViewTextBoxColumn.Name = "checkInDataGridViewTextBoxColumn";
            // 
            // monthDataGridViewTextBoxColumn
            // 
            this.monthDataGridViewTextBoxColumn.DataPropertyName = "Month";
            this.monthDataGridViewTextBoxColumn.HeaderText = "Month";
            this.monthDataGridViewTextBoxColumn.Name = "monthDataGridViewTextBoxColumn";
            // 
            // date1DataGridViewTextBoxColumn
            // 
            this.date1DataGridViewTextBoxColumn.DataPropertyName = "Date1";
            this.date1DataGridViewTextBoxColumn.HeaderText = "Date1";
            this.date1DataGridViewTextBoxColumn.Name = "date1DataGridViewTextBoxColumn";
            // 
            // locationNaDataGridViewTextBoxColumn
            // 
            this.locationNaDataGridViewTextBoxColumn.DataPropertyName = "LocationNa";
            this.locationNaDataGridViewTextBoxColumn.HeaderText = "LocationNa";
            this.locationNaDataGridViewTextBoxColumn.Name = "locationNaDataGridViewTextBoxColumn";
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.checkInBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Attendance.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(68, 258);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(643, 183);
            this.reportViewer1.TabIndex = 2;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load_1);
            // 
            // testprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 542);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnprintdoc);
            this.Name = "testprint";
            this.Text = "testprint";
            this.Load += new System.EventHandler(this.testprint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.attendanceTimeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkInBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintDialog printDialog1;
        private AttendanceTimeDataSet attendanceTimeDataSet;
        private System.Windows.Forms.BindingSource checkInBindingSource;
        private AttendanceTimeDataSetTableAdapters.CheckInTableAdapter checkInTableAdapter;
        private System.Windows.Forms.Button btnprintdoc;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkInIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fingerPrintIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkInDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn date1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationNaDataGridViewTextBoxColumn;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}