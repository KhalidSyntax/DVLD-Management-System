using System;
using System.Data;
using DVLD_DataAccess;

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

        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }

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
        }

        public static clsLicenseClass Find(int LicenseClassID)
        {
            string ClassName = "";
            string ClassDescription = "";
            byte MinimumAllowedAge = 0, DefaultValidityLength = 0;
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
            byte MinimumAllowedAge = 0, DefaultValidityLength = 0;
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

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassDataAccess.GetAllLicenseClasses();
        }
    }
}
