using System;

namespace WndApp2.Model
{
    class Kitap
    {

        public int KitapID { get; set; }
        public int? KategoriID { get; set; }
        public int? YazarID { get; set; }
        public string KitapAdi { get; set; }
        public DateTime? EklenmeTarihi { get; set; }
        public int? GoruntulemeSayi { get; set; }
    }
}
