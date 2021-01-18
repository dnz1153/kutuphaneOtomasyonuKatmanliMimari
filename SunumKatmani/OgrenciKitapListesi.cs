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
    public partial class OgrenciKitapListesi : Form
    {
        public OgrenciKitapListesi()
        {
            InitializeComponent();
        }
        private void OgrenciListeGuncelle()
        {
            // Öğrenci Id tanımlanan değişken katmanına atanır.
            DK_KitapAlanlar kitap = new DK_KitapAlanlar()
            {
                Ogrenci_Id = int.Parse(Ogr_Id.Text)
            };
            // Öğrencinin aldıgı ve teslim ettiği kitapları döndürür.
            dataGrid_Liste.DataSource = IK_KitapAlanlar.IKOgrenciTabloListeDoldur(kitap);

            // Datagrid'in Sütun başlıkları olusturuldu.
            dataGrid_Liste.Columns[0].HeaderText = "ID";
            dataGrid_Liste.Columns[1].HeaderText = "Kitap ID";
            dataGrid_Liste.Columns[2].HeaderText = "Kitap Adı";
            dataGrid_Liste.Columns[3].HeaderText = "Kitap Alınma Tarihi";
            dataGrid_Liste.Columns[4].HeaderText = "Kitap Teslim Tarihi";
            dataGrid_Liste.Columns[5].HeaderText = "Teslim Edilmiş Mi?";
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

        private void OgrenciKitapListesi_Load(object sender, EventArgs e)
        {
            //Olusturulan Nesneler İçin Sayfa Acılırken Acıklamalar Olusturuldu.
            toolTip1.SetToolTip(pb_Geri, "Geri");
            toolTip1.SetToolTip(pb_Cikis, "Çıkış");
            OgrenciListeGuncelle();

            TabloRenklendirme();
            GC.Collect();

        }
        private void TabloRenklendirme()
        {
               // Renklendirme işlemi yapmak için tablonun satırları for ile gezilir
               for (int i = 0; i < dataGrid_Liste.Rows.Count; i++)
                {
                        // DataGridViewCellStyle bir nesne oluşturulur.BackColor vermek için
                        DataGridViewCellStyle color = new DataGridViewCellStyle();

                    // Eger kitap teslim edilmiş ise kitap arkaplan rengi yeşil yazı rengi beyaz olur.(Görünmesi için)
                    if (Convert.ToBoolean(dataGrid_Liste.Rows[i].Cells[5].Value) == true)
                    {
                        color.BackColor = Color.Green;
                        color.ForeColor = Color.White;
                    }

                    else//Eğer Teslim edilmemiş ise şimdiki zamandan listede alınma tarihi çıkarılarak bir sonuc elde edilir
                    {
                        TimeSpan sonuc = DateTime.Now - Convert.ToDateTime(dataGrid_Liste.Rows[i].Cells[3].Value);
                        //Çıkan sonuc eger 15 ten büyükse bu kitabın teslim tarihinin geçtiği satır rengini kırmızıya boyanarak belli edilir.
                        if (sonuc.TotalDays > 15)
                        {
                            color.BackColor = Color.Red;
                        }
                        //Çıkan sonuc eger 13 ve 15 arasında ise kitabın teslim tarihinin yaklaştığı bildirmek amacıyla sarı renge boyanır.
                        if (sonuc.TotalDays >= 13 && sonuc.TotalDays <= 15)
                        {
                            color.BackColor = Color.Yellow;
                        }
                    }
                dataGrid_Liste.Rows[i].DefaultCellStyle = color;
                }
            }
        }
    }
