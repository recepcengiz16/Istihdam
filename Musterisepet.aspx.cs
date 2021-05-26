using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;


namespace Istıhdam
{
    public partial class Deneme : System.Web.UI.Page
    {
        ArrayList musterisepeti = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["musteriid"] == null)
            {
                Response.Write("Bu sayfayı üyeler görüntüleyebilir. Lütfen giris yapınız");
                Response.End();
            }
            if (Page.IsPostBack == false)
            {
                int urunid = Convert.ToInt32(Request.QueryString["urunid"]);
                Urun urun = new Urunlerdao().musteritekurungetir(urunid);
                if (Session["sepet"] != null) musterisepeti = (ArrayList)Session["sepet"];

                bool kontrol = false;
                int j = 0;
                foreach (Sepetim sepetcik in musterisepeti)
                {
                    if (sepetcik.Urunum.Urunid == urunid)
                    {
                        ((Sepetim)musterisepeti[j]).Adet += 1;
                        kontrol = true;
                    }
                    j++;
                }
                if (kontrol == false)
                {
                    Sepetim sepet = new Sepetim();
                    sepet.Adet = 1;
                    sepet.Urunum = urun;
                    musterisepeti.Add(sepet);
                }

                Session["sepet"] = musterisepeti;
                tabloyayaz();
            }

        }

        void tabloyayaz()
        {
            double toplamfiyat = 0;
            foreach (Sepetim sepettekiurunum in musterisepeti)
            {
                TableRow satir = new TableRow();
                for (int i = 0; i < 8; i++)
                {
                    TableCell hucre = new TableCell();
                    hucre.BorderStyle = BorderStyle.Solid;
                    hucre.Width = 2;
                    satir.Cells.Add(hucre);
                }

                satir.Cells[0].Text = sepettekiurunum.Urunum.Urunadi;
                satir.Cells[1].Text = sepettekiurunum.Urunum.Fiyat.ToString();
                satir.Cells[2].Text = sepettekiurunum.Urunum.Kateno.Kateadi;
                satir.Cells[3].Text = sepettekiurunum.Urunum.Altkategorino.Altkateadi;

                TextBox adetkutusu = new TextBox();
                adetkutusu.Text = sepettekiurunum.Adet.ToString();
                adetkutusu.ID = "adet" + sepettekiurunum.Urunum.Urunid;
                adetkutusu.Width = 35;
                satir.Cells[4].Controls.Add(adetkutusu);

                Image resim = new Image();
                resim.Height = 120;
                resim.Width = 120;
                resim.ImageUrl = "../urunresimleri/" + sepettekiurunum.Urunum.Resim;
                satir.Cells[5].Controls.Add(resim);

                CheckBox silinecek = new CheckBox();
                silinecek.ID = "sil" + sepettekiurunum.Urunum.Urunid;
                satir.Cells[6].Controls.Add(silinecek);

                Table1.Rows.Add(satir);
                toplamfiyat += sepettekiurunum.Urunum.Fiyat * sepettekiurunum.Adet;
            }
            toplamlbl.Text = "Sepetinizin Toplam Fiyatı=" + toplamfiyat.ToString();
        }

        protected void yenilebtn_Click(object sender, EventArgs e)
        {
            if (Session["sepet"] != null) musterisepeti = (ArrayList)Session["sepet"];
            int sayi = 0;

            ArrayList silineceklistesi = new ArrayList();
            foreach (Sepetim gelenurun in musterisepeti)
            {
                int yeniadet = 0;
                if (Request.Form["adet" + gelenurun.Urunum.Urunid] != "")
                {
                    yeniadet = Convert.ToInt32(Request.Form["adet" + gelenurun.Urunum.Urunid]);
                }
                ((Sepetim)musterisepeti[sayi]).Adet = yeniadet;
                String silinme = Request.Form["sil" + gelenurun.Urunum.Urunid];

                if (silinme == "on" || yeniadet == 0)
                {
                    silineceklistesi.Add(gelenurun.Urunum.Urunid);
                }
                sayi++;
            }
            foreach (int silinecekid in silineceklistesi)
            {
                foreach (Sepetim gelenid in musterisepeti)
                {
                    if (gelenid.Urunum.Urunid == silinecekid)
                    {
                        musterisepeti.Remove(gelenid);
                        break;
                    }
                }
            }
            Session["sepet"] = musterisepeti;
            tabloyayaz();
        }

        protected void satinalbtn_Click(object sender, EventArgs e)
        {
            if (Session["sepet"] != null) musterisepeti = (ArrayList)Session["sepet"];

            int sipno = new Siparisdao().siparisver(Convert.ToInt32(Session["musteriid"]), musterisepeti);
            siparislbl.Text = "Siparişiniz alınmıştır. Sipariş numaranız=" + sipno;
        }

        protected void cikisbtn_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Uyegiris.aspx");
        }
    }
}