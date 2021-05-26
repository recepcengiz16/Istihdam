using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace Istıhdam
{
    public class Urunlerdao
    {
        public int urunekleme(String urunadi,Double fiyat,String aciklama,String resim,int kateno, int altkaeno,int saticiid)
        {
            int sayi = 0;
            try
            {    
                SqlConnection bag = new Connectionyapici().baglantiyagec();
                bag.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = bag;
                komut.CommandText = "insert into urunler(urunadi,fiyat,aciklama,resim,kateno,altkateno,saticiid) values(@urunadi,@fiyat,@aciklama,@resim,@kateno,@altkateno,@saticiid)";
                komut.Parameters.AddWithValue("@urunadi", urunadi);
                komut.Parameters.AddWithValue("@fiyat", fiyat);
                komut.Parameters.AddWithValue("@aciklama", aciklama);
                komut.Parameters.AddWithValue("@resim", resim);
                komut.Parameters.AddWithValue("@kateno", kateno);
                komut.Parameters.AddWithValue("@altkateno", altkaeno);
                komut.Parameters.AddWithValue("@saticiid", saticiid);
                sayi = komut.ExecuteNonQuery();
                bag.Close();
            }
            catch(SqlException)
            {
                sayi = -2;
            }
            catch(Exception)
            {
                sayi = -3;
            }
            return sayi;
        }

        public int sonurunidgetir()
        {
            int sayi = 0;
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = bag;
            komut.CommandText = "select max(urunid) from urunler";
            sayi = Convert.ToInt32(komut.ExecuteScalar());
            bag.Close();               
            return sayi;
        }

        public ArrayList sayfaliurunlerimigetir(int kateno,int altkateno,bool tumu,int baslangic,int saticiid)
        {
            String sql = "";
            if (tumu == false)
            {
               sql = "select * from urunler,kategoriler,altkategoriler,saticilar where urunler.kateno=kategoriler.kateno and urunler.kateno=" + kateno +
                    " and urunler.altkateno=altkategoriler.altkateno and urunler.altkateno=" + altkateno + " and urunler.saticiid=saticilar.saticiid and urunler.saticiid=" + saticiid;
            }
            else
            {
               sql = "select * from urunler,kategoriler,altkategoriler,saticilar where urunler.kateno=kategoriler.kateno and " +
                    "urunler.altkateno=altkategoriler.altkateno and urunler.saticiid=saticilar.saticiid and urunler.saticiid=" + saticiid;
            }
            ArrayList urunlerlistesi = new ArrayList();
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter(sql, bag);
            DataSet ds = new DataSet();
            adaptor.Fill(ds, baslangic, 4, "urunlerim");
            foreach (DataRow satir in ds.Tables["urunlerim"].Rows)
            {
                Urun yeniurun = new Urun();
                yeniurun.Urunid = Convert.ToInt32(satir["urunid"]);
                yeniurun.Urunadi = satir["urunadi"].ToString();
                yeniurun.Fiyat = Convert.ToDouble(satir["fiyat"]);
                yeniurun.Aciklama = satir["aciklama"].ToString();
                yeniurun.Resim = satir["resim"].ToString();
                
                Kategoriler kate = new Kategoriler();
                kate.Kateadi = satir["kateadi"].ToString();
                kate.Kateno = Convert.ToInt32(satir["kateno"]);
                yeniurun.Kateno = kate;
                
                Altkategoriler altkate = new Altkategoriler();
                altkate.Altkateadi = satir["altkateadi"].ToString();
                altkate.Altkateno = Convert.ToInt32(satir["altkateno"]);
                altkate.Anakateno = Convert.ToInt32(satir["anakateno"]);
                yeniurun.Altkategorino = altkate;

                Saticilar satici = new Saticilar();
                satici.Saticiid = Convert.ToInt32(satir["saticiid"]);
                satici.Saticiad = satir["saticiad"].ToString();
                satici.Saticisoyad = satir["saticisoyad"].ToString();
                satici.Adres = satir["adres"].ToString();
                satici.Email = satir["email"].ToString();
                yeniurun.Saticiid = satici;
                urunlerlistesi.Add(yeniurun);
            }
            bag.Close();
            return urunlerlistesi;
        }

        public int urunleriminsayisigetir(int kateno,int altkateno,int saticiid,bool tumu)
        {
            int sayi = 0;
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = bag;
            if (tumu == true)
            {
                komut.CommandText = "select count(*) from urunler where saticiid=@saticiid";
                komut.Parameters.AddWithValue("@saticiid", saticiid);
            }
            else if(tumu==false)
            {
                komut.CommandText = "select count(*) from urunler where kateno=@kateno and altkateno=@altkateno and saticiid=@saticiid";
                komut.Parameters.AddWithValue("@kateno", kateno);
                komut.Parameters.AddWithValue("@altkateno", altkateno);
                komut.Parameters.AddWithValue("@saticiid", saticiid);
            }
            sayi = Convert.ToInt32(komut.ExecuteScalar());
            bag.Close();
            return sayi;
        }

        public int urunsil(int urunid,int saticiid)
        {
            int sayi = 0;
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = bag;
            komut.CommandText = "delete from urunler where urunid=@urunid and saticiid=@saticiid";
            komut.Parameters.AddWithValue("@urunid", urunid);
            komut.Parameters.AddWithValue("@saticiid", saticiid);
            sayi = komut.ExecuteNonQuery();
            bag.Close();
            return sayi;
        }

        public Urun tekurungetir(int urunid,int saticiid)
        {
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = bag;
            komut.CommandText = "select * from urunler,kategoriler,altkategoriler,saticilar where urunler.kateno=kategoriler.kateno and " +
                    "urunler.altkateno=altkategoriler.altkateno and urunler.saticiid=saticilar.saticiid and urunler.urunid=@urunid and urunler.saticiid=@saticiid";
            komut.Parameters.AddWithValue("@urunid", urunid);
            komut.Parameters.AddWithValue("@saticiid", saticiid);
            SqlDataReader oku = komut.ExecuteReader();
            oku.Read();
            Urun yeniurun = new Urun();
            yeniurun.Urunid = Convert.ToInt32(oku["urunid"]);
            yeniurun.Urunadi = oku["urunadi"].ToString();
            yeniurun.Fiyat = Convert.ToDouble(oku["fiyat"]);
            yeniurun.Aciklama = oku["aciklama"].ToString();
            yeniurun.Resim = oku["resim"].ToString();

            Kategoriler kate = new Kategoriler();
            kate.Kateadi = oku["kateadi"].ToString();
            kate.Kateno = Convert.ToInt32(oku["kateno"]);
            yeniurun.Kateno = kate;

            Altkategoriler altkate = new Altkategoriler();
            altkate.Altkateadi = oku["altkateadi"].ToString();
            altkate.Altkateno = Convert.ToInt32(oku["altkateno"]);
            altkate.Anakateno = Convert.ToInt32(oku["anakateno"]);
            yeniurun.Altkategorino = altkate;

            Saticilar satici = new Saticilar();
            satici.Saticiid = Convert.ToInt32(oku["saticiid"]);
            satici.Saticiad = oku["saticiad"].ToString();
            satici.Saticisoyad = oku["saticisoyad"].ToString();
            satici.Adres = oku["adres"].ToString();
            satici.Email = oku["email"].ToString();
            yeniurun.Saticiid = satici;
            bag.Close();
            return yeniurun;
        }

        public int urunuguncelle(String urunadi, Double fiyat, String aciklama, String resim, int kateno, int altkaeno,int urunid)
        {
            int sayi = 0;
            try
            {
                SqlConnection bag = new Connectionyapici().baglantiyagec();
                bag.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = bag;
                String sql = "";
                if (resim == "")
                {
                    sql = "update urunler set urunadi=@urunadi,fiyat=@fiyat,aciklama=@aciklama,kateno=@kateno,altkateno=@altkateno where urunid=@urunid";
                    komut.CommandText = sql;
                }
                else if(resim!=null)
                {
                    sql = "update urunler set urunadi=@urunadi,fiyat=@fiyat,aciklama=@aciklama,resim=@resim,kateno=@kateno,altkateno=@altkateno where urunid=@urunid";
                    komut.CommandText = sql;
                    komut.Parameters.AddWithValue("@resim", resim);
                }
                komut.Parameters.AddWithValue("@urunadi", urunadi);
                komut.Parameters.AddWithValue("@fiyat", fiyat);
                komut.Parameters.AddWithValue("@aciklama", aciklama);      
                komut.Parameters.AddWithValue("@kateno", kateno);
                komut.Parameters.AddWithValue("@altkateno", altkaeno);
                komut.Parameters.AddWithValue("@urunid", urunid);
                sayi = komut.ExecuteNonQuery();
                bag.Close();
            }
            catch (Exception)
            {
                sayi = -2;
            }
            return sayi;
        }

        public ArrayList sayfaliurunlergetir(int kateno, int altkateno, int baslangic)
        {

            String sql = "select * from urunler,kategoriler,altkategoriler where urunler.kateno=kategoriler.kateno and urunler.kateno=" + kateno +
                     " and urunler.altkateno=altkategoriler.altkateno and urunler.altkateno=" + altkateno;
            ArrayList urunlerlistesi = new ArrayList();
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter(sql, bag);
            DataSet ds = new DataSet();
            adaptor.Fill(ds, baslangic, 9, "urunlerim");
            foreach (DataRow satir in ds.Tables["urunlerim"].Rows)
            {
                Urun yeniurun = new Urun();
                yeniurun.Urunid = Convert.ToInt32(satir["urunid"]);
                yeniurun.Urunadi = satir["urunadi"].ToString();
                yeniurun.Fiyat = Convert.ToDouble(satir["fiyat"]);
                yeniurun.Aciklama = satir["aciklama"].ToString();
                yeniurun.Resim = satir["resim"].ToString();

                Kategoriler kate = new Kategoriler();
                kate.Kateadi = satir["kateadi"].ToString();
                kate.Kateno = Convert.ToInt32(satir["kateno"]);
                yeniurun.Kateno = kate;

                Altkategoriler altkate = new Altkategoriler();
                altkate.Altkateadi = satir["altkateadi"].ToString();
                altkate.Altkateno = Convert.ToInt32(satir["altkateno"]);
                altkate.Anakateno = Convert.ToInt32(satir["anakateno"]);
                yeniurun.Altkategorino = altkate;
                urunlerlistesi.Add(yeniurun);
            }
            bag.Close();
            return urunlerlistesi;
        }

        public int urunsayisigetir(int altkateno)
        {
            int sayi = 0;
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = bag;              
            komut.CommandText = "select count(*) from urunler where altkateno=@altkateno";
            komut.Parameters.AddWithValue("@altkateno", altkateno);        
            sayi = Convert.ToInt32(komut.ExecuteScalar());
            bag.Close();
            return sayi;
        }

        public Urun musteritekurungetir(int urunid)
        {
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = bag;
            komut.CommandText = "select * from urunler,kategoriler,altkategoriler where urunler.kateno=kategoriler.kateno and " +
                    "urunler.altkateno=altkategoriler.altkateno and urunler.urunid=@urunid";
            komut.Parameters.AddWithValue("@urunid", urunid);
            SqlDataReader oku = komut.ExecuteReader();
            oku.Read();
            Urun yeniurun = new Urun();
            yeniurun.Urunid = Convert.ToInt32(oku["urunid"]);
            yeniurun.Urunadi = oku["urunadi"].ToString();
            yeniurun.Fiyat = Convert.ToDouble(oku["fiyat"]);
            yeniurun.Aciklama = oku["aciklama"].ToString();
            yeniurun.Resim = oku["resim"].ToString();

            Kategoriler kate = new Kategoriler();
            kate.Kateadi = oku["kateadi"].ToString();
            kate.Kateno = Convert.ToInt32(oku["kateno"]);
            yeniurun.Kateno = kate;

            Altkategoriler altkate = new Altkategoriler();
            altkate.Altkateadi = oku["altkateadi"].ToString();
            altkate.Altkateno = Convert.ToInt32(oku["altkateno"]);
            altkate.Anakateno = Convert.ToInt32(oku["anakateno"]);
            yeniurun.Altkategorino = altkate;
            bag.Close();
            return yeniurun;
        }

        public Urun resimgetir(int urunid)
        {
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = bag;
            komut.CommandText = "select * from urunler where urunid=@urunid";
            komut.Parameters.AddWithValue("@urunid", urunid);
            SqlDataReader oku = komut.ExecuteReader();
            oku.Read();
            Urun yeniurun = new Urun();
            yeniurun.Resim = oku["resim"].ToString();       
            bag.Close();
            return yeniurun;
            
        }
    }
}