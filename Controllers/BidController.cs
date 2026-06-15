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

        public bool KirimBid(int idLelang, decimal nominalTawaran)
        {
            if (!UserContext.IsLoggedIn())
            {
                MessageBox.Show("Login dulu ya.", "Akses Ditolak",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!UserContext.IsPembeli())
            {
                MessageBox.Show("Hanya Pembeli yang bisa memasukkan bid.", "Akses Ditolak",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                int idPembeli = UserContext.CurrentUser!.IdUser;
                return BidContext.EksekusiBid(idLelang, idPembeli, nominalTawaran);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Controller", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
