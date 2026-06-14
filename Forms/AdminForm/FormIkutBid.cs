using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Controllers;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;
using Npgsql;

namespace WinFormsApp1.Forms.AdminForm
{
    public partial class FormIkutBid : Form
    {
        private readonly int _idPembeli;
        private System.Windows.Forms.Timer _timerCountdown = new System.Windows.Forms.Timer();

        // [Encapsulation] Bid action lewat controller, bukan direct BidContext
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
                using var conn = ConnectDB.GetConnection();
                string query = @"
                    select l.id_lelang, p.nama_produk,
                           u.nama_lengkap as petani,
                           j.nama_jenis as jenis,
                           l.bid_minimum, l.tgl_akhir, l.status_lelang as status,
                           COALESCE(MAX(b.nominal), 0) as bid_tertinggi,
                           COUNT(b.id_bid) as jumlah_bid
                    from kapten.lelang l
                    join kapten.produk_kopi p on p.id_produk = l.id_produk
                    join kapten.users u on u.id_user = p.id_petani
                    join kapten.jenis_kopi j on j.id_jenis = p.id_jenis
                    left join kapten.bid b on b.id_lelang = l.id_lelang
                    where l.status_lelang = 'berlangsung'
                    group by l.id_lelang, p.nama_produk, u.nama_lengkap, j.nama_jenis, l.status_lelang
                    order by l.tgl_akhir asc";
                var da = new NpgsqlDataAdapter(query, conn);
                var dt = new DataTable();
                da.Fill(dt);
                dgvLelang.DataSource = dt;
                if (dgvLelang.Columns.Count > 0)
                    dgvLelang.Columns[dgvLelang.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                lblJumlahLelang.Text = $"{dt.Rows.Count} lelang aktif saat ini";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat lelang: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLelang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLelang.SelectedRows.Count == 0) return;
            var row = dgvLelang.SelectedRows[0];
            lblSelectedLelang.Text = $"Dipilih: {row.Cells["nama_produk"].Value}";
            decimal bidTertinggi = Convert.ToDecimal(row.Cells["bid_tertinggi"].Value);
            decimal bidMin = Convert.ToDecimal(row.Cells["bid_minimum"].Value);
            decimal batas = bidTertinggi > 0 ? bidTertinggi : bidMin;
            lblBidMin.Text = $"Bid minimum: Rp {batas:N0}";
            tbNominalBid.Text = (batas + 1000).ToString();
        }

        /// <summary>
        /// [Encapsulation] Bid tidak lagi direct ke BidContext.
        /// Validasi dan eksekusi dikelola oleh BidController.
        /// </summary>
        private void btnBid_Click(object sender, EventArgs e)
        {
            if (dgvLelang.SelectedRows.Count == 0)
            { MessageBox.Show("Pilih lelang terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (!decimal.TryParse(tbNominalBid.Text, out decimal nominal) || nominal <= 0)
            { MessageBox.Show("Nominal bid tidak valid!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning); tbNominalBid.Focus(); return; }

            int idLelang = Convert.ToInt32(dgvLelang.SelectedRows[0].Cells["id_lelang"].Value);

            // [Encapsulation] Gunakan BidController, bukan BidContext langsung
            bool ok = _bidController.KirimBid(idLelang, nominal);
            if (ok)
            {
                LoadLelangAktif();
                LoadRiwayatBid();
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
            if (dgvLelang.SelectedRows.Count == 0 || dgvLelang.SelectedRows[0].Cells["tgl_akhir"].Value == DBNull.Value) return;
            DateTime tglAkhir = Convert.ToDateTime(dgvLelang.SelectedRows[0].Cells["tgl_akhir"].Value);
            TimeSpan sisa = tglAkhir - DateTime.Now;
            if (sisa.TotalSeconds <= 0)
                lblCountdown.Text = "⏱ Waktu: HABIS";
            else
                lblCountdown.Text = $"⏱ Sisa: {(int)sisa.TotalMinutes:D2}:{sisa.Seconds:D2}";
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
