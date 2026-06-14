using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;
using Npgsql;

namespace WinFormsApp1.Controllers
{
    public class LelangController : Isearch<Lelang>
    {
        public Lelang? Cari(int id)
        {
            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand(@"
                    select id_lelang, id_produk, bid_minimum, tgl_mulai, tgl_akhir, lokasi_lelang, status_lelang
                    from kapten.lelang
                    where id_lelang = @id", conn);
                cmd.Parameters.AddWithValue("id", id);
                using var reader = cmd.ExecuteReader();
                if (!reader.Read()) return null;
                return new Lelang(
                    reader.GetInt32(0), reader.GetInt32(1), reader.GetDecimal(2),
                    reader.GetDateTime(3), reader.GetDateTime(4),
                    reader.IsDBNull(5) ? null : reader.GetString(5),
                    WinFormsApp1.Models.Enum.ParseStatusLelang(reader.GetString(6)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencari lelang: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Lelang> CariNama(string namaLokasi)
        {
            var list = new List<Lelang>();
            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand(@"
                    select id_lelang, id_produk, bid_minimum, tgl_mulai, tgl_akhir, lokasi_lelang, status_lelang
                    from kapten.lelang
                    where lower(lokasi_lelang) like lower(@nama)
                    order by id_lelang desc", conn);
                cmd.Parameters.AddWithValue("nama", "%" + namaLokasi.Trim() + "%");
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(new Lelang(
                        reader.GetInt32(0), reader.GetInt32(1), reader.GetDecimal(2),
                        reader.GetDateTime(3), reader.GetDateTime(4),
                        reader.IsDBNull(5) ? null : reader.GetString(5),
                        WinFormsApp1.Models.Enum.ParseStatusLelang(reader.GetString(6))));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencari lelang: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        public bool ProsesBukaLelang(int idProduk, string? lokasiLelang)
        {
            if (!UserContext.IsLoggedIn())
            {
                MessageBox.Show("Login dulu ya.", "Akses Ditolak",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!UserContext.IsAdmin())
            {
                MessageBox.Show("Hanya Admin yang bisa membuka lelang.", "Akses Ditolak",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                return LelangContext.EksekusiBukaLelang(idProduk, lokasiLelang);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Controller", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
