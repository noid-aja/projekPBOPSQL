using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    internal static class JenisKopiContext
    {
        public static List<JenisKopi> AmbilSemua()
        {
            DataTable table = DbExecutor.QueryTable(@"
                SELECT *
                FROM kapten.vw_jenis_kopi
                ORDER BY id_jenis ASC;");

            var list = new List<JenisKopi>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new JenisKopi(
                    Convert.ToInt32(row["id_jenis"]),
                    row["nama_jenis"].ToString() ?? string.Empty,
                    row["deskripsi"] == DBNull.Value
                        ? null
                        : row["deskripsi"].ToString()
                ));
            }

            return list;
        }

        public static DataTable AmbilSemuaDataTable()
        {
            return DbExecutor.QueryTable("select id_jenis, nama_jenis, deskripsi from kapten.vw_jenis_kopi order by id_jenis;");
        }

        public static DataTable AmbilIdDanNama()
        {
            return DbExecutor.QueryTable("select id_jenis, nama_jenis from kapten.vw_jenis_kopi order by nama_jenis;");
        }

        public static void Tambah(string nama, string? deskripsi)
        {
            DbExecutor.ExecuteCall(
                "insert into kapten.jenis_kopi(nama_jenis, deskripsi) values(@nama, @deskripsi);",
                new NpgsqlParameter("nama", NpgsqlDbType.Varchar) { Value = nama.Trim() },
                new NpgsqlParameter("deskripsi", NpgsqlDbType.Varchar) { Value = string.IsNullOrWhiteSpace(deskripsi) ? DBNull.Value : deskripsi.Trim() }
            );
        }

        public static void Ubah(int id, string nama, string? deskripsi)
        {
            DbExecutor.ExecuteCall(
                "update kapten.jenis_kopi set nama_jenis=@nama, deskripsi=@deskripsi where id_jenis=@id;",
                new NpgsqlParameter("nama", NpgsqlDbType.Varchar) { Value = nama.Trim() },
                new NpgsqlParameter("deskripsi", NpgsqlDbType.Varchar) { Value = string.IsNullOrWhiteSpace(deskripsi) ? DBNull.Value : deskripsi.Trim() },
                new NpgsqlParameter("id", NpgsqlDbType.Integer) { Value = id }
            );
        }

        public static void Hapus(int id)
        {
            DbExecutor.ExecuteCall(
                "delete from kapten.jenis_kopi where id_jenis = @id;",
                new NpgsqlParameter("id", NpgsqlDbType.Integer) { Value = id }
            );
        }
    }
}