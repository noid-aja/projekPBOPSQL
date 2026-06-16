using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp1.Controllers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Views.AdminView
{
    public partial class ProdukCardAdminInspektor : UserControl
    {
        private int _idProduk;
        private string _namaProduk = string.Empty;
        private string _petani = string.Empty;
        private string _jenis = string.Empty;
        private decimal _hargaPengajuan;
        private string _status = string.Empty;
        private string _roleAktif = "admin";
        private Action? _onRefreshRequired;

        public ProdukCardAdminInspektor()
        {
            InitializeComponent();
        }

        public void SetData(int idProduk, string namaProduk, string petani, string jenis, decimal hargaPengajuan, string status, string grade, string roleAktif, Action onRefreshRequired)
        {
            _idProduk = idProduk;
            _namaProduk = namaProduk;
            _petani = petani;
            _jenis = jenis;
            _hargaPengajuan = hargaPengajuan;
            _status = status;
            _roleAktif = roleAktif;
            _onRefreshRequired = onRefreshRequired;

            pgGambar.Image = Properties.Resources.jenis_kopi;

            lblNamaKopi.Text = namaProduk;
            lblPetani.Text = $"Petani: {petani}";
            lblJenis.Text = $"Jenis: {jenis} | Grade: {grade}";
            lblHargaPengajuan.Text = $"Harga Pengajuan: Rp {hargaPengajuan:N0}";

            string statusFriendly = status.Replace("_", " ").ToUpper();
            lblStatus.Text = statusFriendly;

            string statusLower = status.ToLower().Trim();
            if (statusLower == "pending_inspeksi" || statusLower == "pendinginspeksi")
            {
                lblStatus.BackColor = Color.LightGoldenrodYellow;
                lblStatus.ForeColor = Color.DarkGoldenrod;
            }
            else if (statusLower == "lolos_qc" || statusLower == "lolosqc")
            {
                lblStatus.BackColor = Color.LightGreen;
                lblStatus.ForeColor = Color.DarkGreen;
            }
            else if (statusLower == "ditolak_qc" || statusLower == "ditolakqc")
            {
                lblStatus.BackColor = Color.MistyRose;
                lblStatus.ForeColor = Color.Red;
            }
            else
            {
                lblStatus.BackColor = Color.LightGray;
                lblStatus.ForeColor = Color.Black;
            }

            btnUbahStatus.Visible = (_roleAktif.ToLower().Trim() == "inspektor");
        }

        private void btnUbahStatus_Click(object sender, EventArgs e)
        {

            using (var dialog = new FormBeriGradeDialog(_idProduk, _namaProduk))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _onRefreshRequired?.Invoke();
                }
            }
        }
    }
}
