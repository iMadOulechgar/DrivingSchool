using _DVLD_.Properties;
using BusinessLayer;
using DVLD.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DVLD_.Controls
{
    public partial class DriverLicenceInfo : UserControl
    {

        private int _LicenseID = -1;
        private clsBusinessLayerLicences _License;

        public DriverLicenceInfo()
        {
            InitializeComponent();
        }

        public int LicenseID 
        {
            get { return _LicenseID; }
        }
        public clsBusinessLayerLicences SelectedLicenseInfo
        {
            get { return _License; }
        }

        private void _LoadImage()
        {
            if (SelectedLicenseInfo.DriverInfo.PersonInfo.Gendor == 0)
                PB.Image = Resources.person_boy;
            else
                PB.Image = Resources.person_girl;

            string ImagePath = SelectedLicenseInfo.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                    PB.Load(ImagePath);
            }
            else
                MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void LoadInfo(int LicenceID)
        {
            _LicenseID = LicenceID;
            _License = clsBusinessLayerLicences.Find(_LicenseID);

            if (_License == null)
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }

            LBLLicence.Text = _License.LicenseID.ToString();
            LBLIsActive.Text = _License.IsActive ? "Yes" : "No";
            LBLIsDetained.Text = _License.IsDetained ? "Yes" : "No";
            LBLClass.Text = _License.LicenseClassIfo.ClassName;
            LBLName1.Text = _License.DriverInfo.PersonInfo.FullName;
            LBLNATIONALNO.Text = _License.DriverInfo.PersonInfo.NationalNo;
            LBLGendor.Text = _License.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            LBLDateOfBirth.Text = clsFormat.DateToShort(_License.DriverInfo.PersonInfo.DateOfBirth);
            LBLDriverID.Text = _License.DriverID.ToString();
            LBLIssueDate.Text = clsFormat.DateToShort(_License.IssueDate);
            LBLExpirationDate.Text = clsFormat.DateToShort(_License.ExpirationDate);
            LBLIssueReason.Text = _License.IssueReasonText;
            LBLNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
            _LoadImage();
        }



    }
}
