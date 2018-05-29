using DGVPrinterHelper;
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
    public partial class testprint : Form
    {
        SqlConnection Con = new SqlConnection(@"Server=.\SQLEXPRESS; Database=AttendanceTime; Integrated Security=True");
        public testprint()
        {
            InitializeComponent();
            Con.Open();
            DataTable dt = new DataTable();
            using (SqlCommand cmd2 = new SqlCommand("Select CheckInID, CheckIn, LocationNa from CheckIn  ", Con))
            {


                cmd2.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                dt = new DataTable();
                da.Fill(dt);
            }
            Con.Close();

            reportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportDataSource source = new ReportDataSource("SampleDs", dt);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(source);
            //  reportViewer1.DataBindings();
            reportViewer1.LocalReport.Refresh();
        }

        private void testprint_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'attendanceTimeDataSet.CheckIn' table. You can move, or remove it, as needed.
            this.checkInTableAdapter.Fill(this.attendanceTimeDataSet.CheckIn);
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
            //e.Graphics.DrawImage(bmp, 0, 0);
            
        }
        Bitmap bmp;
        private void btnprintdoc_Click(object sender, EventArgs e)
        {
            //int height = dataGridView1.Height;
            //dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            //bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            //dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            //dataGridView1.Height = height; 

            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height;

            //Create a Bitmap and draw the DataGridView on it.
            bmp = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));

            //Resize DataGridView back to original height.
            dataGridView1.Height = height;

            //Show the Print Preview Dialog.
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();



        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {
           
        }
    }
}
