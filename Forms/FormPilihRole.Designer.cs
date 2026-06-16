namespace WinFormsApp1.Forms
{
    partial class FormPilihRole
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
            cmbRoles = new ComboBox();
            btnPilih = new Button();
            btnBatal = new Button();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(17, 37, 0);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(400, 60);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Font = new Font("Yu Gothic UI Semibold", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(376, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🔑 Pilih Role Sesi Ini";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbRoles
            // 
            cmbRoles.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoles.Font = new Font("Segoe UI", 11F);
            cmbRoles.FormattingEnabled = true;
            cmbRoles.Location = new Point(50, 90);
            cmbRoles.Name = "cmbRoles";
            cmbRoles.Size = new Size(300, 33);
            cmbRoles.TabIndex = 1;
            // 
            // btnPilih
            // 
            btnPilih.BackColor = Color.FromArgb(232, 255, 214);
            btnPilih.FlatAppearance.BorderSize = 0;
            btnPilih.FlatStyle = FlatStyle.Flat;
            btnPilih.Font = new Font("Yu Gothic UI Semibold", 10.5F, FontStyle.Bold);
            btnPilih.ForeColor = Color.FromArgb(17, 37, 0);
            btnPilih.Location = new Point(50, 150);
            btnPilih.Name = "btnPilih";
            btnPilih.Size = new Size(130, 38);
            btnPilih.TabIndex = 2;
            btnPilih.Text = "Masuk";
            btnPilih.UseVisualStyleBackColor = false;
            btnPilih.Click += btnPilih_Click;
            // 
            // btnBatal
            // 
            btnBatal.BackColor = Color.FromArgb(224, 224, 224);
            btnBatal.FlatAppearance.BorderSize = 0;
            btnBatal.FlatStyle = FlatStyle.Flat;
            btnBatal.Font = new Font("Yu Gothic UI Semibold", 10.5F, FontStyle.Bold);
            btnBatal.Location = new Point(220, 150);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(130, 38);
            btnBatal.TabIndex = 3;
            btnBatal.Text = "Batal";
            btnBatal.UseVisualStyleBackColor = false;
            btnBatal.Click += btnBatal_Click;
            // 
            // FormPilihRole
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(400, 220);
            Controls.Add(btnBatal);
            Controls.Add(btnPilih);
            Controls.Add(cmbRoles);
            Controls.Add(panelHeader);
            Font = new Font("Yu Gothic UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPilihRole";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Pilih Role";
            panelHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private ComboBox cmbRoles;
        private Button btnPilih;
        private Button btnBatal;
    }
}
