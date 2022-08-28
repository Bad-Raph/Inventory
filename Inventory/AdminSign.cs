using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class AdminSign : Form
    {
        public AdminSign()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin adminLogin = new AdminLogin();
            adminLogin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductCategories  productCategories = new ProductCategories();
            productCategories.Show();
        }
    }
}
