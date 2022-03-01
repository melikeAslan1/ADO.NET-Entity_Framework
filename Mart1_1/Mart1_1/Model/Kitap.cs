using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mart1_1.Model
{
    class Kitap
    {
        public int KitapID { get; set; }

        public string KitapAdi { get; set; }

        public int KategoriID { get; set; }

        public int YazarID { get; set; }

        public DateTime EklenmeTarihi { get; set; }

        public int GoruntulemeSayisi { get; set; }
    }
}
