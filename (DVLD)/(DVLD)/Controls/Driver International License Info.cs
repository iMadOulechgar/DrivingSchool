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
    public partial class Driver_International_License_Info : UserControl
    {
        public Driver_International_License_Info()
        {
            InitializeComponent();
        }

        public clsBusinessLayerInternationalLicence InternationalLicence;
        public clsBusinessPersone Persone;

        public void FillData()
        {
            LBLAppID.Text = InternationalLicence.ApplicationID.ToString();
            if (Persone.Gendor == 1)
                LBLGendor.Text = "Male";
            else
                LBLGendor.Text = "Female";
            LBLDriverID.Text = InternationalLicence.DriverID.ToString();
            LBLExpirationDate.Text = InternationalLicence.ExpirationDate.ToString();
            LBLNATIONALNO.Text = Persone.NationalNo.ToString();
            LBLInternationID.Text = InternationalLicence.InternationalLicenceID.ToString();
            
            if(InternationalLicence.IsActive == true)
                LBLIsActive.Text = "Yes";
            else
                LBLIsActive.Text = "No";

            LBLIssueDate.Text = InternationalLicence.IssueDate.ToString();
            LBLName1.Text = Persone.FullName;
            LBLDateOfBirth.Text = Persone.DateOfBirth.ToString();
            LBLLicence.Text = InternationalLicence.LicenceID.ToString();
        }



    }
}
