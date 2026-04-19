using System;
using DVLD.People;
using DVLD_Business;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        private clsApplication _Application;
        private int _ApplicationID = -1;

        public int ApplicationID
        {
            get { return _ApplicationID; }
        }

        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public void ResetApplicationInfo()
        {
            _ApplicationID = -1;

            lblApplicationID.Text = "[???]";
            lblStatus.Text = "[???]";

            lblFees.Text = "[$$$]";
            lblType.Text = "[???]";

            lblApplicantName.Text = "[????]";
            lblDate.Text = "[??/??/????]";

            lblStatusDate.Text = "[??/??/????]";
            lblCreatedBy.Text = "[???]";

            llShowPersonInfo.Enabled = false;
        }

        private void _FillApplicationInfo()
        {
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.StatusText;

            lblFees.Text = _Application.ApplicationTypeInfo.ApplicationTypeFees.ToString();
            lblType.Text = _Application.ApplicationTypeInfo.ApplicationTypeTitle;

            lblApplicantName.Text = _Application.ApplicantFullName;
            lblDate.Text = _Application.ApplicationDate.ToString("dd/MM/yyyy");

            lblStatusDate.Text = _Application.LastStatusDate.ToString("dd/MM/yyyy");
            lblCreatedBy.Text = _Application.CreatedByUserInfo.UserName;

            llShowPersonInfo.Enabled = true;
        }

        public void LoadByApplicationID(int ApplicationID)
        {
            _ApplicationID = ApplicationID;
            _Application =
                clsApplication.FindBaseApplication(ApplicationID);

            if (_Application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show(
                    $"No application found with ID = {ApplicationID}.",
                    "Application Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            _FillApplicationInfo();
        }

        private void llShowPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(
                _Application.ApplicantPersonID);

            frm.ShowDialog();
        }
    }
}