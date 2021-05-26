using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Istıhdam
{
    public partial class Uyegiris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void musterigirisbtn_Click(object sender, EventArgs e)
        {
            Musteriler musteri = new Musterilerdao().uyegiriskontrol(musteriaditxt.Text, musterisifretxt.Text);
            Session["musteriadsoyad"]=musteri.Adsoyad;
            if (Session["musteriadsoyad"] == null)
            {
                musterimesajlbl.Text = "Böyle biri kayıtlı değil veya bilgiler yanlış"; 
            }
            else
            {
                Session["musteriid"] = musteri.Uyeid;
                Response.Redirect("Musteriprofil.aspx");
            }
        }

        protected void saticigirisbtn_Click(object sender, EventArgs e)
        {
            Saticilar satici = new Saticilardao().uyegiriskontrol(saticiaditxt.Text, saticisifretxt.Text);
            Session["saticiad"] = satici.Saticiad;
            Session["saticisoyad"] = satici.Saticisoyad;
            if (Session["saticiad"] == null)
            {
                 saticimesajlbl.Text = "Böyle biri kayıtlı değil veya bilgiler yanlış"; 
            }
            else
            {
                Session["saticiid"] = satici.Saticiid;
                Response.Redirect("Saticiprofil.aspx");
            }
        }

        protected void musterikayitbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Uyekayit.aspx?uyekayit=0");
        }

        protected void saticikayitbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Uyekayit.aspx?uyekayit=1");
        }
    }
}