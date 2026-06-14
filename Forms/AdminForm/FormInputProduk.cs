using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Forms.AdminForm
{
    public partial class FormInputProduk : Form
    {
        private readonly int _idPetani;

        public FormInputProduk(int idPetani)
        {
            InitializeComponent();
            _idPetani = idPetani;
            LoadJenisKopi();
        }

        private void LoadJenisKopi()
        {
            try
            {
                using var conn = ConnectDB.GetConnection();
                var da = new NpgsqlDataAdapter("select id_jenis, nama_jenis from kapten.jenis_kopi order by nama_jenis", conn);
                var dt = new DataTable();
                da.Fill(dt);
                cmbJenis.DisplayMember = "nama_jenis";
                cmbJenis.ValueMember = "id_jenis";
                cmbJenis.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load jenis kopi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNamaProduk.Text))
            { MessageBox.Show("Nama produk harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning); tbNamaProduk.Focus(); return; }

            if (cmbJenis.SelectedValue == null)
            { MessageBox.Show("Pilih jenis kopi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (!decimal.TryParse(tbBerat.Text, out decimal berat) || berat <= 0)
            { MessageBox.Show("Berat harus angka lebih dari 0.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning); tbBerat.Focus(); return; }

            if (!decimal.TryParse(tbHarga.Text, out decimal harga) || harga <= 0)
            { MessageBox.Show("Harga pengajuan harus angka lebih dari 0.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning); tbHarga.Focus(); return; }

            int idJenis = Convert.ToInt32(cmbJenis.SelectedValue);
            string deskripsi = tbDeskripsi.Text.Trim();

            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand(@"
                    insert into kapten.produk_kopi (id_petani, id_jenis, nama_produk, berat_kg, harga_pengajuan, deskripsi, status)
                    values (@idPetani, @idJenis, @nama, @berat, @harga, @deskripsi, 'PendingInspeksi')", conn);
                cmd.Parameters.AddWithValue("@idPetani", _idPetani);
                cmd.Parameters.AddWithValue("@idJenis", idJenis);
                cmd.Parameters.AddWithValue("@nama", tbNamaProduk.Text.Trim());
                cmd.Parameters.AddWithValue("@berat", berat);
                cmd.Parameters.AddWithValue("@harga", harga);
                cmd.Parameters.AddWithValue("@deskripsi", string.IsNullOrWhiteSpace(deskripsi) ? (object)DBNull.Value : deskripsi);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Produk berhasil diajukan! Status: Pending Inspeksi.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbNamaProduk.Clear(); tbBerat.Clear(); tbHarga.Clear(); tbDeskripsi.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal simpan produk: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            tbNamaProduk.Clear(); tbBerat.Clear(); tbHarga.Clear(); tbDeskripsi.Clear();
        }
    }
}
