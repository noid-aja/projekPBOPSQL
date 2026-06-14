using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using WinFormsApp1.Controllers;
using WinFormsApp1.Helpers;
using Npgsql;

namespace WinFormsApp1.Forms.AdminForm
{
    public partial class Inspeksi : Form
    {
        // [Encapsulation] Aksi inspeksi dikelola controller, bukan langsung oleh Form
        private readonly InspeksiController _inspeksiController = new InspeksiController();

        public Inspeksi()
        {
            InitializeComponent();
            LoadPendingProducts();
        }

        private void Inspeksi_Load(object sender, EventArgs e)
        {
        }

        private void LoadPendingProducts()
        {
            try
            {
                using var conn = ConnectDB.GetConnection();
                string query = "select id_produk, nama_produk, id_petani, id_jenis, berat_kg, harga_pengajuan, status_produk from kapten.produk_kopi where status_produk = 'pending_inspeksi' order by id_produk";
                var da = new NpgsqlDataAdapter(query, conn);
                var dt = new DataTable();
                da.Fill(dt);
                dgvPending.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat produk: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPending_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            nudNilai.Value = 0;
            tbHargaRekomendasi.Text = string.Empty;
            tbCatatan.Text = string.Empty;
        }

        private string ComputeGrade(int nilai)
        {
            if (nilai >= 85 && nilai <= 100) return "A";
            if (nilai >= 80 && nilai <= 84) return "B";
            if (nilai >= 60 && nilai <= 79) return "C";
            return "D";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPendingProducts();
        }

        /// <summary>
        /// [Encapsulation] Submit QC tidak lagi berisi SQL langsung.
        /// Semua business logic (grade, status, update DB) ada di InspeksiController.
        /// </summary>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dgvPending.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih produk terlebih dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProduk = Convert.ToInt32(dgvPending.SelectedRows[0].Cells["id_produk"].Value);

            int nilai = (int)nudNilai.Value;
            decimal hargaRekomendasi = 0m;
            if (!string.IsNullOrWhiteSpace(tbHargaRekomendasi.Text))
            {
                if (!decimal.TryParse(tbHargaRekomendasi.Text, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out hargaRekomendasi))
                {
                    MessageBox.Show("Harga rekomendasi tidak valid", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbHargaRekomendasi.Focus();
                    return;
                }
            }

            string? catatan = string.IsNullOrWhiteSpace(tbCatatan.Text) ? null : tbCatatan.Text.Trim();
            bool isLolos = nilai >= 80;

            // [Encapsulation] Delegasikan ke InspeksiController
            bool sukses = _inspeksiController.KirimHasilQc(idProduk, nilai, hargaRekomendasi, catatan, isLolos);
            if (sukses)
            {
                string grade = ComputeGrade(nilai);
                string status = isLolos ? "lolos_qc" : "ditolak_qc";
                MessageBox.Show($"Inspeksi berhasil disimpan!\nGrade: {grade} | Status: {status}",
                    "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPendingProducts();
            }
        }
    }
}
