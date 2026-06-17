using WinFormsApp1.Models;
using WinFormsApp1.Controllers;

namespace WinFormsApp1.Views.PembeliView
{
    partial class ProdukCard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pgGambar = new PictureBox();
            lblNamaKopi = new Label();
            lblHargaSekarang = new Label();
            lblBeratAtauGrade = new Label();
            lblTimerCountdown = new Label();
            nudNominalBid = new NumericUpDown();
            btnTempatkanBid = new Button();
            timerDetik = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pgGambar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNominalBid).BeginInit();
            SuspendLayout();
            // 
            // pgGambar
            // 
            pgGambar.BackgroundImageLayout = ImageLayout.Stretch;
            pgGambar.Image = Properties.Resources.coffee_placeholder1;
            pgGambar.Location = new Point(28, 32);
            pgGambar.Margin = new Padding(6);
            pgGambar.Name = "pgGambar";
            pgGambar.Size = new Size(496, 256);
            pgGambar.SizeMode = PictureBoxSizeMode.StretchImage;
            pgGambar.TabIndex = 0;
            pgGambar.TabStop = false;
            pgGambar.Click += pgGambar_Click;
            // 
            // lblNamaKopi
            // 
            lblNamaKopi.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNamaKopi.Location = new Point(28, 309);
            lblNamaKopi.Margin = new Padding(6, 0, 6, 0);
            lblNamaKopi.Name = "lblNamaKopi";
            lblNamaKopi.Size = new Size(496, 53);
            lblNamaKopi.TabIndex = 1;
            lblNamaKopi.Text = "Nama Produk Kopi";
            // 
            // lblHargaSekarang
            // 
            lblHargaSekarang.AutoSize = true;
            lblHargaSekarang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHargaSekarang.ForeColor = Color.DarkGoldenrod;
            lblHargaSekarang.Location = new Point(28, 373);
            lblHargaSekarang.Margin = new Padding(6, 0, 6, 0);
            lblHargaSekarang.Name = "lblHargaSekarang";
            lblHargaSekarang.Size = new Size(249, 37);
            lblHargaSekarang.TabIndex = 2;
            lblHargaSekarang.Text = "Bid Tertinggi: Rp0";
            // 
            // lblBeratAtauGrade
            // 
            lblBeratAtauGrade.AutoSize = true;
            lblBeratAtauGrade.ForeColor = Color.Gray;
            lblBeratAtauGrade.Location = new Point(28, 427);
            lblBeratAtauGrade.Margin = new Padding(6, 0, 6, 0);
            lblBeratAtauGrade.Name = "lblBeratAtauGrade";
            lblBeratAtauGrade.Size = new Size(234, 32);
            lblBeratAtauGrade.TabIndex = 3;
            lblBeratAtauGrade.Text = "Berat: 0 Kg | Grade: -";
            // 
            // lblTimerCountdown
            // 
            lblTimerCountdown.BackColor = Color.MistyRose;
            lblTimerCountdown.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTimerCountdown.ForeColor = Color.Red;
            lblTimerCountdown.Location = new Point(28, 480);
            lblTimerCountdown.Margin = new Padding(6, 0, 6, 0);
            lblTimerCountdown.Name = "lblTimerCountdown";
            lblTimerCountdown.Size = new Size(496, 49);
            lblTimerCountdown.TabIndex = 4;
            lblTimerCountdown.Text = "Sisa Waktu: 00:00:00";
            lblTimerCountdown.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nudNominalBid
            // 
            nudNominalBid.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            nudNominalBid.Location = new Point(28, 565);
            nudNominalBid.Margin = new Padding(6);
            nudNominalBid.Maximum = new decimal(new int[] { 1410065407, 2, 0, 0 });
            nudNominalBid.Name = "nudNominalBid";
            nudNominalBid.Size = new Size(297, 39);
            nudNominalBid.TabIndex = 5;
            nudNominalBid.ThousandsSeparator = true;
            // 
            // btnTempatkanBid
            // 
            btnTempatkanBid.BackColor = Color.SaddleBrown;
            btnTempatkanBid.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTempatkanBid.ForeColor = Color.White;
            btnTempatkanBid.Location = new Point(338, 563);
            btnTempatkanBid.Margin = new Padding(6);
            btnTempatkanBid.Name = "btnTempatkanBid";
            btnTempatkanBid.Size = new Size(186, 53);
            btnTempatkanBid.TabIndex = 6;
            btnTempatkanBid.Text = "Tawar (Bid)";
            btnTempatkanBid.UseVisualStyleBackColor = false;
            btnTempatkanBid.Click += btnTempatkanBid_Click;
            // 
            // timerDetik
            // 
            timerDetik.Interval = 1000;
            timerDetik.Tick += timerDetik_Tick;
            // 
            // ProdukCard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btnTempatkanBid);
            Controls.Add(nudNominalBid);
            Controls.Add(lblTimerCountdown);
            Controls.Add(lblBeratAtauGrade);
            Controls.Add(lblHargaSekarang);
            Controls.Add(lblNamaKopi);
            Controls.Add(pgGambar);
            Margin = new Padding(6);
            Name = "ProdukCard";
            Size = new Size(548, 651);
            ((System.ComponentModel.ISupportInitialize)pgGambar).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNominalBid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.PictureBox pgGambar;
        private System.Windows.Forms.Label lblNamaKopi;
        private System.Windows.Forms.Label lblHargaSekarang;
        private System.Windows.Forms.Label lblBeratAtauGrade;
        private System.Windows.Forms.Label lblTimerCountdown;
        private System.Windows.Forms.NumericUpDown nudNominalBid;
        private System.Windows.Forms.Button btnTempatkanBid;
        private System.Windows.Forms.Timer timerDetik;
    }
}
