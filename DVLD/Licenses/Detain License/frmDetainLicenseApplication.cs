using System;
using DVLD.Classes;
using DVLD_Business;
using DVLD.DriverLicense;
using System.Windows.Forms;

namespace DVLD.Licenses.Detain_License
{
    public partial class frmDetainLicenseApplication : Form
    {
        private int _DetainID = -1;
        private int _SelectedLicenseID = -1;

        public frmDetainLicenseApplication()
        {
            InitializeComponent();
        }

        private void _ResetDefaultValues()
        {
            lblDetainID.Text = "[???]";
            txtFineFees.Text = "";

            btnDetain.Enabled = false;
            llShowLicensesHistory.Enabled = false;
            llShowNewLicensesInfo.Enabled = false;
        }

        private void OnLicenseSelected(int LicenseID)
        {
            _SelectedLicenseID = LicenseID;

            lblLicenseID.Text = _SelectedLicenseID.ToString();
            llShowLicensesHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)
            {
                _ResetDefaultValues();
                return;
            }

            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                _ResetDefaultValues();

                MessageBox.Show(
                   "This license is already detained. You cannot detain it again.",
                   "License Already Detained",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                btnDetain.Enabled = false;
                return;
            }

            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired)
            {
                _ResetDefaultValues();

                MessageBox.Show(
                    "This license is expired. You cannot detain an expired license.",
                    "Expired License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                btnDetain.Enabled = false;
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

                btnDetain.Enabled = false;
                return;
            }

            txtFineFees.Focus();
            btnDetain.Enabled = true;
        }

        private void frmDetainLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            ctrlDriverLicenseInfoWithFilter1.SetLicenseIDFocus();
            ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += OnLicenseSelected;

            lblDetainDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedBy.Text = clsGlobal.currentUser.UserID.ToString();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to detain this license?",
                "Confirm License Detain",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                float fineFees;

                if (!float.TryParse(txtFineFees.Text.Trim(), out fineFees))
                {
                    MessageBox.Show("Please enter a valid number.");
                    txtFineFees.Focus();
                    return;
                }

                if (fineFees <= 0)
                {
                    MessageBox.Show("The value must be greater than zero.");
                    txtFineFees.Focus();
                    return;
                }

                if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo == null)
                {
                    MessageBox.Show("Please select a license first.");
                    return;
                }

                _DetainID =
                    ctrlDriverLicenseInfoWithFilter1
                    .SelectedLicenseInfo
                    .Detain(fineFees, clsGlobal.currentUser.UserID);


                if (_DetainID == -1)
                {
                    _ResetDefaultValues();
                    MessageBox.Show(
                        "Failed to detain the license.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                lblDetainID.Text = _DetainID.ToString();

                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                btnDetain.Enabled = false;
                txtFineFees.Enabled = false;
                llShowNewLicensesInfo.Enabled = true;

                MessageBox.Show(
                    $"License detained successfully.\n\nDetain ID: {_DetainID}",
                    "License Detained Successfully",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "License detain operation has been cancelled.",
                    "Operation Cancelled",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void llShowNewLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm =
                new frmShowInternationalLicenseInfo(_SelectedLicenseID);

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

        private void frmDetainLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.SetLicenseIDFocus();
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == (char)Keys.Back)
                return;

            if (e.KeyChar == '.')
            {
                if (txtFineFees.Text.Contains("."))
                {
                    e.Handled = true; 
                }
                return;
            }
            e.Handled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}