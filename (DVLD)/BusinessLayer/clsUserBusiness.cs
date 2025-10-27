using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            }

            return false;
        }



    }
}
