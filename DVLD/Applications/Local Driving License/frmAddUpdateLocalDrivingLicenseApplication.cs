using System;
using System.Data;
using DVLD.Classes;
using DVLD_Business;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {
        private enum enMode { AddNew = 0, Update = 1 }

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        private enMode _Mode;

        public frmAddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void _FillLicenseClassesInComboBox()
        {
            //DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses();

            //foreach (DataRow row in dtLicenseClasses.Rows)
            //{
            //    cbLicenseClass.Items.Add(row["ClassName"]);
            //}

            cbLicenseClass.DataSource = clsLicenseClass.GetAllLicenseClasses();
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";
        }

        private void _ResetDefaultValues()
        {
            _FillLicenseClassesInComboBox();

            if (_Mode == enMode.AddNew)
            {
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                
                ctrlPersonCardWithFilter1.FilterFocus();
                tpApplicationInfo.Enabled = false;
                btnSave.Enabled = false;

                cbLicenseClass.SelectedIndex = 2;

                _LocalDrivingLicenseApplication.ApplicationTypeID = 
                    (int)clsApplication.enApplicationType.NewDrivingLicense;

                _LocalDrivingLicenseApplication.PaidFees = 
                    _LocalDrivingLicenseApplication.ApplicationTypeInfo.ApplicationTypeFees;

                lblApplicationFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString("F2");

                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedBy.Text = clsGlobal.currentUser.UserName;
            }
            else
            {
                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
            }

            lblMode.Text = this.Text =
                (_Mode == enMode.AddNew ? "Add New" : "Update") +
                " Local Driving License Application";
        }

        private void _LoadData()
        {
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            _LocalDrivingLicenseApplication = 
                clsLocalDrivingLicenseApplication.
                FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show(
                    "No Application with ID = " + _LocalDrivingLicenseApplicationID,
                    "Application Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                _ResetDefaultValues();

                this.Close();
                return;
            }

            ctrlPersonCardWithFilter1.FilterEnabled = true;
            ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            _SelectedPersonID = ctrlPersonCardWithFilter1.PersonID;

            lblLocalDrivingLicebseApplicationID.Text = 
                _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();

            lblApplicationDate.Text =
                clsFormat.DateToShort(_LocalDrivingLicenseApplication.ApplicationDate);

            cbLicenseClass.SelectedValue =
                    _LocalDrivingLicenseApplication.LicenseClassID;

            lblApplicationFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString("F2");
            lblCreatedBy.Text = _LocalDrivingLicenseApplication.CreatedByUserInfo.UserName;
        }

        private void frmAddUpdateLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcApplication.SelectedTab = tcApplication.TabPages["tpApplicationInfo"];
                return;
            }

            if (_SelectedPersonID != -1)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcApplication.SelectedTab = tcApplication.TabPages["tpApplicationInfo"];
            }
            else
            {
                btnSave.Enabled = false;
                tpApplicationInfo.Enabled = false;
                MessageBox.Show(
                    "Please select a person first.",
                    "Select a Person",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbLicenseClass.SelectedIndex == -1)
            {
                MessageBox.Show("Please select License Class");
                return;
            }

            int LicenseClassID = (int)cbLicenseClass.SelectedValue;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;

            if (!_LocalDrivingLicenseApplication.IsApplicantOldEnough())
            {
                MessageBox.Show(
                    "Applicant age is less than the minimum allowed age for this license class.",
                    "Age Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                cbLicenseClass.Focus();
                return;
            }

            int ActiveApplicationID =
                clsApplication.GetActiveApplicationID(
                    _SelectedPersonID,
                    clsApplication.enApplicationType.NewDrivingLicense,
                    LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show(
                    "Choose another License Class, the selected Person already has an active application for the selected class with id = "
                    + ActiveApplicationID,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                cbLicenseClass.Focus();
                return;
            }

            //if (clsLicense.IsLicenseExistByPersonID(_SelectedPersonID, LicenseClassID))
            //{
            //    MessageBox.Show(
            //        "Person already has a license with the same applied driving class, choose different driving class",
            //        "Not allowed",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error
            //    );
            //    return;
            //}

            if (MessageBox.Show(
                    "Do You Want To Save Data?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _LocalDrivingLicenseApplication.ApplicantPersonID = _SelectedPersonID;
                _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
                _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
                _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblApplicationFees.Text.Trim());
                _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.currentUser.UserID;

                if (_LocalDrivingLicenseApplication.Save())
                {
                    lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                    _Mode = enMode.Update;
                    btnSave.Enabled = true;
                    lblMode.Text = "Update Local Driving License Application";

                    MessageBox.Show(
                        "Data Saved Successfully.",
                        "Saved",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Error: Data Didn't Save Successfully.",
                        "Error",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                }
            }
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddUpdateLocalDrivingLicense_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }
    }
}