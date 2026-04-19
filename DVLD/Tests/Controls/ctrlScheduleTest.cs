using DVLD.Classes;
using DVLD.Properties;
using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlScheduleTest : UserControl
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;

        private enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 }
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private clsTestAppointment _TestAppointment;
        private int _TestAppointmentID = -1;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID = -1;

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; }

            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {
                    case clsTestType.enTestType.VisionTest:
                        pbTestTypeImage.Image = Resources.Vision_512;
                        gbTestType.Text = "Vision Test";
                        break;

                    case clsTestType.enTestType.WrittenTest:
                        pbTestTypeImage.Image = Resources.Written_Test_512;
                        gbTestType.Text = "Written Test";
                        break;

                    case clsTestType.enTestType.StreetTest:
                        pbTestTypeImage.Image = Resources.driving_test_512;
                        gbTestType.Text = "Street Test";
                        break;
                }
            }
        }

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }

        public void ResetTestInfo()
        {
            gbRetakeTestInfo.Enabled = false;
            lblMessage.Visible = false;

            lblDriverLicenseApplicationID.Text = "N/A";
            lblDriverClass.Text = "[???]";
            lblName.Text = "[???]";
            lblTrial.Text = "[???]";
            dtpTestDate.Value = DateTime.Now;
            lblFees.Text = "[$$$]";

            lblRetakeTestAppID.Text = "N/A";
            lblRetakeAppFees.Text = "[$$$]";
            lblTotalFees.Text = "[$$$]";

            dtpTestDate.Format = DateTimePickerFormat.Custom;
            dtpTestDate.CustomFormat = "dd/MM/yyyy hh:mm tt";
            dtpTestDate.ShowUpDown = true;
        }

        public void LoadInfo(int LocalDrivingLicenseApplicationID, int TestAppointmentID = -1)
        {
            if (TestAppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = TestAppointmentID;

            _LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.
                FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show(
                $"Error: No Local Driving License Application with ID = {LocalDrivingLicenseApplicationID}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                btnSave.Enabled = false;
                return;
            }

            if (_LocalDrivingLicenseApplication.DoesAttendTestType(_TestTypeID))
                _CreationMode = enCreationMode.RetakeTestSchedule;
            else
                _CreationMode = enCreationMode.FirstTimeSchedule;

            DateTime lastDate = clsLocalDrivingLicenseApplication.
                GetLastTestAppointmentDate(_LocalDrivingLicenseApplicationID, _TestTypeID);

            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                lblTitle.Text = "Schedule Retake Test";
                gbRetakeTestInfo.Enabled = true;

                lblRetakeTestAppID.Text = "0";
                lblRetakeAppFees.Text =
                    clsApplicationType.Find(
                        (int)clsApplication.enApplicationType.RetakeTest).
                        ApplicationTypeFees.ToString();

                dtpTestDate.MinDate = lastDate > DateTime.Now ? lastDate : DateTime.Now;
            }
            else
            {
                lblTitle.Text = "Schedule Test";
                gbRetakeTestInfo.Enabled = false;

                lblRetakeTestAppID.Text = "N/A";
                lblRetakeAppFees.Text = "0";

                dtpTestDate.MinDate = DateTime.Now;
            }

            lblDriverLicenseApplicationID.Text =
                _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDriverClass.Text =
                _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;

            lblName.Text = _LocalDrivingLicenseApplication.PersonFullName;
            lblTrial.Text = _LocalDrivingLicenseApplication.
                TotalTrialsPerTest(_TestTypeID).ToString();

            if (_Mode == enMode.AddNew)
            {
                _TestAppointment = new clsTestAppointment();

                lblFees.Text = clsTestType.Find(_TestTypeID).TestTypeFees.ToString();
                lblRetakeTestAppID.Text = "N/A";

                if (!_HandleActiveTestAppointmentConstraint())
                    return;

                if (!_HandlePrviousTestConstraint())
                    return;
            }
            else
            {
                if (!_LoadTestAppointmentData())
                    return;

                if (_TestAppointment.IsLocked)
                {
                    MessageBox.Show(
                        "This appointment is already completed. You cannot edit it. Please schedule a new test.",
                        "Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    btnSave.Enabled = false;
                    dtpTestDate.Enabled = false;
                    return;
                }

                lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) +
                                    Convert.ToSingle(lblRetakeAppFees.Text)).
                                    ToString();

                if (!_HandleAppointmentLockedConstraint())
                    return;
            }
        }

        private bool _LoadTestAppointmentData()
        {
            _TestAppointment = clsTestAppointment.FindByTestAppointmentID(_TestAppointmentID);

            if(_TestAppointment == null)
            {
                MessageBox.Show(
                $"Error: No Appointment with ID = {_TestAppointmentID}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                btnSave.Enabled = false;
                return false;
            }

            lblFees.Text = _TestAppointment.PaidFees.ToString();

            if (DateTime.Compare(DateTime.Now, _TestAppointment.TestAppointmentDate) < 0)
                dtpTestDate.MinDate = DateTime.Now;
            else
                dtpTestDate.MinDate = _TestAppointment.TestAppointmentDate;

            dtpTestDate.Value = _TestAppointment.TestAppointmentDate;

            if(_TestAppointment.RetakeTestApplicationID == -1)
            {
                lblRetakeTestAppID.Text = "N/A";
                lblRetakeAppFees.Text = "0";
            }
            else
            {
                lblRetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
                lblRetakeAppFees.Text = _TestAppointment.RetakeTestApplicationInfo.PaidFees.ToString();

                lblTitle.Text = "Schedule Retake Test";
                gbRetakeTestInfo.Enabled = true;
            }
            return true;
        }

        private bool _HandleActiveTestAppointmentConstraint()
        {
            if(_Mode == enMode.AddNew &&
                clsLocalDrivingLicenseApplication.
                IsThereAnActiveScheduledTest(
                    _LocalDrivingLicenseApplicationID,
                    _TestTypeID))
            {
                lblMessage.Text = "Person Already have an active appointment for this test";
                
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;

                return false;
            }
            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            if (_TestAppointment.IsLocked)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Person already sat for the test, appointment locked.";

                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;

                return false;
            }
            lblMessage.Visible = false;
            return true;
        }

        private bool _HandlePrviousTestConstraint()
        {
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    lblMessage.Visible = false;
                    return true;

                case clsTestType.enTestType.WrittenTest:
                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest))
                    {
                        lblMessage.Text = "Cannot Schedule, Vision Test should be passed first";
                        lblMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;

                        return false;
                    }
                    lblMessage.Visible = false;
                    btnSave.Enabled = true;
                    dtpTestDate.Enabled = true;

                    return true;

                case clsTestType.enTestType.StreetTest:
                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest))
                    {
                        lblMessage.Text = "Cannot Schedule, Written Test should be passed first";
                        lblMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;

                        return false;
                    }
                    lblMessage.Visible = false;
                    btnSave.Enabled = true;
                    dtpTestDate.Enabled = true;

                    return true;
            }
            return true;
        }

        private bool _HandleRetakeApplication()
        {
            if (_Mode == enMode.AddNew &&
                _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                clsApplication Application = new clsApplication();

                Application.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                // Application.ApplicationDate = DateTime.Now;

                Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;

                // Application.LastStatusDate = DateTime.Now;

                Application.PaidFees =
                clsApplicationType.Find(
                    (int)clsApplication.enApplicationType.RetakeTest).ApplicationTypeFees;

                Application.CreatedByUserID = clsGlobal.currentUser.UserID;

                if (!Application.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show(
                    "Failed to Create application",
                    "Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    return false;
                }
                _TestAppointment.RetakeTestApplicationID = Application.ApplicationID;
            }
            return true; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplication())
                return;

            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID =
                _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;

            _TestAppointment.TestAppointmentDate = dtpTestDate.Value;
            _TestAppointment.PaidFees = Convert.ToSingle(lblFees.Text);

            _TestAppointment.CreatedByUserID = clsGlobal.currentUser.UserID;

            if (_TestAppointment.Save())
            {
                _Mode = enMode.Update;

                MessageBox.Show(
                "Data Saved Successfully.",
                "Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show(
                "Error: Data Is not Saved Successfully.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}