using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Controllers
{
    public class LelangController : Isearch<Lelang>
    {
        public Lelang? Cari(int id)
        {
            return LelangContext.AmbilLelangById(id);
        }

        public List<Lelang> CariNama(string namaLokasi)
        {
            return LelangContext.CariLelangByLokasi(namaLokasi);
        }

        public bool ProsesBukaLelang(int idProduk, string? lokasiLelang, string statusLelang, int durasiMenit)
        {
            if (!UserContext.IsLoggedIn())
            {
                MessageBox.Show("Login dulu ya.", "Akses Ditolak",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!UserContext.IsAdmin())
            {
                MessageBox.Show("Hanya Admin yang bisa membuka lelang.", "Akses Ditolak",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                return LelangContext.EksekusiBukaLelang(idProduk, lokasiLelang, statusLelang, durasiMenit);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Controller", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool TutupLelangManual(int idLelang)
        {
            if (!UserContext.IsLoggedIn() || !UserContext.IsAdmin())
            {
                MessageBox.Show("Hanya Admin yang bisa menutup lelang.", "Akses Ditolak",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return TransaksiContext.TutupLelang(idLelang);
        }

        public System.Data.DataTable DapatkanPesertaLelang(int idLelang)
        {
            if (!UserContext.IsLoggedIn() || !UserContext.IsAdmin())
            {
                MessageBox.Show("Akses ditolak. Hanya Admin yang bisa melihat daftar peserta lelang.",
                    "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new System.Data.DataTable();
            }
            return LelangContext.AmbilPesertaLelang(idLelang);
        }

        public System.Data.DataTable DapatkanHasilLelang()
        {
            return LelangContext.AmbilHasilLelang();
        }
    }
}
