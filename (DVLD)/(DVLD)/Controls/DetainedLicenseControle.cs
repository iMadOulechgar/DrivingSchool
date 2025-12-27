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
          
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLicenceHistory History = new FrmLicenceHistory();
            History.ShowDialog();
        }
    }
}
