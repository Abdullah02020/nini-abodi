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
    public partial class UsersForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=desktop-o5cco2r\mssqlserver01;Initial Catalog=ChildCare;Integrated Security=True");
        DataSet ds = new DataSet();
        public UsersForm()
        {
            InitializeComponent();

        }

        void refre_data()
        {

            string query = "SELECT * FROM [Users] ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Users]");
            UsersGV.DataSource = ds.Tables[0];

        }
    
    
        private void UsersForm_Load_1(object sender, EventArgs e)
        {
            refre_data();
        }


        private void logoutLable_Click(object sender, EventArgs e)
        {
            LogInForm login = new LogInForm();
            login.Show();
            this.Hide();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=desktop-o5cco2r\mssqlserver01;Initial Catalog=ChildCare;Integrated Security=True");

            if (UnameTb.Text == "" || UpassTb.Text == "" || UserPhone.Text == "" || UserGender.Text == "" || UserAddress.Text == "")
            {
                MessageBox.Show("Fill All The Fields");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Insert into Users values('" + UnameTb.Text + "','" + UpassTb.Text + "','" + UserPhone.Text + "','" + UserGender.Text + "','" + UserAddress.Text + "')", conn);
                conn.Open();
                int x = cmd.ExecuteNonQuery();
                conn.Close();

                if (x > 0)
                    MessageBox.Show("Added successfully");
                else
                    MessageBox.Show("not added .. Try again");
                UnameTb.Text = "";
                UpassTb.Text = "";
                UserPhone.Text = "";
                UserGender.Text = "";
                UserAddress.Text = "";
                conn.Close();
                refre_data();

            }
        }

                      
        


        private void EditBtn_Click(object sender, EventArgs e)
        {

            conn.Open();
            string update = "Update [Users] set Password='" + UpassTb.Text + "', Phone='" + UserPhone.Text + "',Gender='" + UserGender.Text + "',Address='" + UserAddress.Text + "' where UserID='" + UserID.Text + "'   ";
            SqlCommand com = new SqlCommand(update, conn);
            com.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Done");
            UnameTb.Text = "";
            UpassTb.Text = "";
            UserPhone.Text = "";
            UserGender.Text = "";
            UserAddress.Text = "";
            refre_data();

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result;
                result = MessageBox.Show("Do you want delete? ", "Conformation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    conn.Open();
                    String com = "Delete from [Users] where UserID='" + UserID.Text + "'";

                    SqlCommand cmd = new SqlCommand(com, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Done");
                    UnameTb.Text = "";
                    UpassTb.Text = "";
                    UserPhone.Text = "";
                    UserGender.Text = "";
                    UserAddress.Text = "";
                    refre_data();
                }
                else
                    MessageBox.Show("Try again");

            }
            catch
            {
                MessageBox.Show("Try again ", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void X_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void UsersGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rw = this.UsersGV.Rows[e.RowIndex];
            UserID.Text = rw.Cells["UserID"].Value.ToString();
            UnameTb.Text = rw.Cells["UserName"].Value.ToString();
            UpassTb.Text = rw.Cells["Password"].Value.ToString();
            UserPhone.Text = rw.Cells["Phone"].Value.ToString();
            UserGender.Text = rw.Cells["Gender"].Value.ToString();
            UserAddress.Text = rw.Cells["Address"].Value.ToString();
        }



        private void FoodBtn_Click(object sender, EventArgs e)
        {
            Food fr = new Food();
            fr.Show();
            this.Hide();
        }

        private void ActivityBtn_Click(object sender, EventArgs e)
        {
            Activity fr = new Activity();
            this.Hide();
            fr.Show();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {

            String com = "select * from [Users] where UserName like '%" + UnameTb.Text + "%'";

            SqlDataAdapter da = new SqlDataAdapter(com, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Users]");
            UsersGV.DataSource = ds.Tables[0];

        }

        private void SubscribeBtn_Click(object sender, EventArgs e)
        {
            Subscription fr = new Subscription();
            this.Hide();
            fr.Show();
        }


        private void ChildBtn_Click(object sender, EventArgs e)
        {
            Child fr = new Child();
            this.Hide();
            fr.Show();
        }

        private void logoutLable_Click_1(object sender, EventArgs e)
        {
            LogInForm fr = new LogInForm();
            this.Hide();
            fr.Show();
        }
    }
}
