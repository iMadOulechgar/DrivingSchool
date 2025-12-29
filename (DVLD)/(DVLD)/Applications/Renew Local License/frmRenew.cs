using _DVLD_.Licences;
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

namespace _DVLD_.Applications.Renew_Local_License
{
    public partial class frmRenew : Form
    {
        public frmRenew()
        {
            InitializeComponent();
        }

        private int _NewLicenseID = -1;

        private void frmRenew_Load(object sender, EventArgs e)
        {
            filterLicences1.txtLicenseIDFocus();

            LBLAppDate.Text = clsFormat.DateToShort(DateTime.Now);
            LBLIssueDate.Text = LBLAppDate.Text;
            LBLExpirationDate.Text = "???";
            LBLAppFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).AppFees.ToString();
            LBLCreatedBy.Text = clsGlobal.UserLogin.UserName;
        }

        private void filterLicences1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            LBLOldLic.Text = SelectedLicenseID.ToString();

            LLHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
                return;

            int ValidityLength = filterLicences1.LicenseInfo.LicenseClassIfo.DefaultValidityLength;
            LBLExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(ValidityLength));
            LBLLicenceFees.Text = filterLicences1.LicenseInfo.LicenseClassIfo.ClassFees.ToString();
            LBLTotalFees.Text = (Convert.ToSingle(LBLLicenceFees.Text) + Convert.ToSingle(LBLAppFees.Text)).ToString();
            TBNotes.Text = filterLicences1.LicenseInfo.Notes.ToString();

            //check the license is not Expired.
            if (!filterLicences1.LicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " + clsFormat.DateToShort(filterLicences1.LicenseInfo.ExpirationDate)
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BTNIssued.Enabled = false;
                return;
            }

            //check the license is Active.
            if (!filterLicences1.LicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BTNIssued.Enabled = false;
                return;
            }

            BTNIssued.Enabled = true;
        }

        private void BTNIssued_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsBusinessLayerLicences NewLicence = filterLicences1.LicenseInfo.RenewLicense(TBNotes.Text,clsGlobal.UserLogin.UserID);

            if (NewLicence == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LBLRenewAppID.Text = NewLicence.ApplicationID.ToString();
            _NewLicenseID = NewLicence.LicenseID;
            LBLRenewedLic.Text = _NewLicenseID.ToString();
            MessageBox.Show("Licensed Renewed Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            BTNIssued.Enabled = false;
            filterLicences1.FilterEnabled = false;
            LLlicenseInfo.Enabled = true;
        }

        private void LLlicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDrivingLicenceDetails Details = new frmDrivingLicenceDetails(_NewLicenseID);
            Details.ShowDialog();
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
