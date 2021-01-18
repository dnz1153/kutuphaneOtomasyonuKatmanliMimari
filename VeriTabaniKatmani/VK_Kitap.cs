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
    public class VK_Kitap
    {
        public static int KitapEkle(DK_Kitap kitap)
        {
            OleDbCommand komut = new OleDbCommand("Insert Into Kitap(Kitap_Adi,Kitap_Yazar,Kitap_BasimT,Kitap_Turu,Kitap_SayfaSayisi) Values(@Kitap_Adi,@Kitap_Yazar,@Kitap_BasimT,@Kitap_Turu,@Kitap_SayfaSayisi)", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            komut.Parameters.AddWithValue("@Kitap_Adi",kitap.Kitap_Adi);
            komut.Parameters.AddWithValue("@Kitap_Yazar",kitap.Kitap_Yazar);
            komut.Parameters.AddWithValue("@Kitap_BasimT",kitap.Kitap_BasimT);
            komut.Parameters.AddWithValue("@Kitap_Turu",kitap.Kitap_Turu);
            komut.Parameters.AddWithValue("@Kitap_SayfaSayisi",kitap.Kitap_SayfaSayisi);

            return komut.ExecuteNonQuery();
        }
        public static int KitapGuncelle(DK_Kitap kitap)
        {
            OleDbCommand komut = new OleDbCommand("Update Kitap Set Kitap_Adi=@Kitap_Adi,Kitap_Yazar=@Kitap_Yazar,Kitap_BasimT=@Kitap_BasimT,Kitap_Turu=@Kitap_Turu,Kitap_SayfaSayisi=@Kitap_SayfaSayisi Where Kitap_Id=@Kitap_Id", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);

            komut.Parameters.AddWithValue("@Kitap_Adi", kitap.Kitap_Adi);
            komut.Parameters.AddWithValue("@Kitap_Yazar", kitap.Kitap_Yazar);
            komut.Parameters.AddWithValue("@Kitap_BasimT", kitap.Kitap_BasimT);
            komut.Parameters.AddWithValue("@Kitap_Turu", kitap.Kitap_Turu);
            komut.Parameters.AddWithValue("@Kitap_SayfaSayisi", kitap.Kitap_SayfaSayisi);
            komut.Parameters.AddWithValue("@Kitap_Id", kitap.Kitap_Id);

            return komut.ExecuteNonQuery();
        }
        public static int KitapSil(DK_Kitap kitap)
        {
            OleDbCommand komut = new OleDbCommand("Delete From Kitap Where Kitap_Id=@Kitap_Id", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            komut.Parameters.AddWithValue("@Kitap_Id", kitap.Kitap_Id);

            return komut.ExecuteNonQuery();
        }
        public static List<DK_Kitap> KitapListele()
        {
            OleDbCommand komut = new OleDbCommand("Select * From Kitap", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            OleDbDataReader dataRead = komut.ExecuteReader();
            List<DK_Kitap> kitap = new List<DK_Kitap>();

            while (dataRead.Read())
            {
                kitap.Add(new DK_Kitap
                {
                    Kitap_Id=int.Parse(dataRead["Kitap_Id"].ToString()),
                    Kitap_Adi=dataRead["Kitap_Adi"].ToString(),
                    Kitap_Yazar=dataRead["Kitap_Yazar"].ToString(),
                    Kitap_BasimT=dataRead["Kitap_BasimT"].ToString(),
                    Kitap_Turu=dataRead["Kitap_Turu"].ToString(),
                    Kitap_SayfaSayisi=int.Parse(dataRead["Kitap_SayfaSayisi"].ToString())
                });
            }
            return kitap;
        }
        public static int KitapIdKontrol(string gelenKitapAdi)
        {
            OleDbCommand komut = new OleDbCommand("Select Kitap_Id From Kitap Where Kitap_Adi=@Kitap_Adi", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            komut.Parameters.AddWithValue("Kitap_Adi", gelenKitapAdi);

            int Kitap_Id = 0;
            OleDbDataReader dataRead = komut.ExecuteReader();

            while (dataRead.Read()){
                Kitap_Id = int.Parse(dataRead["Kitap_Id"].ToString());
            }
            return Kitap_Id;

        }
        public static List<DK_Kitap> KitapAra(string aranan)
        {
            OleDbCommand komut = new OleDbCommand("Select * From Kitap Where Kitap_Adi like '%"+aranan+ "%' Or Kitap_Yazar like '%" + aranan + "%' Or Kitap_BasimT like '%" + aranan + "%' Or Kitap_Turu like '%" + aranan + "%' Or Kitap_SayfaSayisi like '%" + aranan + "%' ", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            OleDbDataReader dataRead = komut.ExecuteReader();
            List<DK_Kitap> kitapAra = new List<DK_Kitap>();

            while (dataRead.Read())
            {
                kitapAra.Add(new DK_Kitap
                {
                    Kitap_Id = int.Parse(dataRead["Kitap_Id"].ToString()),
                    Kitap_Adi = dataRead["Kitap_Adi"].ToString(),
                    Kitap_Yazar = dataRead["Kitap_Yazar"].ToString(),
                    Kitap_BasimT = dataRead["Kitap_BasimT"].ToString(),
                    Kitap_Turu = dataRead["Kitap_Turu"].ToString(),
                    Kitap_SayfaSayisi = int.Parse(dataRead["Kitap_SayfaSayisi"].ToString())
                });
            }
            return kitapAra;
        }
        public static int KitapSayisi()
        {
            OleDbCommand komut = new OleDbCommand("Select * From Kitap", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            int Sayac = 0;
            OleDbDataReader dataRead = komut.ExecuteReader();
            while (dataRead.Read())
            {
                Sayac++;
            }
            return Sayac;
        }
        public static int OkunanKitapSayisi()
        {
            OleDbCommand komut = new OleDbCommand("Select * From (Kitap AS k INNER JOIN KitapAlanlar AS a ON k.Kitap_Id=a.Kitap_Id) Where a.bool_KitapT=false", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            int Sayac = 0;
            OleDbDataReader dataRead = komut.ExecuteReader();
            while (dataRead.Read())
            {
                Sayac++;
            }
            return Sayac;
        }
    }
}
