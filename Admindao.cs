using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Istıhdam
{
    public class Admindao
    {
        public ArrayList saticilarigetir(int baslangic)
        {

            String sql = "select * from saticilar,sehirler where saticilar.plaka=sehirler.plaka";
            ArrayList saticilar = new ArrayList();
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter(sql, bag);
            DataSet ds = new DataSet();
            adaptor.Fill(ds, baslangic, 10, "saticilartable");
            foreach (DataRow satir in ds.Tables["saticilartable"].Rows)
            {
                Saticilar satici = new Saticilar();
                satici.Adres = satir["adres"].ToString();
                satici.Dogtar = Convert.ToDateTime(satir["dogtar"]);
                satici.Email = satir["email"].ToString();
                satici.Kuladi = satir["kuladi"].ToString();
                satici.Saticiad = satir["saticiad"].ToString();
                satici.Saticiid = Convert.ToInt32(satir["saticiid"]);
                satici.Saticisoyad = satir["saticisoyad"].ToString();
                satici.Sifre = satir["sifre"].ToString();
                satici.Telefon = satir["telefon"].ToString();

                Sehirler sehir = new Sehirler();
                sehir.Plaka = Convert.ToByte(satir["plaka"]);
                sehir.Sehiradi = satir["sehiradi"].ToString();
                satici.Plaka = sehir;
                saticilar.Add(satici);
            }
            bag.Close();
            return saticilar;
        }

        public int saticisayisigetir()
        {
            int sayi = 0;
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = bag;
            komut.CommandText = "select count(*) from saticilar";
            sayi = Convert.ToInt32(komut.ExecuteScalar());
            bag.Close();
            return sayi;
        }

        public int saticisil(int saticiid)
        {
            int sayi = 0;
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = bag;
            komut.CommandText = "delete from saticilar where saticiid=@saticiid";
            komut.Parameters.AddWithValue("@saticiid", saticiid);
            sayi = Convert.ToInt32(komut.ExecuteNonQuery());
            bag.Close();
            return sayi;
        }

        public int saticiguncelle(String ad, String soyad, String kuladi, String sifre, String email, String telefon, String adres, byte plaka, String dogtar, int uyeid)
        {
            int sayi = 0;
            try
            {
                SqlConnection bag = new Connectionyapici().baglantiyagec();
                bag.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = bag;
                komut.CommandText = "update saticilar set saticiad=@saticiad,saticisoyad=@saticisoyad,kuladi=@kuladi,sifre=@sifre,email=@email,telefon=@telefon,adres=@adres,plaka=@plaka,dogtar=@dogtar where saticiid=@saticiid";
                komut.Parameters.AddWithValue("@kuladi", kuladi);
                komut.Parameters.AddWithValue("@sifre", sifre);
                komut.Parameters.AddWithValue("@saticiad", ad);
                komut.Parameters.AddWithValue("@saticisoyad", soyad);
                komut.Parameters.AddWithValue("@email", email);
                komut.Parameters.AddWithValue("@adres", adres);
                komut.Parameters.AddWithValue("@plaka", plaka);
                komut.Parameters.AddWithValue("@telefon", telefon);
                komut.Parameters.AddWithValue("@dogtar", Convert.ToDateTime(dogtar));
                komut.Parameters.AddWithValue("@saticiid", uyeid);
                sayi = komut.ExecuteNonQuery();
                bag.Close();

            }
            catch (SqlException hata)
            {
                if (hata.Message.IndexOf("kuladi") != -1) sayi = -2;
                else if (hata.Message.IndexOf("email") != -1) sayi = -3;
            }
            catch (Exception)
            {
                sayi = -4;
            }
            return sayi;
        }

        public ArrayList musterilerigetir(int baslangic)
        {

            String sql = "select * from musteriler,sehirler where musteriler.plaka=sehirler.plaka";
            ArrayList musteriler = new ArrayList();
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter(sql, bag);
            DataSet ds = new DataSet();
            adaptor.Fill(ds, baslangic, 10, "musterilertable");
            foreach (DataRow satir in ds.Tables["musterilertable"].Rows)
            {
                Musteriler musteri = new Musteriler();
                musteri.Adres = satir["adres"].ToString();
                musteri.Dogtar = Convert.ToDateTime(satir["dogtar"]);
                musteri.Email = satir["email"].ToString();
                musteri.Kuladi = satir["kuladi"].ToString();
                musteri.Adsoyad = satir["adsoyad"].ToString();
                musteri.Uyeid = Convert.ToInt32(satir["uyeid"]);
                musteri.Sifre = satir["sifre"].ToString();
                musteri.Telefon = satir["telefon"].ToString();

                Sehirler sehir = new Sehirler();
                sehir.Plaka = Convert.ToByte(satir["plaka"]);
                sehir.Sehiradi = satir["sehiradi"].ToString();
                musteri.Plaka = sehir;
                musteriler.Add(musteri);
            }
            bag.Close();
            return musteriler;
        }

        public int musterisayisigetir()
        {
            int sayi = 0;
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = bag;
            komut.CommandText = "select count(*) from musteriler";
            sayi = Convert.ToInt32(komut.ExecuteScalar());
            bag.Close();
            return sayi;
        }

        public int musterisil(int uyeid)
        {
            int sayi = 0;
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = bag;
            komut.CommandText = "delete from musteriler where uyeid=@uyeid";
            komut.Parameters.AddWithValue("@uyeid", uyeid);
            sayi = Convert.ToInt32(komut.ExecuteNonQuery());
            bag.Close();
            return sayi;
        }

        public int musteriguncelle(String adsoyad, String email, String telefon, byte plaka, String dogtar, String adres, String kuladi, String sifre, int uyeid)
        {
            int sayi = 0;
            try
            {
                SqlConnection bag = new Connectionyapici().baglantiyagec();
                bag.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = bag;
                komut.CommandText = "update musteriler set adsoyad=@adsoyad,email=@email,telefon=@telefon,plaka=@plaka,dogtar=@dogtar,adres=@adres,kuladi=@kuladi,sifre=@sifre where uyeid=@uyeid";
                komut.Parameters.AddWithValue("@adsoyad", adsoyad);
                komut.Parameters.AddWithValue("@email", email);
                komut.Parameters.AddWithValue("@telefon", telefon);
                komut.Parameters.AddWithValue("@plaka", plaka);
                komut.Parameters.AddWithValue("@dogtar", Convert.ToDateTime(dogtar).ToShortDateString());
                komut.Parameters.AddWithValue("@adres", adres);
                komut.Parameters.AddWithValue("@kuladi", kuladi);
                komut.Parameters.AddWithValue("@sifre", sifre);
                komut.Parameters.AddWithValue("@uyeid", uyeid);
                sayi = komut.ExecuteNonQuery();
                bag.Close();
            }
            catch (SqlException hata)
            {
                if (hata.Message.IndexOf("kuladi") != -1) sayi = -2;
                else if (hata.Message.IndexOf("email") != -1) sayi = -3;
            }
            catch (Exception)
            {
                sayi = -4;
            }
            return sayi;
        }
    }
}