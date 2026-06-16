namespace WinFormsApp1.Views.AdminForm
{
    partial class jeniskopi
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
            tbNama = new TextBox();
            tbDeskripsi = new TextBox();
            btnTambah = new Button();
            btnEdit = new Button();
            btnHapus = new Button();
            dgvJenis = new DataGridView();
            panel1 = new Panel();
            label1 = new Label();
            label4 = new Label();
            panel2 = new Panel();
            lblJudul = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvJenis).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tbNama
            // 
            tbNama.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbNama.BackColor = Color.White;
            tbNama.BorderStyle = BorderStyle.None;
            tbNama.Location = new Point(268, 46);
            tbNama.Margin = new Padding(5, 5, 5, 5);
            tbNama.Name = "tbNama";
            tbNama.Size = new Size(964, 32);
            tbNama.TabIndex = 6;
            tbNama.TextChanged += tbNama_TextChanged;
            // 
            // tbDeskripsi
            // 
            tbDeskripsi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbDeskripsi.BackColor = Color.White;
            tbDeskripsi.BorderStyle = BorderStyle.None;
            tbDeskripsi.Location = new Point(268, 112);
            tbDeskripsi.Margin = new Padding(5, 5, 5, 5);
            tbDeskripsi.Multiline = true;
            tbDeskripsi.Name = "tbDeskripsi";
            tbDeskripsi.Size = new Size(964, 208);
            tbDeskripsi.TabIndex = 4;
            tbDeskripsi.TextChanged += tbDeskripsi_TextChanged;
            // 
            // btnTambah
            // 
            btnTambah.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTambah.BackColor = Color.FromArgb(29, 217, 0);
            btnTambah.FlatAppearance.BorderSize = 0;
            btnTambah.FlatStyle = FlatStyle.Flat;
            btnTambah.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            btnTambah.ForeColor = Color.Black;
            btnTambah.Location = new Point(1260, 35);
            btnTambah.Margin = new Padding(5, 5, 5, 5);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(436, 158);
            btnTambah.TabIndex = 3;
            btnTambah.Text = "➕Tambah";
            btnTambah.UseVisualStyleBackColor = false;
            btnTambah.Click += btnTambah_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Right;
            btnEdit.BackColor = Color.Gold;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnEdit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            btnEdit.ForeColor = Color.Black;
            btnEdit.Location = new Point(1260, 211);
            btnEdit.Margin = new Padding(5, 5, 5, 5);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(275, 109);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "✏️Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnHapus
            // 
            btnHapus.Anchor = AnchorStyles.Right;
            btnHapus.BackColor = Color.FromArgb(192, 25, 25);
            btnHapus.FlatAppearance.BorderSize = 0;
            btnHapus.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnHapus.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnHapus.FlatStyle = FlatStyle.Flat;
            btnHapus.Font = new Font("Segoe UI", 18F);
            btnHapus.ForeColor = Color.Black;
            btnHapus.Location = new Point(1555, 213);
            btnHapus.Margin = new Padding(5, 5, 5, 5);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(141, 109);
            btnHapus.TabIndex = 1;
            btnHapus.Text = "🗑️";
            btnHapus.UseVisualStyleBackColor = false;
            btnHapus.Click += btnHapus_Click;
            // 
            // dgvJenis
            // 
            dgvJenis.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvJenis.BackgroundColor = SystemColors.Control;
            dgvJenis.ColumnHeadersHeight = 29;
            dgvJenis.Location = new Point(20, 467);
            dgvJenis.Margin = new Padding(5, 5, 5, 5);
            dgvJenis.Name = "dgvJenis";
            dgvJenis.ReadOnly = true;
            dgvJenis.RowHeadersWidth = 51;
            dgvJenis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvJenis.Size = new Size(1682, 954);
            dgvJenis.TabIndex = 0;
            dgvJenis.CellClick += dgvJenis_CellClick;
            dgvJenis.CellContentClick += dgvJenis_CellContentClick;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(17, 37, 0);
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnTambah);
            panel1.Controls.Add(tbDeskripsi);
            panel1.Controls.Add(btnHapus);
            panel1.Controls.Add(tbNama);
            panel1.Controls.Add(btnEdit);
            panel1.Location = new Point(-8, 90);
            panel1.Margin = new Padding(5, 5, 5, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1727, 357);
            panel1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(60, 112);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(149, 45);
            label1.TabIndex = 12;
            label1.Text = "Deskripsi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(60, 35);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(181, 45);
            label4.TabIndex = 11;
            label4.Text = "Nama Jenis";
            label4.Click += label4_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(232, 255, 214);
            panel2.Controls.Add(lblJudul);
            panel2.Location = new Point(-8, -3);
            panel2.Margin = new Padding(5, 5, 5, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(1727, 102);
            panel2.TabIndex = 8;
            // 
            // lblJudul
            // 
            lblJudul.BackColor = Color.FromArgb(232, 255, 214);
            lblJudul.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblJudul.ForeColor = Color.FromArgb(17, 37, 0);
            lblJudul.Location = new Point(28, 24);
            lblJudul.Margin = new Padding(5, 0, 5, 0);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(557, 64);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "☕ Kelola Jenis Kopi";
            lblJudul.Click += lblJudul_Click;
            // 
            // jeniskopi
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1721, 1493);
            Controls.Add(panel2);
            Controls.Add(dgvJenis);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Margin = new Padding(5, 5, 5, 5);
            Name = "jeniskopi";
            Text = "Jenis Kopi";
            Load += jeniskopi_Load;
            ((System.ComponentModel.ISupportInitialize)dgvJenis).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TextBox tbNama;
        private System.Windows.Forms.TextBox tbDeskripsi;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.DataGridView dgvJenis;
        private Panel panel1;
        private Label label4;
        private Label label1;
        private Panel panel2;
        private Label lblJudul;
    }
}