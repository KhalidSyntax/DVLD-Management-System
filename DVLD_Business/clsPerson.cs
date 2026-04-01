using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return string.IsNullOrWhiteSpace(ThirdName) ?
                    $"{FirstName} {SecondName} {LastName}" :
                    $"{FirstName} {SecondName} {ThirdName} {LastName}";
            }
        }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }

        public clsCountry CountryInfo;

        private string _ImagePath;
        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }

        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now.AddYears(-18);
            this.Gender = false;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";

            Mode = enMode.AddNew;
        }

        private clsPerson(
            int PersonID, string NationalNo,
            string FirstName, string SecondName, string ThirdName, string LastName,
            DateTime DateOfBirth, bool Gender, string Address, string Phone,
            string Email, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.CountryInfo = clsCountry.Find(NationalityCountryID);
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }

        public static clsPerson Find(int PersonID)
        {
            string NationalNo = "",
            FirstName = "", SecondName = "", ThirdName = "", LastName = "",
             Address = "", Phone = "", Email = "", ImagePath = "";

            int NationalityCountryID = -1;
            DateTime DateOfBirth = DateTime.Now;
            bool Gender = false;

            if (clsPersonDataAccess.GetPersonInfoByID(PersonID, ref NationalNo,
            ref FirstName, ref SecondName, ref ThirdName, ref LastName,
            ref DateOfBirth, ref Gender, ref Address, ref Phone,
            ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo,
                         FirstName, SecondName, ThirdName, LastName,
                         DateOfBirth, Gender, Address, Phone,
                         Email, NationalityCountryID, ImagePath);
            }
            else
                return null;
        }

        public static clsPerson Find(string NationalNo)
        {
            string
            FirstName = "", SecondName = "", ThirdName = "", LastName = "",
             Address = "", Phone = "", Email = "", ImagePath = "";

            int NationalityCountryID = -1, PersonID = -1;
            DateTime DateOfBirth = DateTime.Now;
            bool Gender = false;

            if (clsPersonDataAccess.GetPersonInfoByNationalNo(NationalNo, ref PersonID,
            ref FirstName, ref SecondName, ref ThirdName, ref LastName,
            ref DateOfBirth, ref Gender, ref Address, ref Phone,
            ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo,
                         FirstName, SecondName, ThirdName, LastName,
                         DateOfBirth, Gender, Address, Phone,
                         Email, NationalityCountryID, ImagePath);
            }
            else
                return null;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonDataAccess.AddNewPerson(this.NationalNo,
                         this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                         this.DateOfBirth, this.Gender, this.Address, this.Phone,
                         this.Email, this.NationalityCountryID, this.ImagePath);

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPersonDataAccess.UpdatePerson(this.PersonID, this.NationalNo,
                         this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                         this.DateOfBirth, this.Gender, this.Address, this.Phone,
                         this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdatePerson();
            }
            return false;
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPersonDataAccess.DeletePerson(PersonID);
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonDataAccess.GetAllPeople();
        }

        public static bool isPersonExist(int PersonID)
        {
            return clsPersonDataAccess.IsPersonExist(PersonID);
        }

        public static bool isPersonExist(string NationalNo)
        {
            return clsPersonDataAccess.IsPersonExist(NationalNo);
        }
    }
}
