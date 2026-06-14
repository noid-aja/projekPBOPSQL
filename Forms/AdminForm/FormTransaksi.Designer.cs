namespace WinFormsApp1.Forms.AdminForm
{
    partial class FormTransaksi
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
            lblTotal = new System.Windows.Forms.Label();
            lblMetode = new System.Windows.Forms.Label();
            cmbMetode = new System.Windows.Forms.ComboBox();
            btnBayar = new System.Windows.Forms.Button();
            btnRefresh = new System.Windows.Forms.Button();
            dgvTransaksi = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).BeginInit();
            SuspendLayout();

            lblJudul.Text = "💳 Transaksi";
            lblJudul.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblJudul.Location = new System.Drawing.Point(12, 12);
            lblJudul.Size = new System.Drawing.Size(350, 30);

            lblMetode.Text = "Metode Bayar:";
            lblMetode.Location = new System.Drawing.Point(12, 55);
            lblMetode.Size = new System.Drawing.Size(90, 23);
            lblMetode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            cmbMetode.Location = new System.Drawing.Point(105, 52);
            cmbMetode.Size = new System.Drawing.Size(160, 23);
            cmbMetode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbMetode.Items.AddRange(new object[] { "Transfer", "Tunai", "QRIS", "Virtual Account" });
            cmbMetode.SelectedIndex = 0;

            btnBayar.Text = "✅ Konfirmasi Bayar";
            btnBayar.Location = new System.Drawing.Point(278, 50);
            btnBayar.Size = new System.Drawing.Size(160, 28);
            btnBayar.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            btnBayar.ForeColor = System.Drawing.Color.White;
            btnBayar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBayar.Click += btnBayar_Click;

            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.Location = new System.Drawing.Point(450, 50);
            btnRefresh.Size = new System.Drawing.Size(100, 28);
            btnRefresh.Click += btnRefresh_Click;

            lblTotal.Text = "Total: -";
            lblTotal.Location = new System.Drawing.Point(560, 55);
            lblTotal.Size = new System.Drawing.Size(200, 23);
            lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            dgvTransaksi.Location = new System.Drawing.Point(12, 90);
            dgvTransaksi.Size = new System.Drawing.Size(960, 450);
            dgvTransaksi.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                                | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvTransaksi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dgvTransaksi.ReadOnly = true;
            dgvTransaksi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvTransaksi.AllowUserToAddRows = false;

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(984, 552);
            Controls.Add(lblJudul);
            Controls.Add(lblMetode);
            Controls.Add(cmbMetode);
            Controls.Add(btnBayar);
            Controls.Add(btnRefresh);
            Controls.Add(lblTotal);
            Controls.Add(dgvTransaksi);
            Name = "FormTransaksi";
            Text = "Transaksi";
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblMetode;
        private System.Windows.Forms.ComboBox cmbMetode;
        private System.Windows.Forms.Button btnBayar;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvTransaksi;
    }
}
