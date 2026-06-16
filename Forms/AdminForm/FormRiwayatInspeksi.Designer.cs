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
            lblJudul = new Label();
            lblTotal = new Label();
            btnRefresh = new Button();
            dgvRiwayat = new DataGridView();
            panel1 = new Panel();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblJudul.Location = new Point(15, 19);
            lblJudul.Margin = new Padding(6, 0, 6, 0);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(557, 64);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "📋 Riwayat Inspeksi";
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Yu Gothic UI", 12F);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(22, 27);
            lblTotal.Margin = new Padding(6, 0, 6, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(371, 49);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total: -";
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.White;
            btnRefresh.Location = new Point(1619, 16);
            btnRefresh.Margin = new Padding(6, 6, 6, 6);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(186, 60);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvRiwayat
            // 
            dgvRiwayat.AllowUserToAddRows = false;
            dgvRiwayat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRiwayat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvRiwayat.ColumnHeadersHeight = 46;
            dgvRiwayat.Location = new Point(22, 246);
            dgvRiwayat.Margin = new Padding(6, 6, 6, 6);
            dgvRiwayat.Name = "dgvRiwayat";
            dgvRiwayat.ReadOnly = true;
            dgvRiwayat.RowHeadersWidth = 82;
            dgvRiwayat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRiwayat.Size = new Size(1783, 895);
            dgvRiwayat.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(232, 255, 214);
            panel1.Controls.Add(lblJudul);
            panel1.Location = new Point(0, 4);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1849, 102);
            panel1.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(17, 37, 0);
            panel2.Controls.Add(btnRefresh);
            panel2.Controls.Add(lblTotal);
            panel2.Location = new Point(0, 101);
            panel2.Margin = new Padding(5);
            panel2.Name = "panel2";
            panel2.Size = new Size(1849, 103);
            panel2.TabIndex = 8;
            // 
            // FormRiwayatInspeksi
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1827, 1169);
            Controls.Add(dgvRiwayat);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(6, 6, 6, 6);
            Name = "FormRiwayatInspeksi";
            Text = "Riwayat Inspeksi";
            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblJudul, lblTotal;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvRiwayat;
        private Panel panel1;
        private Panel panel2;
    }
}
