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
    public partial class Bus : Form
    {
        public Bus()
        {
            InitializeComponent();
        }
        //تعريف متغير من نوع قاعدة بيانات فيه معرفة قاعدة البيانات حتى نقوم بربطها بالواجهة
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-O5CCO2R\MSSQLSERVER01;Initial Catalog=BusReservation;Integrated Security=True");

        void refre_data()
        {

            string query = "SELECT * FROM [Bus1] ";
            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Bus1]");
            ItemsGV.DataSource = ds.Tables[0];

        }
     

        private void Bus_Load(object sender, EventArgs e)
        {
            refre_data();

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-O5CCO2R\MSSQLSERVER01;Initial Catalog=BusReservation;Integrated Security=True");

            if (NameTXT.Text == "" || BusCapTXT.Text == "" || CompTXT.Text == "" || BusPriceTXT.Text == "" )
            {
                MessageBox.Show("ادخل جميع البيانات");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Insert into [Bus1] values('" + NameTXT.Text + "','" + BusCapTXT.Text + "','" + CompTXT.Text + "','" + BusPriceTXT.Text + "')", cn);
                cn.Open();
                int x = cmd.ExecuteNonQuery();
                cn.Close();
                if (x > 0)
                    MessageBox.Show("تمت الاضافة");
                else
                    MessageBox.Show("لم تتم الاضافة ... حاول مرة اخرى");
                BusIDTXT.Text = "";
                NameTXT.Text = "";
                BusCapTXT.Text = "";
                CompTXT.Text = "";
                BusPriceTXT.Text = "";
                cn.Close();
                refre_data();
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            cn.Open();
            string update = "Update [Bus1] set BusName='" + NameTXT.Text + "', Capacity='" + BusCapTXT.Text + "', BusCompany='" + CompTXT.Text + "', price='" + BusPriceTXT.Text + "' where BusID='" + BusIDTXT.Text + "'   ";
            SqlCommand com = new SqlCommand(update, cn);
            com.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("تم التعديل");
            BusIDTXT.Text = "";
            NameTXT.Text = "";
            BusCapTXT.Text = "";
            CompTXT.Text = "";
            BusPriceTXT.Text = "";
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
                    String com = "Delete from [Bus1] where BusID='" + BusIDTXT.Text + "'";

                    SqlCommand cmd = new SqlCommand(com, cn);

                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("تم الحذف");
                    BusIDTXT.Text = "";
                    NameTXT.Text = "";
                    BusCapTXT.Text = "";
                    CompTXT.Text = "";
                    BusPriceTXT.Text = "";
                    refre_data();
                }
                else
                    MessageBox.Show("Try again");

            }
            catch
            {
                MessageBox.Show("حاول مرة اخرى ", "خطأ ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            String com = "select * from [Bus1] where BusName like '%" + NameTXT.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(com, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Employees]");
            ItemsGV.DataSource = ds.Tables[0];

        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            Employee frm = new Employee();
            frm.Show();
            this.Hide();
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

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            LogInForm frm = new LogInForm();
            frm.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ItemsGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rw = this.ItemsGV.Rows[e.RowIndex];
            BusIDTXT.Text = rw.Cells["BusID"].Value.ToString();
            NameTXT.Text = rw.Cells["BusName"].Value.ToString();
            BusCapTXT.Text = rw.Cells["Capacity"].Value.ToString();
            CompTXT.Text = rw.Cells["BusCompany"].Value.ToString();
            BusPriceTXT.Text = rw.Cells["price"].Value.ToString();
                    }
    }
}
