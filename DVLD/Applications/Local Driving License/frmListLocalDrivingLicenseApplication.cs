using DVLD_Business;
using DVLD.Classes;
using System;
using System.Data;
using System.Drawing;
using System.Security.Policy;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.Applications
{
    public partial class frmListLocalDrivingLicenseApplications : Form
    {
        private DataTable _dtAllLocalDrivingLicenseApplications;

        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void _RefreshApplicationsList()
        {
            _dtAllLocalDrivingLicenseApplications =
                clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();

            dgvLocalDrivingLicenseApplications.DataSource =
                _dtAllLocalDrivingLicenseApplications;

            lblRecordsCount.Text =
                dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
        }

        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _RefreshApplicationsList();
            cbFilterBy.SelectedIndex = 0;

            // Header
            dgvLocalDrivingLicenseApplications.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);
            dgvLocalDrivingLicenseApplications.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            // Cells
            dgvLocalDrivingLicenseApplications.DefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Regular);

            if (dgvLocalDrivingLicenseApplications.Rows.Count > 0)
            {
                dgvLocalDrivingLicenseApplications.Columns[0].HeaderText = "Local Driving License Application ID";
                dgvLocalDrivingLicenseApplications.Columns[0].Width = 320;

                dgvLocalDrivingLicenseApplications.Columns[1].HeaderText = "Driving Class";
                dgvLocalDrivingLicenseApplications.Columns[1].Width = 250;

                dgvLocalDrivingLicenseApplications.Columns[2].HeaderText = "National No";
                dgvLocalDrivingLicenseApplications.Columns[2].Width = 140;

                dgvLocalDrivingLicenseApplications.Columns[3].HeaderText = "Full Name";
                dgvLocalDrivingLicenseApplications.Columns[3].Width = 280;

                dgvLocalDrivingLicenseApplications.Columns[4].DefaultCellStyle.Format = "d";
                dgvLocalDrivingLicenseApplications.Columns[4].HeaderText = "Application Date";
                dgvLocalDrivingLicenseApplications.Columns[4].Width = 180;

                dgvLocalDrivingLicenseApplications.Columns[5].HeaderText = "Passed Tests";
                dgvLocalDrivingLicenseApplications.Columns[5].Width = 90;

                dgvLocalDrivingLicenseApplications.Columns[6].HeaderText = "Status";
                dgvLocalDrivingLicenseApplications.Columns[6].Width = 100;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllLocalDrivingLicenseApplications.Rows.Count <= 0)
                return;

            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Local Driving License Application ID": FilterColumn = "LocalDrivingLicenseApplicationID"; break;
                case "National No": FilterColumn = "NationalNo"; break;
                case "Full Name": FilterColumn = "FullName"; break;
                case "Status": FilterColumn = "Status"; break;
                default: FilterColumn = "None"; break;
            }

            if (string.IsNullOrWhiteSpace(txtFilterValue.Text) || FilterColumn == "None")
            {
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "LocalDrivingLicenseApplicationID")
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter =
                    string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text);
            else
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter =
                    string.Format("[{0}] like '{1}%'", FilterColumn, txtFilterValue.Text);

            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

            _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
        }

        private void miShowApplicationDetails_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo frm =
                new frmLocalDrivingLicenseApplicationInfo(
                    (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
            _RefreshApplicationsList();
        }

        private void btnAddLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm =
                new frmAddUpdateLocalDrivingLicenseApplication();

            frm.ShowDialog();
            _RefreshApplicationsList();
        }

        private void miEditApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm =
                new frmAddUpdateLocalDrivingLicenseApplication(
                    (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
            _RefreshApplicationsList();
        }

        private void miDeleteApplication_Click(object sender, EventArgs e)
        {
            int localDrivingLicenseApplicationID =
                (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(
                    localDrivingLicenseApplicationID);

            if (localDrivingLicenseApplication == null)
            {
                MessageBox.Show(
                    "Application not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (MessageBox.Show(
                    "Are you sure you want to delete this application?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (localDrivingLicenseApplication.Delete())
            {
                MessageBox.Show(
                    "Application deleted successfully.",
                    "Deleted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                _RefreshApplicationsList();
            }
            else
            {
                MessageBox.Show(
                    $"Application was not deleted because it has linked data [{localDrivingLicenseApplicationID}].",
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void miCancelApplication_Click(object sender, EventArgs e)
        {
            int localDrivingLicenseApplicationID =
                (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(
                    localDrivingLicenseApplicationID);

            if (localDrivingLicenseApplication == null)
            {
                MessageBox.Show(
                    "Application not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (MessageBox.Show(
                    $"Are you sure you want to cancel application [{localDrivingLicenseApplicationID}]?",
                    "Confirm Cancel",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) != DialogResult.OK)
                return;

            if (localDrivingLicenseApplication.Cancel())
            {
                MessageBox.Show(
                    "Application cancelled successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                _RefreshApplicationsList();
            }
            else
            {
                MessageBox.Show(
                    "Application could not be cancelled because it has linked records.",
                    "Cancel Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // Later 

        private void miScheduleTests_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "This Feature Is Not Implemented Yet!",
            "Not Ready!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation);
        }

        private void miIssueDrivingLicenseFirstTime_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "This Feature Is Not Implemented Yet!",
            "Not Ready!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation);
        }

        private void miShowLicense_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "This Feature Is Not Implemented Yet!",
            "Not Ready!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation);
        }

        private void mishowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "This Feature Is Not Implemented Yet!",
            "Not Ready!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation);
        }

        private void mischeduleVisionTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "This Feature Is Not Implemented Yet!",
            "Not Ready!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation);
        }

        private void mischeduleWrittenTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "This Feature Is Not Implemented Yet!",
            "Not Ready!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation);
        }

        private void mischeduleStreetTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "This Feature Is Not Implemented Yet!",
            "Not Ready!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation);
        }

        private void dgvLocalDrivingLicenseApplications_DoubleClick(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo frm =
                new frmLocalDrivingLicenseApplicationInfo(
                    (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
            _RefreshApplicationsList();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Local Driving License Application ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}