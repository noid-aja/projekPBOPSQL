using Npgsql;
using NpgsqlTypes;
using System.Data;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    internal static class PemenangLelangContext
    {
        public static DataTable AmbilSemuaPemenang()
        {
            return DbExecutor.QueryTable(@"
                SELECT *
                FROM kapten.vw_pemenang_lelang_detail
                ORDER BY tgl_ditetapkan DESC;");
        }

        public static DataTable AmbilPemenangById(
            int idPemenang)
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_pemenang_lelang_detail
                  WHERE id_pemenang = @idPemenang;",

                new NpgsqlParameter(
                    "idPemenang",
                    NpgsqlDbType.Integer)
                {
                    Value = idPemenang
                });
        }

        public static DataTable AmbilPemenangPembeli(
            int idPembeli)
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_pemenang_lelang_detail
                  WHERE id_pembeli = @idPembeli
                  ORDER BY tgl_ditetapkan DESC;",

                new NpgsqlParameter(
                    "idPembeli",
                    NpgsqlDbType.Integer)
                {
                    Value = idPembeli
                });
        }

        public static DataTable AmbilPemenangPetani(
            int idPetani)
        {
            return DbExecutor.QueryTable(
                @"SELECT *
                  FROM kapten.vw_pemenang_lelang_detail
                  WHERE id_petani = @idPetani
                  ORDER BY tgl_ditetapkan DESC;",

                new NpgsqlParameter(
                    "idPetani",
                    NpgsqlDbType.Integer)
                {
                    Value = idPetani
                });
        }
    }
}