using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VarOlanDegiskenKatmani;
using VeriTabaniKatmani;

namespace IsKatmani
{
    public class IK_KitapAlanlar
    {
        public static int IKKitapAlma(DK_KitapAlanlar dK_Kitap)
        {
            if (dK_Kitap.Kitap_Id != 0 && dK_Kitap.Ogrenci_Id != 0 && dK_Kitap.Kitap_AlinmaT != null)
            {
                return VK_KitapAlanlar.KitapAlma(dK_Kitap);
            }
            else
            {
                return -1;
            }
        }
        
        public static List<string> IKcomboKitapDoldur(DK_KitapAlanlar ogr)
        {
            return VK_KitapAlanlar.comboKitapDoldur(ogr);
        }

        public static DateTime IKKitapAlinmaTarihGetirme(DK_KitapAlanlar dK_Kitap,bool Sec)
        {
            if (Sec == true)
            {
                if (dK_Kitap.Kitap_Id != 0 && dK_Kitap.Ogrenci_Id != 0)
                {
                    return VK_KitapAlanlar.KitapAlinmaTarihGetirme(dK_Kitap,Sec);
                }
                else
                {
                    return DateTime.Now;
                }
            }
            else
            {
                if (dK_Kitap.KitapAlan_Id != 0 && dK_Kitap.Kitap_Id != 0 && dK_Kitap.Ogrenci_Id != 0)
                {
                    return VK_KitapAlanlar.KitapAlinmaTarihGetirme(dK_Kitap,Sec);
                }
                else
                {
                    return DateTime.Now;
                }
            }

        }
        public static DateTime IKKitapIadeTarihGetirme(DK_KitapAlanlar dK_Kitap)
        {
            if (dK_Kitap.KitapAlan_Id != 0 && dK_Kitap.Kitap_Id != 0 && dK_Kitap.Ogrenci_Id != 0&&dK_Kitap.bool_KitapT!=false)
            {
                return VK_KitapAlanlar.KitapIadeTarihGetirme(dK_Kitap);
            }
            else
            {
                return DateTime.Now;
            }
        }
        public static int IKKitapAlmaSil(DK_KitapAlanlar dK_Kitap)
        {
            if (dK_Kitap.Kitap_Id != 0 && dK_Kitap.Ogrenci_Id != 0 && dK_Kitap.bool_KitapT != true)
            {
                return VK_KitapAlanlar.KitapAlmaSil(dK_Kitap);
            }
            else
            {
                return -1;
            }
        }
        public static int IKKitapIade(DK_KitapAlanlar dK_Kitap)
        {
            if (dK_Kitap.Kitap_Id != 0 && dK_Kitap.Ogrenci_Id != 0 && dK_Kitap.Kitap_AlinmaT != null&&dK_Kitap.Kitap_TeslimT!=null)
            {
                return VK_KitapAlanlar.KitapIade(dK_Kitap);
            }
            else
            {
                return -1;
            }
        }

        public static List<string> IKcomboKitapIadeDoldur(DK_KitapAlanlar dK_Kitap)
        {
            return VK_KitapAlanlar.comboKitapIadeDoldur(dK_Kitap);

        }
        public static List<DK_KitapBilgisi> IKOgrenciTabloListeDoldur(DK_KitapAlanlar dK_Kitap)
        {
            return VK_KitapAlanlar.OgrenciTabloListeDoldur(dK_Kitap);
        }
        public static List<DK_KitapListeBilgisi> IKKitapAlmaVeIadeListesi(DK_KitapBilgisi dK_Kitap)
        {
            if (dK_Kitap.Kitap_Id!= 0)
            {
                return VK_KitapAlanlar.KitapAlmaVeIadeListesi(dK_Kitap);
            }
            else
            {
                return null;
            }
            
        }
        public static int IKOgrAldigiKitapSayisi(DK_KitapAlanlar dK_Kitap)
        {
            if (dK_Kitap.Ogrenci_Id != 0)
            {
                return VK_KitapAlanlar.OgrAldigiKitapSayisi(dK_Kitap);
            }
            else
            {
                return -1;
            }
        }
        public static int IKOgrTeslimKitapSayisi(DK_KitapAlanlar dK_Kitap)
        {
            if (dK_Kitap.Ogrenci_Id != 0)
            {
                return VK_KitapAlanlar.OgrTeslimKitapSayisi(dK_Kitap);
            }
            else
            {
                return -1;
            }
        }
        public static int IKOgrVerilebilecekKitapSayisi(DK_KitapAlanlar dK_Kitap)
        {
            if (dK_Kitap.Ogrenci_Id != 0)
            {
                return VK_KitapAlanlar.OgrVerilebilecekKitapSayisi(dK_Kitap);
            }
            else
            {
                return -1;
            }
        }
        

    }
}
