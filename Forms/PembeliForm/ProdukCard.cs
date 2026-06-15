using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1.Forms.PembeliForm
{
    public partial class ProdukCard : UserControl
    {
        private decimal _hargaAwal;
        private decimal _bidTertinggi;
        private decimal _beratKg;

        public event EventHandler? CardClick;

        public ProdukCard()
        {
            InitializeComponent();
            
            this.Click += (s, e) => OnCardClicked(e);
            BindClickEvents(this);
        }

        private void BindClickEvents(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.Click += (s, e) => OnCardClicked(e);
                if (ctrl.HasChildren)
                {
                    BindClickEvents(ctrl);
                }
            }
        }

        protected virtual void OnCardClicked(EventArgs e)
        {
            CardClick?.Invoke(this, e);
        }

        [Browsable(true)]
        [Category("Lelang Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int IdLelang { get; set; }

        [Browsable(true)]
        [Category("Lelang Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image ProductImage
        {
            get => picProduct.Image;
            set => picProduct.Image = value;
        }

        [Browsable(true)]
        [Category("Lelang Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NamaProduk
        {
            get => lblNama.Text;
            set => lblNama.Text = value;
        }

        [Browsable(true)]
        [Category("Lelang Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Petani
        {
            get => lblPetani.Text;
            set => lblPetani.Text = $"Petani: {value}";
        }

        [Browsable(true)]
        [Category("Lelang Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string JenisKopi
        {
            get => lblJenis.Text;
            set => lblJenis.Text = $"Jenis: {value}";
        }

        [Browsable(true)]
        [Category("Lelang Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Grade
        {
            get => lblGrade.Text;
            set => lblGrade.Text = $"Grade: {value}";
        }

        [Browsable(true)]
        [Category("Lelang Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal HargaAwal
        {
            get => _hargaAwal;
            set
            {
                _hargaAwal = value;
                UpdateHargaDisplay();
            }
        }

        [Browsable(true)]
        [Category("Lelang Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal BidTertinggi
        {
            get => _bidTertinggi;
            set
            {
                _bidTertinggi = value;
                UpdateHargaDisplay();
            }
        }

        [Browsable(true)]
        [Category("Lelang Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal HargaSaatIni => _bidTertinggi > 0 ? _bidTertinggi : _hargaAwal;

        private void UpdateHargaDisplay()
        {
            lblHarga.Text = $"Harga: Rp {HargaSaatIni:N0}";
        }

        [Browsable(true)]
        [Category("Lelang Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal BeratKg
        {
            get => _beratKg;
            set
            {
                _beratKg = value;
                lblBerat.Text = $"Berat: {value:N0} Kg";
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime TglAkhir { get; set; }

        public void UpdateCountdown()
        {
            TimeSpan sisa = TglAkhir - DateTime.Now;
            if (sisa.TotalSeconds <= 0)
            {
                lblCountdown.Text = "⏱ Sisa: HABIS";
                lblCountdown.ForeColor = Color.Red;
            }
            else
            {
                lblCountdown.Text = $"⏱ Sisa: {(int)sisa.TotalMinutes:D2}:{sisa.Seconds:D2}";
                lblCountdown.ForeColor = Color.DarkRed;
            }
        }
    }
}
