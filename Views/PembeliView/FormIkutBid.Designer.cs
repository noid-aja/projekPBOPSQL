namespace WinFormsApp1.Views.PembeliView
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
            tabControl = new TabControl();
            tabLelang = new TabPage();
            lblJudul = new Label();
            lblJumlahLelang = new Label();
            btnRefresh = new Button();
            flpLelang = new FlowLayoutPanel();
            tabRiwayat = new TabPage();
            dgvRiwayat = new DataGridView();
            panel1 = new Panel();
            tabControl.SuspendLayout();
            tabLelang.SuspendLayout();
            tabRiwayat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabLelang);
            tabControl.Controls.Add(tabRiwayat);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(6, 6, 6, 6);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1827, 1195);
            tabControl.TabIndex = 0;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            // 
            // tabLelang
            // 
            tabLelang.Controls.Add(flpLelang);
            tabLelang.Controls.Add(panel1);
            tabLelang.Location = new Point(8, 46);
            tabLelang.Margin = new Padding(6, 6, 6, 6);
            tabLelang.Name = "tabLelang";
            tabLelang.Padding = new Padding(9, 11, 9, 11);
            tabLelang.Size = new Size(1811, 1141);
            tabLelang.TabIndex = 0;
            tabLelang.Text = "🔨 Ikut Bid";
            // 
            // lblJudul
            // 
            lblJudul.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblJudul.Location = new Point(15, 19);
            lblJudul.Margin = new Padding(6, 0, 6, 0);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(464, 60);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "\U0001f6d2 Lelang Aktif";
            // 
            // lblJumlahLelang
            // 
            lblJumlahLelang.Font = new Font("Yu Gothic UI", 12F);
            lblJumlahLelang.Location = new Point(491, 21);
            lblJumlahLelang.Margin = new Padding(6, 0, 6, 0);
            lblJumlahLelang.Name = "lblJumlahLelang";
            lblJumlahLelang.Size = new Size(371, 49);
            lblJumlahLelang.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.White;
            btnRefresh.Location = new Point(1689, 17);
            btnRefresh.Margin = new Padding(6, 6, 6, 6);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(93, 60);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "🔄";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // flpLelang
            // 
            flpLelang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpLelang.AutoScroll = true;
            flpLelang.Location = new Point(19, 115);
            flpLelang.Margin = new Padding(6, 6, 6, 6);
            flpLelang.Name = "flpLelang";
            flpLelang.Size = new Size(3220, 1966);
            flpLelang.TabIndex = 3;
            // 
            // tabRiwayat
            // 
            tabRiwayat.Controls.Add(dgvRiwayat);
            tabRiwayat.Location = new Point(8, 46);
            tabRiwayat.Margin = new Padding(6, 6, 6, 6);
            tabRiwayat.Name = "tabRiwayat";
            tabRiwayat.Padding = new Padding(9, 11, 9, 11);
            tabRiwayat.Size = new Size(355, 159);
            tabRiwayat.TabIndex = 1;
            tabRiwayat.Text = "📋 Riwayat Bid";
            // 
            // dgvRiwayat
            // 
            dgvRiwayat.AllowUserToAddRows = false;
            dgvRiwayat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvRiwayat.ColumnHeadersHeight = 46;
            dgvRiwayat.Dock = DockStyle.Fill;
            dgvRiwayat.Location = new Point(9, 11);
            dgvRiwayat.Margin = new Padding(6, 6, 6, 6);
            dgvRiwayat.Name = "dgvRiwayat";
            dgvRiwayat.ReadOnly = true;
            dgvRiwayat.RowHeadersWidth = 82;
            dgvRiwayat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRiwayat.Size = new Size(337, 137);
            dgvRiwayat.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(232, 255, 214);
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(lblJumlahLelang);
            panel1.Controls.Add(lblJudul);
            panel1.Location = new Point(0, 2);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1797, 102);
            panel1.TabIndex = 14;
            // 
            // FormIkutBid
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1827, 1195);
            Controls.Add(tabControl);
            Margin = new Padding(6, 6, 6, 6);
            Name = "FormIkutBid";
            Text = "Lelang & Bid";
            tabControl.ResumeLayout(false);
            tabLelang.ResumeLayout(false);
            tabRiwayat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabLelang, tabRiwayat;
        private System.Windows.Forms.Label lblJudul, lblJumlahLelang;
        private System.Windows.Forms.DataGridView dgvRiwayat;
        private System.Windows.Forms.FlowLayoutPanel flpLelang;
        private System.Windows.Forms.Button btnRefresh;
        private Panel panel1;
    }
}
