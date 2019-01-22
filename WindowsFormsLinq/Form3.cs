using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLinq
{
    public partial class Form3 : Form
    {
        NorthwindDataContext dc = new NorthwindDataContext();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var cat = from c in dc.Categories
                      select new {c.CategoryID,c.CategoryName };

            
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryId";
            comboBox1.DataSource = cat;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int catId = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                dataGridView1.DataSource = from p in dc.Products where p.CategoryID == catId select p;
                
            }
            catch (Exception)
            {


            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
           int pid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = from p in dc.Products
                         join det in dc.Order_Details on p.ProductID equals det.ProductID
                         join ord in dc.Orders on det.OrderID equals ord.OrderID
                         join ship in dc.Shippers on ord.ShipVia equals ship.ShipperID
                         where p.ProductID == pid
                         select new
                         {
                             p.ProductName,
                             ship.CompanyName,
                             ord.ShipCountry,
                             ord.OrderDate
                         };
            dataGridView2.DataSource = result;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
