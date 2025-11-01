using _DVLD_.About_Test;
using _DVLD_.Application;
using _DVLD_.PeopleMenu;
using _DVLD_.Users;
using System;
using System.Windows.Forms;

namespace _DVLD_
{
    public partial class Main_MDI_ : Form
    {
        public Main_MDI_()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagePeople MP = new ManagePeople();

            MP.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManagment User = new UserManagment();
            User.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserDetails Details = new ShowUserDetails(clsGlobal.UserLogin.UserID,clsGlobal.UserLogin.PersonIdByRef);
            Details.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordFrm Password = new ChangePasswordFrm(clsGlobal.UserLogin.UserID, clsGlobal.UserLogin.PersonIdByRef);
            Password.ShowDialog();
        }

        private void drivingLicenceServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageApplicationTypes frm = new FrmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTestTypes Tests = new FrmTestTypes();
            Tests.ShowDialog();
        }
    }
}
