using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp1.Controllers;

namespace WinFormsApp1.Views.PembeliView
{
    public partial class FormInputBidDialog : Form
    {
        private readonly int _idLelang;
        private readonly decimal _hargaSaatIni;
        private readonly BidController _bidController = new BidController();

        public bool BidSuccess { get; private set; } = false;

        public FormInputBidDialog(int idLelang, string namaProduk, decimal hargaSaatIni)
        {
            InitializeComponent();
            _idLelang = idLelang;
            _hargaSaatIni = hargaSaatIni;

            lblProduk.Text = namaProduk;
            lblHargaSaatIni.Text = $"Harga Saat Ini: Rp {hargaSaatIni:N0}";

            tbNominal.Text = (hargaSaatIni + 10000).ToString("F0");
        }

        private void btnPasang_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(tbNominal.Text, out decimal nominal) || nominal <= 0)
            {
                MessageBox.Show("Nominal bid tidak valid!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNominal.Focus();
                return;
            }

            if (nominal <= _hargaSaatIni)
            {
                MessageBox.Show($"Nominal bid harus lebih tinggi dari Rp {_hargaSaatIni:N0}!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNominal.Focus();
                return;
            }

            bool ok = _bidController.KirimBid(_idLelang, nominal);
            if (ok)
            {
                BidSuccess = true;
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
