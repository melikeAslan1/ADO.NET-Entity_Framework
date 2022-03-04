using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mart4_1.Model
{
   public class Kategori:IEntity
    {
        public int KategoriID { get; set; }

        public string KategoriAdi { get; set; }
        public virtual ICollection<Film> Filmler { get; set; }



    }
}
