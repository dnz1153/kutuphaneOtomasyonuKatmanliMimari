using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VarOlanDegiskenKatmani;
using System.Data;
using System.Data.OleDb;

namespace VeriTabaniKatmani
{
    public class VK_Ogrenci
    {
        public static bool OgrenciKontrol(DK_Ogrenci ogrenci)//Gelen TC ve Sifre ile öğrencinin girisini saglayan metot
        {
            //Gelen Ogrenci_Tc ve Ogrenci_Sifre ile veritabanındaki verileri kontrol etme
            OleDbCommand komut = new OleDbCommand("Select * From Ogrenci Where Ogrenci_Tc=@Ogrenci_Tc and Ogrenci_Sifre=@Ogrenci_Sifre", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            komut.Parameters.AddWithValue("@Ogrenci_Tc", ogrenci.Ogrenci_Tc);
            komut.Parameters.AddWithValue("@Ogrenci_Sifre", ogrenci.Ogrenci_Sifre);
            

            OleDbDataReader dataRead = komut.ExecuteReader();
            bool sonuc=false;
            int sayac = 0;

            //Veritabanindan bir veri okunursa sayac arttırılır.
            while (dataRead.Read())
            {
                sayac++;
            }
            if (sayac > 0)
            {
                //Sayac 0 dan büyükse sonucu true döndür
                sonuc = true;
            }
            //Veritabaninda veri okunuyorsa true - Veritabaninda veri yoksa false döner.
            return sonuc;

        }

        public static string OgrenciSifreKontrol(DK_Ogrenci ogrenci)//Gelen TC,Ad,Soyad ve Yas bilgileri ile öğrencinin sifresini öğrenmesi
        {
            OleDbCommand komut = new OleDbCommand("Select Ogrenci_Sifre,Ogrenci_Tc,Ogrenci_Adi,Ogrenci_Soyadi,Ogrenci_Yas From Ogrenci Where Ogrenci_Tc=@Ogrenci_Tc and Ogrenci_Adi=@Ogrenci_Adi and Ogrenci_Soyadi=@Ogrenci_Soyadi and Ogrenci_Yas=@Ogrenci_Yas",Baglanti.conn);

            Baglanti.ConntectionKontrol(komut);
            komut.Parameters.AddWithValue("@Ogrenci_Tc", ogrenci.Ogrenci_Tc);
            komut.Parameters.AddWithValue("@Ogrenci_Adi", ogrenci.Ogrenci_Adi);
            komut.Parameters.AddWithValue("@Ogrenci_Soyadi", ogrenci.Ogrenci_Soyadi);
            komut.Parameters.AddWithValue("@Ogrenci_Yas", ogrenci.Ogrenci_Yas);
           
            OleDbDataReader dataRead = komut.ExecuteReader();
            string sqlSifre = ""; //Veritabanından gelen sifre için string bir degisken tanımlandı.

            while (dataRead.Read())//Komut işlendikten sonra uygun bir kullanıcı var ise sifresini sqlSifre ye ataması
            {
                sqlSifre = dataRead["Ogrenci_Sifre"].ToString();
            };
            return sqlSifre;

        }
        public static string OgrenciGirisAdSoyadKontrol(DK_Ogrenci ogrenci)
        {
            OleDbCommand komut = new OleDbCommand("Select Ogrenci_Tc,Ogrenci_Adi,Ogrenci_Soyadi From Ogrenci Where Ogrenci_Tc=@Ogrenci_Tc", Baglanti.conn);

            Baglanti.ConntectionKontrol(komut);
            komut.Parameters.AddWithValue("@Ogrenci_Tc", ogrenci.Ogrenci_Tc);

            OleDbDataReader dataRead = komut.ExecuteReader();
            string sqlAdSoyad = ""; //Veritabanından gelen sifre için string bir degisken tanımlandı.

            while (dataRead.Read())//Komut işlendikten sonra uygun bir kullanıcı var ise sifresini sqlSifre ye ataması
            {
                sqlAdSoyad = dataRead["Ogrenci_Adi"].ToString()+" "+dataRead["Ogrenci_Soyadi"].ToString();
            };
            return sqlAdSoyad;

        }
        public static bool OgrenciAyniTCKontrol(DK_Ogrenci ogrenci)
        {
            OleDbCommand komut = new OleDbCommand("Select count(Ogrenci_Tc) FROM Ogrenci Where Ogrenci_Tc=@Ogrenci_Tc",Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            komut.Parameters.AddWithValue("@Ogrenci_Tc", ogrenci.Ogrenci_Tc);
            int count = Convert.ToInt32(komut.ExecuteScalar());

            if (count > 0)
            {
                return false;
            }
            return true;

        }
        public static int OgrenciEkle(DK_Ogrenci ogrenci)
        {
            OleDbCommand komut = new OleDbCommand("Insert Into Ogrenci(Ogrenci_Tc,Ogrenci_Adi,Ogrenci_Soyadi,Ogrenci_Yas,Ogrenci_Cinsiyet,Ogrenci_Sifre) Values(@Ogrenci_Tc,@Ogrenci_Adi,@Ogrenci_Soyadi,@Ogrenci_Yas,@Ogrenci_Cinsiyet,@Ogrenci_Sifre)",Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            komut.Parameters.AddWithValue("@Ogrenci_Tc", ogrenci.Ogrenci_Tc);
            komut.Parameters.AddWithValue("@Ogrenci_Adi",ogrenci.Ogrenci_Adi);
            komut.Parameters.AddWithValue("@Ogrenci_Soyadi",ogrenci.Ogrenci_Soyadi);
            komut.Parameters.AddWithValue("@Ogrenci_Yas",ogrenci.Ogrenci_Yas);
            komut.Parameters.AddWithValue("@Ogrenci_Cinsiyeti",ogrenci.Ogrenci_Cinsiyet);
            komut.Parameters.AddWithValue("@Ogrenci_Sifre",ogrenci.Ogrenci_Sifre);

            return komut.ExecuteNonQuery();
        }
        public static int OgrenciGuncelle(DK_Ogrenci ogrenci)
        {
            OleDbCommand komut = new OleDbCommand("Update Ogrenci Set Ogrenci_Tc=@Ogrenci_Tc,Ogrenci_Adi=@Ogrenci_Adi,Ogrenci_Soyadi=@Ogrenci_Soyadi,Ogrenci_Yas=@Ogrenci_Yas,Ogrenci_Cinsiyet=@Ogrenci_Cinsiyet,Ogrenci_Sifre=@Ogrenci_Sifre Where Ogrenci_Id=@Ogrenci_Id", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            komut.Parameters.AddWithValue("@Ogrenci_Tc", ogrenci.Ogrenci_Tc);
            komut.Parameters.AddWithValue("@Ogrenci_Adi", ogrenci.Ogrenci_Adi);
            komut.Parameters.AddWithValue("@Ogrenci_Soyadi", ogrenci.Ogrenci_Soyadi);
            komut.Parameters.AddWithValue("@Ogrenci_Yas", ogrenci.Ogrenci_Yas);
            komut.Parameters.AddWithValue("@Ogrenci_Cinsiyeti", ogrenci.Ogrenci_Cinsiyet);
            komut.Parameters.AddWithValue("@Ogrenci_Sifre", ogrenci.Ogrenci_Sifre);
            komut.Parameters.AddWithValue("@Ogrenci_Id", ogrenci.Ogrenci_Id);

            return komut.ExecuteNonQuery();
        }
        public static int OgrenciSil(DK_Ogrenci ogrenci)
        {
            OleDbCommand komut = new OleDbCommand("Delete From Ogrenci Where Ogrenci_Id=@Ogrenci_Id",Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);

            komut.Parameters.AddWithValue("@Ogrenci_Id", ogrenci.Ogrenci_Id);

            return komut.ExecuteNonQuery();
        }
        public static List<DK_Ogrenci> OgrenciListele()
        {
            OleDbCommand komut = new OleDbCommand("Select * From Ogrenci", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            OleDbDataReader dataRead = komut.ExecuteReader();
            List<DK_Ogrenci> ogrenci = new List<DK_Ogrenci>();

            while (dataRead.Read())
            {
                ogrenci.Add(new DK_Ogrenci  //Veritabanından gelen öğrencileri nesne seklinde DataGride ekleme
                {
                    Ogrenci_Id=int.Parse(dataRead["Ogrenci_Id"].ToString()),
                    Ogrenci_Tc=dataRead["Ogrenci_Tc"].ToString(),
                    Ogrenci_Adi=dataRead["Ogrenci_Adi"].ToString(),
                    Ogrenci_Soyadi=dataRead["Ogrenci_Soyadi"].ToString(),
                    Ogrenci_Yas=int.Parse(dataRead["Ogrenci_Yas"].ToString()),
                    Ogrenci_Cinsiyet=dataRead["Ogrenci_Cinsiyet"].ToString(),
                    Ogrenci_Sifre=dataRead["Ogrenci_Sifre"].ToString(),
                    Ogrenci_Ceza=float.Parse(dataRead["Ogrenci_Ceza"].ToString())
                });
            }
            return ogrenci;
        }
        public static int OgrenciIdKontrol(DK_Ogrenci ogrenci)
        {
            OleDbCommand komut = new OleDbCommand("Select Ogrenci_Id From Ogrenci Where Ogrenci_Tc=@Ogrenci_Tc and Ogrenci_Sifre=@Ogrenci_Sifre", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            komut.Parameters.AddWithValue("@Ogrenci_Tc", ogrenci.Ogrenci_Tc);
            komut.Parameters.AddWithValue("@Ogrenci_Sifre", ogrenci.Ogrenci_Sifre);
            
            int OgrID = 0;

            OleDbDataReader dataRead = komut.ExecuteReader();

            while (dataRead.Read())
            {
                //Gelen Ogrenci ID sini OgrID degiskenine atama
                OgrID = int.Parse(dataRead["Ogrenci_Id"].ToString());
            }
            return OgrID;
        }
        public static DK_Ogrenci OgrenciBilgiGetir(DK_Ogrenci ogrenci)
        {
            OleDbCommand komut = new OleDbCommand("Select * From Ogrenci Where Ogrenci_Id=@Ogrenci_Id", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            komut.Parameters.AddWithValue("@Ogrenci_Id", ogrenci.Ogrenci_Id);
            DK_Ogrenci ogr = new DK_Ogrenci();

            OleDbDataReader dataRead = komut.ExecuteReader();

            while (dataRead.Read())
            {
                ogr.Ogrenci_Id = int.Parse(dataRead["Ogrenci_Id"].ToString());
                ogr.Ogrenci_Tc = dataRead["Ogrenci_Tc"].ToString();
                ogr.Ogrenci_Adi = dataRead["Ogrenci_Adi"].ToString();
                ogr.Ogrenci_Soyadi = dataRead["Ogrenci_Soyadi"].ToString();
                ogr.Ogrenci_Yas = int.Parse(dataRead["Ogrenci_Yas"].ToString());
                ogr.Ogrenci_Cinsiyet = dataRead["Ogrenci_Cinsiyet"].ToString();
                ogr.Ogrenci_Sifre = dataRead["Ogrenci_Sifre"].ToString();
                ogr.Ogrenci_Ceza = float.Parse(dataRead["Ogrenci_Ceza"].ToString());
            };
            return ogr;
        }
        public static int CezaOdemeIslemi(DK_Ogrenci ogrenci)
        {
            OleDbCommand komut = new OleDbCommand("Update Ogrenci Set Ogrenci_Ceza=@Ogrenci_Ceza Where Ogrenci_Id=@Ogrenci_Id", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            komut.Parameters.AddWithValue("@Ogrenci_Ceza", ogrenci.Ogrenci_Ceza);
            komut.Parameters.AddWithValue("@Ogrenci_Id", ogrenci.Ogrenci_Id);
            

            return komut.ExecuteNonQuery();
        }
        public static float IadeyeGununeGoreCezaEkleme(DK_Ogrenci ogrenci)
        {
            OleDbCommand komut = new OleDbCommand("Update Ogrenci Set Ogrenci_Ceza=@Ogrenci_Ceza Where Ogrenci_Id=@Ogrenci_Id", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            komut.Parameters.AddWithValue("@Ogrenci_Ceza", ogrenci.Ogrenci_Ceza);
            komut.Parameters.AddWithValue("@Ogrenci_Id", ogrenci.Ogrenci_Id);



            return komut.ExecuteNonQuery();
        }
    }
}
