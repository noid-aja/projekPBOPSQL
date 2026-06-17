using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp1.Controllers;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Views.PembeliView
{
    public partial class FormIkutBid : Form
    {
        private readonly int _idPembeli;
        private System.Windows.Forms.Timer _timerCountdown = new System.Windows.Forms.Timer();
        private readonly BidController _bidController = new BidController();

        public FormIkutBid(int idPembeli)
        {
            InitializeComponent();
            _idPembeli = idPembeli;
            LoadLelangAktif();
            LoadRiwayatBid();

            _timerCountdown.Interval = 1000;
            _timerCountdown.Tick += TimerCountdown_Tick;
            _timerCountdown.Start();
        }

        private void LoadLelangAktif()
        {
            try
            {
                flpLelang.Controls.Clear();
                TransaksiContext.SinkronkanStatusLelang();
                var dt = LelangContext.AmbilLelangAktifPembeli(_idPembeli);

                lblJumlahLelang.Text = $"{dt.Rows.Count} lelang aktif saat ini";

                flpLelang.SuspendLayout();
                foreach (DataRow row in dt.Rows)
                {
                    Lelang lelang = new Lelang(
                        Convert.ToInt32(row["id_lelang"]),
                        Convert.ToInt32(row["id_produk"]),
                        Convert.ToDecimal(row["bid_minimum"]),
                        Convert.ToDateTime(row["tgl_mulai"]),
                        Convert.ToDateTime(row["tgl_akhir"]),
                        row["lokasi_lelang"] == DBNull.Value ? null : row["lokasi_lelang"].ToString(),
                        WinFormsApp1.Models.Enum.ParseStatusLelang(row["status_lelang"].ToString() ?? "")
                    );

                    ProdukKopi produk = new ProdukKopi(
                        Convert.ToInt32(row["id_produk"]),
                        Convert.ToInt32(row["id_petani"]),
                        Convert.ToInt32(row["id_jenis"]),
                        row["nama_produk"].ToString() ?? "",
                        Convert.ToDecimal(row["berat_kg"]),
                        Convert.ToDecimal(row["harga_pengajuan"]),
                        row["deskripsi"] == DBNull.Value ? null : row["deskripsi"].ToString(),
                        WinFormsApp1.Models.Enum.ParseStatusProduk(row["status_produk"].ToString() ?? "")
                    );

                    decimal bidTertinggi = Convert.ToDecimal(row["bid_tertinggi"]);
                    string grade = row["grade"] == DBNull.Value ? "-" : row["grade"].ToString() ?? "-";

                    ProdukCard card = new ProdukCard();
                    card.SetDataLelang(lelang, produk, bidTertinggi, grade);


                    card.Click += (s, e) =>
                    {
                        decimal hargaAcuan = bidTertinggi > 0 ? bidTertinggi : lelang.BidMinimum;

                        using (var diag = new FormInputBidDialog(lelang.IdLelang, produk.NamaProduk, hargaAcuan))
                        {
                            if (diag.ShowDialog() == DialogResult.OK)
                            {
                                LoadLelangAktif();
                                LoadRiwayatBid();
                            }
                        }
                    };

                    flpLelang.Controls.Add(card);
                }
                flpLelang.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat lelang: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRiwayatBid()
        {
            try
            {
                var dt = BidContext.AmbilRiwayatBidPembeli(_idPembeli);
                dgvRiwayat.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat riwayat bid: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLelangAktif();
            LoadRiwayatBid();
        }

        private void TimerCountdown_Tick(object sender, EventArgs e)
        {
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1) LoadRiwayatBid();
        }

        protected override void OnFormClosed(System.Windows.Forms.FormClosedEventArgs e)
        {
            _timerCountdown.Stop();
            _timerCountdown.Dispose();
            base.OnFormClosed(e);
        }
    }
}
