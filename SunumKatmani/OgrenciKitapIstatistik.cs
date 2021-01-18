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
using ZedGraph;

namespace SunumKatmani
{
    public partial class OgrenciKitapIstatistik : Form
    {
        
        int tumKitapSay;
        int okunanKitapSay;
        int OgrAldigiKitapSay;
        int OgrTeslimKitapSay;
        int OgrVerilebilecekKitapSay;
        

        public OgrenciKitapIstatistik()
        {
            InitializeComponent();
        }

        private void pb_Geri_Click(object sender, EventArgs e)
        {
            // Tanımlanan Picturebox ile OgrenciPaneli ekranına geri dönmemizi sağlandı.
            this.Visible = false;
            OgrenciPanel oPanel = new OgrenciPanel();
            oPanel.lbl_OgrId.Text = Ogr_Id.Text;
            oPanel.ShowDialog();
            
        }

        private void pb_Cikis_Click(object sender, EventArgs e)
        {
            // Tanımlanan Picturebox ile uygulamayı kapamamızı sağlar.
            System.Windows.Forms.Application.Exit();
        }

        private void OgrenciKitapIstatistik_Load(object sender, EventArgs e)
        {
            //Olusturulan Nesneler İçin Sayfa Acılırken Acıklamalar Olusturuldu.
            toolTip1.SetToolTip(pb_Geri, "Geri");
            toolTip1.SetToolTip(pb_Cikis, "Çıkış");

            // Öğrenci Id tanımlanan değişken katmanına atanır.
            DK_KitapAlanlar kitapSay = new DK_KitapAlanlar()
            {
                Ogrenci_Id = int.Parse(Ogr_Id.Text)
            };
            // İş katmanından dönen verileri değişkenlere atama
            tumKitapSay = IK_Kitap.IKKitapSayisi();
            okunanKitapSay = IK_Kitap.IKOkunanKitapSayisi();
            OgrAldigiKitapSay = IK_KitapAlanlar.IKOgrAldigiKitapSayisi(kitapSay);
            OgrTeslimKitapSay = IK_KitapAlanlar.IKOgrTeslimKitapSayisi(kitapSay);
            OgrVerilebilecekKitapSay = IK_KitapAlanlar.IKOgrVerilebilecekKitapSayisi(kitapSay);

            // Grafik oluşturma metodu çağrıldı
            GrafikOlusturma();

        }
        private void GrafikOlusturma()
        { 
            GraphPane myPane = zedGraph.GraphPane;

            // ZedGraph 'n baslık,satir ve sütun adlari atandı
            myPane.Title.Text = "Öğrenci İstatistikleri";
            myPane.XAxis.Title.Text = "";
            myPane.YAxis.Title.Text = "Kitap Sayıları";
            
            // Double değişkenlere gelen int değerler atandı
            double[]y = {tumKitapSay};
            double[] y1 = {okunanKitapSay};
            double[] y2 = {OgrAldigiKitapSay};
            double[] y3 = {OgrTeslimKitapSay};
            double[] y4 = {OgrVerilebilecekKitapSay };

            
            // Bir bar nesnesi oluşturuldu ve içine İş katmanından gelen degerler atandı
            BarItem myBar = myPane.AddBar("Tüm Kitap Sayısı", null,y, Color.Red);
            myBar.Bar.Fill = new Fill(Color.Red, Color.White, Color.Red);

            myBar = myPane.AddBar("Şuan Okunan Kitap Sayısı", null, y1, Color.Purple);
            myBar.Bar.Fill = new Fill(Color.Purple, Color.White, Color.Purple);

            myBar = myPane.AddBar("Öğrenci Aldıgı Kitap Sayisi", null, y2, Color.Blue);
            myBar.Bar.Fill = new Fill(Color.Blue, Color.White, Color.Blue);

            myBar = myPane.AddBar("Öğrenci Teslim Kitap Sayisi", null, y3, Color.Green);
            myBar.Bar.Fill = new Fill(Color.Green, Color.White, Color.Green);

            myBar = myPane.AddBar("Öğrenci Verilebilecek Kitap Sayisi", null, y4, Color.Cyan);
            myBar.Bar.Fill = new Fill(Color.Cyan, Color.White, Color.Cyan);


            myPane.XAxis.MajorTic.IsBetweenLabels = true;
            myPane.XAxis.Type = AxisType.Text;
            myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 90F);
            myPane.Fill = new Fill(Color.FromArgb(250, 250, 255));
            zedGraph.AxisChange();

        }
    }
}
