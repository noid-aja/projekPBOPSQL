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
            lblJudul = new Label();
            lblTotal = new Label();
            lblFilter = new Label();
            cmbFilter = new ComboBox();
            btnRefresh = new Button();
            dgvProduk = new DataGridView();
            panel1 = new Panel();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvProduk).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.BackColor = Color.FromArgb(232, 255, 214);
            lblJudul.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblJudul.ForeColor = Color.FromArgb(17, 37, 0);
            lblJudul.Location = new Point(17, 17);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(343, 40);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "📦 Kelola Produk Kopi";
            lblJudul.Click += lblJudul_Click_1;
            // 
            // lblTotal
            // 
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(590, 37);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(229, 31);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total: -";
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFilter
            // 
            lblFilter.Font = new Font("Yu Gothic UI", 12F);
            lblFilter.ForeColor = Color.White;
            lblFilter.Location = new Point(21, 34);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(139, 31);
            lblFilter.TabIndex = 1;
            lblFilter.Text = "Filter Status:";
            lblFilter.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbFilter
            // 
            cmbFilter.BackColor = Color.White;
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Items.AddRange(new object[] { "Semua", "PendingInspeksi", "LolosQc", "DitolakQc", "Berlangsung", "Terjual" });
            cmbFilter.Location = new Point(159, 37);
            cmbFilter.Margin = new Padding(3, 4, 3, 4);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(257, 28);
            cmbFilter.TabIndex = 2;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(232, 255, 214);
            btnRefresh.ForeColor = Color.Black;
            btnRefresh.Location = new Point(448, 31);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(114, 37);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvProduk
            // 
            dgvProduk.AllowUserToAddRows = false;
            dgvProduk.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProduk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProduk.BackgroundColor = SystemColors.Control;
            dgvProduk.ColumnHeadersHeight = 29;
            dgvProduk.Location = new Point(14, 172);
            dgvProduk.Margin = new Padding(3, 4, 3, 4);
            dgvProduk.Name = "dgvProduk";
            dgvProduk.ReadOnly = true;
            dgvProduk.RowHeadersWidth = 51;
            dgvProduk.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProduk.Size = new Size(1097, 572);
            dgvProduk.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(232, 255, 214);
            panel1.Controls.Add(lblJudul);
            panel1.Location = new Point(-7, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1138, 64);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(17, 37, 0);
            panel2.Controls.Add(lblFilter);
            panel2.Controls.Add(lblTotal);
            panel2.Controls.Add(btnRefresh);
            panel2.Controls.Add(cmbFilter);
            panel2.Location = new Point(-7, 61);
            panel2.Name = "panel2";
            panel2.Size = new Size(1138, 104);
            panel2.TabIndex = 7;
            // 
            // ProdukKopi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1125, 749);
            Controls.Add(panel1);
            Controls.Add(dgvProduk);
            Controls.Add(panel2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ProdukKopi";
            Text = "Kelola Produk Kopi";
            ((System.ComponentModel.ISupportInitialize)dgvProduk).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvProduk;
        private Panel panel1;
        private Panel panel2;
    }
}
