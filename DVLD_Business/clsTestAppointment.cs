using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class clsTestAppointment
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestAppointmentID { get; set; }
        public clsTestType.enTestType TestTypeID { get; set; }

        private clsTestType _TestTypeIDInfo;
        public clsTestType TestTypeIDInfo
        {
            get
            {
                if (_TestTypeIDInfo == null)
                    _TestTypeIDInfo = clsTestType.Find((clsTestType.enTestType)TestTypeID);

                return _TestTypeIDInfo;
            }
        }

        public int LocalDrivingLicenseApplicationID { get; set; }
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplicationInfo;
        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplicationInfo
        {
            get
            {
                if (_LocalDrivingLicenseApplicationInfo == null)
                    _LocalDrivingLicenseApplicationInfo =
                        clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(
                            LocalDrivingLicenseApplicationID);

                return _LocalDrivingLicenseApplicationInfo;
            }
        }


        public DateTime TestAppointmentDate { get; set; }
        public float PaidFees { get; set; }

        public int CreatedByUserID { get; set; }
        private clsUser _CreatedByUserInfo;
        public clsUser CreatedByUserInfo
        {
            get
            {
                if (_CreatedByUserInfo == null)
                    _CreatedByUserInfo = clsUser.FindByUserID(CreatedByUserID);

                return _CreatedByUserInfo;
            }
        }

        public int RetakeTestApplicationID { get; set; }
        private clsApplication _RetakeTestApplicationInfo;
        public clsApplication RetakeTestApplicationInfo
        {
            get
            {
                if (_RetakeTestApplicationInfo == null)
                    _RetakeTestApplicationInfo = clsApplication.FindBaseApplication(
                        RetakeTestApplicationID);

                return _RetakeTestApplicationInfo;
            }
        }

        public bool IsLocked { get; set; }

        public int TestID
        {
            get { return _GetTestID(); }
        }

        public clsTestAppointment()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = clsTestType.enTestType.VisionTest;
            this.LocalDrivingLicenseApplicationID = -1;
            this.TestAppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.RetakeTestApplicationID = -1;
            this.IsLocked = false;

            Mode = enMode.AddNew;
        }

        private clsTestAppointment(
            int TestAppointmentID,
            clsTestType.enTestType TestTypeID,
            int LocalDrivingLicenseApplicationID,
            DateTime TestAppointmentDate,
            float PaidFees,
            int CreatedByUserID,
            int RetakeTestApplicationID,
            bool IsLocked)

        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.TestAppointmentDate = TestAppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.IsLocked = IsLocked;

            Mode = enMode.Update;
        }

        public static clsTestAppointment FindByTestAppointmentID(int TestAppointmentID)
        {
            int TestTypeID = -1,
            LocalDrivingLicenseApplicationID = -1,
            CreatedByUserID = -1,
            RetakeTestApplicationID = -1;

            DateTime TestAppointmentDate = DateTime.Now;
            float PaidFees = 0;
            bool IsLocked = false;

            if (clsTestAppointmentDataAccess.GetTestAppointmentByID(
                        TestAppointmentID,
                        ref TestTypeID,
                        ref LocalDrivingLicenseApplicationID,
                        ref TestAppointmentDate,
                        ref PaidFees,
                        ref CreatedByUserID,
                        ref RetakeTestApplicationID,
                        ref IsLocked))
            {
                return new clsTestAppointment(
                        TestAppointmentID,
                        (clsTestType.enTestType)TestTypeID,
                        LocalDrivingLicenseApplicationID,
                        TestAppointmentDate,
                        PaidFees,
                        CreatedByUserID,
                        RetakeTestApplicationID,
                        IsLocked);
            }
            else
                return null;
        }

        public static clsTestAppointment GetLastTestAppointment(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            int TestAppointmentID = -1,
            CreatedByUserID = -1,
            RetakeTestApplicationID = -1;

            DateTime TestAppointmentDate = DateTime.Now;
            float PaidFees = 0;
            bool IsLocked = false;

            if (clsTestAppointmentDataAccess.GetLastTestAppointment(
                        LocalDrivingLicenseApplicationID,
                        (int)TestTypeID,
                        ref TestAppointmentID,
                        ref TestAppointmentDate,
                        ref PaidFees,
                        ref CreatedByUserID,
                        ref RetakeTestApplicationID,
                        ref IsLocked))
            {
                return new clsTestAppointment(
                        TestAppointmentID,
                        TestTypeID,
                        LocalDrivingLicenseApplicationID,
                        TestAppointmentDate,
                        PaidFees,
                        CreatedByUserID,
                        RetakeTestApplicationID,
                        IsLocked);
            }
            else
                return null;
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID =
            clsTestAppointmentDataAccess.AddNewTestAppointment(
                (int)this.TestTypeID,
                this.LocalDrivingLicenseApplicationID,
                this.TestAppointmentDate,
                this.PaidFees,
                this.CreatedByUserID,
                this.RetakeTestApplicationID,
                this.IsLocked);

            return (this.TestAppointmentID != -1);
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentDataAccess.UpdateTestAppointment(
                this.TestAppointmentID,
                (int)this.TestTypeID,
                this.LocalDrivingLicenseApplicationID,
                this.TestAppointmentDate,
                this.PaidFees,
                this.CreatedByUserID,
                this.RetakeTestApplicationID,
                this.IsLocked);
        }

        public  bool Save()
        {
            if (Mode == enMode.AddNew)
            {
                if (_AddNewTestAppointment())
                {
                    Mode = enMode.Update;
                    return true;
                }
                return false;
            }
            return _UpdateTestAppointment();
        }

        public static bool Delete(int TestAppointmentID)
        {
            return clsTestAppointmentDataAccess.DeleteTestAppointment(TestAppointmentID);
        }

        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentDataAccess.GetAllTestAppointments();
        }

        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentDataAccess.
                GetApplicationTestAppointmentsPerTestType(
                LocalDrivingLicenseApplicationID,
                (int)TestTypeID);
        }

        public DataTable GetApplicationTestAppointmentsPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentDataAccess.
                GetApplicationTestAppointmentsPerTestType(
                this.LocalDrivingLicenseApplicationID,
                (int)TestTypeID);
        }

        private int _GetTestID()
        {
            return clsTestAppointmentDataAccess.
                GetTestID(this.TestAppointmentID);
        }
    }
}
