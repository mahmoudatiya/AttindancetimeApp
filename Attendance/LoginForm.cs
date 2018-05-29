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
    public partial class LoginForm : Form
    {
        SqlConnection Con = new SqlConnection(@"Server=development; Database=AttendanceTime; Integrated Security=True");
        SqlCommand Cmd;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPWD.Text == "")
            {
                MessageBox.Show("الرجاح ادخل اسم المستخدم وكلمة المرور");
                return;
            }
            try
            {
                //Create SqlConnection

                SqlCommand cmd = new SqlCommand("Select * from Users where UserName=@username and Password=@password", Con);
                cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                cmd.Parameters.AddWithValue("@password", txtPWD.Text);
                Con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                Con.Close();
                int count = ds.Tables[0].Rows.Count;
                //If count is equal to 1, than show frmMain form
                if (count == 1)
                {
                    MessageBox.Show("تم تسجيل الدخول بنجاح!");
                    this.Hide();
                    Form1 fm = new Form1(txtUserName.Text);
                    fm.Show();
                }
                else
                {
                    MessageBox.Show("فشل الدخول!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
