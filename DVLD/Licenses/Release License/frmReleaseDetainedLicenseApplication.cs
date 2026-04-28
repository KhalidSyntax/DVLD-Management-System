using DVLD.Classes;
using DVLD.DriverLicense;
using DVLD_Business;
using System;
using System.ComponentModel;
using System.Security.Policy;
using System.Windows.Forms;
using static DVLD_Business.clsApplication;

namespace DVLD.Licenses.Release_License
{
    public partial class frmReleaseDetainedLicenseApplication : Form
    {
        private int _SelectedLicenseID = -1;
        public frmReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
        }

        public frmReleaseDetainedLicenseApplication(int LicenseID)
        {
            InitializeComponent();
            _SelectedLicenseID = LicenseID;

            ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(_SelectedLicenseID);
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
        }

        private void _LoadReleaseLicenseInfo()
        {
            lblDetainID.Text =
                ctrlDriverLicenseInfoWithFilter1.
                SelectedLicenseInfo.
                DetainedInfo.
                DetainID.ToString();

            lblDetainDate.Text = clsFormat.DateToShort(
                ctrlDriverLicenseInfoWithFilter1.
                SelectedLicenseInfo.
                DetainedInfo.
                DetainDate);

            float appFees =
                clsApplicationType.Find(
                    (int)clsApplication.
                    enApplicationType.
                    ReleaseDetainedDrivingLicense).
                    ApplicationTypeFees;

            lblAppFees.Text = appFees.ToString();

            float fineFees =
                ctrlDriverLicenseInfoWithFilter1.
                SelectedLicenseInfo.
                DetainedInfo.FineFees;

            lblFineFees.Text = fineFees.ToString();

            lblTotalFees.Text = (appFees + fineFees).ToString();

            lblCreatedBy.Text = 
                ctrlDriverLicenseInfoWithFilter1.
                SelectedLicenseInfo.
                CreatedByUserInfo.
                UserName.ToString();   
        }

        private void OnLicenseSelected(int LicenseID)
        {
            _SelectedLicenseID = LicenseID;

            lblLicenseID.Text = _SelectedLicenseID.ToString();
            llShowLicensesHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)
                return;

            var license = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo;

            if (!license.IsDetained)
            {
                MessageBox.Show(
                    "This license is not currently detained.",
                    "Already Released",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                btnRelease.Enabled = false;
                return;
            }

            if (license.IsLicenseExpired)
            {
                MessageBox.Show(
                    "This license has expired.\n\nPlease verify the license information.",
                    "Expired License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                btnRelease.Enabled = false;
                return;
            }

            if (!license.IsActive)
            {
                MessageBox.Show(
                    "This license is inactive.\n\nPlease select a valid active license.",
                    "Inactive License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                btnRelease.Enabled = false;
                return;
            }
            
            _LoadReleaseLicenseInfo();
            btnRelease.Enabled = true;
        }

        private void frmReleaseDetainedLicenseApplication_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.SetLicenseIDFocus();
            ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += OnLicenseSelected;

            btnRelease.Enabled = false;
            llShowLicensesHistory.Enabled = false;
            llShowLicenseInfo.Enabled = false;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to release this detained license?",
                "Confirm License Release",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int ApplicationID = -1;

                bool isReleased =
                    ctrlDriverLicenseInfoWithFilter1.
                    SelectedLicenseInfo.
                    ReleaseDetainedLicense(clsGlobal.currentUser.UserID, ref ApplicationID);

                lblAppID.Text = ApplicationID.ToString();

                if (!isReleased)
                {
                    MessageBox.Show(
                        "Failed to release the license.\r\nPlease try again.",
                        "Operation Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show(
                    "The detained license has been released successfully.",
                    "Release Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                btnRelease.Enabled = false;
                llShowLicenseInfo.Enabled = true;
            }
            else
            {
                MessageBox.Show(
                    "The license release operation has been cancelled.",
                    "Operation Cancelled",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm =
                new frmShowPersonLicenseHistory(
                    ctrlDriverLicenseInfoWithFilter1.
                    SelectedLicenseInfo.
                    DriverInfo.
                    PersonID);

            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm =
                new frmShowLicenseInfo(_SelectedLicenseID);

            frm.ShowDialog();
        }

        private void frmReleaseDetainedLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.SetLicenseIDFocus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}