using DVLD.Classes;
using DVLD.DriverLicense;
using DVLD.Licenses;
using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmReplaceLostOrDamagedLicenseApplication : Form
    {
        private int _NewLicenseID = -1;

        public frmReplaceLostOrDamagedLicenseApplication()
        {
            InitializeComponent();
        }

        private void _ResetDefaultValues()
        {
            lblLicenseReplacementAppID.Text = "[???]";
            lblReplacementLicenseID.Text = "[???]";
            lblOldLicenseID.Text = "[???]";

            btnIssueReplacement.Enabled = false;
        }

        private clsLicense.enIssueReason GetIssueReason()
        {
            if (rbDamagedLicense.Checked)
                return clsLicense.enIssueReason.ReplacementForDamaged;

            return clsLicense.enIssueReason.ReplacementForLost;
        }

        private void SetApplicationFeesAndTitle()
        {
            clsApplication.enApplicationType AppType;

            if (rbDamagedLicense.Checked)
                AppType = clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;

            else
                AppType = clsApplication.enApplicationType.ReplaceLostDrivingLicense;

            lblAppFees.Text = clsApplicationType.Find(
            (int)AppType).ApplicationTypeFees.ToString();

            lblTitle.Text =
                rbDamagedLicense.Checked ?
                "Replacement For Damaged License" :
                "Replacement For Lost License";
        }

        private void OnLicenseSelected(int LicenseID)
        {
            int SelectedLicenseID = LicenseID;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            llShowLicensesHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
            {
                _ResetDefaultValues();
                return;
            }

            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                _ResetDefaultValues();
                MessageBox.Show(
                    "Selected license is inactive.Please choose an active license.",
                    "Not allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                btnIssueReplacement.Enabled = false;
                return;
            }

            btnIssueReplacement.Enabled = true;
        }

        private void frmReplaceLostOrDamagedLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            ctrlDriverLicenseInfoWithFilter1.SetLicenseIDFocus();
            ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += OnLicenseSelected;

            SetApplicationFeesAndTitle();

            lblAppDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedBy.Text = clsGlobal.currentUser.UserID.ToString();

            btnIssueReplacement.Enabled = false;
            llShowLicensesHistory.Enabled = false;
            llShowNewLicensesInfo.Enabled = false;

            rbDamagedLicense.Checked = true;
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to issue a replacement for the selected license?",
                "Confirm License Replacement",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsLicense NewLicense =
                    ctrlDriverLicenseInfoWithFilter1.
                    SelectedLicenseInfo.
                    Replace(GetIssueReason(), clsGlobal.currentUser.UserID);

                if (NewLicense == null)
                {
                    _ResetDefaultValues();
                    MessageBox.Show(
                        "Failed to issue the replacement license.",
                        "Operation Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                lblLicenseReplacementAppID.Text = NewLicense.ApplicationID.ToString();
                _NewLicenseID = NewLicense.LicenseID;
                lblReplacementLicenseID.Text = _NewLicenseID.ToString();

                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                btnIssueReplacement.Enabled = false;
                llShowNewLicensesInfo.Enabled = true;
                gbReplacement.Enabled = false;

                MessageBox.Show(
                    $"The replacement license has been issued successfully.\n\nNew License ID: {_NewLicenseID}",
                    "License Replacement Completed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "License replacement operation has been cancelled.",
                    "Operation Cancelled",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void llShowNewLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
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

        private void rbDamgedLicense_CheckedChanged(object sender, EventArgs e)
        {
            SetApplicationFeesAndTitle();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            SetApplicationFeesAndTitle();
        }

        private void frmReplaceLostOrDamagedLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.SetLicenseIDFocus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}