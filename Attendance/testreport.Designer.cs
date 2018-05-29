namespace Attendance
{
    partial class testreport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.CheckInBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AttendanceTimeDataSet = new Attendance.AttendanceTimeDataSet();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CheckInTableAdapter = new Attendance.AttendanceTimeDataSetTableAdapters.CheckInTableAdapter();
            this.attendanceTimeDataSet1 = new Attendance.AttendanceTimeDataSet();
            this.button1 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReport11 = new Attendance.CrystalReport1();
            ((System.ComponentModel.ISupportInitialize)(this.CheckInBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceTimeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceTimeDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // CheckInBindingSource
            // 
            this.CheckInBindingSource.DataMember = "CheckIn";
            this.CheckInBindingSource.DataSource = this.AttendanceTimeDataSet;
            // 
            // AttendanceTimeDataSet
            // 
            this.AttendanceTimeDataSet.DataSetName = "AttendanceTimeDataSet";
            this.AttendanceTimeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer3
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.CheckInBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "Attendance.Report1.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(12, 12);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.Size = new System.Drawing.Size(785, 112);
            this.reportViewer3.TabIndex = 0;
            this.reportViewer3.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // CheckInTableAdapter
            // 
            this.CheckInTableAdapter.ClearBeforeFill = true;
            // 
            // attendanceTimeDataSet1
            // 
            this.attendanceTimeDataSet1.DataSetName = "AttendanceTimeDataSet";
            this.attendanceTimeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(644, 480);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(155, 150);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(306, 57);
            this.reportViewer1.TabIndex = 2;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(117, 213);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.CrystalReport11;
            this.crystalReportViewer1.Size = new System.Drawing.Size(548, 243);
            this.crystalReportViewer1.TabIndex = 3;
            // 
            // testreport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 515);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer3);
            this.Name = "testreport";
            this.Text = "testreport";
            this.Load += new System.EventHandler(this.testreport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CheckInBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceTimeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceTimeDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private System.Windows.Forms.BindingSource CheckInBindingSource;
        private AttendanceTimeDataSet AttendanceTimeDataSet;
        private AttendanceTimeDataSetTableAdapters.CheckInTableAdapter CheckInTableAdapter;
        private AttendanceTimeDataSet attendanceTimeDataSet1;
        private System.Windows.Forms.Button button1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalReport1 CrystalReport11;
    }
}