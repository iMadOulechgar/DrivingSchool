using _DVLD_.PeopleMenu;
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
    public partial class FrmAddUsers : Form
    {
        public FrmAddUsers()
        {
            InitializeComponent();
        }

        clsUserBusiness User = new clsUserBusiness();

        private void button1_Click(object sender, EventArgs e)
        {
            if (!User.IsExists(personInfo1.Persone1.PersoneID))
            {
                User.PersonIdByRef = personInfo1.Persone1.PersoneID;
                Tab.SelectedIndex = 1;
                BTNsave.Enabled = true;
            }
            else
            {
                MessageBox.Show("This Persone Is Already User !! ","STOP",MessageBoxButtons.OKCancel,MessageBoxIcon.Hand);
            }
            
        }

        private void FrmAddUsers_Load(object sender, EventArgs e)
        {
            filterControle1.FillDataByDelegateSearchSTR += personInfo1._FillControlsWithData;
            filterControle1.GetFunFromInfoPer += personInfo1._FillControlsWithData;
            filterControle1.FillDataByDelegateSearchINT += personInfo1._FillControlsWithData;
        }

        private bool ValidatingTools()
        {
            if (TBConfirmPassword.Text != "" && !(TBConfirmPassword.Text != TBPassword.Text) && TBPassword.Text != "" && TBUsername.Text != "")
                return true;


            return false;
        }

        private void _GetDataFromUI()
        {
            User.UserName = TBUsername.Text;
            User.Password = TBPassword.Text;
            if (CBIsActive.Checked = true)
                User.IsActive = 1;
            else
                User.IsActive = 0;
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TBConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (TBPassword.Text != TBConfirmPassword.Text)
            {
                errorProvider1.SetError(TBConfirmPassword, "The Password Not The Same");
            }
            else
                errorProvider1.Clear();
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            if (ValidatingTools())
            {
                _GetDataFromUI();
                if (User.Save())
                {
                    LBLUserID.Text = User.UserID.ToString();
                    MessageBox.Show("User Added Succesfly :) ", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("User Has Not Been Added :/ ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Wrong Info , Fill Data !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
