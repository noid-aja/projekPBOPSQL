using Npgsql;
using NpgsqlTypes;
using System;
using System.Data;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    internal static class TransaksiContext
    {
        public static bool TutupLelang(int idLelang)
        {
            DbExecutor.ExecuteCall(
                @"CALL kapten.sp_tutup_lelang(
                    @idLelang,
                    @persentaseKomisi
                );",

                new NpgsqlParameter(
                    "idLelang",
                    NpgsqlDbType.Integer)
                {
                    Value = idLelang
                },

                new NpgsqlParameter(
                    "persentaseKomisi",
                    NpgsqlDbType.Numeric)
                {
                    Value = 5.00m
                });

            return true;
        }

        public static bool UbahStatusPembayaran(
            int idTransaksi,
            string status)
        {
            DbExecutor.ExecuteCall(
                @"CALL kapten.sp_konfirmasi_pembayaran(
                    @idTransaksi,
                    @status
                );",

                new NpgsqlParameter(
                    "idTransaksi",
                    NpgsqlDbType.Integer)
                {
                    Value = idTransaksi
                },

                new NpgsqlParameter(
                    "status",
                    NpgsqlDbType.Varchar)
                {
                    Value = status.Trim().ToLowerInvariant()
                });

            return true;
        }

        public static bool AdminKonfirmasiLunas(
            int idTransaksi)
        {
            return UbahStatusPembayaran(
                idTransaksi,
                "lunas");
        }

        public static bool AdminKonfirmasiGagalBayar(
            int idTransaksi)
        {
            return UbahStatusPembayaran(
                idTransaksi,
                "dibatalkan");
        }

        public static DataTable AmbilSemuaDetail()
        {
            return DbExecutor.QueryTable(@"
                SELECT *
                FROM kapten.vw_transaksi_detail
                ORDER BY tgl_transaksi DESC;");
        }

        public static DataTable AmbilDetailById(
            int idTransaksi)
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_transaksi_detail
                  WHERE id_transaksi = @idTransaksi;",

                new NpgsqlParameter(
                    "idTransaksi",
                    NpgsqlDbType.Integer)
                {
                    Value = idTransaksi
                });
        }

        public static DataTable AmbilTransaksiPembeli(
            int idPembeli)
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_transaksi_detail
                  WHERE id_pembeli = @idPembeli
                  ORDER BY tgl_transaksi DESC;",

                new NpgsqlParameter(
                    "idPembeli",
                    NpgsqlDbType.Integer)
                {
                    Value = idPembeli
                });
        }

        public static DataTable AmbilTransaksiPetani(
            int idPetani)
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_transaksi_detail
                  WHERE id_petani = @idPetani
                  ORDER BY tgl_transaksi DESC;",

                new NpgsqlParameter(
                    "idPetani",
                    NpgsqlDbType.Integer)
                {
                    Value = idPetani
                });
        }

        public static DataTable AmbilTransaksiUntukGrid(string role, int idUser)
        {
            string query = role.ToLower() switch
            {
                "admin" => @"
                    select id_transaksi, nama_produk,
                           nama_pembeli as pembeli, nama_petani as petani,
                           total_bayar as harga_final, tgl_transaksi, status_bayar as status_pembayaran, 'Transfer' as metode_pembayaran
                    from kapten.vw_transaksi_detail
                    order by id_transaksi desc",
                "petani" => @"
                    select id_transaksi, nama_produk,
                           nama_pembeli as pembeli,
                           total_bayar as harga_final, tgl_transaksi, status_bayar as status_pembayaran, 'Transfer' as metode_pembayaran
                    from kapten.vw_transaksi_detail
                    where id_petani = @idUser
                    order by id_transaksi desc",
                "pembeli" => @"
                    select id_transaksi, nama_produk,
                           nama_petani as petani,
                           total_bayar as harga_final, tgl_transaksi, status_bayar as status_pembayaran, 'Transfer' as metode_pembayaran
                    from kapten.vw_transaksi_detail
                    where id_pembeli = @idUser
                    order by id_transaksi desc",
                _ => "select 1"
            };

            if (query.Contains("@idUser"))
            {
                return DbExecutor.QueryTable(query, new NpgsqlParameter("idUser", NpgsqlDbType.Integer) { Value = idUser });
            }
            return DbExecutor.QueryTable(query);
        }

        public static void CekDanTutupLelangExpired()
        {
            DataTable lelangExpired =
                DbExecutor.QueryTable(@"
                    SELECT id_lelang
                    FROM kapten.lelang
                    WHERE status_lelang = 'berlangsung'
                      AND tgl_akhir <= CURRENT_TIMESTAMP
                    ORDER BY id_lelang;");

            foreach (DataRow row in lelangExpired.Rows)
            {
                int idLelang =
                    Convert.ToInt32(row["id_lelang"]);

                try
                {
                    TutupLelang(idLelang);
                }
                catch (PostgresException ex)
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"Gagal menutup lelang {idLelang}: " +
                        ex.MessageText);
                }
            }
        }
    }
}