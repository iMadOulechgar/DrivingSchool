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

namespace _DVLD_.Controls
{
    public partial class LocalDrivingLicenceAppInfoAndApplicationInfo : UserControl
    {
        public LocalDrivingLicenceAppInfoAndApplicationInfo()
        {
            InitializeComponent();
        }
        
        public clsApplicationBusinessLayer Application;

        string StatusUi(int Status)
        {
            switch (Status)
            {
                case 1:
                    return "New";
                case 2:
                    return "Cancelled";
                case 3:
                    return "Completed";
            }

            return "";
        }

        public void _FillControlesWithData(int Passed)
        {
            LBLAppID.Text = Application.LocalApp.LocalDrivingLicenceAppLicationID.ToString();
            LBLLicense.Text = Application.LocalApp.LicenceClasses.ToString();
            LBLID.Text = Application.App.ApplicationId.ToString();
            LBLStatus.Text = StatusUi(Application.App.AppStatus);
            LBLFees.Text = Application.App.PaidFees.ToString();
            LBLType.Text = clsDataAccessLayerApplication.GetAppType(Application.App.AppType);
            //LBLApp.Text = clsPersone.getPersoneFullNameByID(Application.App.AppPersoneId);
            LBLDate.Text = Application.App.AppDate.ToString();
            LBLDateStatus.Text = Application.App.LastStatusDate.ToString();
            LBLCreatedBy.Text = clsUsers.GetUserNameByID(Application.App.CreatedByUserID);
            LBLPassedTest.Text = Passed.ToString() + "/3";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowDetails DetailsPersone = new ShowDetails(Application.App.AppPersoneId);
            DetailsPersone.ShowDialog();
        }
    }
}
