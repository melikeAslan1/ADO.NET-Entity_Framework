using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WndApp2.DAL;
using WndApp2.Model;

namespace WndApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListeYukle();
        }

       private void ListeYukle()
        {
            KitapDAL db = new KitapDAL();
            dataGridView1.DataSource = db.KitapListeVM();

            cmbYazar.DataSource = db.Yazarlar();
            cmbKategori.DataSource = db.Kategoriler();

            cmbKategori.DisplayMember = "KategoriAdi";
            cmbKategori.ValueMember = "KategoriID";

            cmbYazar.DisplayMember = "YazarADSOYAD";
            cmbYazar.ValueMember = "YazarID";
        }

      
     private void ButonDurumlari(bool durum)
        {
            btnEkle.Enabled = durum;
            groupBox1.Enabled = !durum;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            KitapDAL db = new KitapDAL();
            Kitap kitap = new Kitap();
            kitap.KitapID = int.Parse(txtKitapID.Text);
            kitap.KitapAdi = txtKitapAdi.Text;
            kitap.KategoriID = ((Kategori)cmbKategori.SelectedItem).KategoriID;
            kitap.YazarID = ((Yazar)cmbYazar.SelectedItem).YazarID;

            db.KitapGuncelle(kitap);
            ButonDurumlari(true);
            ListeYukle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            KitapDAL db = new KitapDAL();
            Kitap kitap = new Kitap();
            kitap.KitapAdi = txtKitapAdi.Text;
            kitap.KategoriID = ((Kategori)cmbKategori.SelectedItem).KategoriID;
            kitap.YazarID = ((Yazar)cmbYazar.SelectedItem).YazarID;
            db.KitapEkle(kitap);
            ListeYukle();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            KitapDAL db = new KitapDAL();
            if (txtKitapID.Text != "")
            {
                Kitap kitap = db.KitapBul(int.Parse(txtKitapID.Text));
                if (kitap.KitapID > 0)
                {
                    ButonDurumlari(false);
                    txtKitapAdi.Text = kitap.KitapAdi;
                    List<Kategori> katList = ((List<Kategori>)cmbKategori.DataSource);
                    int indis = -1;
                    for (int i = 0; i < katList.Count; i++)
                    {
                        if (katList[i].KategoriID == kitap.KategoriID)
                        {
                            indis = i;
                            break;
                        }
                    }
                    cmbKategori.SelectedIndex = indis;
                    List<Yazar> yazList = ((List<Yazar>)cmbYazar.DataSource);
                    indis = -1;
                    for (int i = 0; i < katList.Count; i++)
                    {
                        if (yazList[i].YazarID == kitap.YazarID)
                        {
                            indis = i;
                            break;
                        }
                    }
                    cmbYazar.SelectedIndex = indis;


                }
                else
                    MessageBox.Show("Aradığınız kayıt bulunamadı...");

            }
            else
                MessageBox.Show("");
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            ButonDurumlari(true);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            KitapDAL db = new KitapDAL();
            DialogResult dr=MessageBox.Show("Emin misiniz?","UYARI",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if(dr==DialogResult.Yes)
                db.KitapSil(int.Parse(txtKitapID.Text));
            ButonDurumlari(true);
            ListeYukle();
        }
    }
}
