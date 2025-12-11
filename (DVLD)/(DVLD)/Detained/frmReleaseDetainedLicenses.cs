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
        public frmReleaseDetainedLicenses()
        {
            InitializeComponent();
            releasedLicenseControle1.UiLogicLoad();
        }

        public frmReleaseDetainedLicenses(int LicID)
        {
            InitializeComponent();
            releasedLicenseControle1.LoadDatainListViewDetainedLicenses(LicID);
        }
    }
}
