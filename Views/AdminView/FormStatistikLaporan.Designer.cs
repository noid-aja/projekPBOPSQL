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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProdukDetail = new System.Windows.Forms.TabPage();
            this.dgvProdukDetail = new System.Windows.Forms.DataGridView();
            this.tabKopiPopuler = new System.Windows.Forms.TabPage();
            this.dgvKopiPopuler = new System.Windows.Forms.DataGridView();
            this.tabPerformaPetani = new System.Windows.Forms.TabPage();
            this.dgvPerformaPetani = new System.Windows.Forms.DataGridView();
            this.tabRollup = new System.Windows.Forms.TabPage();
            this.dgvRollup = new System.Windows.Forms.DataGridView();
            this.tabCube = new System.Windows.Forms.TabPage();
            this.dgvCube = new System.Windows.Forms.DataGridView();
            this.tabKeuangan = new System.Windows.Forms.TabPage();
            this.dgvKeuangan = new System.Windows.Forms.DataGridView();
            this.tabSubqueryHarga = new System.Windows.Forms.TabPage();
            this.dgvSubqueryHarga = new System.Windows.Forms.DataGridView();
            this.tabBidTertinggi = new System.Windows.Forms.TabPage();
            this.dgvBidTertinggi = new System.Windows.Forms.DataGridView();
            this.tabUnionLinimasa = new System.Windows.Forms.TabPage();
            this.dgvUnionLinimasa = new System.Windows.Forms.DataGridView();
            this.tabIntersectMultiRole = new System.Windows.Forms.TabPage();
            this.dgvIntersectMultiRole = new System.Windows.Forms.DataGridView();
            this.tabExceptPembeliBelumBid = new System.Windows.Forms.TabPage();
            this.dgvExceptPembeliBelumBid = new System.Windows.Forms.DataGridView();
            this.tabSubqueryBid = new System.Windows.Forms.TabPage();
            this.dgvSubqueryBid = new System.Windows.Forms.DataGridView();
            this.panelHeader.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabProdukDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdukDetail)).BeginInit();
            this.tabKopiPopuler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKopiPopuler)).BeginInit();
            this.tabPerformaPetani.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerformaPetani)).BeginInit();
            this.tabRollup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRollup)).BeginInit();
            this.tabCube.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCube)).BeginInit();
            this.tabKeuangan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeuangan)).BeginInit();
            this.tabSubqueryHarga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubqueryHarga)).BeginInit();
            this.tabBidTertinggi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBidTertinggi)).BeginInit();
            this.tabUnionLinimasa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnionLinimasa)).BeginInit();
            this.tabIntersectMultiRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntersectMultiRole)).BeginInit();
            this.tabExceptPembeliBelumBid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExceptPembeliBelumBid)).BeginInit();
            this.tabSubqueryBid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubqueryBid)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(214)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(984, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(37)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(15, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(262, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 Statistik & Laporan Analitis";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabProdukDetail);
            this.tabControl1.Controls.Add(this.tabKopiPopuler);
            this.tabControl1.Controls.Add(this.tabPerformaPetani);
            this.tabControl1.Controls.Add(this.tabRollup);
            this.tabControl1.Controls.Add(this.tabCube);
            this.tabControl1.Controls.Add(this.tabKeuangan);
            this.tabControl1.Controls.Add(this.tabSubqueryHarga);
            this.tabControl1.Controls.Add(this.tabBidTertinggi);
            this.tabControl1.Controls.Add(this.tabUnionLinimasa);
            this.tabControl1.Controls.Add(this.tabIntersectMultiRole);
            this.tabControl1.Controls.Add(this.tabExceptPembeliBelumBid);
            this.tabControl1.Controls.Add(this.tabSubqueryBid);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 501);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabProdukDetail
            // 
            this.tabProdukDetail.Controls.Add(this.dgvProdukDetail);
            this.tabProdukDetail.Location = new System.Drawing.Point(4, 24);
            this.tabProdukDetail.Name = "tabProdukDetail";
            this.tabProdukDetail.Size = new System.Drawing.Size(976, 473);
            this.tabProdukDetail.TabIndex = 0;
            this.tabProdukDetail.Text = "Katalog Detail (View)";
            this.tabProdukDetail.UseVisualStyleBackColor = true;
            // 
            // dgvProdukDetail
            // 
            this.dgvProdukDetail.AllowUserToAddRows = false;
            this.dgvProdukDetail.AllowUserToDeleteRows = false;
            this.dgvProdukDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdukDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdukDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvProdukDetail.Name = "dgvProdukDetail";
            this.dgvProdukDetail.ReadOnly = true;
            this.dgvProdukDetail.RowHeadersWidth = 51;
            this.dgvProdukDetail.Size = new System.Drawing.Size(976, 473);
            this.dgvProdukDetail.TabIndex = 0;
            // 
            // tabKopiPopuler
            // 
            this.tabKopiPopuler.Controls.Add(this.dgvKopiPopuler);
            this.tabKopiPopuler.Location = new System.Drawing.Point(4, 24);
            this.tabKopiPopuler.Name = "tabKopiPopuler";
            this.tabKopiPopuler.Size = new System.Drawing.Size(976, 473);
            this.tabKopiPopuler.TabIndex = 1;
            this.tabKopiPopuler.Text = "Kopi Terpopuler (Group)";
            this.tabKopiPopuler.UseVisualStyleBackColor = true;
            // 
            // dgvKopiPopuler
            // 
            this.dgvKopiPopuler.AllowUserToAddRows = false;
            this.dgvKopiPopuler.AllowUserToDeleteRows = false;
            this.dgvKopiPopuler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKopiPopuler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKopiPopuler.Location = new System.Drawing.Point(0, 0);
            this.dgvKopiPopuler.Name = "dgvKopiPopuler";
            this.dgvKopiPopuler.ReadOnly = true;
            this.dgvKopiPopuler.RowHeadersWidth = 51;
            this.dgvKopiPopuler.Size = new System.Drawing.Size(976, 473);
            this.dgvKopiPopuler.TabIndex = 0;
            // 
            // tabPerformaPetani
            // 
            this.tabPerformaPetani.Controls.Add(this.dgvPerformaPetani);
            this.tabPerformaPetani.Location = new System.Drawing.Point(4, 24);
            this.tabPerformaPetani.Name = "tabPerformaPetani";
            this.tabPerformaPetani.Size = new System.Drawing.Size(976, 473);
            this.tabPerformaPetani.TabIndex = 2;
            this.tabPerformaPetani.Text = "Performa Petani (Group)";
            this.tabPerformaPetani.UseVisualStyleBackColor = true;
            // 
            // dgvPerformaPetani
            // 
            this.dgvPerformaPetani.AllowUserToAddRows = false;
            this.dgvPerformaPetani.AllowUserToDeleteRows = false;
            this.dgvPerformaPetani.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerformaPetani.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPerformaPetani.Location = new System.Drawing.Point(0, 0);
            this.dgvPerformaPetani.Name = "dgvPerformaPetani";
            this.dgvPerformaPetani.ReadOnly = true;
            this.dgvPerformaPetani.RowHeadersWidth = 51;
            this.dgvPerformaPetani.Size = new System.Drawing.Size(976, 473);
            this.dgvPerformaPetani.TabIndex = 0;
            // 
            // tabRollup
            // 
            this.tabRollup.Controls.Add(this.dgvRollup);
            this.tabRollup.Location = new System.Drawing.Point(4, 24);
            this.tabRollup.Name = "tabRollup";
            this.tabRollup.Size = new System.Drawing.Size(976, 473);
            this.tabRollup.TabIndex = 3;
            this.tabRollup.Text = "Akumulasi Berat (Rollup)";
            this.tabRollup.UseVisualStyleBackColor = true;
            // 
            // dgvRollup
            // 
            this.dgvRollup.AllowUserToAddRows = false;
            this.dgvRollup.AllowUserToDeleteRows = false;
            this.dgvRollup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRollup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRollup.Location = new System.Drawing.Point(0, 0);
            this.dgvRollup.Name = "dgvRollup";
            this.dgvRollup.ReadOnly = true;
            this.dgvRollup.RowHeadersWidth = 51;
            this.dgvRollup.Size = new System.Drawing.Size(976, 473);
            this.dgvRollup.TabIndex = 0;
            // 
            // tabCube
            // 
            this.tabCube.Controls.Add(this.dgvCube);
            this.tabCube.Location = new System.Drawing.Point(4, 24);
            this.tabCube.Name = "tabCube";
            this.tabCube.Size = new System.Drawing.Size(976, 473);
            this.tabCube.TabIndex = 4;
            this.tabCube.Text = "Statistik Produk (Cube)";
            this.tabCube.UseVisualStyleBackColor = true;
            // 
            // dgvCube
            // 
            this.dgvCube.AllowUserToAddRows = false;
            this.dgvCube.AllowUserToDeleteRows = false;
            this.dgvCube.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCube.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCube.Location = new System.Drawing.Point(0, 0);
            this.dgvCube.Name = "dgvCube";
            this.dgvCube.ReadOnly = true;
            this.dgvCube.RowHeadersWidth = 51;
            this.dgvCube.Size = new System.Drawing.Size(976, 473);
            this.dgvCube.TabIndex = 0;
            // 
            // tabKeuangan
            // 
            this.tabKeuangan.Controls.Add(this.dgvKeuangan);
            this.tabKeuangan.Location = new System.Drawing.Point(4, 24);
            this.tabKeuangan.Name = "tabKeuangan";
            this.tabKeuangan.Size = new System.Drawing.Size(976, 473);
            this.tabKeuangan.TabIndex = 5;
            this.tabKeuangan.Text = "Laporan Komisi (Grouping Sets)";
            this.tabKeuangan.UseVisualStyleBackColor = true;
            // 
            // dgvKeuangan
            // 
            this.dgvKeuangan.AllowUserToAddRows = false;
            this.dgvKeuangan.AllowUserToDeleteRows = false;
            this.dgvKeuangan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKeuangan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKeuangan.Location = new System.Drawing.Point(0, 0);
            this.dgvKeuangan.Name = "dgvKeuangan";
            this.dgvKeuangan.ReadOnly = true;
            this.dgvKeuangan.RowHeadersWidth = 51;
            this.dgvKeuangan.Size = new System.Drawing.Size(976, 473);
            this.dgvKeuangan.TabIndex = 0;
            // 
            // tabSubqueryHarga
            // 
            this.tabSubqueryHarga.Controls.Add(this.dgvSubqueryHarga);
            this.tabSubqueryHarga.Location = new System.Drawing.Point(4, 24);
            this.tabSubqueryHarga.Name = "tabSubqueryHarga";
            this.tabSubqueryHarga.Size = new System.Drawing.Size(976, 473);
            this.tabSubqueryHarga.TabIndex = 6;
            this.tabSubqueryHarga.Text = "Kopi Premium (Subquery)";
            this.tabSubqueryHarga.UseVisualStyleBackColor = true;
            // 
            // dgvSubqueryHarga
            // 
            this.dgvSubqueryHarga.AllowUserToAddRows = false;
            this.dgvSubqueryHarga.AllowUserToDeleteRows = false;
            this.dgvSubqueryHarga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubqueryHarga.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubqueryHarga.Location = new System.Drawing.Point(0, 0);
            this.dgvSubqueryHarga.Name = "dgvSubqueryHarga";
            this.dgvSubqueryHarga.ReadOnly = true;
            this.dgvSubqueryHarga.RowHeadersWidth = 51;
            this.dgvSubqueryHarga.Size = new System.Drawing.Size(976, 473);
            this.dgvSubqueryHarga.TabIndex = 0;
            // 
            // tabBidTertinggi
            // 
            this.tabBidTertinggi.Controls.Add(this.dgvBidTertinggi);
            this.tabBidTertinggi.Location = new System.Drawing.Point(4, 24);
            this.tabBidTertinggi.Name = "tabBidTertinggi";
            this.tabBidTertinggi.Size = new System.Drawing.Size(976, 473);
            this.tabBidTertinggi.TabIndex = 7;
            this.tabBidTertinggi.Text = "Bid Tertinggi (View)";
            this.tabBidTertinggi.UseVisualStyleBackColor = true;
            // 
            // dgvBidTertinggi
            // 
            this.dgvBidTertinggi.AllowUserToAddRows = false;
            this.dgvBidTertinggi.AllowUserToDeleteRows = false;
            this.dgvBidTertinggi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBidTertinggi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBidTertinggi.Location = new System.Drawing.Point(0, 0);
            this.dgvBidTertinggi.Name = "dgvBidTertinggi";
            this.dgvBidTertinggi.ReadOnly = true;
            this.dgvBidTertinggi.RowHeadersWidth = 51;
            this.dgvBidTertinggi.Size = new System.Drawing.Size(976, 473);
            this.dgvBidTertinggi.TabIndex = 0;
            // 
            // tabUnionLinimasa
            // 
            this.tabUnionLinimasa.Controls.Add(this.dgvUnionLinimasa);
            this.tabUnionLinimasa.Location = new System.Drawing.Point(4, 24);
            this.tabUnionLinimasa.Name = "tabUnionLinimasa";
            this.tabUnionLinimasa.Size = new System.Drawing.Size(976, 473);
            this.tabUnionLinimasa.TabIndex = 8;
            this.tabUnionLinimasa.Text = "Linimasa Aktivitas (Union)";
            this.tabUnionLinimasa.UseVisualStyleBackColor = true;
            // 
            // dgvUnionLinimasa
            // 
            this.dgvUnionLinimasa.AllowUserToAddRows = false;
            this.dgvUnionLinimasa.AllowUserToDeleteRows = false;
            this.dgvUnionLinimasa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnionLinimasa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUnionLinimasa.Location = new System.Drawing.Point(0, 0);
            this.dgvUnionLinimasa.Name = "dgvUnionLinimasa";
            this.dgvUnionLinimasa.ReadOnly = true;
            this.dgvUnionLinimasa.RowHeadersWidth = 51;
            this.dgvUnionLinimasa.Size = new System.Drawing.Size(976, 473);
            this.dgvUnionLinimasa.TabIndex = 0;
            // 
            // tabIntersectMultiRole
            // 
            this.tabIntersectMultiRole.Controls.Add(this.dgvIntersectMultiRole);
            this.tabIntersectMultiRole.Location = new System.Drawing.Point(4, 24);
            this.tabIntersectMultiRole.Name = "tabIntersectMultiRole";
            this.tabIntersectMultiRole.Size = new System.Drawing.Size(976, 473);
            this.tabIntersectMultiRole.TabIndex = 9;
            this.tabIntersectMultiRole.Text = "Pengguna Multi-Role (Intersect)";
            this.tabIntersectMultiRole.UseVisualStyleBackColor = true;
            // 
            // dgvIntersectMultiRole
            // 
            this.dgvIntersectMultiRole.AllowUserToAddRows = false;
            this.dgvIntersectMultiRole.AllowUserToDeleteRows = false;
            this.dgvIntersectMultiRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIntersectMultiRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIntersectMultiRole.Location = new System.Drawing.Point(0, 0);
            this.dgvIntersectMultiRole.Name = "dgvIntersectMultiRole";
            this.dgvIntersectMultiRole.ReadOnly = true;
            this.dgvIntersectMultiRole.RowHeadersWidth = 51;
            this.dgvIntersectMultiRole.Size = new System.Drawing.Size(976, 473);
            this.dgvIntersectMultiRole.TabIndex = 0;
            // 
            // tabExceptPembeliBelumBid
            // 
            this.tabExceptPembeliBelumBid.Controls.Add(this.dgvExceptPembeliBelumBid);
            this.tabExceptPembeliBelumBid.Location = new System.Drawing.Point(4, 24);
            this.tabExceptPembeliBelumBid.Name = "tabExceptPembeliBelumBid";
            this.tabExceptPembeliBelumBid.Size = new System.Drawing.Size(976, 473);
            this.tabExceptPembeliBelumBid.TabIndex = 10;
            this.tabExceptPembeliBelumBid.Text = "Pembeli Pasif (Except)";
            this.tabExceptPembeliBelumBid.UseVisualStyleBackColor = true;
            // 
            // dgvExceptPembeliBelumBid
            // 
            this.dgvExceptPembeliBelumBid.AllowUserToAddRows = false;
            this.dgvExceptPembeliBelumBid.AllowUserToDeleteRows = false;
            this.dgvExceptPembeliBelumBid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExceptPembeliBelumBid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExceptPembeliBelumBid.Location = new System.Drawing.Point(0, 0);
            this.dgvExceptPembeliBelumBid.Name = "dgvExceptPembeliBelumBid";
            this.dgvExceptPembeliBelumBid.ReadOnly = true;
            this.dgvExceptPembeliBelumBid.RowHeadersWidth = 51;
            this.dgvExceptPembeliBelumBid.Size = new System.Drawing.Size(976, 473);
            this.dgvExceptPembeliBelumBid.TabIndex = 0;
            // 
            // tabSubqueryBid
            // 
            this.tabSubqueryBid.Controls.Add(this.dgvSubqueryBid);
            this.tabSubqueryBid.Location = new System.Drawing.Point(4, 24);
            this.tabSubqueryBid.Name = "tabSubqueryBid";
            this.tabSubqueryBid.Size = new System.Drawing.Size(976, 473);
            this.tabSubqueryBid.TabIndex = 11;
            this.tabSubqueryBid.Text = "Bid Tinggi (Subquery)";
            this.tabSubqueryBid.UseVisualStyleBackColor = true;
            // 
            // dgvSubqueryBid
            // 
            this.dgvSubqueryBid.AllowUserToAddRows = false;
            this.dgvSubqueryBid.AllowUserToDeleteRows = false;
            this.dgvSubqueryBid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubqueryBid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubqueryBid.Location = new System.Drawing.Point(0, 0);
            this.dgvSubqueryBid.Name = "dgvSubqueryBid";
            this.dgvSubqueryBid.ReadOnly = true;
            this.dgvSubqueryBid.RowHeadersWidth = 51;
            this.dgvSubqueryBid.Size = new System.Drawing.Size(976, 473);
            this.dgvSubqueryBid.TabIndex = 0;
            // 
            // FormStatistikLaporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelHeader);
            this.Name = "FormStatistikLaporan";
            this.Text = "Statistik & Laporan Analitis";
            this.Load += new System.EventHandler(this.FormStatistikLaporan_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabProdukDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdukDetail)).EndInit();
            this.tabKopiPopuler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKopiPopuler)).EndInit();
            this.tabPerformaPetani.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerformaPetani)).EndInit();
            this.tabRollup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRollup)).EndInit();
            this.tabCube.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCube)).EndInit();
            this.tabKeuangan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeuangan)).EndInit();
            this.tabSubqueryHarga.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubqueryHarga)).EndInit();
            this.tabBidTertinggi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBidTertinggi)).EndInit();
            this.tabUnionLinimasa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnionLinimasa)).EndInit();
            this.tabIntersectMultiRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntersectMultiRole)).EndInit();
            this.tabExceptPembeliBelumBid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExceptPembeliBelumBid)).EndInit();
            this.tabSubqueryBid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubqueryBid)).EndInit();
            this.ResumeLayout(false);
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
