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

    public partial class GirisFormu : Form
    {
        NorthwindDataContext dc = new NorthwindDataContext();
        public GirisFormu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            


            #region Database işlemleri

            Employee q = dc.Employees.FirstOrDefault(I=>I.FirstName==textBox1.Text);
                    #endregion
            Param.UserName = q.FirstName ;
            Param.KayitTipi = "asdasd";
            Param.UserID = q.EmployeeID;
            Form2 frm = new Form2();
            frm.Show();
        }
    }
}
