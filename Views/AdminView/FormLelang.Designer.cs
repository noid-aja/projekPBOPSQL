namespace WinFormsApp1.Views.AdminView
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
            lblFilterStatus = new Label();
            cmbFilterStatus = new ComboBox();
            btnBukaLelang = new Button();
            btnTutupLelang = new Button();
            btnRefresh = new Button();
            lblDaftarLelang = new Label();
            dgvLelang = new DataGridView();
            btnLihatPeserta = new Button();
            panelAksi = new Panel();
            lblStatusBuka = new Label();
            cmbStatusBuka = new ComboBox();
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
            lblPilihProduk.Location = new Point(15, 35);
            lblPilihProduk.Margin = new Padding(4, 0, 4, 0);
            lblPilihProduk.Name = "lblPilihProduk";
            lblPilihProduk.Size = new Size(318, 43);
            lblPilihProduk.TabIndex = 0;
            lblPilihProduk.Text = "Produk Siap Lelang:";
            lblPilihProduk.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbProduk
            // 
            cmbProduk.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduk.Location = new Point(334, 36);
            cmbProduk.Margin = new Padding(4, 6, 4, 6);
            cmbProduk.Name = "cmbProduk";
            cmbProduk.Size = new Size(419, 53);
            cmbProduk.TabIndex = 1;
            // 
            // lblFilterStatus
            // 
            lblFilterStatus.Font = new Font("Yu Gothic UI", 12F);
            lblFilterStatus.ForeColor = Color.White;
            lblFilterStatus.Location = new Point(15, 111);
            lblFilterStatus.Margin = new Padding(4, 0, 4, 0);
            lblFilterStatus.Name = "lblFilterStatus";
            lblFilterStatus.Size = new Size(318, 43);
            lblFilterStatus.TabIndex = 2;
            lblFilterStatus.Text = "Filter Status Lelang:";
            lblFilterStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbFilterStatus
            // 
            cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStatus.Location = new Point(334, 111);
            cmbFilterStatus.Margin = new Padding(4, 6, 4, 6);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(419, 53);
            cmbFilterStatus.TabIndex = 3;
            cmbFilterStatus.SelectedIndexChanged += cmbFilterStatus_SelectedIndexChanged;
            // 
            // btnBukaLelang
            // 
            btnBukaLelang.BackColor = Color.FromArgb(39, 174, 96);
            btnBukaLelang.FlatAppearance.BorderSize = 0;
            btnBukaLelang.FlatStyle = FlatStyle.Flat;
            btnBukaLelang.ForeColor = Color.White;
            btnBukaLelang.Location = new Point(1210, 37);
            btnBukaLelang.Margin = new Padding(4, 6, 4, 6);
            btnBukaLelang.Name = "btnBukaLelang";
            btnBukaLelang.Size = new Size(220, 52);
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
            btnTutupLelang.Location = new Point(1210, 106);
            btnTutupLelang.Margin = new Padding(4, 6, 4, 6);
            btnTutupLelang.Name = "btnTutupLelang";
            btnTutupLelang.Size = new Size(220, 52);
            btnTutupLelang.TabIndex = 5;
            btnTutupLelang.Text = "❌ Tutup Lelang";
            btnTutupLelang.UseVisualStyleBackColor = false;
            btnTutupLelang.Click += btnTutupLelang_Click;
            // 
            // lblStatusBuka
            // 
            lblStatusBuka.Font = new Font("Yu Gothic UI", 12F);
            lblStatusBuka.ForeColor = Color.White;
            lblStatusBuka.Location = new Point(780, 35);
            lblStatusBuka.Margin = new Padding(4, 0, 4, 0);
            lblStatusBuka.Name = "lblStatusBuka";
            lblStatusBuka.Size = new Size(180, 43);
            lblStatusBuka.TabIndex = 8;
            lblStatusBuka.Text = "Status Awal:";
            lblStatusBuka.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbStatusBuka
            // 
            cmbStatusBuka.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusBuka.Location = new Point(970, 36);
            cmbStatusBuka.Margin = new Padding(4, 6, 4, 6);
            cmbStatusBuka.Name = "cmbStatusBuka";
            cmbStatusBuka.Size = new Size(220, 53);
            cmbStatusBuka.TabIndex = 9;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.White;
            btnRefresh.ForeColor = Color.Black;
            btnRefresh.Location = new Point(1619, 35);
            btnRefresh.Margin = new Padding(4, 6, 4, 6);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(224, 65);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "🔄Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblDaftarLelang
            // 
            lblDaftarLelang.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDaftarLelang.Location = new Point(13, 296);
            lblDaftarLelang.Margin = new Padding(4, 0, 4, 0);
            lblDaftarLelang.Name = "lblDaftarLelang";
            lblDaftarLelang.Size = new Size(235, 38);
            lblDaftarLelang.TabIndex = 2;
            lblDaftarLelang.Text = "Daftar Lelang:";
            // 
            // dgvLelang
            // 
            dgvLelang.AllowUserToAddRows = false;
            dgvLelang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLelang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvLelang.ColumnHeadersHeight = 29;
            dgvLelang.Location = new Point(19, 340);
            dgvLelang.Margin = new Padding(4, 6, 4, 6);
            dgvLelang.Name = "dgvLelang";
            dgvLelang.ReadOnly = true;
            dgvLelang.RowHeadersWidth = 51;
            dgvLelang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLelang.Size = new Size(1842, 667);
            dgvLelang.TabIndex = 3;
            // 
            // btnLihatPeserta
            // 
            btnLihatPeserta.BackColor = Color.FromArgb(41, 128, 185);
            btnLihatPeserta.FlatAppearance.BorderSize = 0;
            btnLihatPeserta.FlatStyle = FlatStyle.Flat;
            btnLihatPeserta.ForeColor = Color.White;
            btnLihatPeserta.Location = new Point(1450, 35);
            btnLihatPeserta.Margin = new Padding(4, 6, 4, 6);
            btnLihatPeserta.Name = "btnLihatPeserta";
            btnLihatPeserta.Size = new Size(160, 123);
            btnLihatPeserta.TabIndex = 7;
            btnLihatPeserta.Text = "👥 Lihat Peserta";
            btnLihatPeserta.UseVisualStyleBackColor = false;
            btnLihatPeserta.Click += btnLihatPeserta_Click;
            // 
            // panelAksi
            // 
            panelAksi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelAksi.BackColor = Color.FromArgb(17, 37, 0);
            panelAksi.BorderStyle = BorderStyle.FixedSingle;
            panelAksi.Controls.Add(lblPilihProduk);
            panelAksi.Controls.Add(btnLihatPeserta);
            panelAksi.Controls.Add(cmbProduk);
            panelAksi.Controls.Add(lblFilterStatus);
            panelAksi.Controls.Add(cmbFilterStatus);
            panelAksi.Controls.Add(btnBukaLelang);
            panelAksi.Controls.Add(btnTutupLelang);
            panelAksi.Controls.Add(btnRefresh);
            panelAksi.Controls.Add(lblStatusBuka);
            panelAksi.Controls.Add(cmbStatusBuka);
            panelAksi.ForeColor = Color.White;
            panelAksi.Location = new Point(3, 96);
            panelAksi.Margin = new Padding(4, 6, 4, 6);
            panelAksi.Name = "panelAksi";
            panelAksi.Size = new Size(1865, 194);
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
            panel2.Size = new Size(1885, 100);
            panel2.TabIndex = 9;
            // 
            // FormLelang
            // 
            AutoScaleDimensions = new SizeF(18F, 45F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1881, 1046);
            Controls.Add(panelAksi);
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
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.Button btnBukaLelang;
        private System.Windows.Forms.Button btnTutupLelang;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblDaftarLelang;
        private System.Windows.Forms.DataGridView dgvLelang;
        private System.Windows.Forms.Panel panelAksi;
        private Panel panel2;
        private System.Windows.Forms.Button btnLihatPeserta;
        private System.Windows.Forms.Label lblStatusBuka;
        private System.Windows.Forms.ComboBox cmbStatusBuka;
    }
}
