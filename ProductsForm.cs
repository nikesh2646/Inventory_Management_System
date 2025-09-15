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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InventoryManagementSystem
{
    public partial class ProductsForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\MyData\M6- Project\InventoryManagementSystem\InventoryDB1.mdf"";Integrated Security=True");

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            Display_data();
        }
        public void Display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from ProductsTable";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
        public ProductsForm()
        {
            InitializeComponent();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtCategory.Text = row.Cells["Category"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                
                txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
            }
            txtName.Enabled = false;
        }
        private void cleartext()
        {
            txtProductID.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtCategory.Text = "";
            txtQuantity.Text = "";
            txtProductID.Focus();
        }
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            cleartext();
            txtProductID.Focus();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtProductID.Text = row.Cells["ProductID"].Value.ToString();
                txtName.Text = row.Cells["ProductName"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                txtCategory.Text = row.Cells["Category"].Value.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
            }
            txtProductID.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into ProductsTable values('" + txtProductID.Text + "','" + txtName.Text + "','" + txtCategory.Text + "','" + txtPrice.Text + "','" + txtQuantity.Text + "')";

            cmd.ExecuteNonQuery();
            

            Display_data();
            con.Close();
            MessageBox.Show("Record Inserted Successfully");

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update ProductsTable set Name='" + txtName.Text + "'where ProductID='" + txtProductID.Text + "'update ProductsTable set Category= '" + txtCategory.Text + "'where ProductID='" + txtProductID.Text + "'update ProductsTable set Price= '" + txtPrice.Text + "'where ProductID='" + txtProductID.Text + "'update ProductsTable set Quantity= '" + txtQuantity.Text + "'where ProductID='" + txtProductID.Text + "'";

            cmd.ExecuteNonQuery();
            con.Close();

            Display_data();
            MessageBox.Show("Record Updated Successfully");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtProductID.Text == "")
            {
                MessageBox.Show("Please Enter Product ID");
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from ProductsTable where ProductID='" + txtProductID.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                Display_data();
                MessageBox.Show("Record Deleted Successfully");

                cleartext();
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            Display_data();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cleartext();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into ProductsTable values('" + txtProductID.Text + "','" + txtName.Text + "','" + txtCategory.Text + "','" + txtPrice.Text + "','" + txtQuantity.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            Display_data();
            MessageBox.Show("Record Inserted Successfully");
            cleartext();
        }

        private void btnUpdate_Click_2(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update ProductsTable set Name='" + txtName.Text + "'where ProductID='" + txtProductID.Text + "'update ProductsTable set Category= '" + txtCategory.Text + "'where ProductID='" + txtProductID.Text + "'update ProductsTable set Price= '" + txtPrice.Text + "'where ProductID='" + txtProductID.Text + "'update ProductsTable set Quantity= '" + txtQuantity.Text + "'where ProductID='" + txtProductID.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            Display_data();
            MessageBox.Show("Record Updated Successfully");
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if(txtProductID.Text == "")
            {
                MessageBox.Show("Please Enter Product ID");
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from ProductsTable where ProductID='" + txtProductID.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                Display_data();
                MessageBox.Show("Record Deleted Successfully");
                cleartext();
            }
        }

        private void btnRefresh_Click_2(object sender, EventArgs e)
        {
            Display_data();
        }
    }
}

