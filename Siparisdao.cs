using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace Istıhdam
{
    public class Siparisdao
    {
        public int siparisver(int musteriid,ArrayList musterisepeti)
        {
            int siparisno = 0;
            int kontrol = 0;
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = bag;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = bag;
            cmd.CommandText = "select count(*) from siparisler";
            kontrol = Convert.ToInt32(cmd.ExecuteScalar());
            if (kontrol == 0 || kontrol == null) siparisno = 1;
            else
            {
                komut.CommandText = "select max(sipno) from siparisler";
                siparisno = Convert.ToInt32(komut.ExecuteScalar());
                siparisno++;
            }
            

            foreach (Sepetim gelen in musterisepeti)
            {
                SqlCommand komut2 = new SqlCommand();
                komut2.Connection = bag;
                komut2.CommandText = "insert into siparisler(uyeid,urunid,adet,sip_tarih,sipno) values(@uyeid,@urunid,@adet,@sip_tarih,@sipno)";
                komut2.Parameters.AddWithValue("@uyeid", musteriid);
                komut2.Parameters.AddWithValue("@urunid", gelen.Urunum.Urunid);
                komut2.Parameters.AddWithValue("@adet", gelen.Adet);
                komut2.Parameters.AddWithValue("@sip_tarih", DateTime.Now);
                komut2.Parameters.AddWithValue("@sipno", siparisno);
                komut2.ExecuteNonQuery();
            }
            bag.Close();
            return siparisno;
        }

        public ArrayList musterisayfaliurunlergetir(int baslangic,int uyeid)
        {
            String sql = "select * from siparisler,urunler where siparisler.urunid=urunler.urunid and siparisler.uyeid=" + uyeid;
            
            ArrayList siparisler = new ArrayList();
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
                yeniurun.Resim = satir["resim"].ToString();

                Siparis sipnesnesi = new Siparis();
                sipnesnesi.Adet = Convert.ToInt32(satir["adet"]);
                sipnesnesi.Kayitno = Convert.ToInt32(satir["kayitno"]);
                sipnesnesi.Sipno = Convert.ToInt32(satir["sipno"]);
                sipnesnesi.Sip_tarih = Convert.ToDateTime(satir["sip_tarih"]);
                sipnesnesi.Urunid = yeniurun;
                siparisler.Add(sipnesnesi);
            }
            bag.Close();
            return siparisler;
        }

        public int  musterisiparissayisigetir(int musteriid)
        {
            int sayi = 0;
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = bag;
            
            komut.CommandText = "select count(*) from siparisler where uyeid=@uyeid";
            komut.Parameters.AddWithValue("@uyeid", musteriid);
            sayi = Convert.ToInt32(komut.ExecuteScalar());
            bag.Close();
            return sayi;
        }

        public ArrayList saticisayfaliurunlergetir(int baslangic, int uyeid)
        {

            String sql = "select * from siparisler,musteriler,urunler,saticilar where siparisler.urunid=urunler.urunid and siparisler.uyeid=musteriler.uyeid and urunler.saticiid=saticilar.saticiid and saticilar.saticiid="+uyeid;      
                
            ArrayList siparisler = new ArrayList();
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter(sql, bag);
            DataSet ds = new DataSet();
            adaptor.Fill(ds, baslangic, 5, "siparislerim");
            foreach (DataRow satir in ds.Tables["siparislerim"].Rows)
            {
                Urun yeniurun = new Urun();
                yeniurun.Urunid = Convert.ToInt32(satir["urunid"]);
                yeniurun.Urunadi = satir["urunadi"].ToString();
                yeniurun.Fiyat = Convert.ToDouble(satir["fiyat"]);
                yeniurun.Resim = satir["resim"].ToString();

                Musteriler yenimusteri = new Musteriler();
                yenimusteri.Adres = satir["adres"].ToString();
                yenimusteri.Adsoyad = satir["adsoyad"].ToString();
                yenimusteri.Email = satir["email"].ToString();

                Siparis sipnesnesi = new Siparis();
                sipnesnesi.Adet = Convert.ToInt32(satir["adet"]);
                sipnesnesi.Sip_tarih = Convert.ToDateTime(satir["sip_tarih"]);
                sipnesnesi.Urunid = yeniurun;
                sipnesnesi.Uyeid = yenimusteri;
                siparisler.Add(sipnesnesi);
            }
            bag.Close();
            return siparisler;
        }

        public int saticisiparissayisigetir(int saticiid)//saticiid ye ait olan siparişlerin sayısını getiremedim.
        {
            int sayi = 0;
            SqlConnection bag = new Connectionyapici().baglantiyagec();
            bag.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = bag;           
            komut.CommandText = "select count(*) from siparisler,urunler,saticilar where siparisler.urunid=urunler.urunid and urunler.saticiid=saticilar.saticiid and urunler.saticiid=@saticiid";
            komut.Parameters.AddWithValue("@saticiid", saticiid);     
            sayi = Convert.ToInt32(komut.ExecuteScalar());
            bag.Close();
            return sayi;
        }
    }
}