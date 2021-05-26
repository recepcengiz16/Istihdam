using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Istıhdam
{
    public class Musteriler
    {
        int uyeid;
        String kuladi;
        String sifre;
        String adsoyad;
        String email;
        String adres;
        Sehirler plaka;
        Boolean onay;
        String telefon;
        DateTime dogtar;

        public int Uyeid { get => uyeid; set => uyeid = value; }
        public string Kuladi { get => kuladi; set => kuladi = value; }
        public string Sifre { get => sifre; set => sifre = value; }
        public string Adsoyad { get => adsoyad; set => adsoyad = value; }
        public string Email { get => email; set => email = value; }
        public string Adres { get => adres; set => adres = value; }
        public Sehirler Plaka { get => plaka; set => plaka = value; }
        public bool Onay { get => onay; set => onay = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public DateTime Dogtar { get => dogtar; set => dogtar = value; }
    }
}