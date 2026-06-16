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
                    FROM kapten.vw_inspeksi_detail
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
                        id_inspeksi,
                        id_produk,
                        id_inspektor,
                        tgl_inspeksi,
                        nilai,
                        grade,
                        harga_rekomendasi,
                        catatan,
                        status_inspeksi
                    FROM kapten.vw_inspeksi_detail
                    WHERE nama_produk ILIKE @nama
                    ORDER BY id_inspeksi DESC;", conn);

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

        public static System.Data.DataTable AmbilHasilQCPetani(int idPetani)
        {
            return DbExecutor.QueryTable(@"
                SELECT nama_produk, nilai, harga_rekomendasi,
                       catatan, tgl_inspeksi, status_produk,
                       nama_inspektor as inspektor
                FROM kapten.vw_produk_detail
                WHERE id_petani = @idPetani AND tgl_inspeksi IS NOT NULL
                ORDER BY tgl_inspeksi DESC;",
                new NpgsqlParameter("idPetani", NpgsqlDbType.Integer) { Value = idPetani });
        }

        public static System.Data.DataTable AmbilPendingProducts()
        {
            return DbExecutor.QueryTable(@"
                SELECT id_produk, nama_produk, id_petani, id_jenis, berat_kg, harga_pengajuan, status_produk
                FROM kapten.vw_produk_detail
                WHERE status_produk = 'pending_inspeksi'
                ORDER BY id_produk;");
        }

        public static System.Data.DataTable AmbilRiwayatInspeksiDataTable(int idInspektor)
        {
            if (idInspektor > 0)
            {
                return DbExecutor.QueryTable(@"
                    SELECT id_inspeksi, nama_produk, nama_inspektor as inspektor,
                           nilai, harga_rekomendasi, catatan, tgl_inspeksi,
                           status_produk
                    FROM kapten.vw_produk_detail
                    WHERE id_inspektor = @id and tgl_inspeksi is not null
                    ORDER BY tgl_inspeksi DESC",
                    new NpgsqlParameter("id", NpgsqlDbType.Integer) { Value = idInspektor });
            }
            else
            {
                return DbExecutor.QueryTable(@"
                    SELECT id_inspeksi, nama_produk, nama_inspektor as inspektor,
                           nilai, harga_rekomendasi, catatan, tgl_inspeksi,
                           status_produk
                    FROM kapten.vw_produk_detail
                    WHERE tgl_inspeksi is not null
                    ORDER BY tgl_inspeksi DESC");
            }
        }
    }
}