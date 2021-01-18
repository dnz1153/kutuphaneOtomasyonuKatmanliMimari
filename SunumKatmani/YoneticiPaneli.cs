using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SunumKatmani
{
    public partial class YoneticiPaneli : Form
    {
        public YoneticiPaneli()
        {
            InitializeComponent();
        }

        private void pb_Ogrenci_Click(object sender, EventArgs e)
        {
            // Tanımlanan Picturebox ile YöneticiÖğrenci sayfasına gidildi.
            this.Visible = false;
            YoneticiOgrCRUD ogrCRUD = new YoneticiOgrCRUD();
            ogrCRUD.ShowDialog();
            
        }

        private void pb_Kitap_Click(object sender, EventArgs e)
        {
            // Tanımlanan Picturebox ile YöneticiKitap sayfasına gidildi.
            this.Visible = false;
            YoneticiKitapCRUD kitapCRUD = new YoneticiKitapCRUD();
            kitapCRUD.ShowDialog();
            
        }

        private void pb_Geri_Click(object sender, EventArgs e)
        {
            // Tanımlanan Picturebox ile yönetici giris ekranına geri dönmemizi sağlandı.
            this.Visible = false;
            YoneticiGiris y1 = new YoneticiGiris();
            y1.ShowDialog();
            
        }

        private void pb_Cikis_Click(object sender, EventArgs e)
        {
            // Tanımlanan Picturebox ile uygulamayı kapamamızı sağlar.
            System.Windows.Forms.Application.Exit();
        }

        private void YoneticiPaneli_Load(object sender, EventArgs e)
        {
            //Olusturulan Nesneler İçin Sayfa Acılırken Acıklamalar Olusturuldu.
            toolTip1.SetToolTip(pb_Geri, "Geri");
            toolTip1.SetToolTip(pb_Cikis, "Çıkış");

            GC.Collect();
        }
    }
}
