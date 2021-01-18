using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarOlanDegiskenKatmani
{
    public class DK_KitapListeBilgisi
    {
        // Yönetici Panelinde bulunan kitap işlemleri içerisindeki tüm kitapların kim tarafından hangi tarihte alındıkları veya
        // teslim edildiklerini gösteren tablo için ayrı bir get set olusturuldu.

        int kitap_Id;
        string kitap_Adi;
        string ogrenci_Adi;
        string ogrenci_Soyadi;
        DateTime kitap_AlinmaT;
        string kitap_TeslimT;
        bool bool_kitapT;

        public int Kitap_Id { get => kitap_Id; set => kitap_Id = value; }
        public string Kitap_Adi { get => kitap_Adi; set => kitap_Adi = value; }
        public string Ogrenci_Adi { get => ogrenci_Adi; set => ogrenci_Adi = value; }
        public string Ogrenci_Soyadi { get => ogrenci_Soyadi; set => ogrenci_Soyadi = value; }
        public DateTime Kitap_AlinmaT { get => kitap_AlinmaT; set => kitap_AlinmaT = value; }
        public string Kitap_TeslimT { get => kitap_TeslimT; set => kitap_TeslimT = value; }
        public bool bool_KitapT { get => bool_kitapT; set => bool_kitapT = value; }
    }
}
