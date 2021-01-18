using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VeriTabaniKatmani;
using VarOlanDegiskenKatmani;

namespace IsKatmani
{
    public class IK_Yonetici
    {
        public static bool IKYoneticiKontrol(DK_Yonetici yon)
        {
            if(yon.Yonetici_KullaniciAdi!=null && yon.Yonetici_Sifre != null)
            {
                //Eğer girilen veriler bos değilse kullanıcı adi ve sifreyi veritabani katmanındaki metoda gönderilir
                return VK_Yonetici.YoneticiKontrol(yon);
            }
            else
            {
                return false;
            }
           
        }
        
    }
}
