using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;

namespace Istıhdam
{
    public class Kategorilerdao
    {
        public ArrayList tumkategorilerigetir()
        {
            ArrayList kategorilistesi = new ArrayList();
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = bag;
            komut.CommandText = "select * from kategoriler order by kateadi";
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                Kategoriler kategori = new Kategoriler();
                kategori.Kateno = Convert.ToInt32(oku["kateno"]);
                kategori.Kateadi = oku["kateadi"].ToString();
                kategorilistesi.Add(kategori);
            }
            oku.Close();
            bag.Close();
            return kategorilistesi;
        }

        public ArrayList altkategorilerigetir(int anakateno)
        {
            ArrayList altkategorilistesi = new ArrayList();
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = bag;
            komut.CommandText = "select * from altkategoriler where anakateno=@anakateno order by altkateadi";
            komut.Parameters.AddWithValue("@anakateno", anakateno);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                Altkategoriler altkategori = new Altkategoriler();
                altkategori.Altkateno = Convert.ToInt32(oku["altkateno"]);
                altkategori.Anakateno = Convert.ToInt32(oku["anakateno"]);
                altkategori.Altkateadi = oku["altkateadi"].ToString();
                altkategorilistesi.Add(altkategori);
            }
            oku.Close();
            bag.Close();
            return altkategorilistesi;
        }

        public int kategoriekle(String kateadi)
        {
            int sayi = 0;
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = bag;
            komut.CommandText = "insert into kategoriler(kateadi) values(@kateadi)";
            komut.Parameters.AddWithValue("@kateadi", kateadi);
            sayi = komut.ExecuteNonQuery();
            bag.Close();
            return sayi;
        }

        public int altkategoriekle(int kateno,String altkateadi)
        {
            int sayi = 0;
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = bag;
            komut.CommandText = "insert into altkategoriler(altkateadi,anakateno) values(@altkateadi,@anakateno)";
            komut.Parameters.AddWithValue("@altkateadi", altkateadi);
            komut.Parameters.AddWithValue("@anakateno", kateno);
            sayi = komut.ExecuteNonQuery();
            bag.Close();
            return sayi;
        }
    }
}