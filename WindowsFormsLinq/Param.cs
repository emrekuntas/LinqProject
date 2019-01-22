using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsLinq
{
    public static class Param
    {
        
        private static string  username;

        public static string  UserName
        {
            get { return username; }
            set { username = value; }
        }
        private static string kayitTipi;

        public static string KayitTipi
        {
            get { return kayitTipi; }
            set { kayitTipi = value; }
        }

        private static  int userId;

        public static int UserID
        {
            get { return userId; }
            set { userId = value; }
        }

    }
}
