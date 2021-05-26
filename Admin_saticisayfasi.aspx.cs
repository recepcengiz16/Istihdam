using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Istıhdam
{
    public partial class Admin_saticisayfasi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mesajlbl.Text = "";
            if (Request.QueryString["silinecekuyeid"] != null)
            {
                int saticiid = Convert.ToInt32(Request.QueryString["silinecekuyeid"]);
                int kontrolsayi = new Admindao().saticisil(saticiid);
                if (kontrolsayi == 1)
                {
                    mesajlbl.Text = "Satıcı başarıyla silinmiştir.";
                }
            }

            int sayfano = 0;
            if (Request.QueryString["sayfano"] == null) sayfano = 1;
            else sayfano = Convert.ToInt32(Request.QueryString["sayfano"]);
            int baslangicyeri = (sayfano - 1) * 10;
            ArrayList saticilistem = new Admindao().saticilarigetir(baslangicyeri);
            int i = 1;
            foreach (Saticilar gelensatici in saticilistem)
            {
                TableRow satir = new TableRow();
                for (int j = 0; j < 11; j++)
                {
                    TableCell hucre = new TableCell();
                    hucre.Width = 2;
                    hucre.BorderColor = System.Drawing.Color.Black;
                    hucre.BorderStyle = BorderStyle.Solid;
                    satir.Cells.Add(hucre);
                }
                Table1.Rows.Add(satir);
                Table1.Rows[i].Cells[0].Text = gelensatici.Saticiad;
                Table1.Rows[i].Cells[1].Text = gelensatici.Saticisoyad;
                Table1.Rows[i].Cells[2].Text = gelensatici.Kuladi;
                Table1.Rows[i].Cells[3].Text = gelensatici.Sifre;
                Table1.Rows[i].Cells[4].Text = gelensatici.Email;
                Table1.Rows[i].Cells[5].Text=gelensatici.Telefon;
                Table1.Rows[i].Cells[6].Text = gelensatici.Adres;
                Table1.Rows[i].Cells[7].Text = gelensatici.Plaka.Sehiradi;
                Table1.Rows[i].Cells[8].Text = gelensatici.Dogtar.ToShortDateString();

                Button guncellelink = new Button();
                guncellelink.Text = "Güncelle";
                guncellelink.CssClass = "btn btn-success";
                guncellelink.PostBackUrl = "Admin_saticiguncelle.aspx?saticiid=" + gelensatici.Saticiid;
                Table1.Rows[i].Cells[9].Controls.Add(guncellelink);

                Button sillink = new Button();
                sillink.Text = "Sil";
                sillink.CssClass = "btn btn-danger";
                sillink.PostBackUrl = "Admin_saticisayfasi.aspx?silinecekuyeid=" + gelensatici.Saticiid;
                Table1.Rows[i].Cells[10].Controls.Add(sillink);
                i++;
            }
            sayfalar(sayfano);
        }

        void sayfalar(int sayfano)
        {
            int toplamkayitsayisi = new Admindao().saticisayisigetir();
            int toplamsayfa = 0;
            if (toplamkayitsayisi % 10 == 0) toplamsayfa = toplamkayitsayisi / 10;
            else toplamsayfa = (toplamkayitsayisi / 10) + 1;
            String sayfayonlendirme = "Sayfalar-->>";
            if (toplamsayfa == 1)
            {
                sayfalalbl.Text = sayfayonlendirme + "<b> 1 </b>";
            }
            else
            {             
                if (sayfano > 1)
                {
                    sayfayonlendirme += "<a href=Admin_saticisayfasi.aspx?sayfano=" + (sayfano - 1) + "> Önceki </a>";
                }

                for (int sayfanumara = 1; sayfanumara < toplamsayfa; sayfanumara++)
                {
                     if (sayfano == sayfanumara) sayfayonlendirme += "<b>" + sayfanumara + "</b>";
                     else if (sayfanumara != sayfano) sayfayonlendirme += "<a href=Admin_saticisayfasi.aspx?sayfano=" + sayfanumara + ">" + " " + sayfanumara + " " + "</a>";
                }
                if (sayfano == toplamsayfa)
                {
                     sayfayonlendirme += "<b>" + sayfano + "</b>";
                }

                if (sayfano < toplamsayfa)
                {
                    sayfayonlendirme += "<a href=Admin_saticisayfasi.aspx?sayfano=" + (sayfano + 1) + "> Sonraki </a>";
                }
                    sayfalalbl.Text = sayfayonlendirme;
            }

        }
    }
}