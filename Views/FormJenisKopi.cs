using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class FormJenisKopi : Form
    {
        public FormJenisKopi()
        {
            InitializeComponent();
            LoadJenisKopi();
        }

        private void btntambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNama.Text))
            {
                MessageBox.Show("Nama jenis kopi harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNama.Focus();
                return;
            }

            try
            {
                JenisKopiContext.Tambah(tbNama.Text.Trim(), tbDeskripsi.Text.Trim());
                MessageBox.Show("Data berhasil ditambah.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadJenisKopi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat menyimpan data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadJenisKopi()
        {
            try
            {
                DataTable dt = JenisKopiContext.AmbilSemuaDataTable();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data dulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbNama.Text))
            {
                MessageBox.Show("Nama jenis kopi harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNama.Focus();
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            try
            {
                JenisKopiContext.Ubah(id, tbNama.Text.Trim(), tbDeskripsi.Text.Trim());
                MessageBox.Show("Data berhasil diubah.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadJenisKopi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mengubah data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnhapus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data dulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            DialogResult dr = MessageBox.Show("Yakin?!", "Konfirmasi hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr != DialogResult.Yes) return;

            try
            {
                JenisKopiContext.Hapus(id);
                MessageBox.Show("Data berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadJenisKopi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan atau data sudah digunakan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                tbNama.Text = row.Cells[1].Value?.ToString();
                object val = null;
                try
                {
                    val = row.Cells["deskripsi"].Value;
                }
                catch
                {
                    if (row.Cells.Count > 2)
                        val = row.Cells[2].Value;
                }
                tbDeskripsi.Text = val?.ToString() ?? string.Empty;
            }
        }

        private void FormJenisKopi_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbNama_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
