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
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-O5CCO2R\MSSQLSERVER01;Initial Catalog=BusReservation;Integrated Security=True");


        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     
        
        private void UserOredr_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'busReservationDataSet4.Trips' table. You can move, or remove it, as needed.
            this.tripsTableAdapter1.Fill(this.busReservationDataSet4.Trips);
            // TODO: This line of code loads data into the 'busReservationDataSet3.Passenger' table. You can move, or remove it, as needed.
            this.passengerTableAdapter.Fill(this.busReservationDataSet3.Passenger);
            // TODO: This line of code loads data into the 'busReservationDataSet2.Trips' table. You can move, or remove it, as needed.
            this.tripsTableAdapter.Fill(this.busReservationDataSet2.Trips);
            // TODO: This line of code loads data into the 'busReservationDataSet1.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.busReservationDataSet1.Employees);
            // TODO: This line of code loads data into the 'busReservationDataSet.Bus1' table. You can move, or remove it, as needed.
            this.bus1TableAdapter.Fill(this.busReservationDataSet.Bus1);
             DateLbl.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
           // TripIDTXT.Text = LogInForm.Employee;
            refre_data();
            refre_PassengertData();
            Combobox.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            
        }

   
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void refre_data()
        {

            string query = "SELECT * FROM [View_1] ";
            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[View_1]");
            ItemsGV.DataSource = ds.Tables[0];

        }


        void refre_PassengertData()
        {

            string query = "SELECT * FROM [Passenger] ";
            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Passenger]");
            PassengerGV.DataSource = ds.Tables[0];

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

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-O5CCO2R\MSSQLSERVER01;Initial Catalog=BusReservation;Integrated Security=True");

            if (PassNameTXT.Text == "" || PhoneTXT.Text == "" || AddressTXT.Text == "" || GenderCombobox.Text == "")
            {
                MessageBox.Show("ادخل جميع البيانات");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Insert into [Passenger] values('" + PassNameTXT.Text + "','" + PhoneTXT.Text + "','" + AddressTXT.Text + "','" + GenderCombobox.Text + "')", cn);
                cn.Open();
                int x = cmd.ExecuteNonQuery();
                cn.Close();
                if (x > 0)
                    MessageBox.Show("تمت الاضافة");
                else
                    MessageBox.Show("لم تتم الاضافة ... حاول مرة اخرى");
                PassenIDTXT.Text = "";
                PassNameTXT.Text = "";
                PhoneTXT.Text = "";
                AddressTXT.Text = "";
                GenderCombobox.Text = "";
                cn.Close();
                refre_PassengertData();
             }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cn.Open();
            string update = "Update [Passenger] set PassengerName='" + PassNameTXT.Text + "', PassengerAddress='" + PhoneTXT.Text + "',Phone='" + AddressTXT.Text + "',Gender='" + GenderCombobox.Text + "'  where PassengerID='" + PassenIDTXT.Text + "'   ";
            SqlCommand com = new SqlCommand(update, cn);
            com.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("تم التعديل");
            PassenIDTXT.Text = "";
            PassNameTXT.Text = "";
            PhoneTXT.Text = "";
            AddressTXT.Text = "";
            GenderCombobox.Text = "";
            refre_PassengertData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result;
                result = MessageBox.Show("هل تريد الحذف؟ ", "Conformation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    cn.Open();
                    String com = "Delete from [Passenger] where PassengerID='" + PassenIDTXT.Text + "'";

                    SqlCommand cmd = new SqlCommand(com, cn);

                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("تم الحذف");
                    PassenIDTXT.Text = "";
                    PassNameTXT.Text = "";
                    PhoneTXT.Text = "";
                    AddressTXT.Text = "";
                    GenderCombobox.Text = "";
                    refre_PassengertData();
                }
                else
                    MessageBox.Show("Try again");

            }
            catch
            {
                MessageBox.Show("حاول مرة اخرى ", "خطأ ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            String com = "select * from [Passenger] where PassengerName like '%" + PassNameTXT.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(com, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Passenger]");
            PassengerGV.DataSource = ds.Tables[0];
        }

        private void PassengerGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            DataGridViewRow rw = this.PassengerGV.Rows[e.RowIndex];
            PassenIDTXT.Text = rw.Cells["PassengerID"].Value.ToString();
            PassNameTXT.Text = rw.Cells["PassengerName"].Value.ToString();
            PhoneTXT.Text = rw.Cells["PassengerAddress"].Value.ToString();
            AddressTXT.Text = rw.Cells["Phone"].Value.ToString();
            GenderCombobox.Text = rw.Cells["Gender"].Value.ToString();
            
        }

        private void GuestLbl_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            refre_data();
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-O5CCO2R\MSSQLSERVER01;Initial Catalog=BusReservation;Integrated Security=True");
            String com = "select * from Bus1 where BusID like '%" + comboBox1.SelectedValue + "%'";
            SqlDataAdapter da = new SqlDataAdapter(com, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Bus1");
            DataTable dt = new DataTable();
            da.Fill(dt);
            BusNumTXT.Text = dt.Rows[0]["BusID"].ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-O5CCO2R\MSSQLSERVER01;Initial Catalog=BusReservation;Integrated Security=True");

                 SqlCommand cmd = new SqlCommand("Insert into [Booking1] values('" + comboBox1.SelectedValue + "','" + Combobox.SelectedValue + "','" + comboBox2.SelectedValue + "','" + comboBox3.SelectedValue + "','" + ChireNumTXT.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')", cn);
                cn.Open();
                int x = cmd.ExecuteNonQuery();
                cn.Close();
                if (x > 0)
                    MessageBox.Show("تمت الاضافة");
                else
                    MessageBox.Show("لم تتم الاضافة ... حاول مرة اخرى");
            comboBox1.Text = "";
            Combobox.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            ChireNumTXT.Text = "";
               cn.Close();
                refre_data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cn.Open();
            string update = "Update [Booking1] set EmployeeID='" + comboBox1.SelectedValue + "', BusID='" + Combobox.SelectedValue + "', TripID='" + comboBox2.SelectedValue + "',PassengerID='" + comboBox3.SelectedValue + "', ChairNumber='" + ChireNumTXT.Text + "', BookingDate='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' where BookingID='" + BookIDTXT.Text + "'   ";
            SqlCommand com = new SqlCommand(update, cn);
            com.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("تم التعديل");
            comboBox1.Text = "";
            Combobox.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            ChireNumTXT.Text = "";
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
                    String com = "Delete from [Booking1] where BookingID='" + BookIDTXT.Text + "'";

                    SqlCommand cmd = new SqlCommand(com, cn);

                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("تم الحذف");
                    comboBox1.Text = "";
                    Combobox.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    ChireNumTXT.Text = "";
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

        private void ItemsGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rw = this.ItemsGV.Rows[e.RowIndex];
            BookIDTXT.Text = rw.Cells["BookingID"].Value?.ToString() ?? "";
            comboBox1.SelectedValue = rw.Cells["EmployeeID"].Value?.ToString() ?? "";
            Combobox.SelectedValue = rw.Cells["BusID"].Value?.ToString() ?? "";
            comboBox2.SelectedValue = rw.Cells["TripID"].Value?.ToString() ?? "";
            comboBox3.SelectedValue = rw.Cells["PassengerID"].Value?.ToString() ?? "";
            ChireNumTXT.Text = rw.Cells["ChairNumber"].Value?.ToString() ?? "";
            dateTimePicker1.Text = rw.Cells["BookingDate"].Value?.ToString() ?? "";

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-O5CCO2R\MSSQLSERVER01;Initial Catalog=BusReservation;Integrated Security=True");

            String com = "select * from Trips where TripID like '%" + comboBox1.SelectedValue + "%'";
            SqlDataAdapter da = new SqlDataAdapter(com, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Trips");
            DataTable dt = new DataTable();
            da.Fill(dt);
            bunifuTextBox1.Text = dt.Rows[0]["TripPrice"].ToString();
            
            refre_data();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-O5CCO2R\MSSQLSERVER01;Initial Catalog=BusReservation;Integrated Security=True");
            String com = "select * from Trips where TripID like '%" + comboBox1.SelectedValue + "%'";
            SqlDataAdapter da = new SqlDataAdapter(com, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Trips");
            DataTable dt = new DataTable();
            da.Fill(dt);
            bunifuTextBox1.Text = dt.Rows[0]["TripPrice"].ToString();
        }
    }
}

