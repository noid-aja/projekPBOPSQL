using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Forms.AdminForm
{
    public partial class FormLelang : Form
    {
        public FormLelang()
        {
            InitializeComponent();
            LoadLelang();
            LoadProdukSiapLelang();
        }

        private void LoadLelang()
        {
            try
            {
                using var conn = ConnectDB.GetConnection();
                string query = @"
                    select l.id_lelang, p.nama_produk, l.bid_minimum,
                           l.tgl_mulai, l.tgl_akhir, l.lokasi_lelang, l.status_lelang as status,
                           COALESCE(MAX(b.nominal), 0) as bid_tertinggi,
                           COUNT(b.id_bid) as jumlah_bid
                    from kapten.lelang l
                    join kapten.produk_kopi p on p.id_produk = l.id_produk
                    left join kapten.bid b on b.id_lelang = l.id_lelang
                    group by l.id_lelang, p.nama_produk, l.status_lelang
                    order by l.id_lelang desc";
                var da = new NpgsqlDataAdapter(query, conn);
                var dt = new DataTable();
                da.Fill(dt);
                dgvLelang.DataSource = dt;
                if (dgvLelang.Columns.Count > 0)
                    dgvLelang.Columns[dgvLelang.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat lelang: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProdukSiapLelang()
        {
            try
            {
                cmbProduk.Items.Clear();
                cmbProduk.Items.Add("-- Pilih Produk --");
                var list = LelangContext.AmbilProdukSiapLelang();
                foreach (var p in list)
                    cmbProduk.Items.Add(new ProdukItem(p.IdProduk, p.NamaProduk));
                cmbProduk.SelectedIndex = 0;
                cmbProduk.DisplayMember = "Display";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load produk: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBukaLelang_Click(object sender, EventArgs e)
        {
            if (cmbProduk.SelectedIndex <= 0 || cmbProduk.SelectedItem is not ProdukItem item)
            {
                MessageBox.Show("Pilih produk yang akan dilelang!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string? lokasi = string.IsNullOrWhiteSpace(tbLokasi.Text) ? null : tbLokasi.Text.Trim();
            bool ok = LelangContext.EksekusiBukaLelang(item.IdProduk, lokasi);
            if (ok)
            {
                MessageBox.Show("Lelang berhasil dibuka! Durasi 3 menit.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLelang();
                LoadProdukSiapLelang();
                tbLokasi.Clear();
            }
        }

        private void btnTutupLelang_Click(object sender, EventArgs e)
        {
            if (dgvLelang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih lelang yang ingin ditutup.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idLelang = Convert.ToInt32(dgvLelang.SelectedRows[0].Cells["id_lelang"].Value);
            string status = dgvLelang.SelectedRows[0].Cells["status"].Value?.ToString() ?? "";
            if (status.ToLower() != "berlangsung")
            {
                MessageBox.Show("Hanya lelang yang sedang berlangsung yang bisa ditutup.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Yakin tutup lelang ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand(@"
                    update kapten.lelang set status_lelang = 'selesai', tgl_akhir = NOW()
                    where id_lelang = @id", conn);
                cmd.Parameters.AddWithValue("@id", idLelang);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Lelang berhasil ditutup.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLelang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal tutup lelang: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLelang();
            LoadProdukSiapLelang();
        }

        private class ProdukItem
        {
            public int IdProduk { get; }
            public string Display { get; }
            public ProdukItem(int id, string nama) { IdProduk = id; Display = $"[{id}] {nama}"; }
            public override string ToString() => Display;
        }
    }
}
