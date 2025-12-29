using BusinessLayer;
using DVLD.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BusinessLayer.clsBusinessLayerLicences;

namespace _DVLD_.LicencesLocal_And_International
{
    public partial class frmReplaceForLostOrDamage : Form
    {
        public frmReplaceForLostOrDamage()
        {
            InitializeComponent();
        }

        int _NewLicenseID = -1;

        private void frmReplaceForLostOrDamage_Load(object sender, EventArgs e)
        {
            LBLAppDate.Text = clsFormat.DateToShort(DateTime.Now);
            LBLCreatedBy.Text = clsGlobal.UserLogin.UserName;
            RBDamage.Checked = true;
        }

        private enIssueReason _GetIssueReason()
        {
            if (RBDamage.Checked)
                return enIssueReason.DamagedReplacement;
            else
                return enIssueReason.LostReplacement;
        }

        private int _GetApplicationTypeID()
        {
            if(RBDamage.Checked)
                return (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;
            else
                return (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;
        }

        private void BTNInternational_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsBusinessLayerLicences NewLicense =
               filterLicences1.LicenseInfo.Replace(_GetIssueReason(),
               clsGlobal.UserLogin.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Issue a replacemnet for this  License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            LBLReplacAppID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;

            LBLReplacAppID.Text = _NewLicenseID.ToString();
            MessageBox.Show("Licensed Replaced Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            BTNIssue.Enabled = false;
            GBreplacement.Enabled = false;
            filterLicences1.FilterEnabled = false;
            LLLicenceInfo.Enabled = true;
        }

        private void RBLost_CheckedChanged(object sender, EventArgs e)
        {
            LBLtitle.Text = "Replacement for Lost License";
            this.Text = LBLtitle.Text;
            LBLAppFees.Text = clsApplicationType.Find(_GetApplicationTypeID()).AppFees.ToString();
        }

        private void RBDamage_CheckedChanged(object sender, EventArgs e)
        {
            LBLtitle.Text = "Replacement for Damaged License";
            this.Text = LBLtitle.Text;
            LBLAppFees.Text = clsApplicationType.Find(_GetApplicationTypeID()).AppFees.ToString();
        }

        private void filterLicences1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            LBLOldLicenceID.Text = SelectedLicenseID.ToString();
            LLLicenceInfo.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
            {
                return;
            }

            //dont allow a replacement if is Active .
            if (!filterLicences1.LicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BTNIssue.Enabled = false;
                return;
            }
            BTNIssue.Enabled = true;
        }
    }
}
