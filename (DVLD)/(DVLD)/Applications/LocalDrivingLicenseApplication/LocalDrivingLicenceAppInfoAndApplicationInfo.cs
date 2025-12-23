using _DVLD_.PeopleMenu;
using BusinessLayer;
using DataAccessLayer;
using DVLD_Buisness;
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
    public partial class LocalDrivingLicenceAppInfoAndApplicationInfo : UserControl
    {
        public LocalDrivingLicenceAppInfoAndApplicationInfo()
        {
            InitializeComponent();
        }

        private clsLocalDrivingLicenseApplicaionBusiness _LocalDrivingLicenseApp;
        private int _LocalDrivingLicenseAppID = -1;
       
        public int LocalDrivingLicenseAppID
        {
            get { return _LocalDrivingLicenseAppID;}
        }

        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApp = clsLocalDrivingLicenseApplicaionBusiness.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApp == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();


                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();
        }

        public void LoadApplicationInfoByApplicationID(int ApplicationID)
        {
            _LocalDrivingLicenseApp = clsLocalDrivingLicenseApplicaionBusiness.FindByApplicationID(ApplicationID);
            if (_LocalDrivingLicenseApp == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();

                MessageBox.Show("No Application with ApplicationID = " + _LocalDrivingLicenseAppID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();
        }

        private void _FillLocalDrivingLicenseApplicationInfo()
        {
            LBLAppID.Text = _LocalDrivingLicenseApp.LocalDrivingLicenseApplicationID.ToString();
            //lblAppliedFor.Text = clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName;
            //lblPassedTests.Text = _LocalDrivingLicenseApplication.GetPassedTestCount().ToString() + "/3";
            ctlAppBaseInfo1.LoadApplicationInfo(_LocalDrivingLicenseApp.ApplicationId);
        }

        private void _ResetLocalDrivingLicenseApplicationInfo()
        {
            _LocalDrivingLicenseAppID = -1;
            ctlAppBaseInfo1.ResetApplicationInfo();
            LBLAppID.Text = "[????]";
            LBLLicense.Text = "[????]";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
