using DVLD.DriverLicense;
using DVLD.Licenses.Detain_License;
using DVLD.Licenses.Release_License;
using DVLD.People;
using DVLD_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Licenses.List_Detain_Licenses
{
    public partial class frmListDetainedLicenses : Form
    {
        private DataTable _dtDetainedLicenses;

        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        private void _RefreshDetainedLicensesList()
        {
            _dtDetainedLicenses =
                clsDetainedLicense.GetAllDetainedLicenses();

            dgvDetainedLicenses.DataSource = _dtDetainedLicenses;
            lblRecordsCount.Text = dgvDetainedLicenses.Rows.Count.ToString();
        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            _RefreshDetainedLicensesList();
            cbFilterBy.SelectedIndex = 0;

            // Header
            dgvDetainedLicenses.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);
            dgvDetainedLicenses.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            // Cells
            dgvDetainedLicenses.DefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Regular);

            if (dgvDetainedLicenses.Rows.Count > 0)
            {
                dgvDetainedLicenses.Columns[0].HeaderText = "Detain.ID";
                dgvDetainedLicenses.Columns[0].Width = 90;

                dgvDetainedLicenses.Columns[1].HeaderText = "License.ID";
                dgvDetainedLicenses.Columns[1].Width = 90;

                dgvDetainedLicenses.Columns[2].HeaderText = "Detain.Date";
                dgvDetainedLicenses.Columns[2].Width = 160;

                dgvDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[3].Width = 110;

                dgvDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[4].Width = 110;

                dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[5].Width = 160;

                dgvDetainedLicenses.Columns[6].HeaderText = "National.No.";
                dgvDetainedLicenses.Columns[6].Width = 90;

                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].Width = 330;

                dgvDetainedLicenses.Columns[8].HeaderText = "Rlease App.ID";
                dgvDetainedLicenses.Columns[8].Width = 150;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset any existing filter
            if (_dtDetainedLicenses != null)
                _dtDetainedLicenses.DefaultView.RowFilter = "";

            if (cbFilterBy.Text == "Is Released")
            {
                cbIsReleased.Visible = true;
                txtFilterValue.Visible = false;
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;
            }
            else
            {
                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsReleased.Visible = false;
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
            lblRecordsCount.Text = dgvDetainedLicenses.Rows.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Detain ID": FilterColumn = "DetainID"; break;
                case "National No": FilterColumn = "NationalNo"; break;
                case "Full Name": FilterColumn = "FullName"; break;
                case "Release Application ID": FilterColumn = "ReleaseApplicationID"; break;
                default: FilterColumn = "None"; break;
            }

            if (string.IsNullOrWhiteSpace(txtFilterValue.Text) || FilterColumn == "None")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvDetainedLicenses.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
            {
                _dtDetainedLicenses.DefaultView.RowFilter =
                    string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text);
            }
            else
            {
                _dtDetainedLicenses.DefaultView.RowFilter =
                    string.Format("[{0}] like '{1}%'", FilterColumn, txtFilterValue.Text);
            }

            lblRecordsCount.Text = dgvDetainedLicenses.Rows.Count.ToString();
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsReleased.SelectedItem == null)
            {
                _dtDetainedLicenses.DefaultView.RowFilter = "";
                return;
            }

            switch (cbIsReleased.SelectedItem.ToString())
            {
                case "All":
                    _dtDetainedLicenses.DefaultView.RowFilter = "";
                    break;

                case "Yes":
                    _dtDetainedLicenses.DefaultView.RowFilter = "IsReleased = true";
                    break;

                case "No":
                    _dtDetainedLicenses.DefaultView.RowFilter = "IsReleased = false";
                    break;

                default: break;
            }
            lblRecordsCount.Text = dgvDetainedLicenses.Rows.Count.ToString();
        }

        private void cmsDetainedLicenses_Opening(object sender, CancelEventArgs e)
        {
            if (dgvDetainedLicenses.CurrentRow == null)
                return;

            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            mireleaseDetainedLicense.Enabled = clsDetainedLicense.IsLicenseDetained(LicenseID);
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm =
                new frmReleaseDetainedLicenseApplication();

            frm.ShowDialog();
            _RefreshDetainedLicensesList();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm =
                new frmDetainLicenseApplication();

            frm.ShowDialog();
            _RefreshDetainedLicensesList();
        }

        private void mireleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;

            if (!clsDetainedLicense.IsLicenseDetained(LicenseID))
                return;

            frmReleaseDetainedLicenseApplication frm =
                new frmReleaseDetainedLicenseApplication(LicenseID);

            frm.ShowDialog();
            _RefreshDetainedLicensesList();
        }

        private void miShowPersonDetails_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            int PersonID = clsLicense.FindByLicenseID(LicenseID).DriverInfo.PersonID;

            frmShowPersonInfo frm =
                new frmShowPersonInfo(PersonID);

            frm.ShowDialog();
            _RefreshDetainedLicensesList();
        }

        private void miShowLicenseDetails_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo frm =
            new frmShowLicenseInfo(
                (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);

            frm.ShowDialog();
        }

        private void mishowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            int PersonID = clsLicense.FindByLicenseID(LicenseID).DriverInfo.PersonID;

            frmShowPersonLicenseHistory frm =
                new frmShowPersonLicenseHistory(PersonID);

            frm.ShowDialog();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Detain ID" || cbFilterBy.Text == "Release Application ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}