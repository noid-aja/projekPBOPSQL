using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Views.PetaniForm
{
    // ─────────────────────────────────────────────────────────────────
    // Form: Produk Saya (untuk Petani)
    // ─────────────────────────────────────────────────────────────────
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
                using var conn = ConnectDB.GetConnection();
                string query = @"
                    select p.id_produk, p.nama_produk,
                           j.nama_jenis as jenis,
                           p.berat_kg, p.harga_pengajuan, p.status_produk as status
                    from kapten.produk_kopi p
                    join kapten.jenis_kopi j on j.id_jenis = p.id_jenis
                    where p.id_petani = @idPetani
                    order by p.id_produk desc";
                var da = new NpgsqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@idPetani", _idPetani);
                var dt = new DataTable();
                da.Fill(dt);
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

    // ─────────────────────────────────────────────────────────────────
    // Form: Hasil QC (untuk Petani)
    // ─────────────────────────────────────────────────────────────────
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
                using var conn = ConnectDB.GetConnection();
                string query = @"
                    select p.nama_produk, i.nilai, i.harga_rekomendasi,
                           i.catatan, i.tgl_inspeksi, pk.status_produk as status_produk,
                           u.nama_lengkap as inspektor
                    from kapten.inspeksi i
                    join kapten.produk_kopi pk on pk.id_produk = i.id_produk
                    join kapten.produk_kopi p on p.id_produk = i.id_produk
                    join kapten.users u on u.id_user = i.id_inspektor
                    where p.id_petani = @idPetani
                    order by i.tgl_inspeksi desc";
                var da = new NpgsqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@idPetani", _idPetani);
                var dt = new DataTable();
                da.Fill(dt);
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

    // ─────────────────────────────────────────────────────────────────
    // Form: Jadwal Lelang (untuk Petani & Pembeli)
    // ─────────────────────────────────────────────────────────────────
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
                using var conn = ConnectDB.GetConnection();
                string query = @"
                    select l.id_lelang, p.nama_produk,
                           u.nama_lengkap as petani,
                           j.nama_jenis as jenis,
                           l.bid_minimum, l.tgl_mulai, l.tgl_akhir,
                           l.lokasi_lelang, l.status_lelang as status
                    from kapten.lelang l
                    join kapten.produk_kopi p on p.id_produk = l.id_produk
                    join kapten.users u on u.id_user = p.id_petani
                    join kapten.jenis_kopi j on j.id_jenis = p.id_jenis
                    order by l.tgl_mulai desc";
                var da = new NpgsqlDataAdapter(query, conn);
                var dt = new DataTable();
                da.Fill(dt);
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
