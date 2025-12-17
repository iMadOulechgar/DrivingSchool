using _DVLD_.PeopleMenu;
using _DVLD_.Properties;
using BusinessLayer;
using DataAccessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace _DVLD_.Controls
{
    public partial class PersonInfo : UserControl
    {
        public PersonInfo()
        {
            InitializeComponent();
        }

        private clsBusinessPersone _Person;

        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsBusinessPersone SelectedPersonInfo
        {
            get { return _Person; }
        }

        private void _LoadPersonImage()
        {
            if (_Person.Gendor == 0)
                PBPerson.Image = Resources.person_boy;
            else
                PBPerson.Image = Resources.person_girl;

            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    PBPerson.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _FillPersonInfo()
        {
            linkLabel1.Enabled = true;
            _PersonID = _Person.PersonID;
            LBLPersoneID.Text = _Person.PersonID.ToString();
            LBLNATIONALNO.Text = _Person.NationalNo;
            LBLName.Text = _Person.FullName;
            LBLGendor.Text = _Person.Gendor == 0 ? "Male" : "Female";
            LBLEmail.Text = _Person.Email;
            LBLPhone.Text = _Person.Phone;
            LBLDateofbirth.Text = _Person.DateOfBirth.ToShortDateString();
            LBLCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            LBLAddress.Text = _Person.Address;
            _LoadPersonImage();
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsBusinessPersone.FindPersoneByPerId(PersonID);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsBusinessPersone.FindPersoneByNationalNo(NationalNo);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form Frm = new AddPersoneFrm(_PersonID);
            Frm.ShowDialog();
            LoadPersonInfo(_PersonID);
        }

        public void ResetPersonInfo()
        {
            _PersonID = -1;
            LBLPersoneID.Text = "[????]";
            LBLNATIONALNO.Text = "[????]";
            LBLName.Text = "[????]";
            PBPerson.Image = Resources.person_boy;
            LBLGendor.Text = "[????]";
            LBLEmail.Text = "[????]";
            LBLPhone.Text = "[????]";
            LBLDateofbirth.Text = "[????]";
            LBLCountry.Text = "[????]";
            LBLAddress.Text = "[????]";
        }
    }
}
