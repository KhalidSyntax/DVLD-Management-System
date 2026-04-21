using System;
using DVLD.Classes;
using DVLD.Properties;
using DVLD_Business;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlScheduledTest : UserControl
    {
        private clsTestAppointment _TestAppointment;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        
        private int _TestAppointmentID = -1;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _TestID = -1;
        
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; }

            private set
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

        public int TestAppointmentID
        {
            get { return _TestAppointmentID; }
        }

        public int TestID
        {
            get { return _TestID; }
        }

        public ctrlScheduledTest()
        {
            InitializeComponent();
        }

        public void ResetTestAppointmenInfo()
        {
            lblDriverLicenseApplicationID.Text = "N/A";
            lblDriverClass.Text = "[????]";
            lblName.Text = "[????]";
            lblTrial.Text = "[??]";
            lblDate.Text = "[??/??/????]";
            lblFees.Text = "[$$$]";
            lblTestID.Text = "[Not Taken Yet]";
        }

        public void LoadTestAppointmentInfo(int TestAppointmentID)
        {
            _TestAppointmentID = TestAppointmentID;

            _TestAppointment = clsTestAppointment
                .FindByTestAppointmentID(TestAppointmentID);

            if (_TestAppointment == null)
            {
                ResetTestAppointmenInfo();

                MessageBox.Show(
                    $"No Test Appointment With ID = {TestAppointmentID}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            TestTypeID = (clsTestType.enTestType)_TestAppointment.TestTypeID;

            _TestID = _TestAppointment.TestID;
            _LocalDrivingLicenseApplicationID =
                _TestAppointment.LocalDrivingLicenseApplicationID;

            _LocalDrivingLicenseApplication =
            clsLocalDrivingLicenseApplication.
            FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                ResetTestAppointmenInfo();
                MessageBox.Show(
                $"Error: No Local Driving License Application with ID = {_LocalDrivingLicenseApplicationID}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return;
            }
            _FillTestAppointmentInfo();
        }

        private void _FillTestAppointmentInfo()
        {
            lblDriverLicenseApplicationID.Text =
                _LocalDrivingLicenseApplication
                .LocalDrivingLicenseApplicationID
                .ToString();

            lblDriverClass.Text =
                _LocalDrivingLicenseApplication
                .LicenseClassInfo.ClassName;

            lblName.Text =
                _LocalDrivingLicenseApplication
                .PersonFullName;

            lblTrial.Text =
                _LocalDrivingLicenseApplication
                .TotalTrialsPerTest(_TestTypeID)
                .ToString();

            lblDate.Text = clsFormat.DateToShort(_TestAppointment.TestAppointmentDate);
            lblFees.Text = _TestAppointment.PaidFees.ToString("0.00");

            lblTestID.Text =
                (_TestAppointment.TestID != -1) ?
                _TestAppointment.TestID.ToString() :
                "Not Taken Yet";
        }
    }
}