using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace WindowsFormsLinq
{
    public partial class Form1 : Form
    {
        NorthwindDataContext dc = new NorthwindDataContext();
        string value = ConfigurationManager.AppSettings["KayitTipi"];
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            var sales = dc.Sales_by_Year(new DateTime(1990, 1, 1), new DateTime(2000, 1, 1));

            salesGrid.DataSource = sales;

            var q = from c in dc.Customers select new {c.CustomerID,c.CompanyName };

            dataGridView1.DataSource = q;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            


            string custId = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            var order = from ord in dc.Orders
                        where ord.CustomerID == custId
                        select ord;

            orderGrid.DataSource = order;

            int detID = Convert.ToInt32(orderGrid.CurrentRow.Cells[0].Value.ToString());

            var detail = from det in dc.Order_Details where det.OrderID == detID select det;

            orderDetGrid.DataSource = detail;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void orderGrid_MouseClick(object sender, MouseEventArgs e)
        {
            OrderDetail();
        }
        public void OrderDetail()
        {

            int detID = Convert.ToInt32(orderGrid.CurrentRow.Cells[0].Value.ToString());

            var detail = from det in dc.Order_Details where det.OrderID == detID select det;

            orderDetGrid.DataSource = detail;
        }
        private void orderGrid_KeyDown(object sender, KeyEventArgs e)
        {
                OrderDetail();
                // do something with selectedCell...
            
        }
    }
}
