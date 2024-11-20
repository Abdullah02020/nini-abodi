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
    public partial class Food : Form
    {
        public Food()
        {
            InitializeComponent();
        }
        //تعريف متغير من نوع قاعدة بيانات فيه معرفة قاعدة البيانات حتى نقوم بربطها بالواجهة
        SqlConnection conn = new SqlConnection(@"Data Source=desktop-o5cco2r\mssqlserver01;Initial Catalog=ChildCare;Integrated Security=True");
        DataSet ds = new DataSet();
      
        void refre_data()
        {

            string query = "SELECT * FROM [View_2] ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[View_2]");
            ItemsGV.DataSource = ds.Tables[0];

        }

        void refre_CategoryData()
        {

            string query = "SELECT * FROM [Catgory] ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Catgory]");
            gunaDataGridView1.DataSource = ds.Tables[0];

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersForm user = new UsersForm();
            user.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Activity order = new Activity();
            order.Show();
            this.Hide();
        }
        

        private void label4_Click(object sender, EventArgs e)
        {
            LogInForm login = new LogInForm();
            login.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ItemsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'childCareDataSet.Catgory' table. You can move, or remove it, as needed.
            this.catgoryTableAdapter.Fill(this.childCareDataSet.Catgory);
            refre_data();
            refre_CategoryData();


        }


             
        private void AddBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=desktop-o5cco2r\mssqlserver01;Initial Catalog=ChildCare;Integrated Security=True");

            if (MealName.Text == "" || MealPrice.Text == "")
            {
                MessageBox.Show("Fill All The Fields");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Insert into Foods values('" + MealName.Text + "','" + MealPrice.Text + "','" + CategCbCompoBox.SelectedValue + "')", conn);
                conn.Open();
                int x = cmd.ExecuteNonQuery();
                conn.Close();

                if (x > 0)
                    MessageBox.Show("Added successfully");
                else
                    MessageBox.Show("not added .. Try again");
                MealName.Text = "";
                MealPrice.Text = "";
                conn.Close();
                refre_data();

            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=desktop-o5cco2r\mssqlserver01;Initial Catalog=ChildCare;Integrated Security=True");

            conn.Open();
            string update = "Update [Foods] set FoodName='" + MealName.Text + "', Price='" + MealPrice.Text + "', CategoryID='" + CategCbCompoBox.SelectedValue + "' where FoodID='" + MealD.Text + "'   ";
            SqlCommand com = new SqlCommand(update, conn);
            com.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Done");
            MealD.Text = "";
            MealName.Text = "";
            MealPrice.Text = "";
            refre_data();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            String com = "select * from [View_2] where FoodName like '%" + MealName.Text + "%'";

            SqlDataAdapter da = new SqlDataAdapter(com, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[View_2]");
            ItemsGV.DataSource = ds.Tables[0];
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
                    String com = "Delete from [Foods] where FoodID='" + MealD.Text + "'";

                    SqlCommand cmd = new SqlCommand(com, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Done");
                    MealD.Text = "";
                    MealName.Text = "";
                    MealPrice.Text = "";
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

        private void ItemsGV_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rw = this.ItemsGV.Rows[e.RowIndex];
            MealD.Text = rw.Cells["FoodID"].Value.ToString();
            MealName.Text = rw.Cells["FoodName"].Value.ToString();
            MealPrice.Text = rw.Cells["Price"].Value.ToString();
            CategCbCompoBox.SelectedValue = rw.Cells["CategoryID"].Value.ToString();
        }

        private void CategEditBtn_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            refre_CategoryData();
        }

        private void AddCategBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=desktop-o5cco2r\mssqlserver01;Initial Catalog=ChildCare;Integrated Security=True");

            if (Categ.Text == "" )
            {
                MessageBox.Show("Fill  The Field");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Insert into Catgory values('" + Categ.Text + "')", conn);
                conn.Open();
                int x = cmd.ExecuteNonQuery();
                conn.Close();

                if (x > 0)
                    MessageBox.Show("Added successfully");
                else
                    MessageBox.Show("not added .. Try again");
                Categ.Text = "";
                conn.Close();
                refre_CategoryData();
            }
        }

        private void EditCatgBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=desktop-o5cco2r\mssqlserver01;Initial Catalog=ChildCare;Integrated Security=True");

            conn.Open();
            string update = "Update [Catgory] set CategoryType='" + Categ.Text + "' where CategoryID='" + CatgID.Text + "'    " ;
            SqlCommand com = new SqlCommand(update, conn);
            com.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Done");
            Categ.Text = "";
            refre_CategoryData();
        }

        private void DeleteCatgBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result;
                result = MessageBox.Show("Do you want delete? ", "Conformation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    conn.Open();
                    String com = "Delete from [Catgory] where CategoryID='" + CatgID.Text + "'";

                    SqlCommand cmd = new SqlCommand(com, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Done");
                    Categ.Text = "";
                    refre_CategoryData();
                }
                else
                    MessageBox.Show("Try again");

            }
            catch
            {
                MessageBox.Show("Try again ", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rw = this.gunaDataGridView1.Rows[e.RowIndex];
            CatgID.Text = rw.Cells["CategoryID"].Value.ToString();
            Categ.Text = rw.Cells["CategoryType"].Value.ToString();
        }

        private void CloseCateg_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            this.catgoryTableAdapter.Fill(this.childCareDataSet.Catgory);
        }

        private void X_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void ActivityBtn_Click(object sender, EventArgs e)
        {
            Activity fr = new Activity();
            this.Hide();
            fr.Show();
        }

        private void logoutLable_Click(object sender, EventArgs e)
        {
            LogInForm fr = new LogInForm();
            this.Hide();
            fr.Show();
        }
    }
}
