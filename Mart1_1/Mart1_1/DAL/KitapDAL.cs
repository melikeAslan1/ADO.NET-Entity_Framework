using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Mart1_1.Model;
using System.Data.SqlClient;

namespace Mart1_1.DAL
{
    class KitapDAL
    {
        private string strConn;
        public KitapDAL()
        {
            strConn = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        }

        //public List<Kitap> KitapListe()
        //{
        //    // metotla gelen metotla gittiği için performan olarak List i metot içine yazmak daha iyi, tabiki list i dısarıda kullanmıyorsam

        //    List<Kitap> kitaplar = new List<Kitap>();

        //    SqlConnection conn = new SqlConnection(strConn);

        //    conn.Open();

        //    // AC KAPAYLA YAPILAN HER YERDE BU YAPI OTOMATİK OLARAK KAPATMA İŞLEMİNİ YAPAR. USİNG KULLANIMI.
        //    using(SqlCommand cmd= new SqlCommand("SELECT * from Kitaplar", conn))  // bu kullanım tavsiye ediliyor,
        //                                                                           // çünkü unutulabiliyor kapatmak.
        //    {
        //        SqlDataReader dr = cmd.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            Kitap kitap = new Kitap();


        //            kitap.KitapID = Convert.ToInt32(dr[0]);
        //            kitap.KitapAdi = dr[1].ToString();
        //            kitap.KategoriID = dr.IsDBNull(2) ?0 :(int?)dr[2];


        //            kitap.YazarID = dr.IsDBNull(3) ? 0 : (int?)dr[3];
        //            kitap.EklenmeTarihi = dr.IsDBNull(4) ? DateTime.Parse("1/1/2000") : DateTime.Parse(
        //                dr[4].ToString());
        //            kitap.GoruntulemeSayisi = dr.IsDBNull(5) ? 0 : (int?)dr[5];
        //            kitaplar.Add(kitap);
        //        }
        //    }
        //    return kitaplar;
        //}

        public List<Kitap> KitapListeVM()
        {
            // metotla gelen metotla gittiği için performan olarak List i metot içine yazmak daha iyi, tabiki list i dısarıda kullanmıyorsam

            List<KitapVM> kitaplar = new List<KitapVM>();

            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();

            // AC KAPAYLA YAPILAN HER YERDE BU YAPI OTOMATİK OLARAK KAPATMA İŞLEMİNİ YAPAR. USİNG KULLANIMI.
            using (SqlCommand cmd = new SqlCommand("SELECT * from Kategoriler kat INNER JOIN Kitaplar ktp ON kat.KategoriID=ktp.KategoriID INNER JOIN Yazarlar yzr ON" +
                "ktp.YazarID=yzr.YazarID", conn))  // bu kullanım tavsiye ediliyor,
                                                   // çünkü unutulabiliyor kapatmak.
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    KitapVM kitap = new KitapVM();
                    kitap.KitapID = Convert.ToInt32(dr["KitapID"]);
                    kitap.KitapAdi = dr["KitapAdi"].ToString();
                    kitap.KategoriAdi = dr["kategoriAdi"].ToString();
                    kitap.YazarAdi = dr["YazarAdi"].ToString();

                    kitaplar.Add(kitap);
                }
            }
            return kitaplar;
        }

        public List<Kitap> Kategoriler()
        {
            // metotla gelen metotla gittiği için performan olarak List i metot içine yazmak daha iyi, tabiki list i dısarıda kullanmıyorsam

            List<Kategori> kategoriler = new List<Kategori>();

            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();

            // AC KAPAYLA YAPILAN HER YERDE BU YAPI OTOMATİK OLARAK KAPATMA İŞLEMİNİ YAPAR. USİNG KULLANIMI.
            using (SqlCommand cmd = new SqlCommand("SELECT * from Kategoriler kat INNER JOIN Kitaplar ktp ON kat.KategoriID=ktp.KategoriID INNER JOIN Yazarlar yzr ON" +
                "ktp.YazarID=yzr.YazarID", conn))  // bu kullanım tavsiye ediliyor,
                                                   // çünkü unutulabiliyor kapatmak.
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
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
            // metotla gelen metotla gittiği için performan olarak List i metot içine yazmak daha iyi, tabiki list i dısarıda kullanmıyorsam

            List<Yazar> yazarlar = new List<Yazar>();

            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();

            // AC KAPAYLA YAPILAN HER YERDE BU YAPI OTOMATİK OLARAK KAPATMA İŞLEMİNİ YAPAR. USİNG KULLANIMI.
            using (SqlCommand cmd = new SqlCommand("SELECT * from Yazarlar", conn))  // bu kullanım tavsiye ediliyor,
                                                   // çünkü unutulabiliyor kapatmak.
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Yazar yazar = new Yazar()
                    {
                        YazarID = Convert.ToInt32(dr[0]),
                        YazarAdi = dr[1].ToString(),
                        YazarSoyad= dr[2].ToString()

                    };

                    yazarlar.Add(yazar);
                }
            }
            return yazarlar;
        }

        public void KitapEkle(Kitap kitap)
        {
            SqlConnection conn = new SqlConnection(strConn);

            conn.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;

            cmd.CommandText = "INSERT INTO Kitaplar VALUES (@ad, @katID, @yazarID, getdate(), 0)";

            cmd.Parameters.AddWithValue("@ad", kitap.KitapAdi);

            cmd.Parameters.AddWithValue("@katID", kitap.KategoriID);

            cmd.Parameters.AddWithValue("@yazarID", kitap.)
            
        }

        public void KitapSil(int kitapID) // kitapSil de sadece silme işlemi var. ıd yi bulup siliyor.
        {

        }

        //public void KGun(int kID, string ad)  // bu mantıksız.
        //{

        //}

        public void KitapGuncelle(Kitap kitap)  // burada kitabı bulup özelliklerini değiştir. 
        {

        }

        public Kitap KitapBul(int id)
        {
            return null; 
        }


    }
}
