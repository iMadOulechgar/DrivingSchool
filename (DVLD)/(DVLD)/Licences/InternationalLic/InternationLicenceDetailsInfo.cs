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
        int _InternationalID = -1;
        public InternationLicenceDetailsInfo(int InternationalID)
        {
            InitializeComponent();
            _InternationalID = InternationalID;
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InternationLicenceDetailsInfo_Load(object sender, EventArgs e)
        {
            ctrlInternationDetails1.LoadInfo(_InternationalID);
        }
    }
}
