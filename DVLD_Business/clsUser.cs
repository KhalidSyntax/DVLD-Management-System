using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }

        public string Password;
        public bool IsActive { get; set; }

        private clsPerson _PersonInfo;

        public clsPerson PersonInfo
        {
            get 
            {
                if (_PersonInfo == null)
                    _PersonInfo = clsPerson.Find(this.PersonID);
                return _PersonInfo;
            }
        }

        public clsUser()
        {
            UserID = -1;
            UserName = "";
            Password = "";
            IsActive = true;

            Mode = enMode.AddNew;
        }

        private clsUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            _PersonInfo = clsPerson.Find(PersonID);
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }

        public static clsUser FindByUserID(int UserID)
        {
            int PersonID = -1; string UserName = "", Password = "";
            bool IsActive = false;

            if (clsUserDataAccess.GetUserInfoByUserID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1; string UserName = "", Password = "";
            bool IsActive = false;

            if (clsUserDataAccess.GetUserInfoByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref IsActive))
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1, PersonID = -1;
            bool IsActive = false;

            if (clsUserDataAccess.GetUserInfoByUsernameAndPassword(UserName, Password, ref UserID, ref PersonID, ref IsActive))
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        private bool _AddNewUser()
        {
            if (clsUserDataAccess.IsUserExistForPersonID(this.PersonID))
                return false;

            this.UserID = clsUserDataAccess.AddNewUser(
                this.PersonID,
                this.UserName,
                this.Password,
                this.IsActive);

            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUserDataAccess.UpdateUser(
                this.UserID,
                this.PersonID,
                this.UserName,
                this.Password,
                this.IsActive);
        }

        public bool ChangePassword(string NewPassword)
        {
            if (string.IsNullOrWhiteSpace(NewPassword))
                return false;

            if(clsUserDataAccess.ChangePassword(this.UserID, NewPassword))
            {
                this.Password = NewPassword;
                return true;
            }
            return false;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateUser();
            }
            return false;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserDataAccess.GetAllUsers();
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserDataAccess.DeleteUser(UserID);
        }

        public static bool isUserExist(int UserID)
        {
            return clsUserDataAccess.IsUserExist(UserID);
        }

        public static bool isUserExist(string UserName)
        {
            return clsUserDataAccess.IsUserExist(UserName);
        }

        public static bool IsUserExistForPersonID(int PersonID)
        {
            return clsUserDataAccess.IsUserExistForPersonID(PersonID);
        }
    }
}
