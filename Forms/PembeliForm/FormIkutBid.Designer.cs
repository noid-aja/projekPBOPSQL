namespace WinFormsApp1.Forms.PembeliForm
{
    partial class FormIkutBid
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControl = new System.Windows.Forms.TabControl();
            tabLelang = new System.Windows.Forms.TabPage();
            tabRiwayat = new System.Windows.Forms.TabPage();
            lblJudul = new System.Windows.Forms.Label();
            lblJumlahLelang = new System.Windows.Forms.Label();
            btnRefresh = new System.Windows.Forms.Button();
            flpLelang = new System.Windows.Forms.FlowLayoutPanel();
            dgvRiwayat = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).BeginInit();
            tabControl.SuspendLayout();
            tabLelang.SuspendLayout();
            tabRiwayat.SuspendLayout();
            SuspendLayout();

            // tabControl
            tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl.TabPages.Add(tabLelang);
            tabControl.TabPages.Add(tabRiwayat);
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;

            // tabLelang
            tabLelang.Text = "🔨 Ikut Bid";
            tabLelang.Padding = new System.Windows.Forms.Padding(5);

            // lblJudul
            lblJudul.Text = "🛒 Lelang Aktif";
            lblJudul.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            lblJudul.Location = new System.Drawing.Point(10, 10);
            lblJudul.Size = new System.Drawing.Size(250, 28);

            // lblJumlahLelang
            lblJumlahLelang.Location = new System.Drawing.Point(270, 15);
            lblJumlahLelang.Size = new System.Drawing.Size(200, 23);
            lblJumlahLelang.Text = "";

            // btnRefresh
            btnRefresh.Text = "🔄";
            btnRefresh.Location = new System.Drawing.Point(480, 10);
            btnRefresh.Size = new System.Drawing.Size(50, 28);
            btnRefresh.Click += btnRefresh_Click;

            // flpLelang
            flpLelang.Location = new System.Drawing.Point(10, 45);
            flpLelang.Size = new System.Drawing.Size(950, 470);
            flpLelang.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flpLelang.AutoScroll = true;

            tabLelang.Controls.Add(lblJudul);
            tabLelang.Controls.Add(lblJumlahLelang);
            tabLelang.Controls.Add(btnRefresh);
            tabLelang.Controls.Add(flpLelang);

            // tabRiwayat
            tabRiwayat.Text = "📋 Riwayat Bid";
            tabRiwayat.Padding = new System.Windows.Forms.Padding(5);

            dgvRiwayat.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvRiwayat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dgvRiwayat.ReadOnly = true;
            dgvRiwayat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvRiwayat.AllowUserToAddRows = false;

            tabRiwayat.Controls.Add(dgvRiwayat);

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(984, 560);
            Controls.Add(tabControl);
            Name = "FormIkutBid";
            Text = "Lelang & Bid";

            tabControl.ResumeLayout(false);
            tabLelang.ResumeLayout(false);
            tabRiwayat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabLelang, tabRiwayat;
        private System.Windows.Forms.Label lblJudul, lblJumlahLelang;
        private System.Windows.Forms.DataGridView dgvRiwayat;
        private System.Windows.Forms.FlowLayoutPanel flpLelang;
        private System.Windows.Forms.Button btnRefresh;
    }
}
