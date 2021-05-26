using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Istıhdam
{
    public partial class Admin_musteriguncelle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int uyeid = Convert.ToInt32(Request.QueryString["musteriid"]);
            Session["adminmusteriid"] = uyeid;
            Musteriler musteri = new Musterilerdao().uyegetir(uyeid);

            if (Page.IsPostBack == false)
            {
                musteriadsoyadtxt.Text = musteri.Adsoyad;
                musteriemailtxt.Text = musteri.Email;
                musteriteltxt.Text = musteri.Telefon;
                musterisehirdrop.Items[0].Text = musteri.Plaka.Sehiradi;
                musterisehirdrop.Items[0].Value = musteri.Plaka.Plaka.ToString();
                musteridogtartxt.Text = musteri.Dogtar.ToShortDateString();
                musteriadrestxt.Text = musteri.Adres;
                musterikuladitxt.Text = musteri.Kuladi;
                musterisifretxt.Text = musteri.Sifre;
                musterisifretekrartxt.Text = musteri.Sifre;

                ArrayList sehirlerlistesi = new Sehirlerdao().tumsehirlerigetir();
                int sehirsayi = 1;
                foreach (Sehirler gelensehir in sehirlerlistesi)
                {
                    if (gelensehir.Plaka != musteri.Plaka.Plaka)
                    {
                        musterisehirdrop.Items.Add(gelensehir.Sehiradi);
                        musterisehirdrop.Items[sehirsayi].Value = gelensehir.Plaka.ToString();
                        sehirsayi++;
                    }
                }
            }
        }

        protected void musterisifreksayi_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (musterisifretxt.Text.Length < 5) args.IsValid = false;
        }

        protected void guncellebtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                int sayi = new Admindao().musteriguncelle(musteriadsoyadtxt.Text, musteriemailtxt.Text, musteriteltxt.Text, Convert.ToByte(musterisehirdrop.SelectedItem.Value), musteridogtartxt.Text, musteriadrestxt.Text, musterikuladitxt.Text, musterisifretxt.Text, Convert.ToInt32(Session["adminmusteriid"]));
                if (sayi == -2) musterimesajlbl.Text = "Kullanıcı adı hatası";
                else if (sayi == -3) musterimesajlbl.Text = "E mail hatası";
                else if (sayi == -4) musterimesajlbl.Text = "Bilinmeyen bir hata";
                else musterimesajlbl.Text = "Başarılı bir şekilde güncelleme yapıldı";
            }
        }
    }
}