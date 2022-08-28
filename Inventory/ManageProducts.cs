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
    public partial class ManageProducts : Form
    {
        public ManageProducts()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Raphael Baddoo\Documents\Database.mdf;Integrated Security=True;Connect Timeout=30");
        void fillcategory()
        {
            string query = "select * from CategoryTb1";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            try
            {
                Con.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("CatName", typeof(string));
                rdr = cmd.ExecuteReader();
                dt.Load(rdr);
                CatCombo.ValueMember = "CatName";
                CatCombo.DataSource = dt;
                Con.Close();
            }
            catch
            {

            }
        }
        private void ManageProducts_Load(object sender, EventArgs e)
        {
            fillcategory();
            populate();
        }
        void populate()
        {
            try
            {
                Con.Open();
                string Myquery = "select * from ProductTb1";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                ProductGV.DataSource = ds.Tables[0];
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
                SqlCommand cmd = new SqlCommand("insert into ProductTb1 values('" + ProductIdTb.Text + "','" + ProductNameTb.Text + "','" + ProductQtyTb.Text + "','" + ProductPriceTb.Text + "','" + ProductDescTb.Text + "','" + CatCombo.SelectedValue.ToString() + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Successfully Added");

                Con.Close();
                populate();

            }
            catch
            {

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Con.Close();
            Con.Open();
            SqlCommand cmd = new SqlCommand("update ProductTb1 set ProdName='" + ProductNameTb .Text + "',ProdQty='" + ProductQtyTb .Text + "',ProdPrice='" + ProductPriceTb.Text + "',ProdDesc='" + ProductDescTb.Text + "',ProdCat='" + CatCombo.SelectedValue.ToString() + "' where ProdtId='" + ProductIdTb.Text + "'", Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Category Successfully Updated");

            Con.Close();
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ProductIdTb.Text == "")
            {
                MessageBox.Show("Enter the Product ID");
            }
            else
            {
                Con.Close();
                Con.Open();
                string myquery = "delete from ProductTb1 where ProdtId= '" + ProductIdTb.Text + "'";
                SqlCommand cmd = new SqlCommand(myquery, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Successfully Deleted");
                Con.Close();
                populate();
            }
        }
    }
}
