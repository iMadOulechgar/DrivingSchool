using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DVLD_.Controls
{
    public partial class DriverLicenceInfo : UserControl
    {
        public DriverLicenceInfo()
        {
            InitializeComponent();
        }

        public clsApplicationBusinessLayer Application;
        public clsBusinessPersone Person;
        public clsBusinessLayerLicences Licence;

        string GetAppType(int AppID)
        {
            clsBusinessApplicationType TypesName = new clsBusinessApplicationType();
             return TypesName.GetAppTypesNameByAppID(AppID); 
        }

        public void _FillDataInControle()
        {
            clsBussinessLayerDetainedLicense Detained = new clsBussinessLayerDetainedLicense();

            LBLClass.Text = Application.GetClassName(Licence.LicenceClassID);
            LBLName1.Text = Person.GetFullName();
            LBLLicence.Text = Licence.LicenceID.ToString();
            LBLNATIONALNO.Text = Person.NationalNum.ToString();
            if (Person.Gendor == 1)
                LBLGendor.Text = "Male";
            else
                LBLGendor.Text = "Female";

            LBLIssueDate.Text = Licence.IssueDate.ToString();

            if (Licence.IssueReason == 1 || Application.App.AppType == 1)
                LBLIssueReason.Text = "First Time";
            else
            {
                LBLIssueReason.Text = GetAppType(Application.App.AppType);
            }
                

            if (Licence.Notes != "")
                LBLNotes.Text = Licence.Notes;
            else
                LBLNotes.Text = "No Notes";

            if (Licence.IsActive == true)
                LBLIsActive.Text = "Yes";
            else
                LBLIsActive.Text = "No";

            LBLDateOfBirth.Text = Person.DateOfBirth.ToString();
            LBLDriverID.Text = Licence.DriverID.ToString();
            LBLExpirationDate.Text = Licence.ExpirationDate.ToString();
            if(Detained.IsAlreadyDetained(Licence.LicenceID))
                LBLIsDetained.Text = "Yes";
            else
                LBLIsDetained.Text = "No";

            PB.Load(Person.ImgPath);
        }


    }
}
