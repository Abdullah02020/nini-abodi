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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }



        //تعريف متغير من نوع قاعدة بيانات فيه معرفة قاعدة البيانات حتى نقوم بربطها بالواجهة

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-O5CCO2R\MSSQLSERVER01;Initial Catalog=BusReservation;Integrated Security=True");



        void refre_data()
        {

            string query = "SELECT * FROM [Employees] ";
            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Employees]");
            UsersGV.DataSource = ds.Tables[0];

        }

        private void Employee_Load(object sender, EventArgs e)
        {
            refre_data();

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Passengers frm = new Passengers();
            frm.Show();
            this.Hide();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Booking frm = new Booking();
            frm.Show();
            this.Hide();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            Trips frm = new Trips();
            frm.Show();
            this.Hide();
        }

       


        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Bus frm = new Bus();
            frm.Show();
            this.Hide();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-O5CCO2R\MSSQLSERVER01;Initial Catalog=BusReservation;Integrated Security=True");

            if (EmpNameTXT.Text == "" || PhoneTXT.Text == "" || AddressTXT.Text == "" || SalaryTxT.Text == "" || GenderCombobox.Text == "" || JobTXT.Text == "")
            {
                MessageBox.Show("ادخل جميع البيانات");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Insert into [Employees] values('" + EmpNameTXT.Text + "','" + PhoneTXT.Text + "','" + AddressTXT.Text + "','" + SalaryTxT.Text + "','" + GenderCombobox.Text + "','" + EmpPassTXT.Text + "','" + JobTXT.Text + "')", cn);
                cn.Open();
                int x = cmd.ExecuteNonQuery();
                cn.Close();
                if (x > 0)
                    MessageBox.Show("تمت الاضافة");
                else
                    MessageBox.Show("لم تتم الاضافة ... حاول مرة اخرى");
                EmpIDTXT.Text = "";
                EmpNameTXT.Text = "";
                PhoneTXT.Text = "";
                AddressTXT.Text = "";
                SalaryTxT.Text = "";
                GenderCombobox.Text = "";
                EmpPassTXT.Text = "";
                JobTXT.Text = "";
                cn.Close();
                refre_data();
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            cn.Open();
            string update = "Update [Employees] set Mobile='" + PhoneTXT.Text + "', Address='" + AddressTXT.Text + "',Salary='" + SalaryTxT.Text + "',Gender='" + GenderCombobox.Text + "',Password='" + EmpPassTXT.Text + "',Job='" + GenderCombobox.Text + "' where EmployeeID='" + EmpIDTXT.Text + "'   ";
            SqlCommand com = new SqlCommand(update, cn);
            com.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("تم التعديل");
            EmpIDTXT.Text = "";
            EmpNameTXT.Text = "";
            PhoneTXT.Text = "";
            AddressTXT.Text = "";
            SalaryTxT.Text = "";
            GenderCombobox.Text = "";
            EmpPassTXT.Text = "";
            JobTXT.Text = "";
            refre_data();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result;
                result = MessageBox.Show("هل تريد الحذف؟ ", "Conformation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    cn.Open();
                    String com = "Delete from [Employees] where EmployeeID='" + EmpIDTXT.Text + "'";

                    SqlCommand cmd = new SqlCommand(com, cn);

                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("تم الحذف");
                    EmpIDTXT.Text = "";
                    EmpNameTXT.Text = "";
                    PhoneTXT.Text = "";
                    AddressTXT.Text = "";
                    SalaryTxT.Text = "";
                    GenderCombobox.Text = "";
                    EmpPassTXT.Text = "";
                    JobTXT.Text = "";
                    refre_data();
                }
                else
                    MessageBox.Show("حاول مجددا");

            }
            catch
            {
                MessageBox.Show("حاول مرة اخرى ", "خطأ ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            String com = "select * from [Employees] where EmployeeName like '%" + EmpNameTXT.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(com, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Employees]");
            UsersGV.DataSource = ds.Tables[0];

        }

        private void UsersGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rw = this.UsersGV.Rows[e.RowIndex];
            EmpIDTXT.Text = rw.Cells["EmployeeID"].Value.ToString();
            EmpNameTXT.Text = rw.Cells["EmployeeName"].Value.ToString();
            PhoneTXT.Text = rw.Cells["Mobile"].Value.ToString();
            AddressTXT.Text = rw.Cells["Address"].Value.ToString();
            SalaryTxT.Text = rw.Cells["Salary"].Value.ToString();
            GenderCombobox.Text = rw.Cells["Gender"].Value.ToString();
            EmpPassTXT.Text = rw.Cells["Password"].Value.ToString();
            JobTXT.Text = rw.Cells["Job"].Value.ToString();
         
        }

        private void bunifuThinButton24_Click_1(object sender, EventArgs e)
        {
            LogInForm frm = new LogInForm();
            frm.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     
    }
}
