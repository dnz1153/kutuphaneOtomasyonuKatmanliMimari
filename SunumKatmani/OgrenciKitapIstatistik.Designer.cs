
namespace SunumKatmani
{
    partial class OgrenciKitapIstatistik
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OgrenciKitapIstatistik));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pb_Geri = new System.Windows.Forms.PictureBox();
            this.pb_Cikis = new System.Windows.Forms.PictureBox();
            this.Ogr_Id = new System.Windows.Forms.Label();
            this.zedGraph = new ZedGraph.ZedGraphControl();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Geri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Cikis)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.81359F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.18641F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.Controls.Add(this.pb_Geri, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pb_Cikis, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.Ogr_Id, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.zedGraph, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.974359F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.02564F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1064, 674);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pb_Geri
            // 
            this.pb_Geri.Image = ((System.Drawing.Image)(resources.GetObject("pb_Geri.Image")));
            this.pb_Geri.Location = new System.Drawing.Point(3, 3);
            this.pb_Geri.Name = "pb_Geri";
            this.pb_Geri.Size = new System.Drawing.Size(97, 49);
            this.pb_Geri.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Geri.TabIndex = 0;
            this.pb_Geri.TabStop = false;
            this.pb_Geri.Click += new System.EventHandler(this.pb_Geri_Click);
            // 
            // pb_Cikis
            // 
            this.pb_Cikis.Image = ((System.Drawing.Image)(resources.GetObject("pb_Cikis.Image")));
            this.pb_Cikis.Location = new System.Drawing.Point(960, 621);
            this.pb_Cikis.Name = "pb_Cikis";
            this.pb_Cikis.Size = new System.Drawing.Size(100, 49);
            this.pb_Cikis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Cikis.TabIndex = 1;
            this.pb_Cikis.TabStop = false;
            this.pb_Cikis.Click += new System.EventHandler(this.pb_Cikis_Click);
            // 
            // Ogr_Id
            // 
            this.Ogr_Id.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Ogr_Id.AutoSize = true;
            this.Ogr_Id.BackColor = System.Drawing.Color.Black;
            this.Ogr_Id.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Ogr_Id.ForeColor = System.Drawing.Color.White;
            this.Ogr_Id.Location = new System.Drawing.Point(1010, 0);
            this.Ogr_Id.Name = "Ogr_Id";
            this.Ogr_Id.Size = new System.Drawing.Size(0, 18);
            this.Ogr_Id.TabIndex = 5;
            // 
            // zedGraph
            // 
            this.zedGraph.Location = new System.Drawing.Point(107, 59);
            this.zedGraph.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraph.Name = "zedGraph";
            this.zedGraph.ScrollGrace = 0D;
            this.zedGraph.ScrollMaxX = 0D;
            this.zedGraph.ScrollMaxY = 0D;
            this.zedGraph.ScrollMaxY2 = 0D;
            this.zedGraph.ScrollMinX = 0D;
            this.zedGraph.ScrollMinY = 0D;
            this.zedGraph.ScrollMinY2 = 0D;
            this.zedGraph.Size = new System.Drawing.Size(846, 555);
            this.zedGraph.TabIndex = 6;
            // 
            // OgrenciKitapIstatistik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1062, 673);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OgrenciKitapIstatistik";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OgrenciKitapIstatistik";
            this.Load += new System.EventHandler(this.OgrenciKitapIstatistik_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Geri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Cikis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pb_Geri;
        private System.Windows.Forms.PictureBox pb_Cikis;
        public System.Windows.Forms.Label Ogr_Id;
        private System.Windows.Forms.ToolTip toolTip1;
        private ZedGraph.ZedGraphControl zedGraph;
    }
}