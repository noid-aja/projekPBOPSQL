using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Helpers;

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
                using (NpgsqlConnection conn = ConnectDB.GetConnection())
                {
                    string query = "insert into kapten.jenis_kopi(nama, deskripsi) values(@nama, @deskripsi)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", tbNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@deskripsi", string.IsNullOrWhiteSpace(tbDeskripsi.Text) ? (object)DBNull.Value : tbDeskripsi.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }

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
            using (NpgsqlConnection conn = ConnectDB.GetConnection())
            {
                string query = "select * from kapten.jenis_kopi";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
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
                using (NpgsqlConnection conn = ConnectDB.GetConnection())
                {
                    string query = "update kapten.jenis_kopi set nama=@nama, deskripsi=@deskripsi where jenis_kopi_id=@id";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", tbNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@deskripsi", string.IsNullOrWhiteSpace(tbDeskripsi.Text) ? (object)DBNull.Value : tbDeskripsi.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

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
                using (NpgsqlConnection conn = ConnectDB.GetConnection())
                {
                    // Cek apakah jenis kopi digunakan di tabel produk
                    string checkQuery = "select count(*) from kapten.produk where jenis_kopi_id = @id";
                    using (NpgsqlCommand checkCmd = new NpgsqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@id", id);
                        long used = Convert.ToInt64(checkCmd.ExecuteScalar());
                        if (used > 0)
                        {
                            MessageBox.Show("Jenis kopi tidak bisa dihapus karena sudah digunakan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string deleteQuery = "delete from kapten.jenis_kopi where jenis_kopi_id = @id";
                    using (NpgsqlCommand delCmd = new NpgsqlCommand(deleteQuery, conn))
                    {
                        delCmd.Parameters.AddWithValue("@id", id);
                        delCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadJenisKopi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat menghapus data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
