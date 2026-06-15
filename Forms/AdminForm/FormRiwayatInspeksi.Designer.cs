namespace WinFormsApp1.Forms.AdminForm
{
    partial class FormRiwayatInspeksi
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
            btnRefresh = new System.Windows.Forms.Button();
            dgvRiwayat = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).BeginInit();
            SuspendLayout();

            lblJudul.Text = "📋 Riwayat Inspeksi";
            lblJudul.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblJudul.Location = new System.Drawing.Point(12, 12);
            lblJudul.Size = new System.Drawing.Size(300, 30);

            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.Location = new System.Drawing.Point(320, 14);
            btnRefresh.Size = new System.Drawing.Size(100, 28);
            btnRefresh.Click += btnRefresh_Click;

            lblTotal.Text = "Total: -";
            lblTotal.Location = new System.Drawing.Point(430, 18);
            lblTotal.Size = new System.Drawing.Size(200, 23);
            lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            dgvRiwayat.Location = new System.Drawing.Point(12, 55);
            dgvRiwayat.Size = new System.Drawing.Size(960, 480);
            dgvRiwayat.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                              | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvRiwayat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dgvRiwayat.ReadOnly = true;
            dgvRiwayat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvRiwayat.AllowUserToAddRows = false;

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(984, 548);
            Controls.Add(lblJudul);
            Controls.Add(btnRefresh);
            Controls.Add(lblTotal);
            Controls.Add(dgvRiwayat);
            Name = "FormRiwayatInspeksi";
            Text = "Riwayat Inspeksi";
            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblJudul, lblTotal;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvRiwayat;
    }
}
