using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class Enum
    {
        public enum StatusProduk
        {
            PendingInspeksi, 
            LolosQc,
            DitolakQc,
            DijadwalkanLelang,
            Berlangsung,
            Terjual,
            Dibatalkan
        }

        public static StatusProduk ParseStatusProduk(string statusStr)
        {
            if (string.IsNullOrEmpty(statusStr)) return StatusProduk.PendingInspeksi;
            switch (statusStr.Replace("_", "").ToLower())
            {
                case "pendinginspeksi": return StatusProduk.PendingInspeksi;
                case "lolosqc": return StatusProduk.LolosQc;
                case "ditolakqc": return StatusProduk.DitolakQc;
                case "dijadwalkanlelang": return StatusProduk.DijadwalkanLelang;
                case "berlangsung": return StatusProduk.Berlangsung;
                case "terjual": return StatusProduk.Terjual;
                case "dibatalkan": return StatusProduk.Dibatalkan;
                default: return StatusProduk.PendingInspeksi;
            }
        }

        public static string ToDbString(StatusProduk status)
        {
            switch (status)
            {
                case StatusProduk.PendingInspeksi: return "pending_inspeksi";
                case StatusProduk.LolosQc: return "lolos_qc";
                case StatusProduk.DitolakQc: return "ditolak_qc";
                case StatusProduk.DijadwalkanLelang: return "dijadwalkan_lelang";
                case StatusProduk.Berlangsung: return "berlangsung";
                case StatusProduk.Terjual: return "terjual";
                case StatusProduk.Dibatalkan: return "dibatalkan";
                default: return "pending_inspeksi";
            }
        }

        public enum StatusLelang
        {
            Dijadwalkan,    
            Berlangsung,
            Selesai,
            Dibatalkan
        }

        public static StatusLelang ParseStatusLelang(string statusStr)
        {
            if (string.IsNullOrEmpty(statusStr)) return StatusLelang.Dijadwalkan;
            switch (statusStr.Replace("_", "").ToLower())
            {
                case "dijadwalkan": return StatusLelang.Dijadwalkan;
                case "berlangsung": return StatusLelang.Berlangsung;
                case "selesai": return StatusLelang.Selesai;
                case "dibatalkan": return StatusLelang.Dibatalkan;
                default: return StatusLelang.Dijadwalkan;
            }
        }

        public static string ToDbString(StatusLelang status)
        {
            switch (status)
            {
                case StatusLelang.Dijadwalkan: return "dijadwalkan";
                case StatusLelang.Berlangsung: return "berlangsung";
                case StatusLelang.Selesai: return "selesai";
                case StatusLelang.Dibatalkan: return "dibatalkan";
                default: return "dijadwalkan";
            }
        }

        public enum StatusBayar
        {
            BelumBayar,      
            Lunas,
            Dibatalkan
        }

        public static StatusBayar ParseStatusBayar(string statusStr)
        {
            if (string.IsNullOrEmpty(statusStr)) return StatusBayar.BelumBayar;
            switch (statusStr.Replace("_", "").ToLower())
            {
                case "belumbayar": return StatusBayar.BelumBayar;
                case "lunas": return StatusBayar.Lunas;
                case "dibatalkan": return StatusBayar.Dibatalkan;
                default: return StatusBayar.BelumBayar;
            }
        }

        public static string ToDbString(StatusBayar status)
        {
            switch (status)
            {
                case StatusBayar.BelumBayar: return "belum_bayar";
                case StatusBayar.Lunas: return "lunas";
                case StatusBayar.Dibatalkan: return "dibatalkan";
                default: return "belum_bayar";
            }
        }
    }
}
