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
    }
}
