namespace WinFormsApp1.Views.InspektorForm
{
    partial class Inspeksi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvPending = new DataGridView();
            lblNilai = new Label();
            nudNilai = new NumericUpDown();
            lblHarga = new Label();
            tbHargaRekomendasi = new TextBox();
            lblCatatan = new Label();
            tbCatatan = new TextBox();
            btnSubmit = new Button();
            btnRefresh = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvPending).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNilai).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPending
            // 
            dgvPending.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPending.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPending.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPending.Location = new Point(20, 330);
            dgvPending.Margin = new Padding(5);
            dgvPending.Name = "dgvPending";
            dgvPending.ReadOnly = true;
            dgvPending.RowHeadersWidth = 51;
            dgvPending.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPending.Size = new Size(1495, 493);
            dgvPending.TabIndex = 0;
            dgvPending.CellClick += dgvPending_CellClick;
            dgvPending.CellContentClick += dgvPending_CellContentClick;
            // 
            // lblNilai
            // 
            lblNilai.AutoSize = true;
            lblNilai.Font = new Font("Yu Gothic UI", 12F);
            lblNilai.ForeColor = Color.White;
            lblNilai.Location = new Point(34, 19);
            lblNilai.Margin = new Padding(5, 0, 5, 0);
            lblNilai.Name = "lblNilai";
            lblNilai.Size = new Size(84, 45);
            lblNilai.TabIndex = 3;
            lblNilai.Text = "Nilai";
            // 
            // nudNilai
            // 
            nudNilai.Location = new Point(349, 27);
            nudNilai.Margin = new Padding(5);
            nudNilai.Name = "nudNilai";
            nudNilai.Size = new Size(872, 39);
            nudNilai.TabIndex = 4;
            // 
            // lblHarga
            // 
            lblHarga.AutoSize = true;
            lblHarga.Font = new Font("Yu Gothic UI", 12F);
            lblHarga.ForeColor = Color.White;
            lblHarga.Location = new Point(34, 84);
            lblHarga.Margin = new Padding(5, 0, 5, 0);
            lblHarga.Name = "lblHarga";
            lblHarga.Size = new Size(305, 45);
            lblHarga.TabIndex = 5;
            lblHarga.Text = "Harga Rekomendasi";
            // 
            // tbHargaRekomendasi
            // 
            tbHargaRekomendasi.Location = new Point(349, 91);
            tbHargaRekomendasi.Margin = new Padding(5);
            tbHargaRekomendasi.Name = "tbHargaRekomendasi";
            tbHargaRekomendasi.PlaceholderText = "Harga (numeric)";
            tbHargaRekomendasi.Size = new Size(872, 39);
            tbHargaRekomendasi.TabIndex = 6;
            // 
            // lblCatatan
            // 
            lblCatatan.AutoSize = true;
            lblCatatan.Font = new Font("Yu Gothic UI", 12F);
            lblCatatan.ForeColor = Color.White;
            lblCatatan.Location = new Point(34, 149);
            lblCatatan.Margin = new Padding(5, 0, 5, 0);
            lblCatatan.Name = "lblCatatan";
            lblCatatan.Size = new Size(128, 45);
            lblCatatan.TabIndex = 7;
            lblCatatan.Text = "Catatan";
            // 
            // tbCatatan
            // 
            tbCatatan.Location = new Point(349, 156);
            tbCatatan.Margin = new Padding(5);
            tbCatatan.Multiline = true;
            tbCatatan.Name = "tbCatatan";
            tbCatatan.Size = new Size(872, 126);
            tbCatatan.TabIndex = 8;
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSubmit.BackColor = Color.FromArgb(39, 174, 96);
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.Font = new Font("Yu Gothic UI", 12F);
            btnSubmit.Location = new Point(1270, 27);
            btnSubmit.Margin = new Padding(5);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(234, 83);
            btnSubmit.TabIndex = 9;
            btnSubmit.Text = "Simpan";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Right;
            btnRefresh.Font = new Font("Yu Gothic UI", 12F);
            btnRefresh.Location = new Point(1351, 120);
            btnRefresh.Margin = new Padding(5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(153, 46);
            btnRefresh.TabIndex = 10;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(17, 37, 0);
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(nudNilai);
            panel1.Controls.Add(btnSubmit);
            panel1.Controls.Add(lblNilai);
            panel1.Controls.Add(tbCatatan);
            panel1.Controls.Add(lblHarga);
            panel1.Controls.Add(lblCatatan);
            panel1.Controls.Add(tbHargaRekomendasi);
            panel1.Location = new Point(0, 3);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1527, 317);
            panel1.TabIndex = 14;
            // 
            // Inspeksi
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1534, 805);
            Controls.Add(dgvPending);
            Controls.Add(panel1);
            Margin = new Padding(5);
            Name = "Inspeksi";
            Text = "Input Inspeksi";
            Load += Inspeksi_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPending).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNilai).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPending;
        private System.Windows.Forms.Label lblNilai;
        private System.Windows.Forms.NumericUpDown nudNilai;
        private System.Windows.Forms.Label lblHarga;
        private System.Windows.Forms.TextBox tbHargaRekomendasi;
        private System.Windows.Forms.Label lblCatatan;
        private System.Windows.Forms.TextBox tbCatatan;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnRefresh;
        private Panel panel1;
    }
}