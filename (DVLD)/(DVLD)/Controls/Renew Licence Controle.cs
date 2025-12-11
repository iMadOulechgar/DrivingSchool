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

namespace _DVLD_.Controls
{
    public partial class Renew_Licence_Controle : UserControl
    {
        public Renew_Licence_Controle()
        {
            InitializeComponent();
        }

        public clsApplicationBusinessLayer Application = new clsApplicationBusinessLayer();
        public clsBusinessLayerLicences licences = new clsBusinessLayerLicences();

        public void AppNewLicenceUI()
        {
            LBLIssueDate.Text = DateTime.Now.ToString();
            LBLAppDate.Text = DateTime.Now.ToString();
            LBLAppFees.Text = 7.ToString();
            LBLCreatedBy.Text = clsGlobal.UserLogin.UserName;
        }

        public void FillDataBaseApp(int PersonID)
        {
            Application.App.AppPersoneId = PersonID;
            Application.App.AppStatus = 3;
            Application.App.AppDate = DateTime.Now;
            Application.App.LastStatusDate = DateTime.Now;
            Application.App.PaidFees = 5;
            Application.App.AppType = 2;
            Application.App.CreatedByUserID = clsGlobal.UserLogin.UserID;
        }

        public void FillDataBaseLicence(int AppID,int DriverID,int LicenceClassID)
        {
            licences.ExpirationDate = DateTime.Now.AddYears(10);
            licences.IssueDate = DateTime.Now;
            licences.ApplicationID = AppID;
            licences.CreatedByUserID = clsGlobal.UserLogin.UserID;
            licences.DriverID = DriverID;
            licences.IsActive = true;
            licences.IssueReason = 0;
            licences.Notes = TBNotes.Text;
            licences.PaidFees = 20;
            licences.LicenceClassID = LicenceClassID;
        }

        public void FillControleWhenLicenceRenewed(int App , int LicenceID)
        {
            clsBusinessLayerLicences Licence = new clsBusinessLayerLicences();

            LBLRenewAppID.Text = App.ToString();
            LBLRenewedLic.Text = LicenceID.ToString();

            if (Licence.ChangeActiveToInActive(int.Parse(LBLOldLic.Text)))
            {
                MessageBox.Show("Old Licence Updated Successfly :) ", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Old Licence Not Updated , Something Wrong ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AppNewLicenceUI(int OldLicenceID,decimal LicenceFees)
        {
            int Total=Convert.ToInt32(LBLAppFees.Text) + Convert.ToInt32(LicenceFees);
            TTFees.Text = Total.ToString();
            LBLExpirationDate.Text = DateTime.Now.AddYears(10).ToString();
            LBLLicenceFees.Text = Convert.ToInt32(LicenceFees).ToString();
            LBLOldLic.Text = OldLicenceID.ToString();

        }


    }
}
