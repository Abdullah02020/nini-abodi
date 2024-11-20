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

namespace BusReservation
{
    public partial class LogInForm : Form
    {
      
        public LogInForm()
        {
            InitializeComponent();
          
        }

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-O5CCO2R\MSSQLSERVER01;Initial Catalog=BusReservation;Integrated Security=True");

        private void ExitLable_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      
        public static string Employee;
        private void LogInBtn_Click(object sender, EventArgs e)
        {
            Employee = EmployeeName.Text;
            if (EmployeeName.Text == "" || Pass.Text == "") //التحقق اذا كان اسم المستخدماو كلمة المرور فارغان واحد او كلاهما يعطي رسالة لادخالهما
            {
                MessageBox.Show("ادخل اسم المستخدم او كلمة السر");
            }
            else
            {
                try
                {
                    // Create the SqlDataAdapter on the fly
                    SqlDataAdapter sda = new SqlDataAdapter("select * from Employees where EmployeeName='" + EmployeeName.Text + "' and Password='" + Pass.Text + "'", cn);
                    DataSet ds = new DataSet();

                    
                    sda.Fill(ds, "Employees");
                    if (ds.Tables["Employees"].Rows.Count == 0)
                    {
                        MessageBox.Show("فشل تسجيل الدخول");
                    }
                    else
                    {
                        Booking frm = new Booking();
                        this.Hide();
                        frm.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ أثناء محاولة تسجيل الدخول: " + ex.Message);
                }
            }
        }



        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
