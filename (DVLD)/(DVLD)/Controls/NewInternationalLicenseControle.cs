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

        }

        

        


        private void BTNInternational_Click(object sender, EventArgs e)
        {

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
