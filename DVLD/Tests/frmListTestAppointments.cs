using DVLD.Properties;
using DVLD_Business;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmListTestAppointments : Form
    {
        private DataTable _dtLicenseTestAppointments;
        private int _LocalDrivingLicenseApplicationID;

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        public frmListTestAppointments(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    pbTestTypeImage.Image = Resources.Vision_512;
                    lblTitle.Text = "Vision Test Appointments";
                    break;

                case clsTestType.enTestType.WrittenTest:
                    pbTestTypeImage.Image = Resources.Written_Test_512;
                    lblTitle.Text = "Written Test Appointments";
                    break;

                case clsTestType.enTestType.StreetTest:
                    pbTestTypeImage.Image = Resources.driving_test_512;
                    lblTitle.Text = "Street Test Appointments";
                    break;
            }
        }

        private void _RefreshTestAppointmentsList()
        {
            _LoadTestTypeImageAndTitle();

            _dtLicenseTestAppointments = clsTestAppointment.
                GetApplicationTestAppointmentsPerTestType(
                _LocalDrivingLicenseApplicationID, _TestTypeID);

            dgvLicenseTestAppointments.DataSource = _dtLicenseTestAppointments;
            lblRecordsCount.Text = dgvLicenseTestAppointments.Rows.Count.ToString();
        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApplicationInfo1.
                LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);

            _RefreshTestAppointmentsList();

            // Header
            dgvLicenseTestAppointments.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 12, FontStyle.Bold);
            dgvLicenseTestAppointments.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

            // Cells
            dgvLicenseTestAppointments.DefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Regular);

            if (dgvLicenseTestAppointments.Rows.Count > 0)
            {
                dgvLicenseTestAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvLicenseTestAppointments.Columns[0].Width = 110;

                dgvLicenseTestAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvLicenseTestAppointments.Columns[1].Width = 220;

                dgvLicenseTestAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvLicenseTestAppointments.Columns[2].Width = 120;

                dgvLicenseTestAppointments.Columns[3].HeaderText = "Is Locked";
                dgvLicenseTestAppointments.Columns[3].Width = 90;
            }
            lblRecordsCount.Text = dgvLicenseTestAppointments.Rows.Count.ToString();
        }

        private void btnAddTestAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(
                    _LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication.
                IsThereAnActiveScheduledTest(_TestTypeID))
            {
                MessageBox.Show(
                "Person Already have an active appointment for this test, You cannot add new appointment",
                "Not allowed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                return;
            }

            //clsTest LastTest = LocalDrivingLicenseApplication.GetLastTestPerTestType(_TestTypeID);

            //if (LastTest == null)
            //{
            //    frmScheduleTest frm = new frmScheduleTest(
            //        _LocalDrivingLicenseApplicationID,
            //        _TestTypeID);

            //    frm.ShowDialog();
            //    _RefreshTestAppointmentsList();

            //    return;
            //}

            //if(LastTest.TestResult == true)
            //{
            //    MessageBox.Show(
            //    "This person already passed this test before, You can only retake failled test",
            //    "Not allowed",
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Error);

            //    return;
            //}

            //frmScheduleTest frm2 = new frmScheduleTest(
            //    LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID,
            //    _TestTypeID);

            //frm2.ShowDialog();
            //_RefreshTestAppointmentsList();
        }

        private void miEdit_Click(object sender, EventArgs e)
        {
            if (dgvLicenseTestAppointments.CurrentRow == null)
                return;

            bool isLocked = Convert.ToBoolean(
                dgvLicenseTestAppointments.CurrentRow.Cells[3].Value
            );

            if (isLocked)
            {
                MessageBox.Show("Locked!");
                return;
            }

            int AppointmentID = ((int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value);

            frmScheduleTest frm = new frmScheduleTest(
                _LocalDrivingLicenseApplicationID,
                _TestTypeID, AppointmentID);

            frm.ShowDialog();
            _RefreshTestAppointmentsList();
        }

        private void mitakeTest_Click(object sender, EventArgs e)
        {
            //int AppointmentID = ((int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value);

            //frmTakeTest frm = new frmTakeTest(
            //    _TestAppointmentID,
            //    _TestTypeID);

            //frm.ShowDialog();
            //_RefreshTestAppointmentsList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}