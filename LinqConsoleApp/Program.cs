using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindDataContext db = new NorthwindDataContext();

            #region Insert
            //Employee e = new Employee();
            //e.FirstName = "Ali";
            //e.LastName = "Veli";
            //e.City = "Istanbul";
            //e.Address = "Şişli";
            //e.HomePhone = "2121112233";

            //db.Employees.InsertOnSubmit(e);
            //db.SubmitChanges();
            #endregion

            #region Update
            //Employee e = db.Employees.FirstOrDefault(I => I.FirstName == "Ali");
            //e.LastName = "qweasd";
            //db.SubmitChanges();


            #endregion
            #region Delete
            //Employee e = db.Employees.FirstOrDefault(I => I.FirstName == "Ali");
            //db.Employees.DeleteOnSubmit(e);
            //db.SubmitChanges();
            #endregion
            #region Query 
            string tip = Properties.Settings.Default["Kayittipi"].ToString();
            int a = 0;
            #endregion

        }
    }
}
