using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ogrenciProje
{
    internal class Program
    {
        static List<Personel> personelList = new List<Personel>();
        public static int silmesayaci=0;

        static void Main(string[] args)
        {
            Menu();
            Console.ReadLine();
        }
        static void Menu()
        {
            Console.WriteLine("Personel Listesi Olustumak İçin= '1' e basınız.. ");
            Console.WriteLine("Listeyi Görüntülemek için '2' ye Basınız");
            Console.WriteLine("Personel Silmek İçin  '3' e Basınız");
            Console.WriteLine("Personel Güncellemek  için '4' e Basınız");
            Console.WriteLine("Personel Eklemek  için '5' e Basınız");
            Console.WriteLine("Personel Detayları  için '6' ya Basınız");
            string secim = Console.ReadLine();
            if (secim == "1")
            {
                CreateList();
            }
            else if (secim == "2")
            {
                Console.WriteLine("---------------------");
                perList(personelList);
            }
            else if (secim == "3")
            {
                personelDelete();
            }
            else if (secim == "4")
                personelUpdate();
            else if (secim == "5")
                personelAdd();
            else if (secim == "6")
            {
                personelDetails();
            }
            Menu();
        }
        static void personelDetails()
        {
            Console.WriteLine(" Personel Id= ");
            int id = Convert.ToInt32(Console.ReadLine());
            Personel secilenPersonel = personelList.Where(x => x.id == id).FirstOrDefault();
            Console.WriteLine("Detaylar  ");
            Console.WriteLine("*************");
            Console.WriteLine(secilenPersonel.unvan()+"-"+secilenPersonel.Yas());
            Console.WriteLine("*************");
            Console.WriteLine("Adres = ");
            foreach (var item in secilenPersonel.AdresAl())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("*************");
        }
        static void personelAdd()
        {
            Random random = new Random();
            Personel yeniPersonel = new Personel();
            Console.WriteLine("Ad Giriniz : ");
            string ad = Console.ReadLine();
            Console.WriteLine("Soyad Giriniz : ");
            string soyad = Console.ReadLine();
            yeniPersonel.id=personelList.Max(x=>x.id)+1;
            yeniPersonel.ad = ad;
            yeniPersonel.soyad = soyad;
            yeniPersonel.maas = random.Next(5500,10000);
            personelList.Add(yeniPersonel);
            perList(personelList);
            
        }
        static void personelUpdate()
        {
            Console.WriteLine("Güncelllenecek Personel Id= ");
            int guncellenecekId = Convert.ToInt32(Console.ReadLine());
            Personel guncellenecekPersonel = personelList.Where(x => x.id == guncellenecekId).FirstOrDefault();
            Console.WriteLine("Ad Giriniz : ");
            string isim = Console.ReadLine();
            Console.WriteLine("Soyad Giriniz : ");
            string soyad = Console.ReadLine();
            guncellenecekPersonel.ad = isim;
            guncellenecekPersonel.soyad = soyad;
            perList(personelList);
        } 
        static void personelDelete()
        {
            Console.WriteLine("Silinecek Personel Id= ");
            int silinecekId = Convert.ToInt32(Console.ReadLine());
            Personel silinecekPersonel = personelList.Where(x => x.id == silinecekId).FirstOrDefault();
            personelList.Remove(silinecekPersonel);
            perList(personelList);

        }
        static void clearList()
        {
            personelList.Clear();
            CreateList();
        }

        static void perList(List<Personel> ls)
        {
            Console.WriteLine("id      ad     soyad  maas ");
            Console.WriteLine("************************");
            foreach (var item in ls)
            {
                Console.WriteLine($"{item.id} {item.ad}   {item.soyad} {item.maas}");
            }
            toplamAl(ls);

        }
        public static void toplamAl(List<Personel> ls)
        {
            Console.WriteLine("**************************");
            //1.yol
            int toplamMaas = 0;
            double ortMaas = 0;
            int toplamKisi = 0;
            int toplamErkek = 0;
            int toplamKadın = 0;
            int toplamErkekMaas = 0;
            int toplamKadınMaas = 0;
            //foreach (var item in ls)
            //{
            //    toplamKisi++;
            //    toplamMaas += item.maas;
            //    if (item.cinsiyet == "E") 
            //    { 
            //        toplamErkek++;
            //        toplamErkekMaas += item.maas;
            //    }
            //    else 
            //    {
            //        toplamKadın++;
            //        toplamKadınMaas += item.maas;
            //    }
            //}
            //ortMaas = toplamMaas / toplamKisi;
            //Console.WriteLine("Toplam Kişi= "+toplamKisi);
            //Console.WriteLine("Toplam Maaş= " + toplamMaas);
            //Console.WriteLine("Toplam Erkek= " + toplamErkek);
            //Console.WriteLine("Toplam Erkek Maaş= " + toplamErkekMaas);
            //Console.WriteLine("Toplam Kadın= " + toplamKadın);
            //Console.WriteLine("Toplam Kadın Maaş= " + toplamKadınMaas);
            //Console.WriteLine("Ortalama Maaş= " + ortMaas);

            //2.yol daha  çok kullanılır...

            toplamKisi = ls.Count;
            toplamErkek = ls.Where(x => x.cinsiyet == "E").Count();
            toplamKadın = ls.Where(x => x.cinsiyet == "K").Count();
            toplamErkekMaas = ls.Where(x => x.cinsiyet == "E").Sum(x => x.maas);
            toplamKadınMaas = ls.Where(x => x.cinsiyet == "K").Sum(x => x.maas);
            toplamMaas = ls.Sum(x => x.maas);
            ortMaas = ls.Average(x => x.maas);
            Console.WriteLine("Toplam Kişi= " + toplamKisi);
            Console.WriteLine("Toplam Maaş= " + toplamMaas);
            Console.WriteLine("Toplam Erkek= " + toplamErkek);
            Console.WriteLine("Toplam Erkek Maaş= " + toplamErkekMaas);
            Console.WriteLine("Toplam Kadın= " + toplamKadın);
            Console.WriteLine("Toplam Kadın Maaş= " + toplamKadınMaas);
            Console.WriteLine("Ortalama Maaş= " + ortMaas);
        }
        static void CreateList()
        {
            Random random = new Random();
            for (int i = 1; i <= 5; i++)
            {
                Personel personel = new Personel();
                personel.id = i;
                personel.ad = FakeData.NameData.GetFirstName();
                personel.soyad = FakeData.NameData.GetSurname();
                personel.cadde = FakeData.PlaceData.GetStreetName();
                int yas = random.Next(20, 50);
                personel.dogumTarih = DateTime.Now.AddYears(yas * -1);
                personel.maas = random.Next(2000, 10000);
                int cns = random.Next(0, 2);
                if (cns == 0)
                    personel.cinsiyet = "E";
                else
                    personel.cinsiyet = "K";
                personel.ilce = FakeData.PlaceData.GetCountry();
                personel.sehir = FakeData.PlaceData.GetCity();
                personel.kapiNo = random.Next(1, 150);
                personelList.Add(personel);
            }
        }
    }
}
