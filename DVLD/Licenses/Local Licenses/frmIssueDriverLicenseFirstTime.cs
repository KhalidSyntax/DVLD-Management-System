using System;
using DVLD.Classes;
using DVLD_Business;
using System.Windows.Forms;

namespace DVLD.DriverLicense
{
    public partial class frmIssueDriverLicenseFirstTime : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public frmIssueDriverLicenseFirstTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void frmIssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {
            txtNotes.Focus();

            _LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.
                FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if(_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show(
                    $"No Local Driving License Application was found with ID = {_LocalDrivingLicenseApplication}.",
                    "Application Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
                return;
            }

            if (!_LocalDrivingLicenseApplication.PassedAllTests())
            {
                MessageBox.Show(
                    "This application cannot issue a license because the applicant did not pass all required tests.",
                    "Tests Not Completed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                this.Close();
                return;
            }

            int LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();

            if (LicenseID != -1)
            {
                MessageBox.Show(
                    $"A license already exists for this application. License ID = {LicenseID}.",
                    "License Already Issued",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
                return;
            }

            ctrlDrivingLicenseApplicationInfo1.
                LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int LicenseID =
                _LocalDrivingLicenseApplication.IssueLicenseForTheFirstTime(
                    txtNotes.Text.Trim(),
                    clsGlobal.currentUser.UserID);

            if(LicenseID != -1)
            {
                MessageBox.Show(
                $"Driving License Issued Successfully. License ID = {LicenseID}.",
                "License Issued",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show(
                "Driving License was not issued.",
                "Operation Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
