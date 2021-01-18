using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VarOlanDegiskenKatmani
{
    public class DK_Kitap
    {
        //Kitap Bilgileri Get ve Set ile alindi
        int kitap_Id;
        string kitap_Adi;
        string kitap_Yazar;
        string kitap_BasimT;
        string kitap_Turu;
        int kitap_SafyaSayisi;

        public int Kitap_Id { get => kitap_Id; set => kitap_Id = value; }
        public string Kitap_Adi { get => kitap_Adi; set => kitap_Adi = value; }
        public string Kitap_Yazar { get => kitap_Yazar; set => kitap_Yazar = value; }
        public string Kitap_BasimT { get => kitap_BasimT; set => kitap_BasimT = value; }
        public string Kitap_Turu { get => kitap_Turu; set => kitap_Turu = value; }
        public int Kitap_SayfaSayisi { get => kitap_SafyaSayisi; set => kitap_SafyaSayisi = value; }
    }
}
