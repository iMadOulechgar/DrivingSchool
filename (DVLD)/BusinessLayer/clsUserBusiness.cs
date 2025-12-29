using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsUserBusiness
    {
        enum enmode { Add = 1,Update =2 }

        enmode Mode;

        public int UserID { get; set; }
        public int PersonIdByRef { get; set; }
        public clsPersone PersonInfo;
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsUserBusiness() 
        {
            UserID = -1;
            PersonIdByRef = -1;
            UserName = "";
            Password = "";
            IsActive = false;
            Mode = enmode.Add;
        }   

        public clsUserBusiness(int userid , int personeid , string username , string password , bool isactive)
        {
            UserID = userid;
            PersonIdByRef = personeid;
            PersonInfo = clsPersone.FindPersoneByPerId(personeid);
            UserName = username;
            Password = password;
            this.IsActive = isactive;

            Mode = enmode.Update;
        }

        public bool IsExists(int Per)
        {
            return clsUsers.Exists(Per);
        }

        public static clsUserBusiness FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            bool IsFound = clsUsers.GetUserInfoByPersonID
                                (PersonID, ref UserID, ref UserName, ref Password, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUserBusiness(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        private bool _AddUser()
        {
            UserID = clsUsers.AddUser(this.PersonIdByRef, this.UserName, this.Password, this.IsActive);
            return (UserID != -1);
        }

        public static DataTable GetAllUsersFromDB() =>
            clsUsers.GetAllUsers();

        public bool Save()
        {
            switch (Mode)
            {
                case enmode.Add:
                    if (_AddUser())
                    {
                        Mode = enmode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enmode.Update:
                    return _UpdateUser();
            }

            return false;
        }

        public bool CheckLoginUser()
        {
            return clsUsers.IsUserExistsAndIsActive(this.UserName,this.Password);
        }

        public static clsUserBusiness FindByUserID(int Userid)
        {
            int Personid = -1;
            string Username = "", password = "";
            bool isactive = false;

            if (clsUsers.FindUserByUserID(ref Userid, ref Personid, ref Username, ref password, ref isactive))
            {
                return new clsUserBusiness(Userid, Personid, Username, password, isactive);
            }

            return null;
        }

        public clsUserBusiness FindByUsername(string Username)
        {
            int Personeid = -1, UserId = -1;
            string password = "";
            bool isactive = false;

            if (clsUsers.FindUserByUserName(ref UserId, ref Personeid, ref Username, ref password, ref isactive))
            {
                return new clsUserBusiness(UserId, Personeid, Username, password, isactive);
            }

            return null;
        }

        public static clsUserBusiness FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;

            bool IsActive = false;

            bool IsFound = clsUsers.GetUserInfoByUsernameAndPassword
                                (UserName, Password, ref UserID, ref PersonID, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUserBusiness(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public bool _UpdateUser()
        {
            return clsUsers.UpdateUser(this.UserID, this.UserName, this.Password, this.IsActive);
        }
        
        public static bool DeleteUser(int userid)
        {
            return clsUsers.DeleteUserbyid(userid);
        }

        public bool CheckPassword(string Pass)
        {
            return clsUsers.CheckUserPasswordIsExists(Pass,this.UserID);
        }

        public static bool IsUserExistsByPerID(int PerID)
        {
            return clsUsers.IsUserExistForPersonID(PerID);
        }

        public static bool isUserExist(string UserName)
        {
            return clsUsers.IsUserExist(UserName);
        }


    }
}
