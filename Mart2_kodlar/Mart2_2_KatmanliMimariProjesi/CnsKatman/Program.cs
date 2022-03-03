using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using BLL;

namespace CnsKatman
{
    class Program
    {
        static void Main(string[] args)
        {


            KitapBLL bll = new KitapBLL();

            bll.KitapEkle(new Kitap() { KitapAdi = "Canakkale Sehitlerine", KategoriID = 1, YazarID = 1 });
            foreach (var item in bll.KitapListe())
            {
                Console.WriteLine(item.KitapID + " " + item.KitapAdi + " " + item.KategoriID + " " + item.YazarID);
            }
            Console.WriteLine(" *** ");
            foreach (var yazar in bll.KitapListeYazar(1))
            {
                Console.WriteLine(yazar.YazarID + " " + yazar.KitapAdi);
            }
            Console.WriteLine(" *** ");
            foreach (var kitap in bll.KitapListeKategori(2))
            {
                Console.WriteLine(kitap.KategoriID + " " + kitap.KitapAdi);
            }
        }
    }

    internal class KitapBLL
    {
    }
}
}
