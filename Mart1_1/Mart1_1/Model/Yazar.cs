using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mart1_1.Model
{
    class Yazar
    {
        public int YazarID { get; set; }

        public string YazarAdi { get; set; }

        public string YazarSoyad { get; set; }

        public string YazarADSOYAD { get=> YazarAdi + " " + YazarSoyad; }

        
    }
}