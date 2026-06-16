using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Views.AdminView
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
                var dt = InspeksiContext.AmbilRiwayatInspeksiDataTable(_idInspektor);
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
