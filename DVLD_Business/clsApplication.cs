using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsApplication
    {
        protected enum enMode { AddNew = 0, Update = 1 };
        protected enMode Mode = enMode.AddNew;

        public enum enApplicationType
        {
            NewDrivingLicense = 1,
            RenewDrivingLicense = 2,
            ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4,
            ReleaseDetainedDrivingLicense = 5,
            NewInternationalLicense = 6,
            RetakeTest = 7
        };

        public enum enApplicationStatus
        {
            New = 1,
            Cancelled = 2,
            Completed = 3
        };

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }

        private clsPerson _PersonInfo;
        public clsPerson PersonInfo
        {
            get
            {
                if (_PersonInfo == null)
                    _PersonInfo = clsPerson.Find(ApplicantPersonID);

                return _PersonInfo;
            }
        }
        public string ApplicantFullName
        {
            get { return PersonInfo?.FullName ?? ""; }
        }

        public DateTime ApplicationDate { get; protected set; }
        public int ApplicationTypeID { get; set; }


        private clsApplicationType _ApplicationTypeInfo;
        public clsApplicationType ApplicationTypeInfo
        {
            get
            {
                if (_ApplicationTypeInfo == null)
                    _ApplicationTypeInfo = clsApplicationType.Find(ApplicationTypeID);

                return _ApplicationTypeInfo;
            }
        }

        public enApplicationStatus ApplicationStatus { get; set; }
        public string StatusText
        {
            get { return ApplicationStatus.ToString(); }
        }

        public DateTime LastStatusDate { get; protected set; }
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

        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        protected clsApplication(
            int ApplicationID,
            int ApplicantPersonID,
            DateTime ApplicationDate,
            int ApplicationTypeID,
            enApplicationStatus ApplicationStatus,
            DateTime LastStatusDate,
            float PaidFees,
            int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;

            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;

            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        public static clsApplication FindBaseApplication(int ApplicationID)
        {
            int ApplicantPersonID = -1,
                ApplicationTypeID = -1,
                CreatedByUserID = -1;

            byte ApplicationStatus = 1;
            float PaidFees = 0;

            DateTime ApplicationDate = DateTime.Now,
                     LastStatusDate = DateTime.Now;

            if (clsApplicationDataAccess.GetApplicationByID(
                ApplicationID,
                ref ApplicantPersonID,
                ref ApplicationDate,
                ref ApplicationTypeID,
                ref ApplicationStatus,
                ref LastStatusDate,
                ref PaidFees,
                ref CreatedByUserID))
            {
                return new clsApplication(
                    ApplicationID,
                    ApplicantPersonID,
                    ApplicationDate,
                    ApplicationTypeID,
                   (enApplicationStatus)ApplicationStatus,
                    LastStatusDate,
                    PaidFees,
                    CreatedByUserID);
            }
            else
                return null;
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationDataAccess.AddNewApplication(
                this.ApplicantPersonID,
                this.ApplicationDate,
                this.ApplicationTypeID,
                (byte)this.ApplicationStatus,
                this.LastStatusDate,
                this.PaidFees,
                this.CreatedByUserID);

            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplication()
        {
            return clsApplicationDataAccess.UpdateApplication(
                this.ApplicationID,
                this.ApplicantPersonID,
                this.ApplicationDate,
                this.ApplicationTypeID,
                (byte)this.ApplicationStatus,
                this.LastStatusDate,
                this.PaidFees,
                this.CreatedByUserID);
        }

        public virtual bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateApplication();
            }
            return false;
        }

        public bool Cancel()
        {
            if (ApplicationStatus != enApplicationStatus.New)
                return false;

            if (clsApplicationDataAccess.UpdateStatus(
                ApplicationID,
                (byte)enApplicationStatus.Cancelled))
            {
                ApplicationStatus = enApplicationStatus.Cancelled;
                LastStatusDate = DateTime.Now;
                return true;
            }

            return false;
        }

        public bool SetComplete()
        {
            if (clsApplicationDataAccess.UpdateStatus(
                ApplicationID,
                (byte)enApplicationStatus.Completed))
            {
                ApplicationStatus = enApplicationStatus.Completed;
                LastStatusDate = DateTime.Now;
                return true;
            }

            return false;
        }

        public bool UpdateStatus(clsApplication.enApplicationStatus NewStatus)
        {
            if (clsApplicationDataAccess.UpdateStatus(this.ApplicationID, (byte)NewStatus))
            {
                ApplicationStatus = NewStatus;
                LastStatusDate = DateTime.Now;
                return true;
            }

            return false;
        }

        public bool DeleteApplication()
        {
            return clsApplicationDataAccess.DeleteApplication(this.ApplicationID);
        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            return clsApplicationDataAccess.IsApplicationExist(ApplicationID);
        }

        public static DataTable GetAllApplication()
        {
            return clsApplicationDataAccess.GetAllApplications();
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return clsApplicationDataAccess.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }

        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID)
        {
            return clsApplicationDataAccess.DoesPersonHaveActiveApplication(this.ApplicantPersonID, ApplicationTypeID);
        }

        public static int GetActiveApplicationID(
            int PersonID,
            clsApplication.enApplicationType ApplicationTypeID)
        {
            return clsApplicationDataAccess.GetActiveApplicationID(
                PersonID,
                (int)ApplicationTypeID);
        }

        public static int GetActiveApplicationID(
            int PersonID,
            clsApplication.enApplicationType ApplicationTypeID,
            int LicenseClassID)
        {
            return clsApplicationDataAccess.GetActiveApplicationIDForLicenseClass(
                PersonID,
                (int)ApplicationTypeID,
                LicenseClassID);
        }

        public int GetActiveApplicationID(clsApplication.enApplicationType ApplicationTypeID)
        {
            return clsApplicationDataAccess.GetActiveApplicationID(this.ApplicantPersonID, (int)ApplicationTypeID);
        }
    }
}
