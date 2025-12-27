using _DVLD_.About_Test;
using _DVLD_.Application;
using _DVLD_.Applications;
using _DVLD_.Detained;
using _DVLD_.Drivers;
using _DVLD_.LicencesLocal_And_International;
using _DVLD_.PeopleMenu;
using _DVLD_.Users;
using System;
using System.Windows.Forms;

namespace _DVLD_
{
    public partial class Main_MDI_ : Form
    {
        LoginForm _login;
        public Main_MDI_(LoginForm Frm)
        {
            InitializeComponent();
            _login = Frm;
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
            clsGlobal.UserLogin = null;
            _login.ShowDialog();
        }

        private void userInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserDetails Details = new ShowUserDetails(clsGlobal.UserLogin.UserID);
            Details.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordFrm Password = new ChangePasswordFrm(clsGlobal.UserLogin.UserID);
            Password.ShowDialog();
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

        private void localDrivingLicenceApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListLocalDrivingLicenceApp LDL = new FrmListLocalDrivingLicenceApp();
            LDL.ShowDialog();
        }

        private void localLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewDrivingLicenceApp NewLocalDrivingLicense = new FrmNewDrivingLicenceApp();
            NewLocalDrivingLicense.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAllDrivers Drivers = new frmAllDrivers();
            Drivers.ShowDialog();
        }

        private void internationalLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternationalLicensesApp International = new InternationalLicensesApp();
            International.ShowDialog();
        }

        private void internationalLicenceApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseApplication InterN = new frmInternationalLicenseApplication();
            InterN.ShowDialog();
        }

        private void renewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void replacementForLostOrDemageLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceForLostOrDamage replacement = new frmReplaceForLostOrDamage();
            replacement.ShowDialog();
        }

        private void manageDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses Detain = new frmListDetainedLicenses();
            Detain.ShowDialog();
        }

        private void detaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDetainedLicense detain = new FrmDetainedLicense();
            detain.ShowDialog();    
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenses Released = new frmReleaseDetainedLicenses();
            Released.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenses Release = new frmReleaseDetainedLicenses();
            Release.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListLocalDrivingLicenceApp App = new FrmListLocalDrivingLicenceApp();
            App.ShowDialog();
        }
    }
}
