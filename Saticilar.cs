using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Istıhdam
{
    public class Saticilar
    {
        int saticiid;
        String saticiad;
        String saticisoyad;
        String kuladi;
        String sifre;
        String email;
        String telefon;
        String adres;
        Sehirler plaka;
        DateTime dogtar;

        public int Saticiid { get => saticiid; set => saticiid = value; }
        public string Saticiad { get => saticiad; set => saticiad = value; }
        public string Saticisoyad { get => saticisoyad; set => saticisoyad = value; }
        public string Kuladi { get => kuladi; set => kuladi = value; }
        public string Sifre { get => sifre; set => sifre = value; }
        public string Email { get => email; set => email = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public string Adres { get => adres; set => adres = value; }
        public Sehirler Plaka { get => plaka; set => plaka = value; }
        public DateTime Dogtar { get => dogtar; set => dogtar = value; }
    }
}