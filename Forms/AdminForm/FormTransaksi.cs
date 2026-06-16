using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Forms.AdminForm
{
    public partial class FormTransaksi : Form
    {
        private readonly string _role;
        private readonly int _idUser;

        public FormTransaksi(string role = "admin", int idUser = 0)
        {
            InitializeComponent();
            _role = role.ToLower();
            _idUser = idUser;
            ConfigureByRole();
            LoadTransaksi();
        }

        private void ConfigureByRole()
        {
            switch (_role)
            {
                case "admin":
                    lblJudul.Text = "💳 Semua Transaksi";
                    btnBayar.Text = "✅ Konfirmasi Lunas";
                    btnBayar.Visible = true;
                    break;
                case "petani":
                    lblJudul.Text = "💳 Transaksi Produk Saya";
                    btnBayar.Visible = false;
                    break;
                case "pembeli":
                    lblJudul.Text = "💳 Transaksi Saya";
                    btnBayar.Text = "✅ Konfirmasi Bayar";
                    btnBayar.Visible = true;
                    break;
                default:
                    lblJudul.Text = "💳 Transaksi";
                    btnBayar.Visible = false;
                    break;
            }
        }

        private void LoadTransaksi()
        {
            try
            {
                using var conn = ConnectDB.GetConnection();
                string query = _role switch
                {
                    "admin" => @"
                        select t.id_transaksi, pk.nama_produk,
                               ub.nama_lengkap as pembeli, up.nama_lengkap as petani,
                               t.total_bayar as harga_final, t.tgl_transaksi, t.status_bayar as status_pembayaran, 'Transfer' as metode_pembayaran
                        from kapten.transaksi t
                        join kapten.pemenang_lelang pl on pl.id_pemenang = t.id_pemenang
                        join kapten.lelang l on l.id_lelang = pl.id_lelang
                        join kapten.produk_kopi pk on pk.id_produk = l.id_produk
                        join kapten.bid b on b.id_bid = pl.id_bid
                        join kapten.users ub on ub.id_user = b.id_pembeli
                        join kapten.users up on up.id_user = pk.id_petani
                        order by t.id_transaksi desc",
                    "petani" => @"
                        select t.id_transaksi, pk.nama_produk,
                               ub.nama_lengkap as pembeli,
                               t.total_bayar as harga_final, t.tgl_transaksi, t.status_bayar as status_pembayaran, 'Transfer' as metode_pembayaran
                        from kapten.transaksi t
                        join kapten.pemenang_lelang pl on pl.id_pemenang = t.id_pemenang
                        join kapten.lelang l on l.id_lelang = pl.id_lelang
                        join kapten.produk_kopi pk on pk.id_produk = l.id_produk
                        join kapten.bid b on b.id_bid = pl.id_bid
                        join kapten.users ub on ub.id_user = b.id_pembeli
                        where pk.id_petani = @idUser
                        order by t.id_transaksi desc",
                    "pembeli" => @"
                        select t.id_transaksi, pk.nama_produk,
                               up.nama_lengkap as petani,
                               t.total_bayar as harga_final, t.tgl_transaksi, t.status_bayar as status_pembayaran, 'Transfer' as metode_pembayaran
                        from kapten.transaksi t
                        join kapten.pemenang_lelang pl on pl.id_pemenang = t.id_pemenang
                        join kapten.lelang l on l.id_lelang = pl.id_lelang
                        join kapten.produk_kopi pk on pk.id_produk = l.id_produk
                        join kapten.users up on up.id_user = pk.id_petani
                        join kapten.bid b on b.id_bid = pl.id_bid
                        where b.id_pembeli = @idUser
                        order by t.id_transaksi desc",
                    _ => "select 1"
                };

                var da = new NpgsqlDataAdapter(query, conn);
                if (query.Contains("@idUser"))
                    da.SelectCommand.Parameters.AddWithValue("@idUser", _idUser);
                var dt = new DataTable();
                da.Fill(dt);
                dgvTransaksi.DataSource = dt;
                if (dgvTransaksi.Columns.Count > 0)
                    dgvTransaksi.Columns[dgvTransaksi.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                lblTotal.Text = $"Total: {dt.Rows.Count} transaksi";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat transaksi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadTransaksi();

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (dgvTransaksi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih transaksi terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string statusBayar = dgvTransaksi.SelectedRows[0].Cells["status_pembayaran"].Value?.ToString() ?? "";
            string statusNormalized = statusBayar.ToLower().Replace("_", "");

            if (statusNormalized != "belumbayar")
            {
                MessageBox.Show("Transaksi ini sudah dibayar atau tidak valid.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idTransaksi = Convert.ToInt32(dgvTransaksi.SelectedRows[0].Cells["id_transaksi"].Value);

            try
            {
                var controller = new WinFormsApp1.Controllers.TransaksiController();
                bool sukses;

                if (_role == "admin")
                {
                    // Admin konfirmasi pembayaran telah diterima (lunas)
                    sukses = controller.AdminKonfirmasiPembayaranLunas(idTransaksi);
                    if (sukses)
                    {
                        MessageBox.Show("Pembayaran berhasil dikonfirmasi lunas!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTransaksi();
                    }
                }
                else if (_role == "pembeli")
                {
                    // Pembeli konfirmasi telah membayar
                    sukses = controller.BayarTransaksi(idTransaksi);
                    if (sukses)
                    {
                        MessageBox.Show("Pembayaran berhasil dikonfirmasi!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTransaksi();
                    }
                }
                else
                {
                    MessageBox.Show("Hanya Admin atau Pembeli yang bisa konfirmasi pembayaran.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal konfirmasi bayar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
