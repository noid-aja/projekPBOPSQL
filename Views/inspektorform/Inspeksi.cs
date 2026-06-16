using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using WinFormsApp1.Controllers;
using WinFormsApp1.Helpers;
using Npgsql;

namespace WinFormsApp1.Views.InspektorForm
{
    public partial class Inspeksi : Form
    {
        private readonly InspeksiController _inspeksiController = new InspeksiController();
        private Label lblResult = null!;
        private string currentMode = "input hasil inspeksi";

        public Inspeksi() : this("input hasil inspeksi")
        {
        }

        public Inspeksi(string mode)
        {
            InitializeComponent();
            currentMode = mode?.Trim().ToLowerInvariant() ?? "input hasil inspeksi";
            SetupRealTimeLabel();
            SetupModeUI();
            LoadPendingProducts();
        }

        private void SetupRealTimeLabel()
        {
            lblResult = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                ForeColor = Color.Yellow,
                Location = new Point(1270, 180),
                Name = "lblResult",
                Size = new Size(234, 40),
                Text = "Grade: - | Status: -"
            };
            panel1.Controls.Add(lblResult);
            nudNilai.ValueChanged += (s, e) => UpdateResultLabel();
            UpdateResultLabel();
        }

        private void UpdateResultLabel()
        {
            int nilai = (int)nudNilai.Value;
            string grade = ComputeGrade(nilai);
            string status = nilai >= 80 ? "Lolos QC" : "Ditolak QC";
            lblResult.Text = $"Grade: {grade} | Status: {status}";
            lblResult.ForeColor = nilai >= 80 ? Color.LightGreen : Color.LightCoral;
        }

        private void SetupModeUI()
        {
            switch (currentMode)
            {
                case "lihat produk pending":
                case "produk pending":
                    this.Text = "Lihat Produk Pending";
                    panel1.Visible = false;
                    dgvPending.Location = new Point(20, 20);
                    dgvPending.Height = this.ClientSize.Height - 40;
                    break;
                case "beri grade kopi":
                    this.Text = "Beri Grade Kopi";
                    lblResult.Text = "Grade: -";
                    nudNilai.Focus();
                    break;
                case "set status qc":
                    this.Text = "Set Status QC";
                    lblResult.Text = "Status: -";
                    nudNilai.Focus();
                    break;
                default:
                    this.Text = "Input Hasil Inspeksi";
                    break;
            }
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
            if (nilai >= 85) return "A";
            if (nilai >= 80) return "B";
            if (nilai >= 60) return "C";
            return "D";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPendingProducts();
        }

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

            bool sukses = _inspeksiController.KirimHasilQc(
                idProduk,
                nilai,
                hargaRekomendasi,
                catatan);
            if (sukses)
            {
                string grade = ComputeGrade(nilai);
                string status = isLolos ? "lolos_qc" : "ditolak_qc";
                MessageBox.Show($"Inspeksi berhasil disimpan!\nGrade: {grade} | Status: {status}",
                    "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPendingProducts();
            }
        }
        private void dgvPending_CellContentClick(object sender,DataGridViewCellEventArgs e)
        {
            // Kosongkan kalau event ini memang belum dipakai.
        }
    }
}
