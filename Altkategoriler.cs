using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Istıhdam
{
    public class Altkategoriler
    {
        int altkateno;
        String altkateadi;
        int anakateno;

        public int Altkateno { get => altkateno; set => altkateno = value; }
        public string Altkateadi { get => altkateadi; set => altkateadi = value; }
        public int Anakateno { get => anakateno; set => anakateno = value; }
    }
}