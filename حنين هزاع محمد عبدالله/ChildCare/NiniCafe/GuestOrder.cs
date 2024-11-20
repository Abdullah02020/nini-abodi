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
    public partial class GuestOrder : Form
    {
        public GuestOrder()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=desktop-o5cco2r\mssqlserver01;Initial Catalog=ChildCare;Integrated Security=True");
        DataSet ds = new DataSet();

        private void logoutLable_Click(object sender, EventArgs e)
        {
            LogInForm fr = new LogInForm();
            this.Hide();
            fr.Show();
        }

        private void GuestOrder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'childCareDataSet10.View_3' table. You can move, or remove it, as needed.
            this.view_3TableAdapter1.Fill(this.childCareDataSet10.View_3);
            // TODO: This line of code loads data into the 'childCareDataSet9.View_3' table. You can move, or remove it, as needed.
            this.view_3TableAdapter.Fill(this.childCareDataSet9.View_3);
            // TODO: This line of code loads data into the 'childCareDataSet8.Foods' table. You can move, or remove it, as needed.
            this.foodsTableAdapter.Fill(this.childCareDataSet8.Foods);
            // TODO: This line of code loads data into the 'childCareDataSet7.Acctivities' table. You can move, or remove it, as needed.
            this.acctivitiesTableAdapter.Fill(this.childCareDataSet7.Acctivities);
            // TODO: This line of code loads data into the 'childCareDataSet6.Childs' table. You can move, or remove it, as needed.
            this.childsTableAdapter.Fill(this.childCareDataSet6.Childs);
            refre_data();
        }

        void refre_data()
        {

            string query = "SELECT * FROM [View_3]";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "View_3");
            SubGV.DataSource = ds.Tables[0];

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=desktop-o5cco2r\mssqlserver01;Initial Catalog=ChildCare;Integrated Security=True");

            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox3.Text == "" || PriceText.Text == "")
            {
                MessageBox.Show("Fill All The Fields");
            }
            else
            {

                SqlCommand cmd = new SqlCommand("Insert into Subscripe values('" + comboBox4.Text + "','" + comboBox1.SelectedValue + "','" + comboBox2.SelectedValue + "','" + comboBox3.SelectedValue + "','" + PriceText.Text + "')", conn);
                conn.Open();
                int x = cmd.ExecuteNonQuery();
                conn.Close();

                if (x > 0)
                {
                    MessageBox.Show("Added successfully");
                }
                else
                    MessageBox.Show("not added .. Try again");
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                PriceText.Text = "";
                conn.Close();
                refre_data();

            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            string update = "Update [Subscripe] set ChildID='" + comboBox1.Text + "', ActivityID='" + comboBox2.Text + "',FoodID='" + comboBox3.Text + "',Price='" + PriceText.Text + "' where SubscriptionID='" + SubID.Text + "'   ";
            SqlCommand com = new SqlCommand(update, conn);
            com.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Done");
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            PriceText.Text = "";
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
                    String com = "Delete from [Subscripe] where SubscriptionID='" + SubID.Text + "'";

                    SqlCommand cmd = new SqlCommand(com, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Done");
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    PriceText.Text = "";
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

        private void SearchBtn_Click(object sender, EventArgs e)
        {

            String com = "select * from [Subscripe] where ChildID like '%" + comboBox1.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(com, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Subscripe]");
            SubGV.DataSource = ds.Tables[0];
        }

        private void X_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SubGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rw = this.SubGV.Rows[e.RowIndex];
            SubID.Text = rw.Cells["SubscriptionID"].Value.ToString();
            comboBox4.SelectedValue = rw.Cells["UserID"].Value.ToString();
            comboBox1.SelectedValue = rw.Cells["ChildID"].Value.ToString();
            comboBox2.SelectedValue = rw.Cells["ActivityID"].Value.ToString();
            comboBox3.SelectedValue = rw.Cells["FoodID"].Value.ToString();
            PriceText.Text = rw.Cells["Price"].Value.ToString();
        }

        private void logoutLable_Click_1(object sender, EventArgs e)
        {
            LogInForm fr = new LogInForm();
            fr.Show();
            this.Hide();

        }
    }
}
