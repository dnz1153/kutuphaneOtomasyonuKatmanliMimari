using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarOlanDegiskenKatmani
{
    public class DK_Ogrenci
    {
        //Ogrenci Bilgileri Get ve Set ile alındı.

        int ogrenci_Id;
        string ogrenci_Tc;
        string ogrenci_Adi;
        string ogrenci_Soyadi;
        int ogrenci_Yas;
        string ogrenci_Cinsiyet;
        string ogrenci_Sifre;
        float ogrenci_Ceza;

        public int Ogrenci_Id { get => ogrenci_Id; set => ogrenci_Id = value; }
        public string Ogrenci_Tc { get => ogrenci_Tc; set => ogrenci_Tc = value; }
        public string Ogrenci_Adi { get => ogrenci_Adi; set => ogrenci_Adi = value; }
        public string Ogrenci_Soyadi { get => ogrenci_Soyadi; set => ogrenci_Soyadi = value; }
        public int Ogrenci_Yas { get => ogrenci_Yas; set => ogrenci_Yas = value; }
        public string Ogrenci_Cinsiyet { get => ogrenci_Cinsiyet; set => ogrenci_Cinsiyet = value; }
        public string Ogrenci_Sifre { get => ogrenci_Sifre; set => ogrenci_Sifre = value; }
        public float Ogrenci_Ceza { get => ogrenci_Ceza; set => ogrenci_Ceza = value; }
    }
}
