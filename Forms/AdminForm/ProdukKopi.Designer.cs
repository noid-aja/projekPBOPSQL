namespace WinFormsApp1.Forms.AdminForm
{
    partial class ProdukKopi
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
            lblFilter = new System.Windows.Forms.Label();
            cmbFilter = new System.Windows.Forms.ComboBox();
            btnRefresh = new System.Windows.Forms.Button();
            dgvProduk = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProduk).BeginInit();
            SuspendLayout();

            // lblJudul
            lblJudul.Text = "📦 Kelola Produk Kopi";
            lblJudul.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblJudul.Location = new System.Drawing.Point(12, 12);
            lblJudul.Size = new System.Drawing.Size(300, 30);

            // lblFilter
            lblFilter.Text = "Filter Status:";
            lblFilter.Location = new System.Drawing.Point(12, 55);
            lblFilter.Size = new System.Drawing.Size(80, 23);
            lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // cmbFilter
            cmbFilter.Location = new System.Drawing.Point(95, 52);
            cmbFilter.Size = new System.Drawing.Size(180, 23);
            cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbFilter.Items.AddRange(new object[] { "Semua", "PendingInspeksi", "LolosQc", "DitolakQc", "Berlangsung", "Terjual" });
            cmbFilter.SelectedIndex = 0;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;

            // btnRefresh
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.Location = new System.Drawing.Point(290, 50);
            btnRefresh.Size = new System.Drawing.Size(100, 28);
            btnRefresh.Click += btnRefresh_Click;

            // lblTotal
            lblTotal.Text = "Total: -";
            lblTotal.Location = new System.Drawing.Point(400, 55);
            lblTotal.Size = new System.Drawing.Size(200, 23);
            lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // dgvProduk
            dgvProduk.Location = new System.Drawing.Point(12, 90);
            dgvProduk.Size = new System.Drawing.Size(960, 460);
            dgvProduk.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                             | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvProduk.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProduk.ReadOnly = true;
            dgvProduk.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvProduk.AllowUserToAddRows = false;

            // ProdukKopi form
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(984, 562);
            Controls.Add(lblJudul);
            Controls.Add(lblFilter);
            Controls.Add(cmbFilter);
            Controls.Add(btnRefresh);
            Controls.Add(lblTotal);
            Controls.Add(dgvProduk);
            Name = "ProdukKopi";
            Text = "Kelola Produk Kopi";
            ((System.ComponentModel.ISupportInitialize)dgvProduk).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvProduk;
    }
}
