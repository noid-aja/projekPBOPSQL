using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    public static class LelangContext
    {
        public static List<ProdukKopi> AmbilProdukSiapLelang()
        {
            DataTable table = DbExecutor.QueryTable(@"
                SELECT *
                FROM kapten.vw_produk_siap_lelang
                ORDER BY id_produk ASC;");

            var list = new List<ProdukKopi>();

            foreach (DataRow row in table.Rows)
            {
                string status =
                    Convert.ToString(row["status_produk"])
                    ?? string.Empty;

                list.Add(new ProdukKopi(
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
                ));
            }

            return list;
        }

        public static bool EksekusiBukaLelang(
            int idProduk,
            string? lokasiLelang)
        {
            DbExecutor.ExecuteCall(
                @"CALL kapten.sp_buka_lelang(
                    @idProduk,
                    @lokasi,
                    @durasiMenit
                );",

                new NpgsqlParameter(
                    "idProduk",
                    NpgsqlDbType.Integer)
                {
                    Value = idProduk
                },

                new NpgsqlParameter(
                    "lokasi",
                    NpgsqlDbType.Varchar)
                {
                    Value = string.IsNullOrWhiteSpace(lokasiLelang)
                        ? DBNull.Value
                        : lokasiLelang.Trim()
                },

                new NpgsqlParameter(
                    "durasiMenit",
                    NpgsqlDbType.Integer)
                {
                    Value = 3
                });

            return true;
        }

        public static Lelang? AmbilLelangById(int id)
        {
            DataTable table = DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_lelang_detail
                  WHERE id_lelang = @id;",

                new NpgsqlParameter(
                    "id",
                    NpgsqlDbType.Integer)
                {
                    Value = id
                });

            if (table.Rows.Count == 0)
                return null;

            return MapLelang(table.Rows[0]);
        }

        public static List<Lelang> CariLelangByLokasi(
            string namaLokasi)
        {
            DataTable table = DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_lelang_detail
                  WHERE lokasi_lelang ILIKE @lokasi
                  ORDER BY id_lelang DESC;",

                new NpgsqlParameter(
                    "lokasi",
                    NpgsqlDbType.Varchar)
                {
                    Value = "%" + namaLokasi.Trim() + "%"
                });

            var list = new List<Lelang>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(MapLelang(row));
            }

            return list;
        }

        private static Lelang MapLelang(DataRow row)
        {
            string status =
                Convert.ToString(row["status_lelang"])
                ?? string.Empty;

            return new Lelang(
                Convert.ToInt32(row["id_lelang"]),
                Convert.ToInt32(row["id_produk"]),
                Convert.ToDecimal(row["bid_minimum"]),
                Convert.ToDateTime(row["tgl_mulai"]),
                Convert.ToDateTime(row["tgl_akhir"]),
                row["lokasi_lelang"] == DBNull.Value
                    ? null
                    : Convert.ToString(
                        row["lokasi_lelang"]),
                Enum.ParseStatusLelang(status)
            );
        }
    }
}