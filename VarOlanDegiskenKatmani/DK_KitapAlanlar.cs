using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarOlanDegiskenKatmani
{
    public class DK_KitapAlanlar
    {
        //Kitap Alan Kişilerin Bilgisi Get ve Set ile alındı.
        int kitapAlan_Id;
        int kitap_Id;
        int ogrenci_Id;
        DateTime kitap_AlinmaT;
        DateTime kitap_TeslimT;
        bool bool_kitapT;

        public int KitapAlan_Id { get => kitapAlan_Id; set => kitapAlan_Id = value; }
        public int Kitap_Id { get => kitap_Id; set => kitap_Id = value; }
        public int Ogrenci_Id { get => ogrenci_Id; set => ogrenci_Id = value; }
        public DateTime Kitap_AlinmaT { get => kitap_AlinmaT; set => kitap_AlinmaT = value; }
        public DateTime Kitap_TeslimT { get => kitap_TeslimT; set => kitap_TeslimT = value; }
        public bool bool_KitapT { get => bool_kitapT; set => bool_kitapT = value; }
    }
}
