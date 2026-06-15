using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Controllers
{
    public class ProdukKopiController : Isearch<ProdukKopi>
    {
        public ProdukKopi? Cari(int id) => ProdukKopiContext.AmbilById(id);

        public List<ProdukKopi> CariNama(string nama) => ProdukKopiContext.CariByNama(nama);

        public bool KirimPengajuanProduk(
            string namaProduk,
            int idJenis,
            decimal beratKg,
            decimal hargaPengajuan,
            string? deskripsi)
        {
            if (!UserContext.IsLoggedIn())
            {
                MessageBox.Show("Login dulu ya.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!UserContext.IsPetani())
            {
                MessageBox.Show("Hanya Petani yang bisa mengajukan produk.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(namaProduk))
            {
                MessageBox.Show("Nama produk tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (beratKg <= 0)
            {
                MessageBox.Show("Berat harus lebih dari 0.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (hargaPengajuan <= 0)
            {
                MessageBox.Show("Harga pengajuan harus lebih dari 0.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                int idPetani = UserContext.CurrentUser!.IdUser;
                bool sukses = ProdukKopiContext.TambahProduk(
                    idPetani, namaProduk.Trim(), idJenis, beratKg, hargaPengajuan, deskripsi);
                return sukses;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Controller", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
