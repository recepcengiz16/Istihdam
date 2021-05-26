using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;

namespace Istıhdam
{
    public class Musterilerdao
    {
        public int uyekayit(String adsoyad,String email,String telefon,byte plaka,String dogtar,String adres,String kuladi,String sifre)
        {
            int sayi = 0;
            try
            {
                SqlConnection bag = new Connectionyapici().baglantiyagec();
                bag.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = bag;
                komut.CommandText = "insert into musteriler(kuladi,sifre,adsoyad,email,adres,plaka,onay,telefon,dogtar) values(@kuladi,@sifre,@adsoyad,@email,@adres,@plaka,@onay,@telefon,@dogtar)";
                komut.Parameters.AddWithValue("@kuladi", kuladi);
                komut.Parameters.AddWithValue("@sifre", sifre);
                komut.Parameters.AddWithValue("@adsoyad", adsoyad);
                komut.Parameters.AddWithValue("@email", email);
                komut.Parameters.AddWithValue("@adres", adres);
                komut.Parameters.AddWithValue("@plaka", plaka);
                komut.Parameters.AddWithValue("@onay", false);
                komut.Parameters.AddWithValue("@telefon", telefon);
                komut.Parameters.AddWithValue("@dogtar", Convert.ToDateTime(dogtar));
                sayi = komut.ExecuteNonQuery();
                bag.Close();
                
            }
            catch(SqlException hata)
            {
                if (hata.Message.IndexOf("kuladi") != -1) sayi = -2;
                else if (hata.Message.IndexOf("email") != -1) sayi = -3;
            }
            catch(Exception)
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
                komut.CommandText = "delete from musteriler where uyeid=@uyeid";
                komut.Parameters.AddWithValue("@uyeid", uyeid);
                sayi = komut.ExecuteNonQuery();
                bag.Close();
            }
            catch(Exception)
            {

            }
            return sayi;
        }

        public Musteriler uyegiriskontrol(String kuladi,String sifre)
        {
            
            Musteriler musteri = new Musteriler();
            try
            {
                SqlConnection bag = new Connectionyapici().baglantiyagec();
                bag.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = bag;
                komut.CommandText = "select * from musteriler where kuladi=@kuladi and sifre=@sifre";
                komut.Parameters.AddWithValue("@kuladi", kuladi);
                komut.Parameters.AddWithValue("@sifre",sifre);
                SqlDataReader oku = komut.ExecuteReader();
                oku.Read();
                musteri.Adsoyad = oku["adsoyad"].ToString();
                musteri.Uyeid = Convert.ToInt32(oku["uyeid"]);
                musteri.Kuladi =oku["kuladi"].ToString();
                musteri.Sifre = oku["sifre"].ToString();
                oku.Close();
                bag.Close();
            }
            catch (Exception)
            {
                
            }
            return musteri;
        }

        public Musteriler uyegetir(int uyeid)
        {
                Musteriler musteri = new Musteriler();
                SqlConnection bag = new Connectionyapici().baglantiyagec();
                bag.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = bag;
                komut.CommandText = "select * from musteriler,sehirler where musteriler.plaka=sehirler.plaka and uyeid=@uyeid";
                komut.Parameters.AddWithValue("@uyeid", uyeid);
                SqlDataReader oku = komut.ExecuteReader();
                oku.Read();
                musteri.Adres = oku["adres"].ToString();
                musteri.Adsoyad = oku["adsoyad"].ToString();
                musteri.Dogtar = Convert.ToDateTime(oku["dogtar"]);
                musteri.Email = oku["email"].ToString();
                musteri.Kuladi = oku["kuladi"].ToString();
                musteri.Onay = Convert.ToBoolean(oku["onay"]);
                Sehirler plaka = new Sehirler();
                plaka.Sehiradi = oku["sehiradi"].ToString();
                plaka.Plaka = Convert.ToByte(oku["plaka"]);
                musteri.Plaka = plaka;
                musteri.Sifre = oku["sifre"].ToString();
                musteri.Telefon = oku["telefon"].ToString();
                musteri.Uyeid = uyeid;
                oku.Close();
                bag.Close();
                return musteri;
        }
        public int uyeguncelle(String adsoyad, String email, String telefon, byte plaka, String dogtar, String adres, String kuladi, String sifre,int uyeid)
        {
            int sayi = 0;
            try
            {
                SqlConnection bag = new Connectionyapici().baglantiyagec();
                bag.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = bag;
                komut.CommandText = "update musteriler set adsoyad=@adsoyad,email=@email,telefon=@telefon,plaka=@plaka,dogtar=@dogtar,adres=@adres,kuladi=@kuladi,sifre=@sifre where uyeid=@uyeid";
                komut.Parameters.AddWithValue("@adsoyad",adsoyad);
                komut.Parameters.AddWithValue("@email",email);
                komut.Parameters.AddWithValue("@telefon",telefon);
                komut.Parameters.AddWithValue("@plaka",plaka);
                komut.Parameters.AddWithValue("@dogtar",Convert.ToDateTime(dogtar));
                komut.Parameters.AddWithValue("@adres",adres);
                komut.Parameters.AddWithValue("@kuladi",kuladi);
                komut.Parameters.AddWithValue("@sifre",sifre);
                komut.Parameters.AddWithValue("@uyeid",uyeid);
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