using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsApp1.Models;

namespace WinFormsApp1.Forms
{
    public partial class FormPilihRole : Form
    {
        public string SelectedRole { get; private set; } = string.Empty;

        public FormPilihRole(List<Userrole> roles)
        {
            InitializeComponent();
            foreach (var role in roles)
            {
                cmbRoles.Items.Add(role.NamaRole);
            }
            if (cmbRoles.Items.Count > 0)
            {
                cmbRoles.SelectedIndex = 0;
            }
        }

        private void btnPilih_Click(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedItem == null)
            {
                MessageBox.Show("Pilih salah satu role", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SelectedRole = cmbRoles.SelectedItem.ToString()!;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
