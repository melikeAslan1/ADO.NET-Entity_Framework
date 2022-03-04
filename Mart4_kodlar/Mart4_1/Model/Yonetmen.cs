using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mart4_1.Model
{
    public class Yonetmen:IEntity
    {
        public int YonetmenID { get; set; }

        public string YonetmenAdi { get; set; }

        public ICollection<Film> Filmler { get; set; }
    }
}
