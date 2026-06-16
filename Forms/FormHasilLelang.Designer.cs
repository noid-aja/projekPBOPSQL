namespace WinFormsApp1.Forms
{
    partial class FormHasilLelang
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
            lblJudul = new Label();
            dgvHasil = new DataGridView();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHasil).BeginInit();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblJudul.Location = new Point(12, 12);
            lblJudul.Size = new Size(400, 35);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "📊 Rekap Hasil Lelang";
            // 
            // dgvHasil
            // 
            dgvHasil.AllowUserToAddRows = false;
            dgvHasil.AllowUserToDeleteRows = false;
            dgvHasil.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHasil.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHasil.BackgroundColor = Color.White;
            dgvHasil.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHasil.Location = new Point(12, 60);
            dgvHasil.MultiSelect = false;
            dgvHasil.Name = "dgvHasil";
            dgvHasil.ReadOnly = true;
            dgvHasil.RowHeadersWidth = 51;
            dgvHasil.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHasil.Size = new Size(960, 480);
            dgvHasil.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.Location = new Point(872, 12);
            btnRefresh.Size = new Size(100, 32);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // FormHasilLelang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 235, 235);
            ClientSize = new Size(984, 561);
            Controls.Add(btnRefresh);
            Controls.Add(dgvHasil);
            Controls.Add(lblJudul);
            Name = "FormHasilLelang";
            Text = "Rekap Hasil Lelang";
            ((System.ComponentModel.ISupportInitialize)dgvHasil).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblJudul;
        private DataGridView dgvHasil;
        private Button btnRefresh;
    }
}
