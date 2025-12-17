using DataAccessLayer;
using System;
using System.Data;

namespace BusinessLayer
{
    public class clsBusinessPersone
    {
        public enum enmode { Add = 1, Update = 2};
        public enmode Mode = enmode.Add;

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }

        public string FullName  
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }
        }

        public DateTime DateOfBirth { get; set; }
        public byte Gendor { get; set; }
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

        public clsBusinessPersone(int id,string NationalN, string Fn, string Sn, string Tn,
            string Ln, DateTime DOB, byte Gd, string Ar, string PhoneNumber,
            string email, int countryid, string picturepath)
        {
            this.PersonID = id;
            this.NationalNo = NationalN;
            this.FirstName = Fn;
            this.SecondName = Sn;
            this.ThirdName = Tn;
            this.LastName = Ln;
            this.DateOfBirth = DOB;
            this.Gendor = Gd;
            this.Address = Ar;
            this.Phone = PhoneNumber;
            this.Email = email;
            this.NationalityCountryID = countryid;
            this.CountryInfo = clsCountry.Find(countryid);
            this.ImagePath = picturepath;

            Mode = enmode.Update;
        }

        public clsBusinessPersone()
        {
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = default(DateTime);
            this.Gendor = 0;
            this.Phone = "";
            this.Address = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";

            Mode = enmode.Add;
        }

        private bool _AddPersone()
        {
            this.PersonID = clsPersone.AddPersone(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
            return (this.PersonID != -1);
        }

        private bool _UpdatePersone()
        {
            return clsPersone.UpdatePersone(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enmode.Add:

                    if (_AddPersone())
                    {
                        Mode = enmode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enmode.Update:

                    return _UpdatePersone();
            }

            return false;
        }

        public static clsBusinessPersone FindPersoneByPerId(int id)
        {
            string NationalNum = "", Firstname = "", SecondName = "", ThirdName = "", LastName = "";
            DateTime DateOfBirth = default(DateTime);
            byte Gendor = 0;
            int CountryID = -1;
            string Address = "", Phone = "", Email = "", ImgPath = "";

            if (clsPersone.FindPersoneById(ref id, ref NationalNum, ref Firstname, ref SecondName, ref ThirdName,
                    ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref CountryID, ref ImgPath))
            {
                return new clsBusinessPersone(id,NationalNum, Firstname, SecondName, ThirdName,
                     LastName, DateOfBirth, Gendor, Address, Phone, Email, CountryID, ImgPath);
            }
            else
            {
                return null;
            }
        }

        public static clsBusinessPersone FindPersoneByNationalNo(string NationalNo)
        {
            string Firstname = "", SecondName = "", ThirdName = "", LastName = "";
            DateTime DateOfBirth = default(DateTime);
            byte Gendor = 0;
            int CountryID = -1 , id = 0;
            string Address = "", Phone = "", Email = "", ImgPath = "";

            if(clsPersone.FindPersoneByNational(ref id, ref NationalNo, ref Firstname, ref SecondName, ref ThirdName,
                    ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref CountryID, ref ImgPath))
            {
                return new clsBusinessPersone(id, NationalNo,  Firstname,  SecondName,  ThirdName,
                    LastName,  DateOfBirth,  Gendor,  Address,  Phone,  Email,  CountryID,  ImgPath);
            }
            else
            {
                return null;
            }
        }

        public static  DataTable GetAllRowsFromPeople()
        {
            return clsPersone.GetAllPersons();
        }

        public static bool DeletePersoneById(int Num)
        {
            return clsPersone.DeletePersoneById(Num);
        }

        public bool IsExists(string name)
        {
            return clsPersone.Exists(name);
        }

        public bool IsExists(int id)
        {
            return clsPersone.Exists(id);
        }

    }
}
