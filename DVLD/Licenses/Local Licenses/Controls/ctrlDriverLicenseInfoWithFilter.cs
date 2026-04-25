using System;
using DVLD_Business;
using System.Windows.Forms;

namespace DVLD.Licenses.Local_Licenses.Controls
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        public event Action<int> OnLicenseSelected;

        protected virtual void LicenseSelected(int licenseID)
        {
            OnLicenseSelected?.Invoke(licenseID);
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get { return _FilterEnabled; }

            set 
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        private int _LicenseID = -1;

        public int LicenseID => ctrlDriverLicenseInfo1.LicenseID;
        
        public clsLicense SelectedLicenseInfo { get => ctrlDriverLicenseInfo1.SelectedLicenseInfo; }

        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        private void LoadLicenseInfo(int LicenseID)
        {
            txtLicenseID.Text = LicenseID.ToString();
            ctrlDriverLicenseInfo1.LoadDriverInfo(LicenseID);
            _LicenseID = ctrlDriverLicenseInfo1.LicenseID;

            if (OnLicenseSelected != null && FilterEnabled)
                LicenseSelected(_LicenseID);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show(
                    "Please correct the highlighted fields before continuing.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            _LicenseID = int.Parse(txtLicenseID.Text.Trim());
            LoadLicenseInfo(_LicenseID);
        }

        public void SetLicenseIDFocus()
        {
            txtLicenseID.Focus();
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (e.KeyChar == (Char)13)
                btnFind.PerformClick();
        }

        private void txtLicenseID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtLicenseID.Text))
            {
                // e.Cancel = true;
                epLicenseValidation.SetError(txtLicenseID, "Please enter a value for this field.");
            }
            else
            {
                // e.Cancel = false;
                epLicenseValidation.SetError(txtLicenseID, null);
            }
        }
    }
}