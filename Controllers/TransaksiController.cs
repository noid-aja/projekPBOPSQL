using Npgsql;
using System;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Controllers
{
    public class TransaksiController
    {
        public bool KonfirmasiLunas(int idTransaksi)
        {
            if (!UserContext.IsLoggedIn())
            {
                MessageBox.Show(
                    "Login terlebih dahulu.",
                    "Akses Ditolak",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (!UserContext.IsAdmin())
            {
                MessageBox.Show(
                    "Hanya Admin yang dapat mengonfirmasi pembayaran.",
                    "Akses Ditolak",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            if (idTransaksi <= 0)
            {
                MessageBox.Show(
                    "Pilih transaksi terlebih dahulu.",
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            try
            {
                return TransaksiContext
                    .AdminKonfirmasiLunas(idTransaksi);
            }
            catch (PostgresException ex)
            {
                MessageBox.Show(
                    ex.MessageText,
                    "Konfirmasi Pembayaran Gagal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mengonfirmasi pembayaran: "
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        public bool KonfirmasiGagalBayar(int idTransaksi)
        {
            if (!UserContext.IsLoggedIn())
            {
                MessageBox.Show(
                    "Login terlebih dahulu.",
                    "Akses Ditolak",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (!UserContext.IsAdmin())
            {
                MessageBox.Show(
                    "Hanya Admin yang dapat membatalkan transaksi.",
                    "Akses Ditolak",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            try
            {
                return TransaksiContext
                    .AdminKonfirmasiGagalBayar(idTransaksi);
            }
            catch (PostgresException ex)
            {
                MessageBox.Show(
                    ex.MessageText,
                    "Pembatalan Transaksi Gagal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal membatalkan transaksi: "
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }
    }
}