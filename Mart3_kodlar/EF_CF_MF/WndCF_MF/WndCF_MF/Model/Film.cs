using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WndCF_MF.Model
{
    [Table("Filmler")]
   public class Film
    {
        public int FilmID { get; set; }
        [Column(TypeName ="varchar")]
        [StringLength(100)]
        public string FilmAdi{ get; set; }

        public int KategoriID { get; set; }

        public int YonetmenID { get; set; }

        public short Sure { get; set; }

        public  Kategori Kategori { get; set; }

        public Yonetmen Yonetmen { get; set; }

        public  ICollection<Film_Oyuncu> Oyuncular { get; set; }







    }

}
