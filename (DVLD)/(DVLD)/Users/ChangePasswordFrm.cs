using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DVLD_.Users
{
    public partial class ChangePasswordFrm : Form
    {
        clsUserBusiness UserBus = new clsUserBusiness();
        clsBusinessPersone PersoneBus = new clsBusinessPersone();

        public ChangePasswordFrm(int UserID, int PersoneID)
        {
            InitializeComponent();
            clsUserBusiness User = new clsUserBusiness();

            UserBus = User.Find(UserID);
            loginUserInfo1.User1 = UserBus;
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool ValidatingInputs()
        {
            return (TBCurrentPass.Text != "" && TBPassword.Text != "" && TBConfirmPassword.Text != "") ? true : false;
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            if (ValidatingInputs())
            {
                if ((TBConfirmPassword.Text == TBPassword.Text) && (UserBus.CheckPassword(TBCurrentPass.Text)))
                {
                    UserBus.Password = TBConfirmPassword.Text;

                    if (UserBus.Save())
                    {
                        MessageBox.Show("The Changed Succesfly :)", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TBConfirmPassword.Text = "";
                        TBPassword.Text = "";
                        TBCurrentPass.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("The Password Not Saved Try Again :/ ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The Confirm Password Are Not The Same :(","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Fill Data !!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TBCurrentPass_Validating(object sender, CancelEventArgs e)
        {
            if (!UserBus.CheckPassword(TBCurrentPass.Text))
            {
                errorProvider1.SetError(TBCurrentPass,"The Current Password Invalid");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void TBConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!(TBConfirmPassword.Text == TBPassword.Text))
                errorProvider1.SetError(TBConfirmPassword, "The Password Are Not The Same");
            else
                errorProvider1.Clear();
        }


    }
}
