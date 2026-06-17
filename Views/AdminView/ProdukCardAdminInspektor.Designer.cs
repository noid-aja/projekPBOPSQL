namespace WinFormsApp1.Views.AdminView
{
    partial class ProdukCardAdminInspektor
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
            pgGambar = new PictureBox();
            lblNamaKopi = new Label();
            lblPetani = new Label();
            lblJenis = new Label();
            lblHargaPengajuan = new Label();
            lblStatus = new Label();
            btnUbahStatus = new Button();
            ((System.ComponentModel.ISupportInitialize)pgGambar).BeginInit();
            SuspendLayout();
            // 
            // pgGambar
            // 
            pgGambar.BackgroundImageLayout = ImageLayout.Stretch;
            pgGambar.Image = Properties.Resources.coffee_placeholder;
            pgGambar.Location = new Point(28, 32);
            pgGambar.Margin = new Padding(6, 6, 6, 6);
            pgGambar.Name = "pgGambar";
            pgGambar.Size = new Size(496, 256);
            pgGambar.SizeMode = PictureBoxSizeMode.StretchImage;
            pgGambar.TabIndex = 0;
            pgGambar.TabStop = false;
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
            // lblPetani
            // 
            lblPetani.AutoSize = true;
            lblPetani.ForeColor = Color.DimGray;
            lblPetani.Location = new Point(28, 373);
            lblPetani.Margin = new Padding(6, 0, 6, 0);
            lblPetani.Name = "lblPetani";
            lblPetani.Size = new Size(101, 32);
            lblPetani.TabIndex = 2;
            lblPetani.Text = "Petani: -";
            // 
            // lblJenis
            // 
            lblJenis.AutoSize = true;
            lblJenis.ForeColor = Color.DimGray;
            lblJenis.Location = new Point(28, 416);
            lblJenis.Margin = new Padding(6, 0, 6, 0);
            lblJenis.Name = "lblJenis";
            lblJenis.Size = new Size(88, 32);
            lblJenis.TabIndex = 3;
            lblJenis.Text = "Jenis: -";
            // 
            // lblHargaPengajuan
            // 
            lblHargaPengajuan.AutoSize = true;
            lblHargaPengajuan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHargaPengajuan.ForeColor = Color.DarkGoldenrod;
            lblHargaPengajuan.Location = new Point(28, 459);
            lblHargaPengajuan.Margin = new Padding(6, 0, 6, 0);
            lblHargaPengajuan.Name = "lblHargaPengajuan";
            lblHargaPengajuan.Size = new Size(269, 32);
            lblHargaPengajuan.TabIndex = 4;
            lblHargaPengajuan.Text = "Harga Pengajuan: Rp0";
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.LightGray;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.Location = new Point(28, 508);
            lblStatus.Margin = new Padding(6, 0, 6, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(496, 49);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "STATUS";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnUbahStatus
            // 
            btnUbahStatus.BackColor = Color.FromArgb(17, 37, 0);
            btnUbahStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUbahStatus.ForeColor = Color.White;
            btnUbahStatus.Location = new Point(28, 574);
            btnUbahStatus.Margin = new Padding(6, 6, 6, 6);
            btnUbahStatus.Name = "btnUbahStatus";
            btnUbahStatus.Size = new Size(496, 64);
            btnUbahStatus.TabIndex = 6;
            btnUbahStatus.Text = "Ubah Status QC";
            btnUbahStatus.UseVisualStyleBackColor = false;
            btnUbahStatus.Click += btnUbahStatus_Click;
            // 
            // ProdukCardAdminInspektor
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btnUbahStatus);
            Controls.Add(lblStatus);
            Controls.Add(lblHargaPengajuan);
            Controls.Add(lblJenis);
            Controls.Add(lblPetani);
            Controls.Add(lblNamaKopi);
            Controls.Add(pgGambar);
            Margin = new Padding(6, 6, 6, 6);
            Name = "ProdukCardAdminInspektor";
            Size = new Size(548, 666);
            ((System.ComponentModel.ISupportInitialize)pgGambar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.PictureBox pgGambar;
        private System.Windows.Forms.Label lblNamaKopi;
        private System.Windows.Forms.Label lblPetani;
        private System.Windows.Forms.Label lblJenis;
        private System.Windows.Forms.Label lblHargaPengajuan;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnUbahStatus;
    }
}
