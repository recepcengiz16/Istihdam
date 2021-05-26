using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;

namespace Istıhdam
{
    public class Sehirlerdao
    {
        public ArrayList tumsehirlerigetir()
        {
            ArrayList sehirler = new ArrayList();
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = bag;
            komut.CommandText = "select * from sehirler order by sehiradi";
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                Sehirler sehir = new Sehirler();
                sehir.Plaka = Convert.ToByte(oku["plaka"]);
                sehir.Sehiradi = oku["sehiradi"].ToString();
                sehirler.Add(sehir);
            }
            oku.Close();
            bag.Close();
            return sehirler;
        }
    }
}