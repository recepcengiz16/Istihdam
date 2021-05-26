using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Istıhdam
{
    public partial class Saticiurunlerim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mesajlbl.Text = "";
            if(Request.QueryString["silinecekurunid"]!=null)
            {
                int urunid = Convert.ToInt32(Request.QueryString["silinecekurunid"]);
                int kontrolsayi = new Urunlerdao().urunsil(urunid,Convert.ToInt32(Session["saticiid"]));
                if (kontrolsayi == 1)
                {
                    mesajlbl.Text = "Ürün başarıyla silinmiştir.";
                }
            }
            if (Page.IsPostBack == false)
            {
                ArrayList kategoriler = new Kategorilerdao().tumkategorilerigetir();
                int sayi = 1;
                foreach (Kategoriler gelenkat in kategoriler)
                {
                    anakategoridrop.Items.Add(gelenkat.Kateadi);
                    anakategoridrop.Items[sayi].Value = gelenkat.Kateno.ToString();
                    sayi++;
                }
            }
            int anakateno = 0;
            int altkateno = 0;
            bool kontrol;
            if (Request.QueryString["kontrol"] != null)
            {
                kontrol = Convert.ToBoolean(Request.QueryString["kontrol"]);
            }
            else kontrol = true;
            if (Request.QueryString["anakateno"] != null && Request.QueryString["altkateno"] != null)
            {
                anakateno = Convert.ToInt32(Request.QueryString["anakateno"]);
                altkateno = Convert.ToInt32(Request.QueryString["altkateno"]);
            }      
            int sayfano = 0;
            if (Request.QueryString["sayfano"] == null) sayfano = 1;
            else sayfano = Convert.ToInt32(Request.QueryString["sayfano"]);
            int baslangicyeri = (sayfano - 1) *4;
            ArrayList urunlistem = new Urunlerdao().sayfaliurunlerimigetir(anakateno, altkateno, kontrol, baslangicyeri, Convert.ToInt32(Session["saticiid"]));
            int i = 1;
            foreach (Urun gelenurun in urunlistem)
            {
                TableRow satir = new TableRow();
                for (int j = 0; j < 8; j++)
                {
                    TableCell hucre = new TableCell();
                    hucre.Width = 2;
                    hucre.BorderColor = System.Drawing.Color.Black;
                    hucre.BorderStyle = BorderStyle.Solid;
                    satir.Cells.Add(hucre);
                }
                Table1.Rows.Add(satir);
                Table1.Rows[i].Cells[0].Text = gelenurun.Urunadi;
                Table1.Rows[i].Cells[1].Text = gelenurun.Fiyat.ToString();
                Table1.Rows[i].Cells[2].Text = gelenurun.Aciklama;
                Table1.Rows[i].Cells[3].Text = gelenurun.Kateno.Kateadi;
                Table1.Rows[i].Cells[4].Text = gelenurun.Altkategorino.Altkateadi;

                Image resim = new Image();
                resim.Height = 90;
                resim.Width = 90;
                resim.ImageUrl = "../urunresimleri/"+ gelenurun.Resim;
                Table1.Rows[i].Cells[5].Controls.Add(resim);

                Button guncellelink = new Button();
                guncellelink.Text = "Güncelle";
                guncellelink.CssClass = "btn btn-success";
                guncellelink.PostBackUrl = "Saticiurunguncelle.aspx?urunid="+gelenurun.Urunid;
                Table1.Rows[i].Cells[6].Controls.Add(guncellelink);

                Button sillink = new Button();
                sillink.Text = "Sil";
                sillink.CssClass = "btn btn-danger";
                sillink.PostBackUrl = "Saticiurunlerim.aspx?silinecekurunid="+gelenurun.Urunid;
                Table1.Rows[i].Cells[7].Controls.Add(sillink);
                i++;
            }
            sayfalar(anakateno, altkateno, Convert.ToInt32(Session["saticiid"]), sayfano,kontrol);
        }

        protected void anakategoridrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            altkatedrop.Items.Clear();
            ArrayList altkategoriler = new Kategorilerdao().altkategorilerigetir(Convert.ToInt32(anakategoridrop.SelectedItem.Value));
            int sayi = 0;
            foreach (Altkategoriler gelenkat in altkategoriler)
            {
                altkatedrop.Items.Add(gelenkat.Altkateadi);
                altkatedrop.Items[sayi].Value = gelenkat.Altkateno.ToString();
                sayi++;
            }
        }


        protected void altkatedrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            int anakateno = Convert.ToInt32(anakategoridrop.SelectedItem.Value);
            int altkateno = Convert.ToInt32(altkatedrop.SelectedItem.Value);
            Response.Redirect("Saticiurunlerim.aspx?anakateno="+anakateno+"&altkateno="+altkateno+"&kontrol=false&sayfano=1");
        }


        protected void tumuradiobtn_CheckedChanged(object sender, EventArgs e)
        {
            
            Response.Redirect("Saticiurunlerim.aspx?kontrol=true");
        }

        void sayfalar(int anakateno, int altkateno, int saticiid, int sayfano,bool tumu)
        {
            int toplamkayitsayisi = new Urunlerdao().urunleriminsayisigetir(anakateno, altkateno, saticiid,tumu);
            int toplamsayfa = 0;
            if (toplamkayitsayisi % 4 == 0) toplamsayfa = toplamkayitsayisi / 4;
            else toplamsayfa = (toplamkayitsayisi / 4) + 1;
            String sayfayonlendirme = "Sayfalar-->>";
            if (toplamsayfa == 1)
            {
                sayfalalbl.Text = sayfayonlendirme + "<b> 1 </b>";
            }
            else
            {
                if(tumu==true)
                {
                    if (sayfano > 1)
                    {
                        sayfayonlendirme += "<a href=Saticiurunlerim.aspx?anakateno=" + anakateno + "&altkateno=" + altkateno + "&saticiid=" + saticiid + "&sayfano=" + (sayfano - 1) + "&kontrol=true> Önceki </a>";
                    }

                    for (int sayfanumara = 1; sayfanumara < toplamsayfa; sayfanumara++)
                    {
                        if (sayfano == sayfanumara) sayfayonlendirme += "<b>" + sayfanumara + "</b>";
                        else if(sayfanumara!=sayfano) sayfayonlendirme += "<a href=Saticiurunlerim.aspx?anakateno=" + anakateno + "&altkateno=" + altkateno + "&saticiid=" + saticiid + "&sayfano=" + sayfanumara + "&kontrol=true>" + " " + sayfanumara + " " + "</a>";
                    }
                    if (sayfano == toplamsayfa)
                    {
                        sayfayonlendirme += "<b>" + sayfano + "</b>";
                    }

                    if (sayfano < toplamsayfa)
                    {
                        sayfayonlendirme += "<a href=Saticiurunlerim.aspx?anakateno=" + anakateno + "&altkateno=" + altkateno + "&saticiid=" + saticiid + "&sayfano=" + (sayfano + 1) + "&kontrol=true> Sonraki </a>";
                    }
                    sayfalalbl.Text = sayfayonlendirme;
                }
                else if(tumu==false)
                {
                    if (sayfano > 1)
                    {
                        sayfayonlendirme += "<a href=Saticiurunlerim.aspx?anakateno=" + anakateno + "&altkateno=" + altkateno + "&saticiid=" + saticiid + "&sayfano=" + (sayfano - 1) + "&kontrol=false> Önceki </a>";
                    }

                    for (int sayfanumara = 1; sayfanumara < toplamsayfa; sayfanumara++)
                    {
                        if (sayfano == sayfanumara) sayfayonlendirme += "<b>" + sayfanumara + "</b>";
                        else if(sayfanumara!=sayfano) sayfayonlendirme += "<a href=Saticiurunlerim.aspx?anakateno=" + anakateno + "&altkateno=" + altkateno + "&saticiid=" + saticiid + "&sayfano=" + sayfanumara + "&kontrol=false>" + " " + sayfanumara + " " + "</a>";
                    }
                    if(sayfano==toplamsayfa)
                    {
                        sayfayonlendirme += "<b>" + sayfano + "</b>";
                    }

                    if (sayfano < toplamsayfa)
                    {
                        sayfayonlendirme += "<a href=Saticiurunlerim.aspx?anakateno=" + anakateno + "&altkateno=" + altkateno + "&saticiid=" + saticiid + "&sayfano=" + (sayfano + 1) + "&kontrol=false> Sonraki </a>";
                    }
                    sayfalalbl.Text = sayfayonlendirme;
                }
                
            }
            
        }
    }
}