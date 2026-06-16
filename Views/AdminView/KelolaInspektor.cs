using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Models;

namespace WinFormsApp1.Views.AdminView
{
    public partial class KelolaInspektor : Form
    {
        public KelolaInspektor()
        {
            InitializeComponent();
            LoadInspektor();
        }

        private void KelolaInspektor_Load(object sender, EventArgs e)
        {
        }

        private void LoadInspektor()
        {
            try
            {
                var dt = UserContext.AmbilSemuaInspektorDetail();
                dgvInspektor.DataSource = dt;
                dgvInspektor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat inspektor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string fullName = tbFullName.Text.Trim();
            string username = tbUsername.Text.Trim();
            string noTelp = tbNoTelp.Text.Trim();
            string password = tbPassword.Text;

            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Nama lengkap harus diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbFullName.Focus();
                return;
            }

            if (fullName.Length < 3)
            {
                MessageBox.Show("Nama lengkap minimal 3 karakter", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbFullName.Focus();
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(fullName, @"^[a-zA-ZÀ-ÿ.'\s]+$"))
            {
                MessageBox.Show("Nama lengkap hanya boleh berisi huruf, spasi, titik, dan apostrof", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbFullName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username harus diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbUsername.Focus();
                return;
            }

            if (username.Length < 4)
            {
                MessageBox.Show("Username minimal 4 karakter", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbUsername.Focus();
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("Username hanya boleh berisi huruf, angka, dan underscore", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(noTelp))
            {
                MessageBox.Show("Nomor telepon harus diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNoTelp.Focus();
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(noTelp, @"^[0-9]{10,15}$"))
            {
                MessageBox.Show("Nomor telepon harus berisi 10 sampai 15 angka", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNoTelp.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password harus diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPassword.Focus();
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password minimal 8 karakter", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPassword.Focus();
                return;
            }

            try
            {
                User newInspector = new User
                {
                    NamaLengkap = fullName,
                    Username = username,
                    Password = password,
                    NoTelp = noTelp
                };

                UserContext.Register(newInspector, new string[] { "inspektor" });

                MessageBox.Show("Inspektor berhasil didaftarkan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadInspektor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mendaftarkan inspektor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvInspektor.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih inspektor dulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullName = tbFullName.Text.Trim();
            string username = tbUsername.Text.Trim();
            string noTelp = tbNoTelp.Text.Trim();
            string password = tbPassword.Text;

            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Nama lengkap harus diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbFullName.Focus();
                return;
            }

            if (fullName.Length < 3)
            {
                MessageBox.Show("Nama lengkap minimal 3 karakter", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbFullName.Focus();
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(fullName, @"^[a-zA-ZÀ-ÿ.'\s]+$"))
            {
                MessageBox.Show("Nama lengkap hanya boleh berisi huruf, spasi, titik, dan apostrof", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbFullName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username harus diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbUsername.Focus();
                return;
            }

            if (username.Length < 4)
            {
                MessageBox.Show("Username minimal 4 karakter", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbUsername.Focus();
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("Username hanya boleh berisi huruf, angka, dan underscore", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(noTelp))
            {
                MessageBox.Show("Nomor telepon harus diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNoTelp.Focus();
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(noTelp, @"^[0-9]{10,15}$"))
            {
                MessageBox.Show("Nomor telepon harus berisi 10 sampai 15 angka", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNoTelp.Focus();
                return;
            }

            bool shouldUpdatePassword = !string.IsNullOrEmpty(password);
            if (shouldUpdatePassword && password.Length < 8)
            {
                MessageBox.Show("Password minimal 8 karakter", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPassword.Focus();
                return;
            }

            int id = Convert.ToInt32(dgvInspektor.SelectedRows[0].Cells["id_user"].Value);
            try
            {
                UserContext.AdminUpdateUser(id, username, fullName, noTelp, password, "inspektor");
                MessageBox.Show("Data inspektor berhasil diubah", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadInspektor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengubah data inspektor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            if (dgvInspektor.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih inspektor dulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvInspektor.SelectedRows[0].Cells["id_user"].Value);
            var dr = MessageBox.Show("Yakin ingin menonaktifkan inspektor ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr != DialogResult.Yes) return;

            try
            {
                UserContext.SoftDeleteUser(id);
                MessageBox.Show("Inspektor berhasil dinonaktifkan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadInspektor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menonaktifkan inspektor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            if (dgvInspektor.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih inspektor dulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvInspektor.SelectedRows[0].Cells["id_user"].Value);
            try
            {
                UserContext.AktifkanUser(id);
                MessageBox.Show("Inspektor berhasil diaktifkan kembali", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadInspektor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengaktifkan inspektor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInspektor();
        }

        private void dgvInspektor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvInspektor.Rows[e.RowIndex];
            try { tbUsername.Text = row.Cells["username"].Value?.ToString() ?? string.Empty; } catch { tbUsername.Text = row.Cells.Count > 1 ? row.Cells[1].Value?.ToString() ?? string.Empty : string.Empty; }
            try { tbFullName.Text = row.Cells["nama_lengkap"].Value?.ToString() ?? string.Empty; } catch { tbFullName.Text = row.Cells.Count > 2 ? row.Cells[2].Value?.ToString() ?? string.Empty : string.Empty; }
            try { tbNoTelp.Text = row.Cells["no_telp"].Value?.ToString() ?? string.Empty; } catch { tbNoTelp.Text = string.Empty; }
        }

        private void ClearInputs()
        {
            tbUsername.Text = string.Empty;
            tbFullName.Text = string.Empty;
            tbPassword.Text = string.Empty;
            tbNoTelp.Text = string.Empty;
        }
    }
}
