using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WndCF_MF.DAL;
using WndCF_MF.Model;
namespace WndCF_MF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FilmDB db = new FilmDB();
            dataGridView1.DataSource = db.Filmler.ToList();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            FilmDB db = new FilmDB();

            //var liste = from f in db.Filmler
            //            select new { f.FilmID, Ad = f.FilmAdi, f.Kategori.KategoriAdi, f.Yonetmen.YonetmenAdi };

            var liste = db.Filmler.ToList();
            dataGridView1.DataSource = liste.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Modelde navigation Prop. önünde "virtual" olup olmamasına göre calismasi değişir.
            FilmDB db = new FilmDB();

            var liste = db.Filmler.Include("Kategori").Include("Yonetmen").ToList();

            dataGridView1.DataSource = liste.ToList();
        }

        FilmDB db = new FilmDB();
        private void button5_Click(object sender, EventArgs e)
        {
            var film = db.Filmler.Find(1);
            var film2 = db.Filmler.Where(f => f.FilmID == 1).SingleOrDefault();



        }

       
        private void button4_Click(object sender, EventArgs e)
        {
            db.Kategoriler.Add(new Kategori { KategoriAdi = "Animasyon" });

            db.SaveChanges();


        }

        private void button7_Click(object sender, EventArgs e)
        {
            var kat = db.Kategoriler.Find(3);

            db.Entry<Kategori>(kat).State = System.Data.Entity.EntityState.Modified;

            kat.KategoriAdi = "Eğlence";

            db.SaveChanges();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var kat = db.Kategoriler.Find(4);  // find primary key e göre, primary key i 5 olanı sil yani ıd si 5 olanı.

            db.Kategoriler.Remove(kat);

            db.SaveChanges();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string strAra = textBox1.Text;

            var result = db.Filmler.Where(f => f.FilmAdi.Contains(strAra));

            dataGridView1.DataSource = result.ToList();
        }
    }
}
