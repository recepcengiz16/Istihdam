using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Istıhdam
{
    public class Connectionyapici
    {
        public SqlConnection baglantiyagec()
        {
            SqlConnection bag = new SqlConnection();
            bag.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ISTIHDAM.mdf;Integrated Security=True";
            return bag;
        }
    }
}