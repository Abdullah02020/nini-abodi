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
    public partial class Activity : Form
    {
        public Activity()
        {
            InitializeComponent();
        }

        //تعريف متغير من نوع قاعدة بيانات فيه معرفة قاعدة البيانات حتى نقوم بربطها بالواجهة
        SqlConnection conn = new SqlConnection(@"Data Source=desktop-o5cco2r\mssqlserver01;Initial Catalog=ChildCare;Integrated Security=True");
        DataSet ds = new DataSet();

        void refre_data()
        {

            string query = "SELECT * FROM [Acctivities] ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Acctivities]");
            ActivGV.DataSource = ds.Tables[0];

        }
        private void Activity_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'childCareDataSet12.Acctivities' table. You can move, or remove it, as needed.
            this.acctivitiesTableAdapter1.Fill(this.childCareDataSet12.Acctivities);
            // TODO: This line of code loads data into the 'childCareDataSet3.Acctivities' table. You can move, or remove it, as needed.
            this.acctivitiesTableAdapter.Fill(this.childCareDataSet3.Acctivities);
            refre_data();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=desktop-o5cco2r\mssqlserver01;Initial Catalog=ChildCare;Integrated Security=True");

            if (ActName.Text == "" || ActPer.Text == "" || ActPrice.Text == "" )
            {
                MessageBox.Show("Fill All The Fields");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Insert into Acctivities values('" + ActName.Text + "','" + ActPer.Text + "','" + ActPrice.Text + "')", conn);
                conn.Open();
                int x = cmd.ExecuteNonQuery();
                conn.Close();

                if (x > 0)
                    MessageBox.Show("Added successfully");
                else
                    MessageBox.Show("not added .. Try again");
                ActName.Text = "";
                ActPer.Text = "";
                ActPrice.Text = "";
                conn.Close();
                refre_data();

            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {

            conn.Open();
            string update = "Update [Acctivities] set ActivityName='" + ActName.Text + "', ActivityPeriod='" + ActPer.Text + "',ActivityPrice='" + ActPrice.Text  + "' where ActivityID='" + ActID.Text + "'   ";
            SqlCommand com = new SqlCommand(update, conn);
            com.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Done");
            ActName.Text = "";
            ActPer.Text = "";
            ActPrice.Text = "";
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
                    String com = "Delete from [Acctivities] where ActivityID='" + ActID.Text + "'";

                    SqlCommand cmd = new SqlCommand(com, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Done");
                    ActName.Text = "";
                    ActPer.Text = "";
                    ActPrice.Text = "";
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
            String com = "select * from [Acctivities] where ActivityName like '%" + ActName.Text + "%'";

            SqlDataAdapter da = new SqlDataAdapter(com, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Acctivities]");
            ActivGV.DataSource = ds.Tables[0];
        }

       

        private void ActivGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rw = this.ActivGV.Rows[e.RowIndex];
            ActID.Text = rw.Cells["ActivityID"].Value.ToString();
            ActName.Text = rw.Cells["ActivityName"].Value.ToString();
            ActPer.Text = rw.Cells["ActivityPeriod"].Value.ToString();
            ActPrice.Text = rw.Cells["ActivityPrice"].Value.ToString();
        }
        private void UserBtn_Click(object sender, EventArgs e)
        {
            UsersForm fr = new UsersForm();
            this.Hide();
            fr.Show();
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

        private void FoodBtn_Click(object sender, EventArgs e)
        {
            Food fr = new Food();
            fr.Show();
            this.Hide();
        }

        private void X_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutLable_Click(object sender, EventArgs e)
        {
            LogInForm fr = new LogInForm();
            this.Hide();
            fr.Show();
        }
    }

}
