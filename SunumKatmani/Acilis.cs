using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SunumKatmani
{
    public partial class Acilis : Form
    {
        public Acilis()
        {
            InitializeComponent();
        }

        private int saniye = 6;
        private int sayac = 0;
        public string[] Giris = new string[] { "Program Yükeleniyor Lütfen Bekleyin.", "Program Yükeleniyor Lütfen Bekleyin..", "Program Yükeleniyor Lütfen Bekleyin...", "Program Açılıyor.", "Secim Ekranina Yönlediriliyorsuz.","..." };

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Giris string ini label içine yazdırma işlemi ve bu işlem bitiminde belirlenen seçim ekranına girişi sağlandı.
            saniye--;
            lbl_bekleme.Text = Giris[sayac];
            sayac++;
            if (sayac == 6)
            {
                sayac = 0;
            }

            if (sayac == 0)
            {
                Timer.Stop();
                BarTimer.Stop();
                Thread.Sleep(1000);
                this.Visible = false;
                SecimEkrani s1 = new SecimEkrani();
                s1.ShowDialog();
                

            }

        }

        private void BarTimer_Tick(object sender, EventArgs e)
        {
            // Progress barin yüklenme efektini vermesi için gerekli kodlar yazıldı
            progressBar_Acilis.Value += 2;
            if (progressBar_Acilis.Value == 100)
            {
                BarTimer.Stop();
            }
        }

        private void Acilis_Load(object sender, EventArgs e)
        {
            // Olusturulan iki adet timer açılış ekranının başlamasıyla baslatıldı.
            Timer.Start();
            Timer.Interval = 1000;
            BarTimer.Start();
            BarTimer.Interval = 100;
            GC.Collect();
        }
    }
}
