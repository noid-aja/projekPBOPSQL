using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    public static class BidContext
    {
        public static bool EksekusiBid(
            int idLelang,
            int idPembeli,
            decimal nominalBid)
        {
            DbExecutor.ExecuteCall(
                @"CALL kapten.sp_pasang_bid(
                    @idLelang,
                    @idPembeli,
                    @nominal
                );",

                new NpgsqlParameter(
                    "idLelang",
                    NpgsqlDbType.Integer)
                {
                    Value = idLelang
                },

                new NpgsqlParameter(
                    "idPembeli",
                    NpgsqlDbType.Integer)
                {
                    Value = idPembeli
                },

                new NpgsqlParameter(
                    "nominal",
                    NpgsqlDbType.Numeric)
                {
                    Value = nominalBid
                });

            return true;
        }

        public static System.Data.DataTable AmbilRiwayatBidPembeli(
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

        public static Bid? CariBidById(int id)
        {
            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();

                using var cmd = new NpgsqlCommand(@"
                    SELECT
                        id_bid,
                        id_lelang,
                        id_pembeli,
                        nominal,
                        tgl_bid
                    FROM kapten.vw_bid_detail
                    WHERE id_bid = @id;", conn);

                cmd.Parameters.Add(
                    new NpgsqlParameter(
                        "id",
                        NpgsqlDbType.Integer)
                    {
                        Value = id
                    });

                using var reader = cmd.ExecuteReader();

                if (!reader.Read())
                    return null;

                return new Bid(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetInt32(2),
                    reader.GetDecimal(3),
                    reader.GetDateTime(4)
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mencari bid: " + ex.Message,
                    "Error SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return null;
            }
        }

        public static List<Bid> CariBidByNamaProduk(
            string nama)
        {
            var list = new List<Bid>();

            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();

                using var cmd = new NpgsqlCommand(@"
                    SELECT
                        id_bid,
                        id_lelang,
                        id_pembeli,
                        nominal,
                        tgl_bid
                    FROM kapten.vw_bid_detail
                    WHERE nama_produk ILIKE @nama
                    ORDER BY tgl_bid DESC;", conn);

                cmd.Parameters.Add(
                    new NpgsqlParameter(
                        "nama",
                        NpgsqlDbType.Varchar)
                    {
                        Value = "%" + nama.Trim() + "%"
                    });

                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Bid(
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetInt32(2),
                        reader.GetDecimal(3),
                        reader.GetDateTime(4)
                    ));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mencari bid: " + ex.Message,
                    "Error SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return list;
        }
    }
}