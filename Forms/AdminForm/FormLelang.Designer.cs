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
            lblJudul = new Label();
            lblPilihProduk = new Label();
            cmbProduk = new ComboBox();
            lblLokasi = new Label();
            tbLokasi = new TextBox();
            btnBukaLelang = new Button();
            btnTutupLelang = new Button();
            btnRefresh = new Button();
            lblDaftarLelang = new Label();
            dgvLelang = new DataGridView();
            btnLihatPeserta = new Button();
            panelAksi = new Panel();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvLelang).BeginInit();
            panelAksi.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblJudul.Location = new Point(16, 18);
            lblJudul.Margin = new Padding(4, 0, 4, 0);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(393, 56);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "🔨 Kelola Lelang";
            // 
            // lblPilihProduk
            // 
            lblPilihProduk.Font = new Font("Yu Gothic UI", 12F);
            lblPilihProduk.ForeColor = Color.White;
            lblPilihProduk.Location = new Point(8, 32);
            lblPilihProduk.Margin = new Padding(4, 0, 4, 0);
            lblPilihProduk.Name = "lblPilihProduk";
            lblPilihProduk.Size = new Size(188, 43);
            lblPilihProduk.TabIndex = 0;
            lblPilihProduk.Text = "Produk Siap Lelang:";
            lblPilihProduk.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbProduk
            // 
            cmbProduk.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduk.Location = new Point(201, 36);
            cmbProduk.Margin = new Padding(4, 6, 4, 6);
            cmbProduk.Name = "cmbProduk";
            cmbProduk.Size = new Size(344, 36);
            cmbProduk.TabIndex = 1;
            // 
            // lblLokasi
            // 
            lblLokasi.Font = new Font("Yu Gothic UI", 12F);
            lblLokasi.ForeColor = Color.White;
            lblLokasi.Location = new Point(565, 32);
            lblLokasi.Margin = new Padding(4, 0, 4, 0);
            lblLokasi.Name = "lblLokasi";
            lblLokasi.Size = new Size(78, 43);
            lblLokasi.TabIndex = 2;
            lblLokasi.Text = "Lokasi:";
            lblLokasi.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbLokasi
            // 
            tbLokasi.Location = new Point(649, 37);
            tbLokasi.Margin = new Padding(4, 6, 4, 6);
            tbLokasi.Name = "tbLokasi";
            tbLokasi.PlaceholderText = "Opsional...";
            tbLokasi.Size = new Size(280, 34);
            tbLokasi.TabIndex = 3;
            // 
            // btnBukaLelang
            // 
            btnBukaLelang.BackColor = Color.FromArgb(39, 174, 96);
            btnBukaLelang.FlatAppearance.BorderSize = 0;
            btnBukaLelang.FlatStyle = FlatStyle.Flat;
            btnBukaLelang.ForeColor = Color.White;
            btnBukaLelang.Location = new Point(943, 29);
            btnBukaLelang.Margin = new Padding(4, 6, 4, 6);
            btnBukaLelang.Name = "btnBukaLelang";
            btnBukaLelang.Size = new Size(205, 52);
            btnBukaLelang.TabIndex = 4;
            btnBukaLelang.Text = "✅ Buka Lelang";
            btnBukaLelang.UseVisualStyleBackColor = false;
            btnBukaLelang.Click += btnBukaLelang_Click;
            // 
            // btnTutupLelang
            // 
            btnTutupLelang.BackColor = Color.FromArgb(192, 57, 43);
            btnTutupLelang.FlatAppearance.BorderSize = 0;
            btnTutupLelang.FlatStyle = FlatStyle.Flat;
            btnTutupLelang.ForeColor = Color.White;
            btnTutupLelang.Location = new Point(1159, 29);
            btnTutupLelang.Margin = new Padding(4, 6, 4, 6);
            btnTutupLelang.Name = "btnTutupLelang";
            btnTutupLelang.Size = new Size(205, 52);
            btnTutupLelang.TabIndex = 5;
            btnTutupLelang.Text = "❌ Tutup Lelang";
            btnTutupLelang.UseVisualStyleBackColor = false;
            btnTutupLelang.Click += btnTutupLelang_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.White;
            btnRefresh.ForeColor = Color.Black;
            btnRefresh.Location = new Point(1376, 29);
            btnRefresh.Margin = new Padding(4, 6, 4, 6);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(78, 52);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "🔄";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblDaftarLelang
            // 
            lblDaftarLelang.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDaftarLelang.Location = new Point(19, 224);
            lblDaftarLelang.Margin = new Padding(4, 0, 4, 0);
            lblDaftarLelang.Name = "lblDaftarLelang";
            lblDaftarLelang.Size = new Size(235, 38);
            lblDaftarLelang.TabIndex = 2;
            lblDaftarLelang.Text = "Daftar Lelang:";
            // 
            // btnLihatPeserta
            // 
            btnLihatPeserta.BackColor = Color.FromArgb(41, 128, 185);
            btnLihatPeserta.FlatAppearance.BorderSize = 0;
            btnLihatPeserta.FlatStyle = FlatStyle.Flat;
            btnLihatPeserta.ForeColor = Color.White;
            btnLihatPeserta.Location = new Point(280, 215);
            btnLihatPeserta.Margin = new Padding(4, 6, 4, 6);
            btnLihatPeserta.Name = "btnLihatPeserta";
            btnLihatPeserta.Size = new Size(180, 38);
            btnLihatPeserta.TabIndex = 7;
            btnLihatPeserta.Text = "👥 Lihat Peserta";
            btnLihatPeserta.UseVisualStyleBackColor = false;
            btnLihatPeserta.Click += btnLihatPeserta_Click;
            // 
            // dgvLelang
            // 
            dgvLelang.AllowUserToAddRows = false;
            dgvLelang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLelang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvLelang.ColumnHeadersHeight = 29;
            dgvLelang.Location = new Point(19, 261);
            dgvLelang.Margin = new Padding(4, 6, 4, 6);
            dgvLelang.Name = "dgvLelang";
            dgvLelang.ReadOnly = true;
            dgvLelang.RowHeadersWidth = 51;
            dgvLelang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLelang.Size = new Size(1508, 746);
            dgvLelang.TabIndex = 3;
            // 
            // panelAksi
            // 
            panelAksi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelAksi.BackColor = Color.FromArgb(17, 37, 0);
            panelAksi.BorderStyle = BorderStyle.FixedSingle;
            panelAksi.Controls.Add(lblPilihProduk);
            panelAksi.Controls.Add(cmbProduk);
            panelAksi.Controls.Add(lblLokasi);
            panelAksi.Controls.Add(tbLokasi);
            panelAksi.Controls.Add(btnBukaLelang);
            panelAksi.Controls.Add(btnTutupLelang);
            panelAksi.Controls.Add(btnRefresh);
            panelAksi.ForeColor = Color.White;
            panelAksi.Location = new Point(3, 69);
            panelAksi.Margin = new Padding(4, 6, 4, 6);
            panelAksi.Name = "panelAksi";
            panelAksi.Size = new Size(1531, 114);
            panelAksi.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(232, 255, 214);
            panel2.Controls.Add(lblJudul);
            panel2.Location = new Point(3, 0);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1551, 70);
            panel2.TabIndex = 9;
            // 
            // FormLelang
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1547, 1046);
            Controls.Add(panelAksi);
            Controls.Add(btnLihatPeserta);
            Controls.Add(lblDaftarLelang);
            Controls.Add(dgvLelang);
            Controls.Add(panel2);
            Font = new Font("Yu Gothic UI", 12F);
            Margin = new Padding(4, 6, 4, 6);
            Name = "FormLelang";
            Text = "Kelola Lelang";
            ((System.ComponentModel.ISupportInitialize)dgvLelang).EndInit();
            panelAksi.ResumeLayout(false);
            panelAksi.PerformLayout();
            panel2.ResumeLayout(false);
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
        private Panel panel2;
        private System.Windows.Forms.Button btnLihatPeserta;
    }
}
