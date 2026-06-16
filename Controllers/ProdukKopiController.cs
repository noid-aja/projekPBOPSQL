using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.Controllers
{
    public class ProdukKopiController : Isearch<ProdukKopi>
    {
        public ProdukKopi? Cari(int id)
        {
            if (id <= 0)
                return null;

            try
            {
                return ProdukKopiContext.AmbilById(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mencari produk: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return null;
            }
        }

        public List<ProdukKopi> CariNama(string nama)
        {
            if (string.IsNullOrWhiteSpace(nama))
                return new List<ProdukKopi>();

            try
            {
                return ProdukKopiContext.CariByNama(
                    nama.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mencari produk: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return new List<ProdukKopi>();
            }
        }

        public bool KirimPengajuanProduk(
            string namaProduk,
            int idJenis,
            decimal beratKg,
            decimal hargaPengajuan,
            string? deskripsi)
        {
            if (!ValidasiPetaniLogin())
                return false;

            if (string.IsNullOrWhiteSpace(namaProduk))
            {
                MessageBox.Show(
                    "Nama produk tidak boleh kosong.",
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (idJenis <= 0)
            {
                MessageBox.Show(
                    "Jenis kopi harus dipilih.",
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (beratKg <= 0)
            {
                MessageBox.Show(
                    "Berat harus lebih dari 0 kg.",
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (hargaPengajuan <= 0)
            {
                MessageBox.Show(
                    "Harga pengajuan harus lebih dari Rp0.",
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            try
            {
                int idPetani =
                    UserContext.CurrentUser!.IdUser;

                return ProdukKopiContext.TambahProduk(
                    idPetani,
                    namaProduk.Trim(),
                    idJenis,
                    beratKg,
                    hargaPengajuan,
                    deskripsi);
            }
            catch (PostgresException ex)
            {
                MessageBox.Show(
                    ex.MessageText,
                    "Pengajuan Produk Ditolak",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mengajukan produk: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        public bool UbahHargaProduk(
            int idProduk,
            decimal hargaBaru)
        {
            if (!ValidasiPetaniLogin())
                return false;

            if (idProduk <= 0)
            {
                MessageBox.Show(
                    "Pilih produk yang akan diubah.",
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (hargaBaru <= 0)
            {
                MessageBox.Show(
                    "Harga baru harus lebih dari Rp0.",
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            try
            {
                int idPetani =
                    UserContext.CurrentUser!.IdUser;

                return ProdukKopiContext.UbahHargaProduk(
                    idProduk,
                    idPetani,
                    hargaBaru);
            }
            catch (PostgresException ex)
            {
                MessageBox.Show(
                    ex.MessageText,
                    "Gagal Mengubah Harga",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mengubah harga produk: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        public bool HapusProdukPending(int idProduk)
        {
            if (!ValidasiPetaniLogin())
                return false;

            if (idProduk <= 0)
            {
                MessageBox.Show(
                    "Pilih produk yang akan dihapus.",
                    "Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            try
            {
                int idPetani =
                    UserContext.CurrentUser!.IdUser;

                return ProdukKopiContext.HapusProdukPending(
                    idProduk,
                    idPetani);
            }
            catch (PostgresException ex)
            {
                MessageBox.Show(
                    ex.MessageText,
                    "Gagal Menghapus Produk",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menghapus produk: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        private static bool ValidasiPetaniLogin()
        {
            if (!UserContext.IsLoggedIn())
            {
                MessageBox.Show(
                    "Login dulu ya.",
                    "Akses Ditolak",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (!UserContext.IsPetani())
            {
                MessageBox.Show(
                    "Hanya Petani yang dapat mengelola produk.",
                    "Akses Ditolak",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            return true;
        }
    }
}