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
    public partial class frmDrivingLicenceDetails : Form
    {
        public frmDrivingLicenceDetails(int localID)
        {
            InitializeComponent();
            clsApplicationBusinessLayer App = new clsApplicationBusinessLayer();
            clsBusinessPersone Per = new clsBusinessPersone();
            clsBusinessLayerLicences Lic = new clsBusinessLayerLicences();
            //driverLicenceInfo1.Person = Per.FindPersoneByPerId(driverLicenceInfo1.Application.App.AppPersoneId);
        }

        public frmDrivingLicenceDetails()
        {
            InitializeComponent();
        }

        public void FillData(int LicenceID)
        {
            clsApplicationBusinessLayer App = new clsApplicationBusinessLayer();
            clsBusinessPersone Per = new clsBusinessPersone();
            clsBusinessLayerLicences Lic = new clsBusinessLayerLicences();

            driverLicenceInfo1.Licence = Lic.FindByLicenceID(LicenceID);
            //driverLicenceInfo1.Person = Per.FindPersoneByPerId(driverLicenceInfo1.Application.App.AppPersoneId);
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDrivingLicenceDetails_Load(object sender, EventArgs e)
        {
        }
    }
}
