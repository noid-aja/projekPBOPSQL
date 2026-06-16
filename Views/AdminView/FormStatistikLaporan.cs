using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp1.Models;

namespace WinFormsApp1.Views.AdminView
{
    public partial class FormStatistikLaporan : Form
    {
        public FormStatistikLaporan()
        {
            InitializeComponent();
        }

        private void FormStatistikLaporan_Load(object sender, EventArgs e)
        {
            LoadTab1();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0: LoadTab1(); break;
                case 1: LoadTab2(); break;
                case 2: LoadTab3(); break;
                case 3: LoadTab4(); break;
                case 4: LoadTab5(); break;
                case 5: LoadTab6(); break;
                case 6: LoadTab7(); break;
                case 7: LoadTab8(); break;
                case 8: LoadTab9(); break;
                case 9: LoadTab10(); break;
                case 10: LoadTab11(); break;
                case 11: LoadTab12(); break;
            }
        }

        private void BindGrid(DataGridView dgv, DataTable dt)
        {
            dgv.DataSource = dt;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadTab1()
        {
            try
            {
                BindGrid(dgvProdukDetail, DashboardContext.AmbilProdukAdminView());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat produk detail: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTab2()
        {
            try
            {
                BindGrid(dgvKopiPopuler, DashboardContext.AmbilLaporanGroupBy());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat statistik kopi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTab3()
        {
            try
            {
                BindGrid(dgvPerformaPetani, DashboardContext.AmbilLaporanPerformaPetani());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat performa petani: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTab4()
        {
            try
            {
                BindGrid(dgvRollup, DashboardContext.AmbilLaporanRollup());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat rollup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTab5()
        {
            try
            {
                BindGrid(dgvCube, DashboardContext.AmbilLaporanCube());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat cube: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTab6()
        {
            try
            {
                BindGrid(dgvKeuangan, DashboardContext.AmbilLaporanGroupingSets());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat grouping sets keuangan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTab7()
        {
            try
            {
                BindGrid(dgvSubqueryHarga, DashboardContext.AmbilSubqueryProdukDiAtasRata());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat subquery: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTab8()
        {
            try
            {
                BindGrid(dgvBidTertinggi, DashboardContext.AmbilBidTertinggi());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat bid tertinggi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTab9()
        {
            try
            {
                BindGrid(dgvUnionLinimasa, DashboardContext.AmbilUnionAktivitasUser());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat linimasa union: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTab10()
        {
            try
            {
                BindGrid(dgvIntersectMultiRole, DashboardContext.AmbilIntersectPetaniPembeli());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat intersect: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTab11()
        {
            try
            {
                BindGrid(dgvExceptPembeliBelumBid, DashboardContext.AmbilExceptPembeliBelumBid());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat except: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTab12()
        {
            try
            {
                BindGrid(dgvSubqueryBid, DashboardContext.AmbilSubqueryBidDiAtasRata());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat bid di atas rata-rata: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
