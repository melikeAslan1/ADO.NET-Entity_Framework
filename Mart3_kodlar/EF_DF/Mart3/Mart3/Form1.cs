using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mart3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        KitapDBEntities db = new KitapDBEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = db.kitaplar.ToList();

            db.Database.Log = Mesaj;

            dataGridView2.DataSource = db.Database.SqlQuery<Kategoriler>("SELECT * FROM Kategoriler").ToList<Kategoriler>();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.kitaplar.Add(new kitaplar { KitapAdi= "Harry Potter", KategoriID=2, YazarID= 2});

            db.SaveChanges();

        }

        public void Mesaj(string str)
        {
            MessageBox.Show(str);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // kitaplarla kategorileri join yap ekrana yaz.

            //var result = from k in db.kitaplar
            //             join kat in db.Kategoriler
            //             on k.KategoriID equals kat.KategoriID
            //             select new { k.KitapID, k.KitapAdi, kat.KategoriAdi };

            var result = from k in db.kitaplar
                         select new { k.KitapID, k.KitapAdi, k.Kategoriler.KategoriAdi }; // k nın içinde kategoriler var bu işte nevigation property dir. 


            dataGridView1.DataSource = result.ToList();



        }
    }
}
