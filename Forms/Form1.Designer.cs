namespace WinFormsApp1
{
    partial class Form1
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
            tbusr = new TextBox();
            tbpw = new TextBox();
            btnlogin = new Button();
            linkregister = new LinkLabel();
            SuspendLayout();
            // 
            // tbusr
            // 
            tbusr.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbusr.BackColor = Color.FromArgb(17, 37, 0);
            tbusr.BorderStyle = BorderStyle.None;
            tbusr.Font = new Font("Segoe UI", 9F);
            tbusr.ForeColor = Color.WhiteSmoke;
            tbusr.Location = new Point(242, 109);
            tbusr.Margin = new Padding(4, 3, 4, 3);
            tbusr.Name = "tbusr";
            tbusr.PlaceholderText = "Masukan Username";
            tbusr.Size = new Size(222, 16);
            tbusr.TabIndex = 0;
            tbusr.TextChanged += tbusr_TextChanged;
            // 
            // tbpw
            // 
            tbpw.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbpw.BackColor = Color.FromArgb(17, 37, 0);
            tbpw.BorderStyle = BorderStyle.None;
            tbpw.Font = new Font("Segoe UI", 9F);
            tbpw.ForeColor = Color.WhiteSmoke;
            tbpw.Location = new Point(242, 158);
            tbpw.Margin = new Padding(4, 3, 4, 3);
            tbpw.Name = "tbpw";
            tbpw.PasswordChar = '*';
            tbpw.PlaceholderText = "Masukan Password";
            tbpw.Size = new Size(222, 16);
            tbpw.TabIndex = 1;
            tbpw.UseSystemPasswordChar = true;
            tbpw.TextChanged += tbpw_TextChanged;
            // 
            // btnlogin
            // 
            btnlogin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnlogin.BackColor = Color.Transparent;
            btnlogin.FlatAppearance.BorderSize = 0;
            btnlogin.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnlogin.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnlogin.FlatStyle = FlatStyle.Flat;
            btnlogin.Location = new Point(239, 226);
            btnlogin.Margin = new Padding(4, 3, 4, 3);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(222, 28);
            btnlogin.TabIndex = 0;
            btnlogin.UseVisualStyleBackColor = false;
            btnlogin.Click += btnlogin_Click;
            // 
            // linkregister
            // 
            linkregister.ActiveLinkColor = Color.ForestGreen;
            linkregister.AutoSize = true;
            linkregister.BackColor = Color.Transparent;
            linkregister.Font = new Font("Segoe UI", 7F);
            linkregister.LinkColor = Color.White;
            linkregister.Location = new Point(384, 259);
            linkregister.Name = "linkregister";
            linkregister.Size = new Size(74, 12);
            linkregister.TabIndex = 6;
            linkregister.TabStop = true;
            linkregister.Text = "Daftar Sekarang";
            linkregister.LinkClicked += linkregister_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.loginnnn__1_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(699, 338);
            Controls.Add(linkregister);
            Controls.Add(btnlogin);
            Controls.Add(tbpw);
            Controls.Add(tbusr);
            DoubleBuffered = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbusr;
        private TextBox tbpw;
        private Button btnlogin;
        private LinkLabel linkregister;
    }
}
