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
    public partial class Child : Form
    {
        public Child()
        {
            InitializeComponent();
        }

        //تعريف متغير من نوع قاعدة بيانات فيه معرفة قاعدة البيانات حتى نقوم بربطها بالواجهة
        SqlConnection conn = new SqlConnection(@"Data Source=desktop-o5cco2r\mssqlserver01;Initial Catalog=ChildCare;Integrated Security=True");
        DataSet ds = new DataSet();

        void refre_data()
        {

            string query = "SELECT * FROM [View_1] ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[View_1]");
            ChildGV.DataSource = ds.Tables[0];

        }

        void refre_parentData()
        {

            string query = "SELECT * FROM [Parents] ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Parents]");
            gunaDataGridView1.DataSource = ds.Tables[0];

        }

        private void Child_Load(object sender, EventArgs e)
        {
            refre_data();
            refre_parentData();
        }


        private void EditBtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            string update = "Update [Childs] set ChildName='" + ChildText.Text + "', Gender='" + ChildGenderCombo.Text + "',DateofBirth='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' where ChildID='" + ChildID.Text + "'   ";
            SqlCommand com = new SqlCommand(update, conn);
            com.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Done");
            ChildText.Text = "";
            ChildGenderCombo.Text = "";
            refre_data();
        }


        private void EditCatgBtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            string update = "Update [Parents] set ParentName='" + ParentText.Text + "', Address='" + ParentAddressText.Text + "',Phone='" + ParentPhoneText.Text + "'  where ParentID='" + ParentID.Text + "'   ";
            SqlCommand com = new SqlCommand(update, conn);
            com.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Done");
           ParentID.Text = "";
            ParentText.Text = "";
            ParentAddressText.Text = "";
            ParentPhoneText.Text = "";
            refre_parentData();
            refre_data();

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
                    String com = "Delete from [Parents] where ParentID='" + ParentID.Text + "'";

                    SqlCommand cmd = new SqlCommand(com, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Done");
                    ParentID.Text = "";
                    ParentText.Text = "";
                    ParentAddressText.Text = "";
                    ParentPhoneText.Text = "";
                    refre_parentData();
                }
                else
                    MessageBox.Show("Try again");

            }
            catch
            {
                MessageBox.Show("Try again ", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void SearchParentBtn_Click(object sender, EventArgs e)
        {

            String com = "select * from [Parents] where ParentName like '%" + ParentText.Text + "%'";

            SqlDataAdapter da = new SqlDataAdapter(com, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Parents]");
            gunaDataGridView1.DataSource = ds.Tables[0];
        }

        private void CategEditBtn_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

       

        private void AddCategBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=desktop-o5cco2r\mssqlserver01;Initial Catalog=ChildCare;Integrated Security=True");

            if (ParentText.Text == "" || ParentAddressText.Text == "" || ParentPhoneText.Text == "")
            {
                MessageBox.Show("Fill  The Field");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Insert into [Parents] values('" + ParentText.Text + "','" + ParentAddressText.Text + "','" + ParentPhoneText.Text + "')", conn);
                conn.Open();
                int x = cmd.ExecuteNonQuery();
                conn.Close();
                if (x > 0)
                    MessageBox.Show("Added successfully");
                else
                    MessageBox.Show("not added .. Try again");
                 conn.Close();
                refre_parentData();
            }
        }

        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rw = this.gunaDataGridView1.Rows[e.RowIndex];
            ParentID.Text = rw.Cells["ParentID"].Value.ToString();
            ParentText.Text = rw.Cells["ParentName"].Value.ToString();
            ParentAddressText.Text = rw.Cells["Address"].Value.ToString();
            ParentPhoneText.Text = rw.Cells["Phone"].Value.ToString();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=desktop-o5cco2r\mssqlserver01;Initial Catalog=ChildCare;Integrated Security=True");

            if (ChildText.Text == "" || ChildGenderCombo.Text == "")
            {
                MessageBox.Show("Fill All The Fields");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Insert into [Childs] values('" + ChildText.Text + "','" + ChildGenderCombo.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '" + ParentTextBox.Text + "')", conn) ;
                conn.Open();
                int x = cmd.ExecuteNonQuery();
                conn.Close();

                if (x > 0)
                    MessageBox.Show("Added successfully");
                else
                    MessageBox.Show("not added .. Try again");
                ChildText.Text = "";
                ChildGenderCombo.Text = "";
                conn.Close();
                refre_data();

            }
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
                    String com = "Delete from [Childs] where ChildID='" + ChildID.Text + "'";

                    SqlCommand cmd = new SqlCommand(com, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Done");
                    ChildText.Text = "";
                    ChildGenderCombo.Text = "";
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
            String com = "select * from [Childs] where ChildName like '%" + ChildText.Text + "%'";

            SqlDataAdapter da = new SqlDataAdapter(com, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Acctivities]");
            ChildGV.DataSource = ds.Tables[0];
        }

        private void ChildGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow rw = this.ChildGV.Rows[e.RowIndex];
            ChildID.Text = rw.Cells["ChildID"].Value.ToString();
            ChildText.Text = rw.Cells["ChildName"].Value.ToString();
            ChildGenderCombo.Text = rw.Cells["Gender"].Value.ToString();
            dateTimePicker1.Text = rw.Cells["DateofBirth"].Value.ToString();
            ParentTextBox.Text = rw.Cells["ParentID"].Value.ToString();
        }

        private void CloseCateg_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = false;
            ParentTextBox.Text = (ParentID.Text);
        }

        private void SearchParentBtn_Click_1(object sender, EventArgs e)
        {
            String com = "select * from [Parents] where ParentName like '%" + ParentText.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(com, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Parents]");
            gunaDataGridView1.DataSource = ds.Tables[0];
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

        private void logoutLable_Click(object sender, EventArgs e)
        {
            LogInForm fr = new LogInForm();
            this.Hide();
            fr.Show();
        }
    }
        }
    

