using DVLD.Classes;
using DVLD.Properties;
using DVLD_Business;
using System;
using System.IO;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        private clsInternationalLicense _InternationalLicense;
        private int _InternationalLicenseID = -1;

        public int InternationalLicenseID
        {
            get { return _InternationalLicenseID; }
        }

        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public void ResetDriverInfo()
        {
            lblName.Text = "[????]";
            lblInternationalLicenseID.Text = "[????]";
            lblLicenseID.Text = "[???]";

            lblNationalNo.Text = "[????]";
            lblGender.Text = "[????]";
            lblIssueDate.Text = "[??/??/????]";

            lblAppID.Text = "[???]";
            lblIsActive.Text = "[??]";
            lblDriverID.Text = "[???]";
            lblDOB.Text = "[??/??/????]";
            lblExpirationDate.Text = "[????]";

            pbPersonImage.Image = Resources.Male_512;
        }

        public void LoadInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID = InternationalLicenseID;
            _InternationalLicense =
                clsInternationalLicense.FindByInternationalLicenseID(_InternationalLicenseID);

            if (_InternationalLicense == null)
            {
                ResetDriverInfo();
                MessageBox.Show(
                    $"No International License was found with the following ID:\n\n{InternationalLicenseID}",
                    "International License Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                _InternationalLicenseID = -1;
                return;
            }
            _FillInternationalLicenseInfo();
        }

        private void _FillInternationalLicenseInfo()
        {
            lblName.Text = _InternationalLicense.DriverInfo.PersonInfo.FullName;
            lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lblLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();

            lblNationalNo.Text = _InternationalLicense.DriverInfo.PersonInfo.NationalNo;
            lblGender.Text = _InternationalLicense.DriverInfo.PersonInfo.Gender ? "Male" : "Female";
            lblIssueDate.Text = clsFormat.DateToShort(_InternationalLicense.IssueDate);

            lblAppID.Text = _InternationalLicense.ApplicationID.ToString();
            lblIsActive.Text = _InternationalLicense.IsActive ? "Yes" : "No";
            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblDOB.Text = clsFormat.DateToShort(_InternationalLicense.DriverInfo.PersonInfo.DateOfBirth);
            lblExpirationDate.Text = clsFormat.DateToShort(_InternationalLicense.ExpirationDate);

            _LoadPersonImage();
        }

        private void _LoadPersonImage()
        {
            if (_InternationalLicense.DriverInfo.PersonInfo.Gender)
                pbPersonImage.Image = Properties.Resources.Male_512;
            else
                pbPersonImage.Image = Properties.Resources.Female_512;

            string ImagePath = _InternationalLicense.DriverInfo.PersonInfo.ImagePath;
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