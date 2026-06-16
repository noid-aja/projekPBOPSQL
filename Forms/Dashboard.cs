using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;
using WinFormsApp1.Forms.PetaniForm;
using WinFormsApp1.Forms.PembeliForm;
using WinFormsApp1.Forms.InspektorForm;
using WinFormsApp1.Forms.AdminForm;

namespace WinFormsApp1.Forms
{
    public partial class Dashboard : Form
    {
        private string roleAktif = "admin";
        private bool _isLoggingOut = false;

        public Dashboard()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        public Dashboard(string role)
        {
            InitializeComponent();
            roleAktif = role?.Trim().ToLower() ?? string.Empty;
            this.DoubleBuffered = true;
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            try
            {
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
                        break;

                    case "kelola user":
                    case "kelola role":
                        openChildForm(new KelolaUser());
                        break;
                    case "kelola jenis kopi":
                    case "jenis kopi":
                        openChildForm(new jeniskopi());
                        break;
                    case "lihat semua produk":
                    case "produk kopi":
                        openChildForm(new WinFormsApp1.Forms.AdminForm.ProdukKopi());
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
                        openChildForm(new FormRiwayatInspeksi());
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
                    case "ikut bid":
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
                    case "input hasil inspeksi":
                    case "beri grade kopi":
                    case "set status qc":
                    case "input inspeksi":
                        openChildForm(new WinFormsApp1.Forms.InspektorForm.Inspeksi());
                        break;
                    case "riwayat inspeksi":
                    case "laporan qc":
                        openChildForm(new FormRiwayatInspeksi(idUser));
                        break;

                    default:
                        MessageBox.Show("Menu belum tersedia: " + btn.Tag.ToString(), "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuka menu: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void lblSidebarTitle_Click(object sender, EventArgs e)
        {

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
    }
}   