using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsDriver
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreateDate { get; }

        private clsPerson _PersonInfo;

        public clsPerson PersonInfo
        {
            get
            {
                if (_PersonInfo == null)
                    _PersonInfo = clsPerson.Find(PersonID);

                return _PersonInfo;
            }
        }

        public clsDriver()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreateDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private clsDriver(
            int DriverID,
            int PersonID,
            int CreatedByUserID,
            DateTime CreateDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreateDate = CreateDate;

            Mode = enMode.Update;
        }

        public static clsDriver FindByDriverID(int DriverID)
        {
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreateDate = DateTime.Now;

            if (clsDriverDataAccess.GetDriverInfoByDriverID(
                DriverID,
                ref PersonID,
                ref CreatedByUserID,
                ref CreateDate))
            {
                return new clsDriver(
                    DriverID,
                    PersonID,
                    CreatedByUserID,
                    CreateDate);
            }

            return null;
        }

        public static clsDriver FindByPersonID(int PersonID)
        {
            int DriverID = -1;
            int CreatedByUserID = -1;
            DateTime CreateDate = DateTime.Now;

            if (clsDriverDataAccess.GetDriverInfoByPersonID(
                PersonID,
                ref DriverID,
                ref CreatedByUserID,
                ref CreateDate))
            {
                return new clsDriver(
                    DriverID,
                    PersonID,
                    CreatedByUserID,
                    CreateDate);
            }

            return null;
        }

        private bool _AddNewDriver()
        {
            this.DriverID = clsDriverDataAccess.AddNewDriver(
                this.PersonID,
                this.CreatedByUserID);

            return (this.DriverID != -1);
        }

        private bool _UpdateDriver()
        {
            return clsDriverDataAccess.UpdateDriver(
                this.DriverID,
                this.PersonID,
                this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateDriver();
            }

            return false;
        }

        public static bool Delete(int DriverID)
        {
            return clsDriverDataAccess.DeleteDriver(DriverID);
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriverDataAccess.GetAllDrivers();
        }

        public static bool IsDriverExist(int PersonID)
        {
            return clsDriverDataAccess.IsDriverExist(PersonID);
        }

        public static DataTable GetLicenses(int DriverID)
        {
            return clsLicense.GetDriverLicenses(DriverID);
        }

        public static DataTable GetInternationalLicenses(int DriverID)
        {
            return clsInternationalLicense.GetDriverInternationalLicenses(DriverID);
        }
    }
}