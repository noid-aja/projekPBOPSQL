using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp1.Controllers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Views.PembeliForm
{
    public partial class ProdukCard : UserControl
    {
        private Lelang _lelang;
        private ProdukKopi _produkKopi;
        private BidController _bidController;
        private DateTime _waktuSelesaiLelang;

        public ProdukCard()
        {
            InitializeComponent();
            _bidController = new BidController();
        }

        public void SetDataLelang(Lelang lelang, ProdukKopi produk, decimal penawaranTertinggisaatIni)
        {
            _lelang = lelang;
            _produkKopi = produk;
            _waktuSelesaiLelang = lelang.TglAkhir; 

            lblNamaKopi.Text = produk.NamaProduk;
            lblBeratAtauGrade.Text = $"Berat: {produk.BeratKg} Kg | Status: {produk.Status}";

            decimal hargaAcuan = penawaranTertinggisaatIni > 0 ? penawaranTertinggisaatIni : lelang.BidMinimum;
            lblHargaSekarang.Text = $"Harga Saat Ini: Rp {hargaAcuan:N0}";

            nudNominalBid.Minimum = hargaAcuan + 1000;
            nudNominalBid.Value = hargaAcuan + 1000;

            UpdateCountdownTampilan();
            timerDetik.Start();
        }

        private void timerDetik_Tick(object sender, EventArgs e)
        {
            UpdateCountdownTampilan();
        }

        private void UpdateCountdownTampilan()
        {
            TimeSpan sisaWaktu = _waktuSelesaiLelang - DateTime.Now;

            if (sisaWaktu.TotalSeconds <= 0)
            {
                timerDetik.Stop();
                lblTimerCountdown.Text = "LELANG SELESAI";
                lblTimerCountdown.BackColor = Color.LightGray;
                lblTimerCountdown.ForeColor = Color.Black;

                nudNominalBid.Enabled = false;
                btnTempatkanBid.Enabled = false;
                btnTempatkanBid.BackColor = Color.Gray;
            }
            else
            {
                lblTimerCountdown.Text = string.Format("Sisa Waktu: {0:D2}:{1:D2}:{2:D2}",
                    sisaWaktu.Hours,
                    sisaWaktu.Minutes,
                    sisaWaktu.Seconds);

                if (sisaWaktu.TotalMinutes < 1)
                {
                    lblTimerCountdown.BackColor = Color.Red;
                    lblTimerCountdown.ForeColor = Color.White;
                }
            }
        }
        private void btnTempatkanBid_Click(object sender, EventArgs e)
        {
            decimal nominalTawaran = nudNominalBid.Value;
            bool sukses = _bidController.KirimBid(_lelang.IdLelang, nominalTawaran);

            if (sukses)
            {
                var lelangTerbaru = LelangContext.AmbilLelangById(_lelang.IdLelang);
                if (lelangTerbaru != null)
                {
                    _waktuSelesaiLelang = lelangTerbaru.TglAkhir;
                }

                lblHargaSekarang.Text = $"Harga Saat Ini: Rp {nominalTawaran:N0}";
                nudNominalBid.Minimum = nominalTawaran + 1000;
                nudNominalBid.Value = nominalTawaran + 1000;

                UpdateCountdownTampilan();
            }
        }
    }
}
