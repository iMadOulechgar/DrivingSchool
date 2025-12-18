using _DVLD_.PeopleMenu;
using BusinessLayer;
using DataAccessLayer;
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
    public partial class FrmAddUsers : Form
    {
        public FrmAddUsers()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _UserID = -1;
        clsUserBusiness _User;

        public FrmAddUsers(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _UserID = UserID;
        }

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
                this.Text = "Add New User";
                _User = new clsUserBusiness();

                tbLogininfo.Enabled = false;

                personeFilterAndAdd1.FilterFocus();
            }
            else
            {
                lblTitle.Text = "Update User";
                this.Text = "Update User";

                tbLogininfo.Enabled = true;
                BTNsave.Enabled = true;
            }

            txtUserName.Text = "";
            TBPassword.Text = "";
            TBConfirmPassword.Text = "";
            CBIsActive.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                BTNsave.Enabled = true;
                tbLogininfo.Enabled = true;
                Tab.SelectedTab = Tab.TabPages["tbLogininfo"];
                return;
            }

            //incase of add new mode.
            if (personeFilterAndAdd1.PersonID != -1)
            {

                if (clsUserBusiness.IsUserExistsByPerID(personeFilterAndAdd1.PersonID))
                {

                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    personeFilterAndAdd1.FilterFocus();
                }
                else
                {
                    BTNsave.Enabled = true;
                    tbLogininfo.Enabled = true;
                    Tab.SelectedTab = Tab.TabPages["tbLogininfo"];
                }
            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                personeFilterAndAdd1.FilterFocus();

            }

        }

        private void _LoadData()
        {
            _User = clsUserBusiness.FindByUserID(_UserID);
            personeFilterAndAdd1.FilterEnabled = false;

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _User, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //the following code will not be executed if the person was not found
            LBLUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            TBPassword.Text = _User.Password;
            TBConfirmPassword.Text = _User.Password;
            CBIsActive.Checked = _User.IsActive;
            personeFilterAndAdd1.LoadPersonInfo(_User.PersonIdByRef);
        }

        private void FrmAddUsers_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TBConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (TBPassword.Text.Trim() != TBConfirmPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(TBConfirmPassword, "The Password Not The Same");
            }
            else
                errorProvider1.Clear();
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.PersonIdByRef = personeFilterAndAdd1.PersonID;
            _User.UserName = txtUserName.Text.Trim();
            _User.Password = TBPassword.Text.Trim();
            _User.IsActive = CBIsActive.Checked;


            if (_User.Save())
            {
                LBLUserID.Text = _User.UserID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void TBUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }


            if (_Mode == enMode.AddNew)
            {

                if (clsUserBusiness.isUserExist(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "username is used by another user");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                }
            }
            else
            {
                //incase update make sure not to use anothers user name
                if (_User.UserName != txtUserName.Text.Trim())
                {
                    if (clsUserBusiness.isUserExist(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, null);
                    } 
                }
            }
        }

        private void TBPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(TBPassword, null);
            }
            
        }
    }
}
