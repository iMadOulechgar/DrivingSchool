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

        public clsUserBusiness User  = new clsUserBusiness();
        public event Action WhenTheUserGetAddedOrEdited; 

        public FrmAddUsers(int UserID)
        {
            InitializeComponent();

            clsUserBusiness User2 = new clsUserBusiness();
            clsBusinessPersone Persone = new clsBusinessPersone();
            User = User2.Find(UserID);

            if (User != null)
            {
                FillAllDataToUi();
                personInfo1.Persone1 = Persone.FindPersoneByPerId(User.PersonIdByRef);
                filterControle1.fillfilter(personInfo1.Persone1.PersoneID);
                filterControle1.Enabled = false;
                BTNsave.Enabled = true;
                button1.Visible = false;
            }
        }

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
            if (CBIsActive.Checked == true)
                User.IsActive = 1;
            else
                User.IsActive = 0;
        }

        private void FillAllDataToUi()
        {
            LBLUserID.Text = User.UserID.ToString();
            TBUsername.Text = User.UserName;
            TBPassword.Text = User.Password;
            TBConfirmPassword.Text = User.Password;
            if (User.IsActive == 1)
                CBIsActive.Checked = true;
            else
                CBIsActive.Checked = false;
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            WhenTheUserGetAddedOrEdited?.Invoke();
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
                    MessageBox.Show("User Saved Succesfly :) ", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Invalid User :/ ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Wrong Info , Fill Data !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
