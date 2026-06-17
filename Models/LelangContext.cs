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
            string? lokasiLelang,
            string statusLelang,
            int durasiMenit)
        {
            DbExecutor.ExecuteCall(
                @"CALL kapten.sp_buka_lelang(
                    @idProduk,
                    @lokasi,
                    @durasiMenit,
                    @statusLelang
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
                    Value = durasiMenit
                },

                new NpgsqlParameter(
                    "statusLelang",
                    NpgsqlDbType.Varchar)
                {
                    Value = statusLelang
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


        public static DataTable AmbilPesertaLelang(int idLelang)
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.fn_peserta_lelang(
                      @idLelang
                  );",

                new NpgsqlParameter(
                    "idLelang",
                    NpgsqlDbType.Integer)
                {
                    Value = idLelang
                });
        }

        public static DataTable AmbilHasilLelang()
        {
            return DbExecutor.QueryTable(@"
                SELECT
                    id_lelang,
                    nama_produk,
                    nama_petani,
                    nama_pembeli AS nama_pemenang,
                    harga_menang AS harga_pemenang,
                    tgl_ditetapkan AS tgl_selesai
                FROM kapten.vw_pemenang_lelang_detail
                ORDER BY tgl_ditetapkan DESC;");
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

        public static DataTable AmbilLelangAktifPembeli(int idPembeli)
        {
            return DbExecutor.QueryTable(
                @"SELECT * FROM kapten.fn_lelang_aktif_pembeli(@idPembeli);",
                new NpgsqlParameter("idPembeli", NpgsqlDbType.Integer) { Value = idPembeli });
        }

        public static DataTable AmbilJadwalLelang()
        {
            return DbExecutor.QueryTable(@"
                SELECT id_lelang, nama_produk,
                       nama_petani as petani,
                       nama_jenis as jenis,
                       bid_minimum, tgl_mulai, tgl_akhir,
                       lokasi_lelang, status_lelang as status
                FROM kapten.vw_lelang_detail
                ORDER BY tgl_mulai DESC;");
        }

        public static DataTable AmbilSemuaLelangDataTable()
        {
            return AmbilSemuaLelangDataTable("Semua");
        }

        public static DataTable AmbilSemuaLelangDataTable(string status)
        {
            if (string.IsNullOrEmpty(status) || status.Equals("Semua", StringComparison.OrdinalIgnoreCase))
            {
                return DbExecutor.QueryTable(@"
                    SELECT id_lelang, nama_produk, bid_minimum,
                           tgl_mulai, tgl_akhir, lokasi_lelang, status_lelang AS status,
                           COALESCE(bid_tertinggi, 0) AS bid_tertinggi,
                           jumlah_bid
                    FROM kapten.vw_lelang_detail
                    ORDER BY id_lelang DESC;");
            }

            return DbExecutor.QueryTable(@"
                SELECT id_lelang, nama_produk, bid_minimum,
                       tgl_mulai, tgl_akhir, lokasi_lelang, status_lelang AS status,
                       COALESCE(bid_tertinggi, 0) AS bid_tertinggi,
                       jumlah_bid
                FROM kapten.vw_lelang_detail
                WHERE status_lelang = @status
                ORDER BY id_lelang DESC;",
                new NpgsqlParameter("status", NpgsqlDbType.Varchar) { Value = status.ToLower().Trim() });
        }
    }
}