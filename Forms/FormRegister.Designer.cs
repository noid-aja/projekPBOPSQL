namespace WinFormsApp1  // ← sama kayak FormRegister.cs
{
    partial class FormRegister  // ← nama class harus sama
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegister));
            txtnamapanjang = new TextBox();
            txtpassword = new TextBox();
            txtcpassword = new TextBox();
            Register = new Button();
            txtnotelp = new TextBox();
            txtrole = new ComboBox();
            txtusername = new TextBox();
            btnback = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            label13 = new Label();
            label11 = new Label();
            label12 = new Label();
            label9 = new Label();
            label10 = new Label();
            label7 = new Label();
            label8 = new Label();
            label5 = new Label();
            label6 = new Label();
            label1 = new Label();
            label4 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtnamapanjang
            // 
            txtnamapanjang.BackColor = Color.FromArgb(17, 37, 0);
            txtnamapanjang.BorderStyle = BorderStyle.None;
            txtnamapanjang.Font = new Font("Segoe UI", 10F);
            txtnamapanjang.ForeColor = Color.WhiteSmoke;
            txtnamapanjang.Location = new Point(65, 138);
            txtnamapanjang.Margin = new Padding(2);
            txtnamapanjang.Name = "txtnamapanjang";
            txtnamapanjang.PlaceholderText = "Masukan Nama";
            txtnamapanjang.Size = new Size(271, 23);
            txtnamapanjang.TabIndex = 0;
            txtnamapanjang.TextChanged += txtnamapanjang_TextChanged;
            // 
            // txtpassword
            // 
            txtpassword.BackColor = Color.FromArgb(17, 37, 0);
            txtpassword.BorderStyle = BorderStyle.None;
            txtpassword.Font = new Font("Segoe UI", 10.2F);
            txtpassword.ForeColor = Color.WhiteSmoke;
            txtpassword.Location = new Point(414, 210);
            txtpassword.Margin = new Padding(2);
            txtpassword.Name = "txtpassword";
            txtpassword.PlaceholderText = "Masukan Password";
            txtpassword.Size = new Size(271, 23);
            txtpassword.TabIndex = 4;
            txtpassword.UseSystemPasswordChar = true;
            txtpassword.TextChanged += txtpassword_TextChanged;
            // 
            // txtcpassword
            // 
            txtcpassword.BackColor = Color.FromArgb(17, 37, 0);
            txtcpassword.BorderStyle = BorderStyle.None;
            txtcpassword.Font = new Font("Segoe UI", 10.2F);
            txtcpassword.ForeColor = Color.WhiteSmoke;
            txtcpassword.Location = new Point(414, 295);
            txtcpassword.Margin = new Padding(2);
            txtcpassword.Name = "txtcpassword";
            txtcpassword.PlaceholderText = "Ulangi Password";
            txtcpassword.Size = new Size(271, 23);
            txtcpassword.TabIndex = 6;
            txtcpassword.UseSystemPasswordChar = true;
            // 
            // Register
            // 
            Register.BackColor = Color.FromArgb(232, 255, 214);
            Register.Cursor = Cursors.Hand;
            Register.FlatAppearance.BorderSize = 0;
            Register.FlatStyle = FlatStyle.Flat;
            Register.Font = new Font("Yu Gothic UI Semibold", 15F, FontStyle.Bold);
            Register.Location = new Point(192, 398);
            Register.Margin = new Padding(2);
            Register.Name = "Register";
            Register.Size = new Size(358, 47);
            Register.TabIndex = 8;
            Register.Text = "Daftar";
            Register.UseVisualStyleBackColor = false;
            Register.Click += Register_Click;
            // 
            // txtnotelp
            // 
            txtnotelp.BackColor = Color.FromArgb(17, 37, 0);
            txtnotelp.BorderStyle = BorderStyle.None;
            txtnotelp.Font = new Font("Segoe UI", 10.2F);
            txtnotelp.ForeColor = Color.WhiteSmoke;
            txtnotelp.Location = new Point(65, 295);
            txtnotelp.Margin = new Padding(2);
            txtnotelp.Name = "txtnotelp";
            txtnotelp.PlaceholderText = "Masukan No.Telp";
            txtnotelp.Size = new Size(271, 23);
            txtnotelp.TabIndex = 12;
            // 
            // txtrole
            // 
            txtrole.AllowDrop = true;
            txtrole.BackColor = Color.FromArgb(17, 37, 0);
            txtrole.FlatStyle = FlatStyle.Flat;
            txtrole.ForeColor = SystemColors.WindowFrame;
            txtrole.FormattingEnabled = true;
            txtrole.Items.AddRange(new object[] { "Petani", "Pembeli" });
            txtrole.Location = new Point(404, 141);
            txtrole.Margin = new Padding(2);
            txtrole.MaxDropDownItems = 2;
            txtrole.Name = "txtrole";
            txtrole.Size = new Size(281, 28);
            txtrole.TabIndex = 14;
            txtrole.Tag = "";
            txtrole.Text = "Pilih Role";
            txtrole.SelectedIndexChanged += txtrole_SelectedIndexChanged;
            // 
            // txtusername
            // 
            txtusername.BackColor = Color.FromArgb(17, 37, 0);
            txtusername.BorderStyle = BorderStyle.None;
            txtusername.Font = new Font("Segoe UI", 10.2F);
            txtusername.ForeColor = Color.WhiteSmoke;
            txtusername.Location = new Point(65, 210);
            txtusername.Margin = new Padding(2);
            txtusername.Name = "txtusername";
            txtusername.PlaceholderText = "Masukan Username";
            txtusername.Size = new Size(271, 23);
            txtusername.TabIndex = 16;
            txtusername.TextChanged += txtusername_TextChanged;
            // 
            // btnback
            // 
            btnback.BackColor = Color.Transparent;
            btnback.FlatAppearance.BorderSize = 0;
            btnback.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnback.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnback.FlatStyle = FlatStyle.Flat;
            btnback.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnback.ForeColor = Color.WhiteSmoke;
            btnback.Location = new Point(17, 6);
            btnback.Name = "btnback";
            btnback.Size = new Size(140, 46);
            btnback.TabIndex = 17;
            btnback.Text = "Kembali";
            btnback.UseVisualStyleBackColor = false;
            btnback.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.AutoSize = true;
            panel1.BackColor = Color.FromArgb(17, 37, 0);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtrole);
            panel1.Controls.Add(txtpassword);
            panel1.Controls.Add(txtnotelp);
            panel1.Controls.Add(txtusername);
            panel1.Controls.Add(txtcpassword);
            panel1.Controls.Add(txtnamapanjang);
            panel1.Controls.Add(btnback);
            panel1.Controls.Add(Register);
            panel1.Location = new Point(200, 58);
            panel1.MaximumSize = new Size(738, 486);
            panel1.MinimumSize = new Size(738, 486);
            panel1.Name = "panel1";
            panel1.Size = new Size(738, 486);
            panel1.TabIndex = 18;
            panel1.Resize += panel1_Resize;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Center;
            panel2.Location = new Point(15, 18);
            panel2.Name = "panel2";
            panel2.Size = new Size(31, 27);
            panel2.TabIndex = 31;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Yu Gothic UI", 12F);
            label13.ForeColor = Color.White;
            label13.Location = new Point(404, 108);
            label13.Name = "label13";
            label13.Size = new Size(51, 28);
            label13.TabIndex = 30;
            label13.Text = "Role";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Yu Gothic UI", 12F);
            label11.ForeColor = Color.White;
            label11.Location = new Point(404, 180);
            label11.Name = "label11";
            label11.Size = new Size(94, 28);
            label11.TabIndex = 29;
            label11.Text = "Password";
            // 
            // label12
            // 
            label12.BackColor = Color.White;
            label12.Location = new Point(404, 239);
            label12.Name = "label12";
            label12.Size = new Size(281, 1);
            label12.TabIndex = 28;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic UI", 12F);
            label9.ForeColor = Color.White;
            label9.Location = new Point(404, 265);
            label9.Name = "label9";
            label9.Size = new Size(192, 28);
            label9.TabIndex = 27;
            label9.Text = "Konfirmasi Password";
            // 
            // label10
            // 
            label10.BackColor = Color.White;
            label10.Location = new Point(404, 324);
            label10.Name = "label10";
            label10.Size = new Size(281, 1);
            label10.TabIndex = 26;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 12F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(55, 265);
            label7.Name = "label7";
            label7.Size = new Size(148, 28);
            label7.TabIndex = 25;
            label7.Text = "Nomor Telepon";
            // 
            // label8
            // 
            label8.BackColor = Color.White;
            label8.Location = new Point(55, 324);
            label8.Name = "label8";
            label8.Size = new Size(281, 1);
            label8.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 12F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(55, 180);
            label5.Name = "label5";
            label5.Size = new Size(99, 28);
            label5.TabIndex = 23;
            label5.Text = "Username";
            // 
            // label6
            // 
            label6.BackColor = Color.White;
            label6.Location = new Point(55, 239);
            label6.Name = "label6";
            label6.Size = new Size(281, 1);
            label6.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI Semibold", 20F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(180, 197, 166);
            label1.Location = new Point(236, 18);
            label1.Name = "label1";
            label1.Size = new Size(260, 46);
            label1.TabIndex = 20;
            label1.Text = "Registrasi Akun";
            label1.Click += label1_Click_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(55, 108);
            label4.Name = "label4";
            label4.Size = new Size(64, 28);
            label4.TabIndex = 19;
            label4.Text = "Nama";
            // 
            // label2
            // 
            label2.BackColor = Color.White;
            label2.Location = new Point(58, 169);
            label2.Name = "label2";
            label2.Size = new Size(281, 1);
            label2.TabIndex = 18;
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg_register_login;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1121, 636);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Margin = new Padding(2);
            Name = "FormRegister";
            Text = "Register";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtnamapanjang;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtcpassword;
        private System.Windows.Forms.Button Register;
        private TextBox txtnotelp;
        private ComboBox txtrole;
        private TextBox txtusername;
        private Button btnback;
        private Panel panel1;
        private Label label2;
        private Label label4;
        private Label label1;
        private Label label11;
        private Label label12;
        private Label label9;
        private Label label10;
        private Label label7;
        private Label label8;
        private Label label5;
        private Label label6;
        private Label label13;
        private Panel panel2;
    }
}