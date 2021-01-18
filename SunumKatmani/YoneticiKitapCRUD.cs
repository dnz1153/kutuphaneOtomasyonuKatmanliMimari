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
    public partial class YoneticiKitapCRUD : Form
    {
        int ID;
        
        public YoneticiKitapCRUD()
        {
            InitializeComponent();
        }
        private void KitapListeleGuncelle()
        {
            
            //DataGrid e ilk verilerin gelmesi
            dataGrid_Kitap.DataSource = IK_Kitap.IKKitapListele();

            dataGrid_Kitap.Columns[0].HeaderText = "Kitap ID";
            dataGrid_Kitap.Columns[0].Width = 50;
            dataGrid_Kitap.Columns[1].HeaderText = "Kitap Adı";
            dataGrid_Kitap.Columns[2].HeaderText = "Kitap Yazar";
            dataGrid_Kitap.Columns[3].HeaderText = "Kitap Basim Tarihi";
            dataGrid_Kitap.Columns[4].HeaderText = "Kitap Türü";
            dataGrid_Kitap.Columns[5].HeaderText = "Kitap Sayfa Sayısı";

            //Fonksiyon acıldıgında textboxların bos gelmesi
            txt_KitapAdi.Text = "";
            txt_KitapYazar.Text = "";
            dateTime_BasimTarihi.Text = "";
            txt_KitapTuru.Text = "";
            txt_KitapSayfaSayisi.Text = "";
        }

        private void YoneticiKitapCRUD_Load(object sender, EventArgs e)
        {
            //Olusturulan Nesneler İçin Sayfa Acılırken Acıklamalar Olusturuldu.
            toolTip1.SetToolTip(pb_Geri, "Geri");
            toolTip1.SetToolTip(pb_Cikis, "Çıkış");
            toolTip1.SetToolTip(pb_KitapEkle, "Kitabı Ekle");
            toolTip1.SetToolTip(pb_KitapSil, "Kitabı Sil");
            toolTip1.SetToolTip(pb_KitapGnclle, "Kitabı Güncelle");
            toolTip1.SetToolTip(pb_KitapCRUDListele, "Kitap İşlemleri(Ekle-Sil-Güncelle-Listele)");
            toolTip1.SetToolTip(pb_KitapAlimTeslimListele, "Kitap Alim Ve Teslim Listesi Görüntüle");
            KitapListeleGuncelle();
            GC.Collect();
        }

        private void pb_Geri_Click(object sender, EventArgs e)
        {
            // Tanımlanan Picturebox ile yönetici giris ekranına geri dönmemizi sağlandı.
            this.Visible = false;
            YoneticiPaneli y2 = new YoneticiPaneli();
            y2.ShowDialog();
            
        }

        private void pb_Cikis_Click(object sender, EventArgs e)
        {
            // Tanımlanan Picturebox ile uygulamayı kapamamızı sağlar.
            System.Windows.Forms.Application.Exit();
        }

        private void pb_KitapEkle_Click(object sender, EventArgs e)
        {
            // Textboxların boş olmaması için gerekli koşul yapısı
            if (txt_KitapAdi.Text != "" && txt_KitapYazar.Text != "" && dateTime_BasimTarihi.Text != "" && txt_KitapTuru.Text != "" && txt_KitapSayfaSayisi.Text != "")
            {
                // Textboxtan gelen bilgileri değişken katmanındaki nesnenin içine atama işlemi
                DK_Kitap dK_Kitap = new DK_Kitap()
                {
                    Kitap_Adi = txt_KitapAdi.Text,
                    Kitap_Yazar = txt_KitapYazar.Text,
                    Kitap_BasimT = dateTime_BasimTarihi.Text,
                    Kitap_Turu = txt_KitapTuru.Text,
                    Kitap_SayfaSayisi = int.Parse(txt_KitapSayfaSayisi.Text)
                };
                // İş katmanına değişken katmanına atanan bilgiler yollanır.
                IK_Kitap.IKKitapEkle(dK_Kitap);
                MessageBox.Show("Kitap Başarılı Bir Şekilde Kayıt Edilmiştir.", "Başarılı Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Eklenen kitabı listede güncelleme
                KitapListeleGuncelle();
            }
            else
            {
                // Eğer herhangi bir textbox boş ise kullanıcıya hata mesajı gösterir.
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz.Lütfen Tekrar Giriniz.", "Hatali Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txt_KitapAdi.Text = "";
            txt_KitapYazar.Text = "";
            dateTime_BasimTarihi.Text = "";
            txt_KitapTuru.Text = "";
            txt_KitapSayfaSayisi.Text = "";

        }

        private void pb_KitapGnclle_Click(object sender, EventArgs e)
        {
            // Textboxlardan gelen ve tablodan gelen bilgiler boş olamama koşulu
            if (ID.ToString()!=""&&txt_KitapAdi.Text != "" && txt_KitapYazar.Text != "" && dateTime_BasimTarihi.Text != "" && txt_KitapTuru.Text != "" && txt_KitapSayfaSayisi.Text != "")
            {
                // Gelen bilgileri değişken katmanına atama işlemi
                DK_Kitap dK_Kitap = new DK_Kitap()
                {
                    Kitap_Id = int.Parse(ID.ToString()),
                    Kitap_Adi = txt_KitapAdi.Text,
                    Kitap_Yazar = txt_KitapYazar.Text,
                    Kitap_BasimT = dateTime_BasimTarihi.Text,
                    Kitap_Turu = txt_KitapTuru.Text,
                    Kitap_SayfaSayisi = int.Parse(txt_KitapSayfaSayisi.Text)
                };
                // İş katmanına değişken katmanından gelen bilgiler aktarılır
                IK_Kitap.IKKitapGuncelle(dK_Kitap);
                MessageBox.Show("Kitap Başarılı Bir Şekilde Güncellenmiştir.", "Başarılı Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Güncellenen kitabı listeye tekrar yazma işlemi
                KitapListeleGuncelle();
            }
            else
            {
                // Eğer herhangi bir textbox boş ise kullanıcıya hata mesajı gösterir.
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz.Lütfen Tekrar Giriniz.", "Hatali Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txt_KitapAdi.Text = "";
            txt_KitapYazar.Text = "";
            dateTime_BasimTarihi.Text = "";
            txt_KitapTuru.Text = "";
            txt_KitapSayfaSayisi.Text = "";
        }

        private void dataGrid_Kitap_SelectionChanged(object sender, EventArgs e)
        {
            // Tabloda herhangi bir satıra basıldıgı anda değişken ve textboxlara o bilgileri atama
            ID = int.Parse(dataGrid_Kitap.CurrentRow.Cells[0].Value.ToString());
            if (txt_KitapAdi.Enabled == true)
            {
            
            txt_KitapAdi.Text = dataGrid_Kitap.CurrentRow.Cells[1].Value.ToString();
            txt_KitapYazar.Text = dataGrid_Kitap.CurrentRow.Cells[2].Value.ToString();
            dateTime_BasimTarihi.Text = dataGrid_Kitap.CurrentRow.Cells[3].Value.ToString();
            txt_KitapTuru.Text = dataGrid_Kitap.CurrentRow.Cells[4].Value.ToString();
            txt_KitapSayfaSayisi.Text = dataGrid_Kitap.CurrentRow.Cells[5].Value.ToString();
            }
            
        }

        private void txt_KitapSayfaSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Kitap Sayfa Sayisi textboxuna harf girisini engelleme
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pb_KitapSil_Click(object sender, EventArgs e)
        {
            // ID'nin boş gelmeme koşulu
            if (ID.ToString() != "")
            {
                // ID'nin değişken katmanına atanma işlemi
                DK_Kitap dK_Kitap = new DK_Kitap()
                {
                    Kitap_Id = int.Parse(ID.ToString())
                };
                // İş katmanına değişken katmanından gelen ID bilgisi atanır.
                IK_Kitap.IKKitapSil(dK_Kitap);
                MessageBox.Show("Kitap Başarılı Bir Şekilde Silinmiştir.", "Başarılı Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KitapListeleGuncelle();
            }
        }

        private void pb_KitapCRUDListele_Click(object sender, EventArgs e)
        {
            // kitap listesi güncelleme ve dataGride işleme fonk cagırımı 
            KitapListeleGuncelle();
            // Textboxları ve picturebox nesnelerini işlevlerini aktif etme
            txt_KitapAdi.Enabled = true;
            txt_KitapYazar.Enabled = true;
            dateTime_BasimTarihi.Enabled = true;
            txt_KitapTuru.Enabled = true;
            txt_KitapSayfaSayisi.Enabled = true;

            pb_KitapEkle.Enabled = true;
            pb_KitapSil.Enabled = true;
            pb_KitapGnclle.Enabled = true;
        }

        private void pb_KitapAlimTeslimListele_Click(object sender, EventArgs e)
        {
            // Değişken katmanına Kitap_Id nin atanma işlemi
            DK_KitapBilgisi kitap = new DK_KitapBilgisi()
            {
                Kitap_Id = ID,
            };
            // Textboxları ve picturebox nesnelerini işlevlerini deaktif etme
            txt_KitapAdi.Enabled = false;
            txt_KitapYazar.Enabled = false;
            dateTime_BasimTarihi.Enabled = false;
            txt_KitapTuru.Enabled = false;
            txt_KitapSayfaSayisi.Enabled = false;

            pb_KitapEkle.Enabled = false;
            pb_KitapSil.Enabled = false;
            pb_KitapGnclle.Enabled = false;

            
            // DataGrid'e seçilen kitap ıd si ile kitabı alan ve iade eden kişileri görme işlemi
            dataGrid_Kitap.DataSource = IK_KitapAlanlar.IKKitapAlmaVeIadeListesi(kitap);

            //DataGrid sütun başlıklarını ayarlama
            dataGrid_Kitap.Columns[0].HeaderText = "Kitap ID";
            dataGrid_Kitap.Columns[0].Width = 50;
            dataGrid_Kitap.Columns[1].HeaderText = "Kitap Adı";
            dataGrid_Kitap.Columns[2].HeaderText = "Öğrenci Adı";
            dataGrid_Kitap.Columns[3].HeaderText = "Öğrenci Soyadı";
            dataGrid_Kitap.Columns[4].HeaderText = "Kitap Alinma Tarihi";
            dataGrid_Kitap.Columns[5].HeaderText = "Kitap Teslim Tarihi";
            dataGrid_Kitap.Columns[6].HeaderText = "Kitap Teslim Edilmiş Mi?";


        }

        private void pb_Istatistik_Click(object sender, EventArgs e)
        {

        }
    }
}
