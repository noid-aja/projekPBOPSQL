using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Controllers;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Views.AdminView
{
    public partial class FormLelang : Form
    {
        private readonly LelangController _lelangController = new LelangController();

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
                var dt = LelangContext.AmbilSemuaLelangDataTable();
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

            bool ok = _lelangController.ProsesBukaLelang(item.IdProduk, lokasi);
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

            bool ok = _lelangController.TutupLelangManual(idLelang);
            if (ok)
            {
                MessageBox.Show("Lelang berhasil ditutup.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLelang();
                LoadProdukSiapLelang();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLelang();
            LoadProdukSiapLelang();
        }

        private void btnLihatPeserta_Click(object sender, EventArgs e)
        {
            if (dgvLelang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih lelang terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idLelang = Convert.ToInt32(dgvLelang.SelectedRows[0].Cells["id_lelang"].Value);
            string namaProduk = dgvLelang.SelectedRows[0].Cells["nama_produk"].Value?.ToString() ?? "";

            var formDaftar = new FormDaftarPeserta(idLelang, namaProduk);
            formDaftar.ShowDialog();
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
