using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

namespace Istıhdam
{
    public partial class Urunlerim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["musteriid"] == null)
            {
                Response.Write("Üye olmadan ürünlerimizi göremezsiniz");
                uyegitlink.Visible = true;
                Response.End();
            }
            else uyegitlink.Visible = false;
            if (Page.IsPostBack == false)
            {
                ArrayList kategoriler = new Kategorilerdao().tumkategorilerigetir();
                foreach (Kategoriler kategori in kategoriler)
                {
                    MenuItem kate = new MenuItem();
                    kate.Text = kategori.Kateadi;
                    kate.NavigateUrl = "Urunler.aspx?kateno=" + kategori.Kateno;
                    ArrayList altkatelistesi = new Kategorilerdao().altkategorilerigetir(kategori.Kateno);
                    foreach (Altkategoriler gelenaltkate in altkatelistesi)
                    {
                        MenuItem altmenu = new MenuItem();
                        altmenu.Text = gelenaltkate.Altkateadi;
                        altmenu.NavigateUrl = "Urunler.aspx?altkateno=" + gelenaltkate.Altkateno+ "&kateno="+gelenaltkate.Anakateno;
                        kate.ChildItems.Add(altmenu);
                    }
                    Menu1.Items.Add(kate);
                }
            }
            int kateno = Convert.ToInt32(Request.QueryString["kateno"]);
            int altkateno = Convert.ToInt32(Request.QueryString["altkateno"]);
            int sayfano = 0;
            if (Request.QueryString["sayfano"] == null) sayfano = 1;
            else sayfano = Convert.ToInt32(Request.QueryString["sayfano"]);
            int baslangic = (sayfano - 1) * 9;
            ArrayList urunler = new Urunlerdao().sayfaliurunlergetir(kateno, altkateno, baslangic);
            int i = 0;
            int j = 0;
            foreach (Urun gelenurun in urunler)
            {
                Image resim = new Image();
                resim.ImageUrl = "urunresimleri/" + gelenurun.Resim;
                resim.Height = 150;
                resim.Width = 220;
                Table1.Rows[i].Cells[j].Controls.Add(resim);
                Table1.Rows[i].Cells[j].Controls.Add(new LiteralControl("<br><b>Ürün Adı=</b>" + gelenurun.Urunadi + "<br><b>Fiyatı=</b>" + gelenurun.Fiyat + "<br>"));
                Button sepet = new Button();
                sepet.CssClass = "btn btn-success";
                sepet.Text = "Sepete Ekle";                
                sepet.PostBackUrl="Musterisepet.aspx?urunid=" + gelenurun.Urunid;
                Table1.Rows[i].Cells[j].Controls.Add(sepet);
                Table1.Rows[i].Cells[j].Controls.Add(new LiteralControl("<br>"));
                j++;
                if (j == 3)
                {
                    i++;
                    j = 0;
                }
            }
            sayfalar(kateno,altkateno, sayfano);

        }//page load

        void sayfalar(int anakateno,int altkateno, int sayfano)
        {
            int toplamkayitsayisi = new Urunlerdao().urunsayisigetir(altkateno);
            int toplamsayfa = 0;
            if (toplamkayitsayisi % 9 == 0) toplamsayfa = toplamkayitsayisi / 9;
            else toplamsayfa = (toplamkayitsayisi / 9) + 1;
            String sayfayonlendirme = "Sayfalar-->>";
            if (toplamsayfa == 1)
            {
                sayfalbl.Text = sayfayonlendirme + "<b> 1 </b>";
            }
            else
            {
                if (sayfano > 1)
                {
                    sayfayonlendirme += "<a href=Urunler.aspx?kateno="+anakateno+"&altkateno=" + altkateno + "&sayfano=" + (sayfano - 1) + "> Önceki </a>";
                }

                for (int sayfanumara = 1; sayfanumara < toplamsayfa; sayfanumara++)
                {
                    if (sayfano == sayfanumara) sayfayonlendirme += "<b>" + sayfanumara + "</b>";
                    else if (sayfanumara != sayfano) sayfayonlendirme += "<a href=Urunler.aspx?kateno="+anakateno+"&altkateno=" + altkateno +"&sayfano=" + sayfanumara +">" + " " + sayfanumara + " " + "</a>";
                }
                if (sayfano == toplamsayfa)
                {
                    sayfayonlendirme += "<b>" + sayfano + "</b>";
                }

                if (sayfano < toplamsayfa)
                {
                    sayfayonlendirme += "<a href=Urunler.aspx?kateno="+anakateno+"&altkateno=" + altkateno +"&sayfano=" + (sayfano + 1) +"> Sonraki </a>";
                }
                sayfalbl.Text = sayfayonlendirme;
            }
        }
    }
}