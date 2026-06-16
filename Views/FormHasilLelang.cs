using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Controllers;

namespace WinFormsApp1.Views
{
    public partial class FormHasilLelang : Form
    {
        private readonly LelangController _lelangController = new LelangController();
        private readonly string _role;

        public FormHasilLelang(string role)
        {
            InitializeComponent();
            _role = role?.Trim().ToLower() ?? "pembeli";
            LoadHasilLelang();
        }

        private void LoadHasilLelang()
        {
            try
            {
                DataTable dt = _lelangController.DapatkanHasilLelang();
                dgvHasil.DataSource = dt;

                if (dgvHasil.Columns.Contains("id_lelang"))
                {
                    dgvHasil.Columns["id_lelang"].HeaderText = "ID Lelang";
                }
                if (dgvHasil.Columns.Contains("nama_produk"))
                {
                    dgvHasil.Columns["nama_produk"].HeaderText = "Nama Produk";
                }
                if (dgvHasil.Columns.Contains("nama_petani"))
                {
                    dgvHasil.Columns["nama_petani"].HeaderText = "Nama Petani";
                }
                if (dgvHasil.Columns.Contains("nama_pemenang"))
                {
                    dgvHasil.Columns["nama_pemenang"].HeaderText = "Pemenang";
                }
                if (dgvHasil.Columns.Contains("harga_pemenang"))
                {
                    dgvHasil.Columns["harga_pemenang"].HeaderText = "Harga Terjual";
                    dgvHasil.Columns["harga_pemenang"].DefaultCellStyle.Format = "C0";
                }
                if (dgvHasil.Columns.Contains("tgl_selesai"))
                {
                    dgvHasil.Columns["tgl_selesai"].HeaderText = "Tanggal Selesai";
                    dgvHasil.Columns["tgl_selesai"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                }

                if (_role == "pembeli")
                {
                    if (dgvHasil.Columns.Contains("nama_pemenang"))
                    {
                        dgvHasil.Columns["nama_pemenang"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat rekap hasil lelang: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadHasilLelang();
        }
    }
}
