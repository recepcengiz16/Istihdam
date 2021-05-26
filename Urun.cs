using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Istıhdam
{
    public class Urun
    {
        int urunid;
        String urunadi;
        double fiyat;
        String aciklama;
        String resim;
        Kategoriler kateno;
        Altkategoriler altkategorino;
        Saticilar saticiid;

        public int Urunid { get => urunid; set => urunid = value; }
        public string Urunadi { get => urunadi; set => urunadi = value; }
        public double Fiyat { get => fiyat; set => fiyat = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }
        public string Resim { get => resim; set => resim = value; }
        public Kategoriler Kateno { get => kateno; set => kateno = value; }
        public Altkategoriler Altkategorino { get => altkategorino; set => altkategorino = value; }
        public Saticilar Saticiid { get => saticiid; set => saticiid = value; }
    }
}