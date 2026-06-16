using System;
using System.Globalization;
using System.Windows.Forms;
using WinFormsApp1.Controllers;

namespace WinFormsApp1.Views.AdminView
{
    public partial class FormBeriGradeDialog : Form
    {
        private readonly int _idProduk;
        private readonly InspeksiController _inspeksiController = new InspeksiController();

        public FormBeriGradeDialog(int idProduk, string namaProduk)
        {
            InitializeComponent();
            _idProduk = idProduk;
            lblNamaProduk.Text = namaProduk;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            int nilai = (int)nudNilai.Value;
            decimal hargaRekomendasi = 0m;

            if (string.IsNullOrWhiteSpace(tbHargaRekomendasi.Text))
            {
                MessageBox.Show("Harga rekomendasi harus diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbHargaRekomendasi.Focus();
                return;
            }

            if (!decimal.TryParse(tbHargaRekomendasi.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out hargaRekomendasi) || hargaRekomendasi <= 0)
            {

                if (!decimal.TryParse(tbHargaRekomendasi.Text, out hargaRekomendasi) || hargaRekomendasi <= 0)
                {
                    MessageBox.Show("Harga rekomendasi tidak valid!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbHargaRekomendasi.Focus();
                    return;
                }
            }

            string catatan = tbCatatan.Text.Trim();

            bool sukses = _inspeksiController.KirimHasilQc(_idProduk, nilai, hargaRekomendasi, catatan);
            if (sukses)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
