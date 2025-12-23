using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DVLD_.Applications.LocalDrivingLicenseApplication
{
    public partial class FrmLocalDrivingLicenseInfo : Form
    {
        private int _ApplicationID = -1;

        public FrmLocalDrivingLicenseInfo(int AppId)
        {
            InitializeComponent();
            this._ApplicationID = AppId;
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLocalDrivingLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApp1.LoadApplicationInfoByLocalDrivingAppID(this._ApplicationID);
        }
    }
}
