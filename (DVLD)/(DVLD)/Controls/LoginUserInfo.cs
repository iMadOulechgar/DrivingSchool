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

namespace _DVLD_.Controls
{
    public partial class LoginUserInfo : UserControl
    {
        public LoginUserInfo()
        {
            InitializeComponent();
        }

        public clsUserBusiness User1 ;

        public void _FillDataUI()
        {
            LBLUI.Text = User1.UserID.ToString();
            LBLUN.Text = User1.UserName.ToString();
            if (User1.IsActive == 1)
                LBLIA.Text = "True";
            else
                LBLIA.Text = "False";
        }

        private void LoginUserInfo_Load(object sender, EventArgs e)
        {
            if (User1 != null)
            {
                _FillDataUI();
            }
        }
    }
}
