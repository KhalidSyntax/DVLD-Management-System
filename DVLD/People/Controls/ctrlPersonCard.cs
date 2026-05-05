using DVLD.Properties;
using DVLD_Business;
using System.IO;
using System.Windows.Forms;
using DVLD.People;

namespace DVLD
{
    public partial class ctrlPersonCard : UserControl
    {
        private clsPerson _Person;
        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void ResetPersonInfo()
        {
            llEditPersonInfo.Enabled = false;
            _PersonID = -1;
            lblPersonID.Text = "[???]";
            lblNationalNo.Text = "[???]";
            lblName.Text = "[???]";
            lblGender.Text = "[???]";
            lblEmail.Text = "[???]";
            lblAddress.Text = "[???]";
            lblDOB.Text = "[???]";
            lblPhone.Text = "[???]";
            lblCountry.Text = "[???]";
            pbPersonImage.Image = Resources.Male_512;
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show(
                    $"No Person With PersonID =  {PersonID}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show(
                    "No Person With NationalNo = {NationalNo}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            _FillPersonInfo();
        }

        private void _LoadPersonImage()
        {
            if (_Person.Gender)
                pbPersonImage.Image = Properties.Resources.Male_512;
            else
                pbPersonImage.Image = Properties.Resources.Female_512;

            string ImagePath = _Person.ImagePath;
            if(ImagePath != "")
            {
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show(
                        $"Could not find this image: = {ImagePath}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void _FillPersonInfo()
        {
            llEditPersonInfo.Enabled = true;
            _PersonID = _Person.PersonID;

            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            lblName.Text = _Person.FullName;
            lblGender.Text = _Person.Gender ? "Male" : "Female";

            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblDOB.Text = _Person.DateOfBirth.ToShortDateString();
            lblPhone.Text = _Person.Phone;
            lblCountry.Text = _Person.CountryInfo.CountryName;

            _LoadPersonImage();
        }

        private void llEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);

            frm.DataBack += (senderObj, savedPersonID) =>
            {
                LoadPersonInfo(savedPersonID);
            };
            frm.ShowDialog();
        }
    }
}
