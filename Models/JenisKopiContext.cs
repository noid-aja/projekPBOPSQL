using System;
using System.Collections.Generic;
using System.Data;
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
    }
}