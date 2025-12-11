using _DVLD_.Licences;
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
    public partial class DetainedLicenseControle : UserControl
    {
        public DetainedLicenseControle()
        {
            InitializeComponent();
        }

        clsBussinessLayerDetainedLicense Detain = new clsBussinessLayerDetainedLicense();

        bool checkIsLicenceDetainedAlready()
        {
            clsBussinessLayerDetainedLicense Detained = new clsBussinessLayerDetainedLicense();

            if (Detained.IsAlreadyDetained(Convert.ToInt32(textBox1.Text)))
                return true;
            else
                return false;
        }

        void FillControlesWithData()
        {
            clsBusinessLayerLicences CheckLicence = new clsBusinessLayerLicences();
            clsApplicationBusinessLayer App = new clsApplicationBusinessLayer();
            clsBusinessPersone Per = new clsBusinessPersone();

            driverLicenceInfo1.Licence = CheckLicence.FindByLicenceID(Convert.ToInt32(textBox1.Text));
            driverLicenceInfo1.Application = App.FindAppByAppID(driverLicenceInfo1.Licence.ApplicationID);
            driverLicenceInfo1.Person = Per.FindPersoneByPerId(driverLicenceInfo1.Application.App.AppPersoneId);
            driverLicenceInfo1._FillDataInControle();
            FillDataWhenSearch(driverLicenceInfo1.Licence.LicenceID);
        }

        void UiLogic(bool I)
        {
            if (I)
            {
                BTNInternational.Enabled = true;
                linkLabel2.Enabled = false;
                linkLabel1.Enabled = true;
                TBFineFees.Enabled = true;
            }
            else
            {
                BTNInternational.Enabled = false;
                linkLabel2.Enabled = false;
                linkLabel1.Enabled = true;
                TBFineFees.Enabled = false;
            }
        }

        void FillDataWhenSearch(int LicenceID)
        {
            LBLCreatedBy.Text = clsGlobal.UserLogin.UserName;
            LBLDetainedDate.Text = DateTime.Now.ToString();
            LBLLicenceID.Text = LicenceID.ToString();        
        }

        public void UiLogicLoad()
        {
            linkLabel1.Enabled = false;
            linkLabel2.Enabled = false;
            BTNInternational.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkIsLicenceDetainedAlready())
            {
                FillControlesWithData();
                UiLogic(false);
                MessageBox.Show("You Can Not Detain This License","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                FillControlesWithData();
                UiLogic(true);
            }
        }

        void FillDataBeforeSaving()
        {
            Detain.LicenceID = int.Parse(LBLLicenceID.Text);
            Detain.DetainDate = DateTime.Now;
            Detain.FineFees = Convert.ToDecimal(int.Parse(TBFineFees.Text));
            Detain.CreatedByUserID = clsGlobal.UserLogin.UserID;
            Detain.IsReleased = false;
        }

        void FillControleAfterSavingSuccessfly()
        {
            BTNInternational.Enabled = false;
            linkLabel2.Enabled = true;
            LBLIDetainedID.Text = Detain.DetainID.ToString();
            TBFineFees.Enabled = false;
        }

        void Save()
        {
            FillDataBeforeSaving();

            if (Detain.Save())
            {
                FillControleAfterSavingSuccessfly();
                MessageBox.Show("Data Saved Successfly", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Not Save , Somethign Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNInternational_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDrivingLicenceDetails Licence = new frmDrivingLicenceDetails();
            Licence.FillData(int.Parse(LBLLicenceID.Text));
            Licence.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLicenceHistory History = new FrmLicenceHistory();
            History.FillData(driverLicenceInfo1.Person.PersoneID,driverLicenceInfo1.Application.App.ApplicationId);
            History.ShowDialog();
        }
    }
}
