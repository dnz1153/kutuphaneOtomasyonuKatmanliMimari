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
    public class VK_Yonetici
    {
        public static bool YoneticiKontrol(DK_Yonetici yonetici)
        {
            OleDbCommand komut = new OleDbCommand("Select * From Yetkili Where Yetkili_KAdi=@Yonetici_KullaniciAdi and Yetkili_Sifre=@Yonetici_Sifre", Baglanti.conn);
            Baglanti.ConntectionKontrol(komut);
            komut.Parameters.AddWithValue("@Yonetici_KullaniciAdi", yonetici.Yonetici_KullaniciAdi);
            komut.Parameters.AddWithValue("@Yonetici_Sifre", yonetici.Yonetici_Sifre);

            OleDbDataReader dataRead = komut.ExecuteReader();
            bool sonuc = false;
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
        
    }
}
