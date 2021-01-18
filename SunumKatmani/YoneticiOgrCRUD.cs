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
    public partial class YoneticiOgrCRUD : Form
    {
        int ID;
        float Ceza;

        public YoneticiOgrCRUD()
        {
            InitializeComponent();
        }
        private void OgrenciListeGuncelle()
        {
            //DataGrid e ilk verilerin gelmesi
            dataGrid_Ogrenci.DataSource = IK_Ogrenci.IKOgrenciListele();

            dataGrid_Ogrenci.Columns[0].HeaderText = "Öğrenci ID";
            dataGrid_Ogrenci.Columns[0].Width = 50;
            dataGrid_Ogrenci.Columns[1].HeaderText = "Öğrenci TC";
            dataGrid_Ogrenci.Columns[2].HeaderText = "Öğrenci Adı";
            dataGrid_Ogrenci.Columns[3].HeaderText = "Öğrenci Soyadi";
            dataGrid_Ogrenci.Columns[4].HeaderText = "Öğrenci Yaş";
            dataGrid_Ogrenci.Columns[5].HeaderText = "Öğrenci Cinsiyet";
            dataGrid_Ogrenci.Columns[6].HeaderText = "Öğrenci Şifre";
            dataGrid_Ogrenci.Columns[7].HeaderText = "Öğrenci Ceza";

            //Fonksiyon acıldıgında textboxların bos gelmesi
            txt_OgrTc.Text = "";
            txt_OgrAdi.Text = "";
            txt_OgrSoyadi.Text = "";
            txt_OgrYas.Text = "";
            cb_OgrCinsiyet.Text = "";
            txt_OgrSifre.Text = "";
        }

        
        private void pb_OgrEkle_Click(object sender, EventArgs e)
        {
            //Textbox Bos Olup Olmadıgının Kontrolü
            if (txt_OgrTc.Text != "" && txt_OgrAdi.Text != "" && txt_OgrSoyadi.Text != "" && txt_OgrYas.Text != "" && cb_OgrCinsiyet.Text != "" && txt_OgrSifre.Text != "")
            {
                if (txt_OgrTc.Text.Length == 11)//Öğrenci TC nin 11 haneli olma kontrolü
                {
                    if (int.Parse(txt_OgrYas.Text)>0&& int.Parse(txt_OgrYas.Text)<150)//Öğrenci Yas Kontrolü
                    {
                        // Textboxtaki bilgilerin değişken katmanına atanma işlemi
                        DK_Ogrenci dK_Ogrenci = new DK_Ogrenci()
                        {
                            Ogrenci_Tc = txt_OgrTc.Text,
                            Ogrenci_Adi = txt_OgrAdi.Text,
                            Ogrenci_Soyadi = txt_OgrSoyadi.Text,
                            Ogrenci_Yas = int.Parse(txt_OgrYas.Text),
                            Ogrenci_Cinsiyet = cb_OgrCinsiyet.Text,
                            Ogrenci_Sifre = txt_OgrSifre.Text
                        };
                        if (IK_Ogrenci.IKOgrenciAynıTCKontrol(dK_Ogrenci) == true)// Girilen TC sistemde varsa koşulu
                        {
                            // Aynı TC sistemde yok ise iş katmanına öğrenci bilgileri atama
                            IK_Ogrenci.IKOgrenciEkle(dK_Ogrenci);
                            MessageBox.Show("Öğrenci Başarılı Bir Şekilde Kayıt Edilmiştir.", "Başarılı Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            OgrenciListeGuncelle();
                        }
                        else
                        {
                            MessageBox.Show("Aynı TC Sistemde Var.Lütfen TC nizi Kontrol Ediniz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Öğrenci Yaşı 0 ile 150 olması gerekir.Lütfen Tekrar Deneyin", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("TC nizi eksik veya fazla giriş yaptınız.Lütfen Tekrar Deneyin", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz.Lütfen Tekrar Giriniz.", "Hatali Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //Textboxlari kayıttan sonra bosaltma
            txt_OgrTc.Text = "";
            txt_OgrAdi.Text = "";
            txt_OgrSoyadi.Text = "";
            txt_OgrYas.Text = "";
            cb_OgrCinsiyet.Text = "";
            txt_OgrSifre.Text = "";
        }

        private void YoneticiOgrCRUD_Load(object sender, EventArgs e)
        {
            //Olusturulan Nesneler İçin Sayfa Acılırken Acıklamalar Olusturuldu.
            toolTip1.SetToolTip(pb_Geri, "Geri");
            toolTip1.SetToolTip(pb_Cikis, "Çıkış");
            toolTip1.SetToolTip(pb_OgrEkle, "Öğrenci Ekle");
            toolTip1.SetToolTip(pb_OgrSil, "Öğrenci Sil");
            toolTip1.SetToolTip(pb_OgrGnclle, "Öğrenci Güncelle");

            //Load ekranı ogrenci listesi güncelleme ve dataGride işleme fonk cagırımı
            OgrenciListeGuncelle();
            GC.Collect();

        }

        private void dataGrid_Ogrenci_SelectionChanged(object sender, EventArgs e)
        {
            //DataGrid içinde seçilen bir satırın bilgilerini textboxlara aktarma
            ID =int.Parse(dataGrid_Ogrenci.CurrentRow.Cells[0].Value.ToString());
            txt_OgrTc.Text = dataGrid_Ogrenci.CurrentRow.Cells[1].Value.ToString();
            txt_OgrAdi.Text= dataGrid_Ogrenci.CurrentRow.Cells[2].Value.ToString();
            txt_OgrSoyadi.Text= dataGrid_Ogrenci.CurrentRow.Cells[3].Value.ToString();
            txt_OgrYas.Text= dataGrid_Ogrenci.CurrentRow.Cells[4].Value.ToString();
            cb_OgrCinsiyet.Text= dataGrid_Ogrenci.CurrentRow.Cells[5].Value.ToString();
            txt_OgrSifre.Text= dataGrid_Ogrenci.CurrentRow.Cells[6].Value.ToString();
            Ceza=float.Parse(dataGrid_Ogrenci.CurrentRow.Cells[7].Value.ToString());

            
        }

        private void pb_Ogr_Gnclle_Click(object sender, EventArgs e)
        {
            // Textbox ve ID lerin bos olmama koşulu
            if (ID.ToString()!=""&&txt_OgrTc.Text != "" && txt_OgrAdi.Text != "" && txt_OgrSoyadi.Text != "" && txt_OgrYas.Text != "" && cb_OgrCinsiyet.Text != "" && txt_OgrSifre.Text != "")
            {
                // TC nin 11 haneli olma koşulu
                if (txt_OgrTc.Text.Length == 11)
                {
                    // Eğer tüm koşullar sağlanırsa değişken katmanına değerler atanır.
                    DK_Ogrenci dK_Ogrenci = new DK_Ogrenci()
                    {
                        Ogrenci_Id = int.Parse(ID.ToString()),
                        Ogrenci_Tc = txt_OgrTc.Text,
                        Ogrenci_Adi = txt_OgrAdi.Text,
                        Ogrenci_Soyadi = txt_OgrSoyadi.Text,
                        Ogrenci_Yas = int.Parse(txt_OgrYas.Text),
                        Ogrenci_Cinsiyet = cb_OgrCinsiyet.Text,
                        Ogrenci_Sifre = txt_OgrSifre.Text
                    };

                    if (IK_Ogrenci.IKOgrenciAynıTCKontrol(dK_Ogrenci) == true)// Girilen TC sistemde varsa koşulu
                    { 
                     // Değişken katmanına atanan değerleri iş katmanına atanır.
                     IK_Ogrenci.IKOgrenciGuncelle(dK_Ogrenci);
                    MessageBox.Show("Öğrenci Başarılı Bir Şekilde Güncellenmiştir.", "Başarılı Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Güncellenenen öğrenci bilgilerini tabloya işler.
                    OgrenciListeGuncelle();
                    }
                    else
                    {
                        MessageBox.Show("Aynı TC Sistemde Var.Lütfen TC nizi Kontrol Ediniz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("TC nizi eksik veya fazla giriş yaptınız.Lütfen Tekrar Deneyin", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz.Lütfen Tekrar Giriniz.", "Hatali Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //Textboxlari kayıttan sonra bosaltma
            txt_OgrTc.Text = "";
            txt_OgrAdi.Text = "";
            txt_OgrSoyadi.Text = "";
            txt_OgrYas.Text = "";
            cb_OgrCinsiyet.Text = "";
            txt_OgrSifre.Text = "";
        }

        private void txt_OgrYas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Yas textboxuna harf girisini engelleme
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_OgrTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Tc textboxuna harf girisini engelleme
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pb_OgrSil_Click(object sender, EventArgs e)
        {
            // Gelen ID boş olamama koşulu
            if (ID.ToString() != "")
            {
                // Eğer boş değilse gelen ID değişken katmanına atanır.
                DK_Ogrenci dK_Ogrenci = new DK_Ogrenci()
                {
                    Ogrenci_Id = int.Parse(ID.ToString())
                };
                // Atanan değişken katmanı ile iş katmanına atanır.
                IK_Ogrenci.IKOgrenciSil(dK_Ogrenci);
                MessageBox.Show("Öğrenci Başarılı Bir Şekilde Silinmiştir.", "Başarılı Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Silinen öğrenci tablodan silinme işlemi
                OgrenciListeGuncelle();
            }     
        }

        private void pb_Geri_Click(object sender, EventArgs e)
        {
            // Tanımlanan Picturebox ile yönetici paneline geri dönmemizi sağlandı.
            this.Visible = false;
            YoneticiPaneli y1 = new YoneticiPaneli();
            y1.ShowDialog();
            
        }

        private void pb_Cikis_Click(object sender, EventArgs e)
        {
            // Tanımlanan Picturebox ile uygulamayı kapamamızı sağlar.
            System.Windows.Forms.Application.Exit();
        }
    }
}
