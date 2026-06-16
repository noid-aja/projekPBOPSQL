namespace WinFormsApp1.Views.PetaniForm
{
    partial class FormInputProduk
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
            lblNama = new Label();
            tbNamaProduk = new TextBox();
            lblJenis = new Label();
            cmbJenis = new ComboBox();
            lblBerat = new Label();
            tbBerat = new TextBox();
            lblHarga = new Label();
            tbHarga = new TextBox();
            lblDeskripsi = new Label();
            tbDeskripsi = new TextBox();
            btnSubmit = new Button();
            btnBatal = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblJudul.Location = new Point(23, 26);
            lblJudul.Margin = new Padding(5, 0, 5, 0);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(650, 64);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "🌱 Input Produk Kopi Baru";
            lblJudul.Click += lblJudul_Click;
            // 
            // lblNama
            // 
            lblNama.Font = new Font("Yu Gothic UI", 12F);
            lblNama.Location = new Point(55, 149);
            lblNama.Margin = new Padding(5, 0, 5, 0);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(223, 50);
            lblNama.TabIndex = 1;
            lblNama.Text = "Nama Produk:";
            lblNama.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbNamaProduk
            // 
            tbNamaProduk.Location = new Point(297, 163);
            tbNamaProduk.Margin = new Padding(5, 6, 5, 6);
            tbNamaProduk.Name = "tbNamaProduk";
            tbNamaProduk.PlaceholderText = "Contoh: Kopi Arabika Premium";
            tbNamaProduk.Size = new Size(516, 39);
            tbNamaProduk.TabIndex = 2;
            tbNamaProduk.TextChanged += tbNamaProduk_TextChanged;
            // 
            // lblJenis
            // 
            lblJenis.Font = new Font("Yu Gothic UI", 12F);
            lblJenis.Location = new Point(55, 224);
            lblJenis.Margin = new Padding(5, 0, 5, 0);
            lblJenis.Name = "lblJenis";
            lblJenis.Size = new Size(223, 50);
            lblJenis.TabIndex = 3;
            lblJenis.Text = "Jenis Kopi:";
            lblJenis.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbJenis
            // 
            cmbJenis.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJenis.Location = new Point(297, 236);
            cmbJenis.Margin = new Padding(5, 6, 5, 6);
            cmbJenis.Name = "cmbJenis";
            cmbJenis.Size = new Size(516, 40);
            cmbJenis.TabIndex = 4;
            // 
            // lblBerat
            // 
            lblBerat.Font = new Font("Yu Gothic UI", 12F);
            lblBerat.Location = new Point(55, 299);
            lblBerat.Margin = new Padding(5, 0, 5, 0);
            lblBerat.Name = "lblBerat";
            lblBerat.Size = new Size(223, 50);
            lblBerat.TabIndex = 5;
            lblBerat.Text = "Berat (kg):";
            lblBerat.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbBerat
            // 
            tbBerat.Location = new Point(297, 311);
            tbBerat.Margin = new Padding(5, 6, 5, 6);
            tbBerat.Name = "tbBerat";
            tbBerat.PlaceholderText = "Contoh: 50.5";
            tbBerat.Size = new Size(220, 39);
            tbBerat.TabIndex = 6;
            // 
            // lblHarga
            // 
            lblHarga.Font = new Font("Yu Gothic UI", 12F);
            lblHarga.Location = new Point(55, 373);
            lblHarga.Margin = new Padding(5, 0, 5, 0);
            lblHarga.Name = "lblHarga";
            lblHarga.Size = new Size(223, 50);
            lblHarga.TabIndex = 7;
            lblHarga.Text = "Harga Pengajuan:";
            lblHarga.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbHarga
            // 
            tbHarga.Location = new Point(297, 387);
            tbHarga.Margin = new Padding(5, 6, 5, 6);
            tbHarga.Name = "tbHarga";
            tbHarga.PlaceholderText = "Contoh: 500000";
            tbHarga.Size = new Size(293, 39);
            tbHarga.TabIndex = 8;
            // 
            // lblDeskripsi
            // 
            lblDeskripsi.Font = new Font("Yu Gothic UI", 12F);
            lblDeskripsi.Location = new Point(55, 448);
            lblDeskripsi.Margin = new Padding(5, 0, 5, 0);
            lblDeskripsi.Name = "lblDeskripsi";
            lblDeskripsi.Size = new Size(223, 50);
            lblDeskripsi.TabIndex = 9;
            lblDeskripsi.Text = "Deskripsi:";
            lblDeskripsi.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbDeskripsi
            // 
            tbDeskripsi.Location = new Point(297, 465);
            tbDeskripsi.Margin = new Padding(5, 6, 5, 6);
            tbDeskripsi.Multiline = true;
            tbDeskripsi.Name = "tbDeskripsi";
            tbDeskripsi.PlaceholderText = "Deskripsi produk (opsional)";
            tbDeskripsi.ScrollBars = ScrollBars.Vertical;
            tbDeskripsi.Size = new Size(516, 166);
            tbDeskripsi.TabIndex = 10;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.DarkGreen;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Yu Gothic UI", 12F);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(297, 651);
            btnSubmit.Margin = new Padding(5, 6, 5, 6);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(335, 75);
            btnSubmit.TabIndex = 11;
            btnSubmit.Text = "✅ Ajukan Produk";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnBatal
            // 
            btnBatal.Font = new Font("Yu Gothic UI", 12F);
            btnBatal.Location = new Point(665, 651);
            btnBatal.Margin = new Padding(5, 6, 5, 6);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(148, 75);
            btnBatal.TabIndex = 12;
            btnBatal.Text = "Batal";
            btnBatal.Click += btnBatal_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(232, 255, 214);
            panel1.Controls.Add(lblJudul);
            panel1.Location = new Point(-3, -2);
            panel1.Margin = new Padding(5, 5, 5, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(939, 102);
            panel1.TabIndex = 13;
            // 
            // FormInputProduk
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(928, 789);
            Controls.Add(lblNama);
            Controls.Add(tbNamaProduk);
            Controls.Add(lblJenis);
            Controls.Add(cmbJenis);
            Controls.Add(lblBerat);
            Controls.Add(tbBerat);
            Controls.Add(lblHarga);
            Controls.Add(tbHarga);
            Controls.Add(lblDeskripsi);
            Controls.Add(tbDeskripsi);
            Controls.Add(btnSubmit);
            Controls.Add(btnBatal);
            Controls.Add(panel1);
            Margin = new Padding(5, 6, 5, 6);
            Name = "FormInputProduk";
            Text = "Input Produk Baru";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblJudul, lblNama, lblJenis, lblBerat, lblHarga, lblDeskripsi;
        private System.Windows.Forms.TextBox tbNamaProduk, tbBerat, tbHarga, tbDeskripsi;
        private System.Windows.Forms.ComboBox cmbJenis;
        private System.Windows.Forms.Button btnSubmit, btnBatal;
        private Panel panel1;
    }
}
