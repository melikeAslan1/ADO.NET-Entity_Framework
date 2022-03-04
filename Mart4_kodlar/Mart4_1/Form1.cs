using Mart4_1.BLL;
using Mart4_1.DAL;
using Mart4_1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mart4_1
{
    //katmanlı mimaride generic yapının kullanılması...
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GnFilmDB db = new GnFilmDB();
            GnBLL<Film> film = new GnBLL<Film>(db);
            dataGridView1.DataSource = film.Liste();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GnFilmDB db = new GnFilmDB();
            //GnBLL<Yonetmen> yonetmen = new GnBLL<Yonetmen>(db);

            GnBLL<Kategori> kat = new GnBLL<Kategori>(db);

            Kategori kayegori = new Kategori() { KategoriAdi = "Uzay" };

            kat.Ekle(kayegori);
            //  dataGridView1.DataSource = yonetmen.Liste();

            dataGridView1.DataSource = kat.Liste();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GnFilmDB db = new GnFilmDB();

            GnBLL<Yonetmen> yonetmen = new GnBLL<Yonetmen>(db);

            Yonetmen director = new Yonetmen { YonetmenAdi = "Tarantino" };
            yonetmen.Ekle(director);
          //  GnBLL<Kategori> kategori = new GnBLL<Kategori>(db);
            dataGridView1.DataSource = yonetmen.Liste();
        }
    }
}
