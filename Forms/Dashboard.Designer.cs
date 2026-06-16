namespace WinFormsApp1.Forms
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            lblSidebarTitle = new Label();
            panel4 = new Panel();
            lblCardValue1 = new Label();
            lblCardTitle1 = new Label();
            panel5 = new Panel();
            lblCardValue2 = new Label();
            lblCardTitle2 = new Label();
            panel6 = new Panel();
            lblCardValue3 = new Label();
            lblCardTitle3 = new Label();
            panel7 = new Panel();
            lblCardValue4 = new Label();
            lblCardTitle4 = new Label();
            lblTableTitle = new Label();
            dgvDashboard = new DataGridView();
            panel8 = new Panel();
            btnMenu1 = new Button();
            btnMenu2 = new Button();
            btnMenu3 = new Button();
            btnMenu4 = new Button();
            btnMenu5 = new Button();
            btnLogout = new Button();
            btnMenu6 = new Button();
            btnMenu7 = new Button();
            btnMenu8 = new Button();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            label1 = new Label();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).BeginInit();
            panel8.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // lblSidebarTitle
            // 
            lblSidebarTitle.AutoSize = true;
            lblSidebarTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSidebarTitle.ForeColor = Color.White;
            lblSidebarTitle.Location = new Point(60, 296);
            lblSidebarTitle.Name = "lblSidebarTitle";
            lblSidebarTitle.Size = new Size(293, 45);
            lblSidebarTitle.TabIndex = 3;
            lblSidebarTitle.Text = "Dashboard Admin";
            lblSidebarTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblSidebarTitle.Click += lblSidebarTitle_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(232, 255, 214);
            panel4.Controls.Add(lblCardValue1);
            panel4.Controls.Add(lblCardTitle1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(16, 16);
            panel4.Margin = new Padding(16);
            panel4.Name = "panel4";
            panel4.Size = new Size(317, 291);
            panel4.TabIndex = 4;
            panel4.Paint += panel4_Paint;
            // 
            // lblCardValue1
            // 
            lblCardValue1.AutoSize = true;
            lblCardValue1.BackColor = Color.Transparent;
            lblCardValue1.Dock = DockStyle.Top;
            lblCardValue1.Font = new Font("Segoe UI", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCardValue1.Location = new Point(0, 0);
            lblCardValue1.Name = "lblCardValue1";
            lblCardValue1.Size = new Size(181, 71);
            lblCardValue1.TabIndex = 1;
            lblCardValue1.Text = "label1";
            lblCardValue1.TextAlign = ContentAlignment.MiddleCenter;
            lblCardValue1.Click += lblCardValue1_Click;
            // 
            // lblCardTitle1
            // 
            lblCardTitle1.AutoSize = true;
            lblCardTitle1.Dock = DockStyle.Bottom;
            lblCardTitle1.Location = new Point(0, 259);
            lblCardTitle1.Name = "lblCardTitle1";
            lblCardTitle1.Size = new Size(78, 32);
            lblCardTitle1.TabIndex = 0;
            lblCardTitle1.Text = "label3";
            lblCardTitle1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(166, 199, 126);
            panel5.Controls.Add(lblCardValue2);
            panel5.Controls.Add(lblCardTitle2);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(365, 16);
            panel5.Margin = new Padding(16);
            panel5.Name = "panel5";
            panel5.Size = new Size(317, 291);
            panel5.TabIndex = 5;
            panel5.Paint += panel5_Paint;
            // 
            // lblCardValue2
            // 
            lblCardValue2.AutoSize = true;
            lblCardValue2.Dock = DockStyle.Top;
            lblCardValue2.Font = new Font("Segoe UI", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCardValue2.Location = new Point(0, 0);
            lblCardValue2.Name = "lblCardValue2";
            lblCardValue2.Size = new Size(181, 71);
            lblCardValue2.TabIndex = 2;
            lblCardValue2.Text = "label2";
            // 
            // lblCardTitle2
            // 
            lblCardTitle2.AutoSize = true;
            lblCardTitle2.Dock = DockStyle.Bottom;
            lblCardTitle2.Location = new Point(0, 259);
            lblCardTitle2.Name = "lblCardTitle2";
            lblCardTitle2.Size = new Size(78, 32);
            lblCardTitle2.TabIndex = 1;
            lblCardTitle2.Text = "label4";
            lblCardTitle2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(232, 255, 214);
            panel6.Controls.Add(lblCardValue3);
            panel6.Controls.Add(lblCardTitle3);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(714, 16);
            panel6.Margin = new Padding(16);
            panel6.Name = "panel6";
            panel6.Size = new Size(317, 291);
            panel6.TabIndex = 5;
            panel6.Paint += panel6_Paint;
            // 
            // lblCardValue3
            // 
            lblCardValue3.AutoSize = true;
            lblCardValue3.Dock = DockStyle.Top;
            lblCardValue3.Font = new Font("Segoe UI", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCardValue3.Location = new Point(0, 0);
            lblCardValue3.Name = "lblCardValue3";
            lblCardValue3.Size = new Size(181, 71);
            lblCardValue3.TabIndex = 3;
            lblCardValue3.Text = "label7";
            // 
            // lblCardTitle3
            // 
            lblCardTitle3.AutoSize = true;
            lblCardTitle3.Dock = DockStyle.Bottom;
            lblCardTitle3.Location = new Point(0, 259);
            lblCardTitle3.Name = "lblCardTitle3";
            lblCardTitle3.Size = new Size(78, 32);
            lblCardTitle3.TabIndex = 2;
            lblCardTitle3.Text = "label5";
            lblCardTitle3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(166, 199, 126);
            panel7.Controls.Add(lblCardValue4);
            panel7.Controls.Add(lblCardTitle4);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(1063, 16);
            panel7.Margin = new Padding(16);
            panel7.Name = "panel7";
            panel7.Size = new Size(317, 291);
            panel7.TabIndex = 5;
            // 
            // lblCardValue4
            // 
            lblCardValue4.AutoSize = true;
            lblCardValue4.Dock = DockStyle.Top;
            lblCardValue4.Font = new Font("Segoe UI", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCardValue4.Location = new Point(0, 0);
            lblCardValue4.Name = "lblCardValue4";
            lblCardValue4.Size = new Size(181, 71);
            lblCardValue4.TabIndex = 4;
            lblCardValue4.Text = "label8";
            // 
            // lblCardTitle4
            // 
            lblCardTitle4.AutoSize = true;
            lblCardTitle4.Dock = DockStyle.Bottom;
            lblCardTitle4.Location = new Point(0, 259);
            lblCardTitle4.Name = "lblCardTitle4";
            lblCardTitle4.Size = new Size(78, 32);
            lblCardTitle4.TabIndex = 3;
            lblCardTitle4.Text = "label6";
            lblCardTitle4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTableTitle
            // 
            lblTableTitle.AutoSize = true;
            lblTableTitle.Dock = DockStyle.Top;
            lblTableTitle.Location = new Point(0, 0);
            lblTableTitle.Name = "lblTableTitle";
            lblTableTitle.Size = new Size(199, 32);
            lblTableTitle.TabIndex = 0;
            lblTableTitle.Text = "Data Produk Kopi";
            // 
            // dgvDashboard
            // 
            dgvDashboard.AllowUserToAddRows = false;
            dgvDashboard.AllowUserToDeleteRows = false;
            dgvDashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDashboard.BackgroundColor = Color.White;
            dgvDashboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDashboard.Dock = DockStyle.Fill;
            dgvDashboard.Location = new Point(0, 32);
            dgvDashboard.Margin = new Padding(3, 5, 3, 5);
            dgvDashboard.Name = "dgvDashboard";
            dgvDashboard.ReadOnly = true;
            dgvDashboard.RowHeadersWidth = 82;
            dgvDashboard.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDashboard.Size = new Size(1372, 262);
            dgvDashboard.TabIndex = 1;
            dgvDashboard.CellContentClick += dgvDashboard_CellContentClick;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel8.BackColor = Color.White;
            panel8.Controls.Add(dgvDashboard);
            panel8.Controls.Add(lblTableTitle);
            panel8.Location = new Point(432, 724);
            panel8.Margin = new Padding(3, 5, 3, 5);
            panel8.Name = "panel8";
            panel8.Size = new Size(1372, 294);
            panel8.TabIndex = 6;
            panel8.Paint += panel8_Paint;
            // 
            // btnMenu1
            // 
            btnMenu1.BackColor = Color.DarkGreen;
            btnMenu1.FlatAppearance.BorderSize = 0;
            btnMenu1.FlatStyle = FlatStyle.Flat;
            btnMenu1.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu1.ForeColor = Color.White;
            btnMenu1.Location = new Point(50, 381);
            btnMenu1.Margin = new Padding(3, 5, 3, 5);
            btnMenu1.Name = "btnMenu1";
            btnMenu1.Size = new Size(315, 69);
            btnMenu1.TabIndex = 3;
            btnMenu1.Text = "Beranda";
            btnMenu1.UseVisualStyleBackColor = false;
            btnMenu1.Click += btnMenu1_Click;
            // 
            // btnMenu2
            // 
            btnMenu2.BackColor = Color.DarkGreen;
            btnMenu2.FlatAppearance.BorderSize = 0;
            btnMenu2.FlatStyle = FlatStyle.Flat;
            btnMenu2.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu2.ForeColor = Color.White;
            btnMenu2.Location = new Point(50, 453);
            btnMenu2.Margin = new Padding(3, 5, 3, 5);
            btnMenu2.Name = "btnMenu2";
            btnMenu2.Size = new Size(315, 69);
            btnMenu2.TabIndex = 4;
            btnMenu2.Text = "Kelola User";
            btnMenu2.UseVisualStyleBackColor = false;
            // 
            // btnMenu3
            // 
            btnMenu3.BackColor = Color.DarkGreen;
            btnMenu3.FlatAppearance.BorderSize = 0;
            btnMenu3.FlatStyle = FlatStyle.Flat;
            btnMenu3.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu3.ForeColor = Color.White;
            btnMenu3.Location = new Point(50, 525);
            btnMenu3.Margin = new Padding(3, 5, 3, 5);
            btnMenu3.Name = "btnMenu3";
            btnMenu3.Size = new Size(315, 69);
            btnMenu3.TabIndex = 5;
            btnMenu3.Text = "Jenis Kopi";
            btnMenu3.UseVisualStyleBackColor = false;
            // 
            // btnMenu4
            // 
            btnMenu4.BackColor = Color.DarkGreen;
            btnMenu4.FlatAppearance.BorderSize = 0;
            btnMenu4.FlatStyle = FlatStyle.Flat;
            btnMenu4.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu4.ForeColor = Color.White;
            btnMenu4.Location = new Point(50, 597);
            btnMenu4.Margin = new Padding(3, 5, 3, 5);
            btnMenu4.Name = "btnMenu4";
            btnMenu4.Size = new Size(315, 69);
            btnMenu4.TabIndex = 6;
            btnMenu4.Text = "Produk Kopi";
            btnMenu4.UseVisualStyleBackColor = false;
            // 
            // btnMenu5
            // 
            btnMenu5.BackColor = Color.DarkGreen;
            btnMenu5.FlatAppearance.BorderSize = 0;
            btnMenu5.FlatStyle = FlatStyle.Flat;
            btnMenu5.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu5.ForeColor = Color.White;
            btnMenu5.Location = new Point(50, 669);
            btnMenu5.Margin = new Padding(3, 5, 3, 5);
            btnMenu5.Name = "btnMenu5";
            btnMenu5.Size = new Size(315, 69);
            btnMenu5.TabIndex = 7;
            btnMenu5.Text = "Lelang";
            btnMenu5.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLogout.BackColor = Color.DarkRed;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(50, 931);
            btnLogout.Margin = new Padding(3, 5, 3, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(307, 75);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "↩️ Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnMenu6
            // 
            btnMenu6.BackColor = Color.DarkGreen;
            btnMenu6.FlatAppearance.BorderSize = 0;
            btnMenu6.FlatStyle = FlatStyle.Flat;
            btnMenu6.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu6.ForeColor = Color.White;
            btnMenu6.Location = new Point(50, 741);
            btnMenu6.Margin = new Padding(3, 5, 3, 5);
            btnMenu6.Name = "btnMenu6";
            btnMenu6.Size = new Size(315, 69);
            btnMenu6.TabIndex = 9;
            btnMenu6.Text = "Transaksi";
            btnMenu6.UseVisualStyleBackColor = false;
            // 
            // btnMenu7
            // 
            btnMenu7.BackColor = Color.DarkGreen;
            btnMenu7.FlatAppearance.BorderSize = 0;
            btnMenu7.FlatStyle = FlatStyle.Flat;
            btnMenu7.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu7.ForeColor = Color.White;
            btnMenu7.Location = new Point(50, 813);
            btnMenu7.Margin = new Padding(3, 5, 3, 5);
            btnMenu7.Name = "btnMenu7";
            btnMenu7.Size = new Size(315, 69);
            btnMenu7.TabIndex = 10;
            btnMenu7.Text = "Laporan";
            btnMenu7.UseVisualStyleBackColor = false;
            // 
            // btnMenu8
            // 
            btnMenu8.BackColor = Color.DarkGreen;
            btnMenu8.FlatAppearance.BorderSize = 0;
            btnMenu8.FlatStyle = FlatStyle.Flat;
            btnMenu8.Font = new Font("Segoe UI Black", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu8.ForeColor = Color.White;
            btnMenu8.Location = new Point(50, 885);
            btnMenu8.Margin = new Padding(3, 5, 3, 5);
            btnMenu8.Name = "btnMenu8";
            btnMenu8.Size = new Size(315, 69);
            btnMenu8.TabIndex = 11;
            btnMenu8.Text = "Menu8";
            btnMenu8.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(17, 37, 0);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(btnMenu8);
            panel2.Controls.Add(btnMenu7);
            panel2.Controls.Add(lblSidebarTitle);
            panel2.Controls.Add(btnMenu6);
            panel2.Controls.Add(btnLogout);
            panel2.Controls.Add(btnMenu5);
            panel2.Controls.Add(btnMenu4);
            panel2.Controls.Add(btnMenu3);
            panel2.Controls.Add(btnMenu2);
            panel2.Controls.Add(btnMenu1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 5, 3, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(426, 1018);
            panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = Properties.Resources.Gemini_Generated_Image_kab6fikab6fikab6_1__1__1;
            pictureBox1.Location = new Point(95, 42);
            pictureBox1.Margin = new Padding(5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(258, 249);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(panel3);
            panel1.Location = new Point(421, 0);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1401, 1018);
            panel1.TabIndex = 7;
            panel1.Paint += panel1_Paint;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.BackColor = Color.FromArgb(17, 37, 0);
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(panel4, 0, 0);
            tableLayoutPanel1.Controls.Add(panel5, 1, 0);
            tableLayoutPanel1.Controls.Add(panel7, 3, 0);
            tableLayoutPanel1.Controls.Add(panel6, 2, 0);
            tableLayoutPanel1.Location = new Point(5, 381);
            tableLayoutPanel1.Margin = new Padding(5);
            tableLayoutPanel1.MinimumSize = new Size(0, 320);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 320F));
            tableLayoutPanel1.Size = new Size(1396, 323);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackgroundImage = (Image)resources.GetObject("panel3.BackgroundImage");
            panel3.BackgroundImageLayout = ImageLayout.Center;
            panel3.Controls.Add(label1);
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1401, 381);
            panel3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Yu Gothic UI Semibold", 30F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(21, 54);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(1093, 106);
            label1.TabIndex = 0;
            label1.Text = "Hai! Selamat datang kembali";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 235, 235);
            ClientSize = new Size(1822, 1018);
            Controls.Add(panel2);
            Controls.Add(panel8);
            Controls.Add(panel1);
            Margin = new Padding(3, 5, 3, 5);
            Name = "Dashboard";
            Text = "Dashboard Admin";
            WindowState = FormWindowState.Maximized;
            Load += FormDashboard_Load;
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblSidebarTitle;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Label lblCardTitle1;
        private Label lblCardTitle2;
        private Label lblCardTitle3;
        private Label lblCardTitle4;
        private Label lblCardValue1;
        private Label lblCardValue2;
        private Label lblCardValue3;
        private Label lblCardValue4;
        private Label lblTableTitle;
        private DataGridView dgvDashboard;
        private Panel panel8;
        private Button btnMenu1;
        private Button btnMenu2;
        private Button btnMenu3;
        private Button btnMenu4;
        private Button btnMenu5;
        private Button btnLogout;
        private Button btnMenu6;
        private Button btnMenu7;
        private Button btnMenu8;
        private Panel panel2;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel3;
    }
}