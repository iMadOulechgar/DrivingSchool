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

namespace _DVLD_.Detained
{
    public partial class frmReleaseDetainedLicenses : Form
    {
        int _SelectedLicense = -1;

        public frmReleaseDetainedLicenses()
        {
            InitializeComponent();
        }

        public frmReleaseDetainedLicenses(int LicenseID)
        {
            InitializeComponent();
            _SelectedLicense = LicenseID;
            filterLicences1.LoadLicenseInfo(_SelectedLicense);
            filterLicences1.FilterEnabled = false;
        }

        private void filterLicences1_OnLicenseSelected(int obj)
        {
            _SelectedLicense = obj;
            LBLLicenceID.Text = _SelectedLicense.ToString();

            linkLabel1.Enabled = (_SelectedLicense != -1);

            if (_SelectedLicense == -1)
            {
                return;
            }

            if (!filterLicences1.LicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License i is not detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LBLAppFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).AppFees.ToString();
            LBLCreatedBy.Text = clsGlobal.UserLogin.UserName;
            LBLIDetainedID.Text = filterLicences1.LicenseInfo.DetainedInfo.DetainID.ToString();
            LBLLicenceID.Text = filterLicences1.LicenseInfo.LicenseID.ToString();
            LBLCreatedBy.Text = filterLicences1.LicenseInfo.DetainedInfo.CreatedByUserInfo.UserName;
            LBLDetainedDate.Text = clsFormat.DateToShort(filterLicences1.LicenseInfo.DetainedInfo.DetainDate);
            LBLFineFees.Text = filterLicences1.LicenseInfo.DetainedInfo.FineFees.ToString();
            LBLTotalFees.Text = (Convert.ToSingle(LBLAppFees.Text)+Convert.ToSingle(LBLFineFees.Text)).ToString();
            BTNRelease.Enabled = true;
        }

        private void BTNRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int ApplicationID = -1;

            bool IsReleased = filterLicences1.LicenseInfo.ReleaseDetainedLicense(clsGlobal.UserLogin.UserID, ref ApplicationID);

            LBLAppID.Text = ApplicationID.ToString();

            if (!IsReleased)
            {
                MessageBox.Show("Faild to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

            BTNRelease.Enabled = false;
            filterLicences1.FilterEnabled = false;
            linkLabel2.Enabled = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDrivingLicenceDetails Frm = new frmDrivingLicenceDetails(_SelectedLicense);
            Frm.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLicenceHistory History = new FrmLicenceHistory(filterLicences1.LicenseInfo.DriverInfo.PersonID);
            History.ShowDialog();
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
