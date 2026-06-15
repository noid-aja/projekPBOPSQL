using System;
using System.Data;
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
                    select l.id_lelang, p.nama_produk,
                           u.nama_lengkap as petani,
                           j.nama_jenis as jenis,
                           p.berat_kg,
                           COALESCE(i.grade, '-') as grade,
                           l.bid_minimum, l.tgl_akhir, l.status_lelang as status,
                           COALESCE(MAX(b.nominal), 0) as bid_tertinggi,
                           COUNT(b.id_bid) as jumlah_bid
                    from kapten.lelang l
                    join kapten.produk_kopi p on p.id_produk = l.id_produk
                    join kapten.users u on u.id_user = p.id_petani
                    join kapten.jenis_kopi j on j.id_jenis = p.id_jenis
                    left join kapten.inspeksi i on i.id_produk = p.id_produk
                    left join kapten.bid b on b.id_lelang = l.id_lelang
                    where l.status_lelang = 'berlangsung'
                    group by l.id_lelang, p.nama_produk, u.nama_lengkap, j.nama_jenis, p.berat_kg, i.grade, l.status_lelang, l.tgl_akhir, l.bid_minimum
                    order by l.tgl_akhir asc";

                var da = new NpgsqlDataAdapter(query, conn);
                var dt = new DataTable();
                da.Fill(dt);

                lblJumlahLelang.Text = $"{dt.Rows.Count} lelang aktif saat ini";

                flpLelang.SuspendLayout();
                foreach (DataRow row in dt.Rows)
                {
                    int idLelang = Convert.ToInt32(row["id_lelang"]);
                    string namaProduk = row["nama_produk"].ToString() ?? "";
                    string petani = row["petani"].ToString() ?? "";
                    string jenis = row["jenis"].ToString() ?? "";
                    decimal berat = Convert.ToDecimal(row["berat_kg"]);
                    string grade = row["grade"].ToString() ?? "-";
                    decimal bidMin = Convert.ToDecimal(row["bid_minimum"]);
                    DateTime tglAkhir = Convert.ToDateTime(row["tgl_akhir"]);
                    decimal bidTertinggi = Convert.ToDecimal(row["bid_tertinggi"]);

                    ProdukCard card = new ProdukCard();
                    card.IdLelang = idLelang;
                    card.NamaProduk = namaProduk;
                    card.Petani = petani;
                    card.JenisKopi = jenis;
                    card.BeratKg = berat;
                    card.Grade = grade;
                    card.HargaAwal = bidMin;
                    card.BidTertinggi = bidTertinggi;
                    card.TglAkhir = tglAkhir;

                    // Load coffee beans image safely from Resources folder
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
                                card.ProductImage = Image.FromFile(path);
                                break;
                            }
                            catch {}
                        }
                    }

                    // Open Pasang Bid Form on Card Click
                    card.CardClick += card_CardClick;

                    flpLelang.Controls.Add(card);
                }
                flpLelang.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat lelang: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void card_CardClick(object? sender, EventArgs e)
        {
            if (sender is not ProdukCard card) return;

            using (var diag = new FormInputBidDialog(card.IdLelang, card.NamaProduk, card.HargaSaatIni))
            {
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    LoadLelangAktif();
                    LoadRiwayatBid();
                }
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
            foreach (Control ctrl in flpLelang.Controls)
            {
                if (ctrl is ProdukCard card)
                {
                    card.UpdateCountdown();
                }
            }
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
