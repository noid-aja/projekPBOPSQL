namespace WinFormsApp1.Forms.AdminForm
{
    partial class KelolaUser
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
            dgvUsers = new DataGridView();
            tbNoTelp = new TextBox();
            btnEnable = new Button();
            btnRefresh = new Button();
            tbUsername = new TextBox();
            btnDisable = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            cbRole = new ComboBox();
            tbPassword = new TextBox();
            tbFullName = new TextBox();
            panel2 = new Panel();
            lblJudul = new Label();
            panel1 = new Panel();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvUsers.BackgroundColor = SystemColors.Control;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(11, 362);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1253, 539);
            dgvUsers.TabIndex = 0;
            dgvUsers.CellClick += dgvUsers_CellClick;
            dgvUsers.CellContentClick += dgvUsers_CellContentClick;
            // 
            // tbNoTelp
            // 
            tbNoTelp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbNoTelp.BackColor = Color.FromArgb(235, 235, 235);
            tbNoTelp.BorderStyle = BorderStyle.None;
            tbNoTelp.Font = new Font("Segoe UI", 11F);
            tbNoTelp.Location = new Point(169, 176);
            tbNoTelp.Name = "tbNoTelp";
            tbNoTelp.PlaceholderText = "No. Telp";
            tbNoTelp.Size = new Size(298, 25);
            tbNoTelp.TabIndex = 10;
            // 
            // btnEnable
            // 
            btnEnable.Anchor = AnchorStyles.None;
            btnEnable.BackColor = Color.FromArgb(39, 174, 96);
            btnEnable.FlatAppearance.BorderSize = 0;
            btnEnable.FlatStyle = FlatStyle.Flat;
            btnEnable.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            btnEnable.Location = new Point(877, 198);
            btnEnable.Name = "btnEnable";
            btnEnable.Size = new Size(187, 61);
            btnEnable.TabIndex = 11;
            btnEnable.Text = "✅";
            btnEnable.UseVisualStyleBackColor = false;
            btnEnable.Click += btnEnable_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.None;
            btnRefresh.BackColor = Color.WhiteSmoke;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI Semibold", 19F, FontStyle.Bold);
            btnRefresh.Location = new Point(877, 109);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(109, 83);
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
            tbUsername.Location = new Point(169, 77);
            tbUsername.Name = "tbUsername";
            tbUsername.PlaceholderText = "Username";
            tbUsername.Size = new Size(298, 25);
            tbUsername.TabIndex = 1;
            tbUsername.TextChanged += tbUsername_TextChanged;
            // 
            // btnDisable
            // 
            btnDisable.Anchor = AnchorStyles.None;
            btnDisable.BackColor = Color.FromArgb(192, 57, 43);
            btnDisable.FlatAppearance.BorderSize = 0;
            btnDisable.FlatStyle = FlatStyle.Flat;
            btnDisable.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            btnDisable.Location = new Point(1069, 198);
            btnDisable.Name = "btnDisable";
            btnDisable.Size = new Size(187, 61);
            btnDisable.TabIndex = 7;
            btnDisable.Text = "❎";
            btnDisable.UseVisualStyleBackColor = false;
            btnDisable.Click += btnDisable_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.None;
            btnEdit.BackColor = Color.Gold;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            btnEdit.Location = new Point(992, 109);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(265, 83);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "✏️Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.None;
            btnAdd.BackColor = Color.GreenYellow;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold);
            btnAdd.Location = new Point(877, 19);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(380, 84);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "➕Tambah";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // cbRole
            // 
            cbRole.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbRole.BackColor = Color.FromArgb(235, 235, 235);
            cbRole.FlatStyle = FlatStyle.Flat;
            cbRole.Font = new Font("Segoe UI", 11F);
            cbRole.ForeColor = SystemColors.WindowFrame;
            cbRole.Location = new Point(169, 220);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(298, 33);
            cbRole.TabIndex = 4;
            cbRole.Text = "Role";
            cbRole.SelectedIndexChanged += cbRole_SelectedIndexChanged;
            // 
            // tbPassword
            // 
            tbPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbPassword.BackColor = Color.FromArgb(235, 235, 235);
            tbPassword.BorderStyle = BorderStyle.None;
            tbPassword.Font = new Font("Segoe UI", 11F);
            tbPassword.Location = new Point(169, 127);
            tbPassword.Name = "tbPassword";
            tbPassword.PlaceholderText = "Password";
            tbPassword.Size = new Size(298, 25);
            tbPassword.TabIndex = 3;
            tbPassword.UseSystemPasswordChar = true;
            tbPassword.TextChanged += tbPassword_TextChanged;
            // 
            // tbFullName
            // 
            tbFullName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbFullName.BackColor = Color.FromArgb(235, 235, 235);
            tbFullName.BorderStyle = BorderStyle.None;
            tbFullName.Font = new Font("Segoe UI", 11F);
            tbFullName.Location = new Point(169, 28);
            tbFullName.Name = "tbFullName";
            tbFullName.PlaceholderText = "Full name";
            tbFullName.Size = new Size(298, 25);
            tbFullName.TabIndex = 2;
            tbFullName.TextChanged += tbFullName_TextChanged;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(232, 255, 214);
            panel2.Controls.Add(lblJudul);
            panel2.Location = new Point(-3, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1360, 64);
            panel2.TabIndex = 12;
            // 
            // lblJudul
            // 
            lblJudul.BackColor = Color.FromArgb(232, 255, 214);
            lblJudul.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblJudul.ForeColor = Color.FromArgb(17, 37, 0);
            lblJudul.Location = new Point(17, 15);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(343, 40);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "👥 Kelola User";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(17, 37, 0);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
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
            panel1.Controls.Add(cbRole);
            panel1.Location = new Point(-3, 58);
            panel1.Name = "panel1";
            panel1.Size = new Size(1278, 298);
            panel1.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 12F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(30, 74);
            label5.Name = "label5";
            label5.Size = new Size(99, 28);
            label5.TabIndex = 16;
            label5.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(30, 124);
            label3.Name = "label3";
            label3.Size = new Size(94, 28);
            label3.TabIndex = 15;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(30, 173);
            label2.Name = "label2";
            label2.Size = new Size(78, 28);
            label2.TabIndex = 14;
            label2.Text = "No.Telp";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(30, 225);
            label1.Name = "label1";
            label1.Size = new Size(51, 28);
            label1.TabIndex = 13;
            label1.Text = "Role";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(30, 25);
            label4.Name = "label4";
            label4.Size = new Size(64, 28);
            label4.TabIndex = 12;
            label4.Text = "Nama";
            label4.Click += label4_Click;
            // 
            // KelolaUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1276, 938);
            Controls.Add(panel2);
            Controls.Add(dgvUsers);
            Controls.Add(panel1);
            Name = "KelolaUser";
            Text = "KelolaUser";
            Load += KelolaUser_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.TextBox tbNoTelp;
        private System.Windows.Forms.Button btnEnable;
        private Button btnRefresh;
        private TextBox tbUsername;
        private Button btnDisable;
        private Button btnEdit;
        private Button btnAdd;
        private ComboBox cbRole;
        private TextBox tbPassword;
        private TextBox tbFullName;
        private Panel panel2;
        private Label lblJudul;
        private Panel panel1;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
    }
}