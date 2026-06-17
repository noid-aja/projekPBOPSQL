using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;
using WinFormsApp1.Views.PetaniView;
using WinFormsApp1.Views.PembeliView;
using WinFormsApp1.Views.InspektorView;
using WinFormsApp1.Views.AdminView;

namespace WinFormsApp1.Views
{
    public partial class Dashboard : Form
    {
        private string roleAktif = "admin";
        private bool _isLoggingOut = false;

        private Button btnToggleRole = null!;
        private Button btnTambahRole = null!;
        private Button btnHapusRole = null!;

        public Dashboard()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            InisialisasiRoleButtons();
            UpdateWelcomeGreeting();
        }

        public Dashboard(string role)
        {
            InitializeComponent();
            roleAktif = role?.Trim().ToLower() ?? string.Empty;
            this.DoubleBuffered = true;
            InisialisasiRoleButtons();
            UpdateWelcomeGreeting();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            try
            {

                pictureBox1.Click += LogoOrTitle_Click;
                lblSidebarTitle.Click += LogoOrTitle_Click;
                pictureBox1.Cursor = Cursors.Hand;
                lblSidebarTitle.Cursor = Cursors.Hand;

                if (string.IsNullOrWhiteSpace(roleAktif))
                {
                    MessageBox.Show(
                        "Role user kosong. Cek hasil login dan mapping User.Roles.",
                        "Role Kosong",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                AturDashboard(roleAktif);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memuat dashboard:\n" + ex.Message,
                    "Dashboard Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void AturDashboard(string role)
        {
            if (!UserContext.IsLoggedIn())
            {
                MessageBox.Show("Sesi login Anda tidak valid. Silakan login kembali.",
                    "Sesi Habis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TransaksiContext.SinkronkanStatusLelang();

            var oopRoles = UserContext.CurrentUser!.GetOopRoles();
            var roleObj = oopRoles.Find(r =>
                r.NamaRole.Equals(role, StringComparison.OrdinalIgnoreCase));

            if (roleObj == null)
            {
                MessageBox.Show("Role tidak dikenali: " + role,
                    "Role Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int currentIdUser = UserContext.CurrentUser.IdUser;

            UpdateWelcomeGreeting();

            lblSidebarTitle.Text = roleObj.JudulDashboard;

            AturMenu(roleObj.GetMenuAkses());

            DataTable ringkasan = DashboardContext.AmbilRingkasan(
                currentIdUser,
                roleObj.NamaRole);

            if (ringkasan.Rows.Count > 0)
            {
                DataRow row = ringkasan.Rows[0];

                AturCard(
                    row["card1_value"]?.ToString() ?? "0",
                    row["card1_title"]?.ToString() ?? "-",
                    row["card2_value"]?.ToString() ?? "0",
                    row["card2_title"]?.ToString() ?? "-",
                    row["card3_value"]?.ToString() ?? "0",
                    row["card3_title"]?.ToString() ?? "-",
                    row["card4_value"]?.ToString() ?? "0",
                    row["card4_title"]?.ToString() ?? "-");
            }

            if (roleObj.NamaRole == "admin")
            {
                IsiTabelAdmin();
            }
            else if (roleObj.NamaRole == "petani")
            {
                IsiTabelPetani(currentIdUser);
            }
            else if (roleObj.NamaRole == "pembeli")
            {
                IsiTabelPembeli(currentIdUser);
            }
            else if (roleObj.NamaRole == "inspektor")
            {
                IsiTabelInspektor();
            }

            UpdateRoleButtons();
        }


        private void AturCard(
            string value1, string title1,
            string value2, string title2,
            string value3, string title3,
            string value4, string title4)
        {
            lblCardValue1.Text = value1;
            lblCardTitle1.Text = title1;

            lblCardValue2.Text = value2;
            lblCardTitle2.Text = title2;

            lblCardValue3.Text = value3;
            lblCardTitle3.Text = title3;

            lblCardValue4.Text = value4;
            lblCardTitle4.Text = title4;
        }

        private void AturMenu(List<string> menus)
        {
            Button[] tombolMenu = { btnMenu1, btnMenu2, btnMenu3, btnMenu4, btnMenu5, btnMenu6, btnMenu7, btnMenu8 };

            for (int i = 0; i < tombolMenu.Length; i++)
            {
                if (i < menus.Count)
                {
                    tombolMenu[i].Text = menus[i];
                    tombolMenu[i].Tag = menus[i];
                    tombolMenu[i].Visible = true;

                    tombolMenu[i].Click -= Menu_Click;
                    tombolMenu[i].Click += Menu_Click;
                }
                else
                {
                    tombolMenu[i].Visible = false;
                }
            }
        }

        private void btnKeDashboard_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
                activeForm = null;
            }


            ShowDashboardComponents();
            AturDashboard(roleAktif);
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            if (sender is not Button btn || btn.Tag == null) return;

            string menu = btn.Tag.ToString()!.Trim();
            string menuLower = menu.ToLower();
            int idUser = UserContext.IsLoggedIn() ? UserContext.CurrentUser!.IdUser : 0;

            if (menuLower != "beranda" && UserContext.IsLoggedIn())
            {
                var oopRoles = UserContext.CurrentUser!.GetOopRoles();
                var roleObj = oopRoles.Find(r =>
                    r.NamaRole.Equals(roleAktif, StringComparison.OrdinalIgnoreCase));

                if (roleObj != null && !roleObj.BisaAksesMenu(menu))
                {
                    MessageBox.Show($"Menu '{menu}' tidak tersedia untuk role {roleObj.NamaRole}.\n\nRole kamu: {roleObj.GetDeskripsiRole()}",
                        "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                switch (menuLower)
                {
                    case "beranda":
                        if (activeForm != null) { activeForm.Close(); activeForm = null; }
                        ShowDashboardComponents();
                        AturDashboard(roleAktif);
                        break;

                    case "kelola user":
                        openChildForm(new KelolaUser());
                        break;
                    case "kelola inspektor":
                        openChildForm(new KelolaInspektor());
                        break;
                    case "kelola jenis kopi":
                    case "jenis kopi":
                        openChildForm(new jeniskopi());
                        break;
                    case "lihat semua produk":
                    case "produk kopi":
                        openChildForm(new WinFormsApp1.Views.AdminView.ProdukKopi(roleAktif));
                        break;
                    case "kelola lelang":
                    case "lelang":
                        openChildForm(new FormLelang());
                        break;
                    case "rekap hasil lelang":
                    case "hasil lelang":
                    case "riwayat lelang":
                        openChildForm(new FormHasilLelang(roleAktif));
                        break;
                    case "kelola transaksi":
                    case "transaksi":
                        openChildForm(new FormTransaksi(roleAktif, idUser));
                        break;
                    case "lihat laporan":
                    case "laporan":
                        if (roleAktif == "admin")
                        {
                            openChildForm(new FormStatistikLaporan());
                        }
                        else
                        {
                            openChildForm(new FormRiwayatInspeksi());
                        }
                        break;

                    case "input produk kopi":
                    case "input produk":
                        openChildForm(new FormInputProduk(idUser));
                        break;
                    case "lihat produk saya":
                    case "produk saya":
                        openChildForm(new ProdukKopiPetani(idUser));
                        break;
                    case "lihat hasil qc":
                    case "hasil qc":
                        openChildForm(new FormHasilQC(idUser));
                        break;
                    case "lihat jadwal lelang":
                    case "jadwal lelang":
                        openChildForm(new FormJadwalLelang());
                        break;
                    case "lihat status transaksi":
                        openChildForm(new FormTransaksi("petani", idUser));
                        break;

                    case "lihat lelang":
                        openChildForm(new FormIkutBid(idUser));
                        break;
                    case "lihat riwayat bid":
                    case "riwayat bid":
                        openChildForm(new FormIkutBid(idUser));
                        break;
                    case "lihat transaksi":
                    case "transaksi saya":
                        openChildForm(new FormTransaksi("pembeli", idUser));
                        break;

                    case "lihat produk pending":
                    case "produk pending":
                        openChildForm(new WinFormsApp1.Views.InspektorView.Inspeksi("lihat produk pending"));
                        break;
                    case "input hasil inspeksi":
                    case "input inspeksi":
                        openChildForm(new WinFormsApp1.Views.InspektorView.Inspeksi("input hasil inspeksi"));
                        break;
                    case "beri grade kopi":
                        openChildForm(new WinFormsApp1.Views.InspektorView.Inspeksi("beri grade kopi"));
                        break;
                    case "set status qc":
                        openChildForm(new WinFormsApp1.Views.InspektorView.Inspeksi("set status qc"));
                        break;
                    case "riwayat inspeksi":
                    case "laporan qc":
                        openChildForm(new FormRiwayatInspeksi(idUser));
                        break;

                    default:
                        MessageBox.Show("Menu '" + menu + "' belum diimplementasikan atau salah mapping case.",
                                        "Info Halaman",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuka menu: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        private void SetTable(DataTable table)
        {
            dgvDashboard.DataSource = null;
            dgvDashboard.Columns.Clear();
            dgvDashboard.DataSource = table;
        }

        private void IsiTabelAdmin() =>
            SetTable(DashboardContext.AmbilProdukAdmin());

        private void IsiTabelPetani(int idPetani) =>
            SetTable(DashboardContext.AmbilProdukPetani(idPetani));

        private void IsiTabelPembeli(int idPembeli) =>
            SetTable(DashboardContext.AmbilLelangTersedia(idPembeli));

        private void IsiTabelInspektor() =>
            SetTable(DashboardContext.AmbilProdukPendingInspeksi());

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin logout?",
                                                   "Konfirmasi Logout",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                UserContext.Logout();
                _isLoggingOut = true;

                FormLogin.Instance.TampilkanKembali();

                this.Close();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (!_isLoggingOut)
            {
                Application.Exit();
            }
        }

        private void UpdateWelcomeGreeting()
        {
            if (UserContext.IsLoggedIn() && UserContext.CurrentUser != null)
            {
                string nama = UserContext.CurrentUser.NamaLengkap;
                if (string.IsNullOrWhiteSpace(nama))
                {
                    nama = UserContext.CurrentUser.Username;
                }
                label1.Text = $"Selamat Datang, {nama}";
                label1.BringToFront();
            }
        }

        private Form activeForm = null;
        private void openChildForm(Form child)
        {
            this.SuspendLayout();
            HideDashboardComponents();
            if (activeForm != null)
            {
                activeForm.Close();
                panel1.Controls.Remove(activeForm);
            }

            activeForm = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            panel1.Controls.Add(child);
            panel1.Tag = child;
            child.BringToFront();
            child.Show();
            this.ResumeLayout(true);
        }

        private void HideDashboardComponents()
        {
            this.SuspendLayout();
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            lblTableTitle.Visible = false;
            this.ResumeLayout(false);
        }

        private void ShowDashboardComponents()
        {
            this.SuspendLayout();
            panel4.Visible = true;
            panel5.Visible = true;
            panel6.Visible = true;
            panel7.Visible = true;
            panel8.Visible = true;
            lblTableTitle.Visible = true;
            this.ResumeLayout(true);
        }

        private void LogoOrTitle_Click(object? sender, EventArgs e)
        {
            KembaliKeDashboard();
        }

        private void KembaliKeDashboard()
        {
            SuspendLayout();

            if (activeForm != null)
            {
                panel1.Controls.Remove(activeForm);

                activeForm.Close();
                activeForm.Dispose();
                activeForm = null;
            }

            ShowDashboardComponents();

            AturDashboard(roleAktif);

            ResumeLayout(true);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void lblCardValue1_Click(object sender, EventArgs e)
        {
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dgvDashboard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnMenu1_Click(object sender, EventArgs e)
        {

        }

        private void InisialisasiRoleButtons()
        {
            btnToggleRole = new Button
            {
                BackColor = System.Drawing.Color.Navy,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.White,
                Size = new System.Drawing.Size(306, 40),
                Visible = false,
                Cursor = Cursors.Hand
            };
            btnToggleRole.FlatAppearance.BorderSize = 0;
            btnToggleRole.Click += BtnToggleRole_Click;

            btnTambahRole = new Button
            {
                BackColor = System.Drawing.Color.Orange,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.Black,
                Size = new System.Drawing.Size(306, 40),
                Visible = false,
                Cursor = Cursors.Hand
            };
            btnTambahRole.FlatAppearance.BorderSize = 0;
            btnTambahRole.Click += BtnTambahRole_Click;

            btnHapusRole = new Button
            {
                BackColor = System.Drawing.Color.Red,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.White,
                Size = new System.Drawing.Size(306, 40),
                Visible = false,
                Cursor = Cursors.Hand
            };
            btnHapusRole.FlatAppearance.BorderSize = 0;
            btnHapusRole.Click += BtnHapusRole_Click;

            panel2.Controls.Add(btnToggleRole);
            panel2.Controls.Add(btnTambahRole);
            panel2.Controls.Add(btnHapusRole);
        }

        private void UpdateRoleButtons()
        {
            if (btnToggleRole == null || btnTambahRole == null || btnHapusRole == null) return;

            btnToggleRole.Visible = false;
            btnTambahRole.Visible = false;
            btnHapusRole.Visible = false;

            if (UserContext.CurrentUser == null) return;

            var roles = UserContext.CurrentUser.Roles;
            bool hasPetani = roles.Any(r => r.NamaRole.Equals("petani", System.StringComparison.OrdinalIgnoreCase));
            bool hasPembeli = roles.Any(r => r.NamaRole.Equals("pembeli", System.StringComparison.OrdinalIgnoreCase));
            bool isPetaniOrPembeli = roleAktif.Equals("petani", System.StringComparison.OrdinalIgnoreCase) || roleAktif.Equals("pembeli", System.StringComparison.OrdinalIgnoreCase);

            if (isPetaniOrPembeli)
            {
                int logoutY = btnLogout.Location.Y;
                int logoutX = btnLogout.Location.X;

                if (hasPetani && hasPembeli)
                {
                    btnToggleRole.Text = $"🔄 Switch ke {(roleAktif == "petani" ? "Pembeli" : "Petani")}";
                    btnToggleRole.Location = new System.Drawing.Point(logoutX, logoutY - 50);
                    btnToggleRole.Visible = true;

                    btnHapusRole.Text = $"⚠️ Hapus Role {roleAktif.ToUpper()}";
                    btnHapusRole.Location = new System.Drawing.Point(logoutX, logoutY - 100);
                    btnHapusRole.Visible = true;
                }
                else if (hasPetani && !hasPembeli)
                {
                    btnTambahRole.Text = "➕ Aktifkan Akses Pembeli";
                    btnTambahRole.Location = new System.Drawing.Point(logoutX, logoutY - 50);
                    btnTambahRole.Visible = true;
                }
                else if (!hasPetani && hasPembeli)
                {
                    btnTambahRole.Text = "➕ Aktifkan Akses Petani";
                    btnTambahRole.Location = new System.Drawing.Point(logoutX, logoutY - 50);
                    btnTambahRole.Visible = true;
                }
            }
        }

        private void BtnToggleRole_Click(object? sender, System.EventArgs e)
        {
            if (UserContext.CurrentUser == null) return;
            string targetRole = roleAktif.Equals("petani", System.StringComparison.OrdinalIgnoreCase) ? "pembeli" : "petani";
            roleAktif = targetRole;
            AturDashboard(roleAktif);
            btnKeDashboard_Click(this, System.EventArgs.Empty);
        }

        private void BtnTambahRole_Click(object? sender, System.EventArgs e)
        {
            if (UserContext.CurrentUser == null) return;
            string targetRole = roleAktif.Equals("petani", System.StringComparison.OrdinalIgnoreCase) ? "pembeli" : "petani";

            var confirm = MessageBox.Show(
                $"Apakah Anda yakin ingin mengaktifkan role '{targetRole}' untuk akun ini?",
                "Konfirmasi Aktifkan Role",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    UserContext.AddRole(UserContext.CurrentUser.IdUser, targetRole);
                    UserContext.RefreshCurrentUserRoles();
                    roleAktif = targetRole;
                    AturDashboard(roleAktif);
                    btnKeDashboard_Click(this, System.EventArgs.Empty);
                    MessageBox.Show($"Role '{targetRole}' berhasil diaktifkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Gagal mengaktifkan role: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnHapusRole_Click(object? sender, System.EventArgs e)
        {
            if (UserContext.CurrentUser == null) return;
            string targetRole = roleAktif;

            var confirm = MessageBox.Show(
                $"Apakah Anda yakin ingin menonaktifkan role '{targetRole}' dari akun ini? (Soft Delete)",
                "Konfirmasi Hapus Role",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    UserContext.RemoveRole(UserContext.CurrentUser.IdUser, targetRole);
                    UserContext.RefreshCurrentUserRoles();

                    var remainingRoleObj = UserContext.CurrentUser.Roles.FirstOrDefault();
                    if (remainingRoleObj != null)
                    {
                        roleAktif = remainingRoleObj.NamaRole;
                        AturDashboard(roleAktif);
                        btnKeDashboard_Click(this, System.EventArgs.Empty);
                        MessageBox.Show($"Role '{targetRole}' berhasil dinonaktifkan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Akun Anda tidak memiliki role aktif lagi. Silakan login kembali.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        UserContext.Logout();
                        _isLoggingOut = true;
                        FormLogin.Instance.TampilkanKembali();
                        this.Close();
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Gagal menonaktifkan role: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}