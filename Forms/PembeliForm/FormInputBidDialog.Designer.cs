namespace WinFormsApp1.Forms.PembeliForm
{
    partial class FormInputBidDialog
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
            lblProduk = new System.Windows.Forms.Label();
            lblHargaSaatIni = new System.Windows.Forms.Label();
            lblNominalLabel = new System.Windows.Forms.Label();
            tbNominal = new System.Windows.Forms.TextBox();
            btnPasang = new System.Windows.Forms.Button();
            btnBatal = new System.Windows.Forms.Button();
            panelHeader = new System.Windows.Forms.Panel();
            lblHeaderTitle = new System.Windows.Forms.Label();
            panelHeader.SuspendLayout();
            SuspendLayout();

            // panelHeader
            panelHeader.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            panelHeader.Controls.Add(lblHeaderTitle);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Size = new System.Drawing.Size(350, 50);

            // lblHeaderTitle
            lblHeaderTitle.Text = "🔨 Pasang Tawaran Bid";
            lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblHeaderTitle.Location = new System.Drawing.Point(12, 12);
            lblHeaderTitle.Size = new System.Drawing.Size(326, 25);

            // lblProduk
            lblProduk.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblProduk.ForeColor = System.Drawing.Color.DarkGreen;
            lblProduk.Location = new System.Drawing.Point(20, 70);
            lblProduk.Size = new System.Drawing.Size(310, 25);

            // lblHargaSaatIni
            lblHargaSaatIni.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblHargaSaatIni.ForeColor = System.Drawing.Color.DarkSlateBlue;
            lblHargaSaatIni.Location = new System.Drawing.Point(20, 105);
            lblHargaSaatIni.Size = new System.Drawing.Size(310, 22);

            // lblNominalLabel
            lblNominalLabel.Text = "Masukkan Nominal Bid Anda (Rp):";
            lblNominalLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblNominalLabel.Location = new System.Drawing.Point(20, 145);
            lblNominalLabel.Size = new System.Drawing.Size(310, 18);

            // tbNominal
            tbNominal.Font = new System.Drawing.Font("Segoe UI", 11F);
            tbNominal.Location = new System.Drawing.Point(20, 168);
            tbNominal.Size = new System.Drawing.Size(310, 27);

            // btnPasang
            btnPasang.Text = "💰 PASANG BID";
            btnPasang.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnPasang.ForeColor = System.Drawing.Color.White;
            btnPasang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnPasang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPasang.Location = new System.Drawing.Point(20, 220);
            btnPasang.Size = new System.Drawing.Size(145, 36);
            btnPasang.Click += new System.EventHandler(btnPasang_Click);

            // btnBatal
            btnBatal.Text = "Batal";
            btnBatal.BackColor = System.Drawing.Color.FromArgb(189, 195, 199);
            btnBatal.ForeColor = System.Drawing.Color.Black;
            btnBatal.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBatal.Location = new System.Drawing.Point(185, 220);
            btnBatal.Size = new System.Drawing.Size(145, 36);
            btnBatal.Click += new System.EventHandler(btnBatal_Click);

            // FormInputBidDialog
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(350, 280);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Pasang Bid";
            Controls.Add(panelHeader);
            Controls.Add(lblProduk);
            Controls.Add(lblHargaSaatIni);
            Controls.Add(lblNominalLabel);
            Controls.Add(tbNominal);
            Controls.Add(btnPasang);
            Controls.Add(btnBatal);
            panelHeader.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblProduk;
        private System.Windows.Forms.Label lblHargaSaatIni;
        private System.Windows.Forms.Label lblNominalLabel;
        private System.Windows.Forms.TextBox tbNominal;
        private System.Windows.Forms.Button btnPasang;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
    }
}
