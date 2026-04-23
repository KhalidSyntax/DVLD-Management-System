using System;
using DVLD_Business;
using DVLD.DriverLicense;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _LicenseID = -1;

        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }

        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void ResetLocalDrivingLicenseApplicationInfo()
        {
            ctrlApplicationBasicInfo1.ResetApplicationInfo();
            _LocalDrivingLicenseApplicationID = -1;
            _LicenseID = -1;

            lblLocalDrivingLicenseApplicationID.Text = "[???]";
            lblAppliedFor.Text = "[???]";
            lblPassedTests.Text = "0";
            llShowLicenseInfo.Enabled = false;
        }

        private void _FillLocalDrivingLicenseApplicationInfo()
        {
            _LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();
            llShowLicenseInfo.Enabled = (_LicenseID != -1);

            lblLocalDrivingLicenseApplicationID.Text =
                _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();

            lblAppliedFor.Text =
                _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;

            lblPassedTests.Text =
                _LocalDrivingLicenseApplication.GetPassedTestCount().ToString() + "/3";

            ctrlApplicationBasicInfo1.LoadByApplicationID(
                _LocalDrivingLicenseApplication.ApplicationID);
        }

        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                ResetLocalDrivingLicenseApplicationInfo();
                MessageBox.Show(
                    $"No Local Driving License Application was found with ID = {LocalDrivingLicenseApplicationID}.",
                    "Application Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            _FillLocalDrivingLicenseApplicationInfo();
        }

        public void LoadApplicationInfo(int ApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByApplicationID(ApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                ResetLocalDrivingLicenseApplicationInfo();
                MessageBox.Show(
                    $"No local driving license application found with ID = {LocalDrivingLicenseApplicationID}.",
                    "Application Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            _FillLocalDrivingLicenseApplicationInfo();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(
                _LocalDrivingLicenseApplication.GetActiveLicenseID());

            frm.ShowDialog();
        }
    }
}