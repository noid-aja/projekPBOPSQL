using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Models;

namespace WinFormsApp1.Models.Roles
{
    public class InspektorRole : RoleUser
    {
        public InspektorRole(User user) : base(user) { }

        public override string NamaRole => "inspektor";

        public override string JudulDashboard => "Dashboard Inspektor";

        public override string GetDeskripsiRole() =>
            "Inspektor bertugas menilai kualitas produk kopi, memberi grade, dan menentukan status lolos/tidak QC.";

        public override List<string> GetMenuAkses()
        {
            return new List<string>
            {
                "Lihat Produk Pending",
                "Input Hasil Inspeksi",
                "Beri Grade Kopi",
                "Set Status QC",
                "Riwayat Inspeksi"
            };
        }
    }
}