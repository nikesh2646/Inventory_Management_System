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
    public partial class StockForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\MyData\M6- Project\InventoryManagementSystem\InventoryDB1.mdf"";Integrated Security=True");
        public StockForm()
        {
            InitializeComponent();
        }

        private void lblTransactiondate_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = comboBox1.Text;
            int CurrentStock = Convert.ToInt32(textBox2.Text);
            int InOutQuantity = Convert.ToInt32(textBox3.Text);
            string TransactionType = comboBox2.Text;
            DateTime TransactionDate = dateTimePicker1.Value;

            int newStock = CurrentStock;

            if (TransactionType == "IN")
            {
                newStock = CurrentStock + InOutQuantity;
            }
            else //if (TransactionType == "OUT")
            {
                if (CurrentStock >= InOutQuantity)
                {
                    newStock = CurrentStock - InOutQuantity;
                }
            }
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update ProductsTable set Quantity='" + newStock + "' where Name='" + Name + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Quantity Updated Successfully");


                con.Open();
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into StockTransactionTable values('" + Name + "','" + InOutQuantity + "','" + TransactionType + "','" + TransactionDate + "','" + newStock +"')";
                cmd1.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Transaction Record Saved Successful");
                Display_data();
        }
        public void Display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from StockTransactionTable";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           cleartext();
        }
        private void cleartext()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            dateTimePicker1 = null;
            comboBox2.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Name from ProductsTable";
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader["Name"].ToString());
            }
            con.Close();
            Display_data();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Display_data();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Quantity from ProductsTable where Name='" + comboBox1.SelectedItem.ToString() + "'";
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                textBox3.Text = reader["Quantity"].ToString();
            }
            con.Close();
        }
    }
}
