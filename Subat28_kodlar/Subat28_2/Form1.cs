using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subat28_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // butonun içine bütün kod yazılmazzz..
            //sadece şimdi yazıcaz.

            // bu baglantılı yöntem.

            string strConn = "Data Source=.;Initial Catalog=KitapDB;Integrated Security=True";

            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Kitaplar", conn);

            SqlDataReader dr = cmd.ExecuteReader();
            // dr indeksleyicidir. indeksleyicidir bak...   bir class ın sanki bir diziymiş gibi kullanılmasıdır indeksleyici. 

            string baslik = "";

            for (int i = 0; i < dr.FieldCount; i++)
            {
                baslik += dr.GetName(i).ToUpper() + " ";
            }

            listBox1.Items.Add(baslik);

           // dr.Read();  // bir taneyi okur.

            while(dr.Read())
            {
                string satir = "";
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    satir += dr[i] + " ";
                }

               // listBox1.Items.Add(dr[0] + " " + dr["KitapAdi"]);
                listBox1.Items.Add(satir);
            }
            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strConn = "Data Source=.;Initial Catalog=KitapDB;Integrated Security=True";

            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Kitaplar(KitapAdi,KategoriID,YazarID) VALUES (@ad, @kID, @yID) ",conn);

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@kID", textBox3.Text);

            cmd.Parameters.AddWithValue("@YID", textBox2.Text);


            cmd.ExecuteNonQuery();
            conn.Close();

           // execute reader(select cümlelerinde kullanılır.), execute nonquery(insert into, update, delete lerde kullanılır.)
           // execute scalar(geriye sadece bir değer dönecekse kullanılır.) 

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strConn = "Data Source=.;Initial Catalog=KitapDB;Integrated Security=True";

            //DataTable
             //Dataset - bir veritabanı gibi davranır, bir dataset içinde bir sürü data table olabilir..-

            SqlDataAdapter da = new SqlDataAdapter("select * from Kitaplar", strConn);

            DataTable dt = new DataTable();

            da.Fill(dt);

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    string satir = "";
            //    for (int j = 0; j < dt.Columns.Count; j++)
            //    {
            //        satir += dt.Rows[i][j] + " ";
            //    }
            //    listBox1.Items.Add(satir);
            //}

            // con open con close yazmadım.
            DataRow yeni = dt.NewRow();
            yeni[0] = 123;
            yeni[1] = "Serenat";

            dt.Rows.Add(yeni);
            SqlCommandBuilder scb = new SqlCommandBuilder(da);


            da.Update(dt);
            dt.Rows[0].RowState()= DataRowState.
            dataGridView1.DataSource = dt;


        }
    }
}
