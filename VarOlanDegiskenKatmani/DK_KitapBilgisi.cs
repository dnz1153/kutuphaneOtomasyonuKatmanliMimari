using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarOlanDegiskenKatmani
{
    public class DK_KitapBilgisi
    {
        // Ogrenci Panelinde bulunan Öğrencinin aldıgı ve teslim ettiği kitapların listesini olusturmak için ayrı
        // bir get set olusturuldu.
        int kitapAlan_Id;
        int kitap_Id;
        string kitap_Adi;
        DateTime kitap_AlinmaT;
        string kitap_TeslimT;
        bool bool_kitapT;

        public int KitapAlan_Id { get => kitapAlan_Id; set => kitapAlan_Id = value; }
        public int Kitap_Id { get => kitap_Id; set => kitap_Id = value; }
        public string Kitap_Adi { get => kitap_Adi; set => kitap_Adi = value; }
        public DateTime Kitap_AlinmaT { get => kitap_AlinmaT; set => kitap_AlinmaT = value; }
        public string Kitap_TeslimT { get => kitap_TeslimT; set => kitap_TeslimT = value; }
        public bool bool_KitapT { get => bool_kitapT; set => bool_kitapT = value; }
    }
}
