namespace WinFormsApp1.Views.AdminForm
{
    partial class FormDaftarPeserta
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
            panelHeader = new Panel();
            lblTitle = new Label();
            dgvPeserta = new DataGridView();
            btnClose = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPeserta).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(232, 255, 214);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(682, 100);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 37, 0);
            lblTitle.Location = new Point(12, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(658, 57);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "👥 Daftar Peserta & Bid Terakhir";
            lblTitle.Click += lblTitle_Click;
            // 
            // dgvPeserta
            // 
            dgvPeserta.AllowUserToAddRows = false;
            dgvPeserta.AllowUserToDeleteRows = false;
            dgvPeserta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPeserta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPeserta.BackgroundColor = SystemColors.ControlLightLight;
            dgvPeserta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPeserta.Location = new Point(12, 106);
            dgvPeserta.MultiSelect = false;
            dgvPeserta.Name = "dgvPeserta";
            dgvPeserta.ReadOnly = true;
            dgvPeserta.RowHeadersWidth = 51;
            dgvPeserta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPeserta.Size = new Size(658, 307);
            dgvPeserta.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(17, 37, 0);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Yu Gothic UI Semibold", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(523, 419);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(147, 50);
            btnClose.TabIndex = 2;
            btnClose.Text = "Tutup";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // FormDaftarPeserta
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(682, 469);
            Controls.Add(btnClose);
            Controls.Add(dgvPeserta);
            Controls.Add(panelHeader);
            Font = new Font("Yu Gothic UI", 9F);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormDaftarPeserta";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Daftar Peserta Lelang";
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPeserta).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private DataGridView dgvPeserta;
        private Button btnClose;
    }
}
