namespace WinFormsApp1.Forms.AdminForm
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
            dgvLelang = new System.Windows.Forms.DataGridView();
            panelBid = new System.Windows.Forms.Panel();
            lblSelectedLelang = new System.Windows.Forms.Label();
            lblBidMin = new System.Windows.Forms.Label();
            lblNominal = new System.Windows.Forms.Label();
            tbNominalBid = new System.Windows.Forms.TextBox();
            btnBid = new System.Windows.Forms.Button();
            lblCountdown = new System.Windows.Forms.Label();
            btnRefresh = new System.Windows.Forms.Button();
            dgvRiwayat = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvLelang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).BeginInit();
            tabControl.SuspendLayout();
            tabLelang.SuspendLayout();
            tabRiwayat.SuspendLayout();
            panelBid.SuspendLayout();
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

            // dgvLelang
            dgvLelang.Location = new System.Drawing.Point(10, 45);
            dgvLelang.Size = new System.Drawing.Size(940, 250);
            dgvLelang.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvLelang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dgvLelang.ReadOnly = true;
            dgvLelang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvLelang.AllowUserToAddRows = false;
            dgvLelang.SelectionChanged += dgvLelang_SelectionChanged;

            // panelBid
            panelBid.Location = new System.Drawing.Point(10, 305);
            panelBid.Size = new System.Drawing.Size(940, 130);
            panelBid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelBid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelBid.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);

            lblSelectedLelang.Text = "Pilih lelang di atas untuk bid";
            lblSelectedLelang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblSelectedLelang.Location = new System.Drawing.Point(10, 10);
            lblSelectedLelang.Size = new System.Drawing.Size(400, 23);

            lblBidMin.Text = "Bid minimum: -";
            lblBidMin.Location = new System.Drawing.Point(10, 35);
            lblBidMin.Size = new System.Drawing.Size(300, 23);

            lblCountdown.Text = "⏱ Sisa: --:--";
            lblCountdown.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblCountdown.ForeColor = System.Drawing.Color.DarkRed;
            lblCountdown.Location = new System.Drawing.Point(320, 30);
            lblCountdown.Size = new System.Drawing.Size(200, 28);

            lblNominal.Text = "Nominal Bid (Rp):";
            lblNominal.Location = new System.Drawing.Point(10, 68);
            lblNominal.Size = new System.Drawing.Size(130, 23);
            lblNominal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            tbNominalBid.Location = new System.Drawing.Point(143, 66);
            tbNominalBid.Size = new System.Drawing.Size(200, 23);
            tbNominalBid.PlaceholderText = "Contoh: 500000";

            btnBid.Text = "💰 PASANG BID";
            btnBid.Location = new System.Drawing.Point(355, 62);
            btnBid.Size = new System.Drawing.Size(160, 35);
            btnBid.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            btnBid.ForeColor = System.Drawing.Color.White;
            btnBid.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnBid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBid.Click += btnBid_Click;

            panelBid.Controls.Add(lblSelectedLelang);
            panelBid.Controls.Add(lblBidMin);
            panelBid.Controls.Add(lblCountdown);
            panelBid.Controls.Add(lblNominal);
            panelBid.Controls.Add(tbNominalBid);
            panelBid.Controls.Add(btnBid);

            tabLelang.Controls.Add(lblJudul);
            tabLelang.Controls.Add(lblJumlahLelang);
            tabLelang.Controls.Add(btnRefresh);
            tabLelang.Controls.Add(dgvLelang);
            tabLelang.Controls.Add(panelBid);

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
            panelBid.ResumeLayout(false);
            panelBid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLelang).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabLelang, tabRiwayat;
        private System.Windows.Forms.Label lblJudul, lblJumlahLelang, lblSelectedLelang, lblBidMin, lblNominal, lblCountdown;
        private System.Windows.Forms.DataGridView dgvLelang, dgvRiwayat;
        private System.Windows.Forms.Panel panelBid;
        private System.Windows.Forms.TextBox tbNominalBid;
        private System.Windows.Forms.Button btnBid, btnRefresh;
    }
}
