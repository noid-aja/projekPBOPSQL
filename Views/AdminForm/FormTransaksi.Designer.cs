namespace WinFormsApp1.Views.AdminForm
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
            lblJudul = new Label();
            lblTotal = new Label();
            lblMetode = new Label();
            cmbMetode = new ComboBox();
            btnBayar = new Button();
            btnRefresh = new Button();
            dgvTransaksi = new DataGridView();
            panel1 = new Panel();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblJudul.Location = new Point(20, 21);
            lblJudul.Margin = new Padding(6, 0, 6, 0);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(650, 64);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "💳 Transaksi";
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Yu Gothic UI", 12F);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(968, 29);
            lblTotal.Margin = new Padding(6, 0, 6, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(371, 49);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "Total: -";
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            lblTotal.Click += lblTotal_Click;
            // 
            // lblMetode
            // 
            lblMetode.Font = new Font("Yu Gothic UI", 12F);
            lblMetode.ForeColor = Color.White;
            lblMetode.Location = new Point(22, 26);
            lblMetode.Margin = new Padding(6, 0, 6, 0);
            lblMetode.Name = "lblMetode";
            lblMetode.Size = new Size(252, 49);
            lblMetode.TabIndex = 1;
            lblMetode.Text = "Metode Bayar:";
            lblMetode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbMetode
            // 
            cmbMetode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetode.Items.AddRange(new object[] { "Transfer", "Tunai", "QRIS", "Virtual Account" });
            cmbMetode.Location = new Point(273, 35);
            cmbMetode.Margin = new Padding(6);
            cmbMetode.Name = "cmbMetode";
            cmbMetode.Size = new Size(294, 40);
            cmbMetode.TabIndex = 2;
            // 
            // btnBayar
            // 
            btnBayar.BackColor = Color.FromArgb(39, 174, 96);
            btnBayar.FlatStyle = FlatStyle.Flat;
            btnBayar.Font = new Font("Yu Gothic UI", 12F);
            btnBayar.ForeColor = Color.White;
            btnBayar.Location = new Point(579, 23);
            btnBayar.Margin = new Padding(6);
            btnBayar.Name = "btnBayar";
            btnBayar.Size = new Size(368, 60);
            btnBayar.TabIndex = 3;
            btnBayar.Text = "✅ Konfirmasi Bayar";
            btnBayar.UseVisualStyleBackColor = false;
            btnBayar.Click += btnBayar_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.White;
            btnRefresh.Location = new Point(1602, 20);
            btnRefresh.Margin = new Padding(6);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(186, 60);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvTransaksi
            // 
            dgvTransaksi.AllowUserToAddRows = false;
            dgvTransaksi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTransaksi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvTransaksi.ColumnHeadersHeight = 46;
            dgvTransaksi.Location = new Point(22, 218);
            dgvTransaksi.Margin = new Padding(6);
            dgvTransaksi.Name = "dgvTransaksi";
            dgvTransaksi.ReadOnly = true;
            dgvTransaksi.RowHeadersWidth = 82;
            dgvTransaksi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransaksi.Size = new Size(1783, 934);
            dgvTransaksi.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(232, 255, 214);
            panel1.Controls.Add(lblJudul);
            panel1.Location = new Point(2, 2);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1849, 102);
            panel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(17, 37, 0);
            panel2.Controls.Add(btnBayar);
            panel2.Controls.Add(cmbMetode);
            panel2.Controls.Add(btnRefresh);
            panel2.Controls.Add(lblMetode);
            panel2.Controls.Add(lblTotal);
            panel2.Location = new Point(0, 92);
            panel2.Margin = new Padding(5);
            panel2.Name = "panel2";
            panel2.Size = new Size(1808, 102);
            panel2.TabIndex = 7;
            // 
            // FormTransaksi
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1827, 1178);
            Controls.Add(dgvTransaksi);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(6);
            Name = "FormTransaksi";
            Text = "Transaksi";
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblMetode;
        private System.Windows.Forms.ComboBox cmbMetode;
        private System.Windows.Forms.Button btnBayar;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvTransaksi;
        private Panel panel1;
        private Panel panel2;
    }
}
