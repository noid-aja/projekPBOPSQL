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
            this.pgGambar = new System.Windows.Forms.PictureBox();
            this.lblNamaKopi = new System.Windows.Forms.Label();
            this.lblPetani = new System.Windows.Forms.Label();
            this.lblJenis = new System.Windows.Forms.Label();
            this.lblHargaPengajuan = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnUbahStatus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pgGambar)).BeginInit();
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
            this.lblNamaKopi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblNamaKopi.Location = new System.Drawing.Point(15, 145);
            this.lblNamaKopi.Name = "lblNamaKopi";
            this.lblNamaKopi.Size = new System.Drawing.Size(267, 25);
            this.lblNamaKopi.TabIndex = 1;
            this.lblNamaKopi.Text = "Nama Produk Kopi";
            // 
            // lblPetani
            // 
            this.lblPetani.AutoSize = true;
            this.lblPetani.ForeColor = System.Drawing.Color.DimGray;
            this.lblPetani.Location = new System.Drawing.Point(15, 175);
            this.lblPetani.Name = "lblPetani";
            this.lblPetani.Size = new System.Drawing.Size(43, 15);
            this.lblPetani.TabIndex = 2;
            this.lblPetani.Text = "Petani: -";
            // 
            // lblJenis
            // 
            this.lblJenis.AutoSize = true;
            this.lblJenis.ForeColor = System.Drawing.Color.DimGray;
            this.lblJenis.Location = new System.Drawing.Point(15, 195);
            this.lblJenis.Name = "lblJenis";
            this.lblJenis.Size = new System.Drawing.Size(35, 15);
            this.lblJenis.TabIndex = 3;
            this.lblJenis.Text = "Jenis: -";
            // 
            // lblHargaPengajuan
            // 
            this.lblHargaPengajuan.AutoSize = true;
            this.lblHargaPengajuan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHargaPengajuan.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblHargaPengajuan.Location = new System.Drawing.Point(15, 215);
            this.lblHargaPengajuan.Name = "lblHargaPengajuan";
            this.lblHargaPengajuan.Size = new System.Drawing.Size(125, 15);
            this.lblHargaPengajuan.TabIndex = 4;
            this.lblHargaPengajuan.Text = "Harga Pengajuan: Rp0";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.LightGray;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(15, 238);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(267, 23);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "STATUS";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUbahStatus
            // 
            this.btnUbahStatus.BackColor = System.Drawing.Color.FromArgb(17, 37, 0);
            this.btnUbahStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUbahStatus.ForeColor = System.Drawing.Color.White;
            this.btnUbahStatus.Location = new System.Drawing.Point(15, 269);
            this.btnUbahStatus.Name = "btnUbahStatus";
            this.btnUbahStatus.Size = new System.Drawing.Size(267, 30);
            this.btnUbahStatus.TabIndex = 6;
            this.btnUbahStatus.Text = "Ubah Status QC";
            this.btnUbahStatus.UseVisualStyleBackColor = false;
            this.btnUbahStatus.Click += new System.EventHandler(this.btnUbahStatus_Click);
            // 
            // ProdukCardAdminInspektor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnUbahStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblHargaPengajuan);
            this.Controls.Add(this.lblJenis);
            this.Controls.Add(this.lblPetani);
            this.Controls.Add(this.lblNamaKopi);
            this.Controls.Add(this.pgGambar);
            this.Name = "ProdukCardAdminInspektor";
            this.Size = new System.Drawing.Size(295, 312);
            ((System.ComponentModel.ISupportInitialize)(this.pgGambar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
