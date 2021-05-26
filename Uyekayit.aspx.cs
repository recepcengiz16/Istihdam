using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Istıhdam
{
    public partial class Uyekayit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int kayit = Convert.ToInt32(Request.QueryString["uyekayit"]);
            if (kayit == 0) MultiView1.ActiveViewIndex = 0;
            else if (kayit == 1) MultiView1.ActiveViewIndex = 1;

            if (Page.IsPostBack == false)
            {
                ArrayList sehirlerlistesi = new Sehirlerdao().tumsehirlerigetir();
                int sehirsayi = 1;
                foreach (Sehirler gelensehir in sehirlerlistesi)
                {
                    musterisehirdrop.Items.Add(gelensehir.Sehiradi);
                    musterisehirdrop.Items[sehirsayi].Value = gelensehir.Plaka.ToString();
                    sehirsayi++;
                }
                sehirsayi = 1;
                foreach (Sehirler gelensehir in sehirlerlistesi)
                {
                    saticisehirdrop.Items.Add(gelensehir.Sehiradi);
                    saticisehirdrop.Items[sehirsayi].Value = gelensehir.Plaka.ToString();
                    sehirsayi++;
                }
            }
        }

        protected void musterikaydetbtn_Click(object sender, EventArgs e)
        {    
            if (Page.IsValid)
            {
                int kontrol = new Musterilerdao().uyekayit(musteriadsoyadtxt.Text, musteriemailtxt.Text, musteriteltxt.Text, Convert.ToByte(musterisehirdrop.SelectedItem.Value), musteridogtartxt.Text, musteriadrestxt.Text, musterikuladitxt.Text, musterisifretxt.Text);
                if (kontrol == -2) musterimesajlbl.Text = "Bu kullanıcı adı zaten var. Yeniden giriniz.";
                else if (kontrol == -3) musterimesajlbl.Text = "Bu email zaten var. Yeni e mail giriniz.";
                else if (kontrol == -4) musterimesajlbl.Text = "Bilinmeyen bir hata oluştu";
                else
                {
                    musterimesajlbl.Text = "Başarılı bir şekilde kaydedildi";
                    musterilink.Visible = true;
                }
            }
        }

        protected void saticikaydetbtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int kontrol = new Saticilardao().uyekayit(saticiadtxt.Text, saticisoyadtxt.Text, saticikuladitxt.Text, saticisifretxt.Text, saticiemailtxt.Text, saticiteltxt.Text, saticiadrestxt.Text, Convert.ToByte(saticisehirdrop.SelectedItem.Value), saticidogtartxt.Text);
                if (kontrol == -2) musterimesajlbl.Text = "Bu kullanıcı adı zaten var. Yeniden giriniz.";
                else if (kontrol == -3) musterimesajlbl.Text = "Bu email zaten var. Yeni e mail giriniz.";
                else if (kontrol == -4) musterimesajlbl.Text = "Bilinmeyen bir hata oluştu";
                else
                {
                    saticimesajlbl.Text = "Başarılı bir şekilde kaydedildi";
                    saticilink.Visible = true;
                }
            }
        }

        protected void musterisifreksayi_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (musterisifreksayi.Text.Length < 5) args.IsValid = false;
        }

        protected void saticisifrek_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (saticisifretekrartxt.Text.Length < 5) args.IsValid = false;
        }
    }
}