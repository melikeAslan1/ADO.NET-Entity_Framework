using Mart4_1.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mart4_1.DAL
{
    public class GnFilmDB:DbContext
    {
        public DbSet<Film> Filmler { get; set; }

        public DbSet<Yonetmen> Yonetmenler { get; set; }

        public DbSet<Kategori> Kategoriler { get; set; }



    }
}
