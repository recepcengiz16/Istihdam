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
    public partial class Saticiurunekleme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                ArrayList kategoriler = new Kategorilerdao().tumkategorilerigetir();
                int sayi = 1;
                foreach (Kategoriler gelenkat in kategoriler)
                {
                    kategoridrop.Items.Add(gelenkat.Kateadi);
                    kategoridrop.Items[sayi].Value = gelenkat.Kateno.ToString();
                    sayi++;
                }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            String resim = resimekle();
            if (resim != "")
            {
                int saticiid = Convert.ToInt32(Session["saticiid"]);
                int kontrol = new Urunlerdao().urunekleme(urunaditxt.Text, Convert.ToDouble(fiyattxt.Text), aciklamatxt.Text, resim,Convert.ToInt32(kategoridrop.SelectedItem.Value), Convert.ToInt32(altkategoridrop.SelectedItem.Value),saticiid);
                if (kontrol == 1) mesajlbl.Text = "Ürün kaydedildi.";
                else if (kontrol == -2) mesajlbl.Text = "Ürün kaydedilirken bir hata oluştu";
                else if (kontrol == -3) mesajlbl.Text = "Bilinmeyen bir hata";
            }
            else
            {
                mesajlbl.Text = "Resim seçili olmadığı için kayıt yapılamadı";
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
                else mesajlbl.Text = "Lütfen resim dosyası seçiniz.";
            }
            catch (Exception)
            {
                resimadi = "";
            }
            return resimadi;
        }

       
    }
}