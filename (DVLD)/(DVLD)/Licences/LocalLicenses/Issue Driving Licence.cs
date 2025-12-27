using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DVLD_.Licences
{
    public partial class Issue_Driving_Licence : Form
    {
        clsLocalDrivingLicenseApplicaionBusiness _LocalDrivingLicenseApplication;
        int _LocalDrivingLicenseApplicationID = -1;

        public Issue_Driving_Licence(int localID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = localID;
        }


        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void BTNsave_Click(object sender, EventArgs e)
        {
            int LicenceId = _LocalDrivingLicenseApplication.IssueLicenseForTheFirtTime(TBNotes.Text,clsGlobal.UserLogin.UserID);

            if (LicenceId != -1)
            {
                MessageBox.Show("License Issued Successfully with License ID = " + LicenceId.ToString(),
                   "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued ! ",
                "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Issue_Driving_Licence_Load(object sender, EventArgs e)
        {
            TBNotes.Focus();
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplicaionBusiness.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Applicaiton with ID=" + _LocalDrivingLicenseApplicationID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            if (!_LocalDrivingLicenseApplication.PassedAllTests())
            {
                MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();
            if (LicenseID != -1)
            {
                MessageBox.Show("Person already has License before with License ID=" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;

            }

            ctrlDrivingLicenseApp1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
        }
    }
}
