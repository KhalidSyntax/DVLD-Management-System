using System; 
using DVLD.Classes;
using DVLD_Business;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmTakeTest : Form
    {
        private clsTest _Test;
        private clsTestAppointment _TestAppointment;

        private int _TestAppointmentID = -1;
        private int _TestID = -1;

        private clsTestType.enTestType _TestTypeID;

        public frmTakeTest(int TestAppointmentID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            _TestAppointmentID = TestAppointmentID;
            _TestTypeID = TestTypeID;
        }

        private void _LoadScheduledTest()
        {
            _TestAppointment = clsTestAppointment.FindByTestAppointmentID(_TestAppointmentID);

            ctrlScheduledTest1.LoadTestAppointmentInfo(_TestAppointmentID);
            btnSave.Enabled = (ctrlScheduledTest1.TestAppointmentID != -1); 
        }

        private void _LoadTestIfExists()
        {
            _TestID = ctrlScheduledTest1.TestID;

            if (_TestID == -1)
            {
                _Test = new clsTest();
                return;
            }

            _Test = clsTest.Find(_TestID);
            _FillTestInfo();
            _DisableTestControls();
        }

        private void _FillTestInfo()
        {
            if (_Test.TestResult)
                rbPass.Checked = true;
            else
                rbFail.Checked = true;

            txtNotes.Text = _Test.Notes;
        }

        private void _DisableTestControls()
        {
            lblMessage.Visible = true;

            rbPass.Enabled = false;
            rbFail.Enabled = false;
        }

        private void _LockForm()
        {
            btnSave.Enabled = false;
            rbPass.Enabled = false;
            rbFail.Enabled = false;
            txtNotes.ReadOnly = true;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _LoadScheduledTest();
            _LoadTestIfExists();

            if (_Test != null && _Test.TestID != -1 &&
                _TestAppointment != null &&
                _TestAppointment.IsLocked)
                _LockForm();
        }

        private bool _ConfirmSave()
        {
            return MessageBox.Show(
                "Are you sure you want to save? After that you cannot change the Pass/Fail results after you save.",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes;
        }

        private void _PrepareTestData()
        {
            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = txtNotes.Text.Trim();
            _Test.CreatedByUserID = clsGlobal.currentUser.UserID;
        }

        private void _SaveTest()
        {
            if (_Test.Save())
            {
                ctrlScheduledTest1.LoadTestAppointmentInfo(_TestAppointmentID);
                _LockForm();

                MessageBox.Show(
                    "Data Saved Successfully.",
                    "Saved",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_ConfirmSave())
                return;

            _PrepareTestData();
            _SaveTest();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}