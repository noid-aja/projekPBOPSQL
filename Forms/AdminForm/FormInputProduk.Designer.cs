namespace WinFormsApp1.Forms.AdminForm
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
            lblJudul = new System.Windows.Forms.Label();
            lblNama = new System.Windows.Forms.Label();
            tbNamaProduk = new System.Windows.Forms.TextBox();
            lblJenis = new System.Windows.Forms.Label();
            cmbJenis = new System.Windows.Forms.ComboBox();
            lblBerat = new System.Windows.Forms.Label();
            tbBerat = new System.Windows.Forms.TextBox();
            lblHarga = new System.Windows.Forms.Label();
            tbHarga = new System.Windows.Forms.TextBox();
            lblDeskripsi = new System.Windows.Forms.Label();
            tbDeskripsi = new System.Windows.Forms.TextBox();
            btnSubmit = new System.Windows.Forms.Button();
            btnBatal = new System.Windows.Forms.Button();
            SuspendLayout();

            lblJudul.Text = "🌱 Input Produk Kopi Baru";
            lblJudul.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblJudul.Location = new System.Drawing.Point(30, 20);
            lblJudul.Size = new System.Drawing.Size(350, 30);

            lblNama.Text = "Nama Produk:";
            lblNama.Location = new System.Drawing.Point(30, 70);
            lblNama.Size = new System.Drawing.Size(120, 23);
            lblNama.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            tbNamaProduk.Location = new System.Drawing.Point(160, 68);
            tbNamaProduk.Size = new System.Drawing.Size(280, 23);
            tbNamaProduk.PlaceholderText = "Contoh: Kopi Arabika Premium";

            lblJenis.Text = "Jenis Kopi:";
            lblJenis.Location = new System.Drawing.Point(30, 105);
            lblJenis.Size = new System.Drawing.Size(120, 23);
            lblJenis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            cmbJenis.Location = new System.Drawing.Point(160, 103);
            cmbJenis.Size = new System.Drawing.Size(280, 23);
            cmbJenis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            lblBerat.Text = "Berat (kg):";
            lblBerat.Location = new System.Drawing.Point(30, 140);
            lblBerat.Size = new System.Drawing.Size(120, 23);
            lblBerat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            tbBerat.Location = new System.Drawing.Point(160, 138);
            tbBerat.Size = new System.Drawing.Size(120, 23);
            tbBerat.PlaceholderText = "Contoh: 50.5";

            lblHarga.Text = "Harga Pengajuan:";
            lblHarga.Location = new System.Drawing.Point(30, 175);
            lblHarga.Size = new System.Drawing.Size(120, 23);
            lblHarga.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            tbHarga.Location = new System.Drawing.Point(160, 173);
            tbHarga.Size = new System.Drawing.Size(160, 23);
            tbHarga.PlaceholderText = "Contoh: 500000";

            lblDeskripsi.Text = "Deskripsi:";
            lblDeskripsi.Location = new System.Drawing.Point(30, 210);
            lblDeskripsi.Size = new System.Drawing.Size(120, 23);
            lblDeskripsi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            tbDeskripsi.Location = new System.Drawing.Point(160, 210);
            tbDeskripsi.Size = new System.Drawing.Size(280, 80);
            tbDeskripsi.Multiline = true;
            tbDeskripsi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            tbDeskripsi.PlaceholderText = "Deskripsi produk (opsional)";

            btnSubmit.Text = "✅ Ajukan Produk";
            btnSubmit.Location = new System.Drawing.Point(160, 305);
            btnSubmit.Size = new System.Drawing.Size(140, 35);
            btnSubmit.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            btnSubmit.ForeColor = System.Drawing.Color.White;
            btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSubmit.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnSubmit.Click += btnSubmit_Click;

            btnBatal.Text = "Batal";
            btnBatal.Location = new System.Drawing.Point(310, 305);
            btnBatal.Size = new System.Drawing.Size(80, 35);
            btnBatal.Click += btnBatal_Click;

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(500, 370);
            Controls.Add(lblJudul);
            Controls.Add(lblNama); Controls.Add(tbNamaProduk);
            Controls.Add(lblJenis); Controls.Add(cmbJenis);
            Controls.Add(lblBerat); Controls.Add(tbBerat);
            Controls.Add(lblHarga); Controls.Add(tbHarga);
            Controls.Add(lblDeskripsi); Controls.Add(tbDeskripsi);
            Controls.Add(btnSubmit); Controls.Add(btnBatal);
            Name = "FormInputProduk";
            Text = "Input Produk Baru";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblJudul, lblNama, lblJenis, lblBerat, lblHarga, lblDeskripsi;
        private System.Windows.Forms.TextBox tbNamaProduk, tbBerat, tbHarga, tbDeskripsi;
        private System.Windows.Forms.ComboBox cmbJenis;
        private System.Windows.Forms.Button btnSubmit, btnBatal;
    }
}
