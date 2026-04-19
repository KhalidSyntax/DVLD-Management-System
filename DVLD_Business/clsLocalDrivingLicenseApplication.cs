using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        private clsLicenseClass _LicenseClassInfo;
        public clsLicenseClass LicenseClassInfo
        {
            get
            {
                if (_LicenseClassInfo == null)
                    _LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);

                return _LicenseClassInfo;
            }
        }

        public string PersonFullName
        {
            get { return base.PersonInfo?.FullName ?? "N/A"; }
        }

        public clsLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;

            Mode = enMode.AddNew;
        }

        private clsLocalDrivingLicenseApplication(
            int LocalDrivingLicenseApplicationID,
            int ApplicationID,
            int ApplicantPersonID,
            DateTime ApplicationDate,
            int ApplicationTypeID,
            enApplicationStatus ApplicationStatus,
            DateTime LastStatusDate,
            float PaidFees,
            int CreatedByUserID,
            int LicenseClasseID)

            : base(
            ApplicationID,
            ApplicantPersonID,
            ApplicationDate,
            ApplicationTypeID,
            ApplicationStatus,
            LastStatusDate,
            PaidFees,
            CreatedByUserID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LicenseClassID = LicenseClasseID;

            Mode = enMode.Update;
        }

        public static clsLocalDrivingLicenseApplication FindByLocalDrivingAppLicenseID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1, LicenseClasseID = -1;

            if (clsLocalDrivingLicenseApplicationDataAccess.GetLocalDrivingLicenseApplicationInfoByID(
                LocalDrivingLicenseApplicationID,
                ref ApplicationID,
                ref LicenseClasseID))
            {
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                return new clsLocalDrivingLicenseApplication(
                        LocalDrivingLicenseApplicationID,
                        Application.ApplicationID,
                        Application.ApplicantPersonID,
                        Application.ApplicationDate,
                        Application.ApplicationTypeID,
                        Application.ApplicationStatus,
                        Application.LastStatusDate,
                        Application.PaidFees,
                        Application.CreatedByUserID,
                        LicenseClasseID);
            }
            else
                return null;
        }

        public static clsLocalDrivingLicenseApplication FindByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = -1, LicenseClasseID = -1;

            if (clsLocalDrivingLicenseApplicationDataAccess.GetLocalDrivingLicenseApplicationInfoByApplicationID(
                ApplicationID,
                ref LocalDrivingLicenseApplicationID,
                ref LicenseClasseID))
            {
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                return new clsLocalDrivingLicenseApplication(
                        LocalDrivingLicenseApplicationID,
                        Application.ApplicationID,
                        Application.ApplicantPersonID,
                        Application.ApplicationDate,
                        Application.ApplicationTypeID,
                        Application.ApplicationStatus,
                        Application.LastStatusDate,
                        Application.PaidFees,
                        Application.CreatedByUserID,
                        LicenseClasseID);
            }
            else
                return null;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationDataAccess.AddNewLocalDrivingLicenseApplication(
                this.ApplicationID,
                this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationDataAccess.UpdateLocalDrivingLicenseApplication(
                this.LocalDrivingLicenseApplicationID,
                this.ApplicationID,
                this.LicenseClassID);
        }

        public bool IsApplicantOldEnough()
        {
            if (PersonInfo == null)
                return false;

            int age = DateTime.Now.Year - PersonInfo.DateOfBirth.Year;

            if (PersonInfo.DateOfBirth > DateTime.Now.AddYears(-age))
                age--;

            int minimumAge = LicenseClassInfo.MinimumAllowedAge;

            return age >= minimumAge;
        }

        public override bool Save()
        {
            if (!IsApplicantOldEnough())
                return false;

            bool isNew = (Mode == enMode.AddNew);

            if (!base.Save())
                return false;

            if(isNew)
            {
                if (_AddNewLocalDrivingLicenseApplication())
                {
                    Mode = enMode.Update;
                    return true;
                }
                return false;
            }

            return _UpdateLocalDrivingLicenseApplication();
        }

        public bool Delete()
        {
            bool IsLocalDrivingApplicationDeleted = clsLocalDrivingLicenseApplicationDataAccess.DeleteLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID);
            if (!IsLocalDrivingApplicationDeleted)
                return false;

            bool IsBaseApplicationDeleted = base.DeleteApplication();
                return IsBaseApplicationDeleted;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationDataAccess.GetAllLocalDrivingLicenseApplications();
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.DoesPassTestType(
                LocalDrivingLicenseApplicationID,
                (int)TestTypeID);
        }

        public bool DoesPassTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.DoesPassTestType(
                this.LocalDrivingLicenseApplicationID,
                (int)TestTypeID);
        }

        public bool DoesPassPreviousTest(clsTestType.enTestType CurrentTestType)
        {
            switch(CurrentTestType)
            {
                case clsTestType.enTestType.VisionTest:
                    return true;

                case clsTestType.enTestType.WrittenTest:
                    return this.DoesPassTestType(clsTestType.enTestType.VisionTest);

                case clsTestType.enTestType.StreetTest:
                    return this.DoesPassTestType(clsTestType.enTestType.WrittenTest);

                default:
                    return false;
            }
        }

        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.DoesAttendTestType(
                LocalDrivingLicenseApplicationID,
                (int)TestTypeID);
        }

        public bool DoesAttendTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.DoesAttendTestType(
                this.LocalDrivingLicenseApplicationID,
                (int)TestTypeID);
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.TotalTrialsPerTest(
                LocalDrivingLicenseApplicationID,
                (int)TestTypeID);
        }

        public byte TotalTrialsPerTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.TotalTrialsPerTest(
                this.LocalDrivingLicenseApplicationID,
                (int)TestTypeID);
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.IsThereAnActiveScheduledTest(
                LocalDrivingLicenseApplicationID,
                (int)TestTypeID);
        }

        public bool IsThereAnActiveScheduledTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.IsThereAnActiveScheduledTest(
                this.LocalDrivingLicenseApplicationID,
                (int)TestTypeID);
        }

        public static DateTime GetLastTestAppointmentDate(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationDataAccess.GetLastTestAppointmentDate(
                LocalDrivingLicenseApplicationID,
                (int)TestTypeID);
        }

        // Later Explain

        //public clsTest GetLastTestPerTestType(clsTestType.enTestType TestTypeID)
        //{
        //    return clsTest.FindLastTestPerPersonAndLicenseClass(
        //        this.ApplicantPersonID,
        //        this.LicenseClassID,
        //        TestTypeID);
        //}

        //public byte GetPassedTestCount()
        //{
        //    return clsTest.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        //}

        //public bool PassedAllTests()
        //{
        //    return clsTest.PassedAllTests(this.LocalDrivingLicenseApplicationID);
        //}

        //public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        //{
        //    return clsTest.PassedAllTests(LocalDrivingLicenseApplicationID);
        //}

        //public int IssueLicenseForTheFirstTime(string Notes, int CreatedByUserID)
        //{
        //    int DriverID = -1;

        //    clsDriver Driver = clsDriver.FindByPersonID(this.ApplicantPersonID);

        //    if(Driver == null)
        //    {
        //        Driver = new clsDriver();
        //        Driver.PersonID = this.ApplicantPersonID;
        //        Driver.CreatedByUserID = CreatedByUserID;

        //        if (Driver.Save())
        //            DriverID = Driver.DriverID;
        //        else
        //            return -1;
        //    }
        //    else
        //    {
        //        DriverID = Driver.DriverID;
        //    }

        //    clsLicense License = new clsLicense();

        //    License.ApplicationID = this.ApplicationID;
        //    License.DriverID = DriverID;
        //    License.LicenseClass = this.LicenseClassID;
        //    License.IssueDate = DateTime.Now;
        //    License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
        //    License.Notes = Notes;
        //    License.PaidFees = this.LicenseClassInfo.ClassFees;
        //    License.IsActive = true;
        //    License.IssueReason = clsLicense.enIssueReason.FirstTime;
        //    License.CreatedByUserID = CreatedByUserID;

        //    if (License.Save())
        //    {
        //        this.SetComplete();
        //        return License.LicenseID;
        //    }
        //    else
        //        return -1;
        //}

        //public bool IsLicenseIssued()
        //{
        //    return (GetActiveLicenseID() != -1);
        //}

        //public int GetActiveLicenseID()
        //{
        //    return clsLicense.GetActiveLicenseIDByPersonID(
        //        this.ApplicantPersonID,
        //        this.LicenseClassID);
        //}

    }
}
