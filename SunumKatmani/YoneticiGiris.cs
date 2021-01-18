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
    public partial class YoneticiGiris : Form
    {
        public YoneticiGiris()
        {
            InitializeComponent();
        }

        private void btn_Giris_Click(object sender, EventArgs e)
        {
            
            if (txt_KAdi.Text != "" && txt_Sifre.Text != "")
            {
                //Yonetici nesnesi olusturup gelen KAdi ve Sifre Değişken Katmanına(DK) ya yollanır.
                DK_Yonetici dk_Yonetici = new DK_Yonetici()
                {
                    Yonetici_KullaniciAdi = txt_KAdi.Text,
                    Yonetici_Sifre = txt_Sifre.Text
                };


                if (IK_Yonetici.IKYoneticiKontrol(dk_Yonetici) == true)
                {
                    //Eger olusturulan nesne veritabaninda var ise yeni form olustur ve oraya git
                    this.Visible = false;
                    YoneticiPaneli yPanel = new YoneticiPaneli();

                    //Giris Yapan Kullanıcının Adi Ekranda yazanr
                    MessageBox.Show("Hoşgeldin " + txt_KAdi.Text.ToUpper() + " sisteme başarılı bir şekilde giriş yaptınız.", "Hoşgeldin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_KAdi.Text = "";
                    txt_Sifre.Text = "";
                    yPanel.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Giriş işlemi başarısız oldu.Kullanıcı adı veya sifre yanlış.Tekrar Deneyin..", "Hatali Giris", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
            }
            else
            {
                MessageBox.Show("Kullanici adini veya sifresi bos olamaz.Tekrar deneyin.", "Hatali Giris", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

                
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void check_SifreGör(object sender, EventArgs e)
        {

        }

        private void check_SifreGor_CheckedChanged(object sender, EventArgs e)
        {//Checkbox secili ise sifreyi göster değilse sifreyi '*' karakteri göstersin.
            if (check_SifreGor.Checked)
            {
                txt_Sifre.PasswordChar = '\0';
            }
            else
            {
                txt_Sifre.PasswordChar = '*';
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

        private void YoneticiGiris_Load(object sender, EventArgs e)
        {
            //Olusturulan Nesneler İçin Sayfa Acılırken Acıklamalar Olusturuldu.
            toolTip1.SetToolTip(pb_Geri, "Geri");
            toolTip1.SetToolTip(pb_Cikis, "Çıkış");
            GC.Collect();
        }
    }
}
