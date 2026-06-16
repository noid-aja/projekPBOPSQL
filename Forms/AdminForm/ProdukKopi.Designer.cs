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
            lblJudul.Location = new Point(28, 27);
            lblJudul.Margin = new Padding(5, 0, 5, 0);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(557, 64);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "📦 Kelola Produk Kopi";
            lblJudul.Click += lblJudul_Click_1;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Yu Gothic UI", 12F);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(717, 39);
            lblTotal.Margin = new Padding(5, 0, 5, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(372, 50);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total: -";
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFilter
            // 
            lblFilter.Font = new Font("Yu Gothic UI", 12F);
            lblFilter.ForeColor = Color.White;
            lblFilter.Location = new Point(34, 39);
            lblFilter.Margin = new Padding(5, 0, 5, 0);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(226, 50);
            lblFilter.TabIndex = 1;
            lblFilter.Text = "Filter Status:";
            lblFilter.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbFilter
            // 
            cmbFilter.BackColor = Color.White;
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Items.AddRange(new object[] { "Semua", "PendingInspeksi", "LolosQc", "DitolakQc", "Berlangsung", "Terjual" });
            cmbFilter.Location = new Point(258, 44);
            cmbFilter.Margin = new Padding(5, 6, 5, 6);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(415, 40);
            cmbFilter.TabIndex = 2;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.White;
            btnRefresh.ForeColor = Color.Black;
            btnRefresh.Location = new Point(1632, 39);
            btnRefresh.Margin = new Padding(5, 6, 5, 6);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(185, 59);
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
            dgvProduk.Location = new Point(23, 230);
            dgvProduk.Margin = new Padding(5, 6, 5, 6);
            dgvProduk.Name = "dgvProduk";
            dgvProduk.ReadOnly = true;
            dgvProduk.RowHeadersWidth = 51;
            dgvProduk.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProduk.Size = new Size(1783, 960);
            dgvProduk.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(232, 255, 214);
            panel1.Controls.Add(lblJudul);
            panel1.Location = new Point(-11, -6);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1849, 100);
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
            panel2.Location = new Point(-11, 90);
            panel2.Margin = new Padding(5);
            panel2.Name = "panel2";
            panel2.Size = new Size(1849, 129);
            panel2.TabIndex = 7;
            // 
            // ProdukKopi
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1828, 1198);
            Controls.Add(panel1);
            Controls.Add(dgvProduk);
            Controls.Add(panel2);
            Margin = new Padding(5, 6, 5, 6);
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
