using _DVLD_.Controls;
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

namespace _DVLD_.LicencesLocal_And_International
{
    public partial class frmRenewLicence : Form
    {
        public frmRenewLicence()
        {
            InitializeComponent();
        }

        public clsBusinessLayerLicences Licence = new clsBusinessLayerLicences();
        public clsApplicationBusinessLayer Application = new clsApplicationBusinessLayer();

        void ChangeUiLogic(bool Ui)
        {
            if (Ui)
            {
                linkLabel2.Enabled = false;
                BTNSave.Enabled = true;
                linkLabel1.Enabled = true;
            }
            else
            {
                BTNSave.Enabled = false;
                linkLabel1.Enabled = true;
                linkLabel2.Enabled = false;
            }
        }

        private void frmRenewLicence_Load(object sender, EventArgs e)
        {
            renew_Licence_Controle1.AppNewLicenceUI();
            filterLicences1.EditUILogic += renew_Licence_Controle1.AppNewLicenceUI;
            filterLicences1.ChangeUILogic += ChangeUiLogic;
            filterLicences1.GetIds += GetWhatYouNeedFromOtherControle;
        }

        void GetWhatYouNeedFromOtherControle(int TempID,int PerID , int DriverID , int ClassLicenceID)
        {
            Licence.LicenceClassID = ClassLicenceID;
            Licence.DriverID = DriverID;
            TempAppID = TempID;
        }

        public int TempAppID {get; set;}

       

        void Save()
        {
           
        }

        private void BTNSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDrivingLicenceDetails Licence = new frmDrivingLicenceDetails();
            Licence.FillData(renew_Licence_Controle1.licences.LicenceID);
            Licence.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLicenceHistory His = new FrmLicenceHistory();
            His.ShowDialog();
        }
    }
}
