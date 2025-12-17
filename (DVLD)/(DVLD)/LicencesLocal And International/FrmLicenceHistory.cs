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

namespace _DVLD_.Licences
{
    public partial class FrmLicenceHistory : Form
    {
        public clsApplicationBusinessLayer App;

        public FrmLicenceHistory(int LocalID)
        {
            InitializeComponent();

            clsApplicationBusinessLayer Application = new clsApplicationBusinessLayer();
            App = Application.GetDataByLocalID(LocalID);
           personeFilterAndAdd1.fillfilter(App.App.AppPersoneId);
            driver_Licences_Hirtory1.FillDataGridView(App.App.ApplicationId);
            driver_Licences_Hirtory1.FillDataGridViewInternationalLicence();
        }

        public FrmLicenceHistory()
        {
            InitializeComponent();
        }

        public void FillData(int PersonID , int AppID)
        {
            personeFilterAndAdd1.fillfilter(PersonID);
            driver_Licences_Hirtory1.FillDataGridView(AppID);
            driver_Licences_Hirtory1.FillDataGridViewInternationalLicence();
        }

        public void FillByDetained(int PerID , int LicID)
        {
            personeFilterAndAdd1.fillfilter(PerID);
            driver_Licences_Hirtory1.FillDatByLicenceIDDirect(LicID);
            driver_Licences_Hirtory1.FillDataGridViewInternationalLicence();
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
