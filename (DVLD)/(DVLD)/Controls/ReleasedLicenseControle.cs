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
    public partial class ReleasedLicenseControle : UserControl
    {
        public ReleasedLicenseControle()
        {
            InitializeComponent();
        }

        clsApplicationBusinessLayer Application = new clsApplicationBusinessLayer();
        clsBussinessLayerDetainedLicense Released  = new clsBussinessLayerDetainedLicense();

        bool checkIsLicenceDetainedAlready()
        {
            clsBussinessLayerDetainedLicense Detained = new clsBussinessLayerDetainedLicense();

            if (Detained.IsAlreadyDetained(Convert.ToInt32(textBox1.Text)))
                return true;
            else
                return false;
        }

        void FillControlesWithData(bool IsReleasedAlready)
        {
            clsBusinessLayerLicences CheckLicence = new clsBusinessLayerLicences();
            clsApplicationBusinessLayer App = new clsApplicationBusinessLayer();
            clsBusinessPersone Per = new clsBusinessPersone();
            clsBussinessLayerDetainedLicense Det = new clsBussinessLayerDetainedLicense();

            driverLicenceInfo1.Licence = CheckLicence.FindByLicenceID(Convert.ToInt32(textBox1.Text));
            driverLicenceInfo1.Application = App.FindAppByAppID(driverLicenceInfo1.Licence.ApplicationID);
            driverLicenceInfo1.Person = Per.FindPersoneByPerId(driverLicenceInfo1.Application.App.AppPersoneId);
            driverLicenceInfo1._FillDataInControle();
            if (IsReleasedAlready)
            {
                Released = Det.FindDetainedLicenceByLicenceID(driverLicenceInfo1.Licence.LicenceID);
                FillDataWhenSearch(driverLicenceInfo1.Licence.LicenceID);
            }
        }

        void UiLogic(bool I)
        {
            if (I)
            {
                BTNInternational.Enabled = true;
                linkLabel2.Enabled = false;
                linkLabel1.Enabled = true;
            }
            else
            {
                BTNInternational.Enabled = false;
                linkLabel2.Enabled = false;
                linkLabel1.Enabled = true;
            }
        }

        public void FillDataBaseApp(int PersonID)
        {
            Application.App.AppPersoneId = PersonID;
            Application.App.AppStatus = 3;
            Application.App.AppDate = DateTime.Now;
            Application.App.LastStatusDate = DateTime.Now;
            Application.App.PaidFees = Convert.ToDecimal(int.Parse(LBLAppFees.Text));
            Application.App.AppType = 5;
            Application.App.CreatedByUserID = clsGlobal.UserLogin.UserID;
        }

        void FillDataWhenSearch(int LicenceID)
        {
            clsBusinessApplicationType AppTy = new clsBusinessApplicationType();
            LBLCreatedBy.Text = clsGlobal.UserLogin.UserName;
            LBLDetainedDate.Text = DateTime.Now.ToString();
            LBLLicenceID.Text = LicenceID.ToString();
            LBLIDetainedID.Text = Released.DetainID.ToString();
            LBLDetainedDate.Text = DateTime.Now.ToString();
            LBLAppFees.Text = Convert.ToInt32(AppTy.GetFeesByAppTypeID(5)).ToString();
            LBLFineFees.Text = Convert.ToInt32(Released.FineFees).ToString();
            LBLTotalFees.Text = (int.Parse(LBLAppFees.Text) + int.Parse(LBLFineFees.Text)).ToString();
        }

        public void UiLogicLoad()
        {
            linkLabel1.Enabled = false;
            linkLabel2.Enabled = false;
            BTNInternational.Enabled = false;
        }

        void FillDataInDb()
        {
            FillDataBaseApp(driverLicenceInfo1.Person.PersoneID);
            if (Application.SaveAddAppCanBeChange())
            {
                MessageBox.Show("App Saved Successfly","Confirm",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Something Wrong On App", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void FillDbRelease()
        {
            Released.ReleaseDate = DateTime.Now;
            Released.ReleasedByUserID = clsGlobal.UserLogin.UserID;
            Released.IsReleased = true;
            Released.ReleaseApplicationID = Application.App.ApplicationId;
            LBLAppID.Text = Application.App.ApplicationId.ToString();
        }

        void LogicUi()
        {
            linkLabel1.Enabled = true;
            linkLabel2.Enabled = true;
            BTNInternational.Enabled = false;
        }

        void Save()
        {
            FillDataInDb();
            FillDbRelease();

            if (Released.Save())
            {
                LogicUi();
                MessageBox.Show("The License Released Successfly", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The License Not Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNInternational_Click(object sender, EventArgs e)
        {
            Save();
        }

        public void LoadDatainListViewDetainedLicenses(int LicenseID)
        {
            textBox1.Text = LicenseID.ToString();
            groupBox1.Enabled = false;

            if (checkIsLicenceDetainedAlready())
            {
                UiLogic(true);
                FillControlesWithData(true);
            }
            else
            {
                UiLogic(false);
                FillControlesWithData(false);
                LBLLicenceID.Text = driverLicenceInfo1.Licence.LicenceID.ToString();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkIsLicenceDetainedAlready())
            {
                UiLogic(true);
                FillControlesWithData(true);
            }
            else
            {
                UiLogic(false);
                FillControlesWithData(false);
                LBLLicenceID.Text = driverLicenceInfo1.Licence.LicenceID.ToString();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLicenceHistory History = new FrmLicenceHistory();
            History.FillData(driverLicenceInfo1.Person.PersoneID, driverLicenceInfo1.Application.App.ApplicationId);
            History.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDrivingLicenceDetails Licen = new frmDrivingLicenceDetails();
            Licen.FillData(driverLicenceInfo1.Licence.LicenceID);
            Licen.ShowDialog();
        }
    }
}
