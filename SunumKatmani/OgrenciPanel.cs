using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VarOlanDegiskenKatmani;
using IsKatmani;

namespace SunumKatmani
{
    public partial class OgrenciPanel : Form
    {
        
        public OgrenciPanel()
        {
            InitializeComponent();
        }

        private void pb_Geri_Click(object sender, EventArgs e)
        {
            // Tanımlanan Picturebox ile OgrenciGiris ekranına geri dönmemizi sağlandı.
            this.Visible = false;
            OgrenciGiris o1 = new OgrenciGiris();
            o1.ShowDialog();
            
        }

        private void pb_Cikis_Click(object sender, EventArgs e)
        {
            // Tanımlanan Picturebox ile uygulamayı kapamamızı sağlar.
            System.Windows.Forms.Application.Exit();
        }
        private void OgrenciPanel_Load(object sender, EventArgs e)
        {
            //Olusturulan Nesneler İçin Sayfa Acılırken Acıklamalar Olusturuldu.
            toolTip1.SetToolTip(pb_Geri, "Geri");
            toolTip1.SetToolTip(pb_Cikis, "Çıkış");
            toolTip1.SetToolTip(pb_CezaOde, "Cezayi Öde");
            toolTip1.SetToolTip(pb_KitapAl, "Kitabı Al");
            toolTip1.SetToolTip(pb_KitapIade, "Kitabı İade Et");
            toolTip1.SetToolTip(lbl_OgrId, "Öğrenci ID");
            toolTip1.SetToolTip(Ogrenci_KitapListesi, "Öğrenci Kitap Listesi");
            toolTip1.SetToolTip(Kitap_Ara, "Kitap Ara");
            toolTip1.SetToolTip(pb_Istatistik, "Kitap İstatistik");
            toolTip1.SetToolTip(dateTime_KitapAlma, "Tarih Seç");
            toolTip1.SetToolTip(dateTime_KitapIade, "Tarih Seç");

            // Öğrenci Id'sini oluşturulan degisken katmanının nesnesine atılmasını saglar
            DK_Ogrenci ogr = new DK_Ogrenci()
            {
                Ogrenci_Id = int.Parse(lbl_OgrId.Text)
            };
            // Öğrenci Id'sini oluşturulan degisken katmanının nesnesine atılmasını saglar
            DK_KitapAlanlar ogr1 = new DK_KitapAlanlar()
            {
                Ogrenci_Id = int.Parse(lbl_OgrId.Text),
            };
            // Değişken katmanından olusturulan Ogr öğesine Ogrenci iş katmanından dönen bilgi gönderilir.
            ogr = IK_Ogrenci.IKOgrenciBilgiGetir(ogr);

            // Combobox ın datasource'na KitapAlanlar iş katmanından gelen comboKitapDoldur bilgisi döner.
            kitap_Alma.DataSource = IK_KitapAlanlar.IKcomboKitapDoldur(ogr1);

            // Combobox ın datasource'na KitapAlanlar iş katmanından gelen comboKitapIadeDoldur bilgisi döner.
            kitap_Iade.DataSource = IK_KitapAlanlar.IKcomboKitapIadeDoldur(ogr1);

            // Gerekli olan bilgiler ogr nesnesi ile label'lara aktarılır ve ekrana yansıtılır.
            lbl_TC.Text = ogr.Ogrenci_Tc;
            lbl_AdSoyad.Text = ogr.Ogrenci_Adi + " " + ogr.Ogrenci_Soyadi;
            lbl_Yas.Text = ogr.Ogrenci_Yas.ToString();
            lbl_Cinsiyet.Text = ogr.Ogrenci_Cinsiyet;
            lbl_Ceza.Text = ogr.Ogrenci_Ceza.ToString();

            GC.Collect();
        }

        private void pb_CezaOde_Click(object sender, EventArgs e)// Ceza Ödeme İşlemi
        {
            //Ogrenci Id ve textbox CezaMiktarının bos gelmesini önleyen koşul
            if (lbl_OgrId.Text != "" && txt_cezaMiktar.Text != "")
            {
                //Ceza işleminden sonra kalan miktari hesaplama
                float kalanMiktar=0;
                float lblCeza = float.Parse(lbl_Ceza.Text);
                float txtCeza = float.Parse(txt_cezaMiktar.Text);
                kalanMiktar = lblCeza - txtCeza;

                // Textboxtaki cezanın öğrencinin cezasından fazla olmasını önleyen koşul
                if (txtCeza<=lblCeza)
                {
                    // Öğrenci Id ve Ceza yı tanımlanan değişken katmanına atanır.
                    DK_Ogrenci dK_Ogrenci = new DK_Ogrenci()
                    {
                        Ogrenci_Id = int.Parse(lbl_OgrId.Text),
                        Ogrenci_Ceza=kalanMiktar
                    };
                    // İş katmanına OgrenciCezaOdemeİşlemi için gerekli bilgiyi döndürür.
                    IK_Ogrenci.IKOgrenciCezaOdemeIslemi(dK_Ogrenci);
                    MessageBox.Show("Ceza miktari başarılı bir şekilde ödendi","Borç Ödeme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    // İş katmanına ÖğrenciBilgiGetir için gerekli bilgiyi döndürür.
                    IK_Ogrenci.IKOgrenciBilgiGetir(dK_Ogrenci);
                    // Gelen Bilgiyi(veritabanından dönen bilgi) label'a yazar.
                    lbl_Ceza.Text = dK_Ogrenci.Ogrenci_Ceza.ToString();
                    txt_cezaMiktar.Text = "";
                }
                else if (lblCeza == 0)
                {
                    // Eğer borc yoksa ödeme işlemi olmaz ve kullanıcıya hata döndürülür.
                    MessageBox.Show("Borçunuz Gözükmemektedir.", "Borç Ödeme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Eğer ceza miktarı borctan fazla olamaz ve kullanıcıya hata döndürür.
                    MessageBox.Show("Ceza miktari borcunuzdan fazla olamaz", "Hatali Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                // Ceza miktarı textbox' bos ise kullanıcıya hata döndürür.
                MessageBox.Show("Ceza miktarı alanı bos bırakılamaz","Hatali Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void pb_KitapAl_Click(object sender, EventArgs e)
        {   
            // Kitap Alma Combobox'nın dolu olma kontrolü
            if (kitap_Alma.Text != "")
            {
                // Kitap Bilgilerini değişkenlere atanır.
                string Kitap_Adi = kitap_Alma.Text;
                int Kitap_Id = IK_Kitap.IKKitapIdKontrol(Kitap_Adi);
                int Ogrenci_Id = int.Parse(lbl_OgrId.Text);

                // Kitap Bilgilerinin dolu oldugu kontrolü
                if (Kitap_Adi != "" && Kitap_Id != 0 && Ogrenci_Id != 0)
                {
                    // Kitap_Id,Öğrenci_Id ve Kitap_AlinmaT tanımlanan değişken katmanına atanır.
                    DK_KitapAlanlar kitapAlma = new DK_KitapAlanlar()
                    {
                        Kitap_Id = Kitap_Id,
                        Ogrenci_Id = Ogrenci_Id,
                        Kitap_AlinmaT = dateTime_KitapAlma.Value.Date
                    };
                        // Kitap Bilgileri İş katmanına yollanır.
                        IK_KitapAlanlar.IKKitapAlma(kitapAlma);
                        MessageBox.Show("Ogrenci Kitabı Başarılı Bir Şekilde Aldı.", "Başarılı Kitap Alımı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //ComboBox'ların içerisindeki veriler güncellenir.
                        kitap_Iade.DataSource = IK_KitapAlanlar.IKcomboKitapIadeDoldur(kitapAlma);
                        kitap_Alma.DataSource = IK_KitapAlanlar.IKcomboKitapDoldur(kitapAlma);

                    
                }
                else
                {
                    // Kitap Bilgileri bos ise kullanıcıya hata döndürür.
                    MessageBox.Show("Kitap Adi,Id ve Ogrenci Id si bos olamaz","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                } 
            }
            else
            {
                // ComboBox içi boş ise kullanıcıya hata döndürür.
                MessageBox.Show("Lütfen Kitap Seciniz.Eger Listede Kitap Yok İse Kütüphane Yetkilisinden Bilgi Edininiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pb_KitapIade_Click(object sender, EventArgs e)
        {
            // ComboBox bos olmama koşulu
            if (kitap_Iade.Text != "")
            {
                // Kitap Bilgilerini değişkenlere atanır.
                string Kitap_Adi = kitap_Iade.Text;
                int Kitap_Id = IK_Kitap.IKKitapIdKontrol(Kitap_Adi);
                int Ogrenci_Id = int.Parse(lbl_OgrId.Text);
                
                DateTime TeslimT= DateTime.Parse(dateTime_KitapIade.Text);

                // Kitap_Id,Kitap_Adi ve Ogrenci_Id (gelen bilgilerin) bos olmama koşulu
                if (Kitap_Adi != "" && Kitap_Id != 0 && Ogrenci_Id != 0)
                {
                    DateTime AlinmaT;
                    // Kitap_Id,Öğrenci_Id ve bool_KitapT tanımlanan değişken katmanına atanır.
                    DK_KitapAlanlar kitapAlinmaT = new DK_KitapAlanlar()
                    {
                        Kitap_Id = Kitap_Id,
                        Ogrenci_Id = Ogrenci_Id,
                        bool_KitapT = false
                    };
                    // Alinma Tarihi Getirme
                    AlinmaT = IK_KitapAlanlar.IKKitapAlinmaTarihGetirme(kitapAlinmaT,true);

                    // Kitap_Id,Öğrenci_Id,Kitap_AlinmaT,Kitap_TeslimT ve bool_KitapT tanımlanan değişken katmanına atanır.
                    DK_KitapAlanlar kitapIade = new DK_KitapAlanlar()
                    {
                        Kitap_Id = Kitap_Id,
                        Ogrenci_Id = Ogrenci_Id,
                        Kitap_AlinmaT=AlinmaT,
                        Kitap_TeslimT = TeslimT,
                        bool_KitapT = true,
                    };
                        // Teslim ve Alınma Tarihleri hesaplanıp Sonuc degiskenine atanır.
                        TimeSpan Sonuc = TeslimT - AlinmaT;
                        //MessageBox.Show("Sonuc=" + Sonuc.ToString());  Kac gün oldugu bilgisi
                        double snc = Sonuc.TotalDays;
                        if (Sonuc.TotalDays >0)//Sonuc değişkeninin Total Günü 0 dan büyük olma koşulu
                        {
                            
                            IK_KitapAlanlar.IKKitapIade(kitapIade);

                        // Kitap_Id,Öğrenci_Id ve bool_KitapT tanımlanan değişken katmanına atanır.
                        DK_KitapAlanlar kitapAlmaSil = new DK_KitapAlanlar()
                        {
                            Kitap_Id = Kitap_Id,
                            Ogrenci_Id = Ogrenci_Id,
                            bool_KitapT = false
                        };
                        // Önceki kitap bilgisi silindi.
                        IK_KitapAlanlar.IKKitapAlmaSil(kitapAlmaSil);
                        MessageBox.Show("Ogrenci Kitabı Başarılı Bir Şekilde İade Etti.", "Başarılı Kitap İadesi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            // Kitap Iade ve Alma ComboBox'lari güncellenir.
                            kitap_Iade.DataSource=IK_KitapAlanlar.IKcomboKitapIadeDoldur(kitapIade);
                            kitap_Alma.DataSource = IK_KitapAlanlar.IKcomboKitapDoldur(kitapIade);

                        if (Sonuc.TotalDays > 15)// Teslim Ederken Ceza Uygulaması(Teslim Edilen kitabın sonuc'ten büyük ise ceza uygulanır.)
                            {
                                // Sonuca göre ceza hesaplama
                                int Ceza = (int)(snc - 15);
                                int CezaToplam = Ceza + int.Parse(lbl_Ceza.Text);
                                // Öğrenci_Id ve Ogrenci_Ceza tanımlanan değişken katmanına atanır.
                                DK_Ogrenci dK_Ogrenci = new DK_Ogrenci()
                                {
                                    Ogrenci_Id= Ogrenci_Id,
                                    Ogrenci_Ceza =CezaToplam,
                                };
                                //Eğer 15 günü aşan teslimler için Cezayı günceller.
                                IK_Ogrenci.IKIadeyeGununeGoreCezaEkleme(dK_Ogrenci);
                                    
                                // Ogrenci Bilgilerini atama ve Ceza label'ına atanır.
                                dK_Ogrenci=IK_Ogrenci.IKOgrenciBilgiGetir(dK_Ogrenci);
                                lbl_Ceza.Text = dK_Ogrenci.Ogrenci_Ceza.ToString();

                                // Teslim süresini aşanlar için kullanıcıya bilgilendirme mesajı(Öğrenciye uygulanacak ceza miktarı)
                                MessageBox.Show("Teslim İçin Belirlenen Süreyi Aştığınız İçin " + Ceza + " TL Cezaya Çarptırıldınız.Lütfen En Kısa Sürede Ödeyiniz.", "Ceza İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            // Alınma ve Teslim Tarihleri kontrolünün kullanıcıya gösterilicek olan hata mesajı
                            MessageBox.Show("Alinma Tarihi Teslim Tarihinden İleride Olamaz.Lütfen Tarihleri Kontrol Ediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }  
                    }
                    else
                    {
                    // Kitap_Adi,Kitap_Id ve Ogrenci_Id kontrolünün kullanıcıya gösterilicek olan hata mesajı
                    MessageBox.Show("Kitap Adi,Id ve Ogrenci Id si bos olamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                // ComboBox dolu mu bos mu kontrolünün kullanıcıya gösterilicek olan hata mesajı
                MessageBox.Show("Lütfen İade Ediceginiz Kitabı Seciniz.Eger Listede Kitap Yok İse Bir Kitap Alınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


        private void Ogrenci_KitapListesi_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            // Öğrencinin sahip oldugu kitap listesine ulaşmak için olusturulan nesne
            OgrenciKitapListesi kitapListesi = new OgrenciKitapListesi();
            // Öğrencinin Id bilgisi KitapListe sayfasına aktarılıyor.
            
            kitapListesi.Ogr_Id.Text =lbl_OgrId.Text;
            kitapListesi.ShowDialog();
            
        }

        private void Kitap_Ara_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            // Kütüphanede bulunan kitapları aramak için gerekli oluşturulan nesne
            OgrenciKitapAra kitapAra = new OgrenciKitapAra();
            // Öğrencinin Id bilgisi KitapAra sayfasına aktarılıyor.
            kitapAra.Ogr_Id.Text = lbl_OgrId.Text;
            kitapAra.ShowDialog();
            
        }

        private void pb_Istatistik_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            // Kütüphanenin ve Öğrencinin sahip oldugu kitaplar ve teslim edilmiş olan kitapların istatistiklerinin
            // bulunduğu sayfa için oluşturulan nesne
            OgrenciKitapIstatistik kitapIstatistik = new OgrenciKitapIstatistik();
            // Öğrencinin Id bilgisi İstatistikler sayfasına aktarılıyor.
            kitapIstatistik.Ogr_Id.Text = lbl_OgrId.Text;
            kitapIstatistik.ShowDialog();
            
        }
    }
}
