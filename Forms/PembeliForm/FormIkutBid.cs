using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp1.Controllers;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;
using Npgsql;

namespace WinFormsApp1.Forms.PembeliForm
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
                using var conn = ConnectDB.GetConnection();
                string query = @"
                   select l.id_lelang, l.bid_minimum, l.tgl_mulai, l.tgl_akhir, l.lokasi_lelang, l.status_lelang,
                           p.id_produk, p.id_petani, p.id_jenis, p.nama_produk, p.berat_kg, p.harga_pengajuan, p.deskripsi, p.status_produk,
                           u.nama_lengkap as petani,
                           j.nama_jenis as jenis,
                           coalesce(i.grade, '-') as grade,
                           coalesce(max(b.nominal), 0) as bid_tertinggi
                    from kapten.lelang l
                    join kapten.produk_kopi p on p.id_produk = l.id_produk
                    join kapten.users u on u.id_user = p.id_petani
                    join kapten.jenis_kopi j on j.id_jenis = p.id_jenis
                    left join kapten.inspeksi i on i.id_produk = p.id_produk
                    left join kapten.bid b on b.id_lelang = l.id_lelang
                    where l.status_lelang = 'berlangsung'
                    group by l.id_lelang, l.bid_minimum, l.tgl_mulai, l.tgl_akhir, l.lokasi_lelang, l.status_lelang,
                             p.id_produk, p.id_petani, p.id_jenis, p.nama_produk, p.berat_kg, p.harga_pengajuan, p.deskripsi, p.status_produk,
                             u.nama_lengkap, j.nama_jenis, i.grade
                    order by l.tgl_akhir asc";

                var da = new NpgsqlDataAdapter(query, conn);
                var dt = new DataTable();
                da.Fill(dt);

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

                    ProdukCard card = new ProdukCard();
                    card.SetDataLelang(lelang, produk, bidTertinggi);


                    string[] searchPaths = new[]
                    {
                        System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "coffee_placeholder.png"),
                        System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Resources", "coffee_placeholder.png"),
                        "Resources/coffee_placeholder.png"
                    };
                    foreach (var path in searchPaths)
                    {
                        if (System.IO.File.Exists(path))
                        {
                            try
                            {
                                break;
                            }
                            catch {}
                        }
                    }

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
                using var conn = ConnectDB.GetConnection();
                string query = @"
                    select b.id_bid, p.nama_produk, b.nominal, b.tgl_bid,
                           l.status_lelang as status_lelang
                    from kapten.bid b
                    join kapten.lelang l on l.id_lelang = b.id_lelang
                    join kapten.produk_kopi p on p.id_produk = l.id_produk
                    where b.id_pembeli = @idPembeli
                    order by b.tgl_bid desc";
                var da = new NpgsqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@idPembeli", _idPembeli);
                var dt = new DataTable();
                da.Fill(dt);
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
