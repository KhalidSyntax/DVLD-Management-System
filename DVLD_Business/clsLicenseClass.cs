using DVLD_DataAccess;
using System;
using System.ComponentModel;
using System.Data;

namespace DVLD_Business
{
    public class clsLicenseClass
    {
        public enum enLicenseClass
        {
            SmallMotorcycle = 1,
            HeavyMotorcycle = 2,
            OrdinaryDrivingLicense = 3,
            Commercial = 4,
            Agricultural = 5,
            SmallAndMediumBus = 6,
            TruckAndHeavyVehicle = 7
        }

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }

        public clsLicenseClass()
        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 18;
            this.DefaultValidityLength = 10;
            this.ClassFees = 0;

            Mode = enMode.AddNew;
        }

        private clsLicenseClass(
            int LicenseClassID,
            string ClassName,
            string ClassDescription,
            byte MinimumAllowedAge,
            byte DefaultValidityLength,
            float ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;

            Mode = enMode.Update;

        }

        public static clsLicenseClass Find(int LicenseClassID)
        {
            string ClassName = "";
            string ClassDescription = "";
            byte MinimumAllowedAge = 18, DefaultValidityLength = 10;
            float ClassFees = 0;

            if (clsLicenseClassDataAccess.GetLicenseClassInfoByID(
                LicenseClassID,
                ref ClassName,
                ref ClassDescription,
                ref MinimumAllowedAge,
                ref DefaultValidityLength,
                ref ClassFees))
            {
                return new clsLicenseClass(
                    LicenseClassID,
                    ClassName,
                    ClassDescription,
                    MinimumAllowedAge,
                    DefaultValidityLength,
                    ClassFees);
            }
            else
                return null;
        }

        public static clsLicenseClass Find(string ClassName)
        {
            int LicenseClassID = 0;
            string ClassDescription = "";
            byte MinimumAllowedAge = 18, DefaultValidityLength = 10;
            float ClassFees = 0;

            if (clsLicenseClassDataAccess.GetLicenseClassInfoByClassName(
                ClassName,
                ref LicenseClassID,
                ref ClassDescription,
                ref MinimumAllowedAge,
                ref DefaultValidityLength,
                ref ClassFees))
            {
                return new clsLicenseClass(
                    LicenseClassID,
                    ClassName,
                    ClassDescription,
                    MinimumAllowedAge,
                    DefaultValidityLength,
                    ClassFees);
            }
            else
                return null;
        }

        public static clsLicenseClass Find(enLicenseClass LicenseClass)
        {
            return Find((int)LicenseClass);
        }

        private bool _AddNewLicenseClass()
        {
            this.LicenseClassID = clsLicenseClassDataAccess.AddNewLicenseClass(
                this.ClassName,
                this.ClassDescription,
                this.MinimumAllowedAge,
                this.DefaultValidityLength,
                this.ClassFees);

            return (this.LicenseClassID != -1);
        }

        private bool _UpdateLicenseClass()
        {
            return clsLicenseClassDataAccess.UpdateLicenseClass(
                this.LicenseClassID,
                this.ClassName,
                this.ClassDescription,
                this.MinimumAllowedAge,
                this.DefaultValidityLength,
                this.ClassFees);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicenseClass())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateLicenseClass();
            }

            return false;
        }

        public static bool Delete(int LicenseClassID)
        {
            return clsLicenseClassDataAccess.DeleteLicenseClass(LicenseClassID);
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassDataAccess.GetAllLicenseClasses();
        }

        public static bool IsPersonAgeAllowedForLicenseClass(int PersonID, enLicenseClass licenseClass)
        {
            clsPerson person = clsPerson.Find(PersonID);

            if (person == null)
                return false;

            clsLicenseClass license = clsLicenseClass.Find((int)licenseClass);

            if (license == null)
                return false;

            int age = DateTime.Now.Year - person.DateOfBirth.Year;

            if (DateTime.Now < person.DateOfBirth.AddYears(age))
                age--;

            return age >= license.MinimumAllowedAge;
        }
    }
}
