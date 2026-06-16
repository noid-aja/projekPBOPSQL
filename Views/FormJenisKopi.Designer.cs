namespace WinFormsApp1
{
    partial class FormJenisKopi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJenisKopi));
            tbNama = new TextBox();
            btntambah = new Button();
            btnedit = new Button();
            btnhapus = new Button();
            dataGridView1 = new DataGridView();
            tbDeskripsi = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tbNama
            // 
            tbNama.Location = new Point(247, 106);
            tbNama.Name = "tbNama";
            tbNama.Size = new Size(250, 27);
            tbNama.TabIndex = 1;
            tbNama.TextChanged += tbNama_TextChanged;
            // 
            // btntambah
            // 
            btntambah.Location = new Point(810, 90);
            btntambah.Name = "btntambah";
            btntambah.Size = new Size(86, 31);
            btntambah.TabIndex = 2;
            btntambah.Text = "Tambah";
            btntambah.UseVisualStyleBackColor = true;
            btntambah.Click += btntambah_Click;
            // 
            // btnedit
            // 
            btnedit.Location = new Point(920, 90);
            btnedit.Name = "btnedit";
            btnedit.Size = new Size(86, 31);
            btnedit.TabIndex = 3;
            btnedit.Text = "Edit";
            btnedit.UseVisualStyleBackColor = true;
            btnedit.Click += btnedit_Click;
            // 
            // btnhapus
            // 
            btnhapus.Location = new Point(905, 239);
            btnhapus.Name = "btnhapus";
            btnhapus.Size = new Size(86, 31);
            btnhapus.TabIndex = 4;
            btnhapus.Text = "Hapus";
            btnhapus.UseVisualStyleBackColor = true;
            btnhapus.Click += btnhapus_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(50, 317);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1093, 665);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // tbDeskripsi
            // 
            tbDeskripsi.Location = new Point(247, 166);
            tbDeskripsi.Name = "tbDeskripsi";
            tbDeskripsi.Size = new Size(515, 27);
            tbDeskripsi.TabIndex = 6;
            // 
            // FormJenisKopi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1184, 1033);
            Controls.Add(tbDeskripsi);
            Controls.Add(dataGridView1);
            Controls.Add(btnhapus);
            Controls.Add(btnedit);
            Controls.Add(btntambah);
            Controls.Add(tbNama);
            DoubleBuffered = true;
            Name = "FormJenisKopi";
            Text = "Form Jenis Kopi";
            Load += FormJenisKopi_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbNama;
        private System.Windows.Forms.Button btntambah;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnhapus;
        private System.Windows.Forms.DataGridView dataGridView1;
        private TextBox tbDeskripsi;
    }
}
