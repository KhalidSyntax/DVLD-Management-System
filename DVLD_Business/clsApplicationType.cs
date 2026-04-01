using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsApplicationType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public float ApplicationTypeFees { get; set; }

        public clsApplicationType()
        {
            ApplicationTypeID = -1;
            ApplicationTypeTitle = "";
            ApplicationTypeFees = 0;

            Mode = enMode.AddNew;
        }

        private clsApplicationType(int AppTypeID, string AppTypeTitle, float AppTypeFees)
        {
            this.ApplicationTypeID = AppTypeID;
            this.ApplicationTypeTitle = AppTypeTitle;
            this.ApplicationTypeFees = AppTypeFees;

            Mode = enMode.Update;
        }

        public static clsApplicationType Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            float ApplicationTypeFees = 0;

            if (clsApplicationTypeDataAccess.GetApplicationTypeInfoByID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationTypeFees))
                return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationTypeFees);
            else
                return null;
        }

        private bool _AddNewApplicationType()
        {
            this.ApplicationTypeID = clsApplicationTypeDataAccess.AddNewApplicationType(this.ApplicationTypeTitle, this.ApplicationTypeFees);

            return (this.ApplicationTypeID != -1);
        }

        private bool _UpdateApplicationType()
        {
            return clsApplicationTypeDataAccess.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationTypeFees);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateApplicationType();
            }
            return false;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypeDataAccess.GetAllApplicationTypes();
        }
    }
}
