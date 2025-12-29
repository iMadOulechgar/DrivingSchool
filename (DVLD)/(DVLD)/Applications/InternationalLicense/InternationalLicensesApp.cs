using _DVLD_.Licences;
using BusinessLayer;
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

namespace _DVLD_.LicencesLocal_And_International
{
    public partial class InternationalLicensesApp : Form
    {
        public InternationalLicensesApp()
        {
            InitializeComponent();
        }

        private int _SelectedLicense = -1;
        private int _InternationLicenseID = -1;

        private void InternationalLicensesApp_Load(object sender, EventArgs e)
        {
            LBLAppDate.Text = clsFormat.DateToShort(DateTime.Now);
            LBLIssueDate.Text = LBLAppDate.Text;
            LBLExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(1));
            LBLFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).AppFees.ToString();
            LBLCreatedBy.Text = clsGlobal.UserLogin.UserName;
        }

        private void filterLicences1_OnLicenseSelected(int obj)
        {
            _SelectedLicense = obj;

            LBLLocalLicenceID.Text = _SelectedLicense.ToString();
            linkLabel1.Enabled = (_SelectedLicense != -1);

            if (_SelectedLicense == -1)
            {
                return;
            }

            if (filterLicences1.LicenseInfo.LicenseClass != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check if person already have an active international license
            int ActiveInternaionalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(filterLicences1.LicenseInfo.DriverID);

            if (ActiveInternaionalLicenseID != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternaionalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                linkLabel2.Enabled = true;
                _InternationLicenseID = ActiveInternaionalLicenseID;
                BTNInternational.Enabled = false;
                return;
            }

            BTNInternational.Enabled = true;
        }

        private void BTNInternational_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsInternationalLicense InternationalLicense = new clsInternationalLicense();
            //those are the information for the base application, because it inhirts from application, they are part of the sub class.

            InternationalLicense.AppPersoneId = filterLicences1.LicenseInfo.DriverInfo.PersonID;
            InternationalLicense.AppDate = DateTime.Now;
            InternationalLicense.AppStatus = clsApplication.enApplicationStatus.Completed;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense).AppFees;
            InternationalLicense.CreatedByUserID = clsGlobal.UserLogin.UserID;


            InternationalLicense.DriverID = filterLicences1.LicenseInfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = filterLicences1.LicenseInfo.LicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            InternationalLicense.CreatedByUserID = clsGlobal.UserLogin.UserID;

            if (!InternationalLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LBLIAppID.Text = InternationalLicense.ApplicationId.ToString();
            _InternationLicenseID = InternationalLicense.InternationalLicenseID;
            LBLLicenceID.Text = InternationalLicense.InternationalLicenseID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            BTNInternational.Enabled = false;
            filterLicences1.FilterEnabled = false;
            linkLabel2.Enabled = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLicenceHistory History = new FrmLicenceHistory(filterLicences1.LicenseInfo.DriverInfo.PersonID);
            History.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InternationLicenceDetailsInfo International = new InternationLicenceDetailsInfo(_InternationLicenseID);
            International.ShowDialog();
        }
    }
}
