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
    public class VK_KitapAlanlar
    {
        public static int KitapAlma(DK_KitapAlanlar kitapAlma)
        {
            OleDbCommand komut = new OleDbCommand("Insert Into KitapAlanlar(Kitap_Id,Ogrenci_Id,Kitap_AlinmaT) Values(@Kitap_Id,@Ogrenci_Id,@Kitap_AlinmaT)", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            komut.Parameters.AddWithValue("@Kitap_Id", kitapAlma.Kitap_Id);
            komut.Parameters.AddWithValue("@Ogrenci_Id", kitapAlma.Ogrenci_Id);
            komut.Parameters.AddWithValue("@Kitap_AlinmaT", kitapAlma.Kitap_AlinmaT);

            return komut.ExecuteNonQuery();

        }
        public static List<string> comboKitapDoldur(DK_KitapAlanlar kitapListele)
        {
            OleDbCommand komut = new OleDbCommand("Select Kitap_Adi From Kitap Where Kitap_Id NOT IN(Select Kitap_Id from KitapAlanlar Where Ogrenci_Id=@Ogrenci_Id And bool_KitapT=false)", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            komut.Parameters.AddWithValue("@Ogrenci_Id", kitapListele.Ogrenci_Id);
            OleDbDataReader dataRead = komut.ExecuteReader();
            List<string> Kitaplar = new List<string>();

            while (dataRead.Read())
            {
                //Veritabaninda olan kitaplari string bir listeye atanması
                Kitaplar.Add(dataRead["Kitap_Adi"].ToString());
            }
            return Kitaplar;
        }
        public static DateTime KitapAlinmaTarihGetirme(DK_KitapAlanlar kitap,bool Sec)
        {
            DateTime zaman = DateTime.Now;
            if (Sec == true)
            {
                OleDbCommand komut = new OleDbCommand("Select Kitap_AlinmaT From KitapAlanlar Where Kitap_Id=@Kitap_Id And Ogrenci_Id=@Ogrenci_Id", Baglanti.conn);
                Baglanti.ConntectionKontrol(komut);
                komut.Parameters.AddWithValue("@Kitap_Id", kitap.Kitap_Id);
                komut.Parameters.AddWithValue("@Ogrenci_Id", kitap.Ogrenci_Id);


                OleDbDataReader dataRead = komut.ExecuteReader();
                
                while (dataRead.Read())
                {
                    zaman = DateTime.Parse(dataRead["Kitap_AlinmaT"].ToString());
                }
                komut.Connection.Close();
                
            }
            else
            {
                OleDbCommand komut = new OleDbCommand("Select Kitap_AlinmaT From KitapAlanlar Where KitapAlan_Id=@Kitap_AlanId And Kitap_Id=@Kitap_Id And Ogrenci_Id=@Ogrenci_Id", Baglanti.conn);
                Baglanti.ConntectionKontrol(komut);
                komut.Parameters.AddWithValue("@KitapAlan_Id", kitap.KitapAlan_Id);
                komut.Parameters.AddWithValue("@Kitap_Id", kitap.Kitap_Id);
                komut.Parameters.AddWithValue("@Ogrenci_Id", kitap.Ogrenci_Id);


                OleDbDataReader dataRead = komut.ExecuteReader();

                while (dataRead.Read())
                {
                    zaman = DateTime.Parse(dataRead["Kitap_AlinmaT"].ToString());
                }
                komut.Connection.Close();
            }
            return zaman;
            
        }
        public static DateTime KitapIadeTarihGetirme(DK_KitapAlanlar kitap)
        {
            OleDbCommand komut = new OleDbCommand("Select Kitap_TeslimT From KitapAlanlar Where KitapAlan_Id=@Kitap_AlanId And Kitap_Id=@Kitap_Id And Ogrenci_Id=@Ogrenci_Id And bool_KitapT=true", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            komut.Parameters.AddWithValue("@KitapAlan_Id", kitap.KitapAlan_Id);
            komut.Parameters.AddWithValue("@Kitap_Id", kitap.Kitap_Id);
            komut.Parameters.AddWithValue("@Ogrenci_Id", kitap.Ogrenci_Id);
            komut.Parameters.AddWithValue("@bool_KitapT", kitap.bool_KitapT);
            

            OleDbDataReader dataRead = komut.ExecuteReader();
            DateTime zaman = DateTime.Now;
            while (dataRead.Read())
            {
                zaman = DateTime.Parse(dataRead["Kitap_TeslimT"].ToString());
            }
            return zaman;
        }
        public static int KitapAlmaSil(DK_KitapAlanlar kitapAlmaSil)
        {
            OleDbCommand komut = new OleDbCommand("Delete From KitapAlanlar Where Ogrenci_Id=@Ogrenci_Id And Kitap_Id=@Kitap_Id And bool_KitapT=false", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);

            komut.Parameters.AddWithValue("@Ogrenci_Id", kitapAlmaSil.Ogrenci_Id);
            komut.Parameters.AddWithValue("@Kitap_Id", kitapAlmaSil.Kitap_Id);
            komut.Parameters.AddWithValue("@bool_KitapT", kitapAlmaSil.bool_KitapT);


            return komut.ExecuteNonQuery();
        }
        public static int KitapIade(DK_KitapAlanlar kitapIade)
        {
            OleDbCommand komut = new OleDbCommand("Insert Into KitapAlanlar(Kitap_Id,Ogrenci_Id,Kitap_AlinmaT,Kitap_TeslimT,bool_KitapT) Values(@Kitap_Id,@Ogrenci_Id,@Kitap_AlinmaT,@Kitap_TeslimT,@bool_KitapT)", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            komut.Parameters.AddWithValue("@Kitap_Id", kitapIade.Kitap_Id);
            komut.Parameters.AddWithValue("@Ogrenci_Id", kitapIade.Ogrenci_Id);
            komut.Parameters.AddWithValue("@Kitap_AlinmaT", kitapIade.Kitap_AlinmaT);
            komut.Parameters.AddWithValue("@Kitap_TeslimT", kitapIade.Kitap_TeslimT);
            komut.Parameters.AddWithValue("@bool_KitapT", kitapIade.bool_KitapT);
            

            return komut.ExecuteNonQuery();
        }
        
        public static List<string> comboKitapIadeDoldur(DK_KitapAlanlar dK)
        {
            
            OleDbCommand komut = new OleDbCommand("Select Kitap_Adi From Kitap Where Kitap_Id IN(Select Kitap_Id from KitapAlanlar Where Ogrenci_Id=@Ogrenci_Id And bool_KitapT=false)", Baglanti.conn);

            Baglanti.ConntectionKontrol(komut);
            komut.Parameters.AddWithValue("@Ogrenci_Id", dK.Ogrenci_Id);
            OleDbDataReader dataRead = komut.ExecuteReader();
            List<string> Kitaplar = new List<string>();

            while (dataRead.Read())
            {
                //Veritabaninda olan kitaplari string bir listeye atanması
                Kitaplar.Add(dataRead["Kitap_Adi"].ToString());
            }
            return Kitaplar;
        }
        public static List<DK_KitapBilgisi> OgrenciTabloListeDoldur(DK_KitapAlanlar kitapBilgi)
        {
            OleDbCommand komut = new OleDbCommand("Select a.KitapAlan_Id,k.Kitap_Id,k.Kitap_Adi,a.Kitap_AlinmaT,a.Kitap_TeslimT,a.bool_KitapT From (Kitap k INNER JOIN KitapAlanlar a ON a.Kitap_Id=k.Kitap_Id) Where Ogrenci_Id=@Ogrenci_Id", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            komut.Parameters.AddWithValue("@Ogrenci_Id", kitapBilgi.Ogrenci_Id);
            OleDbDataReader dataRead = komut.ExecuteReader();
            List<DK_KitapBilgisi> Kitaplar = new List<DK_KitapBilgisi>();


            while (dataRead.Read())
            {
                //Veritabaninda olan kitaplari string bir listeye atanması
                Kitaplar.Add(new DK_KitapBilgisi
                {
                    KitapAlan_Id=int.Parse(dataRead["KitapAlan_Id"].ToString()),
                    Kitap_Id = int.Parse(dataRead["Kitap_Id"].ToString()),
                    Kitap_Adi = dataRead["Kitap_Adi"].ToString(),
                    Kitap_AlinmaT = DateTime.Parse(dataRead["Kitap_AlinmaT"].ToString()),
                    Kitap_TeslimT = dataRead["Kitap_TeslimT"].ToString(),
                    bool_KitapT = bool.Parse(dataRead["bool_KitapT"].ToString()),
                });
            }
            return Kitaplar;
        }
        public static List<DK_KitapListeBilgisi> KitapAlmaVeIadeListesi(DK_KitapBilgisi kitap)
        {
            
            OleDbCommand komut = new OleDbCommand("Select k.Kitap_Id,k.Kitap_Adi,o.Ogrenci_Adi,o.Ogrenci_Soyadi,a.Kitap_AlinmaT,a.Kitap_TeslimT,a.bool_KitapT From ((Kitap k INNER JOIN KitapAlanlar a ON k.Kitap_Id=a.Kitap_Id) INNER JOIN Ogrenci o ON o.Ogrenci_Id=a.Ogrenci_Id) Where k.Kitap_Id=@gelenID", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            

            komut.Parameters.AddWithValue("@Kitap_Id", kitap.Kitap_Id);
            OleDbDataReader dataRead = komut.ExecuteReader();
            List<DK_KitapListeBilgisi> Kitaplar = new List<DK_KitapListeBilgisi>();


            while (dataRead.Read())
            {
                //Veritabaninda olan kitaplari string bir listeye atanması
                Kitaplar.Add(new DK_KitapListeBilgisi
                {
                    Kitap_Id = int.Parse(dataRead["Kitap_Id"].ToString()),
                    Kitap_Adi = dataRead["Kitap_Adi"].ToString(),
                    Ogrenci_Adi=dataRead["Ogrenci_Adi"].ToString(),
                    Ogrenci_Soyadi=dataRead["Ogrenci_Soyadi"].ToString(),
                    Kitap_AlinmaT = DateTime.Parse(dataRead["Kitap_AlinmaT"].ToString()),
                    Kitap_TeslimT = dataRead["Kitap_TeslimT"].ToString(),
                    bool_KitapT = bool.Parse(dataRead["bool_KitapT"].ToString()),
                });
            }
            return Kitaplar;
        }
        public static int OgrAldigiKitapSayisi(DK_KitapAlanlar kitapSayisi)
        {
            OleDbCommand komut = new OleDbCommand("Select * From KitapAlanlar Where Ogrenci_Id=@Ogrenci_Id", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            int Sayac = 0;
            komut.Parameters.AddWithValue("@Ogrenci_Id", kitapSayisi.Ogrenci_Id);
            OleDbDataReader dataRead = komut.ExecuteReader();
            while (dataRead.Read())
            {
                Sayac++;
            }
            return Sayac;
        }
        public static int OgrTeslimKitapSayisi(DK_KitapAlanlar kitapSayisi)
        {
            OleDbCommand komut = new OleDbCommand("Select * From KitapAlanlar Where Ogrenci_Id=@Ogrenci_Id And bool_KitapT=true", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            int Sayac = 0;
            komut.Parameters.AddWithValue("@Ogrenci_Id", kitapSayisi.Ogrenci_Id);
            OleDbDataReader dataRead = komut.ExecuteReader();
            while (dataRead.Read())
            {
                Sayac++;
            }
            return Sayac;
        }
        public static int OgrVerilebilecekKitapSayisi(DK_KitapAlanlar kitapSayisi)
        {
            OleDbCommand komut = new OleDbCommand("Select Kitap_Id From Kitap Where Kitap_Id NOT IN(Select Kitap_Id From KitapAlanlar Where Ogrenci_Id=@Ogrenci_Id And bool_KitapT=false)", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            int Sayac = 0;
            komut.Parameters.AddWithValue("@Ogrenci_Id", kitapSayisi.Ogrenci_Id);
            OleDbDataReader dataRead = komut.ExecuteReader();
            while (dataRead.Read())
            {
                Sayac++;
            }
            return Sayac;
        }





    }
}
