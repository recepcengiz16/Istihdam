using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Istıhdam
{
    public partial class Admin_saticiguncelle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int uyeid =Convert.ToInt32(Request.QueryString["saticiid"]);
            Session["adminsaticiid"] = uyeid;
            Saticilar satici = new Saticilardao().uyegetir(uyeid);
            

            if (Page.IsPostBack == false)
            {
                saticiadtxt.Text = satici.Saticiad;
                saticisoyadtxt.Text = satici.Saticisoyad;
                saticiemailtxt.Text = satici.Email;
                saticiteltxt.Text = satici.Telefon;
                saticisehirdrop.Items[0].Text = satici.Plaka.Sehiradi;
                saticisehirdrop.Items[0].Value = satici.Plaka.Plaka.ToString();
                saticidogtartxt.Text = satici.Dogtar.ToShortDateString();
                saticiadrestxt.Text = satici.Adres;
                saticikuladitxt.Text = satici.Kuladi;
                saticisifretxt.Text = satici.Sifre;
                saticisifretekrartxt.Text = satici.Sifre;

                ArrayList sehirlerlistesi = new Sehirlerdao().tumsehirlerigetir();
                int sehirsayi = 1;
                foreach (Sehirler gelensehir in sehirlerlistesi)
                {
                    if (gelensehir.Plaka != satici.Plaka.Plaka)
                    {
                        saticisehirdrop.Items.Add(gelensehir.Sehiradi);
                        saticisehirdrop.Items[sehirsayi].Value = gelensehir.Plaka.ToString();
                        sehirsayi++;
                    }
                }
            }
        }

        protected void saticisifrek_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (saticisifretxt.Text.Length < 5) args.IsValid = false;
        }

        protected void guncellebtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                int sayi = new Admindao().saticiguncelle(saticiadtxt.Text, saticisoyadtxt.Text, saticikuladitxt.Text, saticisifretxt.Text, saticiemailtxt.Text, saticiteltxt.Text, saticiadrestxt.Text, Convert.ToByte(saticisehirdrop.SelectedItem.Value), saticidogtartxt.Text,Convert.ToInt32(Session["adminsaticiid"]));
                if (sayi == -2) saticimesajlbl.Text = "Kullanıcı adı hatası";
                else if (sayi == -3) saticimesajlbl.Text = "E mail hatası";
                else if (sayi == -4) saticimesajlbl.Text = "Bilinmeyen bir hata";
                else saticimesajlbl.Text = "Başarılı bir şekilde güncelleme yapıldı";
            }
        }
    }
}