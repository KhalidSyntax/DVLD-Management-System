using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using DVLD_Business;
using DVLD.Classes;

namespace DVLD.People
{
    public partial class frmAddUpdatePerson : Form
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int _PersonID = -1;
        private clsPerson _Person;

        public delegate void DataBackEventHandler(object sender, int PersonID);
        public DataBackEventHandler DataBack;

        public frmAddUpdatePerson()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
            _Mode = enMode.Update;
        }

        private bool _HasChanges()
        {
            if (_Mode == enMode.AddNew) return true;
            if (_Person == null) return true;

            string UI(string s) => (s ?? "").Trim();
            string DB(string s) => (s ?? "").Trim();

            if (UI(txtNationalNo.Text) != DB(_Person.NationalNo)) return true;

            if (UI(txtFirstName.Text) != DB(_Person.FirstName)) return true;
            if (UI(txtSecondName.Text) != DB(_Person.SecondName)) return true;
            if (UI(txtThirdName.Text) != DB(_Person.ThirdName)) return true;
            if (UI(txtLastName.Text) != DB(_Person.LastName)) return true;

            if (dtpDOB.Value.Date != _Person.DateOfBirth.Date) return true;

            if (UI(txtAddress.Text) != DB(_Person.Address)) return true;
            if (UI(txtEmail.Text) != DB(_Person.Email)) return true;
            if (UI(txtPhone.Text) != DB(_Person.Phone)) return true;

            bool uiGender = rbMale.Checked;
            if (uiGender != _Person.Gender) return true;

            int uiCountryID = clsCountry.Find(cbCountries.Text).CountryID;
            if (uiCountryID != _Person.NationalityCountryID) return true;

            string uiImagePath = (pbPersonImage.ImageLocation ?? "").Trim();
            string dbImagePath = DB(_Person.ImagePath);
            if (uiImagePath != dbImagePath) return true;

            return false;
        }

        private void _FillCountriesInComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach(DataRow row in dtCountries.Rows)
            {
                cbCountries.Items.Add(row["CountryName"]);
            }
        }

        private void _ResetDefaultValues()
        {
            _FillCountriesInComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblMode.Text = "Update Person";
            }

            lblPersonID.Text = "";
            txtNationalNo.Text = "";
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";

            if (rbMale.Checked)
                pbPersonImage.Image = Properties.Resources.Male_512;
            else
                pbPersonImage.Image = Properties.Resources.Female_512;

            pbPersonImage.ImageLocation = null;
            llRemoveImage.Visible = false;

            dtpDOB.MaxDate = DateTime.Now.AddYears(-18);
            dtpDOB.MinDate = DateTime.Now.AddYears(-100);
            dtpDOB.Value = dtpDOB.MaxDate;

            cbCountries.SelectedIndex = cbCountries.FindString("Saudi Arabia");
        }

        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);

            if(_Person == null)
            {
                MessageBox.Show("This Form will be closed because no person with ID = " + _PersonID);
                this.Close();
                return;
            }

            lblMode.Text = "Update Person";
            lblPersonID.Text = _PersonID.ToString();
            txtNationalNo.Text = _Person.NationalNo;

            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            if (_Person.ThirdName != "")
                txtThirdName.Text = _Person.ThirdName;
            else
                txtThirdName.Text = "";
            txtLastName.Text = _Person.LastName;

            if (_Person.Gender)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            if (_Person.Email != "")
                txtEmail.Text = _Person.Email;
            else
                txtEmail.Text = "";

            txtAddress.Text = _Person.Address;
            dtpDOB.Value = _Person.DateOfBirth;
            txtPhone.Text = _Person.Phone;
            cbCountries.SelectedIndex = cbCountries.FindString(_Person.CountryInfo.CountryName);

            if (!string.IsNullOrWhiteSpace(_Person.ImagePath))
                pbPersonImage.ImageLocation = _Person.ImagePath;
            else
            {
                if (_Person.Gender)
                    pbPersonImage.Image = Properties.Resources.Male_512;
                else
                    pbPersonImage.Image = Properties.Resources.Female_512;
            }
            llRemoveImage.Visible = !string.IsNullOrWhiteSpace(_Person.ImagePath);
        }

        private void frmAddNewPerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                Temp.Focus();
                errorProvider1.SetError(Temp, Temp.Tag + " should have a value!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National No should have a value!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }


            if(txtNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.IsPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National No is used for another person!");
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
                return;

            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, " Invalid Email Format!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Properties.Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Properties.Resources.Female_512;
        }

        private bool _HandlePersonImage()
        {
           if(_Person.ImagePath != pbPersonImage.ImageLocation)
           {
                if(!String.IsNullOrWhiteSpace(_Person.ImagePath))
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch(IOException)
                    {

                    }
                }

                if(pbPersonImage.ImageLocation != null)
                {
                    string sourceImageFile = pbPersonImage.ImageLocation.ToString();

                    if(clsUtil.CopyImageToProjectImagesFolder(ref sourceImageFile))
                    {
                        pbPersonImage.ImageLocation = sourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show(
                            "Error Copying Image File",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return false;
                    }
                }
           }
            return true;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.ImageLocation = selectedFilePath;
                llRemoveImage.Visible = true;
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            llRemoveImage.Visible = false;

            if (rbMale.Checked)
                pbPersonImage.Image = Properties.Resources.Male_512;
            else
                pbPersonImage.Image = Properties.Resources.Female_512;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show(
                    "Please fix the errors.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (!_HandlePersonImage())
                return;

            if(!_HasChanges())
            {
                MessageBox.Show("No changes to save.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show(
                    "Do You Want To Save Data?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Person.NationalNo = txtNationalNo.Text.Trim();
                _Person.FirstName = txtFirstName.Text.Trim();
                _Person.SecondName = txtSecondName.Text.Trim();
                if (txtThirdName.Text != "")
                    _Person.ThirdName = txtThirdName.Text.Trim();
                else
                    _Person.ThirdName = "";
                _Person.LastName = txtLastName.Text.Trim();

                _Person.DateOfBirth = dtpDOB.Value;
                _Person.Address = txtAddress.Text.Trim();
                _Person.Email = txtEmail.Text.Trim();
                _Person.Phone = txtPhone.Text.Trim();
                if (rbMale.Checked)
                    _Person.Gender = true;
                else
                    _Person.Gender = false;

                if (!string.IsNullOrWhiteSpace(pbPersonImage.ImageLocation))
                {
                    _Person.ImagePath = pbPersonImage.ImageLocation;
                }
                else
                    _Person.ImagePath = "";

                _Person.NationalityCountryID = clsCountry.Find(cbCountries.Text).CountryID;

                if (_Person.Save())
                {
                    lblPersonID.Text = _Person.PersonID.ToString();
                    _Mode = enMode.Update;
                    lblMode.Text = "Update Person";

                    DataBack?.Invoke(this, _Person.PersonID);

                    MessageBox.Show("Data Saved Successfully.", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("Error: Data Didn't Save Successfully.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}