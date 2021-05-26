using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Istıhdam
{
    public class Sepetim
    {
        Urun urunum;
        int adet;

        public Urun Urunum { get => urunum; set => urunum = value; }
        public int Adet { get => adet; set => adet = value; }
    }
}