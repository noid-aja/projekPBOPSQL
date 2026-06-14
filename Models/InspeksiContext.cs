using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    public static class InspeksiContext
    {
        public static bool SimpanHasilInspeksi(int idProduk, int idInspektor, int nilai, string grade, decimal hargaRekomendasi, string? catatan, bool isLolos)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();

            using var trans = conn.BeginTransaction();
            try
            {
                using var cmdInspeksi = new NpgsqlCommand(@"
                    insert into kapten.inspeksi (id_produk, id_inspektor, tgl_inspeksi, nilai, grade, harga_rekomendasi, catatan, status_inspeksi) 
                    values (@idProduk, @idInspektor, @tgl, @nilai, @grade, @hargaRekomendasi, @catatan, @statusInspeksi)
                    on conflict (id_produk) do update
                    set id_inspektor = excluded.id_inspektor,
                        tgl_inspeksi = excluded.tgl_inspeksi,
                        nilai = excluded.nilai,
                        grade = excluded.grade,
                        harga_rekomendasi = excluded.harga_rekomendasi,
                        catatan = excluded.catatan,
                        status_inspeksi = excluded.status_inspeksi", conn);

                cmdInspeksi.Parameters.AddWithValue("idProduk", idProduk);
                cmdInspeksi.Parameters.AddWithValue("idInspektor", idInspektor);
                cmdInspeksi.Parameters.AddWithValue("tgl", DateTime.Today);
                cmdInspeksi.Parameters.AddWithValue("nilai", nilai);
                cmdInspeksi.Parameters.AddWithValue("grade", grade);
                cmdInspeksi.Parameters.AddWithValue("hargaRekomendasi", hargaRekomendasi);
                cmdInspeksi.Parameters.AddWithValue("catatan", (object?)catatan?.Trim() ?? DBNull.Value);
                cmdInspeksi.Parameters.AddWithValue("statusInspeksi", isLolos ? "lolos_qc" : "ditolak_qc");
                cmdInspeksi.ExecuteNonQuery();

                string statusBaru = isLolos ? "lolos_qc" : "ditolak_qc";

                using var cmdProduk = new NpgsqlCommand(@"
                    update kapten.produk_kopi 
                    set status_produk = @status 
                    where id_produk = @idProduk", conn);

                cmdProduk.Parameters.AddWithValue("status", statusBaru);
                cmdProduk.Parameters.AddWithValue("idProduk", idProduk);
                cmdProduk.ExecuteNonQuery();

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Gagal menyimpan data QC ke DB: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        /// <summary>[Abstraction] Digunakan oleh InspeksiController yang implements ISearch.</summary>
        public static Inspeksi? AmbilById(int idInspeksi)
        {
            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand(@"
                    select id_inspeksi, id_produk, id_inspektor, tgl_inspeksi, nilai, grade, harga_rekomendasi, catatan, status_inspeksi
                    from kapten.inspeksi
                    where id_inspeksi = @id", conn);
                cmd.Parameters.AddWithValue("id", idInspeksi);
                using var reader = cmd.ExecuteReader();
                if (!reader.Read()) return null;
                return new Inspeksi(
                    reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),
                    reader.GetDateTime(3), reader.GetInt32(4),
                    reader.IsDBNull(5) ? "" : reader.GetString(5),
                    reader.IsDBNull(6) ? 0m : reader.GetDecimal(6),
                    reader.IsDBNull(7) ? null : reader.GetString(7),
                    !reader.IsDBNull(8) && reader.GetString(8) == "lolos_qc");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil inspeksi: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>[Abstraction] Digunakan oleh InspeksiController yang implements ISearch.</summary>
        public static List<Inspeksi> CariByNamaProduk(string namaProduk)
        {
            var list = new List<Inspeksi>();
            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand(@"
                    select i.id_inspeksi, i.id_produk, i.id_inspektor, i.tgl_inspeksi,
                           i.nilai, i.grade, i.harga_rekomendasi, i.catatan, i.status_inspeksi
                    from kapten.inspeksi i
                    join kapten.produk_kopi p on p.id_produk = i.id_produk
                    where lower(p.nama_produk) like lower(@nama)
                    order by i.id_inspeksi desc", conn);
                cmd.Parameters.AddWithValue("nama", "%" + namaProduk.Trim() + "%");
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Inspeksi(
                        reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),
                        reader.GetDateTime(3), reader.GetInt32(4),
                        reader.IsDBNull(5) ? "" : reader.GetString(5),
                        reader.IsDBNull(6) ? 0m : reader.GetDecimal(6),
                        reader.IsDBNull(7) ? null : reader.GetString(7),
                        !reader.IsDBNull(8) && reader.GetString(8) == "lolos_qc"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencari inspeksi: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
    }
    
}
