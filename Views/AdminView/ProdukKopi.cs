using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Views.AdminView
{
    public partial class ProdukKopi : Form
    {
        private FlowLayoutPanel flpProduk;
        private string _roleAktif = "admin";

        public ProdukKopi() : this("admin")
        {
        }

        public ProdukKopi(string roleAktif)
        {
            _roleAktif = roleAktif?.ToLower() ?? "admin";
            InitializeComponent();
            SetupFlowLayoutPanel();
            LoadProduk();
        }

        private void SetupFlowLayoutPanel()
        {

            dgvProduk.Visible = false;

            flpProduk = new FlowLayoutPanel
            {
                Location = dgvProduk.Location,
                Size = dgvProduk.Size,
                Anchor = dgvProduk.Anchor,
                AutoScroll = true,
                BackColor = Color.White
            };

            this.Controls.Add(flpProduk);
        }

        private void LoadProduk()
        {
            try
            {
                var dt = Models.ProdukKopiContext.AmbilSemuaProdukDetail();
                RenderCards(dt);
                lblTotal.Text = $"Total: {dt.Rows.Count} produk";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data produk: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenderCards(DataTable dt)
        {
            flpProduk.SuspendLayout();
            flpProduk.Controls.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int idProduk = Convert.ToInt32(row["id_produk"]);
                string namaProduk = row["nama_produk"].ToString() ?? "";
                string petani = row["petani"].ToString() ?? "";
                string jenis = row["jenis"].ToString() ?? "";
                decimal hargaPengajuan = Convert.ToDecimal(row["harga_pengajuan"]);
                string status = row["status"].ToString() ?? "";
                string grade = row["grade"] == DBNull.Value ? "-" : row["grade"].ToString() ?? "-";

                var card = new ProdukCardAdminInspektor();
                card.SetData(idProduk, namaProduk, petani, jenis, hargaPengajuan, status, grade, _roleAktif, () => LoadProduk());
                flpProduk.Controls.Add(card);
            }

            flpProduk.ResumeLayout(true);
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadProduk();

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string status = cmbFilter.SelectedItem?.ToString() ?? "";
                string dbStatus = (status ?? "").ToLower().Trim() switch
                {
                    "pendinginspeksi" => "pending_inspeksi",
                    "lolosqc" => "lolos_qc",
                    "ditolakqc" => "ditolak_qc",
                    "berlangsung" => "berlangsung",
                    "terjual" => "terjual",
                    _ => (status ?? "").ToLower()
                };

                var dt = Models.ProdukKopiContext.AmbilSemuaProdukDetail(dbStatus);
                RenderCards(dt);
                lblTotal.Text = $"Total: {dt.Rows.Count} produk";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal filter: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblJudul_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblJudul_Click_1(object sender, EventArgs e)
        {

        }

        private void lblFilter_Click(object sender, EventArgs e)
        {

        }
    }
}
