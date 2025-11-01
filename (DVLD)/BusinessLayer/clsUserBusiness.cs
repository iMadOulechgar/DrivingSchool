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
        public string UserName { get; set; }
        public string Password { get; set; }
        public short IsActive { get; set; }

        public clsUserBusiness() 
        {
            UserID = -1;
            PersonIdByRef = -1;
            UserName = "";
            Password = "";
            IsActive = -1;
            Mode = enmode.Add;
        }   

        public clsUserBusiness(int userid , int personeid , string username , string password , bool isactive)
        {
            UserID = userid;
            PersonIdByRef = personeid;
            UserName = username;
            Password = password;
            if (isactive)
                IsActive = 1;
            else
                IsActive = 0;

            Mode = enmode.Update;
        }

        public bool IsExists(int Per)
        {
            return clsUsers.Exists(Per);
        }

        private bool _AddUser()
        {
            UserID = clsUsers.AddUser(this.PersonIdByRef, this.UserName, this.Password, this.IsActive);
            return (UserID != -1);
        }

        public DataTable GetAllUsersFromDB() =>
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
                break;

                case enmode.Update:
                    if (_UpdateUser())
                    {
                        return true;
                    }
                break;
            }

            return false;
        }

        public bool CheckLoginUser()
        {
            return clsUsers.IsUserExistsAndIsActive(this.UserName,this.Password);
        }

        public clsUserBusiness Find(int Userid)
        {
            int Personeid = -1;
            string Username = "", password = "";
            bool isactive = false;

            if (clsUsers.FindUserByUserID(ref Userid, ref Personeid, ref Username, ref password, ref isactive))
            {
                return new clsUserBusiness(Userid, Personeid, Username, password, isactive);
            }

            return null;
        }

        public clsUserBusiness Find(string Username)
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

        public bool _UpdateUser()
        {
            return clsUsers.UpdateUser(this.UserID, this.UserName, this.Password, this.IsActive);
        }
    
        public bool DeleteUser(int userid)
        {
            return clsUsers.DeleteUserbyid(userid);
        }

        public bool CheckPassword(string Pass)
        {
            return clsUsers.CheckUserPasswordIsExists(Pass,this.UserID);
        }

    }
}
