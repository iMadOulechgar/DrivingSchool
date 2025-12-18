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
        private clsUserBusiness _User;
        private int _UserID;
        public ChangePasswordFrm(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void _RestValues()
        {
            TBCurrentPass.Text = "";
            TBPassword.Text = "";
            TBConfirmPassword.Text = "";
            TBCurrentPass.Focus();
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                   "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.Password = TBConfirmPassword.Text;

            if (_User.Save())
            {
                MessageBox.Show("Password Changed Successfully.",
                     "Saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RestValues();
            }
            else
            {
                MessageBox.Show("An Erro Occured, Password did not change.",
                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TBCurrentPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBCurrentPass.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBConfirmPassword, "The Password Are Not The Same");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }

            if (TBCurrentPass.Text != _User.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(TBCurrentPass,"The Current Password Invalid");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void TBConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!(TBConfirmPassword.Text == TBPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBConfirmPassword, "The Password Are Not The Same");
            }
            else
                errorProvider1.Clear();
        }

        private void TBPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBConfirmPassword, "The Password Are Not The Same");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void ChangePasswordFrm_Load(object sender, EventArgs e)
        {
            _RestValues();

            _User = clsUserBusiness.FindByUserID(_UserID);

            if (_User == null)
            {
                MessageBox.Show("Could not Find User with id = " + _UserID,
                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlUserCard1.LoadUserInfo(_UserID);
        }
    }
}
