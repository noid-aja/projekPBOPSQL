public bool KirimHasilQc(
    int idProduk,
    int nilai,
    decimal hargaRekomendasi,
    string? catatan)
{
    if (!UserContext.IsLoggedIn())
    {
        MessageBox.Show(
            "Sesi login habis. Silakan login kembali.",
            "Akses Ditolak",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);

        return false;
    }

    if (!UserContext.IsInspektor())
    {
        MessageBox.Show(
            "Akses ditolak. Hanya Inspektor yang bisa mengisi hasil QC.",
            "Bukan Inspektor",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);

        return false;
    }

    if (nilai < 0 || nilai > 100)
    {
        MessageBox.Show(
            "Nilai QC harus antara 0 sampai 100.",
            "Validasi Gagal",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);

        return false;
    }

    if (hargaRekomendasi <= 0)
    {
        MessageBox.Show(
            "Harga rekomendasi harus lebih dari Rp0.",
            "Validasi Gagal",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);

        return false;
    }

    try
    {
        int idInspektor =
            UserContext.CurrentUser!.IdUser;

            string gradeOtomatis = nilai >= 95 ? "A+"
                                 : nilai >= 85 ? "A"
                                 : nilai >= 80 ? "B"
                                 : nilai >= 60 ? "C"
                                 : "D";

        return false;
    }
}