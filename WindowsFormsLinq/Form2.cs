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
    public partial class Form2 : Form
    {
        NorthwindDataContext dc = new NorthwindDataContext();
        string kayitTipi = ConfigurationManager.AppSettings["KayitTipi"];
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kayitTipi == "Linq")
            {
                
            }
            else
            {

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = Param.UserName;

            var q = from emp in dc.Employees
                    join o in dc.Orders on emp.EmployeeID equals     o.EmployeeID
                    where emp.FirstName == Param.UserName
                    select new
                    {
                        emp.FirstName,
                        emp.LastName,
                        o.OrderDate
                    };
            dataGridView1.DataSource = q;
            //var q = from c in dc.Customers
            //        join o in dc.Orders on c.CustomerID equals o.CustomerID
            //        join det in dc.Order_Details on o.OrderID equals det.OrderID
            //        join p in dc.Products on det.ProductID equals p.ProductID
            //        select new
            //        {
            //            c.ContactName,
            //            o.OrderDate,
            //            p.ProductName,
            //            det.Quantity,
            //            det.UnitPrice

            //        };

            dataGridView1.DataSource = q;
        }
    }
}
