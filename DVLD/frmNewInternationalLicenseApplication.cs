using DVLD.Classes;
using DVLD.DriverLicense;
using DVLD.Licenses;
using DVLD_Business;
using System;
using System.Windows.Forms;
using static DVLD_Business.clsApplication;

namespace DVLD.Applications
{
    public partial class frmNewInternationalLicenseApplication : Form
    {
        private int _NewInternationalLicenseID = -1;
        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void _ResetDefaultValues()
        {
            lblInternationalLicenseID.Text = "[???]";
            lblInternationalLicenseAppID.Text = "[???]";

            btnIssueLicense.Enabled = false;
        }

        private void OnLicenseSelected(int LicenseID)
        {
            int SelectedLicenseID = LicenseID;

            lblLocalLicenseID.Text = SelectedLicenseID.ToString();
            llShowLicensesHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
            {
                _ResetDefaultValues();
                return;
            }

            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassID != 3)
            {
                _ResetDefaultValues();

                MessageBox.Show(
                    "Cannot issue an international license because the driver does not hold a valid local driving license.",
                    "Operation Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                btnIssueLicense.Enabled = false;
                return;
            }

            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired)
            {
                _ResetDefaultValues();

                MessageBox.Show(
                    "Cannot issue international license because the local license is expired.",
                    "International License Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                btnIssueLicense.Enabled = false;
                return;
            }

            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                _ResetDefaultValues();

                MessageBox.Show(
                    "This license is inactive. Please select an active license.",
                    "Invalid License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                btnIssueLicense.Enabled = false;
                return;
            }

            int ActiveInternaionalLicenseID =
                clsInternationalLicense.GetActiveInternationalLicenseByDriverID(
                    ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);

            if (ActiveInternaionalLicenseID != -1)
            {
                _ResetDefaultValues();

                MessageBox.Show(
                    "An active international license already exists for this driver.",
                    "Duplicate License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                btnIssueLicense.Enabled = false;
                return;
            }

            btnIssueLicense.Enabled = true;
        }

        private void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            ctrlDriverLicenseInfoWithFilter1.SetLicenseIDFocus();
            ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += OnLicenseSelected;

            lblAppFees.Text = clsApplicationType.Find(
                (int)clsApplication.enApplicationType.NewInternationalLicense)
                .ApplicationTypeFees.ToString();

            lblAppDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblAppDate.Text;
            lblExpirationDate.Text = "[??/??/????]";

            lblCreatedBy.Text = clsGlobal.currentUser.UserID.ToString();

            btnIssueLicense.Enabled = false;
            llShowLicensesHistory.Enabled = false;
            llShowNewLicensesInfo.Enabled = false;
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    "Are you sure you want to issue an international driving license for the selected local license?",
                    "Confirm Issuance",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsInternationalLicense InternationalLicense =
                    new clsInternationalLicense();

                InternationalLicense.ApplicantPersonID =
                    ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;

                // InternationalLicense.ApplicationDate = DateTime.Now;
                // InternationalLicense.LastStatusDate = DateTime.Now;

                InternationalLicense.ApplicationTypeID =
                    (int)clsApplication.enApplicationType.NewInternationalLicense;
                InternationalLicense.ApplicationStatus = enApplicationStatus.Completed;
                InternationalLicense.PaidFees = 
                clsApplicationType.Find(
                (int)clsApplication.enApplicationType.NewInternationalLicense).ApplicationTypeFees;
                InternationalLicense.CreatedByUserID = clsGlobal.currentUser.UserID;


                InternationalLicense.DriverID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
                InternationalLicense.IssuedUsingLocalLicenseID = ctrlDriverLicenseInfoWithFilter1.LicenseID;
                InternationalLicense.IssueDate = DateTime.Now;
                InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
                InternationalLicense.IsActive = true;

                if (!InternationalLicense.Save())
                {
                    _ResetDefaultValues();
                    MessageBox.Show(
                        "Failed to issue the International License",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                lblInternationalLicenseAppID.Text = InternationalLicense.ApplicationID.ToString();
                _NewInternationalLicenseID = InternationalLicense.InternationalLicenseID;
                lblInternationalLicenseID.Text = _NewInternationalLicenseID.ToString();

                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                btnIssueLicense.Enabled = false;
                llShowNewLicensesInfo.Enabled = true;

                MessageBox.Show(
                    "International driving license has been issued successfully.\n\n" +
                    "International License ID: " + _NewInternationalLicenseID,
                    "Issuance Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "International license issuance has been cancelled.",
                    "Operation Cancelled",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void llShowNewLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm =
                new frmShowInternationalLicenseInfo(_NewInternationalLicenseID);

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

        private void frmNewInternationalLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.SetLicenseIDFocus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}