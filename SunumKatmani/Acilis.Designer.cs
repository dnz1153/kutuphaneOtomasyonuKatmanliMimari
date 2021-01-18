
namespace SunumKatmani
{
    partial class Acilis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Acilis));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar_Acilis = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_bekleme = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.BarTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.progressBar_Acilis, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_bekleme, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1066, 674);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // progressBar_Acilis
            // 
            this.progressBar_Acilis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar_Acilis.Location = new System.Drawing.Point(238, 542);
            this.progressBar_Acilis.Name = "progressBar_Acilis";
            this.progressBar_Acilis.Size = new System.Drawing.Size(589, 37);
            this.progressBar_Acilis.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(270, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(526, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kütüphane Programına Hoşgeldiniz.";
            // 
            // lbl_bekleme
            // 
            this.lbl_bekleme.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_bekleme.BackColor = System.Drawing.Color.Transparent;
            this.lbl_bekleme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_bekleme.ForeColor = System.Drawing.Color.White;
            this.lbl_bekleme.Location = new System.Drawing.Point(134, 417);
            this.lbl_bekleme.Name = "lbl_bekleme";
            this.lbl_bekleme.Size = new System.Drawing.Size(798, 31);
            this.lbl_bekleme.TabIndex = 1;
            this.lbl_bekleme.Text = "Program Yükeleniyor Lütfen Bekleyin";
            this.lbl_bekleme.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // BarTimer
            // 
            this.BarTimer.Tick += new System.EventHandler(this.BarTimer_Tick);
            // 
            // Acilis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1062, 673);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Acilis";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acilis";
            this.Load += new System.EventHandler(this.Acilis_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ProgressBar progressBar_Acilis;
        private System.Windows.Forms.Label lbl_bekleme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Timer BarTimer;
    }
}