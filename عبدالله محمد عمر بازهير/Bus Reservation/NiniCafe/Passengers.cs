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
    public partial class Passengers : Form
    {
        public Passengers()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-O5CCO2R\MSSQLSERVER01;Initial Catalog=BusReservation;Integrated Security=True");

        void refre_data()
        {

            string query = "SELECT * FROM [View_2] ";
            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[View_2]");
            UsersGV.DataSource = ds.Tables[0];

        }

        private void Passengers_Load(object sender, EventArgs e)
        {
            refre_data();

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            String com = "select * from [Passenger] where PassengerName like '%" + PassNameTXT.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(com, cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Passenger]");
            UsersGV.DataSource = ds.Tables[0];
        }

        private void UsersGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rw = this.UsersGV.Rows[e.RowIndex];
            PassIDTXT.Text = rw.Cells["PassengerID"].Value.ToString();
            PassNameTXT.Text = rw.Cells["PassengerName"].Value.ToString();
            PhoneTXT.Text = rw.Cells["PassengerAddress"].Value.ToString();
            AddressTXT.Text = rw.Cells["Phone"].Value.ToString();
            GenderTXT.Text = rw.Cells["Gender"].Value.ToString();
           
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            LogInForm frm = new LogInForm();
            frm.Show();
            this.Hide();
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
    }
}
