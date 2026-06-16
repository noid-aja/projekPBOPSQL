namespace WinFormsApp1
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            linkregister = new LinkLabel();
            tbusr = new TextBox();
            btnlogin = new Button();
            tbpw = new TextBox();
            panel1 = new Panel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // linkregister
            // 
            linkregister.ActiveLinkColor = Color.ForestGreen;
            linkregister.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            linkregister.AutoSize = true;
            linkregister.BackColor = Color.Transparent;
            linkregister.Cursor = Cursors.Hand;
            linkregister.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkregister.LinkColor = Color.White;
            linkregister.Location = new Point(395, 645);
            linkregister.Margin = new Padding(5, 0, 5, 0);
            linkregister.Name = "linkregister";
            linkregister.Size = new Size(221, 40);
            linkregister.TabIndex = 6;
            linkregister.TabStop = true;
            linkregister.Text = "Daftar Sekarang";
            linkregister.LinkClicked += linkregister_LinkClicked;
            // 
            // tbusr
            // 
            tbusr.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbusr.BackColor = Color.FromArgb(17, 37, 0);
            tbusr.BorderStyle = BorderStyle.None;
            tbusr.Font = new Font("Segoe UI", 10.8F);
            tbusr.ForeColor = Color.WhiteSmoke;
            tbusr.Location = new Point(94, 226);
            tbusr.Margin = new Padding(8, 6, 8, 6);
            tbusr.Name = "tbusr";
            tbusr.PlaceholderText = "Masukan Username";
            tbusr.Size = new Size(574, 39);
            tbusr.TabIndex = 0;
            tbusr.TextChanged += tbusr_TextChanged;
            // 
            // btnlogin
            // 
            btnlogin.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnlogin.BackColor = Color.FromArgb(232, 255, 214);
            btnlogin.Cursor = Cursors.Hand;
            btnlogin.FlatAppearance.BorderSize = 0;
            btnlogin.FlatStyle = FlatStyle.Flat;
            btnlogin.Font = new Font("Yu Gothic UI Semibold", 15F, FontStyle.Bold);
            btnlogin.ForeColor = Color.FromArgb(17, 37, 0);
            btnlogin.Location = new Point(89, 560);
            btnlogin.Margin = new Padding(8, 6, 8, 6);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(582, 74);
            btnlogin.TabIndex = 0;
            btnlogin.Text = "Login";
            btnlogin.UseVisualStyleBackColor = false;
            btnlogin.Click += btnlogin_Click;
            // 
            // tbpw
            // 
            tbpw.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbpw.BackColor = Color.FromArgb(17, 37, 0);
            tbpw.BorderStyle = BorderStyle.None;
            tbpw.Font = new Font("Segoe UI", 10.8F);
            tbpw.ForeColor = Color.WhiteSmoke;
            tbpw.Location = new Point(89, 352);
            tbpw.Margin = new Padding(8, 6, 8, 6);
            tbpw.Name = "tbpw";
            tbpw.PasswordChar = '*';
            tbpw.PlaceholderText = "Masukan Password";
            tbpw.Size = new Size(574, 39);
            tbpw.TabIndex = 1;
            tbpw.UseSystemPasswordChar = true;
            tbpw.TextChanged += tbpw_TextChanged;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.AutoSize = true;
            panel1.BackColor = Color.FromArgb(17, 37, 0);
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnlogin);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(tbpw);
            panel1.Controls.Add(linkregister);
            panel1.Controls.Add(tbusr);
            panel1.ForeColor = Color.MintCream;
            panel1.Location = new Point(554, 130);
            panel1.Margin = new Padding(5);
            panel1.MaximumSize = new Size(743, 779);
            panel1.MinimumSize = new Size(743, 779);
            panel1.Name = "panel1";
            panel1.Size = new Size(743, 779);
            panel1.TabIndex = 7;
            panel1.Paint += panel1_Paint;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(127, 645);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(268, 40);
            label6.TabIndex = 12;
            label6.Text = "Belum Punya Akun?";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 12F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(81, 301);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(153, 45);
            label5.TabIndex = 11;
            label5.Text = "Password";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(81, 174);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(163, 45);
            label4.TabIndex = 10;
            label4.Text = "Username";
            // 
            // label3
            // 
            label3.BackColor = Color.White;
            label3.Location = new Point(81, 408);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(593, 2);
            label3.TabIndex = 9;
            // 
            // label2
            // 
            label2.BackColor = Color.White;
            label2.Location = new Point(81, 280);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(593, 2);
            label2.TabIndex = 8;
            label2.Click += label2_Click_1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI Semibold", 20F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(180, 197, 166);
            label1.Location = new Point(242, 43);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(241, 72);
            label1.TabIndex = 7;
            label1.Text = "👤Login";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg_register_login;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1822, 1018);
            Controls.Add(panel1);
            DoubleBuffered = true;
            ForeColor = Color.White;
            Margin = new Padding(8, 6, 8, 6);
            Name = "FormLogin";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            Resize += Form1_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel linkregister;
        private TextBox tbusr;
        private Button btnlogin;
        private TextBox tbpw;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
