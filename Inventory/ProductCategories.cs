using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Inventory
{
    public partial class ProductCategories : Form
    {
        public ProductCategories()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Raphael Baddoo\Documents\Database.mdf;Integrated Security=True;Connect Timeout=30");
        void populate()
        {
            try
            {
                Con.Open();
                string Myquery = "select * from CategoryTb1";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                CategoriesGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }
            private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into CategoryTb1 values('" + CatIdTb.Text + "','" + CatNameTb.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Successfully Added");

                Con.Close();
                populate();

            }
            catch
            {

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CatIdTb.Text == "")
            {
                MessageBox.Show("Enter the Category ID");
            }
            else
            {
                Con.Close();
                Con.Open();
                string myquery = "delete from CategoryTb1 where CatId= '" + CatIdTb.Text + "'";
                SqlCommand cmd = new SqlCommand(myquery, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Successfully Deleted");
                Con.Close();
                populate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
           
                Con.Close();
                Con.Open();
                SqlCommand cmd = new SqlCommand("update CategoryTb1 set CategoriesName='" +  CatNameTb.Text + "' where CatId='" + CatIdTb.Text + "'", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Successfully Updated");

                Con.Close();
                populate();

                   }

        private void ProductCategories_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void CategoriesGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CatIdTb.Text = CategoriesGV.SelectedRows[0].Cells[0].Value.ToString();
            CatNameTb.Text = CategoriesGV.SelectedRows[0].Cells[1].Value.ToString();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();  
        }

        private void CategoriesGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.CategoriesGV.Rows[e.RowIndex];
            CatIdTb.Text=row.Cells[0].Value.ToString();
            CatNameTb.Text= row.Cells[1].Value.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageProducts manageProducts = new ManageProducts();
            manageProducts.Show();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductCategories productCategories = new ProductCategories();
            productCategories.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageUsers manageUsers = new ManageUsers();
            manageUsers.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Page2 page2 = new Page2();
            page2.Show();
        }
    }
}
