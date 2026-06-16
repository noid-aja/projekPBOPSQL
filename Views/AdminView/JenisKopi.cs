using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Views.AdminView
{
    public partial class jeniskopi : Form
    {
        public jeniskopi()
        {
            InitializeComponent();
            LoadJenis();
        }

        private void LoadJenis()
        {
            try
            {
                var dt = JenisKopiContext.AmbilSemuaDataTable();
                dgvJenis.DataSource = dt;
                dgvJenis.Columns["deskripsi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNama.Text))
            {
                MessageBox.Show("Nama harus diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNama.Focus();
                return;
            }

            try
            {
                JenisKopiContext.Tambah(tbNama.Text, tbDeskripsi.Text);
                MessageBox.Show("Data berhasil ditambah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadJenis();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal tambah: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvJenis.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data dulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbNama.Text))
            {
                MessageBox.Show("Nama harus diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNama.Focus();
                return;
            }

            int id = Convert.ToInt32(dgvJenis.SelectedRows[0].Cells[0].Value);
            try
            {
                JenisKopiContext.Ubah(id, tbNama.Text, tbDeskripsi.Text);
                MessageBox.Show("Data berhasil diubah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadJenis();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal ubah: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvJenis.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data dulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvJenis.SelectedRows[0].Cells[0].Value);
            var dr = MessageBox.Show("Yakin ingin menghapus?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr != DialogResult.Yes) return;

            try
            {
                JenisKopiContext.Hapus(id);
                MessageBox.Show("Data berhasil dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadJenis();
            }
            catch (PostgresException ex) when (ex.SqlState == "23503")
            {

                MessageBox.Show("Jenis kopi tidak dapat dihapus karena sudah digunakan pada data produk.",
                                "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal hapus: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvJenis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvJenis.Rows[e.RowIndex];

            tbNama.Text = row.Cells[1].Value?.ToString() ?? string.Empty;

            object val = null;
            try
            {

                val = row.Cells["deskripsi"].Value;
            }
            catch { if (row.Cells.Count > 2) val = row.Cells[2].Value; }
            tbDeskripsi.Text = val?.ToString() ?? string.Empty;
        }

        private void ClearInputs()
        {
            tbNama.Text = string.Empty;
            tbDeskripsi.Text = string.Empty;
        }

        private void jeniskopi_Load(object sender, EventArgs e) { }
        private void tbNama_TextChanged(object sender, EventArgs e) { }
        private void tbDeskripsi_TextChanged(object sender, EventArgs e) { }

        private void dgvJenis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblJudul_Click(object sender, EventArgs e)
        {

        }
    }
}