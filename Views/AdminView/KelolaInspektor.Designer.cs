namespace WinFormsApp1.Views.AdminView
{
    partial class KelolaInspektor
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
            dgvInspektor = new DataGridView();
            tbNoTelp = new TextBox();
            btnEnable = new Button();
            btnRefresh = new Button();
            tbUsername = new TextBox();
            btnDisable = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            tbPassword = new TextBox();
            tbFullName = new TextBox();
            panel2 = new Panel();
            lblJudul = new Label();
            panel1 = new Panel();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvInspektor).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvInspektor
            // 
            dgvInspektor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvInspektor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInspektor.BackgroundColor = SystemColors.Control;
            dgvInspektor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInspektor.Location = new Point(18, 480);
            dgvInspektor.Margin = new Padding(5);
            dgvInspektor.Name = "dgvInspektor";
            dgvInspektor.ReadOnly = true;
            dgvInspektor.RowHeadersWidth = 51;
            dgvInspektor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInspektor.Size = new Size(1300, 450);
            dgvInspektor.TabIndex = 0;
            dgvInspektor.CellClick += dgvInspektor_CellClick;
            // 
            // tbNoTelp
            // 
            tbNoTelp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbNoTelp.BackColor = Color.FromArgb(235, 235, 235);
            tbNoTelp.BorderStyle = BorderStyle.None;
            tbNoTelp.Font = new Font("Segoe UI", 11F);
            tbNoTelp.Location = new Point(220, 260);
            tbNoTelp.Margin = new Padding(5);
            tbNoTelp.Name = "tbNoTelp";
            tbNoTelp.PlaceholderText = "No. Telp";
            tbNoTelp.Size = new Size(650, 40);
            tbNoTelp.TabIndex = 10;
            // 
            // btnEnable
            // 
            btnEnable.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEnable.BackColor = Color.FromArgb(39, 174, 96);
            btnEnable.FlatAppearance.BorderSize = 0;
            btnEnable.FlatStyle = FlatStyle.Flat;
            btnEnable.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnEnable.ForeColor = Color.White;
            btnEnable.Location = new Point(900, 260);
            btnEnable.Margin = new Padding(5);
            btnEnable.Name = "btnEnable";
            btnEnable.Size = new Size(200, 60);
            btnEnable.TabIndex = 11;
            btnEnable.Text = "✅ Aktifkan";
            btnEnable.UseVisualStyleBackColor = false;
            btnEnable.Click += btnEnable_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.WhiteSmoke;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnRefresh.Location = new Point(900, 180);
            btnRefresh.Margin = new Padding(5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 60);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "🔄";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // tbUsername
            // 
            tbUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbUsername.BackColor = Color.FromArgb(235, 235, 235);
            tbUsername.BorderStyle = BorderStyle.None;
            tbUsername.Font = new Font("Segoe UI", 11F);
            tbUsername.Location = new Point(220, 110);
            tbUsername.Margin = new Padding(5);
            tbUsername.Name = "tbUsername";
            tbUsername.PlaceholderText = "Username";
            tbUsername.Size = new Size(650, 40);
            tbUsername.TabIndex = 1;
            // 
            // btnDisable
            // 
            btnDisable.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDisable.BackColor = Color.FromArgb(192, 57, 43);
            btnDisable.FlatAppearance.BorderSize = 0;
            btnDisable.FlatStyle = FlatStyle.Flat;
            btnDisable.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnDisable.ForeColor = Color.White;
            btnDisable.Location = new Point(1110, 260);
            btnDisable.Margin = new Padding(5);
            btnDisable.Name = "btnDisable";
            btnDisable.Size = new Size(200, 60);
            btnDisable.TabIndex = 7;
            btnDisable.Text = "❎ Nonaktif";
            btnDisable.UseVisualStyleBackColor = false;
            btnDisable.Click += btnDisable_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.BackColor = Color.Gold;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnEdit.Location = new Point(1030, 180);
            btnEdit.Margin = new Padding(5);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(280, 60);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "✏️ Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = Color.GreenYellow;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            btnAdd.Location = new Point(900, 40);
            btnAdd.Margin = new Padding(5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(410, 110);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "➕ Tambah Inspektor";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // tbPassword
            // 
            tbPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbPassword.BackColor = Color.FromArgb(235, 235, 235);
            tbPassword.BorderStyle = BorderStyle.None;
            tbPassword.Font = new Font("Segoe UI", 11F);
            tbPassword.Location = new Point(220, 180);
            tbPassword.Margin = new Padding(5);
            tbPassword.Name = "tbPassword";
            tbPassword.PlaceholderText = "Password";
            tbPassword.Size = new Size(650, 40);
            tbPassword.TabIndex = 3;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // tbFullName
            // 
            tbFullName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbFullName.BackColor = Color.FromArgb(235, 235, 235);
            tbFullName.BorderStyle = BorderStyle.None;
            tbFullName.Font = new Font("Segoe UI", 11F);
            tbFullName.Location = new Point(220, 40);
            tbFullName.Margin = new Padding(5);
            tbFullName.Name = "tbFullName";
            tbFullName.PlaceholderText = "Full name";
            tbFullName.Size = new Size(650, 40);
            tbFullName.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(232, 255, 214);
            panel2.Controls.Add(lblJudul);
            panel2.Location = new Point(-5, 0);
            panel2.Margin = new Padding(5);
            panel2.Name = "panel2";
            panel2.Size = new Size(1350, 80);
            panel2.TabIndex = 12;
            // 
            // lblJudul
            // 
            lblJudul.BackColor = Color.FromArgb(232, 255, 214);
            lblJudul.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblJudul.ForeColor = Color.FromArgb(17, 37, 0);
            lblJudul.Location = new Point(28, 20);
            lblJudul.Margin = new Padding(5, 0, 5, 0);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(557, 50);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "👤 Kelola Inspektor";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(17, 37, 0);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(tbFullName);
            panel1.Controls.Add(btnDisable);
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(btnEnable);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(tbUsername);
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(tbPassword);
            panel1.Controls.Add(tbNoTelp);
            panel1.Location = new Point(-5, 80);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1350, 360);
            panel1.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 12F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(49, 105);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(163, 45);
            label5.TabIndex = 16;
            label5.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(49, 175);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(153, 45);
            label3.TabIndex = 15;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(49, 255);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(128, 45);
            label2.TabIndex = 14;
            label2.Text = "No.Telp";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(49, 35);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(104, 45);
            label4.TabIndex = 12;
            label4.Text = "Nama";
            // 
            // KelolaInspektor
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1334, 950);
            Controls.Add(panel2);
            Controls.Add(dgvInspektor);
            Controls.Add(panel1);
            Margin = new Padding(5);
            Name = "KelolaInspektor";
            Text = "Kelola Inspektor";
            Load += KelolaInspektor_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInspektor).EndInit();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInspektor;
        private System.Windows.Forms.TextBox tbNoTelp;
        private System.Windows.Forms.Button btnEnable;
        private Button btnRefresh;
        private TextBox tbUsername;
        private Button btnDisable;
        private Button btnEdit;
        private Button btnAdd;
        private TextBox tbPassword;
        private TextBox tbFullName;
        private Panel panel2;
        private Label lblJudul;
        private Panel panel1;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label4;
    }
}
