using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WndApp2.Model;

namespace WndApp2.DAL
{
    class KitapDAL
    {
        private string strConn;
        public KitapDAL()
        {
            strConn = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        }

        public List<Kitap> KitapListe()
        {
            List<Kitap> kitaplar = new List<Kitap>();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            //Open close gibi yapılarda otomatik kapatma işlemini kendisi yapar.
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Kitaplar", conn))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                //Kayıt sayısını bilmediğimiz için bu şekilde yaptık.True şekilde geliyorsa okunacan şeyler var devam eder,
                //false derse okunacak şey kalmadı o yüzden bitirir .Satır satır yapıyor
                while (dr.Read())
                {
                    //İlişki yapı olduğu için veritabanı objeye çevirmemiz lazımdı.Aşağıdaki işlemleri o yüzden yaptık.
                    Kitap kitap = new Kitap();
                    kitap.KitapID = Convert.ToInt32(dr[0]);
                    kitap.KitapAdi = dr[1].ToString();
                    kitap.KategoriID = dr.IsDBNull(2) ? 0 : (int?)dr[2];
                    kitap.YazarID = dr.IsDBNull(3) ? 0 : (int?)dr[3];
                    kitap.EklenmeTarihi = dr.IsDBNull(4) ? DateTime.Parse("1/1/2000") : DateTime.Parse(dr[4].ToString());
                    kitap.GoruntulemeSayi = dr.IsDBNull(5) ? 0 : (int?)dr[5];

                    kitaplar.Add(kitap);
                }
              
            }
            return kitaplar;
        }

        public List<KitapVM> KitapListeVM()
        {
            List<KitapVM> kitaplar = new List<KitapVM>();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            //Open close gibi yapılarda otomatik kapatma işlemini kendisi yapar.
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Kategoriler kat INNER JOIN Kitaplar ktp ON " +
                "kat.KategoriID=ktp.KategoriID INNER JOIN Yazarlar yzr ON ktp.YazarID=yzr.YazarID", conn))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                //Kayıt sayısını bilmediğimiz için bu şekilde yaptık.True şekilde geliyorsa okunacan şeyler var devam eder,
                //false derse okunacak şey kalmadı o yüzden bitirir .Satır satır yapıyor
                while (dr.Read())
                {
                    //İlişki yapı olduğu için veritabanı objeye çevirmemiz lazımdı.Aşağıdaki işlemleri o yüzden yaptık.
                    KitapVM kitap = new KitapVM();
                    kitap.KitapID = Convert.ToInt32(dr["KitapId"]);
                    kitap.KitapAdi = dr["KitapAdi"].ToString();
                    kitap.KategoriAdi = dr["KategoriAdi"].ToString();
                    kitap.YazarAdi = dr["YazarAdi"].ToString();


                    kitaplar.Add(kitap);
                }
                
            }
            return kitaplar;
        }

        public void KitapEkle(Kitap kitap)
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Kitaplar VALUES(@ad,@katID,@yazarID,getdate(),0)";

            cmd.Parameters.AddWithValue("@ad", kitap.KitapAdi);
            cmd.Parameters.AddWithValue("@katID", kitap.KategoriID);
            cmd.Parameters.AddWithValue("@yazarID", kitap.YazarID);
            cmd.ExecuteNonQuery();//crud işlemlerini bu komut ile yapıyoruz
            conn.Close();
        }
        public void KitapGuncelle(Kitap kitap)
        {
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Kitaplar SET KitapAdi=@ad,KategoriID=@katID,YazarID=@yazID WHERE KitapID=@id", conn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", kitap.KitapID);
            cmd.Parameters.AddWithValue("@ad",kitap.KitapAdi);
            cmd.Parameters.AddWithValue("@katID",kitap.KategoriID);
            cmd.Parameters.AddWithValue("@yazID",kitap.YazarID);

            cmd.ExecuteNonQuery();
            conn.Close();

           
        }

        public void KitapSil(int kitapID)
        {
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE Kitaplar WHERE KitapID=@id", conn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",kitapID);
            

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public Kitap KitapBul(int id)
        {
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Kitaplar WHERE KitapID=@id", conn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id",id);

            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();
            Kitap kitap = new Kitap();
            kitap.KitapID = -1;
            if(dr.HasRows)
            {
                kitap.KitapID = Convert.ToInt32(dr[0]);
                kitap.KitapAdi = dr[1].ToString();
                kitap.KategoriID = dr.IsDBNull(2) ? 0 : (int)dr[2];
                kitap.YazarID = dr.IsDBNull(3) ? 0 : (int)dr[2];

            }
            conn.Close();
            return kitap;
        }

        public List<Kategori> Kategoriler()
        {
            List<Kategori> kategoriler = new List<Kategori>();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            //Open close gibi yapılarda otomatik kapatma işlemini kendisi yapar.
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Kategoriler", conn))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                //Kayıt sayısını bilmediğimiz için bu şekilde yaptık.True şekilde geliyorsa okunacan şeyler var devam eder,
                //false derse okunacak şey kalmadı o yüzden bitirir .Satır satır yapıyor
                while (dr.Read())
                {
                    //İlişki yapı olduğu için veritabanı objeye çevirmemiz lazımdı.Aşağıdaki işlemleri o yüzden yaptık.
                    Kategori kategori = new Kategori()
                    {
                        KategoriID = Convert.ToInt32(dr[0]),
                        KategoriAdi = dr[1].ToString()
                    };
                    kategoriler.Add(kategori);
                }
            }
            return kategoriler;
        }

        public List<Yazar> Yazarlar()
        {
            List<Yazar> yazarlar = new List<Yazar>();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            //Open close gibi yapılarda otomatik kapatma işlemini kendisi yapar.
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Yazarlar", conn))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                //Kayıt sayısını bilmediğimiz için bu şekilde yaptık.True şekilde geliyorsa okunacan şeyler var devam eder,
                //false derse okunacak şey kalmadı o yüzden bitirir .Satır satır yapıyor
                while (dr.Read())
                {
                    //İlişki yapı olduğu için veritabanı objeye çevirmemiz lazımdı.Aşağıdaki işlemleri o yüzden yaptık.
                    Yazar yazar = new Yazar()
                    {
                        YazarID = Convert.ToInt32(dr[0].ToString()),
                        YazarAdi = dr[1].ToString(),
                        YazarSoyad = dr[2].ToString()
                    };
                    yazarlar.Add(yazar);
                }
            }
            return yazarlar;
        }
    }
}
