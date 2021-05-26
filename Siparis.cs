using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Istıhdam
{
    public class Siparis
    {
        Musteriler uyeid;
        Urun urunid;
        int adet;
        DateTime sip_tarih;
        int sipno;
        int kayitno;

        public Musteriler Uyeid { get => uyeid; set => uyeid = value; }
        public Urun Urunid { get => urunid; set => urunid = value; }
        public int Adet { get => adet; set => adet = value; }
        public DateTime Sip_tarih { get => sip_tarih; set => sip_tarih = value; }
        public int Sipno { get => sipno; set => sipno = value; }
        public int Kayitno { get => kayitno; set => kayitno = value; }
    }
}