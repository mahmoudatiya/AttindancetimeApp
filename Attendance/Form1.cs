using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using DGVPrinterHelper;

namespace Attendance
{
    public partial class Form1 : Form
    {
        SqlConnection Con = new SqlConnection(@"Server=development; Database=AttendanceTime; Integrated Security=True");
        SqlDataAdapter Da;
        DataTable Dt = new DataTable();
        SqlCommand Cmd;
        string _userName;
        public Form1(string username)
        {
            InitializeComponent();
            _userName = username;
            string userType;
            Con.Open();

            using (Cmd = new SqlCommand("select Type from Users where UserName = @UserName ", Con))
            {
                Cmd.Parameters.AddWithValue("UserName", _userName);
                try
                {
                    Con.Open();
                    userType = (string)Cmd.ExecuteScalar();
                    if (userType != "admin")
                    {
                        tabPage1.Enabled = false;
                        tabPage2.Enabled = false;
                        tabPage3.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Con.Close();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String EmployeeName, Address;
            int EmployeeNumber, Location, ContractType, CardNumber;
            DateTime BirthDate, StartDate;
            Location = int.Parse(cobLocation.SelectedValue.ToString());
            ContractType = int.Parse(cobContractType.SelectedValue.ToString());
            EmployeeName = txtEmployeeName.Text;
            // Mobile = 0568066633;
            Address = txtAddress.Text;
            CardNumber = int.Parse(txtCardNumber.Text);
            //  EmployeeNumber = int.Parse(txtEmployeeNumber.Text);

            BirthDate = dtpBirthDate.Value;
            StartDate = dtpStartDate.Value;
            EmployeeNumber = 1230613;
            try
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO [Employee] values (@EmployeeID, @EmployeeName, @Mobile, @ContractID, @LocationID, @BirthDate, @StartDate, @Address, @EmployeeIdentity, @CardNumber)", Con))
                {
                    cmd.Parameters.AddWithValue("EmployeeID", EmployeeNumber);
                    cmd.Parameters.AddWithValue("EmployeeName", EmployeeName);
                    cmd.Parameters.AddWithValue("Mobile", txtMobilen.Text);
                    cmd.Parameters.AddWithValue("ContractID", ContractType);
                    cmd.Parameters.AddWithValue("LocationID", Location);
                    cmd.Parameters.AddWithValue("BirthDate", BirthDate);
                    cmd.Parameters.AddWithValue("StartDate", StartDate);
                    cmd.Parameters.AddWithValue("Address", Address);
                    cmd.Parameters.AddWithValue("EmployeeIdentity", txtEmployeeIdentity.Text);
                    cmd.Parameters.AddWithValue("CardNumber", CardNumber);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تمت الاضافه بنجاح !", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Some Error Occured !" + ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1;
            bool existsl = false;
            Con.Open();
            using (cmd1 = new SqlCommand("select count(*) from [Location] where LocationName = @LocationName", Con))
            {
                cmd1.Parameters.AddWithValue("LocationName", txtLocationName.Text);
                existsl = (int)cmd1.ExecuteScalar() > 0;
            }

            if (existsl == true)
            {
                MessageBox.Show(txtUserName.Text, "هذا الموقع موجود بالفعل.");
                Con.Close();
            }
            else
            {
                try
                {
                    //  Con.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO [Location] values (@LocationName)", Con))
                    {
                        cmd.Parameters.AddWithValue("LocationName", txtLocationName.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تمت الاضافة بنجاح !", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Con.Close();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Some Error Occure   d !" + ex.Message);
                }
                finally
                {
                    Con.Close();
                }
                txtLocationName.Clear();
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            string userName = txtUserName.Text;
            bool exists = false;
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    Con.Open();
                    using (SqlCommand cmd = new SqlCommand("select count(*) from [Users] where UserName = @UserName", Con))
                    {
                        cmd.Parameters.AddWithValue("UserName", txtUserName.Text);
                        exists = (int)cmd.ExecuteScalar() > 0;
                    }

                    if (exists)
                    {
                        MessageBox.Show(txtUserName.Text, "هذا المستخدم موجود بالفعل.");
                        Con.Close();
                    }
                    else
                    {
                        // does not exists, so, persist the user
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO [Users] values (@UserName, @Email, @Password, @Mobile, @Type)", Con))
                        {
                            cmd.Parameters.AddWithValue("UserName", txtUserName.Text);
                            cmd.Parameters.AddWithValue("Email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("Password", txtPassword.Text);
                            cmd.Parameters.AddWithValue("Mobile", txtMobile.Text);
                            cmd.Parameters.AddWithValue("Type", txtUserType.Text);


                            cmd.ExecuteNonQuery();
                            MessageBox.Show("تمت الاضافة بنجاح !", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    //try
                    //{
                    //    Cmd = new SqlCommand("Insert into Users(UserName, Email, Password, Mobile, Type) values('" + txtUserName.Text + "', '" + txtEmail.Text + "','" + txtPassword.Text + "', '" + txtMobile.Text + "', '" + txtUserType.Text + "')", Con);
                    //    Con.Open();
                    //    Cmd.ExecuteNonQuery();
                    //    MessageBox.Show("Added Successfully !", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    Con.Close();
                    //}
                    //catch (SqlException ex)
                    //{
                    //    MessageBox.Show("Some Error Occured !" + ex.Message);
                    //}
                    //finally
                    //{
                    //    Con.Close();
                    //}
                    Con.Close();
                }
                else
                {
                    MessageBox.Show("Invalid email address");
                }
            }
            else
            {
                MessageBox.Show("Invalid email address");

            }
        }

        private void btnLoadRecords_Click(object sender, EventArgs e)
        {
            int EmpId;
            DateTime Todate, Fromdate;
            EmpId = int.Parse(cobEmaployeeNameReport.SelectedValue.ToString());
            Fromdate = dtpFromDate.Value;
            Todate = dtpToDate.Value;
            if (Todate < Fromdate)
            {
                MessageBox.Show("الرجاء ادخل التاريخ اقل");
            }
            else
            {
                SqlCommand cmd1;
                Con.Open();
                //"select * from [calc2] where EmployeeID = @EmployeeID and CheckIn BETWEEN @Fromdate AND @Todate"
                using (cmd1 = new SqlCommand("select * from [calcula] where EmployeeID = @EmployeeID and FirstIn BETWEEN @Fromdate AND @Todate", Con))
                {
                    cmd1.Parameters.AddWithValue("EmployeeID", EmpId);
                    cmd1.Parameters.AddWithValue("Fromdate", Fromdate);
                    cmd1.Parameters.AddWithValue("Todate", Todate);
                    cmd1.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);


                    dgvReport.DataSource = dt;
                    dgvReport.Columns[0].HeaderCell.Value = "وقت الدخول";
                    dgvReport.Columns[1].HeaderCell.Value = "وقت الخروج";
                    dgvReport.Columns[2].HeaderCell.Value = "عدد ساعات الدوام";
                    dgvReport.Columns[3].HeaderCell.Value = "رقم الموظف";
                    dgvReport.Columns[4].HeaderCell.Value = "مكان العمل";
                    dgvReport.Columns[5].HeaderCell.Value = "الشهر";

                }
                Con.Close();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export(dgvReport);

        }
        public void Export(DataGridView dgv)
        {
            Microsoft.Office.Interop.Excel._Application App = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workBook = App.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet workSheet = null;
            workSheet = workBook.Sheets["Sheet1"];
            workSheet = workBook.ActiveSheet;
            workSheet.Name = "Location Details";
            App.Columns.ColumnWidth = 20;
            for (int i = 1; i < dgv.Columns.Count + 1; i++)
            {
                workSheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
            }
            for (int i = 1; i < dgv.Rows.Count; i++)
            {
                for (int j = 1; j < dgv.Columns.Count; j++)
                {
                    workSheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                }
            }
            var saveFiledialog = new SaveFileDialog();
            saveFiledialog.FileName = "outbut";
            saveFiledialog.DefaultExt = ".xlsx";
            if (saveFiledialog.ShowDialog() == DialogResult.OK)
            {
                workBook.SaveAs(saveFiledialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            App.Quit();
        }

        private void cobEmployeeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd1, cmd2;
            bool exists = false;
            int EId = int.Parse(cobEmployeeName.SelectedValue.ToString());
            Con.Open();

            using (cmd1 = new SqlCommand("select count(*) from [Vacations] where EmployeeID = @EmployeeID", Con))
            {
                cmd1.Parameters.AddWithValue("EmployeeID", EId);
                exists = (int)cmd1.ExecuteScalar() > 0;
            }
            
            if (exists == false)
            {
                MessageBox.Show(txtUserName.Text, "هذا الموظف ليس لديه اجازات.");
                Con.Close();
            }
            else
            {
                using (cmd2 = new SqlCommand("Select * from Vacations where EmployeeID = @EmployeeID", Con))
                {
                    cmd2.Parameters.AddWithValue("EmployeeID", EId);
                    cmd2.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);   
                    dgvVacations.DataSource = dt;
                }
                //  SqlDataAdapter da = new SqlDataAdapter("Select * from Vacations where EmployeeID = @EmployeeID ", Con);
                //DataTable dt = new DataTable();
                //da.Fill(dt);
                //dgvVacations .DataSource = dt;
                Con.Close();
            }
        }

        private void cobEmployeeNameLeaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SqlCommand cmd1, cmd2;
            //bool exists = false;
            //int EId = int.Parse(cobEmployeeNameLeaves.SelectedValue.ToString());
            //Con.Open();
            //using (cmd1 = new SqlCommand("select count(*) from [Leaves] where EmployeeID = @EmployeeID", Con))
            //{
            //    cmd1.Parameters.AddWithValue("EmployeeID", EId);
            //    exists = (int)cmd1.ExecuteScalar() > 0;
            //}

            //if (exists == false)
            //{
            //    MessageBox.Show(txtUserName.Text, "هذا الموظف ليس لديه مغادرات.");
            //    Con.Close();
            //}
            //else
            //{
            //    using (cmd2 = new SqlCommand("Select * from Leaves where EmployeeID = @EmployeeID", Con))
            //    {
            //        cmd2.Parameters.AddWithValue("EmployeeID", EId);
            //        cmd2.ExecuteNonQuery();
            //        SqlDataAdapter da = new SqlDataAdapter(cmd2);
            //        DataTable dt = new DataTable();
            //        da.Fill(dt);
            //        dgvLeaves.DataSource = dt;
            //    }

            //    Con.Close();
            //}
        }
    
        private void btnLoadRecordsLocation_Click(object sender, EventArgs e)
        {
            string LocationNa;
            bool exists = false;
            DateTime Todate, Fromdate;
            LocationNa = cobLocationworkReort.SelectedValue.ToString();
            Fromdate = dtpFromlocation.Value;
            Todate = dtpTolocation.Value;
            //using (cmd1 = new SqlCommand("select * from [calc3] where LocationNa = @LocationNa and CheckIn BETWEEN @Fromdate AND @Todate", Con))
            //{
            //    Con.Open();
            //    cmd1.Parameters.AddWithValue("Fromdate", Fromdate);
            //    cmd1.Parameters.AddWithValue("Todate", Todate);
            //    cmd1.Parameters.AddWithValue("LocationNa", LocationNa);
            //    exists = (int)cmd1.ExecuteScalar() > 0;
            //}

            //if (exists == false)
            //{
            //    MessageBox.Show(txtUserName.Text, "لا يوجد سجل دوام.");
            //    Con.Close();
            //}
            //else
            //{
            if (Todate < Fromdate)
            {
                MessageBox.Show("الرجاء ادخل التاريخ اقل");
            }
            else
            {
                SqlCommand cmd1;
                Con.Open();
                //"select * from [calc2] where EmployeeID = @EmployeeID and CheckIn BETWEEN @Fromdate AND @Todate"
                using (cmd1 = new SqlCommand("select * from [calc3] where LocationNa = @LocationNa and CheckIn BETWEEN @Fromdate AND @Todate", Con))
                {
                    cmd1.Parameters.AddWithValue("LocationNa", LocationNa);
                    cmd1.Parameters.AddWithValue("Fromdate", Fromdate);
                    cmd1.Parameters.AddWithValue("Todate", Todate);
                    cmd1.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                     

                    dgvReportLocation.DataSource = dt;
                    dgvReportLocation.Columns[0].HeaderCell.Value = "وقت الدخول";
                    dgvReportLocation.Columns[1].HeaderCell.Value = "وقت الخروج";
                    dgvReportLocation.Columns[2].HeaderCell.Value = "عدد ساعات الدوام";
                    dgvReportLocation.Columns[3].HeaderCell.Value = "مكان العمل";
                    dgvReportLocation.Columns[4].HeaderCell.Value = "الشهر";
                    dgvReportLocation.Columns[5].HeaderCell.Value = "رقم الموظف";


                }
                Con.Close();
            } 
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'attendanceTimeDataSet3.LeaveOut' table. You can move, or remove it, as needed.
            this.leaveOutTableAdapter.Fill(this.attendanceTimeDataSet3.LeaveOut);
            // TODO: This line of code loads data into the 'attendanceTimeDataSet3.Location' table. You can move, or remove it, as needed.
            this.locationTableAdapter1.Fill(this.attendanceTimeDataSet3.Location);
            // TODO: This line of code loads data into the 'attendanceTimeDataSet3.Contract' table. You can move, or remove it, as needed.
            this.contractTableAdapter.Fill(this.attendanceTimeDataSet3.Contract);
            // TODO: This line of code loads data into the 'attendanceTimeDataSet1.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter1.Fill(this.attendanceTimeDataSet1.Employee);
           
        }

        private void cobEmaployeeNameReport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddVacation_Click(object sender, EventArgs e)
        {
            int EmpId = int.Parse(cobEmployeeNameVac.SelectedValue.ToString());
            DateTime Todate, Fromdate;
            Fromdate = dtpFromVac.Value;
            Todate = dtpToVac.Value;
            // add vacation for the employee.
            using (SqlCommand cmd = new SqlCommand("INSERT INTO [Vacations] values (@VacationFromDate, @VacationToDate, @VacationType, @EmployeeID)", Con))
            {
                Con.Open();

                cmd.Parameters.AddWithValue("VacationFromDate", Fromdate);
                cmd.Parameters.AddWithValue("VacationToDate", Todate);
                cmd.Parameters.AddWithValue("VacationType", txtVacationType.Text);
                cmd.Parameters.AddWithValue("EmployeeID", EmpId);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تمت الاضافة بنجاح !", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Con.Close();
        }

        private void btnUpdateCheckIn_Click(object sender, EventArgs e)
        {
            int CheckInId;
            DateTime CheckInDate;
            foreach (DataGridViewRow row in dgvCheckIn.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    CheckInId = int.Parse(row.Cells[1].Value.ToString());
                    CheckInDate = Convert.ToDateTime(row.Cells[2].Value.ToString());
                    using (SqlCommand cmd = new SqlCommand("UPDATE CheckIn SET CheckIn = @CheckIn WHERE CheckInID = @CheckInId", Con))
                    {
                        Con.Open();
                        cmd.Parameters.AddWithValue("CheckIn", CheckInDate);
                        cmd.Parameters.AddWithValue("CheckInId", CheckInId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تمت الاضافة بنجاح !", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Con.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(dgvCheckIn != null)
            //{
            //    dgvCheckIn.DataSource = null;
            //}
            //int EmpId = int.Parse(comboBox1.SelectedValue.ToString());
            //bool exists = false;
            //Con.Open();
            //using (SqlCommand cmd1 = new SqlCommand("select count(*) from [CheckIn] where EmployeeID = @EmployeeID", Con))
            //{
            //    cmd1.Parameters.AddWithValue("EmployeeID", EmpId);
            //    exists = (int)cmd1.ExecuteScalar() > 0;
            //}
            
            //if (exists == false)
            //{
            //    MessageBox.Show(txtUserName.Text, "هذا الموظف ليس لديه سجل دخول.");
            //    Con.Close();
            //}
            //else
            //{
            //    using (SqlCommand cmd2 = new SqlCommand("Select CheckInID, CheckIn, LocationNa from CheckIn where EmployeeID = @EmployeeID", Con))
            //    {
                    
            //        cmd2.Parameters.AddWithValue("EmployeeID", EmpId);
            //        cmd2.ExecuteNonQuery();
            //        SqlDataAdapter da = new SqlDataAdapter(cmd2);
            //        DataTable dt = new DataTable();
            //        da.Fill(dt);
            //        dgvCheckIn.DataSource = dt;
            //        dgvCheckIn.Columns[1].HeaderCell.Value = "رقم الموظف";
            //        dgvCheckIn.Columns[2].HeaderCell.Value = "وقت الدخول";
            //        dgvCheckIn.Columns[3].HeaderCell.Value = "مكان العمل";
            //    }

            //    Con.Close();
            //}
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (dgvCheckOut != null)
            //{
            //    dgvCheckOut.DataSource = null;
            //}
            //int EmpId = int.Parse(comboBox2.SelectedValue.ToString());
            //bool exists = false;
            //Con.Open();
            //using (SqlCommand cmd1 = new SqlCommand("select count(*) from [CheckOut] where EmployeeID = @EmployeeID", Con))
            //{
            //    cmd1.Parameters.AddWithValue("EmployeeID", EmpId);
            //    exists = (int)cmd1.ExecuteScalar() > 0;
            //}

            //if (exists == false)
            //{
            //    MessageBox.Show(txtUserName.Text, "هذا الموظف ليس لديه سجل دخول.");
            //    Con.Close();
            //}
            //else
            //{
            //    using (SqlCommand cmd2 = new SqlCommand("Select CheckOutID, CheckOut, LocationNa from CheckOut where EmployeeID = @EmployeeID", Con))
            //    {

            //        cmd2.Parameters.AddWithValue("EmployeeID", EmpId);
            //        cmd2.ExecuteNonQuery();
            //        SqlDataAdapter da = new SqlDataAdapter(cmd2);
            //        DataTable dt = new DataTable();
            //        da.Fill(dt);
            //        dgvCheckOut.DataSource = dt;
            //        dgvCheckOut.Columns[1].HeaderCell.Value = "رقم الموظف";
            //        dgvCheckOut.Columns[2].HeaderCell.Value = "وقت الخروج";
            //        dgvCheckOut.Columns[3].HeaderCell.Value = "مكان العمل";
            //    }

            //    Con.Close();
            //}
        }

        private void btnUpdateCheckOut_Click(object sender, EventArgs e)
        {
            int CheckOutId;
            DateTime CheckOutDate;
            foreach (DataGridViewRow row in dgvCheckOut.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    CheckOutId = int.Parse(row.Cells[1].Value.ToString());
                    CheckOutDate = Convert.ToDateTime(row.Cells[2].Value.ToString());
                    using (SqlCommand cmd = new SqlCommand("UPDATE CheckOut SET CheckOut = @CheckOut WHERE CheckOutID = @CheckOutId", Con))
                    {
                        Con.Open();
                        cmd.Parameters.AddWithValue("CheckOut", CheckOutDate);
                        cmd.Parameters.AddWithValue("CheckOutId", CheckOutId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تمت الاضافة بنجاح !", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Con.Close();
                }
            }
        }

        private void cobEmployeeNameVac_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cobLocationworkReort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLocationReport_Click(object sender, EventArgs e)
        {
            Export(dgvReportLocation);
        }

        private void btnLoadCheckin_Click(object sender, EventArgs e)
        {

            if (dgvCheckIn != null)
            {
                dgvCheckIn.DataSource = null;
            }
            int EmpId = int.Parse(comboBox1.SelectedValue.ToString());
            bool exists = false;
            DateTime Todate, Fromdate;
            Fromdate = dtpFromCheckin.Value;
            Todate = dtpToCheckin.Value;
            if (Todate < Fromdate)
            {
                MessageBox.Show("الرجاء ادخل التاريخ اقل");
            }
            else
            {
                Con.Open();

                using (SqlCommand cmd1 = new SqlCommand("select count(*) from [CheckIn] where EmployeeID = @EmployeeID", Con))
                {
                    cmd1.Parameters.AddWithValue("EmployeeID", EmpId);
                    exists = (int)cmd1.ExecuteScalar() > 0;
                }

                if (exists == false)
                {
                    MessageBox.Show(txtUserName.Text, "هذا الموظف ليس لديه سجل دخول.");
                    Con.Close();
                }
                else
                {
                    using (SqlCommand cmd2 = new SqlCommand("Select CheckInID, CheckIn, LocationNa from CheckIn where EmployeeID = @EmployeeID and CheckIn BETWEEN @Fromdate AND @Todate ", Con))
                    {

                        cmd2.Parameters.AddWithValue("EmployeeID", EmpId);
                        cmd2.Parameters.AddWithValue("Fromdate", Fromdate);
                        cmd2.Parameters.AddWithValue("Todate", Todate);
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvCheckIn.DataSource = dt;
                        dgvCheckIn.Columns[1].HeaderCell.Value = "رقم الموظف";
                        dgvCheckIn.Columns[2].HeaderCell.Value = "وقت الدخول";
                        dgvCheckIn.Columns[3].HeaderCell.Value = "مكان العمل";
                    }

                    Con.Close();
                }
            }
        }

        private void btnLoadCheckout_Click(object sender, EventArgs e)
        {
            if (dgvCheckOut != null)
            {
                dgvCheckOut.DataSource = null;
            }
            int EmpId = int.Parse(comboBox2.SelectedValue.ToString());
            bool exists = false;
            DateTime Todate, Fromdate;
            Fromdate = dtpFromCheckout.Value;
            Todate = dtpToCheckout.Value;
            if (Todate < Fromdate)
            {
                MessageBox.Show("الرجاء ادخل التاريخ اقل");
            }
            else
            {
                Con.Open();
                using (SqlCommand cmd1 = new SqlCommand("select count(*) from [CheckOut] where EmployeeID = @EmployeeID", Con))
                {
                    cmd1.Parameters.AddWithValue("EmployeeID", EmpId);
                    exists = (int)cmd1.ExecuteScalar() > 0;
                }

                if (exists == false)
                {
                     MessageBox.Show(txtUserName.Text, "هذا الموظف ليس لديه سجل دخول.");
                    Con.Close();
                }
                else
                {
                    using (SqlCommand cmd2 = new SqlCommand("Select CheckOutID, CheckOut, LocationNa from CheckOut where EmployeeID = @EmployeeID and CheckOut BETWEEN @Fromdate AND @Todate", Con))
                    {

                        cmd2.Parameters.AddWithValue("EmployeeID", EmpId);
                        cmd2.Parameters.AddWithValue("Fromdate", Fromdate);
                        cmd2.Parameters.AddWithValue("Todate", Todate);
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvCheckOut.DataSource = dt;
                        dgvCheckOut.Columns[1].HeaderCell.Value = "رقم الموظف";
                        dgvCheckOut.Columns[2].HeaderCell.Value = "وقت الخروج";
                        dgvCheckOut.Columns[3].HeaderCell.Value = "مكان العمل";
                    }

                    Con.Close();
                }
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadLeaves_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1, cmd2;
            bool exists = false;
            DateTime Todate, Fromdate;
            Fromdate = dtpFromLeaves.Value;
            Todate = dtpToLeaves.Value;
            int EId = int.Parse(cobEmployeeNameLeaves.SelectedValue.ToString());
            if (Todate < Fromdate)
            {
                MessageBox.Show("الرجاء ادخل التاريخ اقل");
            }
            else
            {
                Con.Open();
                using (cmd1 = new SqlCommand("select count(*) from [Leaves] where EmployeeID = @EmployeeID", Con))
                {
                    cmd1.Parameters.AddWithValue("EmployeeID", EId);
                    exists = (int)cmd1.ExecuteScalar() > 0;
                }

                if (exists == false)
                {
                    MessageBox.Show(txtUserName.Text, "هذا الموظف ليس لديه مغادرات.");
                    Con.Close();
                }
                else
                {
                    using (cmd2 = new SqlCommand("Select * from Leaves where EmployeeID = @EmployeeID and LeaveStart BETWEEN @Fromdate AND @Todate", Con))
                    {
                        cmd2.Parameters.AddWithValue("EmployeeID", EId);
                        cmd2.Parameters.AddWithValue("Fromdate", Fromdate);
                        cmd2.Parameters.AddWithValue("Todate", Todate);
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvLeaves.DataSource = dt;
                    }

                    Con.Close();
                }
            }
        }

        private void btnLoadVacations_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1, cmd2;
            bool exists = false;
            DateTime Todate, Fromdate;
            Fromdate = dtpFromVacations.Value;
            Todate = dtpToVacations.Value;
            int EId = int.Parse(cobEmployeeName.SelectedValue.ToString());
            if (Todate < Fromdate)
            {
                MessageBox.Show("الرجاء ادخل التاريخ اقل");
            }
            else
            {
                Con.Open();

                using (cmd1 = new SqlCommand("select count(*) from [Vacations] where EmployeeID = @EmployeeID", Con))
                {
                    cmd1.Parameters.AddWithValue("EmployeeID", EId);
                    exists = (int)cmd1.ExecuteScalar() > 0;
                }

                if (exists == false)
                {
                    MessageBox.Show(txtUserName.Text, "هذا الموظف ليس لديه اجازات.");
                    Con.Close();
                }
                else
                {
                    using (cmd2 = new SqlCommand("Select * from Vacations where EmployeeID = @EmployeeID and VacationFromDate BETWEEN @Fromdate AND @Todate", Con))
                    {
                        cmd2.Parameters.AddWithValue("EmployeeID", EId);
                        cmd2.Parameters.AddWithValue("Fromdate", Fromdate);
                        cmd2.Parameters.AddWithValue("Todate", Todate);
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvVacations.DataSource = dt;
                    }
                    Con.Close();
                }
            }
        }

        private void btnPrintEmployeeReport_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = " تقرير دوام الموظف";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "ديوان قاضي القضاة - انظمة المعلومات";
            printer.FooterSpacing = 15;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(dgvReport);
        }

        private void btnPrintLocationReport_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = " تقرير دوام الموظف";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "ديوان قاضي القضاة - انظمة المعلومات";
            printer.FooterSpacing = 15;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(dgvReportLocation);
        }
    }
}
