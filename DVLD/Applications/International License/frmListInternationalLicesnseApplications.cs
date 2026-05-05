using DVLD.Applications;
using DVLD.DriverLicense;
using DVLD.Licenses;
using DVLD.People;
using DVLD_Business;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmListInternationalLicesnseApplications : Form
    {
        private DataTable _dtInternationalLicenseApplications;

        public frmListInternationalLicesnseApplications()
        {
            InitializeComponent();
        }

        private void _RefreshInternationalLicensesList()
        {
            _dtInternationalLicenseApplications =
                clsInternationalLicense.GetAllInternationalLicenses();

            dgvInternationalLicenses.DataSource = _dtInternationalLicenseApplications;
            lblRecordsCount.Text = dgvInternationalLicenses.Rows.Count.ToString();
        }

        private void frmListInternationalLicesnseApplications_Load(object sender, EventArgs e)
        {
            _RefreshInternationalLicensesList();
            cbFilterBy.SelectedIndex = 0;

            // Header
            dgvInternationalLicenses.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);
            dgvInternationalLicenses.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            // Cells
            dgvInternationalLicenses.DefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Regular);

            if (dgvInternationalLicenses.Rows.Count > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "International License ID";
                dgvInternationalLicenses.Columns[0].Width = 170;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 120;

                dgvInternationalLicenses.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenses.Columns[2].Width = 120;

                dgvInternationalLicenses.Columns[3].HeaderText = "Local License ID";
                dgvInternationalLicenses.Columns[3].Width = 150;

                dgvInternationalLicenses.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[4].Width = 150;

                dgvInternationalLicenses.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[5].Width = 150;

                dgvInternationalLicenses.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[6].Width = 100;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "International License ID": FilterColumn = "InternationalLicenseID"; break;
                case "Application ID": FilterColumn = "ApplicationID"; break;
                case "Driver ID": FilterColumn = "DriverID"; break;
                case "Local License ID": FilterColumn = "IssuedUsingLocalLicenseID"; break;
                default: FilterColumn = "None"; break;
            }

            if (string.IsNullOrWhiteSpace(txtFilterValue.Text) || FilterColumn == "None")
            {
                _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtInternationalLicenseApplications.DefaultView.Count.ToString();
                return; 
            }

            if (int.TryParse(txtFilterValue.Text.Trim(), out int value))
            {
                _dtInternationalLicenseApplications.DefaultView.RowFilter =
                    string.Format("[{0}] = {1}", FilterColumn, value);
            }
            else
            {
                _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
            }

            lblRecordsCount.Text = _dtInternationalLicenseApplications.DefaultView.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsActive.SelectedItem == null)
            {
                _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
                return;
            }

            switch (cbIsActive.SelectedItem.ToString())
            {
                case "All":
                    _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
                    break;

                case "Yes":
                    _dtInternationalLicenseApplications.DefaultView.RowFilter = "IsActive = true";
                    break;

                case "No":
                    _dtInternationalLicenseApplications.DefaultView.RowFilter = "IsActive = false";
                    break;

                default: break;
            }
            lblRecordsCount.Text = _dtInternationalLicenseApplications.DefaultView.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset any existing filter
            if (_dtInternationalLicenseApplications != null)
                _dtInternationalLicenseApplications.DefaultView.RowFilter = "";

            if (cbFilterBy.Text == "Is Active")
            {
                cbIsActive.Visible = true;
                txtFilterValue.Visible = false;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }
            else
            {
                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsActive.Visible = false;
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
            lblRecordsCount.Text = _dtInternationalLicenseApplications.DefaultView.Count.ToString();
        }

        private void btnAddLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm =
                new frmNewInternationalLicenseApplication();

            frm.ShowDialog();
            _RefreshInternationalLicensesList();

        }

        private void miShowPersonDetails_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalLicenses.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;

            frmShowPersonInfo frm =
                new frmShowPersonInfo(PersonID);

            frm.ShowDialog();
            _RefreshInternationalLicensesList();
        }

        private void miShowLicenseDetails_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo frm =
                new frmShowInternationalLicenseInfo(
                    (int)dgvInternationalLicenses.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
        }

        private void mishowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalLicenses.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindByDriverID(DriverID).PersonID;

            frmShowPersonLicenseHistory frm =
                new frmShowPersonLicenseHistory(PersonID);

            frm.ShowDialog();
        }

        private void dgvInternationalLicenses_DoubleClick(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo frm =
                new frmShowInternationalLicenseInfo(
                    (int)dgvInternationalLicenses.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}