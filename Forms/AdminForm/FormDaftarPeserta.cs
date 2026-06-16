using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Controllers;

namespace WinFormsApp1.Forms.AdminForm
{
    public partial class FormDaftarPeserta : Form
    {
        private readonly LelangController _lelangController = new LelangController();
        private readonly int _idLelang;

        public FormDaftarPeserta(int idLelang, string namaProduk)
        {
            InitializeComponent();
            _idLelang = idLelang;
            lblTitle.Text = $"👥 Peserta Lelang: {namaProduk} (ID: {idLelang})";
            LoadDaftarPeserta();
        }

        private void LoadDaftarPeserta()
        {
            try
            {
                DataTable dt = _lelangController.DapatkanPesertaLelang(_idLelang);
                dgvPeserta.DataSource = dt;

                // Format Headers and Columns
                if (dgvPeserta.Columns.Contains("username"))
                {
                    dgvPeserta.Columns["username"].HeaderText = "Username";
                }
                if (dgvPeserta.Columns.Contains("nama_lengkap"))
                {
                    dgvPeserta.Columns["nama_lengkap"].HeaderText = "Nama Lengkap";
                }
                if (dgvPeserta.Columns.Contains("bid_terakhir"))
                {
                    dgvPeserta.Columns["bid_terakhir"].HeaderText = "Bid Terakhir";
                    dgvPeserta.Columns["bid_terakhir"].DefaultCellStyle.Format = "C0";
                }
                if (dgvPeserta.Columns.Contains("waktu_bid_terakhir"))
                {
                    dgvPeserta.Columns["waktu_bid_terakhir"].HeaderText = "Waktu Bid";
                    dgvPeserta.Columns["waktu_bid_terakhir"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat daftar peserta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
