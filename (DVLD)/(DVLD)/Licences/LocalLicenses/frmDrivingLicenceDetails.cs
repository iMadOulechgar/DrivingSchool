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
        private int _LicenseID = -1; 
        public frmDrivingLicenceDetails(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }
        
        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDrivingLicenceDetails_Load(object sender, EventArgs e)
        {
            driverLicenceInfo1.LoadInfo(_LicenseID);
        }
    }
}
