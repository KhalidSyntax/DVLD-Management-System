using System;
using System.IO;
using DVLD.Classes;
using DVLD_Business;
using DVLD.Properties;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        private clsLicense _License;
        private int _LicenseID = -1;

        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public clsLicense SelectedLicenseInfo
        {
            get { return _License; }
        }

        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public void ResetDriverInfo()
        {
            lblClass.Text = "[????]";
            lblName.Text = "[????]";
            lblLicenseID.Text = "[???]";
            lblNationalNo.Text = "[????]";

            lblGender.Text = "[????]";
            lblIssueDate.Text = "[??/??/????]";
            lblIssueReason.Text = "[????]";
            lblNotes.Text = "[????]";

            lblIsActive.Text = "[??]";
            lblDOB.Text = "[??/??/????]";
            lblExpirationDate.Text = "[??/??/?????]";
            lblDriverID.Text = "[???]";
            lblIsDetainted.Text = "[??]";

            pbPersonImage.Image = Resources.Male_512;
        }

        public void LoadDriverInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.FindByLicenseID(LicenseID);

            if (_License == null)
            {
                ResetDriverInfo();
                MessageBox.Show(
                    $"No driver was found with License ID: {LicenseID}",
                    "Driver Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                _LicenseID = -1;
                return;
            }
            _FillDriverInfo();
        }

        private void _FillDriverInfo()
        {
            lblClass.Text = _License.LicenseClassInfo.ClassName;
            lblName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblDriverID.Text = _License.DriverID.ToString();

            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblGender.Text = _License.DriverInfo.PersonInfo.Gender ? "Male" : "Female";
            lblDOB.Text = clsFormat.DateToShort(_License.DriverInfo.PersonInfo.DateOfBirth);
            
            lblIssueDate.Text = clsFormat.DateToShort(_License.IssueDate);
            lblExpirationDate.Text = clsFormat.DateToShort(_License.ExpirationDate);
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";

            lblIssueReason.Text = _License.IssueReasonText;
            lblNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
            lblIsDetainted.Text = _License.IsDetained ? "Yes" : "No";

            _LoadPersonImage();
        }

        private void _LoadPersonImage()
        {
            if (_License.DriverInfo.PersonInfo.Gender)
                pbPersonImage.Image = Properties.Resources.Male_512;
            else
                pbPersonImage.Image = Properties.Resources.Female_512;

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;
            if (!string.IsNullOrEmpty(ImagePath))
            {
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    MessageBox.Show(
                        $"Could not find this image: {ImagePath}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
    }
}