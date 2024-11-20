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
    public partial class Orders : Form
    {
        public Orders()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=desktop-o5cco2r\mssqlserver01;Initial Catalog=ChildCare;Integrated Security=True");
        DataSet ds = new DataSet();

        void refre_data()
        {

            string query = "SELECT * FROM [View_3]";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "View_3");
            OrdersGV.DataSource = ds.Tables[0];

        }

        private void Orders_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'childCareDataSet14.View_3' table. You can move, or remove it, as needed.
            this.view_3TableAdapter.Fill(this.childCareDataSet14.View_3);
            refre_data();

        }

        private void AddToCartBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
