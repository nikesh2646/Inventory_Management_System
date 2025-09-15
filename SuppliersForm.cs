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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InventoryManagementSystem
{
    public partial class SuppliersForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\MyData\M6- Project\InventoryManagementSystem\InventoryDB1.mdf"";Integrated Security=True");
        public SuppliersForm()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cleartext();
            txtSupplierID.Enabled = true;
            txtSupplierID.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into SuppliersTable values('" + txtSupplierID.Text + "','" + txtName.Text + "','" + txtContact.Text + "','" + txtEmail.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            Display_data();
            MessageBox.Show("Record Inserted Successfully");
            cleartext();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtSupplierID.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtContact.Text = row.Cells[2].Value.ToString();
                txtEmail.Text = row.Cells[3].Value.ToString();
            }
            txtSupplierID.Enabled = false;
        }
        private void cleartext()
        {
            txtSupplierID.Text = "";
            txtName.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtSupplierID.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SuppliersForm_Load(object sender, EventArgs e)
        {
            Display_data();
          

        }
        public void Display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from SuppliersTable";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            Display_data();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update SuppliersTable set Name='" + txtName.Text + "' where SupplierID='" + txtSupplierID.Text + "'update SuppliersTable set Contact= '" + txtContact.Text + "'where SupplierID='" + txtSupplierID.Text + "'update SuppliersTable set Email= '" + txtEmail.Text + "'where SupplierID='" + txtSupplierID.Text + "'";

            cmd.ExecuteNonQuery();
            con.Close();
            Display_data();
            MessageBox.Show("Record Updated Successfully");
            cleartext();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtSupplierID.Text == "")
            {
                MessageBox.Show("Please enter Supplier ID");
            }
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from SuppliersTable where SupplierID='" + txtSupplierID.Text + "'";

                cmd.ExecuteNonQuery();
                con.Close();
                Display_data();
                MessageBox.Show("Record Deleted Successfully");
                cleartext();
            }
        }
    }
}
