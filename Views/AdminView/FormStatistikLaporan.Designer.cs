namespace WinFormsApp1.Views.AdminView
{
    partial class FormStatistikLaporan
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

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitle = new Label();
            tabControl1 = new TabControl();
            tabProdukDetail = new TabPage();
            dgvProdukDetail = new DataGridView();
            tabKopiPopuler = new TabPage();
            dgvKopiPopuler = new DataGridView();
            tabPerformaPetani = new TabPage();
            dgvPerformaPetani = new DataGridView();
            tabRollup = new TabPage();
            dgvRollup = new DataGridView();
            tabCube = new TabPage();
            dgvCube = new DataGridView();
            tabKeuangan = new TabPage();
            dgvKeuangan = new DataGridView();
            tabSubqueryHarga = new TabPage();
            dgvSubqueryHarga = new DataGridView();
            tabBidTertinggi = new TabPage();
            dgvBidTertinggi = new DataGridView();
            tabUnionLinimasa = new TabPage();
            dgvUnionLinimasa = new DataGridView();
            tabIntersectMultiRole = new TabPage();
            dgvIntersectMultiRole = new DataGridView();
            tabExceptPembeliBelumBid = new TabPage();
            dgvExceptPembeliBelumBid = new DataGridView();
            tabSubqueryBid = new TabPage();
            dgvSubqueryBid = new DataGridView();
            panelHeader.SuspendLayout();
            tabControl1.SuspendLayout();
            tabProdukDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProdukDetail).BeginInit();
            tabKopiPopuler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKopiPopuler).BeginInit();
            tabPerformaPetani.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPerformaPetani).BeginInit();
            tabRollup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRollup).BeginInit();
            tabCube.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCube).BeginInit();
            tabKeuangan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKeuangan).BeginInit();
            tabSubqueryHarga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSubqueryHarga).BeginInit();
            tabBidTertinggi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBidTertinggi).BeginInit();
            tabUnionLinimasa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUnionLinimasa).BeginInit();
            tabIntersectMultiRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIntersectMultiRole).BeginInit();
            tabExceptPembeliBelumBid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExceptPembeliBelumBid).BeginInit();
            tabSubqueryBid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSubqueryBid).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(232, 255, 214);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(6, 6, 6, 6);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1827, 128);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 37, 0);
            lblTitle.Location = new Point(28, 36);
            lblTitle.Margin = new Padding(6, 0, 6, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(539, 51);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📊 Statistik & Laporan Analitis";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabProdukDetail);
            tabControl1.Controls.Add(tabKopiPopuler);
            tabControl1.Controls.Add(tabPerformaPetani);
            tabControl1.Controls.Add(tabRollup);
            tabControl1.Controls.Add(tabCube);
            tabControl1.Controls.Add(tabKeuangan);
            tabControl1.Controls.Add(tabSubqueryHarga);
            tabControl1.Controls.Add(tabBidTertinggi);
            tabControl1.Controls.Add(tabUnionLinimasa);
            tabControl1.Controls.Add(tabIntersectMultiRole);
            tabControl1.Controls.Add(tabExceptPembeliBelumBid);
            tabControl1.Controls.Add(tabSubqueryBid);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Yu Gothic UI", 12F);
            tabControl1.Location = new Point(0, 128);
            tabControl1.Margin = new Padding(6, 6, 6, 6);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1827, 1069);
            tabControl1.TabIndex = 1;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabProdukDetail
            // 
            tabProdukDetail.Controls.Add(dgvProdukDetail);
            tabProdukDetail.Location = new Point(8, 59);
            tabProdukDetail.Margin = new Padding(6, 6, 6, 6);
            tabProdukDetail.Name = "tabProdukDetail";
            tabProdukDetail.Size = new Size(1811, 1002);
            tabProdukDetail.TabIndex = 0;
            tabProdukDetail.Text = "Katalog Detail (View)";
            tabProdukDetail.UseVisualStyleBackColor = true;
            // 
            // dgvProdukDetail
            // 
            dgvProdukDetail.AllowUserToAddRows = false;
            dgvProdukDetail.AllowUserToDeleteRows = false;
            dgvProdukDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdukDetail.Dock = DockStyle.Fill;
            dgvProdukDetail.Location = new Point(0, 0);
            dgvProdukDetail.Margin = new Padding(6, 6, 6, 6);
            dgvProdukDetail.Name = "dgvProdukDetail";
            dgvProdukDetail.ReadOnly = true;
            dgvProdukDetail.RowHeadersWidth = 51;
            dgvProdukDetail.Size = new Size(1811, 1002);
            dgvProdukDetail.TabIndex = 0;
            // 
            // tabKopiPopuler
            // 
            tabKopiPopuler.Controls.Add(dgvKopiPopuler);
            tabKopiPopuler.Location = new Point(8, 46);
            tabKopiPopuler.Margin = new Padding(6, 6, 6, 6);
            tabKopiPopuler.Name = "tabKopiPopuler";
            tabKopiPopuler.Size = new Size(1811, 1015);
            tabKopiPopuler.TabIndex = 1;
            tabKopiPopuler.Text = "Kopi Terpopuler (Group)";
            tabKopiPopuler.UseVisualStyleBackColor = true;
            // 
            // dgvKopiPopuler
            // 
            dgvKopiPopuler.AllowUserToAddRows = false;
            dgvKopiPopuler.AllowUserToDeleteRows = false;
            dgvKopiPopuler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKopiPopuler.Dock = DockStyle.Fill;
            dgvKopiPopuler.Location = new Point(0, 0);
            dgvKopiPopuler.Margin = new Padding(6, 6, 6, 6);
            dgvKopiPopuler.Name = "dgvKopiPopuler";
            dgvKopiPopuler.ReadOnly = true;
            dgvKopiPopuler.RowHeadersWidth = 51;
            dgvKopiPopuler.Size = new Size(1811, 1015);
            dgvKopiPopuler.TabIndex = 0;
            // 
            // tabPerformaPetani
            // 
            tabPerformaPetani.Controls.Add(dgvPerformaPetani);
            tabPerformaPetani.Location = new Point(8, 46);
            tabPerformaPetani.Margin = new Padding(6, 6, 6, 6);
            tabPerformaPetani.Name = "tabPerformaPetani";
            tabPerformaPetani.Size = new Size(1811, 1015);
            tabPerformaPetani.TabIndex = 2;
            tabPerformaPetani.Text = "Performa Petani (Group)";
            tabPerformaPetani.UseVisualStyleBackColor = true;
            // 
            // dgvPerformaPetani
            // 
            dgvPerformaPetani.AllowUserToAddRows = false;
            dgvPerformaPetani.AllowUserToDeleteRows = false;
            dgvPerformaPetani.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPerformaPetani.Dock = DockStyle.Fill;
            dgvPerformaPetani.Location = new Point(0, 0);
            dgvPerformaPetani.Margin = new Padding(6, 6, 6, 6);
            dgvPerformaPetani.Name = "dgvPerformaPetani";
            dgvPerformaPetani.ReadOnly = true;
            dgvPerformaPetani.RowHeadersWidth = 51;
            dgvPerformaPetani.Size = new Size(1811, 1015);
            dgvPerformaPetani.TabIndex = 0;
            // 
            // tabRollup
            // 
            tabRollup.Controls.Add(dgvRollup);
            tabRollup.Location = new Point(8, 46);
            tabRollup.Margin = new Padding(6, 6, 6, 6);
            tabRollup.Name = "tabRollup";
            tabRollup.Size = new Size(1811, 1015);
            tabRollup.TabIndex = 3;
            tabRollup.Text = "Akumulasi Berat (Rollup)";
            tabRollup.UseVisualStyleBackColor = true;
            // 
            // dgvRollup
            // 
            dgvRollup.AllowUserToAddRows = false;
            dgvRollup.AllowUserToDeleteRows = false;
            dgvRollup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRollup.Dock = DockStyle.Fill;
            dgvRollup.Location = new Point(0, 0);
            dgvRollup.Margin = new Padding(6, 6, 6, 6);
            dgvRollup.Name = "dgvRollup";
            dgvRollup.ReadOnly = true;
            dgvRollup.RowHeadersWidth = 51;
            dgvRollup.Size = new Size(1811, 1015);
            dgvRollup.TabIndex = 0;
            // 
            // tabCube
            // 
            tabCube.Controls.Add(dgvCube);
            tabCube.Location = new Point(8, 46);
            tabCube.Margin = new Padding(6, 6, 6, 6);
            tabCube.Name = "tabCube";
            tabCube.Size = new Size(1811, 1015);
            tabCube.TabIndex = 4;
            tabCube.Text = "Statistik Produk (Cube)";
            tabCube.UseVisualStyleBackColor = true;
            // 
            // dgvCube
            // 
            dgvCube.AllowUserToAddRows = false;
            dgvCube.AllowUserToDeleteRows = false;
            dgvCube.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCube.Dock = DockStyle.Fill;
            dgvCube.Location = new Point(0, 0);
            dgvCube.Margin = new Padding(6, 6, 6, 6);
            dgvCube.Name = "dgvCube";
            dgvCube.ReadOnly = true;
            dgvCube.RowHeadersWidth = 51;
            dgvCube.Size = new Size(1811, 1015);
            dgvCube.TabIndex = 0;
            // 
            // tabKeuangan
            // 
            tabKeuangan.Controls.Add(dgvKeuangan);
            tabKeuangan.Location = new Point(8, 46);
            tabKeuangan.Margin = new Padding(6, 6, 6, 6);
            tabKeuangan.Name = "tabKeuangan";
            tabKeuangan.Size = new Size(1811, 1015);
            tabKeuangan.TabIndex = 5;
            tabKeuangan.Text = "Laporan Komisi (Grouping Sets)";
            tabKeuangan.UseVisualStyleBackColor = true;
            // 
            // dgvKeuangan
            // 
            dgvKeuangan.AllowUserToAddRows = false;
            dgvKeuangan.AllowUserToDeleteRows = false;
            dgvKeuangan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKeuangan.Dock = DockStyle.Fill;
            dgvKeuangan.Location = new Point(0, 0);
            dgvKeuangan.Margin = new Padding(6, 6, 6, 6);
            dgvKeuangan.Name = "dgvKeuangan";
            dgvKeuangan.ReadOnly = true;
            dgvKeuangan.RowHeadersWidth = 51;
            dgvKeuangan.Size = new Size(1811, 1015);
            dgvKeuangan.TabIndex = 0;
            // 
            // tabSubqueryHarga
            // 
            tabSubqueryHarga.Controls.Add(dgvSubqueryHarga);
            tabSubqueryHarga.Location = new Point(8, 46);
            tabSubqueryHarga.Margin = new Padding(6, 6, 6, 6);
            tabSubqueryHarga.Name = "tabSubqueryHarga";
            tabSubqueryHarga.Size = new Size(1811, 1015);
            tabSubqueryHarga.TabIndex = 6;
            tabSubqueryHarga.Text = "Kopi Premium (Subquery)";
            tabSubqueryHarga.UseVisualStyleBackColor = true;
            // 
            // dgvSubqueryHarga
            // 
            dgvSubqueryHarga.AllowUserToAddRows = false;
            dgvSubqueryHarga.AllowUserToDeleteRows = false;
            dgvSubqueryHarga.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubqueryHarga.Dock = DockStyle.Fill;
            dgvSubqueryHarga.Location = new Point(0, 0);
            dgvSubqueryHarga.Margin = new Padding(6, 6, 6, 6);
            dgvSubqueryHarga.Name = "dgvSubqueryHarga";
            dgvSubqueryHarga.ReadOnly = true;
            dgvSubqueryHarga.RowHeadersWidth = 51;
            dgvSubqueryHarga.Size = new Size(1811, 1015);
            dgvSubqueryHarga.TabIndex = 0;
            // 
            // tabBidTertinggi
            // 
            tabBidTertinggi.Controls.Add(dgvBidTertinggi);
            tabBidTertinggi.Location = new Point(8, 46);
            tabBidTertinggi.Margin = new Padding(6, 6, 6, 6);
            tabBidTertinggi.Name = "tabBidTertinggi";
            tabBidTertinggi.Size = new Size(1811, 1015);
            tabBidTertinggi.TabIndex = 7;
            tabBidTertinggi.Text = "Bid Tertinggi (View)";
            tabBidTertinggi.UseVisualStyleBackColor = true;
            // 
            // dgvBidTertinggi
            // 
            dgvBidTertinggi.AllowUserToAddRows = false;
            dgvBidTertinggi.AllowUserToDeleteRows = false;
            dgvBidTertinggi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBidTertinggi.Dock = DockStyle.Fill;
            dgvBidTertinggi.Location = new Point(0, 0);
            dgvBidTertinggi.Margin = new Padding(6, 6, 6, 6);
            dgvBidTertinggi.Name = "dgvBidTertinggi";
            dgvBidTertinggi.ReadOnly = true;
            dgvBidTertinggi.RowHeadersWidth = 51;
            dgvBidTertinggi.Size = new Size(1811, 1015);
            dgvBidTertinggi.TabIndex = 0;
            // 
            // tabUnionLinimasa
            // 
            tabUnionLinimasa.Controls.Add(dgvUnionLinimasa);
            tabUnionLinimasa.Location = new Point(8, 46);
            tabUnionLinimasa.Margin = new Padding(6, 6, 6, 6);
            tabUnionLinimasa.Name = "tabUnionLinimasa";
            tabUnionLinimasa.Size = new Size(1811, 1015);
            tabUnionLinimasa.TabIndex = 8;
            tabUnionLinimasa.Text = "Linimasa Aktivitas (Union)";
            tabUnionLinimasa.UseVisualStyleBackColor = true;
            // 
            // dgvUnionLinimasa
            // 
            dgvUnionLinimasa.AllowUserToAddRows = false;
            dgvUnionLinimasa.AllowUserToDeleteRows = false;
            dgvUnionLinimasa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUnionLinimasa.Dock = DockStyle.Fill;
            dgvUnionLinimasa.Location = new Point(0, 0);
            dgvUnionLinimasa.Margin = new Padding(6, 6, 6, 6);
            dgvUnionLinimasa.Name = "dgvUnionLinimasa";
            dgvUnionLinimasa.ReadOnly = true;
            dgvUnionLinimasa.RowHeadersWidth = 51;
            dgvUnionLinimasa.Size = new Size(1811, 1015);
            dgvUnionLinimasa.TabIndex = 0;
            // 
            // tabIntersectMultiRole
            // 
            tabIntersectMultiRole.Controls.Add(dgvIntersectMultiRole);
            tabIntersectMultiRole.Location = new Point(8, 46);
            tabIntersectMultiRole.Margin = new Padding(6, 6, 6, 6);
            tabIntersectMultiRole.Name = "tabIntersectMultiRole";
            tabIntersectMultiRole.Size = new Size(1811, 1015);
            tabIntersectMultiRole.TabIndex = 9;
            tabIntersectMultiRole.Text = "Pengguna Multi-Role (Intersect)";
            tabIntersectMultiRole.UseVisualStyleBackColor = true;
            // 
            // dgvIntersectMultiRole
            // 
            dgvIntersectMultiRole.AllowUserToAddRows = false;
            dgvIntersectMultiRole.AllowUserToDeleteRows = false;
            dgvIntersectMultiRole.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIntersectMultiRole.Dock = DockStyle.Fill;
            dgvIntersectMultiRole.Location = new Point(0, 0);
            dgvIntersectMultiRole.Margin = new Padding(6, 6, 6, 6);
            dgvIntersectMultiRole.Name = "dgvIntersectMultiRole";
            dgvIntersectMultiRole.ReadOnly = true;
            dgvIntersectMultiRole.RowHeadersWidth = 51;
            dgvIntersectMultiRole.Size = new Size(1811, 1015);
            dgvIntersectMultiRole.TabIndex = 0;
            // 
            // tabExceptPembeliBelumBid
            // 
            tabExceptPembeliBelumBid.Controls.Add(dgvExceptPembeliBelumBid);
            tabExceptPembeliBelumBid.Location = new Point(8, 46);
            tabExceptPembeliBelumBid.Margin = new Padding(6, 6, 6, 6);
            tabExceptPembeliBelumBid.Name = "tabExceptPembeliBelumBid";
            tabExceptPembeliBelumBid.Size = new Size(1811, 1015);
            tabExceptPembeliBelumBid.TabIndex = 10;
            tabExceptPembeliBelumBid.Text = "Pembeli Pasif (Except)";
            tabExceptPembeliBelumBid.UseVisualStyleBackColor = true;
            // 
            // dgvExceptPembeliBelumBid
            // 
            dgvExceptPembeliBelumBid.AllowUserToAddRows = false;
            dgvExceptPembeliBelumBid.AllowUserToDeleteRows = false;
            dgvExceptPembeliBelumBid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExceptPembeliBelumBid.Dock = DockStyle.Fill;
            dgvExceptPembeliBelumBid.Location = new Point(0, 0);
            dgvExceptPembeliBelumBid.Margin = new Padding(6, 6, 6, 6);
            dgvExceptPembeliBelumBid.Name = "dgvExceptPembeliBelumBid";
            dgvExceptPembeliBelumBid.ReadOnly = true;
            dgvExceptPembeliBelumBid.RowHeadersWidth = 51;
            dgvExceptPembeliBelumBid.Size = new Size(1811, 1015);
            dgvExceptPembeliBelumBid.TabIndex = 0;
            // 
            // tabSubqueryBid
            // 
            tabSubqueryBid.Controls.Add(dgvSubqueryBid);
            tabSubqueryBid.Location = new Point(8, 46);
            tabSubqueryBid.Margin = new Padding(6, 6, 6, 6);
            tabSubqueryBid.Name = "tabSubqueryBid";
            tabSubqueryBid.Size = new Size(1811, 1015);
            tabSubqueryBid.TabIndex = 11;
            tabSubqueryBid.Text = "Bid Tinggi (Subquery)";
            tabSubqueryBid.UseVisualStyleBackColor = true;
            // 
            // dgvSubqueryBid
            // 
            dgvSubqueryBid.AllowUserToAddRows = false;
            dgvSubqueryBid.AllowUserToDeleteRows = false;
            dgvSubqueryBid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubqueryBid.Dock = DockStyle.Fill;
            dgvSubqueryBid.Location = new Point(0, 0);
            dgvSubqueryBid.Margin = new Padding(6, 6, 6, 6);
            dgvSubqueryBid.Name = "dgvSubqueryBid";
            dgvSubqueryBid.ReadOnly = true;
            dgvSubqueryBid.RowHeadersWidth = 51;
            dgvSubqueryBid.Size = new Size(1811, 1015);
            dgvSubqueryBid.TabIndex = 0;
            // 
            // FormStatistikLaporan
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1827, 1197);
            Controls.Add(tabControl1);
            Controls.Add(panelHeader);
            Margin = new Padding(6, 6, 6, 6);
            Name = "FormStatistikLaporan";
            Text = "Statistik & Laporan Analitis";
            Load += FormStatistikLaporan_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabProdukDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProdukDetail).EndInit();
            tabKopiPopuler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKopiPopuler).EndInit();
            tabPerformaPetani.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPerformaPetani).EndInit();
            tabRollup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRollup).EndInit();
            tabCube.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCube).EndInit();
            tabKeuangan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKeuangan).EndInit();
            tabSubqueryHarga.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSubqueryHarga).EndInit();
            tabBidTertinggi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBidTertinggi).EndInit();
            tabUnionLinimasa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUnionLinimasa).EndInit();
            tabIntersectMultiRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvIntersectMultiRole).EndInit();
            tabExceptPembeliBelumBid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvExceptPembeliBelumBid).EndInit();
            tabSubqueryBid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSubqueryBid).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabProdukDetail;
        private System.Windows.Forms.DataGridView dgvProdukDetail;
        private System.Windows.Forms.TabPage tabKopiPopuler;
        private System.Windows.Forms.DataGridView dgvKopiPopuler;
        private System.Windows.Forms.TabPage tabPerformaPetani;
        private System.Windows.Forms.DataGridView dgvPerformaPetani;
        private System.Windows.Forms.TabPage tabRollup;
        private System.Windows.Forms.DataGridView dgvRollup;
        private System.Windows.Forms.TabPage tabCube;
        private System.Windows.Forms.DataGridView dgvCube;
        private System.Windows.Forms.TabPage tabKeuangan;
        private System.Windows.Forms.DataGridView dgvKeuangan;
        private System.Windows.Forms.TabPage tabSubqueryHarga;
        private System.Windows.Forms.DataGridView dgvSubqueryHarga;
        private System.Windows.Forms.TabPage tabBidTertinggi;
        private System.Windows.Forms.DataGridView dgvBidTertinggi;
        private System.Windows.Forms.TabPage tabUnionLinimasa;
        private System.Windows.Forms.DataGridView dgvUnionLinimasa;
        private System.Windows.Forms.TabPage tabIntersectMultiRole;
        private System.Windows.Forms.DataGridView dgvIntersectMultiRole;
        private System.Windows.Forms.TabPage tabExceptPembeliBelumBid;
        private System.Windows.Forms.DataGridView dgvExceptPembeliBelumBid;
        private System.Windows.Forms.TabPage tabSubqueryBid;
        private System.Windows.Forms.DataGridView dgvSubqueryBid;
    }
}
