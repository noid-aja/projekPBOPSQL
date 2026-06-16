using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Views.AdminForm
{
    /// <summary>
    /// Form riwayat inspeksi yang sudah dilakukan oleh inspektor.
    /// </summary>
    public partial class FormRiwayatInspeksi : Form
    {
        private readonly int _idInspektor;

        public FormRiwayatInspeksi(int idInspektor = 0)
        {
            InitializeComponent();
            _idInspektor = idInspektor;
            LoadRiwayat();
        }

        private void LoadRiwayat()
        {
            try
            {
                using var conn = ConnectDB.GetConnection();
                string query = _idInspektor > 0
                    ? @"select i.id_inspeksi, p.nama_produk, u.nama_lengkap as inspektor,
                               i.nilai, i.harga_rekomendasi, i.catatan, i.tgl_inspeksi,
                               pk.status_produk as status_produk
                        from kapten.inspeksi i
                        join kapten.produk_kopi pk on pk.id_produk = i.id_produk
                        join kapten.users u on u.id_user = i.id_inspektor
                        left join kapten.produk_kopi p on p.id_produk = i.id_produk
                        where i.id_inspektor = @id
                        order by i.tgl_inspeksi desc"
                    : @"select i.id_inspeksi, p.nama_produk, u.nama_lengkap as inspektor,
                               i.nilai, i.harga_rekomendasi, i.catatan, i.tgl_inspeksi,
                               pk.status_produk as status_produk
                        from kapten.inspeksi i
                        join kapten.produk_kopi pk on pk.id_produk = i.id_produk
                        join kapten.users u on u.id_user = i.id_inspektor
                        left join kapten.produk_kopi p on p.id_produk = i.id_produk
                        order by i.tgl_inspeksi desc";

                var da = new NpgsqlDataAdapter(query, conn);
                if (_idInspektor > 0)
                    da.SelectCommand.Parameters.AddWithValue("@id", _idInspektor);
                var dt = new DataTable();
                da.Fill(dt);
                dgvRiwayat.DataSource = dt;
                if (dgvRiwayat.Columns.Count > 0)
                    dgvRiwayat.Columns[dgvRiwayat.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                lblTotal.Text = $"Total: {dt.Rows.Count} inspeksi";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat riwayat: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadRiwayat();
    }
}
