using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Views.AdminForm
{
    public partial class ProdukKopi : Form
    {
        public ProdukKopi()
        {
            InitializeComponent();
            LoadProduk();
        }

        private void LoadProduk()
        {
            try
            {
                using var conn = ConnectDB.GetConnection();
                string query = @"
                    select p.id_produk, p.nama_produk,
                           u.nama_lengkap as petani,
                           j.nama_jenis as jenis,
                           p.berat_kg, p.harga_pengajuan, p.status_produk as status
                    from kapten.produk_kopi p
                    join kapten.users u on u.id_user = p.id_petani
                    join kapten.jenis_kopi j on j.id_jenis = p.id_jenis
                    order by p.id_produk desc";
                var da = new NpgsqlDataAdapter(query, conn);
                var dt = new DataTable();
                da.Fill(dt);
                dgvProduk.DataSource = dt;
                if (dgvProduk.Columns.Count > 0)
                    dgvProduk.Columns[dgvProduk.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                lblTotal.Text = $"Total: {dt.Rows.Count} produk";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data produk: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadProduk();

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string status = cmbFilter.SelectedItem?.ToString() ?? "";
                using var conn = ConnectDB.GetConnection();
                string dbStatus = (status ?? "").ToLower().Trim() switch
                {
                    "pendinginspeksi" => "pending_inspeksi",
                    "lolosqc" => "lolos_qc",
                    "ditolakqc" => "ditolak_qc",
                    "berlangsung" => "berlangsung",
                    "terjual" => "terjual",
                    _ => (status ?? "").ToLower()
                };

                string query = status == "Semua" || string.IsNullOrEmpty(status)
                    ? @"select p.id_produk, p.nama_produk,
                           u.nama_lengkap as petani,
                           j.nama_jenis as jenis,
                           p.berat_kg, p.harga_pengajuan, p.status_produk as status
                    from kapten.produk_kopi p
                    join kapten.users u on u.id_user = p.id_petani
                    join kapten.jenis_kopi j on j.id_jenis = p.id_jenis
                    order by p.id_produk desc"
                    : @"select p.id_produk, p.nama_produk,
                           u.nama_lengkap as petani,
                           j.nama_jenis as jenis,
                           p.berat_kg, p.harga_pengajuan, p.status_produk as status
                    from kapten.produk_kopi p
                    join kapten.users u on u.id_user = p.id_petani
                    join kapten.jenis_kopi j on j.id_jenis = p.id_jenis
                    where p.status_produk = @status
                    order by p.id_produk desc";

                var da = new NpgsqlDataAdapter(query, conn);
                if (query.Contains("@status"))
                    da.SelectCommand.Parameters.AddWithValue("@status", dbStatus);
                var dt = new DataTable();
                da.Fill(dt);
                dgvProduk.DataSource = dt;
                lblTotal.Text = $"Total: {dt.Rows.Count} produk";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal filter: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblJudul_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblJudul_Click_1(object sender, EventArgs e)
        {

        }

        private void lblFilter_Click(object sender, EventArgs e)
        {

        }
    }
}
