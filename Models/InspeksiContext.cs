using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    public static class InspeksiContext
    {
        public static bool SimpanHasilInspeksi(
            int idProduk,
            int idInspektor,
            int nilai,
            decimal hargaRekomendasi,
            string? catatan)
        {
            DbExecutor.ExecuteCall(
                @"CALL kapten.sp_simpan_inspeksi(
                    @idProduk,
                    @idInspektor,
                    @nilai,
                    @hargaRekomendasi,
                    @catatan
                );",

                new NpgsqlParameter(
                    "idProduk",
                    NpgsqlDbType.Integer)
                {
                    Value = idProduk
                },

                new NpgsqlParameter(
                    "idInspektor",
                    NpgsqlDbType.Integer)
                {
                    Value = idInspektor
                },

                new NpgsqlParameter(
                    "nilai",
                    NpgsqlDbType.Integer)
                {
                    Value = nilai
                },

                new NpgsqlParameter(
                    "hargaRekomendasi",
                    NpgsqlDbType.Numeric)
                {
                    Value = hargaRekomendasi
                },

                new NpgsqlParameter(
                    "catatan",
                    NpgsqlDbType.Text)
                {
                    Value = string.IsNullOrWhiteSpace(catatan)
                        ? DBNull.Value
                        : catatan.Trim()
                });

            return true;
        }

        public static Inspeksi? AmbilById(int idInspeksi)
        {
            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();

                using var cmd = new NpgsqlCommand(@"
                    SELECT
                        id_inspeksi,
                        id_produk,
                        id_inspektor,
                        tgl_inspeksi,
                        nilai,
                        grade,
                        harga_rekomendasi,
                        catatan,
                        status_inspeksi
                    FROM kapten.inspeksi
                    WHERE id_inspeksi = @id;", conn);

                cmd.Parameters.AddWithValue("id", idInspeksi);

                using var reader = cmd.ExecuteReader();

                if (!reader.Read())
                    return null;

                return new Inspeksi(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetInt32(2),
                    reader.GetDateTime(3),
                    reader.GetInt32(4),
                    reader.IsDBNull(5) ? "" : reader.GetString(5),
                    reader.IsDBNull(6) ? 0m : reader.GetDecimal(6),
                    reader.IsDBNull(7) ? null : reader.GetString(7),
                    !reader.IsDBNull(8) &&
                    reader.GetString(8) == "lolos_qc"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mengambil inspeksi: " + ex.Message,
                    "Error SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return null;
            }
        }

        public static List<Inspeksi> CariByNamaProduk(
            string namaProduk)
        {
            var list = new List<Inspeksi>();

            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();

                using var cmd = new NpgsqlCommand(@"
                    SELECT
                        i.id_inspeksi,
                        i.id_produk,
                        i.id_inspektor,
                        i.tgl_inspeksi,
                        i.nilai,
                        i.grade,
                        i.harga_rekomendasi,
                        i.catatan,
                        i.status_inspeksi
                    FROM kapten.inspeksi i
                    JOIN kapten.produk_kopi p
                        ON p.id_produk = i.id_produk
                    WHERE p.nama_produk ILIKE @nama
                    ORDER BY i.id_inspeksi DESC;", conn);

                cmd.Parameters.AddWithValue(
                    "nama",
                    "%" + namaProduk.Trim() + "%");

                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Inspeksi(
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetInt32(2),
                        reader.GetDateTime(3),
                        reader.GetInt32(4),
                        reader.IsDBNull(5)
                            ? ""
                            : reader.GetString(5),
                        reader.IsDBNull(6)
                            ? 0m
                            : reader.GetDecimal(6),
                        reader.IsDBNull(7)
                            ? null
                            : reader.GetString(7),
                        !reader.IsDBNull(8) &&
                        reader.GetString(8) == "lolos_qc"
                    ));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mencari inspeksi: " + ex.Message,
                    "Error SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return list;
        }
    }
}