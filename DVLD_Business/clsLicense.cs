using DVLD_DataAccess;
using System;
using System.Data;
using static DVLD_Business.clsApplication;

namespace DVLD_Business
{
    public class clsLicense
    {
        public enum enIssueReason
        {
            FirstTime = 1,
            Renew = 2,
            ReplacementForLost = 3,
            ReplacementForDamaged = 4
        }

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int LicenseID { get; set; }

        public int ApplicationID { get; set; }

        public int DriverID { get; set; }

        private clsDriver _DriverInfo;
        public clsDriver DriverInfo
        {
            get
            {
                if (_DriverInfo == null)
                    _DriverInfo = clsDriver.FindByDriverID(DriverID);

                return _DriverInfo;
            }
        }

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

        public DateTime IssueDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public clsLicense.enIssueReason IssueReason { get; set; }

        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }

        public float PaidFees { get; set; }

        public bool IsActive { get; set; }

        public string Notes { get; set; }

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


        //private clsDetainedLicense _DetainedInfo;

        //public clsDetainedLicense DetainedInfo
        //{
        //    get
        //    {
        //        if (_DetainedInfo == null)
        //            _DetainedInfo = clsDetainedLicense.FindByLicenseID(this.LicenseID);

        //        return _DetainedInfo;
        //    }
        //}

        //public bool IsDetained
        //{
        //    get
        //    {
        //        return clsDetainedLicense.IsLicenseDetained(this.LicenseID);
        //    }
        //}

        public bool IsLicenseExpired
        {
            get
            {
                return DateTime.Now > ExpirationDate;
            }
        }

        public clsLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;

            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.MinValue;

            IssueReason = enIssueReason.FirstTime;
            PaidFees = 0;

            IsActive = true;
            Notes = "";

            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsLicense(
            int LicenseID,
            int ApplicationID,
            int DriverID,
            int LicenseClassID,
            DateTime IssueDate,
            DateTime ExpirationDate,
            clsLicense.enIssueReason IssueReason,
            float PaidFees,
            bool IsActive,
            string Notes,
            int CreatedByUserID)
        {

            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClassID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IssueReason = IssueReason;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        public static clsLicense FindByLicenseID(int LicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int LicenseClassID = -1;

            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.MinValue;

            byte IssueReason = 1;
            float PaidFees = 0;

            bool IsActive = false;
            string Notes = "";

            int CreatedByUserID = -1;

            if (clsLicenseDataAccess.GetLicenseInfoByID(
                LicenseID,
                ref ApplicationID,
                ref DriverID,
                ref LicenseClassID,
                ref IssueDate,
                ref ExpirationDate,
                ref IssueReason,
                ref PaidFees,
                ref IsActive,
                ref Notes,
                ref CreatedByUserID))
            {

                return new clsLicense(
                    LicenseID,
                    ApplicationID,
                    DriverID,
                    LicenseClassID,
                    IssueDate,
                    ExpirationDate,
                    (clsLicense.enIssueReason)IssueReason,
                    PaidFees,
                    IsActive,
                    Notes,
                    CreatedByUserID);
            }
            return null;
        }

        public static clsLicense FindByApplicationID(int ApplicationID)
        {
            int LicenseID = -1;
            int DriverID = -1;
            int LicenseClassID = -1;

            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.MinValue;

            byte IssueReason = 1;
            float PaidFees = 0;

            bool IsActive = false;
            string Notes = "";

            int CreatedByUserID = -1;

            if (clsLicenseDataAccess.GetLicenseInfoByApplicationID(
                ApplicationID,
                ref LicenseID,
                ref DriverID,
                ref LicenseClassID,
                ref IssueDate,
                ref ExpirationDate,
                ref IssueReason,
                ref PaidFees,
                ref IsActive,
                ref Notes,
                ref CreatedByUserID))
            {

                return new clsLicense(
                    LicenseID,
                    ApplicationID,
                    DriverID,
                    LicenseClassID,
                    IssueDate,
                    ExpirationDate,
                    (clsLicense.enIssueReason)IssueReason,
                    PaidFees,
                    IsActive,
                    Notes,
                    CreatedByUserID);
            }
            return null;
        }

        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicenseDataAccess.AddNewLicense(
                this.ApplicationID,
                this.DriverID,
                this.LicenseClassID,
                this.IssueDate,
                this.ExpirationDate,
                (byte)this.IssueReason,
                this.PaidFees,
                this.IsActive,
                this.Notes,
                this.CreatedByUserID);

            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            return clsLicenseDataAccess.UpdateLicense(
                this.LicenseID,
                this.ApplicationID,
                this.DriverID,
                this.LicenseClassID,
                this.IssueDate,
                this.ExpirationDate,
                (byte)this.IssueReason,
                this.PaidFees,
                this.IsActive,
                this.Notes,
                this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateLicense();
            }
            return false;
        }

        public static bool Delete(int LicenseID)
        {
            return clsLicenseDataAccess.DeleteLicense(LicenseID);
        }

        public static DataTable GetAllLicenses()
        {
            return clsLicenseDataAccess.GetAllLicenses();
        }

        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicenseDataAccess.GetDriverLicenses(DriverID);
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            return clsLicenseDataAccess.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);
        }

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return clsLicenseDataAccess.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1;
        }

        public bool DeactivateCurrentLicense()
        {
            return clsLicenseDataAccess.DeactivateLicense(this.LicenseID);
        }

        public static string GetIssueReasonText(clsLicense.enIssueReason IssueReason)
        {
            switch(IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";

                case enIssueReason.Renew:
                    return "Renew";

                case enIssueReason.ReplacementForLost:
                    return "Replacement For Lost";

                case enIssueReason.ReplacementForDamaged:
                    return "Replacement For Damaged";

                default:
                    return "First Time";
            }
        }

        //public int Detain(float FineFees, int CreatedByUserID)
        //{
        //    clsDetainedLicense detainedLicense = new clsDetainedLicense();

        //    detainedLicense.LicenseID = this.LicenseID;
        //    detainedLicense.DetainDate = DateTime.Now;
        //    detainedLicense.FineFees = Convert.ToSingle(FineFees);
        //    detainedLicense.CreatedByUserID = CreatedByUserID;

        //    if(!detainedLicense.Save())
        //    {
        //        return -1;
        //    }
        //    return detainedLicense.DetainID;
        //}

        //public bool ReleaseDetainedLicense(int ReleasedByUserID, ref int ApplicationID)
        //{
        //    clsApplication Application = new clsApplication();

        //    Application.ApplicantPersonID = this.DriverInfo.PersonID;

        //    //Application.ApplicationDate = ApplicationDate;
        //    //Application.LastStatusDate = LastStatusDate;

        //    Application.ApplicationTypeID =
        //        (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense;

        //    Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;

        //    Application.PaidFees = clsApplication.FindBaseApplication(
        //        (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense).PaidFees;

        //    Application.CreatedByUserID = ReleasedByUserID;

        //    if(!Application.Save())
        //    {
        //        ApplicationID = -1;
        //        return false;
        //    }

        //    ApplicationID = Application.ApplicationID;

        //    return DetainedInfo.ReleaseDetainedLicense(
        //        ReleasedByUserID,
        //        Application.ApplicationID);
        //}

        public clsLicense RenewLicense(string Notes, int CreatedByUserID)
        {
            if (!this.IsLicenseExpired)
                return null;

            if (!this.IsActive)
                return null;

            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;

            //Application.ApplicationDate = ApplicationDate;
            //Application.LastStatusDate = LastStatusDate;

            Application.ApplicationTypeID =
                (int)clsApplication.enApplicationType.RenewDrivingLicense;

            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;

            Application.PaidFees = clsApplicationType.Find(
                (int)clsApplication.enApplicationType.RenewDrivingLicense).ApplicationTypeFees;

            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;

            int DefaultValidityLength = (int)LicenseClassInfo.DefaultValidityLength;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);

            NewLicense.IssueReason = clsLicense.enIssueReason.Renew;
            NewLicense.PaidFees = LicenseClassInfo.ClassFees;

            NewLicense.IsActive = true;
            NewLicense.Notes = Notes;

            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save())
            {
                return null;
            }

            DeactivateCurrentLicense();
            return NewLicense;
        }

        public clsLicense Replace(clsLicense.enIssueReason IssueReason, int CreatedByUserID)
        {
            if (IssueReason == enIssueReason.FirstTime || IssueReason == enIssueReason.Renew)
            {
                return null;
            }

            if (this.IsLicenseExpired)
            {
                return this.RenewLicense("", CreatedByUserID);
            }

            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;

            //Application.ApplicationDate = ApplicationDate;
            //Application.LastStatusDate = LastStatusDate;

            Application.ApplicationTypeID =
               IssueReason == clsLicense.enIssueReason.ReplacementForDamaged
               ? (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense
               : (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;

            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;

            Application.PaidFees =
                clsApplicationType.Find(Application.ApplicationTypeID).ApplicationTypeFees;

            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.IssueReason = IssueReason;
            NewLicense.PaidFees = 0;
            NewLicense.IsActive = true;
            NewLicense.Notes = this.Notes;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save())
            {
                return null;
            }

            DeactivateCurrentLicense();
            return NewLicense;
        }
    }
}