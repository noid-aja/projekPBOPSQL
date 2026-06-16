using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Views.AdminView
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
                    btnBayar.Visible = false;
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
                var dt = Models.TransaksiContext.AmbilTransaksiUntukGrid(_role, _idUser);
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

                if (_role != "admin")
                {
                    MessageBox.Show(
                        "Hanya Admin yang bisa mengonfirmasi pembayaran offline.",
                        "Akses Ditolak",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                sukses = controller.KonfirmasiLunas(idTransaksi);
                if (sukses)
                {
                    MessageBox.Show(
                        "Pembayaran berhasil dikonfirmasi lunas!",
                        "Sukses",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    LoadTransaksi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal konfirmasi bayar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lblTotal_Click(object sender, EventArgs e)
        {
        }
    }
}
