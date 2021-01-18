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
    public partial class OgrenciKitapAra : Form
    {
        public OgrenciKitapAra()
        {
            InitializeComponent();
            
        }

        private void pb_Cikis_Click(object sender, EventArgs e)
        {
            // Tanımlanan Picturebox ile uygulamayı kapamamızı sağlar.
            System.Windows.Forms.Application.Exit();
        }

        private void pb_Geri_Click(object sender, EventArgs e)
        {
            // Tanımlanan Picturebox ile OgrenciPaneli ekranına geri dönmemizi sağlandı.
            this.Visible = false;
            OgrenciPanel oPanel = new OgrenciPanel();
            oPanel.lbl_OgrId.Text = Ogr_Id.Text;
            oPanel.ShowDialog();
            
        }

        private void pb_KitapAra_Click(object sender, EventArgs e)
        {
            if (txt_KitapAra.Text != "") // Metin arama yaparken textbox'ın bos olmama kontrolü
            { 
                // Datagrid'e textboxa girilen metini İş katmanına atar ve gelen bilgiyi döndürür.
                dataGrid_KitapAra.DataSource=IK_Kitap.IKKitapAra(txt_KitapAra.Text);
            }
            else
            {
                // Boş oldugu takdirdeki hata mesajı kullanıcıya gösterilir.
                MessageBox.Show("Boş arama işlemi yapılamaz.Lütfen doldurup tekrar deneyiniz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pb_Yinele_Click(object sender, EventArgs e)
        {
            // Datagrid'e kitap listesini yenilemek için İş katmanına atar ve gelen bilgiyi döndürür.
            dataGrid_KitapAra.DataSource = IK_Kitap.IKKitapListele();
            txt_KitapAra.Text = "";
        }

        private void OgrenciKitapAra_Load(object sender, EventArgs e)
        {
            //Olusturulan Nesneler İçin Sayfa Acılırken Acıklamalar Olusturuldu.
            toolTip1.SetToolTip(txt_KitapAra, "Aramak İstediğini Metini Girin");
            toolTip1.SetToolTip(pb_Geri, "Geri");
            toolTip1.SetToolTip(pb_Cikis, "Çıkış");
            toolTip1.SetToolTip(pb_Yinele, "Tabloyu Yenile");
            toolTip1.SetToolTip(pb_KitapAra, "Ara");

            // İş katmanındaki kitaplari listeleyen bilgiler döner.
            dataGrid_KitapAra.DataSource = IK_Kitap.IKKitapListele();

            dataGrid_KitapAra.Columns[0].HeaderText = "ID";
            dataGrid_KitapAra.Columns[0].Width = 30;
            dataGrid_KitapAra.Columns[1].HeaderText = "Kitap Adı";
            dataGrid_KitapAra.Columns[2].HeaderText = "Kitap Yazarı";
            dataGrid_KitapAra.Columns[3].HeaderText = "Kitap Basım Tarihi";
            dataGrid_KitapAra.Columns[4].HeaderText = "Kitap Türü";
            dataGrid_KitapAra.Columns[5].HeaderText = "Kitap Sayfa Sayısı";


        }
    }
}
