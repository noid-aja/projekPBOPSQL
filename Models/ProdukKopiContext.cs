using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    public static class ProdukKopiContext
    {
        // =====================================================
        // INSERT PRODUK
        // =====================================================

        public static bool TambahProduk(
            int idPetani,
            string namaProduk,
            int idJenis,
            decimal beratKg,
            decimal hargaPengajuan,
            string? deskripsi)
        {
            DbExecutor.ExecuteCall(
                @"CALL kapten.sp_tambah_produk(
                    @idPetani,
                    @idJenis,
                    @namaProduk,
                    @beratKg,
                    @hargaPengajuan,
                    @deskripsi
                );",

                new NpgsqlParameter(
                    "idPetani",
                    NpgsqlDbType.Integer)
                {
                    Value = idPetani
                },

                new NpgsqlParameter(
                    "idJenis",
                    NpgsqlDbType.Integer)
                {
                    Value = idJenis
                },

                new NpgsqlParameter(
                    "namaProduk",
                    NpgsqlDbType.Varchar)
                {
                    Value = namaProduk.Trim()
                },

                new NpgsqlParameter(
                    "beratKg",
                    NpgsqlDbType.Numeric)
                {
                    Value = beratKg
                },

                new NpgsqlParameter(
                    "hargaPengajuan",
                    NpgsqlDbType.Numeric)
                {
                    Value = hargaPengajuan
                },

                new NpgsqlParameter(
                    "deskripsi",
                    NpgsqlDbType.Text)
                {
                    Value = string.IsNullOrWhiteSpace(deskripsi)
                        ? DBNull.Value
                        : deskripsi.Trim()
                });

            return true;
        }

        // =====================================================
        // UPDATE HARGA PRODUK
        // =====================================================

        public static bool UbahHargaProduk(
            int idProduk,
            int idPetani,
            decimal hargaBaru)
        {
            DbExecutor.ExecuteCall(
                @"CALL kapten.sp_ubah_harga_produk(
                    @idProduk,
                    @idPetani,
                    @hargaBaru
                );",

                new NpgsqlParameter(
                    "idProduk",
                    NpgsqlDbType.Integer)
                {
                    Value = idProduk
                },

                new NpgsqlParameter(
                    "idPetani",
                    NpgsqlDbType.Integer)
                {
                    Value = idPetani
                },

                new NpgsqlParameter(
                    "hargaBaru",
                    NpgsqlDbType.Numeric)
                {
                    Value = hargaBaru
                });

            return true;
        }

        // =====================================================
        // DELETE PRODUK PENDING
        // =====================================================

        public static bool HapusProdukPending(
            int idProduk,
            int idPetani)
        {
            DbExecutor.ExecuteCall(
                @"CALL kapten.sp_hapus_produk_pending(
                    @idProduk,
                    @idPetani
                );",

                new NpgsqlParameter(
                    "idProduk",
                    NpgsqlDbType.Integer)
                {
                    Value = idProduk
                },

                new NpgsqlParameter(
                    "idPetani",
                    NpgsqlDbType.Integer)
                {
                    Value = idPetani
                });

            return true;
        }

        // =====================================================
        // AMBIL PRODUK PENDING
        // =====================================================

        public static List<ProdukKopi> AmbilProdukPending()
        {
            DataTable table = DbExecutor.QueryTable(@"
                SELECT *
                FROM kapten.vw_produk_detail
                WHERE status_produk = 'pending_inspeksi'
                ORDER BY id_produk ASC;");

            return MapProdukList(table);
        }

        // =====================================================
        // AMBIL PRODUK BERDASARKAN ID
        // =====================================================

        public static ProdukKopi? AmbilById(int idProduk)
        {
            DataTable table = DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_produk_detail
                  WHERE id_produk = @idProduk;",

                new NpgsqlParameter(
                    "idProduk",
                    NpgsqlDbType.Integer)
                {
                    Value = idProduk
                });

            if (table.Rows.Count == 0)
                return null;

            return MapProduk(table.Rows[0]);
        }

        // =====================================================
        // CARI PRODUK BERDASARKAN NAMA
        // =====================================================

        public static List<ProdukKopi> CariByNama(
            string nama)
        {
            DataTable table = DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_produk_detail
                  WHERE nama_produk ILIKE @nama
                  ORDER BY id_produk ASC;",

                new NpgsqlParameter(
                    "nama",
                    NpgsqlDbType.Varchar)
                {
                    Value = "%" + nama.Trim() + "%"
                });

            return MapProdukList(table);
        }

        // =====================================================
        // PRODUK MILIK PETANI
        // Menggunakan function yang sudah ada di PostgreSQL.
        // =====================================================

        public static DataTable AmbilProdukPetani(
            int idPetani)
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.fn_produk_petani(
                      @idPetani
                  );",

                new NpgsqlParameter(
                    "idPetani",
                    NpgsqlDbType.Integer)
                {
                    Value = idPetani
                });
        }

        // =====================================================
        // MAPPING DATATABLE KE MODEL
        // =====================================================

        private static List<ProdukKopi> MapProdukList(
            DataTable table)
        {
            var list = new List<ProdukKopi>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(MapProduk(row));
            }

            return list;
        }

        private static ProdukKopi MapProduk(DataRow row)
        {
            string status =
                Convert.ToString(row["status_produk"])
                ?? string.Empty;

            return new ProdukKopi(
                Convert.ToInt32(row["id_produk"]),
                Convert.ToInt32(row["id_petani"]),
                Convert.ToInt32(row["id_jenis"]),
                Convert.ToString(row["nama_produk"])
                    ?? string.Empty,
                Convert.ToDecimal(row["berat_kg"]),
                Convert.ToDecimal(row["harga_pengajuan"]),
                row["deskripsi"] == DBNull.Value
                    ? null
                    : Convert.ToString(row["deskripsi"]),
                Enum.ParseStatusProduk(status)
            );
        }
    }
}