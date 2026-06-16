using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Controllers
{
    public class BidController : Isearch<Bid>
    {
        public Bid? Cari(int id)
        {
            return BidContext.CariBidById(id);
        }

        public List<Bid> CariNama(string nama)
        {
            return BidContext.CariBidByNamaProduk(nama);
        }

        public bool KirimBid(
            int idLelang,
            decimal nominalTawaran)
        {
            if (!UserContext.IsLoggedIn())
            {
                MessageBox.Show(
                    "Login dulu sebelum memasang bid.",
                    "Akses Ditolak",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (!UserContext.IsPembeli())
            {
                MessageBox.Show(
                    "Hanya Pembeli yang bisa memasang bid.",
                    "Akses Ditolak",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            if (idLelang <= 0)
            {
                MessageBox.Show(
                    "Pilih lelang terlebih dahulu.",
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (nominalTawaran <= 0)
            {
                MessageBox.Show(
                    "Nominal bid harus lebih dari Rp0.",
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            try
            {
                int idPembeli =
                    UserContext.CurrentUser!.IdUser;

                return BidContext.EksekusiBid(
                    idLelang,
                    idPembeli,
                    nominalTawaran);
            }
            catch (PostgresException ex)
            {
                MessageBox.Show(
                    ex.MessageText,
                    "Gagal Memasang Bid",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memasang bid: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }
    }
}