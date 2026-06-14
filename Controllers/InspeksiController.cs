using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Controllers
{
    public class InspeksiController : Isearch<Inspeksi>
    {
        public Inspeksi? Cari(int id) => InspeksiContext.AmbilById(id);

        public List<Inspeksi> CariNama(string nama) => InspeksiContext.CariByNamaProduk(nama);

        public bool KirimHasilQc(
            int idProduk,
            int nilai,
            decimal hargaRekomendasi,
            string? catatan,
            bool isLolos)
        {
            if (!UserContext.IsLoggedIn())
            {
                MessageBox.Show("Sesi login habis. Silakan login kembali.", "Akses Ditolak",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!UserContext.IsInspektor())
            {
                MessageBox.Show("Akses ditolak. Hanya Inspektor yang bisa mengisi hasil QC.",
                    "Bukan Inspektor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (nilai < 0 || nilai > 100)
            {
                MessageBox.Show("Nilai QC harus antara 0 sampai 100.", "Validasi Gagal",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string gradeOtomatis = nilai >= 85 ? "A"
                                 : nilai >= 70 ? "B"
                                 : nilai >= 50 ? "C"
                                 : "D";

            try
            {
                int idInspektor = UserContext.CurrentUser!.IdUser;
                return InspeksiContext.SimpanHasilInspeksi(
                    idProduk, idInspektor, nilai, gradeOtomatis, hargaRekomendasi, catatan, isLolos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Controller", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
