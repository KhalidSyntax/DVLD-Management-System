using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsInternationalLicense : clsApplication
    {
        public int InternationalLicenseID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }

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

        public clsInternationalLicense()
        {
            this.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;

            InternationalLicenseID = -1;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            CreatedByUserID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = false;

           Mode = enMode.AddNew;
        }

        private clsInternationalLicense(
            int InternationalLicenseID,
            int ApplicationID,
            int ApplicantPersonID,
            DateTime ApplicationDate,
            int ApplicationTypeID,
            enApplicationStatus ApplicationStatus,
            DateTime LastStatusDate,
            float PaidFees,
            int CreatedByUserID,
            int DriverID,
            int IssuedUsingLocalLicenseID,
            DateTime IssueDate,
            DateTime ExpirationDate,
            bool IsActive)
        {
            base.ApplicationID = ApplicationID;
            base.ApplicantPersonID = ApplicantPersonID;
            base.ApplicationDate = ApplicationDate;
            base.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;
            base.ApplicationStatus = ApplicationStatus;
            base.LastStatusDate = LastStatusDate;
            base.PaidFees = PaidFees;
            base.CreatedByUserID = CreatedByUserID;

            this.InternationalLicenseID = InternationalLicenseID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }

        public static clsInternationalLicense FindByInternationalLicenseID(int InternationalLicenseID)
        {
            int ApplicationID = -1,
            DriverID = -1,
            IssuedUsingLocalLicenseID = -1,
            CreatedByUserID = -1;

            DateTime IssueDate = DateTime.Now,
            ExpirationDate = DateTime.Now;

            bool IsActive = false;

            if (clsInternationalLicenseDataAccess.GetInternationalLicenseInfoByID(
                InternationalLicenseID,
                ref ApplicationID,
                ref DriverID,
                ref IssuedUsingLocalLicenseID,
                ref CreatedByUserID,
                ref IssueDate, ref ExpirationDate, ref IsActive))
            {
                clsApplication Application = clsApplication.Find(ApplicationID);

                return new clsInternationalLicense(
                        InternationalLicenseID,
                        Application.ApplicationID,
                        Application.ApplicantPersonID,
                        Application.ApplicationDate,
                        Application.ApplicationTypeID,
                        (enApplicationStatus)Application.ApplicationStatus,
                        Application.LastStatusDate,
                        Application.PaidFees,
                        Application.CreatedByUserID,
                        DriverID,
                        IssuedUsingLocalLicenseID,
                        IssueDate,
                        ExpirationDate,
                        IsActive);
            }
            else
                return null;
        }

        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID =
                clsInternationalLicenseDataAccess.AddNewInternationalLicense(
                this.ApplicationID,
                this.DriverID,
                this.IssuedUsingLocalLicenseID,
                this.CreatedByUserID,
                this.IssueDate,
                this.ExpirationDate,
                this.IsActive);

            return (this.InternationalLicenseID != -1);
        }

        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicenseDataAccess.UpdateInternationalLicense(
                this.InternationalLicenseID,
                this.ApplicationID,
                this.DriverID,
                this.IssuedUsingLocalLicenseID,
                this.CreatedByUserID,
                this.IssueDate,
                this.ExpirationDate,
                this.IsActive);
        }

        public override bool Save()
        {
            bool isNew = (Mode == enMode.AddNew);

            if (!base.Save())
                return false;

            if (isNew)
            {
                if (_AddNewInternationalLicense())
                {
                    Mode = enMode.Update;
                    return true;
                }
                return false;
            }

            return _UpdateInternationalLicense();
        }

        public bool Delete()
        {
            bool IsInternationalLicenseDeleted =
                clsInternationalLicenseDataAccess.DeleteInternationalLicense(this.InternationalLicenseID);
            if (!IsInternationalLicenseDeleted)
                return false;

            bool IsBaseApplicationDeleted = base.DeleteApplication();
            return IsBaseApplicationDeleted;
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseDataAccess.GetAllInternationalLicenses();
        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return clsInternationalLicenseDataAccess.GetDriverInternationalLicenses(DriverID);
        }

        public static int GetActiveInternationalLicenseByDriverID(int DriverID)
        {
            return clsInternationalLicenseDataAccess.
                GetActiveInternationalLicenseByDriverID(DriverID);
        }
    }
}
