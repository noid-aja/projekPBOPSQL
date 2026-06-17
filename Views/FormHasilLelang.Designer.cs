namespace WinFormsApp1.Views
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
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvHasil).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblJudul.Location = new Point(12, 21);
            lblJudul.Margin = new Padding(5, 0, 5, 0);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(650, 56);
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
            dgvHasil.Location = new Point(20, 115);
            dgvHasil.Margin = new Padding(5);
            dgvHasil.MultiSelect = false;
            dgvHasil.Name = "dgvHasil";
            dgvHasil.ReadOnly = true;
            dgvHasil.RowHeadersWidth = 51;
            dgvHasil.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHasil.Size = new Size(1560, 782);
            dgvHasil.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.Location = new Point(1415, 23);
            btnRefresh.Margin = new Padding(5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(162, 51);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(232, 255, 214);
            panel2.Controls.Add(btnRefresh);
            panel2.Controls.Add(lblJudul);
            panel2.Location = new Point(0, 1);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1595, 100);
            panel2.TabIndex = 10;
            // 
            // FormHasilLelang
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 235, 235);
            ClientSize = new Size(1599, 898);
            Controls.Add(dgvHasil);
            Controls.Add(panel2);
            Margin = new Padding(5);
            Name = "FormHasilLelang";
            Text = "Rekap Hasil Lelang";
            ((System.ComponentModel.ISupportInitialize)dgvHasil).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblJudul;
        private DataGridView dgvHasil;
        private Button btnRefresh;
        private Panel panel2;
    }
}
