using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmScheduleTest : Form
    {
        private int 
            _LocalDrivingLicenseApplicationID = -1,
            _TestAppointmentID = -1;

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID, int TestAppointmentID = -1)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = TestAppointmentID;
            _TestTypeID = TestTypeID;
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestTypeID = _TestTypeID;
            ctrlScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _TestAppointmentID);

            if (_TestAppointmentID != -1)
            {
                clsTestAppointment appointment =
                    clsTestAppointment.FindByTestAppointmentID(_TestAppointmentID);

                if (appointment != null && appointment.IsLocked)
                {
                    this.Text = "View Test Appointment";
                }
                else
                {
                    this.Text = "Edit Test Appointment";
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
