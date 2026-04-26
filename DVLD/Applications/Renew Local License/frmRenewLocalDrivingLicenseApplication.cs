using DVLD.Classes;
using DVLD.DriverLicense;
using DVLD_Business;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class frmRenewLocalDrivingLicenseApplication : Form
    {
        private int _NewLicenseID = -1;

        public frmRenewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void _ResetDefaultValues()
        {
            lblOldLicenseID.Text = "[???]";
            lblRenewdLicenseID.Text = "[???]";
            lblExpirationDate.Text = "[??/??/????]";
            txtNotes.Text = "";
            lblLicenseFees.Text = "[$$$]";
            lblTotalFees.Text = "[$$$]";

            btnRenewLicense.Enabled = false;
        }

        private void _LoadRenewLicenseInfo()
        {
            int DefaultValidityLength =
            ctrlDriverLicenseInfoWithFilter1.
            SelectedLicenseInfo.
            LicenseClassInfo.
            DefaultValidityLength;

            lblExpirationDate.Text =
                clsFormat.DateToShort(DateTime.Now.AddYears(DefaultValidityLength));

            lblLicenseFees.Text =
                ctrlDriverLicenseInfoWithFilter1.
                SelectedLicenseInfo.
                LicenseClassInfo.
                ClassFees.ToString();

            lblTotalFees.Text =
                (
                  Convert.ToSingle(lblAppFees.Text) +
                  Convert.ToSingle(lblLicenseFees.Text)
                ).ToString();

            txtNotes.Text =
                ctrlDriverLicenseInfoWithFilter1.
                SelectedLicenseInfo.
                Notes;
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

            _LoadRenewLicenseInfo();

            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired)
            {
                _ResetDefaultValues();
                MessageBox.Show(
                    $"This license is still valid and cannot be renewed yet.\n\nExpiration Date: " +
                    $"{ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate:dd/MM/yyyy}",
                    "Renewal Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                btnRenewLicense.Enabled = false;
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

                btnRenewLicense.Enabled = false;
                return;
            }

            btnRenewLicense.Enabled = true;
        }

        private void frmRenewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            ctrlDriverLicenseInfoWithFilter1.SetLicenseIDFocus();
            ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += OnLicenseSelected;

            lblAppFees.Text = clsApplicationType.Find(
                (int)clsApplication.enApplicationType.RenewDrivingLicense)
                .ApplicationTypeFees.ToString();

            lblAppDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblAppDate.Text;
            lblExpirationDate.Text = "[??/??/????]";

            lblCreatedBy.Text = clsGlobal.currentUser.UserID.ToString();

            btnRenewLicense.Enabled = false;
            llShowNewLicensesInfo.Enabled = false;
        }

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to renew the selected license?",
                "Confirm License Renewal",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsLicense NewLicense =
                    ctrlDriverLicenseInfoWithFilter1.
                    SelectedLicenseInfo.
                    RenewLicense(txtNotes.Text.Trim(), clsGlobal.currentUser.UserID);

                if (NewLicense == null)
                {
                    _ResetDefaultValues();
                    MessageBox.Show(
                        "Faild to Renew the License",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                lblRenewLicenseAppID.Text = NewLicense.ApplicationID.ToString();
                _NewLicenseID = NewLicense.LicenseID;
                lblRenewdLicenseID.Text = _NewLicenseID.ToString();

                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                btnRenewLicense.Enabled = false;
                llShowNewLicensesInfo.Enabled = true;

                MessageBox.Show(
                    "License renewed successfully.\n\nNew License ID: " + _NewLicenseID,
                    "Renewal Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "License renewal has been cancelled.",
                    "Operation Cancelled",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmShowPersonLicenseHistory frm =
            //new frmShowPersonLicenseHistory(
            //    ctrlDriverLicenseInfoWithFilter1
            //    .SelectedLicenseInfo
            //    .DriverInfo
            //    .PersonID);

            //frm.ShowDialog();

            MessageBox.Show(
                "This Feature Is Not Implemented Yet!",
                "Not Ready!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

        private void llShowNewLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }

        private void frmRenewLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.SetLicenseIDFocus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
