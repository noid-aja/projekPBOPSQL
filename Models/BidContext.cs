using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    public class BidContext
    {
        public static bool EksekusiBid(int idLelang, int idPembeli, decimal nominalBid)
        {
            using var conn = ConnectDB.GetConnection();
            conn.Open();
            using var trans = conn.BeginTransaction();

            try
            {
                using var cekLelang = new NpgsqlCommand(@"
                    select bid_minimum, tgl_akhir, status_lelang 
                    from kapten.lelang 
                    where id_lelang = @idLelang for update", conn, trans); 
                cekLelang.Parameters.AddWithValue("idLelang", idLelang);

                using var reader = cekLelang.ExecuteReader();
                if (!reader.Read()) throw new Exception("Data lelang tidak ada");

                decimal bidMinimum = reader.GetDecimal(0);
                DateTime tglAkhir = reader.GetDateTime(1);
                string statusLelang = reader.GetString(2);
                reader.Close();

                if (statusLelang != "berlangsung")
                    throw new Exception("Lelang telah selesai!");

                if (DateTime.Now > tglAkhir)
                    throw new Exception("Waktu lelang sudah terlewat");

                using var cekBidmax = new NpgsqlCommand(@"select coalesce(max(nominal), 0) 
                                                        from kapten.bid where id_lelang = @idLelang", conn);
                cekBidmax.Parameters.AddWithValue("idLelang", idLelang);
                decimal bidTertinggi = Convert.ToDecimal(cekBidmax.ExecuteScalar());

                decimal batasMinimal = bidTertinggi > 0 ? bidTertinggi : bidMinimum;

                if (nominalBid <= batasMinimal)
                    throw new Exception($"Nominal bid lu kekecilan! Harus lebih tinggi dari {batasMinimal:N0}");

                TimeSpan sisaWaktu = tglAkhir - DateTime.Now;
                bool dapetBonusWaktu = false;

                if (sisaWaktu.TotalMinutes <= 1.0)
                {
                    tglAkhir = tglAkhir.AddSeconds(10); 
                    dapetBonusWaktu = true;

                    using var updateWaktu = new NpgsqlCommand(@"
                        update kapten.lelang set tgl_akhir = @tglAkhir where id_lelang = @idLelang", conn);
                    updateWaktu.Parameters.AddWithValue("tglAkhir", tglAkhir);
                    updateWaktu.Parameters.AddWithValue("idLelang", idLelang);
                    updateWaktu.ExecuteNonQuery();
                }

                using var inputBid = new NpgsqlCommand(@"
                    insert into kapten.bid (id_lelang, id_pembeli, nominal, tgl_bid) 
                    values (@idLelang, @idPembeli, @nominal, @tglBid)", conn);
                inputBid.Parameters.AddWithValue("idLelang", idLelang);
                inputBid.Parameters.AddWithValue("idPembeli", idPembeli);
                inputBid.Parameters.AddWithValue("nominal", nominalBid);
                inputBid.Parameters.AddWithValue("tglBid", DateTime.Now);
                inputBid.ExecuteNonQuery();

                trans.Commit();

                if (dapetBonusWaktu)
                    MessageBox.Show("Karena kurang dari 1 menut akan dapat 10 detik!", 
                                    "Bonus Waktu Active", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message, "Gagal Nge-Bid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public static List<Bid> AmbilRiwayatBidPembeli(int idPembeli)
        {
            var listBid = new List<Bid>();

            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();

                using var cmd = new NpgsqlCommand(@"
                    select id_bid, id_lelang, id_pembeli, nominal, tgl_bid 
                    from kapten.bid 
                    where id_pembeli = @idPembeli 
                    order by tgl_bid DESC", conn);

                cmd.Parameters.AddWithValue("idPembeli", idPembeli);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listBid.Add(new Bid(
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
                System.Windows.Forms.MessageBox.Show("Gagal mengambil riwayat bid: " + ex.Message,
                                                     "Error Database", 
                                                      System.Windows.Forms.MessageBoxButtons.OK, 
                                                      System.Windows.Forms.MessageBoxIcon.Error);
            }

            return listBid;
        }

        public static Bid? CariBidById(int id)
        {
            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand(@"
                    select id_bid, id_lelang, id_pembeli, nominal, tgl_bid
                    from kapten.bid
                    where id_bid = @id", conn);
                cmd.Parameters.AddWithValue("id", id);
                using var reader = cmd.ExecuteReader();
                if (!reader.Read()) return null;
                return new Bid(
                    reader.GetInt32(0), 
                    reader.GetInt32(1), 
                    reader.GetInt32(2),
                    reader.GetDecimal(3),
                    reader.GetDateTime(4));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal mencari bid: " + ex.Message, 
                                                     "Error SQL",
                                                     System.Windows.Forms.MessageBoxButtons.OK, 
                                                     System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public static List<Bid> CariBidByNamaProduk(string nama)
        {
            var list = new List<Bid>();
            try
            {
                using var conn = ConnectDB.GetConnection();
                conn.Open();
                using var cmd = new NpgsqlCommand(@"
                    select b.id_bid, b.id_lelang, b.id_pembeli, b.nominal, b.tgl_bid
                    from kapten.bid b
                    join kapten.lelang l on l.id_lelang = b.id_lelang
                    join kapten.produk_kopi p on p.id_produk = l.id_produk
                    where lower(p.nama_produk) like lower(@nama)
                    order by b.tgl_bid desc", conn);
                cmd.Parameters.AddWithValue("nama", "%" + nama.Trim() + "%");
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add(new Bid(
                        reader.GetInt32(0), 
                        reader.GetInt32(1), 
                        reader.GetInt32(2),
                        reader.GetDecimal(3),
                        reader.GetDateTime(4)));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal mencari bid: " + ex.Message, 
                                                     "Error SQL",
                                                     System.Windows.Forms.MessageBoxButtons.OK, 
                                                     System.Windows.Forms.MessageBoxIcon.Error);
            }
            return list;
        }
    }
}
