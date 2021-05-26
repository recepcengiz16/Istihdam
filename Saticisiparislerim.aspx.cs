using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Istıhdam
{
    public partial class Saticisiparislerim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {         
            int sayfano = 0;
            if (Request.QueryString["sayfano"] == null) sayfano = 1;
            else sayfano = Convert.ToInt32(Request.QueryString["sayfano"]);
            int baslangicyeri = (sayfano - 1) * 5;
            ArrayList siparislerim = new Siparisdao().saticisayfaliurunlergetir(baslangicyeri, Convert.ToInt32(Session["saticiid"])); 
            int i = 1;
            foreach (Siparis gelenurun in siparislerim)
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
                Table1.Rows[i].Cells[0].Text = gelenurun.Sip_tarih.ToShortDateString();
                Table1.Rows[i].Cells[1].Text = gelenurun.Uyeid.Adsoyad;
                Table1.Rows[i].Cells[2].Text = gelenurun.Uyeid.Email;
                Table1.Rows[i].Cells[3].Text = gelenurun.Uyeid.Adres;
                Table1.Rows[i].Cells[4].Text = gelenurun.Urunid.Urunadi;
                Table1.Rows[i].Cells[5].Text = gelenurun.Adet.ToString();

                Image resim = new Image();
                resim.Height = 90;
                resim.Width = 90;
                resim.ImageUrl = "../urunresimleri/" + gelenurun.Urunid.Resim;
                Table1.Rows[i].Cells[6].Controls.Add(resim);
                Table1.Rows[i].Cells[7].Text = (gelenurun.Urunid.Fiyat*gelenurun.Adet).ToString();

                i++;
            }
            sayfalar(sayfano);
        }

        void sayfalar(int sayfano)
        {
            int toplamkayitsayisi = new Siparisdao().saticisiparissayisigetir(Convert.ToInt32(Session["saticiid"]));
            int toplamsayfa = 0;
            if (toplamkayitsayisi % 5 == 0) toplamsayfa = toplamkayitsayisi / 5;
            else toplamsayfa = (toplamkayitsayisi / 5) + 1;
            String sayfayonlendirme = "Sayfalar-->>";
            if (toplamsayfa == 1)
            {
                sayfalalbl.Text = sayfayonlendirme + "<b> 1 </b>";
            }
            else
            {
                
                if (sayfano > 1)
                {
                    sayfayonlendirme += "<a href=Saticisiparislerim.aspx?sayfano=" + (sayfano - 1) +"> Önceki </a>";
                }

                for (int sayfanumara = 1; sayfanumara < toplamsayfa; sayfanumara++)
                {
                     if (sayfano == sayfanumara) sayfayonlendirme += "<b>" + sayfanumara + "</b>";
                     else if (sayfanumara != sayfano) sayfayonlendirme += "<a href=Saticisiparislerim.aspx?sayfano=" + sayfanumara + ">" + " " + sayfanumara + " " + "</a>";
                }
                if (sayfano == toplamsayfa)
                {
                        sayfayonlendirme += "<b>" + sayfano + "</b>";
                }

                if (sayfano < toplamsayfa)
                {
                        sayfayonlendirme += "<a href=Saticisiparislerim.aspx?sayfano=" + (sayfano + 1) + "> Sonraki </a>";
                }
                sayfalalbl.Text = sayfayonlendirme;
                

            }

        }
    }
}