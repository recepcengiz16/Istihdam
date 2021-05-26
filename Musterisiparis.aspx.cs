using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Istıhdam
{
    public partial class Musterisiparis : System.Web.UI.Page
    {
        ArrayList siparislistem = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            int sayfano = 0;
            if (Request.QueryString["sayfano"] == null) sayfano = 1;
            else sayfano = Convert.ToInt32(Request.QueryString["sayfano"]);
            int baslangicyeri = (sayfano - 1) * 4;
            siparislistem = new Siparisdao().musterisayfaliurunlergetir(baslangicyeri, Convert.ToInt32(Session["musteriid"]));
            tabloyaz();
            sayfalar(sayfano, Convert.ToInt32(Session["musteriid"]));
        }

        void sayfalar(int sayfano,int uyeid)
        {
            int toplamkayitsayisi = new Siparisdao().musterisiparissayisigetir(uyeid);
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
                    if (sayfano > 1)
                    {
                        sayfayonlendirme += "<a href=Musterisiparis.aspx?uyeid=" + uyeid + "&sayfano=" + (sayfano - 1) + "&kontrol=true> Önceki </a>";
                    }

                    for (int sayfanumara = 1; sayfanumara < toplamsayfa; sayfanumara++)
                    {
                        if (sayfano == sayfanumara) sayfayonlendirme += "<b>" + sayfanumara + "</b>";
                        else if (sayfanumara != sayfano) sayfayonlendirme += "<a href=Musterisiparis.aspx?uyeid=" + uyeid + "&sayfano=" + sayfanumara + "&kontrol=true>" + " " + sayfanumara + " " + "</a>";
                    }
                    if (sayfano == toplamsayfa)
                    {
                        sayfayonlendirme += "<b>" + sayfano + "</b>";
                    }

                    if (sayfano < toplamsayfa)
                    {
                        sayfayonlendirme += "<a href=Musterisiparis.aspx?uyeid=" +uyeid + "&sayfano=" + (sayfano + 1) + "&kontrol=true> Sonraki </a>";
                    }
                    sayfalalbl.Text = sayfayonlendirme;
            }

        }

        void tabloyaz()
        {
            int i = 1;
            foreach (Siparis gelensiparis in siparislistem)
            {
                TableRow satir = new TableRow();
                for (int j = 0; j < 7; j++)
                {
                    TableCell hucre = new TableCell();
                    hucre.Width = 2;
                    hucre.BorderColor = System.Drawing.Color.Black;
                    hucre.BorderStyle = BorderStyle.Solid;
                    satir.Cells.Add(hucre);
                }
                Table1.Rows.Add(satir);
                Table1.Rows[i].Cells[0].Text = gelensiparis.Sipno.ToString();
                Table1.Rows[i].Cells[1].Text = gelensiparis.Urunid.Urunadi;
                Table1.Rows[i].Cells[2].Text = gelensiparis.Adet.ToString();
                Table1.Rows[i].Cells[3].Text = gelensiparis.Urunid.Fiyat.ToString();

                Image resim = new Image();
                resim.Height = 90;
                resim.Width = 90;
                resim.ImageUrl = "../urunresimleri/" + gelensiparis.Urunid.Resim;
                Table1.Rows[i].Cells[4].Controls.Add(resim);
                Table1.Rows[i].Cells[5].Text = gelensiparis.Sip_tarih.ToString();

                TimeSpan zamanfarki = DateTime.Now - gelensiparis.Sip_tarih;
                if (zamanfarki.Days == 0)
                {
                    Button islem = new Button();
                    islem.CssClass = "btn btn-success";
                    islem.Text = "İşlemi İptal Et";
                    islem.PostBackUrl = "Musterisepet.aspx?sipno=" + gelensiparis.Sipno;
                    Table1.Rows[i].Cells[6].Controls.Add(islem);
                }
                else Table1.Rows[i].Cells[6].Text = "İşleminiz Onaylanmıştır.";

                i++;
            }
        }
    }
}