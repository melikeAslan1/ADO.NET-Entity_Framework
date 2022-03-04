using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WndCF_MF.Model
{
   public class Kategori
    {
        public int KategoriID { get; set; }

        public string KategoriAdi { get; set; }
        public  ICollection<Film> Filmler { get; set; }



    }
}
