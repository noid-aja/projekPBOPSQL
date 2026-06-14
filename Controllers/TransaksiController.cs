using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Controllers
{
    public class TransaksiController
    {
        public void JalankanOtomatisasiPenutupan()
        {
            TransaksiContext.CekDanTutupLelangExpired();
        }

        public bool AdminKonfirmasiPembayaranLunas(int idTransaksi)
        {
            if (!UserContext.IsLoggedIn() || !UserContext.IsAdmin())
            {
                MessageBox.Show("Akses Ditolak! Hanya akun Admin yang bisa mengonfirmasi pembayaran lunas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return TransaksiContext.AdminKonfirmasiLunas(idTransaksi);
        }

        public bool BayarTransaksi(int idTransaksi)
        {
            if (!UserContext.IsLoggedIn())
            {
                MessageBox.Show("Akses Ditolak! Anda harus login terlebih dahulu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return TransaksiContext.AdminKonfirmasiLunas(idTransaksi);
        }
  
        public bool GagalBayarHitAndRun(int idTransaksi)
        {
            if (!UserContext.IsLoggedIn() || !UserContext.IsAdmin())
            {
                MessageBox.Show("Hanya Admin", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool sukses = TransaksiContext.AdminKonfirmasiGagalBayar(idTransaksi);
            if (sukses)
            {
                MessageBox.Show("Transaksi dibatalkan! Produk milik petani akan dikembalikan.", 
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return sukses;
        }
    }
}
