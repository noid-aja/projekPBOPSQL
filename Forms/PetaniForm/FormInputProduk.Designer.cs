namespace WinFormsApp1.Forms.PetaniForm
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
            lblJudul.Location = new Point(14, 16);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(400, 40);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "🌱 Input Produk Kopi Baru";
            lblJudul.Click += lblJudul_Click;
            // 
            // lblNama
            // 
            lblNama.Location = new Point(34, 93);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(137, 31);
            lblNama.TabIndex = 1;
            lblNama.Text = "Nama Produk:";
            lblNama.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbNamaProduk
            // 
            tbNamaProduk.Location = new Point(183, 91);
            tbNamaProduk.Margin = new Padding(3, 4, 3, 4);
            tbNamaProduk.Name = "tbNamaProduk";
            tbNamaProduk.PlaceholderText = "Contoh: Kopi Arabika Premium";
            tbNamaProduk.Size = new Size(319, 27);
            tbNamaProduk.TabIndex = 2;
            // 
            // lblJenis
            // 
            lblJenis.Location = new Point(34, 140);
            lblJenis.Name = "lblJenis";
            lblJenis.Size = new Size(137, 31);
            lblJenis.TabIndex = 3;
            lblJenis.Text = "Jenis Kopi:";
            lblJenis.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbJenis
            // 
            cmbJenis.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJenis.Location = new Point(183, 137);
            cmbJenis.Margin = new Padding(3, 4, 3, 4);
            cmbJenis.Name = "cmbJenis";
            cmbJenis.Size = new Size(319, 28);
            cmbJenis.TabIndex = 4;
            // 
            // lblBerat
            // 
            lblBerat.Location = new Point(34, 187);
            lblBerat.Name = "lblBerat";
            lblBerat.Size = new Size(137, 31);
            lblBerat.TabIndex = 5;
            lblBerat.Text = "Berat (kg):";
            lblBerat.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbBerat
            // 
            tbBerat.Location = new Point(183, 184);
            tbBerat.Margin = new Padding(3, 4, 3, 4);
            tbBerat.Name = "tbBerat";
            tbBerat.PlaceholderText = "Contoh: 50.5";
            tbBerat.Size = new Size(137, 27);
            tbBerat.TabIndex = 6;
            // 
            // lblHarga
            // 
            lblHarga.Location = new Point(34, 233);
            lblHarga.Name = "lblHarga";
            lblHarga.Size = new Size(137, 31);
            lblHarga.TabIndex = 7;
            lblHarga.Text = "Harga Pengajuan:";
            lblHarga.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbHarga
            // 
            tbHarga.Location = new Point(183, 231);
            tbHarga.Margin = new Padding(3, 4, 3, 4);
            tbHarga.Name = "tbHarga";
            tbHarga.PlaceholderText = "Contoh: 500000";
            tbHarga.Size = new Size(182, 27);
            tbHarga.TabIndex = 8;
            // 
            // lblDeskripsi
            // 
            lblDeskripsi.Location = new Point(34, 280);
            lblDeskripsi.Name = "lblDeskripsi";
            lblDeskripsi.Size = new Size(137, 31);
            lblDeskripsi.TabIndex = 9;
            lblDeskripsi.Text = "Deskripsi:";
            lblDeskripsi.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbDeskripsi
            // 
            tbDeskripsi.Location = new Point(183, 280);
            tbDeskripsi.Margin = new Padding(3, 4, 3, 4);
            tbDeskripsi.Multiline = true;
            tbDeskripsi.Name = "tbDeskripsi";
            tbDeskripsi.PlaceholderText = "Deskripsi produk (opsional)";
            tbDeskripsi.ScrollBars = ScrollBars.Vertical;
            tbDeskripsi.Size = new Size(319, 105);
            tbDeskripsi.TabIndex = 10;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.DarkGreen;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 10F);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(183, 407);
            btnSubmit.Margin = new Padding(3, 4, 3, 4);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(160, 47);
            btnSubmit.TabIndex = 11;
            btnSubmit.Text = "✅ Ajukan Produk";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnBatal
            // 
            btnBatal.Location = new Point(354, 407);
            btnBatal.Margin = new Padding(3, 4, 3, 4);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(91, 47);
            btnBatal.TabIndex = 12;
            btnBatal.Text = "Batal";
            btnBatal.Click += btnBatal_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(232, 255, 214);
            panel1.Controls.Add(lblJudul);
            panel1.Location = new Point(-2, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(578, 64);
            panel1.TabIndex = 13;
            // 
            // FormInputProduk
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(571, 493);
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
            Margin = new Padding(3, 4, 3, 4);
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
