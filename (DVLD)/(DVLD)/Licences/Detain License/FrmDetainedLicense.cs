using _DVLD_.GlobalClasses;
using _DVLD_.Licences;
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
    public partial class FrmDetainedLicense : Form
    {
        public FrmDetainedLicense()
        {
            InitializeComponent();
        }

        private int _DetainedID = -1;
        private int _SelectedLicenseId = -1;

        private void FrmDetainedLicense_Load(object sender, EventArgs e)
        {
            LBLIDetainedID.Text = clsFormat.DateToShort(DateTime.Now);
            LBLCreatedBy.Text = clsGlobal.UserLogin.UserName;
        }

        private void filterLicences1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseId = obj;

            LBLLicenceID.Text = _SelectedLicenseId.ToString();

            linkLabel2.Enabled = (_SelectedLicenseId != -1);

            if (_SelectedLicenseId == -1)
            {
                return;
            }

            if (filterLicences1.LicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License i already detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtFineFees.Focus();
            BTNInternational.Enabled = true;
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFineFees, null);

            }

            if (!clsValidation.IsNumber(txtFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtFineFees, null);
            }
        }

        private void BTNInternational_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            _DetainedID = filterLicences1.LicenseInfo.Detain(Convert.ToSingle(txtFineFees.Text), clsGlobal.UserLogin.UserID);
            if (_DetainedID == -1)
            {
                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            LBLIDetainedID.Text = _DetainedID.ToString();
            MessageBox.Show("License Detained Successfully with ID=" + _DetainedID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            BTNInternational.Enabled = false;
            filterLicences1.FilterEnabled = false;
            txtFineFees.Enabled = false;
            linkLabel2.Enabled = true;
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDrivingLicenceDetails Frm = new frmDrivingLicenceDetails(_SelectedLicenseId);
            Frm.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLicenceHistory History = new FrmLicenceHistory(filterLicences1.LicenseInfo.DriverInfo.PersonID);
            History.ShowDialog();
        }

        private void txtFineFees_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
