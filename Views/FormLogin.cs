using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp1.Controllers;
using WinFormsApp1.Views;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;
using WinFormsApp1.Views.AdminForm;

namespace WinFormsApp1
{
    public partial class FormLogin : Form
    {
        private readonly AuthController _authController;

        public static FormLogin Instance { get; private set; } = null!;

        public FormLogin()
        {
            InitializeComponent();
            _authController = new AuthController();
            Instance = this;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                User user = _authController.Login(
                    tbusr.Text,
                    tbpw.Text
                );

                UserContext.SetUser(user);

                // Filter hanya role petani dan pembeli
                var rolePetaniPembeli = user.Roles?
                    .Where(r => r.NamaRole.Equals("petani", StringComparison.OrdinalIgnoreCase)
                             || r.NamaRole.Equals("pembeli", StringComparison.OrdinalIgnoreCase))
                    .ToList() ?? new List<Userrole>();

                string roleUtama;

                if (rolePetaniPembeli.Count >= 2)
                {
                    // User punya 2 role (petani & pembeli) → minta pilih
                    MessageBox.Show(
                        $"Login berhasil!\nSelamat datang, {user.NamaLengkap}.\n\nAnda memiliki 2 role, silakan pilih role untuk sesi ini.",
                        "Verifikasi Role",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    using (var pilihForm = new FormPilihRole(rolePetaniPembeli))
                    {
                        if (pilihForm.ShowDialog() != DialogResult.OK)
                        {
                            UserContext.Logout();
                            return;
                        }
                        roleUtama = pilihForm.SelectedRole;
                    }
                }
                else if (rolePetaniPembeli.Count == 1)
                {
                    // Hanya punya 1 role (petani atau pembeli) → langsung masuk
                    roleUtama = rolePetaniPembeli[0].NamaRole;

                    MessageBox.Show(
                        $"Login berhasil!\nSelamat datang, {user.NamaLengkap}.",
                        "Sukses",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    // Tidak punya role petani/pembeli, cek role lain (admin/inspektor)
                    roleUtama = (user.Roles != null && user.Roles.Count > 0)
                                        ? user.Roles[0].NamaRole
                                        : "pembeli";

                    MessageBox.Show(
                        $"Login berhasil!\nSelamat datang, {user.NamaLengkap}.",
                        "Sukses",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                tbusr.Clear();
                tbpw.Clear();

                Dashboard dashboard = new Dashboard(roleUtama);
                dashboard.Show();
                Hide();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Login Gagal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(
                    "Gagal mengakses database:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Terjadi kesalahan:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            FormRegister registerForm = new FormRegister();
            registerForm.Show();
            Hide();
        }

        public void TampilkanKembali()
        {
            tbusr.Clear();
            tbpw.Clear();
            Show();
            BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void tbusr_TextChanged(object sender, EventArgs e)
        {
        }

        private void tbpw_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void linkregister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister registerForm = new FormRegister();
            registerForm.Show();
            Hide();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int x = (this.ClientSize.Width - panel1.Width) / 2;
            int y = (this.ClientSize.Height - panel1.Height) / 2;

            panel1.Location = new Point(x, y);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}