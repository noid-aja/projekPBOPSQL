using Npgsql;
using System;
using System.Windows.Forms;
using WinFormsApp1.Controllers;
using WinFormsApp1.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;
using WinFormsApp1.Forms.AdminForm;

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

                MessageBox.Show(
                    $"Login berhasil!\nSelamat datang, {user.NamaLengkap}.",
                    "Sukses",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                string roleUtama;
                if (user.Roles != null && user.Roles.Count > 1)
                {
                    using (var pilihForm = new FormPilihRole(user.Roles))
                    {
                        if (pilihForm.ShowDialog() != DialogResult.OK)
                        {
                            UserContext.Logout();
                            return;
                        }
                        roleUtama = pilihForm.SelectedRole;
                    }
                }
                else
                {
                    roleUtama = (user.Roles != null && user.Roles.Count > 0)
                                        ? user.Roles[0].NamaRole
                                        : "pembeli";
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