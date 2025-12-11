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
        clsApplicationBusinessLayer App = new clsApplicationBusinessLayer();
        clsBusinessLayerDrivers Driver = new clsBusinessLayerDrivers();
        clsBusinessLayerLicences Licence = new clsBusinessLayerLicences();

        public Issue_Driving_Licence(int localID,int passedTest)
        {
            InitializeComponent();

            localDrivingLicenceAppInfoAndApplicationInfo1.Application = App.GetDataByLocalID(localID);  
            localDrivingLicenceAppInfoAndApplicationInfo1._FillControlesWithData(passedTest);
        }

        void _FillDataIntDrivers()
        {
            Driver.PersonID = localDrivingLicenceAppInfoAndApplicationInfo1.Application.App.AppPersoneId;
            Driver.CreatedDate = DateTime.Now;
            Driver.CreatedByUserID = clsGlobal.UserLogin.UserID;
        }

        bool CreateNewLicence()
        {
            Licence.ApplicationID = localDrivingLicenceAppInfoAndApplicationInfo1.Application.App.ApplicationId;
            Licence.CreatedByUserID = clsGlobal.UserLogin.UserID;
            Licence.ExpirationDate = DateTime.Now.AddYears(10);
            Licence.IssueDate = DateTime.Now;

            if (Licence.IsExistsByAppID(Licence.ApplicationID))
            {
                return false;
            }

            if (Driver.IsDriverExistByPersonID(localDrivingLicenceAppInfoAndApplicationInfo1.Application.App.AppPersoneId))
            {
                Licence.DriverID = Driver.GetDriverID(localDrivingLicenceAppInfoAndApplicationInfo1.Application.App.AppPersoneId);
                
                if (Licence.DriverID == -1)
                {
                    MessageBox.Show("We Cant Find DriverID");
                    return false;
                }

                Licence.IssueReason = 0;
            }
            else
            {
                _FillDataIntDrivers();

                if (Driver.save())
                    Licence.DriverID = Driver.DriverID;
                else
                {
                    MessageBox.Show("The Driver not added");
                    return false;
                }

                Licence.IssueReason = 1;
            }

            Licence.IsActive = true;
            Licence.Notes = TBNotes.Text;
            Licence.LicenceClassID = localDrivingLicenceAppInfoAndApplicationInfo1.Application.LocalApp.LicenceClasses;
            Licence.PaidFees = (decimal)localDrivingLicenceAppInfoAndApplicationInfo1.Application.App.PaidFees;
            
            return true;
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void BTNsave_Click(object sender, EventArgs e)
        {
            if (CreateNewLicence())
            {
                if (Licence.Save())
                {
                    if(localDrivingLicenceAppInfoAndApplicationInfo1.Application.Save())
                        MessageBox.Show("Data Saved Succesfly", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("The Order Status NotCompleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);     
                }
                else
                {
                    MessageBox.Show("Data Not Saved","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Data Not Filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
