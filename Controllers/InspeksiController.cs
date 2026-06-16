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

        return InspeksiContext.SimpanHasilInspeksi(
            idProduk,
            idInspektor,
            nilai,
            hargaRekomendasi,
            catatan);
    }
    catch (PostgresException ex)
    {
        MessageBox.Show(
            ex.MessageText,
            "Database Menolak Data",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);

        return false;
    }
    catch (Exception ex)
    {
        MessageBox.Show(
            "Gagal menyimpan hasil QC: " + ex.Message,
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);

        return false;
    }
}