using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;

namespace Istıhdam
{
    public partial class Saticiurunguncelle : System.Web.UI.Page
    {
        
        
        Urun gelenurun;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["resimadi"] = FileUpload1.FileName;
            if (Page.IsPostBack == false)
            {
               int urunid = Convert.ToInt32(Request.QueryString["urunid"]);
               Session["urunid"] = urunid;
              gelenurun = new Urunlerdao().tekurungetir(urunid, Convert.ToInt32(Session["saticiid"]));
              urunaditxt.Text = gelenurun.Urunadi;
              fiyattxt.Text = gelenurun.Fiyat.ToString();
              aciklamatxt.Text = gelenurun.Aciklama;
              kategoridrop.Items[0].Text = gelenurun.Kateno.Kateadi;
              kategoridrop.Items[0].Value = gelenurun.Kateno.Kateno.ToString();
              altkategoridrop.Items[0].Text = gelenurun.Altkategorino.Altkateadi;
              altkategoridrop.Items[0].Value = gelenurun.Altkategorino.Altkateno.ToString();

            
                ArrayList kategoriler = new Kategorilerdao().tumkategorilerigetir();
                int katesayi = 1;
                foreach (Kategoriler gelenkate in kategoriler)
                {
                    if (gelenkate.Kateno!=gelenurun.Kateno.Kateno)
                    {
                        kategoridrop.Items.Add(gelenkate.Kateadi);
                        kategoridrop.Items[katesayi].Value = gelenkate.Kateno.ToString();
                        katesayi++;
                    }
                }

                ArrayList altkategoriler = new Kategorilerdao().altkategorilerigetir(gelenurun.Kateno.Kateno);
                int altkatesayi = 1;
                foreach  (Altkategoriler altkate in altkategoriler)
                {
                    if (altkate.Altkateno!=gelenurun.Altkategorino.Altkateno)
                    {
                        altkategoridrop.Items.Add(altkate.Altkateadi);
                        altkategoridrop.Items[altkatesayi].Value = altkate.Altkateno.ToString();
                        altkatesayi++;
                    }
                }
                Image1.ImageUrl = "../urunresimleri/" + gelenurun.Resim;
            }
            
        }      

        protected void kategoridrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            altkategoridrop.Items.Clear();
            ArrayList altkategoriler = new Kategorilerdao().altkategorilerigetir(Convert.ToInt32(kategoridrop.SelectedItem.Value));
            int sayi = 0;
            foreach (Altkategoriler gelenkat in altkategoriler)
            {
                altkategoridrop.Items.Add(gelenkat.Altkateadi);
                altkategoridrop.Items[sayi].Value = gelenkat.Altkateno.ToString();
                sayi++;
            }
        }

        String resimekle()
        {
            String resimadi = "";
            try
            {              
                String uzanti = Path.GetExtension(FileUpload1.FileName);
                if (uzanti == ".jpg" || uzanti == ".png")
                {
                    int sonurunid = new Urunlerdao().sonurunidgetir();
                    sonurunid++;
                    resimadi = sonurunid + uzanti;
                    FileUpload1.SaveAs(Server.MapPath("urunresimleri") + "/" + resimadi);
                    Image1.ImageUrl = "urunresimleri/" + resimadi;

                }
                else if (uzanti==null)
                {
                    resimadi = "";
                }
                else mesajlbl.Text = "Lütfen resim dosyası seçiniz.";
            }
            catch (Exception)
            {
                resimadi = "";
            }
            return resimadi;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int urunid = Convert.ToInt32(Session["urunid"]);
            String guncelresim = "";
            if(FileUpload1.HasFile)
            {
                guncelresim = resimekle();
            }
            if (guncelresim == "" || guncelresim==null)
            {
                int kontrol = new Urunlerdao().urunuguncelle(urunaditxt.Text,Convert.ToDouble(fiyattxt.Text),aciklamatxt.Text,"",Convert.ToInt32(kategoridrop.SelectedItem.Value), Convert.ToInt32(altkategoridrop.SelectedItem.Value),urunid);
                if (kontrol == 1) mesajlbl.Text = "Ürün başarıyla güncellendi.";
                else if (kontrol == -2) mesajlbl.Text = "Ürün güncellenirken bir hata oluştu";              
            }
            else
            {                
                int kontrol = new Urunlerdao().urunuguncelle(urunaditxt.Text,Convert.ToDouble(fiyattxt.Text),aciklamatxt.Text,guncelresim,Convert.ToInt32(kategoridrop.SelectedItem.Value), Convert.ToInt32(altkategoridrop.SelectedItem.Value),urunid);
                if (kontrol == 1) mesajlbl.Text = "Ürün başarıyla güncellendi.";
                else if (kontrol == -2) mesajlbl.Text = "Ürün güncellenirken bir hata oluştu";
            }
        }
    }
}