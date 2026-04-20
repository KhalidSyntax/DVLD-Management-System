using System;
using DVLD_DataAccess;
using System.Data;

namespace DVLD_Business
{
    public class clsTest
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestID { get; set; }

        public int TestAppointmentID { get; set; }

        private clsTestAppointment _TestAppointmentInfo;
        public clsTestAppointment TestAppointmentInfo
        {
            get
            {
                if (_TestAppointmentInfo == null)
                    _TestAppointmentInfo =
                        clsTestAppointment.FindByTestAppointmentID(TestAppointmentID);

                return _TestAppointmentInfo;
            }
        }

        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTest()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsTest(
            int TestID,
            int TestAppointmentID,
            bool TestResult,
            string Notes,
            int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        public static clsTest Find(int TestID)
        {
            int TestAppointmentID = -1;
            bool TestResult = false;
            string Notes = "";
            int CreatedByUserID = -1;

            if (clsTestDataAccess.GetTestByID(
                    TestID,
                    ref TestAppointmentID,
                    ref TestResult,
                    ref Notes,
                    ref CreatedByUserID))
            {
                return new clsTest(
                    TestID,
                    TestAppointmentID,
                    TestResult,
                    Notes,
                    CreatedByUserID);
            }

            return null;
        }

        public static clsTest FindLastTestPerPersonAndLicenseClass(
            int ApplicantPersonID,
            int LicenseClassID,
            clsTestType.enTestType TestTypeID)
        {
            int TestID = -1;
            int TestAppointmentID = -1;
            bool TestResult = false;
            string Notes = "";
            int CreatedByUserID = -1;

            if (clsTestDataAccess.GetLastTestByPersonAndTestTypeAndLicenseClass(
                    ApplicantPersonID,
                    LicenseClassID,
                    (int)TestTypeID,
                    ref TestID,
                    ref TestAppointmentID,
                    ref TestResult,
                    ref Notes,
                    ref CreatedByUserID))
            {
                return new clsTest(
                    TestID,
                    TestAppointmentID,
                    TestResult,
                    Notes,
                    CreatedByUserID);
            }
            return null;
        }

        private bool _AddNewTest()
        {
            this.TestID = clsTestDataAccess.AddNewTest(
                this.TestAppointmentID,
                this.TestResult,
                this.Notes,
                this.CreatedByUserID);

            return (this.TestID != -1);
        }

        private bool _UpdateTest()
        {
            return clsTestDataAccess.UpdateTest(
                this.TestID,
                this.TestAppointmentID,
                this.TestResult,
                this.Notes,
                this.CreatedByUserID);
        }

        public bool Save()
        {
            if (Mode == enMode.AddNew)
            {
                if (_AddNewTest())
                {
                    Mode = enMode.Update;
                    return true;
                }
                return false;
            }

            return _UpdateTest();
        }

        public static bool Delete(int TestID)
        {
            return clsTestDataAccess.DeleteTest(TestID);
        }

        public static DataTable GetAllTests()
        {
            return clsTestDataAccess.GetAllTests();
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestDataAccess.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            return GetPassedTestCount(LocalDrivingLicenseApplicationID) == 3;
        }
    }
}