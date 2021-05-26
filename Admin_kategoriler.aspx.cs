using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Istıhdam
{
    public partial class Admin_kategoriler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack==false)
            {
                ArrayList kategoriler = new Kategorilerdao().tumkategorilerigetir();
                int sayi = 1;
                foreach (Kategoriler gelenkat in kategoriler)
                {
                    anakatedrop.Items.Add(gelenkat.Kateadi);
                    anakatedrop.Items[sayi].Value = gelenkat.Kateno.ToString();
                    altkateanasecimdrop.Items.Add(gelenkat.Kateadi);
                    altkateanasecimdrop.Items[sayi].Value = gelenkat.Kateno.ToString();
                    sayi++;
                }
            }
            if (Request.QueryString["kateeklendi"] != null) mesajlbl.Text = "Kategori başarıyla eklenmiştir.";               
            else if (Request.QueryString["altkateeklendi"] != null) mesajlbl.Text = "Alt kategori başarıyla eklendi";
            else mesajlbl.Text = "";

            if(Request.QueryString["kategir"]!=null)
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;
            }
            if (Request.QueryString["altkategir"]!=null)
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                Panel3.Visible = false;
            }
            if (Request.QueryString["kategoster"]!=null)
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = true;
            }
            
            
        }

        protected void kategoriradio_CheckedChanged(object sender, EventArgs e)
        {
            Response.Redirect("Admin_kategoriler.aspx?kategir=ok");
        }

        protected void altkategoriradio_CheckedChanged(object sender, EventArgs e)
        {
            Response.Redirect("Admin_kategoriler.aspx?altkategir=ok");
        }

        protected void tumkatelisteleradio_CheckedChanged(object sender, EventArgs e)
        {
            Response.Redirect("Admin_kategoriler.aspx?kategoster=ok");
        }

        protected void kateeklebtn_Click(object sender, EventArgs e)
        {
            int sayi = new Kategorilerdao().kategoriekle(kateaditxt.Text);
            if (sayi == 1) Response.Redirect("Admin_kategoriler.aspx?kateeklendi=ok");
        }

        protected void anakatedrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            altkatedrop.Items.Clear();
            altkatedrop.Items.Add("Seçiniz");
            altkatedrop.Items[0].Value = "0";
            ArrayList altkategoriler = new Kategorilerdao().altkategorilerigetir(Convert.ToInt32(anakatedrop.SelectedItem.Value));
            int sayi = 1;
            foreach (Altkategoriler gelenkat in altkategoriler)
            {
                altkatedrop.Items.Add(gelenkat.Altkateadi);
                altkatedrop.Items[sayi].Value = gelenkat.Altkateno.ToString();
                sayi++;
            }
        }

        protected void altkateeklebtn_Click(object sender, EventArgs e)
        {
            int kontrol = new Kategorilerdao().altkategoriekle(Convert.ToInt32(altkateanasecimdrop.SelectedItem.Value),altkateaditxt.Text);
            if (kontrol == 1) Response.Redirect("Admin_kategoriler.aspx?altkateeklendi=ok");
        }
    }
}