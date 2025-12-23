using BusinessLayer;
using DataAccessLayer;
using DVLD.Classes;
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

namespace _DVLD_.Applications
{
    public partial class FrmNewDrivingLicenceApp : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _LocalDrivingLicenseAppID = -1;
        private int _SelectedPersonID = -1;
        clsLocalDrivingLicenseApplicaionBusiness _LocalDrivingLicenseApplication;

        public FrmNewDrivingLicenceApp(int LocalApp)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _LocalDrivingLicenseAppID = LocalApp;
        }

        public FrmNewDrivingLicenceApp()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        private void _FillLicenseClassesInComoboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow row in dtLicenseClasses.Rows)
            {
                CBLicenceClasses.Items.Add(row["ClassName"]);
            }
        }

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values
            _FillLicenseClassesInComoboBox();

            if (_Mode == enMode.AddNew)
            {
                LBLTitle.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplicaionBusiness();
                personeFilterAndAdd1.FilterFocus();
                Tab2.Enabled = false;

                CBLicenceClasses.SelectedIndex = 2;
                LBLFees.Text = clsBusinessApplicationType.Find((int)clsApplicationBusinessLayer.enApplicationType.NewInternationalLicense).AppFees.ToString();
                LBLDate.Text = DateTime.Now.ToShortDateString();
                LBLCreatedBY.Text = clsGlobal.UserLogin.UserName;
            }
            else
            {
                LBLTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                Tab2.Enabled = true;
                BTNsave.Enabled = true;
            }
        }

        void _LoadData()
        {
            personeFilterAndAdd1.FilterEnabled = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplicaionBusiness.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseAppID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseAppID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            personeFilterAndAdd1.LoadPersonInfo(_LocalDrivingLicenseApplication.AppPersoneId);
            LBLDrivingLicenAPP.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            LBLDate.Text = clsFormat.DateToShort(_LocalDrivingLicenseApplication.AppDate);
            CBLicenceClasses.SelectedIndex = CBLicenceClasses.FindString(clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            LBLFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            LBLCreatedBY.Text = clsUserBusiness.FindByUserID(_LocalDrivingLicenseApplication.CreatedByUserID).UserName;
        }

        private void NewFrmDrivingLicenceApp_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                BTNsave.Enabled = true;
                Tab2.Enabled = true;
                Tab.SelectedTab = Tab.TabPages["Tab2"];
                return;
            }

            //incase of add new mode.
            if (personeFilterAndAdd1.PersonID != -1)
            {
                BTNsave.Enabled = true;
                Tab2.Enabled = true;
                Tab.SelectedTab = Tab.TabPages["Tab2"];
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                personeFilterAndAdd1.FilterFocus();
            }
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int LicenseClassID = clsLicenseClass.Find(CBLicenceClasses.Text).LicenseClassID;

            int ActiveApplicationID = clsApplicationBusinessLayer.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, clsApplicationBusinessLayer.enApplicationType.NewDrivingLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CBLicenceClasses.Focus();
                return;
            }

            _LocalDrivingLicenseApplication.ApplicationId = personeFilterAndAdd1.PersonID;
            _LocalDrivingLicenseApplication.AppDate = DateTime.Now;
            _LocalDrivingLicenseApplication.AppType = 1;
            _LocalDrivingLicenseApplication.AppStatus = clsApplicationBusinessLayer.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToDecimal(LBLFees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.UserLogin.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;
            
            if (_LocalDrivingLicenseApplication.Save())
            {
                LBLDrivingLicenAPP.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                LBLTitle.Text = "Update Local Driving License Application";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void personeFilterAndAdd1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }

        private void FrmNewDrivingLicenceApp_Activated(object sender, EventArgs e)
        {
            personeFilterAndAdd1.FilterFocus();
        }
    }
}
