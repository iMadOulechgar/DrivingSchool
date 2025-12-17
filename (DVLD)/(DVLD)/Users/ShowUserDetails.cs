using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DVLD_.Users
{
    public partial class ShowUserDetails : Form
    {
        public ShowUserDetails(int UserID , int PersoneID)
        {
            InitializeComponent();

            clsUserBusiness User = new clsUserBusiness();
            clsBusinessPersone Persone = new clsBusinessPersone();
            loginUserInfo1.User1 = User.Find(UserID);
            //personInfo1.Persone1 = Persone.FindPersoneByPerId(PersoneID);
        }
    }
}
