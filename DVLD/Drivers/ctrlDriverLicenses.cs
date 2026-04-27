using System;
using System.Data;
using DVLD_Business;
using System.Drawing;
using DVLD.DriverLicense;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlDriverLicenses : UserControl
    {
        private int _DriverID;
        private clsDriver _Driver;
        private DataTable _dtDriverLocalLicensesHistory;
        private DataTable _dtDriverInternationalLicensesHistory;

        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        private void _LoadLocalLicenseInfo()
        {
            _dtDriverLocalLicensesHistory = clsDriver.GetLicenses(_DriverID);

            dgvLocalLicensesHistory.DataSource = _dtDriverLocalLicensesHistory;
            lblLocalLicensesRecords.Text = dgvLocalLicensesHistory.Rows.Count.ToString();

            // Header
            dgvLocalLicensesHistory.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);
            dgvLocalLicensesHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            // Cells
            dgvLocalLicensesHistory.DefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Regular);

            if (dgvLocalLicensesHistory.Rows.Count > 0)
            {
                dgvLocalLicensesHistory.Columns[0].HeaderText = "License ID";
                dgvLocalLicensesHistory.Columns[0].Width = 110;

                dgvLocalLicensesHistory.Columns[1].HeaderText = "Application ID";
                dgvLocalLicensesHistory.Columns[1].Width = 110;

                dgvLocalLicensesHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalLicensesHistory.Columns[2].Width = 200;

                dgvLocalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicensesHistory.Columns[3].Width = 150;

                dgvLocalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicensesHistory.Columns[4].Width = 150;

                dgvLocalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvLocalLicensesHistory.Columns[5].Width = 120;
            }
        }

        private void _LoadInternationalLicenseInfo()
        {
            _dtDriverInternationalLicensesHistory = clsDriver.GetInternationalLicenses(_DriverID);

            dgvInternationalLicensesHistory.DataSource = _dtDriverInternationalLicensesHistory;
            lblInternationalLicensesRecords.Text = dgvInternationalLicensesHistory.Rows.Count.ToString();

            // Header
            dgvInternationalLicensesHistory.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);
            dgvInternationalLicensesHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            // Cells
            dgvInternationalLicensesHistory.DefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Regular);

            if (dgvInternationalLicensesHistory.Rows.Count > 0)
            {
                dgvInternationalLicensesHistory.Columns[0].HeaderText = "International License ID";
                dgvInternationalLicensesHistory.Columns[0].Width = 170;

                dgvInternationalLicensesHistory.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicensesHistory.Columns[1].Width = 120;

                dgvInternationalLicensesHistory.Columns[2].HeaderText = "Local License ID";
                dgvInternationalLicensesHistory.Columns[2].Width = 150;

                dgvInternationalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicensesHistory.Columns[3].Width = 150;

                dgvInternationalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicensesHistory.Columns[4].Width = 150;

                dgvInternationalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvInternationalLicensesHistory.Columns[5].Width = 120;
            }
        }

        public void LoadInfo(int driverID)
        {
            _DriverID = driverID;
            _Driver = clsDriver.FindByDriverID(_DriverID);

            if(_Driver == null)
            {
                MessageBox.Show(
                    $"No driver found with ID: {_DriverID}. Please check the ID and try again.",
                    "Driver Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();
        }

        public void LoadInfoByPersonID(int PersonID)
        {
            _Driver = clsDriver.FindByPersonID(PersonID);

            if (_Driver == null)
            {
                MessageBox.Show(
                    $"No driver record was found for Person ID: {PersonID}.\nPlease verify the person data and try again.",
                    "Driver Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            _DriverID = _Driver.DriverID;

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();
        }

        public void Clear()
        {
            _dtDriverLocalLicensesHistory?.Clear();
            _dtDriverInternationalLicensesHistory?.Clear();
        }

        private void mishowLicenseInfo_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value;

            DriverLicense.frmShowLicenseInfo frm =
                new DriverLicense.frmShowLicenseInfo(LicenseID);

            frm.ShowDialog();
        }

        private void miShowInternationalLicense_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "This Feature Is Not Implemented Yet!",
                "Not Ready!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);

            //int InternationalLicenseID =
            //    (int)dgvInternationalLicensesHistory.CurrentRow.Cells[0].Value;

            //frmShowInternationalLicenseInfo frm =
            //    new frmShowInternationalLicenseInfo(InternationalLicenseID);

            //frm.ShowDialog();
        }

        private void dgvLocalLicensesHistory_DoubleClick(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value;

            DriverLicense.frmShowLicenseInfo frm =
                new DriverLicense.frmShowLicenseInfo(LicenseID);

            frm.ShowDialog();
        }

        private void dgvInternationalLicensesHistory_DoubleClick(object sender, EventArgs e)
        {
            //int InternationalLicenseID =
            //    (int)dgvInternationalLicensesHistory.CurrentRow.Cells[0].Value;

            //frmShowInternationalLicenseInfo frm =
            //    new frmShowInternationalLicenseInfo(InternationalLicenseID);

            //frm.ShowDialog();
        }
    }
}