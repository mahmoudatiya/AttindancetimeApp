using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance
{
    public partial class testreport : Form
    {
        public testreport()
        {
            InitializeComponent();

        }

        private void testreport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'AttendanceTimeDataSet.CheckIn' table. You can move, or remove it, as needed.
            this.CheckInTableAdapter.Fill(this.AttendanceTimeDataSet.CheckIn);

            this.reportViewer3.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt;
            SqlConnection Con = new SqlConnection(@"Server=.\SQLEXPRESS; Database=AttendanceTime; Integrated Security=True");
            Con.Open();
            using (SqlCommand cmd2 = new SqlCommand("Select CheckInID, CheckIn, LocationNa from CheckIn ", Con))
            {
                
                cmd2.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                 dt = new DataTable();
                da.Fill(dt);
            }
            Con.Close();
            reportViewer1.Visible = true;
            reportViewer1.LocalReport.ReportPath = "Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            crystalReportViewer1.ReportSource = dt;
            crystalReportViewer1.Refresh();

        }
    }
}
