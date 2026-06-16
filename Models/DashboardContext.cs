using Npgsql;
using NpgsqlTypes;
using System.Data;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    public static class DashboardContext
    {


        public static DataTable AmbilRingkasan(
            int idUser,
            string role)
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.fn_dashboard_ringkas(
                      @idUser,
                      @role
                  );",

                new NpgsqlParameter(
                    "idUser",
                    NpgsqlDbType.Integer)
                {
                    Value = idUser
                },

                new NpgsqlParameter(
                    "role",
                    NpgsqlDbType.Varchar)
                {
                    Value = role.Trim().ToLowerInvariant()
                });
        }


        public static DataTable AmbilProdukAdmin()
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_produk_detail");
        }

        public static DataTable AmbilLelangAdmin()
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_lelang_detail
                  ORDER BY id_lelang DESC;");
        }

        public static DataTable AmbilTransaksiAdmin()
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_transaksi_detail
                  ORDER BY tgl_transaksi DESC;");
        }


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

        public static DataTable GetProdukPetani(
            int idPetani)
        {
            return AmbilProdukPetani(idPetani);
        }


        public static DataTable AmbilLelangTersedia(
            int idPembeli)
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.fn_lelang_tersedia(
                      @idPembeli
                  );",

                new NpgsqlParameter(
                    "idPembeli",
                    NpgsqlDbType.Integer)
                {
                    Value = idPembeli
                });
        }

        public static DataTable AmbilRiwayatBidPembeli(
            int idPembeli)
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.fn_riwayat_bid_pembeli(
                      @idPembeli
                  );",

                new NpgsqlParameter(
                    "idPembeli",
                    NpgsqlDbType.Integer)
                {
                    Value = idPembeli
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


        public static DataTable AmbilProdukPendingInspeksi()
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_produk_detail
                  WHERE status_produk = 'pending_inspeksi'
                  ORDER BY id_produk DESC;");
        }

        public static DataTable AmbilRiwayatInspeksi(
            int idInspektor)
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_produk_detail
                  WHERE id_inspektor = @idInspektor
                  ORDER BY tgl_inspeksi DESC;",

                new NpgsqlParameter(
                    "idInspektor",
                    NpgsqlDbType.Integer)
                {
                    Value = idInspektor
                });
        }


        public static DataTable AmbilLaporanGroupBy()
        {
            return DbExecutor.QueryTable(
                "SELECT * FROM kapten.vw_groupby_produk;");
        }

        public static DataTable AmbilLaporanPerformaPetani()
        {
            return DbExecutor.QueryTable(
                "SELECT * FROM kapten.vw_groupby_performa_petani;");
        }

        public static DataTable AmbilLaporanRollup()
        {
            return DbExecutor.QueryTable(
                "SELECT * FROM kapten.vw_rollup_produk;");
        }

        public static DataTable AmbilLaporanCube()
        {
            return DbExecutor.QueryTable(
                "SELECT * FROM kapten.vw_cube_produk;");
        }

        public static DataTable AmbilLaporanGroupingSets()
        {
            return DbExecutor.QueryTable(
                "SELECT * FROM kapten.vw_grouping_sets_transaksi;");
        }


        public static DataTable AmbilProdukAdminView()
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_dashboard_produk_admin
                  ORDER BY ""ID Produk"" DESC;");
        }


        public static DataTable AmbilBidTertinggi()
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_bid_tertinggi
                  ORDER BY id_lelang DESC;");
        }


        public static DataTable AmbilSubqueryProdukDiAtasRata()
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_subquery_produk_di_atas_rata
                  ORDER BY id_produk ASC;");
        }


        public static DataTable AmbilSubqueryBidDiAtasRata()
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_subquery_bid_di_atas_rata
                  ORDER BY id_bid ASC;");
        }


        public static DataTable AmbilUnionAktivitasUser()
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_union_aktivitas_user
                  ORDER BY waktu DESC NULLS LAST;");
        }


        public static DataTable AmbilIntersectPetaniPembeli()
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_intersect_petani_pembeli
                  ORDER BY id_user ASC;");
        }


        public static DataTable AmbilExceptPembeliBelumBid()
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_except_pembeli_belum_bid
                  ORDER BY id_user ASC;");
        }
    }
}