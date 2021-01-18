using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Referans ile alınan classları kullanmak için gereken kod
using VarOlanDegiskenKatmani;
using IsKatmani;


namespace SunumKatmani
{
    public partial class OgrenciGiris : Form
    {
        public OgrenciGiris()
        {
            InitializeComponent();
        } 
        private void btn_Giris_Click(object sender, EventArgs e)
        {
            if(txt_OgrenciTc.Text!="" && txt_OgrenciSifre.Text != "")// TC ve Sifre textboxların boş gönderilmesini önleyen koşul
            {
                if (txt_OgrenciTc.Text.Length == 11)// Girilen TC'nin 11 hane olmasını gerektiren koşul
                {
                    //TC ve Sifresini oluşturulan degisken katmanına nesnesine atılmasını saglar
                    DK_Ogrenci dK_Ogrenci = new DK_Ogrenci()
                    {
                        Ogrenci_Tc = txt_OgrenciTc.Text,
                        Ogrenci_Sifre=txt_OgrenciSifre.Text
                    };
                    //TC sini oluşturulan degisken katmanına nesnesine atılmasını saglari.
                    DK_Ogrenci dk_AdSoyad = new DK_Ogrenci()
                    {
                        Ogrenci_Tc = txt_OgrenciTc.Text
                    };
                    if (IK_Ogrenci.IKOgrenciKontrol(dK_Ogrenci) == true)//Eger Veritabanindan gelen degerler dogru ise giris yapar
                    {
                        int Ogrenci_ID=IK_Ogrenci.IKOgrenciIdKontrol(dK_Ogrenci);// Kontrol ile dönen ıd yi değişkene atama

                        if (Ogrenci_ID!=0)// Değişkenin 0'a eşit olmama durum kontrolu 
                        {
                            OgrenciPanel oPanel = new OgrenciPanel();//Öğrenci Paneli icin yeni nesne olusturuldu

                            this.Visible = false;
                            //TC si ve Sifresi doğru olan kisinin Adini ve Soyadini getiren kod
                            MessageBox.Show("Hoşgeldin " + IK_Ogrenci.IKOgrenciGirisAdSoyadKontrol(dk_AdSoyad), "Hoşgeldin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Ogrenci Panelinde olan ve public bir label nesnesine giriş yapan öğrencinin Id'sini atama
                            oPanel.lbl_OgrId.Text = Ogrenci_ID.ToString();
                            txt_OgrenciTc.Text = "";
                            txt_OgrenciSifre.Text = "";
                            oPanel.ShowDialog(); 
                        }
                    }
                    else
                    {
                        // Eğer girilen TC ve şifre veritabaninda yok ise gelen hatanın kullanıcıya bildirilme işlemi
                        MessageBox.Show("TC nizi veya sifrenizi yanlis girdiniz.Lütfen Tekrar Deneyin.\nSifrenizi unuttuysanız Sifremi Unuttum'a basınız.",
                            "Hatali Giriş", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                // Eğer girilen TC ve Şifre alanları boş giriş yapılmaya çalısıldıgında kullanıcıya hata olduğunu bildiren işlem
                MessageBox.Show("Öğrenci TC ve Öğrenci Sifre alanları boş bırakılamaz.Lütfen Tekrar Giriniz.", "Hatali Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void check_SifreGor_CheckedChanged(object sender, EventArgs e)
        {
            //Checkbox seçili ise şifreyi göster değilse sifreyi '*' karakteri gösterme işlemi.
            if (check_SifreGor.Checked)
            {
                txt_OgrenciSifre.PasswordChar = '\0';
            }
            else
            {
                txt_OgrenciSifre.PasswordChar = '*';
            }
        }

        private void lbl_SifreUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Link label ile Öğrencinin sifresini unuttum sayfasına yönlendirilme işlemi
            this.Visible = false;
            OgrenciSifremiUnuttum oSifreUnuttum = new OgrenciSifremiUnuttum();
            oSifreUnuttum.ShowDialog();
            
        }

        private void txt_OgrenciTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txt_OgrenciTc_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // TC ye harflerin girişi engellendi.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pb_Geri_Click(object sender, EventArgs e)
        {
            // Tanımlanan Picturebox ile secim ekranına geri dönmemizi sağlandı.
            this.Visible = false;
            SecimEkrani s1 = new SecimEkrani();
            s1.ShowDialog();
            
        }

        private void pb_Cikis_Click(object sender, EventArgs e)
        {
            // Tanımlanan Picturebox ile uygulamayı kapamamızı sağlar.
            System.Windows.Forms.Application.Exit();
        }

        private void OgrenciGiris_Load(object sender, EventArgs e)
        {
            //Olusturulan Nesneler İçin Sayfa Acılırken Acıklamalar Olusturuldu.
            toolTip1.SetToolTip(pb_Geri, "Geri");
            toolTip1.SetToolTip(pb_Cikis, "Çıkış");
            GC.Collect();
            
        }
    }
}
