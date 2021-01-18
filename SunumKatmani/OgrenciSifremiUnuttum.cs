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
    public partial class OgrenciSifremiUnuttum : Form
    {
        public OgrenciSifremiUnuttum()
        {
            InitializeComponent();
        }

        private void txt_OgrenciTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Tc textboxuna harf girisini engelleme
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txt_OgrenciYasi_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Yas textboxuna harf girisini engelleme
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_OgrenciBul_Click(object sender, EventArgs e)
        {
            // Ogrencinin TC,Adi,Soyadi ve Yası girilen degerlerin bos olmamasını saglar
            if (txt_OgrenciTc.Text != "" && txt_OgrenciAdi.Text != "" && txt_OgrenciSoyadi.Text != "" && txt_OgrenciYasi.Text != "")
            {
                //Ogrenci_Tc 11 haneli olmasını saglar
                if (txt_OgrenciTc.Text.Length == 11)
                {
                    //Ogrenci nesnesi olusturuldu.Degisken katmanına veriler yollandı.
                    DK_Ogrenci dk_Ogrenci = new DK_Ogrenci()
                    {
                        Ogrenci_Tc = txt_OgrenciTc.Text,
                        Ogrenci_Adi = txt_OgrenciAdi.Text,
                        Ogrenci_Soyadi = txt_OgrenciSoyadi.Text,
                        Ogrenci_Yas = int.Parse(txt_OgrenciYasi.Text)
                    };
                    //Yukarida girilen veriler dogru ise labelın textine ogrencinin sifresini yazmayı saglar
                    lbl_SifreGöster.Text = IK_Ogrenci.IKOgrenciSifreKontrol(dk_Ogrenci).ToString();
                    //Yukarida girilen veriler dogru ise labelın arka plan rengi kırmızı olur
                    lbl_SifreGöster.BackColor =System.Drawing.Color.Red;
                    if (lbl_SifreGöster.Text == "")
                    {
                        // Eger Sifre boş ise Öğrenci bulunamadı hatası ve background rengini şeffaf yapar.
                        lbl_SifreGöster.BackColor = System.Drawing.Color.Transparent;
                        MessageBox.Show("Ogrenci Bulunamadi.Lütfen Bilgileri Dogru Giriniz.", "Böyle Bir Öğrenci Yok", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                else
                {
                    // Eğer girilen TC 11 haneden az veya fazla ise kullanıcıya hata oldugunu bildiren işlem
                    MessageBox.Show("TC nizi eksik veya fazla giriş yaptınız.Lütfen Tekrar Deneyin", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Eğer girilen TC,Adi,Soyadi ve Yaş alanları boş giriş yapılmaya çalısıldıgında kullanıcıya hata olduğunu bildiren işlem
                MessageBox.Show("Öğrencinin TC,Adi,Soyadi ve Yas alanları boş bırakılamaz.Lütfen Tekrar Giriniz.", "Hatali Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pb_Geri_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            // Tanımlanan Picturebox ile öğrenci giriş ekranına geri dönmemizi sağlandı.
            OgrenciGiris giris = new OgrenciGiris();
            giris.ShowDialog();
            
        }

        private void pb_Cikis_Click(object sender, EventArgs e)
        {
            // Tanımlanan Picturebox ile uygulamayı kapamamızı sağlar.
            System.Windows.Forms.Application.Exit();
        }

        private void OgrenciSifremiUnuttum_Load(object sender, EventArgs e)
        {
            //Olusturulan Nesneler İçin Sayfa Acılırken Acıklamalar Olusturuldu.
            toolTip1.SetToolTip(pb_Geri, "Geri");
            toolTip1.SetToolTip(pb_Cikis, "Çıkış");
            toolTip1.SetToolTip(lbl_SifreGöster, "Öğrencinin Sifresi");
            GC.Collect();
        }
    }
}
