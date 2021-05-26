using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace Istıhdam
{
    public class Saticilardao
    {
        public int uyekayit(String ad, String soyad, String kuladi, String sifre, String email, String telefon, String adres, byte plaka, String dogtar)
        {
            int sayi = 0;
            try
            {
                SqlConnection bag = new Connectionyapici().baglantiyagec();
                bag.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = bag;
                komut.CommandText = "insert into saticilar(saticiad,saticisoyad,kuladi,sifre,email,telefon,adres,plaka,dogtar) values(@saticiad,@saticisoyad,@kuladi,@sifre,@email,@telefon,@adres,@plaka,@dogtar)";
                komut.Parameters.AddWithValue("@kuladi", kuladi);
                komut.Parameters.AddWithValue("@sifre", sifre);
                komut.Parameters.AddWithValue("@saticiad", ad);
                komut.Parameters.AddWithValue("@saticisoyad", soyad);
                komut.Parameters.AddWithValue("@email", email);
                komut.Parameters.AddWithValue("@adres", adres);
                komut.Parameters.AddWithValue("@plaka", plaka);
                komut.Parameters.AddWithValue("@telefon", telefon);
                komut.Parameters.AddWithValue("@dogtar", Convert.ToDateTime(dogtar));
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

        public int uyesil(int uyeid)
        {
            int sayi = 0;
            try
            {
                SqlConnection bag = new Connectionyapici().baglantiyagec();
                bag.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = bag;
                komut.CommandText = "delete from saticilar where uyeid=@uyeid";
                komut.Parameters.AddWithValue("@uyeid", uyeid);
                sayi = komut.ExecuteNonQuery();
                bag.Close();
            }
            catch (Exception)
            {

            }
            return sayi;
        }

        public Saticilar uyegiriskontrol(String kuladi, String sifre)
        {
            
            Saticilar satici = new Saticilar();
            try
            {
                SqlConnection bag = new Connectionyapici().baglantiyagec();
                bag.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = bag;
                komut.CommandText = "select * from saticilar where kuladi=@kuladi and sifre=@sifre";
                komut.Parameters.AddWithValue("@kuladi", kuladi);
                komut.Parameters.AddWithValue("@sifre", sifre);
                SqlDataReader oku = komut.ExecuteReader();
                oku.Read();
                satici.Saticiid = Convert.ToInt32(oku["saticiid"]);
                satici.Saticiad = oku["saticiad"].ToString();
                satici.Saticisoyad = oku["saticisoyad"].ToString();
                satici.Kuladi = oku["kuladi"].ToString();
                satici.Sifre = oku["sifre"].ToString();
                oku.Close();
                bag.Close();
            }
            catch (Exception)
            {
                
            }
            return satici;
        }

        public Saticilar uyegetir(int uyeid)
        {
            Saticilar satici = new Saticilar();
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = bag;
            komut.CommandText = "select * from saticilar,sehirler where saticilar.plaka=sehirler.plaka and saticiid=@saticiid";
            komut.Parameters.AddWithValue("@saticiid", uyeid);
            SqlDataReader oku = komut.ExecuteReader();
            oku.Read();
            satici.Adres = oku["adres"].ToString();
            satici.Saticiad = oku["saticiad"].ToString();
            satici.Saticisoyad = oku["saticisoyad"].ToString();
            satici.Dogtar = Convert.ToDateTime(oku["dogtar"]);
            satici.Email = oku["email"].ToString();
            satici.Kuladi = oku["kuladi"].ToString();
            
            Sehirler plaka = new Sehirler();
            plaka.Sehiradi = oku["sehiradi"].ToString();
            plaka.Plaka = Convert.ToByte(oku["plaka"]);
            satici.Plaka = plaka;
            satici.Sifre = oku["sifre"].ToString();
            satici.Telefon = oku["telefon"].ToString();
            satici.Saticiid = uyeid;
            oku.Close();
            bag.Close();
            return satici;
        }

        public int uyeguncelle(String ad, String soyad, String kuladi, String sifre, String email, String telefon, String adres, byte plaka, String dogtar,int uyeid)
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
                komut.Parameters.AddWithValue("@saticiid",uyeid);
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