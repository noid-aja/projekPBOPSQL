namespace WinFormsApp1.Views.PembeliView
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
            lblProduk = new Label();
            lblHargaSaatIni = new Label();
            lblNominalLabel = new Label();
            tbNominal = new TextBox();
            btnPasang = new Button();
            btnBatal = new Button();
            panelHeader = new Panel();
            lblHeaderTitle = new Label();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // lblProduk
            // 
            lblProduk.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblProduk.ForeColor = Color.DarkGreen;
            lblProduk.Location = new Point(37, 149);
            lblProduk.Margin = new Padding(6, 0, 6, 0);
            lblProduk.Name = "lblProduk";
            lblProduk.Size = new Size(576, 53);
            lblProduk.TabIndex = 1;
            // 
            // lblHargaSaatIni
            // 
            lblHargaSaatIni.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblHargaSaatIni.ForeColor = Color.DarkSlateBlue;
            lblHargaSaatIni.Location = new Point(37, 224);
            lblHargaSaatIni.Margin = new Padding(6, 0, 6, 0);
            lblHargaSaatIni.Name = "lblHargaSaatIni";
            lblHargaSaatIni.Size = new Size(576, 47);
            lblHargaSaatIni.TabIndex = 2;
            // 
            // lblNominalLabel
            // 
            lblNominalLabel.Font = new Font("Segoe UI", 9F);
            lblNominalLabel.Location = new Point(37, 309);
            lblNominalLabel.Margin = new Padding(6, 0, 6, 0);
            lblNominalLabel.Name = "lblNominalLabel";
            lblNominalLabel.Size = new Size(576, 38);
            lblNominalLabel.TabIndex = 3;
            lblNominalLabel.Text = "Masukkan Nominal Bid Anda (Rp):";
            // 
            // tbNominal
            // 
            tbNominal.Font = new Font("Segoe UI", 11F);
            tbNominal.Location = new Point(37, 358);
            tbNominal.Margin = new Padding(6, 6, 6, 6);
            tbNominal.Name = "tbNominal";
            tbNominal.Size = new Size(572, 47);
            tbNominal.TabIndex = 4;
            // 
            // btnPasang
            // 
            btnPasang.BackColor = Color.FromArgb(39, 174, 96);
            btnPasang.FlatStyle = FlatStyle.Flat;
            btnPasang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPasang.ForeColor = Color.White;
            btnPasang.Location = new Point(37, 469);
            btnPasang.Margin = new Padding(6, 6, 6, 6);
            btnPasang.Name = "btnPasang";
            btnPasang.Size = new Size(269, 77);
            btnPasang.TabIndex = 5;
            btnPasang.Text = "💰 PASANG BID";
            btnPasang.UseVisualStyleBackColor = false;
            btnPasang.Click += btnPasang_Click;
            // 
            // btnBatal
            // 
            btnBatal.BackColor = Color.FromArgb(189, 195, 199);
            btnBatal.FlatStyle = FlatStyle.Flat;
            btnBatal.Font = new Font("Segoe UI", 10F);
            btnBatal.ForeColor = Color.Black;
            btnBatal.Location = new Point(344, 469);
            btnBatal.Margin = new Padding(6, 6, 6, 6);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(269, 77);
            btnBatal.TabIndex = 6;
            btnBatal.Text = "Batal";
            btnBatal.UseVisualStyleBackColor = false;
            btnBatal.Click += btnBatal_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(17, 37, 0);
            panelHeader.Controls.Add(lblHeaderTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(6, 6, 6, 6);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(650, 107);
            panelHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(22, 26);
            lblHeaderTitle.Margin = new Padding(6, 0, 6, 0);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(605, 53);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "🔨 Pasang Tawaran Bid";
            // 
            // FormInputBidDialog
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 597);
            Controls.Add(panelHeader);
            Controls.Add(lblProduk);
            Controls.Add(lblHargaSaatIni);
            Controls.Add(lblNominalLabel);
            Controls.Add(tbNominal);
            Controls.Add(btnPasang);
            Controls.Add(btnBatal);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6, 6, 6, 6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormInputBidDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Pasang Bid";
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
