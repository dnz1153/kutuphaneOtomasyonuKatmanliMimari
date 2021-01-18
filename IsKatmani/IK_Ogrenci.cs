using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VeriTabaniKatmani;
using VarOlanDegiskenKatmani;

namespace IsKatmani
{
    public class IK_Ogrenci
    {
        public static bool IKOgrenciKontrol(DK_Ogrenci ogr)
        {
            if (ogr.Ogrenci_Tc != null && ogr.Ogrenci_Sifre != null)
            {
                //Eğer girilen veriler bos değilse kullanıcının TC si ve sifreyi veritabani katmanındaki metoda gönderilir.
                return VK_Ogrenci.OgrenciKontrol(ogr);
            }
            else
            {
                return false;
            }
        }
        public static string IKOgrenciSifreKontrol(DK_Ogrenci ogr)
        {
            if (ogr.Ogrenci_Tc.Length == 11 && ogr.Ogrenci_Yas != 0)
            {
                //Ogrenci_Tc ve Ogrenci_Yas kontrolleri yapıldıktan sonra Veritabanı katamnına yollanıyor.
                return VK_Ogrenci.OgrenciSifreKontrol(ogr);
            }
            else
            {
                //Eger uyusmuyorsa bos döndürür.
                return "";
            }
        }
        public static string IKOgrenciGirisAdSoyadKontrol(DK_Ogrenci ogr)
        {
            if (ogr.Ogrenci_Tc.Length == 11)
            {
                //Ogrenci_Tc ve Ogrenci_Yas kontrolleri yapıldıktan sonra Veritabanı katamnına yollanıyor.
                return VK_Ogrenci.OgrenciGirisAdSoyadKontrol(ogr);
            }
            else
            {
                //Eger uyusmuyorsa bos döndürür.
                return "";
            }
        }
        public static bool IKOgrenciAynıTCKontrol(DK_Ogrenci ogr)
        {
            if (ogr.Ogrenci_Tc.Length == 11)
            {
                return VK_Ogrenci.OgrenciAyniTCKontrol(ogr);
            }
            else
            {
                return false;
            }
        }
        public static int IKOgrenciEkle(DK_Ogrenci ogr)
        {
            //Form Ekranından Gelen Veriler Dolu ve İstege uygun ise Veritabanı katmanına yollanır.
            if (ogr.Ogrenci_Tc.Length == 11 && ogr.Ogrenci_Adi != null && ogr.Ogrenci_Soyadi != null && ogr.Ogrenci_Yas > 0 && ogr.Ogrenci_Yas < 150 && ogr.Ogrenci_Cinsiyet != null && ogr.Ogrenci_Sifre != null)
            {
                return VK_Ogrenci.OgrenciEkle(ogr);
            }
            else
            {
                return -1;
            }
        }
        public static int IKOgrenciGuncelle(DK_Ogrenci ogr)
        {
            //Form Ekranından Gelen Veriler Dolu ve İstege uygun ise Veritabanı katmanına yollanır.
            if (ogr.Ogrenci_Id != 0 && ogr.Ogrenci_Tc.Length == 11 && ogr.Ogrenci_Adi != null && ogr.Ogrenci_Soyadi != null && ogr.Ogrenci_Yas > 0 && ogr.Ogrenci_Yas < 150 && ogr.Ogrenci_Cinsiyet != null && ogr.Ogrenci_Sifre != null)
            {
                return VK_Ogrenci.OgrenciGuncelle(ogr);
            }
            else
            {
                return -1;
            }
        }
        public static int IKOgrenciSil(DK_Ogrenci ogr)
        {
            //Formdan gelen öğrenci id kontorlü
            if (ogr.Ogrenci_Id != 0)
            {
                return VK_Ogrenci.OgrenciSil(ogr);
            }
            else
            {
                return -1;
            }
        }
        public static List<DK_Ogrenci> IKOgrenciListele()
        {
            //Verilerin cekilmesi icin veritabanına yönlendiriliyor.
            return VK_Ogrenci.OgrenciListele();
        }
        public static int IKOgrenciIdKontrol(DK_Ogrenci ogr)
        {
            if (ogr.Ogrenci_Tc != null && ogr.Ogrenci_Sifre != null)
            {
                //Eğer girilen veriler bos değilse kullanıcının TC si ve sifreyi veritabani katmanındaki OgrenciIdKontrol metoduna gönderilir.
                return VK_Ogrenci.OgrenciIdKontrol(ogr);
            }
            else
            {
                return -1;
            }
        }
        public static DK_Ogrenci IKOgrenciBilgiGetir(DK_Ogrenci ogr)
        {
            //Formdan gelen öğrenci id kontorlü
            if (ogr.Ogrenci_Id != 0)
            {
                //Nesne Veritabani Katmanına yollanıyor
                return VK_Ogrenci.OgrenciBilgiGetir(ogr);
            }
            else
            {
                return ogr;
            }
        }
        public static int IKOgrenciCezaOdemeIslemi(DK_Ogrenci ogr)
        {
            //Form Ekranından Gelen Veriler Dolu ve İstege uygun ise Veritabanı katmanına yollanır.
            //Ceza !=-1 durumu saglanması gerekir.Tüm borcu ödeme işlemi için
            if (ogr.Ogrenci_Id != 0 && ogr.Ogrenci_Ceza != -1)
            {
                return VK_Ogrenci.CezaOdemeIslemi(ogr);
            }
            else
            {
                return -1;
            }
        }
        public static float IKIadeyeGununeGoreCezaEkleme(DK_Ogrenci ogr)
        {
            if (ogr.Ogrenci_Id!=0 && ogr.Ogrenci_Ceza != -1)
            {
                return VK_Ogrenci.IadeyeGununeGoreCezaEkleme(ogr);
            }
            else
            {
                return -1;
            }
        }
    }
}
