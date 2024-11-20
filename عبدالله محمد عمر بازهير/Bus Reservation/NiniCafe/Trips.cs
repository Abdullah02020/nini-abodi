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
    public partial class Trips : Form
    {
        public Trips()
        {
            InitializeComponent();
        }

        //تعريف متغير من نوع قاعدة بيانات فيه معرفة قاعدة البيانات حتى نقوم بربطها بالواجهة
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-O5CCO2R\MSSQLSERVER01;Initial Catalog=BusReservation;Integrated Security=True");

        void refre_data()
        {

            string query = "SELECT * FROM [Trips] ";
            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Trips]");
            ItemsGV.DataSource = ds.Tables[0];

        }

        private void Trips_Load(object sender, EventArgs e)
        {
            refre_data();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-O5CCO2R\MSSQLSERVER01;Initial Catalog=BusReservation;Integrated Security=True");

            if (StartCityTXT.Text == "" || EndCityTXT.Text == "" || PeriodTXT.Text == "" || PriceTXT.Text == "")
            {
                MessageBox.Show("ادخل جميع البيانات");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Insert into [Trips] values('" + StartCityTXT.Text + "','" + EndCityTXT.Text + "','" + PeriodTXT.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + PriceTXT.Text + "')", cn);
                cn.Open();
                int x = cmd.ExecuteNonQuery();
                cn.Close();
                if (x > 0)
                    MessageBox.Show("تمت الاضافة");
                else
                    MessageBox.Show("لم تتم الاضافة ... حاول مرة اخرى");
                TripIDTXT.Text = "";
                StartCityTXT.Text = "";
                EndCityTXT.Text = "";
                PeriodTXT.Text = "";
                PriceTXT.Text = "";
                cn.Close();
                refre_data();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.Open();
            string update = "Update [Trips] set StartingPlint='" + StartCityTXT.Text + "', EndingPoint='" + EndCityTXT.Text + "', TripPeriod='" + PeriodTXT.Text + "',TripDate='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', TripPrice='" + PriceTXT.Text + "' where TripID='" + TripIDTXT.Text + "'   ";
            SqlCommand com = new SqlCommand(update, cn);
            com.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("تم التعديل");
            TripIDTXT.Text = "";
            StartCityTXT.Text = "";
            EndCityTXT.Text = "";
            PeriodTXT.Text = "";
            PriceTXT.Text = "";
            refre_data();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result;
                result = MessageBox.Show("هل تريد الحذف؟ ", "Conformation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    cn.Open();
                    String com = "Delete from [Trips] where TripID='" + TripIDTXT.Text + "'";

                    SqlCommand cmd = new SqlCommand(com, cn);

                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("تم الحذف");
                    TripIDTXT.Text = "";
                    StartCityTXT.Text = "";
                    EndCityTXT.Text = "";
                    PeriodTXT.Text = "";
                    PriceTXT.Text = "";
                    refre_data();
                }
                else
                    MessageBox.Show("حاول مرة اخرى");

            }
            catch
            {
                MessageBox.Show("حاول مرة اخرى ", "خطأ ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            String com = "select * from [Trips] where StartingPlint like '%" + StartCityTXT.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(com, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Trips]");
            ItemsGV.DataSource = ds.Tables[0];
        }

        private void ItemsGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rw = this.ItemsGV.Rows[e.RowIndex];
            TripIDTXT.Text = rw.Cells["TripID"].Value.ToString();
            StartCityTXT.Text = rw.Cells["StartingPlint"].Value.ToString();
            EndCityTXT.Text = rw.Cells["EndingPoint"].Value.ToString();
            PeriodTXT.Text = rw.Cells["TripPeriod"].Value.ToString();
            dateTimePicker1.Text = rw.Cells["TripDate"].Value.ToString();
            PriceTXT.Text = rw.Cells["TripPrice"].Value.ToString();
           
        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            Employee frm = new Employee();
            frm.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Bus frm = new Bus();
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

        private void bunifuThinButton24_Click(object sender, EventArgs e)
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
