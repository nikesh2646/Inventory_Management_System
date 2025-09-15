using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class Reports : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\MyData\M6- Project\InventoryManagementSystem\InventoryDB1.mdf"";Integrated Security=True");
        public Reports()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from ProductsTable", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            MessageBox.Show("Products Report Generated", "Inventory Management System");
        }

        private void button2_Click(object sender, EventArgs e)
        {
           if(radioButton1.Checked)
            {
                SqlDataAdapter da2 = new SqlDataAdapter("Select * from ProductsTable where Quantity <=5", con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                dataGridView1.DataSource = dt2;
            }
           else if(radioButton2.Checked)
           {
                SqlDataAdapter da2 = new SqlDataAdapter("Select * from ProductsTable where Quantity >=5", con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                dataGridView1.DataSource = dt2;
           }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from StockTransactionTable", con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView1.DataSource = dt3;
            MessageBox.Show("Stock Transactions Report Generated", "Inventory Management System");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
