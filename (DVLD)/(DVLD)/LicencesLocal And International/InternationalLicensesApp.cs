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
    public partial class InternationalLicensesApp : Form
    {
        public InternationalLicensesApp()
        {
            InitializeComponent();
        }

        private void InternationalLicensesApp_Load(object sender, EventArgs e)
        {
            newInternationalLicenseControle1.SetData();
        }
    }
}
