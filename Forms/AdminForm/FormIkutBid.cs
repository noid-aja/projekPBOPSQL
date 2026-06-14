using System;
using System.Data;
using System.Linq;
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
                           l.bid_minimum, l.tgl_akhir, l.status_lelang as status,
                           COALESCE(MAX(b.nominal), 0) as bid_tertinggi,
                           COUNT(b.id_bid) as jumlah_bid
                    from kapten.lelang l
                    join kapten.produk_kopi p on p.id_produk = l.id_produk
                    join kapten.users u on u.id_user = p.id_petani
                    join kapten.jenis_kopi j on j.id_jenis = p.id_jenis
                    left join kapten.bid b on b.id_lelang = l.id_lelang
                    where l.status_lelang = 'berlangsung'
                    group by l.id_lelang, p.nama_produk, u.nama_lengkap, j.nama_jenis, l.status_lelang, l.tgl_akhir, l.bid_minimum
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
                    decimal bidMin = Convert.ToDecimal(row["bid_minimum"]);
                    DateTime tglAkhir = Convert.ToDateTime(row["tgl_akhir"]);
                    decimal bidTertinggi = Convert.ToDecimal(row["bid_tertinggi"]);
                    int jumlahBid = Convert.ToInt32(row["jumlah_bid"]);

                    Panel card = new Panel();
                    card.Width = 220;
                    card.Height = 280;
                    card.BorderStyle = BorderStyle.FixedSingle;
                    card.BackColor = System.Drawing.Color.White;
                    card.Margin = new Padding(10);
                    card.Tag = tglAkhir;

                    Label lblNama = new Label();
                    lblNama.Text = namaProduk;
                    lblNama.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
                    lblNama.ForeColor = System.Drawing.Color.DarkGreen;
                    lblNama.Location = new System.Drawing.Point(10, 10);
                    lblNama.Size = new System.Drawing.Size(200, 25);

                    Label lblPetani = new Label();
                    lblPetani.Text = $"Petani: {petani}";
                    lblPetani.Font = new System.Drawing.Font("Segoe UI", 8.5F);
                    lblPetani.ForeColor = System.Drawing.Color.DimGray;
                    lblPetani.Location = new System.Drawing.Point(10, 35);
                    lblPetani.Size = new System.Drawing.Size(200, 18);

                    Label lblJenis = new Label();
                    lblJenis.Text = $"Jenis: {jenis}";
                    lblJenis.Font = new System.Drawing.Font("Segoe UI", 8.5F);
                    lblJenis.ForeColor = System.Drawing.Color.DimGray;
                    lblJenis.Location = new System.Drawing.Point(10, 53);
                    lblJenis.Size = new System.Drawing.Size(200, 18);

                    Label lblMin = new Label();
                    lblMin.Text = $"Harga Awal: Rp {bidMin:N0}";
                    lblMin.Font = new System.Drawing.Font("Segoe UI", 9F);
                    lblMin.Location = new System.Drawing.Point(10, 80);
                    lblMin.Size = new System.Drawing.Size(200, 18);

                    Label lblTertinggi = new Label();
                    lblTertinggi.Text = $"Bid Tertinggi: Rp {(bidTertinggi > 0 ? bidTertinggi.ToString("N0") : "-")}";
                    lblTertinggi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
                    lblTertinggi.ForeColor = System.Drawing.Color.DarkSlateBlue;
                    lblTertinggi.Location = new System.Drawing.Point(10, 98);
                    lblTertinggi.Size = new System.Drawing.Size(200, 18);

                    Label lblCount = new Label();
                    lblCount.Name = "lblCountdown";
                    lblCount.Text = "⏱ Sisa: --:--";
                    lblCount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
                    lblCount.ForeColor = System.Drawing.Color.DarkRed;
                    lblCount.Location = new System.Drawing.Point(10, 125);
                    lblCount.Size = new System.Drawing.Size(200, 20);

                    Label lblTawar = new Label();
                    lblTawar.Text = "Nominal Bid (Rp):";
                    lblTawar.Font = new System.Drawing.Font("Segoe UI", 8.5F);
                    lblTawar.Location = new System.Drawing.Point(10, 155);
                    lblTawar.Size = new System.Drawing.Size(200, 18);

                    TextBox tbNominal = new TextBox();
                    tbNominal.Name = "tbNominal";
                    tbNominal.Location = new System.Drawing.Point(10, 175);
                    tbNominal.Size = new System.Drawing.Size(200, 23);
                    decimal batas = bidTertinggi > 0 ? bidTertinggi : bidMin;
                    tbNominal.Text = (batas + 10000).ToString("F0");

                    Button btnPasang = new Button();
                    btnPasang.Text = "💰 PASANG BID";
                    btnPasang.Location = new System.Drawing.Point(10, 208);
                    btnPasang.Size = new System.Drawing.Size(200, 32);
                    btnPasang.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
                    btnPasang.ForeColor = System.Drawing.Color.White;
                    btnPasang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
                    btnPasang.FlatStyle = FlatStyle.Flat;
                    btnPasang.Tag = idLelang;
                    btnPasang.Click += btnPasang_Click;

                    card.Controls.Add(lblNama);
                    card.Controls.Add(lblPetani);
                    card.Controls.Add(lblJenis);
                    card.Controls.Add(lblMin);
                    card.Controls.Add(lblTertinggi);
                    card.Controls.Add(lblCount);
                    card.Controls.Add(lblTawar);
                    card.Controls.Add(tbNominal);
                    card.Controls.Add(btnPasang);

                    flpLelang.Controls.Add(card);
                }
                flpLelang.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat lelang: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPasang_Click(object sender, EventArgs e)
        {
            if (sender is not Button btn || btn.Tag == null) return;
            int idLelang = (int)btn.Tag;

            Panel? card = btn.Parent as Panel;
            if (card == null) return;

            TextBox? tbNominal = card.Controls.Find("tbNominal", true).FirstOrDefault() as TextBox;
            if (tbNominal == null) return;

            if (!decimal.TryParse(tbNominal.Text, out decimal nominal) || nominal <= 0)
            {
                MessageBox.Show("Nominal bid tidak valid!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNominal.Focus();
                return;
            }

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
            foreach (Control ctrl in flpLelang.Controls)
            {
                if (ctrl is Panel card && card.Tag is DateTime tglAkhir)
                {
                    Label? lblCount = card.Controls.Find("lblCountdown", true).FirstOrDefault() as Label;
                    if (lblCount != null)
                    {
                        TimeSpan sisa = tglAkhir - DateTime.Now;
                        if (sisa.TotalSeconds <= 0)
                        {
                            lblCount.Text = "⏱ Sisa: HABIS";
                            lblCount.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            lblCount.Text = $"⏱ Sisa: {(int)sisa.TotalMinutes:D2}:{sisa.Seconds:D2}";
                            lblCount.ForeColor = System.Drawing.Color.DarkRed;
                        }
                    }
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
