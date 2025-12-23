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
    public partial class ControleReplaceForDamageOrLost : UserControl
    {
        public ControleReplaceForDamageOrLost()
        {
            InitializeComponent();
        }

        clsBusinessLayerLicences licences = new clsBusinessLayerLicences();
        clsApplicationBusinessLayer Application = new clsApplicationBusinessLayer();

        void FillReplacementControlesWithData()
        {
            LBLAppDate.Text = DateTime.Now.ToString();
            if (RBForDamaged.Checked == true)
                LBLAppFees.Text = "5";
            else
                LBLAppFees.Text = "10";
            LBLCreatedBy.Text = clsGlobal.UserLogin.UserName;
            LBLOldLicenceID.Text = driverLicenceInfo1.Licence.LicenceID.ToString();
        }

        void FillControlesWithData()
        {
            clsBusinessLayerLicences CheckLicence = new clsBusinessLayerLicences();
            clsApplicationBusinessLayer App = new clsApplicationBusinessLayer();
            clsBusinessPersone Per = new clsBusinessPersone();

            driverLicenceInfo1.Licence = CheckLicence.FindByLicenceID(Convert.ToInt32(textBox1.Text));
            //driverLicenceInfo1.Person = Per.FindPersoneByPerId(driverLicenceInfo1.Application.App.AppPersoneId);
            FillReplacementControlesWithData();
        }

        bool CheckIsLicenseActive()
        {
            clsBusinessLayerLicences CheckLicence = new clsBusinessLayerLicences();

            if (CheckLicence.IsLicenceActive(int.Parse(textBox1.Text)))
                return true;
            else
                return false;
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

        public void UiLogicLoad()
        {
            linkLabel1.Enabled = false;
            linkLabel2.Enabled = false;
            BTNInternational.Enabled = false;
            RBForDamaged.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckIsLicenseActive())
            {
                UiLogic(true);
                FillControlesWithData();
            }
            else
            {
                UiLogic(false);
                FillControlesWithData();
                MessageBox.Show("This Licence Is Not Activated , You Can Not ReplaceIt","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void RBForDamaged_CheckedChanged(object sender, EventArgs e)
        {
            if (RBForDamaged.Checked == true)
            {
                LBLAppFees.Text = "5";
            }
            else
            {
                LBLAppFees.Text = "10";
            }
        }

        

        public void FillDataBaseLicence(int AppID, int DriverID, int LicenceClassID)
        {
            licences.ExpirationDate = DateTime.Now.AddYears(10);
            licences.IssueDate = DateTime.Now;
            licences.ApplicationID = AppID;
            licences.CreatedByUserID = clsGlobal.UserLogin.UserID;
            licences.DriverID = DriverID;
            licences.IsActive = true;
            licences.IssueReason = 0;
            licences.Notes = driverLicenceInfo1.Licence.Notes;
            licences.PaidFees = driverLicenceInfo1.Licence.PaidFees;
            licences.LicenceClassID = LicenceClassID;
        }

        void AfterSaved()
        {
            BTNInternational.Enabled = false;
            linkLabel1.Enabled = true;
            linkLabel2.Enabled = true;
            LBLReplacedLicenceID.Text = licences.LicenceID.ToString();
        }

       

        private void BTNInternational_Click(object sender, EventArgs e)
        {
           
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDrivingLicenceDetails Details = new frmDrivingLicenceDetails();
            Details.FillData(licences.LicenceID);
            Details.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLicenceHistory History = new FrmLicenceHistory();
            History.ShowDialog();
        }
    }
}
