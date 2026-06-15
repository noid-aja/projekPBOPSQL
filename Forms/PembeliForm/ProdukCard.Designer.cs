namespace WinFormsApp1.Forms.PembeliForm
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
            picProduct = new System.Windows.Forms.PictureBox();
            lblNama = new System.Windows.Forms.Label();
            lblPetani = new System.Windows.Forms.Label();
            lblJenis = new System.Windows.Forms.Label();
            lblBerat = new System.Windows.Forms.Label();
            lblGrade = new System.Windows.Forms.Label();
            lblHarga = new System.Windows.Forms.Label();
            lblCountdown = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)picProduct).BeginInit();
            SuspendLayout();

            // picProduct
            picProduct.Location = new System.Drawing.Point(10, 10);
            picProduct.Size = new System.Drawing.Size(200, 110);
            picProduct.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            picProduct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // lblNama
            lblNama.Location = new System.Drawing.Point(10, 125);
            lblNama.Size = new System.Drawing.Size(200, 22);
            lblNama.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblNama.ForeColor = System.Drawing.Color.DarkGreen;

            // lblJenis
            lblJenis.Location = new System.Drawing.Point(10, 147);
            lblJenis.Size = new System.Drawing.Size(200, 16);
            lblJenis.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblJenis.ForeColor = System.Drawing.Color.DimGray;

            // lblBerat
            lblBerat.Location = new System.Drawing.Point(10, 163);
            lblBerat.Size = new System.Drawing.Size(200, 16);
            lblBerat.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblBerat.ForeColor = System.Drawing.Color.DimGray;

            // lblPetani
            lblPetani.Location = new System.Drawing.Point(10, 179);
            lblPetani.Size = new System.Drawing.Size(200, 16);
            lblPetani.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblPetani.ForeColor = System.Drawing.Color.DimGray;

            // lblGrade
            lblGrade.Location = new System.Drawing.Point(10, 195);
            lblGrade.Size = new System.Drawing.Size(200, 16);
            lblGrade.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            lblGrade.ForeColor = System.Drawing.Color.FromArgb(230, 126, 34);

            // lblHarga
            lblHarga.Location = new System.Drawing.Point(10, 215);
            lblHarga.Size = new System.Drawing.Size(200, 18);
            lblHarga.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblHarga.ForeColor = System.Drawing.Color.DarkSlateBlue;

            // lblCountdown
            lblCountdown.Location = new System.Drawing.Point(10, 235);
            lblCountdown.Size = new System.Drawing.Size(200, 18);
            lblCountdown.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblCountdown.ForeColor = System.Drawing.Color.DarkRed;

            // ProdukCard
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Size = new System.Drawing.Size(220, 260);
            BackColor = System.Drawing.Color.White;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Controls.Add(picProduct);
            Controls.Add(lblNama);
            Controls.Add(lblJenis);
            Controls.Add(lblBerat);
            Controls.Add(lblPetani);
            Controls.Add(lblGrade);
            Controls.Add(lblHarga);
            Controls.Add(lblCountdown);
            ((System.ComponentModel.ISupportInitialize)picProduct).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox picProduct;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.Label lblPetani;
        private System.Windows.Forms.Label lblJenis;
        private System.Windows.Forms.Label lblBerat;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Label lblHarga;
        private System.Windows.Forms.Label lblCountdown;
    }
}
