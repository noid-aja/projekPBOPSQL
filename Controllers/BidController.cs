using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;
using Npgsql;

namespace WinFormsApp1.Controllers
{
    public class BidController : Isearch<Bid>
    {
        public Bid? Cari(int id)
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
                    reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),
                    reader.GetDecimal(3), reader.GetDateTime(4));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencari bid: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Bid> CariNama(string nama)
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
                        reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),
                        reader.GetDecimal(3), reader.GetDateTime(4)));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencari bid: " + ex.Message, "Error SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }

        public bool KirimBid(int idLelang, decimal nominalTawaran)
        {
            if (!UserContext.IsLoggedIn())
            {
                MessageBox.Show("Login dulu ya.", "Akses Ditolak",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!UserContext.IsPembeli())
            {
                MessageBox.Show("Hanya Pembeli yang bisa memasukkan bid.", "Akses Ditolak",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                int idPembeli = UserContext.CurrentUser!.IdUser;
                return BidContext.EksekusiBid(idLelang, idPembeli, nominalTawaran);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Controller", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
