using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsDetainedLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public float FineFees { get; set; }

        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int ReleaseByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }

        private clsUser _ReleasedByUserInfo;

        public clsUser ReleasedByUserInfo
        {
            get
            {
                if (_ReleasedByUserInfo == null)
                    _ReleasedByUserInfo = clsUser.FindByUserID(ReleaseByUserID);

                return _ReleasedByUserInfo;
            }
        }

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

        public clsDetainedLicense()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            FineFees = 0;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = DateTime.Now;
            ReleaseByUserID = -1;
            ReleaseApplicationID = -1;

            Mode = enMode.AddNew;
        }

        private clsDetainedLicense(
            int DetainID,
            int LicenseID,
            DateTime DetainDate,
            float FineFees,
            int CreatedByUserID,
            bool IsReleased,
            DateTime ReleaseDate,
            int ReleaseByUserID,
            int ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleaseByUserID = ReleaseByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;

            Mode = enMode.Update;
        }

        public static clsDetainedLicense FindByDetainID(int DetainID)
        {
            int LicenseID = -1,
            CreatedByUserID = -1,
            ReleaseByUserID = -1,
            ReleaseApplicationID = -1;

            DateTime DetainDate = DateTime.Now,
            ReleaseDate = DateTime.Now;

            float FineFees = 0;
            bool IsReleased = false;

            if (clsDetainedLicenseDataAccess.GetDetainedLicenseByID(
                 DetainID,
                 ref LicenseID,
                 ref DetainDate,
                 ref FineFees,
                 ref CreatedByUserID,
                 ref IsReleased,
                 ref ReleaseDate,
                 ref ReleaseByUserID,
                 ref ReleaseApplicationID)) 
            {
                return new clsDetainedLicense(
                 DetainID,
                 LicenseID,
                 DetainDate,
                 FineFees,
                 CreatedByUserID,
                 IsReleased,
                 ReleaseDate,
                 ReleaseByUserID,
                 ReleaseApplicationID);
            }
            return null;
        }

        public static clsDetainedLicense FindByLicenseID(int LicenseID)
        {
            int DetainID = -1,
            CreatedByUserID = -1,
            ReleaseByUserID = -1,
            ReleaseApplicationID = -1;

            DateTime DetainDate = DateTime.Now,
            ReleaseDate = DateTime.Now;

            float FineFees = 0;
            bool IsReleased = false;

            if (clsDetainedLicenseDataAccess.GetDetainedLicenseInfoByLicenseID(
                 LicenseID,
                 ref DetainID,
                 ref DetainDate,
                 ref FineFees,
                 ref CreatedByUserID,
                 ref IsReleased,
                 ref ReleaseDate,
                 ref ReleaseByUserID,
                 ref ReleaseApplicationID))
            {
                return new clsDetainedLicense(
                 DetainID,
                 LicenseID,
                 DetainDate,
                 FineFees,
                 CreatedByUserID,
                 IsReleased,
                 ReleaseDate,
                 ReleaseByUserID,
                 ReleaseApplicationID);
            }
            return null;
        }

        private bool _AddNewDetainedLicense()
        {
            this.DetainID = clsDetainedLicenseDataAccess.AddNewDetainedLicense(
                this.LicenseID,
                this.DetainDate,
                this.FineFees,
                this.CreatedByUserID);

            return (this.DetainID != -1);
        }

        private bool _UpdateDetainedLicense()
        {
            return clsDetainedLicenseDataAccess.UpdateDetainedLicense(
               this.DetainID,
               this.LicenseID,
               this.DetainDate,
               this.FineFees,
               this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetainedLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateDetainedLicense();
            }
            return false;
        }

        public bool ReleaseDetainedLicense(int ReleaseByUserID, int ReleaseApplicationID)
        {
            return clsDetainedLicenseDataAccess.
                ReleaseDetainedLicense(
                this.DetainID,
                ReleaseByUserID,
                ReleaseApplicationID);
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicenseDataAccess.GetAllDetainedLicenses();
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicenseDataAccess.IsLicenseDetained(LicenseID);
        }
    }
}
