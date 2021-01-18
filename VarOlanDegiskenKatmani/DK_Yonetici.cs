using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarOlanDegiskenKatmani
{
    public class DK_Yonetici
    {
        //Yonetici Bilgileri Get ve Set ile alındı.

        int yonetici_Id;
        string yonetici_Adi;
        string yonetici_KullaniciAdi;
        string yonetici_Sifre;

        public int Yonetici_Id { get => yonetici_Id; set => yonetici_Id = value; }
        public string Yonetici_Adi { get => yonetici_Adi; set => yonetici_Adi = value; }
        public string Yonetici_KullaniciAdi { get => yonetici_KullaniciAdi; set => yonetici_KullaniciAdi = value; }
        public string Yonetici_Sifre { get => yonetici_Sifre; set => yonetici_Sifre = value; }


    }
}
