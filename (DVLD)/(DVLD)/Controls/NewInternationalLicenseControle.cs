using _DVLD_.Licences;
using _DVLD_.LicencesLocal_And_International;
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
    public partial class NewInternationalLicenseControle : UserControl
    {
        public NewInternationalLicenseControle()
        {
            InitializeComponent();
        }

        public clsApplicationBusinessLayer App = new clsApplicationBusinessLayer();
        public clsBusinessLayerInternationalLicence International = new clsBusinessLayerInternationalLicence();


        bool ValidateTheLicenceID(string LicenceIDTextBox)
        {
            clsBusinessLayerLicences Lic = new clsBusinessLayerLicences();


            int LicenceID = int.Parse(LicenceIDTextBox);

            if (Lic.IsLicenceExists(LicenceID))
            {
                return true;
            }

            return false;
        }

        public void SetData()
        {
            clsBusinessApplicationType TypeApp = new clsBusinessApplicationType();

            LBLIssueDate.Text = DateTime.Now.ToString();
            LBLAppDate.Text = DateTime.Now.ToString();
            LBLExpirationDate.Text = DateTime.Now.AddYears(1).ToString();
            LBLFees.Text = TypeApp.GetFeesByAppTypeID(6).ToString();
            LBLCreatedBy.Text = clsGlobal.UserLogin.UserName.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clsBusinessLayerInternationalLicence Int = new clsBusinessLayerInternationalLicence();
            clsBusinessPersone persone = new clsBusinessPersone();
            clsBusinessLayerLicences Licences = new clsBusinessLayerLicences();
            clsApplicationBusinessLayer Application = new clsApplicationBusinessLayer();

            if (ValidateTheLicenceID(textBox1.Text))
            {
               
                if (International.CheckIsThereAlreadyAnInternationalLicence(driverLicenceInfo1.Licence.LicenceID))
                {
                    LBLLocalLicenceID.Text = driverLicenceInfo1.Licence.LicenceID.ToString();
                    BTNInternational.Enabled = false;
                    MessageBox.Show("This Person Is Already Have An International Licence","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    LBLLocalLicenceID.Text = driverLicenceInfo1.Licence.LicenceID.ToString();
                    linkLabel2.Enabled = false;
                    BTNInternational.Enabled = true;
                }

            }
            else
            {
                MessageBox.Show("This LicenceID Not Found , Please Try Another Number.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        

        void FillDataInternationLicence()
        {
            International.ExpirationDate = DateTime.Now.AddYears(1);
            International.IssueDate = DateTime.Now;
            International.CreatedByUserID = clsGlobal.UserLogin.UserID;
            International.DriverID = driverLicenceInfo1.Licence.DriverID;
            International.IsActive = driverLicenceInfo1.Licence.IsActive;
            International.LicenceID = driverLicenceInfo1.Licence.LicenceID;
        }

        void FillDataAfterSave()
        {
            linkLabel2.Enabled = true;
            BTNInternational.Enabled = false;
            LBLLicenceID.Text = International.InternationalLicenceID.ToString();
        }

        private void BTNInternational_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Wanna Get International Licence","Info",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
            {

                
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InternationLicenceDetailsInfo DetailsInter = new InternationLicenceDetailsInfo();


            DetailsInter.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLicenceHistory History = new FrmLicenceHistory();
            History.ShowDialog();
        }
    }
}
