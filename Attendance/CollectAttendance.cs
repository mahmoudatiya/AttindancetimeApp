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

namespace Attendance
{
    public partial class CollectAttendance : Form
    {
        string LocationNa;

        SqlConnection Con = new SqlConnection(@"Server=development; Database=AttendanceTime; Integrated Security=True");
        SqlDataAdapter Da;
        DataTable Dt = new DataTable();
        SqlCommand Cmd;
        public CollectAttendance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int counter = 0;
            string line, pp, In, EID, Month, Date1;
            int EmployeeNumber, FingerID, lenght;
            DateTime CheckIn, LIn, LOut, CheckOut;
          //  bool exists = false;
            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"g:\test.txt");
            while ((line = file.ReadLine()) != null)
            {
                // lines = char.Parse(line);
                lenght = line.Length - 1;
                //for(int i=0;i<line.Length-1; i++ )
                //{
                In = line[0].ToString() + line[1].ToString() + line[2].ToString() + line[3].ToString() + line[4].ToString() + line[5].ToString() + line[6].ToString() + line[7].ToString() + line[8].ToString() + line[9].ToString() + " " + line[19].ToString() + line[20].ToString() + ":" + line[21].ToString() + line[22].ToString() + ":" + line[23].ToString() + line[24].ToString();
                pp = line[26].ToString() + line[27].ToString() + line[28].ToString() + line[29].ToString()+ line[30].ToString();
                EID = line[14].ToString() + line[15].ToString() + line[16].ToString() + line[17].ToString() + line[18].ToString();
                int Empid = int.Parse(EID.ToString());
                Month = line[5].ToString() + line[6].ToString();
                Date1 = line[0].ToString() + line[1].ToString() + line[2].ToString() + line[3].ToString() + line[4].ToString() + line[5].ToString() + line[6].ToString() + line[7].ToString() + line[8].ToString() + line[9].ToString();
                CheckIn = Convert.ToDateTime(In);
                bool exists= false;
                //using (SqlCommand cmd1 = new SqlCommand("select * from CheckIn where CheckIn = @CheckIn ", Con))
                //{
                //    Con.Open();
                //    cmd1.Parameters.AddWithValue("CheckIn", CheckIn);
                //    exists = (int)cmd1.ExecuteScalar() > 0;
                //}

                //if (exists == true)
                //{
                //    MessageBox.Show("لا يوجد سجل دوام.");
                //    Con.Close();
                //}
                //else
                //{
                
                    try
                {
                    Con.Close();
                    using (SqlCommand cmd = new SqlCommand("select LocationName from [Location] where LocationID = (select LocationID from Employee where EmployeeID = @EmployeeID)", Con))
                    {
                        Con.Open();
                        cmd.Parameters.AddWithValue("EmployeeID", Empid);
                        cmd.ExecuteNonQuery();
                        LocationNa = (string)cmd.ExecuteScalar();
                        //     MessageBox.Show("Added Successfully !", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (line[lenght - 5].ToString() == "I")
                {

                    CheckIn = Convert.ToDateTime(In);
                    EmployeeNumber = int.Parse(EID.ToString());
                    FingerID = int.Parse(pp.ToString());
                    Con.Open();
                    using (SqlCommand cmd1 = new SqlCommand("select count(*) from [CheckIn] where CheckIn = @CheckIn", Con))
                    {
                        cmd1.Parameters.AddWithValue("CheckIn", CheckIn);
                        exists = (int)cmd1.ExecuteScalar() > 0;
                    }

                    if (exists == false)
                    {
                        try
                        {

                            //Con.Open();
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO [CheckIn] values ( @FingerPrintID, @EmployeeID, @CheckIn, @Month, @Date1, @LocationNa)", Con))
                            {
                                cmd.Parameters.AddWithValue("FingerPrintID", FingerID);
                                cmd.Parameters.AddWithValue("EmployeeID", EmployeeNumber);
                                cmd.Parameters.AddWithValue("CheckIn", CheckIn);
                                cmd.Parameters.AddWithValue("Month", Month);
                                cmd.Parameters.AddWithValue("Date1", Date1);
                                cmd.Parameters.AddWithValue("LocationNa", LocationNa);
                                cmd.ExecuteNonQuery();
                                //      MessageBox.Show("Added Successfully !", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Con.Close();
                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Some Error Occured !" + ex.Message + EmployeeNumber);
                        }
                        finally
                        {
                            Con.Close();
                        }
                    }
                    Con.Close();
                }
                if (line[lenght - 5].ToString() == "i")
                {

                    LIn = Convert.ToDateTime(In);
                    EmployeeNumber = int.Parse(EID.ToString());
                    FingerID = int.Parse(pp.ToString());
                    Con.Close();
                    Con.Open();
                    using (SqlCommand cmd1 = new SqlCommand("select count(*) from [LIn] where LIn = @LIn", Con))
                    {
                        cmd1.Parameters.AddWithValue("LIn", LIn);
                        exists = (int)cmd1.ExecuteScalar() > 0;
                    }

                    if (exists == false)
                    {
                        try
                        {
                            Con.Close();
                            Con.Open();
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO [LeaveIn] values ( @FingerPrintID, @EmployeeID, @LIn, @Date1)", Con))
                            {
                                cmd.Parameters.AddWithValue("FingerPrintID", FingerID);
                                cmd.Parameters.AddWithValue("EmployeeID", EmployeeNumber);
                                cmd.Parameters.AddWithValue("LIn", LIn);
                                cmd.Parameters.AddWithValue("Date1", Date1);
                                cmd.ExecuteNonQuery();

                                //    MessageBox.Show("Added Successfully !", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Con.Close();
                }
                if (line[lenght - 5].ToString() == "o")
                {

                    LOut = Convert.ToDateTime(In);
                    EmployeeNumber = int.Parse(EID.ToString());
                    FingerID = int.Parse(pp.ToString());
                    Con.Close();
                    Con.Open();
                    using (SqlCommand cmd1 = new SqlCommand("select count(*) from [LOut] where LOut = @LOut", Con))
                    {
                        cmd1.Parameters.AddWithValue("LOut", LOut);
                        exists = (int)cmd1.ExecuteScalar() > 0;
                                                
                    }

                    if (exists == false)
                    {
                        try
                        {
                            Con.Close();
                            Con.Open();
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO [LeaveOut] values ( @FingerPrintID, @EmployeeID, @LOut, @Date1)", Con))
                            {
                                cmd.Parameters.AddWithValue("FingerPrintID", FingerID);
                                cmd.Parameters.AddWithValue("EmployeeID", EmployeeNumber);
                                cmd.Parameters.AddWithValue("LOut", LOut);
                                cmd.Parameters.AddWithValue("Date1", Date1);
                                cmd.ExecuteNonQuery();
                                // MessageBox.Show("Added Successfully !", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Con.Close();
                }
                if (line[lenght - 5].ToString() == "O")
                {
                    
                    CheckOut = Convert.ToDateTime(In);
                    EmployeeNumber = int.Parse(EID.ToString());
                    FingerID = int.Parse(pp.ToString());
                    CheckIn = new DateTime();
                    LIn = new DateTime();
                    LOut = new DateTime();
                    Con.Close();
                    Con.Open();
                    using (SqlCommand cmd1 = new SqlCommand("select count(*) from [CheckOut] where CheckOut = @CheckOut", Con))
                    {
                        cmd1.Parameters.AddWithValue("CheckOut", CheckOut);
                        exists = (int)cmd1.ExecuteScalar() > 0;
                    }

                    if (exists == false)
                    {
                        try
                        {

                            //  using (SqlCommand cmd = new SqlCommand("INSERT INTO [Attendance] values (@AttendanceId, @FingerPrintID, @EmployeeID, @CheckIn, @CheckOut, @LIn, @LOut)", Con))

                           // Con.Open();
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO [CheckOut] values (@FingerPrintID, @EmployeeID, @CheckOut, @Month, @Date1, @LocationNa)", Con))
                            {

                                cmd.Parameters.AddWithValue("FingerPrintID", FingerID);
                                cmd.Parameters.AddWithValue("EmployeeID", EmployeeNumber);
                                cmd.Parameters.AddWithValue("CheckOut", CheckOut);
                                cmd.Parameters.AddWithValue("Month", Month);
                                cmd.Parameters.AddWithValue("Date1", Date1);
                                cmd.Parameters.AddWithValue("LocationNa", LocationNa);

                                cmd.ExecuteNonQuery();
                                //   MessageBox.Show("Added Successfully !", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Con.Close();
                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Some Error Occured !" + ex.Message + EmployeeNumber);
                        }
                        finally
                        {
                            Con.Close();
                        }
                        Con.Close();
                    }
                    
                }


                //System.Console.WriteLine(line);
                //MessageBox.Show(line);
                counter++;
            }


            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            System.Console.ReadLine();

        }
    }
}
