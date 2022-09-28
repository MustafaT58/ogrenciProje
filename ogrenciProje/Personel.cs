using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ogrenciProje
{
    internal class Personel
    {
        public int id { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string cinsiyet { get; set; }
        public DateTime dogumTarih { get; set; }
        public string cadde { get; set; }
        public int kapiNo { get; set; }
        public string ilce { get; set; }
        public string sehir { get; set; }
        public int maas { get; set; }
        public string unvan()
        {
            string unvan = "";
            if (cinsiyet=="E")
            {
                unvan = $"Sayın Bay {ad}  {soyad}";
            }
            else
            {
                unvan = $"Sayın Bayan {ad} {soyad}";
            }
            return unvan;
        }
        public int Yas()
        {
            DateTime bugun = DateTime.Now;
            int yas=bugun.Year-dogumTarih.Year;
            DateTime dogumGunu = dogumTarih.AddYears(yas);
            if (dogumGunu > bugun)
                yas++;
            return yas;
        }
        public List<string> AdresAl()
        {
            List<string> adres = new List<string>();
            adres.Add(unvan());
            adres.Add(cadde);
            adres.Add(kapiNo.ToString());
            adres.Add(ilce+"/"+sehir);
            return adres;
            
        }
    }
}
