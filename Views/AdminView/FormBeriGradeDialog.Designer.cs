namespace WinFormsApp1.Views.AdminView
{
    partial class FormBeriGradeDialog
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNamaProduk = new System.Windows.Forms.Label();
            this.lblNilai = new System.Windows.Forms.Label();
            this.nudNilai = new System.Windows.Forms.NumericUpDown();
            this.lblHargaRekomendasi = new System.Windows.Forms.Label();
            this.tbHargaRekomendasi = new System.Windows.Forms.TextBox();
            this.lblCatatan = new System.Windows.Forms.Label();
            this.tbCatatan = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudNilai)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(206, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Input Hasil QC & Inspeksi Kopi";
            // 
            // lblNamaProduk
            // 
            this.lblNamaProduk.AutoSize = true;
            this.lblNamaProduk.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblNamaProduk.ForeColor = System.Drawing.Color.DimGray;
            this.lblNamaProduk.Location = new System.Drawing.Point(20, 45);
            this.lblNamaProduk.Name = "lblNamaProduk";
            this.lblNamaProduk.Size = new System.Drawing.Size(91, 19);
            this.lblNamaProduk.TabIndex = 1;
            this.lblNamaProduk.Text = "Nama Produk";
            // 
            // lblNilai
            // 
            this.lblNilai.AutoSize = true;
            this.lblNilai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNilai.Location = new System.Drawing.Point(20, 85);
            this.lblNilai.Name = "lblNilai";
            this.lblNilai.Size = new System.Drawing.Size(84, 15);
            this.lblNilai.TabIndex = 2;
            this.lblNilai.Text = "Nilai QC (0-100)";
            // 
            // nudNilai
            // 
            this.nudNilai.Location = new System.Drawing.Point(20, 105);
            this.nudNilai.Name = "nudNilai";
            this.nudNilai.Size = new System.Drawing.Size(340, 23);
            this.nudNilai.TabIndex = 3;
            // 
            // lblHargaRekomendasi
            // 
            this.lblHargaRekomendasi.AutoSize = true;
            this.lblHargaRekomendasi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHargaRekomendasi.Location = new System.Drawing.Point(20, 140);
            this.lblHargaRekomendasi.Name = "lblHargaRekomendasi";
            this.lblHargaRekomendasi.Size = new System.Drawing.Size(115, 15);
            this.lblHargaRekomendasi.TabIndex = 4;
            this.lblHargaRekomendasi.Text = "Harga Rekomendasi";
            // 
            // tbHargaRekomendasi
            // 
            this.tbHargaRekomendasi.Location = new System.Drawing.Point(20, 160);
            this.tbHargaRekomendasi.Name = "tbHargaRekomendasi";
            this.tbHargaRekomendasi.Size = new System.Drawing.Size(340, 23);
            this.tbHargaRekomendasi.TabIndex = 5;
            // 
            // lblCatatan
            // 
            this.lblCatatan.AutoSize = true;
            this.lblCatatan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCatatan.Location = new System.Drawing.Point(20, 195);
            this.lblCatatan.Name = "lblCatatan";
            this.lblCatatan.Size = new System.Drawing.Size(48, 15);
            this.lblCatatan.TabIndex = 6;
            this.lblCatatan.Text = "Catatan";
            // 
            // tbCatatan
            // 
            this.tbCatatan.Location = new System.Drawing.Point(20, 215);
            this.tbCatatan.Multiline = true;
            this.tbCatatan.Name = "tbCatatan";
            this.tbCatatan.Size = new System.Drawing.Size(340, 60);
            this.tbCatatan.TabIndex = 7;
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.Color.FromArgb(17, 37, 0);
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.Location = new System.Drawing.Point(20, 290);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(160, 35);
            this.btnSimpan.TabIndex = 8;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.BackColor = System.Drawing.Color.Gray;
            this.btnBatal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBatal.ForeColor = System.Drawing.Color.White;
            this.btnBatal.Location = new System.Drawing.Point(200, 290);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(160, 35);
            this.btnBatal.TabIndex = 9;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = false;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // FormBeriGradeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 345);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.tbCatatan);
            this.Controls.Add(this.lblCatatan);
            this.Controls.Add(this.tbHargaRekomendasi);
            this.Controls.Add(this.lblHargaRekomendasi);
            this.Controls.Add(this.nudNilai);
            this.Controls.Add(this.lblNilai);
            this.Controls.Add(this.lblNamaProduk);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBeriGradeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Beri Grade / QC";
            ((System.ComponentModel.ISupportInitialize)(this.nudNilai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNamaProduk;
        private System.Windows.Forms.Label lblNilai;
        private System.Windows.Forms.NumericUpDown nudNilai;
        private System.Windows.Forms.Label lblHargaRekomendasi;
        private System.Windows.Forms.TextBox tbHargaRekomendasi;
        private System.Windows.Forms.Label lblCatatan;
        private System.Windows.Forms.TextBox tbCatatan;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBatal;
    }
}
