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
    public partial class InternationLicenceDetailsInfo : Form
    {
        public InternationLicenceDetailsInfo()
        {
            InitializeComponent();
        }

        clsBusinessLayerInternationalLicence International = new clsBusinessLayerInternationalLicence();
        clsBusinessPersone Per = new clsBusinessPersone();
        clsBusinessLayerLicences Lice = new clsBusinessLayerLicences();

        public int  Persone { get; set; }
        public int LicenceID {  get; set; }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InternationLicenceDetailsInfo_Load(object sender, EventArgs e)
        {
            driver_International_License_Info1.InternationalLicence = International.FindInternationalLicenceByLicenceID(LicenceID);
            driver_International_License_Info1.Persone = Per.FindPersoneByPerId(Persone);
            driver_International_License_Info1.FillData();
        }
    }
}
