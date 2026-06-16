using WinFormsApp1.Models;
using WinFormsApp1.Controllers;

namespace WinFormsApp1.Views.PembeliForm
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
            this.components = new System.ComponentModel.Container();
            this.pgGambar = new System.Windows.Forms.PictureBox();
            this.lblNamaKopi = new System.Windows.Forms.Label();
            this.lblHargaSekarang = new System.Windows.Forms.Label();
            this.lblBeratAtauGrade = new System.Windows.Forms.Label();
            this.lblTimerCountdown = new System.Windows.Forms.Label();
            this.nudNominalBid = new System.Windows.Forms.NumericUpDown();
            this.btnTempatkanBid = new System.Windows.Forms.Button();
            this.timerDetik = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pgGambar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNominalBid)).BeginInit();
            this.SuspendLayout();
            // 
            // pgGambar
            // 
            this.pgGambar.Location = new System.Drawing.Point(15, 15);
            this.pgGambar.Name = "pgGambar";
            this.pgGambar.Size = new System.Drawing.Size(267, 120);
            this.pgGambar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pgGambar.TabIndex = 0;
            this.pgGambar.TabStop = false;
            // 
            // lblNamaKopi
            // 
            this.lblNamaKopi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNamaKopi.Location = new System.Drawing.Point(15, 145);
            this.lblNamaKopi.Name = "lblNamaKopi";
            this.lblNamaKopi.Size = new System.Drawing.Size(267, 25);
            this.lblNamaKopi.TabIndex = 1;
            this.lblNamaKopi.Text = "Nama Produk Kopi";
            // 
            // lblHargaSekarang
            // 
            this.lblHargaSekarang.AutoSize = true;
            this.lblHargaSekarang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHargaSekarang.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblHargaSekarang.Location = new System.Drawing.Point(15, 175);
            this.lblHargaSekarang.Name = "lblHargaSekarang";
            this.lblHargaSekarang.Size = new System.Drawing.Size(121, 19);
            this.lblHargaSekarang.TabIndex = 2;
            this.lblHargaSekarang.Text = "Bid Tertinggi: Rp0";
            // 
            // lblBeratAtauGrade
            // 
            this.lblBeratAtauGrade.AutoSize = true;
            this.lblBeratAtauGrade.ForeColor = System.Drawing.Color.Gray;
            this.lblBeratAtauGrade.Location = new System.Drawing.Point(15, 200);
            this.lblBeratAtauGrade.Name = "lblBeratAtauGrade";
            this.lblBeratAtauGrade.Size = new System.Drawing.Size(103, 15);
            this.lblBeratAtauGrade.TabIndex = 3;
            this.lblBeratAtauGrade.Text = "Berat: 0 Kg | Grade: -";
            // 
            // lblTimerCountdown
            // 
            this.lblTimerCountdown.BackColor = System.Drawing.Color.MistyRose;
            this.lblTimerCountdown.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTimerCountdown.ForeColor = System.Drawing.Color.Red;
            this.lblTimerCountdown.Location = new System.Drawing.Point(15, 225);
            this.lblTimerCountdown.Name = "lblTimerCountdown";
            this.lblTimerCountdown.Size = new System.Drawing.Size(267, 23);
            this.lblTimerCountdown.TabIndex = 4;
            this.lblTimerCountdown.Text = "Sisa Waktu: 00:00:00";
            this.lblTimerCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudNominalBid
            // 
            this.nudNominalBid.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            this.nudNominalBid.Location = new System.Drawing.Point(15, 265);
            this.nudNominalBid.Maximum = new decimal(new int[] { 1410065407, 2, 0, 0 });
            this.nudNominalBid.Name = "nudNominalBid";
            this.nudNominalBid.Size = new System.Drawing.Size(160, 23);
            this.nudNominalBid.TabIndex = 5;
            this.nudNominalBid.ThousandsSeparator = true;
            // 
            // btnTempatkanBid
            // 
            this.btnTempatkanBid.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnTempatkanBid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTempatkanBid.ForeColor = System.Drawing.Color.White;
            this.btnTempatkanBid.Location = new System.Drawing.Point(182, 264);
            this.btnTempatkanBid.Name = "btnTempatkanBid";
            this.btnTempatkanBid.Size = new System.Drawing.Size(100, 25);
            this.btnTempatkanBid.TabIndex = 6;
            this.btnTempatkanBid.Text = "Tawar (Bid)";
            this.btnTempatkanBid.UseVisualStyleBackColor = false;
            this.btnTempatkanBid.Click += new System.EventHandler(this.btnTempatkanBid_Click);
            // 
            // timerDetik
            // 
            this.timerDetik.Interval = 1000;
            this.timerDetik.Tick += new System.EventHandler(this.timerDetik_Tick);
            // 
            // ProdukCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnTempatkanBid);
            this.Controls.Add(this.nudNominalBid);
            this.Controls.Add(this.lblTimerCountdown);
            this.Controls.Add(this.lblBeratAtauGrade);
            this.Controls.Add(this.lblHargaSekarang);
            this.Controls.Add(this.lblNamaKopi);
            this.Controls.Add(this.pgGambar);
            this.Name = "ProdukCard";
            this.Size = new System.Drawing.Size(295, 305);
            ((System.ComponentModel.ISupportInitialize)(this.pgGambar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNominalBid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
