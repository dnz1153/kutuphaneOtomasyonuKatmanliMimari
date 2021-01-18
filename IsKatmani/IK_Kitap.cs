using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VarOlanDegiskenKatmani;
using VeriTabaniKatmani;

namespace IsKatmani
{
    public class IK_Kitap
    {
        public static int IKKitapEkle(DK_Kitap kitap)
        {
            if (kitap.Kitap_Adi!=null&&kitap.Kitap_Yazar!=null&&kitap.Kitap_BasimT!=null&&kitap.Kitap_Turu!=null&&kitap.Kitap_SayfaSayisi!=0)
            {
                return VK_Kitap.KitapEkle(kitap);
            }
            else
            {
                return -1;
            }
        }
        public static int IKKitapGuncelle(DK_Kitap kitap)
        {
            if (kitap.Kitap_Id!=0&&kitap.Kitap_Adi != null && kitap.Kitap_Yazar != null && kitap.Kitap_BasimT != null && kitap.Kitap_Turu != null && kitap.Kitap_SayfaSayisi != 0)
            {
                return VK_Kitap.KitapGuncelle(kitap);
            }
            else
            {
                return -1;
            }
        }
        public static int IKKitapSil(DK_Kitap kitap)
        {
            if (kitap.Kitap_Id != 0)
            {
                return VK_Kitap.KitapSil(kitap);
            }
            else
            {
                return -1;
            }
        }
        public static List<DK_Kitap> IKKitapListele()
        {
            return VK_Kitap.KitapListele();
        }
        public static int IKKitapIdKontrol(string gelenKitapAdi)
        {
            if (gelenKitapAdi != null)
            {
                return VK_Kitap.KitapIdKontrol(gelenKitapAdi);
            }
            else
            {
                return -1;
            }
        }
        public static List<DK_Kitap> IKKitapAra(string aranan)
        {
          return VK_Kitap.KitapAra(aranan);
        }
        public static int IKKitapSayisi()
        {
            return VK_Kitap.KitapSayisi();
        }
        public static int IKOkunanKitapSayisi()
        {
            return VK_Kitap.OkunanKitapSayisi();
        }
    }
}
