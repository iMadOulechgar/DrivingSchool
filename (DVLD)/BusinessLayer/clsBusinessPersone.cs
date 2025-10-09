using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsBusinessPersone
    {
        public enum enmode { Add = 1 , Update = 2 , Stop = 3};
        public enmode Mode;

        public int PersoneID { get; set; }
        public string NationalNum { get; set; }
        public string Firstname { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CountryID { get; set; }
        public string ImgPath { get; set; } 

        public clsBusinessPersone(string NationalN, string Fn, string Sn, string Tn,
            string Ln, DateTime DOB, byte Gd, string Ar, string PhoneNumber,
            string email, int countryid, string picturepath)
        {
            this.NationalNum = NationalN ;
            this.Firstname = Fn ;
            this.SecondName = Sn ;
            this.ThirdName = Tn ;
            this.LastName = Ln ;
            this.DateOfBirth = DOB ;
            this.Gendor = Gd ;
            this.Address = Ar ;
            this.Phone = PhoneNumber ;
            this.Email = email ;
            this.CountryID = countryid ;
            this.ImgPath = picturepath ;

            Mode = enmode.Update;
        }

        public clsBusinessPersone()
        {
           this.NationalNum = "";
           this.Firstname = "";
           this.SecondName = "";
           this.ThirdName = "";
           this.LastName = "";
           this.DateOfBirth = default(DateTime);
           this.Gendor = 0;
           this.Phone = "";
           this.Address = "";
           this.Email = "";
           this.CountryID = -1;
           this.ImgPath = "";

            Mode = enmode.Add;
        }

        private bool _AddPersone()
        {
             this.PersoneID = clsPersone.AddPersone(this.NationalNum,this.Firstname,this.SecondName,this.ThirdName,this.LastName,
                this.DateOfBirth,this.Gendor,this.Address,this.Phone,this.Email,this.CountryID,this.ImgPath);
            return (this.PersoneID != -1);
        }

        private bool _UpdatePersone()
        {
            return clsPersone.UpdatePersone(this.PersoneID,this.NationalNum, this.Firstname, this.SecondName, this.ThirdName, this.LastName,
                this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.CountryID, this.ImgPath);
        }

        public bool Save()
        {
            switch  (Mode)
            {
                case enmode.Add:

                    if (_AddPersone())
                    {
                        Mode = enmode.Stop;
                        return true;
                    }
                    break;
                case enmode.Update:

                    if (_UpdatePersone())
                    {
                        return true;
                    }
                    break;
                case enmode.Stop:
                    return false;
         
            }

            return false;
        }

        public clsBusinessPersone FindPersoneByPerId(int id)
        {
            string NationalNum = "",  Firstname="",  SecondName="",  ThirdName="",LastName="";
            DateTime DateOfBirth = default(DateTime);
            byte Gendor = 0;
            int CountryID=-1; 
            string Address="", Phone="", Email="", ImgPath="";

            if (clsPersone.FindPersoneById(id, ref NationalNum, ref Firstname, ref SecondName, ref ThirdName,
                    ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref CountryID, ref ImgPath))
            { 
                return new clsBusinessPersone(NationalNum, Firstname, SecondName, ThirdName,
                     LastName, DateOfBirth, Gendor, Address, Phone, Email, CountryID, ImgPath);
            }
            else
            {
                return null;
            }
        }

        public DataTable GetAllRowsFromPeople()
        {
            return clsPersone.GetAllPersons();
        }

        public DataTable GetAllCountrys()
        {
            return clsPersone.GetAllCountrysName();
        }

        public string GetCountryNameById(int id)
        {
            return clsPersone.GetCountryNameById(id);
        }

    }
}
