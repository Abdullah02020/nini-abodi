using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //تعريف مكتبة قاعدة البيانات

namespace NiniCafe
{
    public partial class LogInForm : Form
    {
        private SqlConnection conn;
        private SqlDataAdapter sda;
        private DataSet ds;

        public LogInForm()
        {
            InitializeComponent();
            // Initialize the SqlConnection here
           conn = new SqlConnection(@"Data Source=desktop-o5cco2r\mssqlserver01;Initial Catalog=ChildCare;Integrated Security=True");
            ds = new DataSet();
        }

        private void ExitLable_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GuestLbl_Click(object sender, EventArgs e)
        {
            this.Hide();
            GuestOrder guest = new GuestOrder();
            guest.Show();
        }

        public static string user;
        public static int id;
        private void LogInBtn_Click(object sender, EventArgs e) //دالة تنفذ عند الضغط على بتن تسجيل الدخول
        {
            user = UnameTb.Text;
            if (UnameTb.Text == "" || UpassTb.Text == "") //التحقق اذا كان اسم المستخدماو كلمة المرور فارغان واحد او كلاهما يعطي رسالة لادخالهما
            {
                MessageBox.Show("Enter UserName or Password");
            }
            else
            {
                try
                {
                    // Create the SqlDataAdapter on the fly
                    string query = "SELECT * FROM [Users] WHERE UserName = @UserName AND Password = @Password";
                    sda = new SqlDataAdapter(query, conn);
                    sda.SelectCommand.Parameters.AddWithValue("@UserName", UnameTb.Text);
                    sda.SelectCommand.Parameters.AddWithValue("@Password", UpassTb.Text);

                    ds.Clear();
                    sda.Fill(ds, "Users");
                    if (ds.Tables["Users"].Rows.Count == 0)
                    {
                        MessageBox.Show("Login Failed");
                    }
                    else
                    {
                        UsersForm uf = new UsersForm();
                        this.Hide();
                        uf.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while trying to sign in: " + ex.Message);
                }
            }
        }

        private void X_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Orders fr = new Orders();
            fr.Show();
        }
    }
}