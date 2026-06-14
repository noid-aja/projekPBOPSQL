namespace WinFormsApp1.Forms.AdminForm
{
    partial class FormLelang
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblJudul = new System.Windows.Forms.Label();
            lblPilihProduk = new System.Windows.Forms.Label();
            cmbProduk = new System.Windows.Forms.ComboBox();
            lblLokasi = new System.Windows.Forms.Label();
            tbLokasi = new System.Windows.Forms.TextBox();
            btnBukaLelang = new System.Windows.Forms.Button();
            btnTutupLelang = new System.Windows.Forms.Button();
            btnRefresh = new System.Windows.Forms.Button();
            lblDaftarLelang = new System.Windows.Forms.Label();
            dgvLelang = new System.Windows.Forms.DataGridView();
            panelAksi = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)dgvLelang).BeginInit();
            panelAksi.SuspendLayout();
            SuspendLayout();

            // lblJudul
            lblJudul.Text = "🔨 Kelola Lelang";
            lblJudul.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblJudul.Location = new System.Drawing.Point(12, 12);
            lblJudul.Size = new System.Drawing.Size(250, 30);

            // panelAksi
            panelAksi.Location = new System.Drawing.Point(12, 50);
            panelAksi.Size = new System.Drawing.Size(960, 60);
            panelAksi.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelAksi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // lblPilihProduk
            lblPilihProduk.Text = "Produk Siap Lelang:";
            lblPilihProduk.Location = new System.Drawing.Point(5, 20);
            lblPilihProduk.Size = new System.Drawing.Size(120, 23);
            lblPilihProduk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // cmbProduk
            cmbProduk.Location = new System.Drawing.Point(128, 18);
            cmbProduk.Size = new System.Drawing.Size(220, 23);
            cmbProduk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblLokasi
            lblLokasi.Text = "Lokasi:";
            lblLokasi.Location = new System.Drawing.Point(360, 20);
            lblLokasi.Size = new System.Drawing.Size(50, 23);
            lblLokasi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // tbLokasi
            tbLokasi.Location = new System.Drawing.Point(413, 18);
            tbLokasi.Size = new System.Drawing.Size(180, 23);
            tbLokasi.PlaceholderText = "Opsional...";

            // btnBukaLelang
            btnBukaLelang.Text = "✅ Buka Lelang";
            btnBukaLelang.Location = new System.Drawing.Point(600, 16);
            btnBukaLelang.Size = new System.Drawing.Size(130, 28);
            btnBukaLelang.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            btnBukaLelang.ForeColor = System.Drawing.Color.White;
            btnBukaLelang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBukaLelang.Click += btnBukaLelang_Click;

            // btnTutupLelang
            btnTutupLelang.Text = "❌ Tutup Lelang";
            btnTutupLelang.Location = new System.Drawing.Point(738, 16);
            btnTutupLelang.Size = new System.Drawing.Size(130, 28);
            btnTutupLelang.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            btnTutupLelang.ForeColor = System.Drawing.Color.White;
            btnTutupLelang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTutupLelang.Click += btnTutupLelang_Click;

            // btnRefresh
            btnRefresh.Text = "🔄";
            btnRefresh.Location = new System.Drawing.Point(876, 16);
            btnRefresh.Size = new System.Drawing.Size(50, 28);
            btnRefresh.Click += btnRefresh_Click;

            panelAksi.Controls.Add(lblPilihProduk);
            panelAksi.Controls.Add(cmbProduk);
            panelAksi.Controls.Add(lblLokasi);
            panelAksi.Controls.Add(tbLokasi);
            panelAksi.Controls.Add(btnBukaLelang);
            panelAksi.Controls.Add(btnTutupLelang);
            panelAksi.Controls.Add(btnRefresh);

            // lblDaftarLelang
            lblDaftarLelang.Text = "Daftar Lelang:";
            lblDaftarLelang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblDaftarLelang.Location = new System.Drawing.Point(12, 120);
            lblDaftarLelang.Size = new System.Drawing.Size(150, 20);

            // dgvLelang
            dgvLelang.Location = new System.Drawing.Point(12, 143);
            dgvLelang.Size = new System.Drawing.Size(960, 400);
            dgvLelang.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                             | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvLelang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dgvLelang.ReadOnly = true;
            dgvLelang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvLelang.AllowUserToAddRows = false;

            // FormLelang
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(984, 560);
            Controls.Add(lblJudul);
            Controls.Add(panelAksi);
            Controls.Add(lblDaftarLelang);
            Controls.Add(dgvLelang);
            Name = "FormLelang";
            Text = "Kelola Lelang";
            ((System.ComponentModel.ISupportInitialize)dgvLelang).EndInit();
            panelAksi.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblPilihProduk;
        private System.Windows.Forms.ComboBox cmbProduk;
        private System.Windows.Forms.Label lblLokasi;
        private System.Windows.Forms.TextBox tbLokasi;
        private System.Windows.Forms.Button btnBukaLelang;
        private System.Windows.Forms.Button btnTutupLelang;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblDaftarLelang;
        private System.Windows.Forms.DataGridView dgvLelang;
        private System.Windows.Forms.Panel panelAksi;
    }
}
