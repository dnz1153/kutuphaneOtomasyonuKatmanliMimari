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
    public partial class SecimEkrani : Form
    {
        public SecimEkrani()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Tanımlanan Picturebox ile yönetici giris ekranına bağlantı sağlandı.
            this.Visible = false;
            YoneticiGiris Ygiris = new YoneticiGiris();
            Ygiris.ShowDialog();
            

        }

        private void pb_Ogrenci_Click(object sender, EventArgs e)
        {
            // Tanımlanan Picturebox ile öğrenci giris ekranına bağlantı sağlandı.
            this.Visible = false;
            OgrenciGiris Ogiris = new OgrenciGiris();
            Ogiris.ShowDialog();
            
        }

        private void SecimEkrani_Load(object sender, EventArgs e)
        {
            GC.Collect();
        }
    }
}
