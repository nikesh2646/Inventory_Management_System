using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{

    public partial class MasterForm : Form
    {
        public MasterForm()
        {
            InitializeComponent();
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StockForm stockForm = new StockForm();
            stockForm.MdiParent = this;
            stockForm.Show();
            
            
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ProductsForm productsForm = new ProductsForm();
            productsForm.MdiParent = this;
            productsForm.Show();
            
            

        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            SuppliersForm suppliersForm = new SuppliersForm();
            suppliersForm.MdiParent = this;
            suppliersForm.Show();
            
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSupliers_Click(object sender, EventArgs e)
        {
            SuppliersForm supliersForm = new SuppliersForm();
            supliersForm.MdiParent = this;
            supliersForm.Show();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            StockForm stockForm = new StockForm();
            stockForm.MdiParent = this;
            stockForm.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports report = new Reports();
            report.MdiParent = this;
            report.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
