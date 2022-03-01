using Mart1_1.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using W



namespace Mart1_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            KitapDAL db = new KitapDAL();
            dataGridView1.DataSource = db.KitapListeVM();

            cmbYazar.DataSource = db.Yazarlar();

            cmbYazar.DisplayMember = "YazarADSOYAD";

            cmbYazar.ValueMember = "YazarID";

            cmbKategori.DataSource = db.Kategoriler();

            cmbKategori.DisplayMember = "KategoriAdi";

            cmbKategori.ValueMember = "KategoriID";

            cmbKategori

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            KitapDAL db = new KitapDAL();

            KitapDAL kitap = new KitapDAL();

            kitap.KitapAdi = txtKitapAdi.Text;

            kitap.Kategori




        }
    }
}
