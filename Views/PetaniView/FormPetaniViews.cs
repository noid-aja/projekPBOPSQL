using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Views.PetaniView
{

    public class ProdukKopiPetani : Form
    {
        private readonly int _idPetani;
        private DataGridView dgvProduk;
        private Label lblTotal;

        public ProdukKopiPetani(int idPetani)
        {
            _idPetani = idPetani;
            BuildUI();
            LoadProduk();
        }

        private void BuildUI()
        {
            dgvProduk = new DataGridView
            {
                Location = new System.Drawing.Point(12, 55),
                Size = new System.Drawing.Size(960, 480),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false
            };

            var lblJudul = new Label
            {
                Text = "🌱 Produk Saya",
                Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(12, 12),
                Size = new System.Drawing.Size(280, 28)
            };

            lblTotal = new Label
            {
                Text = "Total: -",
                Location = new System.Drawing.Point(300, 18),
                Size = new System.Drawing.Size(200, 23),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };

            var btnRefresh = new Button
            {
                Text = "🔄 Refresh",
                Location = new System.Drawing.Point(510, 14),
                Size = new System.Drawing.Size(100, 28)
            };
            btnRefresh.Click += (s, e) => LoadProduk();

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(984, 552);
            Text = "Produk Saya";
            Controls.Add(lblJudul);
            Controls.Add(lblTotal);
            Controls.Add(btnRefresh);
            Controls.Add(dgvProduk);
        }

        private void InitializeComponent()
        {

        }

        private void LoadProduk()
        {
            try
            {
                var dt = Models.ProdukKopiContext.AmbilProdukPetaniUntukGrid(_idPetani);
                dgvProduk.DataSource = dt;
                if (dgvProduk.Columns.Count > 0)
                    dgvProduk.Columns[dgvProduk.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                lblTotal.Text = $"Total: {dt.Rows.Count} produk";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat produk: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class FormHasilQC : Form
    {
        private readonly int _idPetani;
        private DataGridView dgvQC;

        public FormHasilQC(int idPetani)
        {
            _idPetani = idPetani;
            BuildUI();
            LoadHasilQC();
        }

        private void BuildUI()
        {
            dgvQC = new DataGridView
            {
                Location = new System.Drawing.Point(12, 55),
                Size = new System.Drawing.Size(960, 480),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false
            };

            var lblJudul = new Label
            {
                Text = "🔍 Hasil QC Produk Saya",
                Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(12, 12),
                Size = new System.Drawing.Size(320, 28)
            };

            var btnRefresh = new Button
            {
                Text = "🔄 Refresh",
                Location = new System.Drawing.Point(340, 14),
                Size = new System.Drawing.Size(100, 28)
            };
            btnRefresh.Click += (s, e) => LoadHasilQC();

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(984, 552);
            Text = "Hasil QC";
            Controls.Add(lblJudul);
            Controls.Add(btnRefresh);
            Controls.Add(dgvQC);
        }

        private void LoadHasilQC()
        {
            try
            {
                var dt = Models.InspeksiContext.AmbilHasilQCPetani(_idPetani);
                dgvQC.DataSource = dt;
                if (dgvQC.Columns.Count > 0)
                    dgvQC.Columns[dgvQC.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat hasil QC: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class FormJadwalLelang : Form
    {
        private DataGridView dgvJadwal;

        public FormJadwalLelang()
        {
            BuildUI();
            LoadJadwal();
        }

        private void BuildUI()
        {
            dgvJadwal = new DataGridView
            {
                Location = new System.Drawing.Point(12, 55),
                Size = new System.Drawing.Size(960, 480),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false
            };

            var lblJudul = new Label
            {
                Text = "📅 Jadwal Lelang",
                Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(12, 12),
                Size = new System.Drawing.Size(280, 28)
            };

            var btnRefresh = new Button
            {
                Text = "🔄 Refresh",
                Location = new System.Drawing.Point(300, 14),
                Size = new System.Drawing.Size(100, 28)
            };
            btnRefresh.Click += (s, e) => LoadJadwal();

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(984, 552);
            Text = "Jadwal Lelang";
            Controls.Add(lblJudul);
            Controls.Add(btnRefresh);
            Controls.Add(dgvJadwal);
        }

        private void LoadJadwal()
        {
            try
            {
                var dt = Models.LelangContext.AmbilJadwalLelang();
                dgvJadwal.DataSource = dt;
                if (dgvJadwal.Columns.Count > 0)
                    dgvJadwal.Columns[dgvJadwal.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat jadwal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
