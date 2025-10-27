using _DVLD_.PeopleMenu;
using BusinessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace _DVLD_.Controls
{
    public partial class PersonInfo : UserControl
    {
        public PersonInfo()
        {
            InitializeComponent();
        }

        public clsBusinessPersone Persone1;

        public void _FillControlsWithData(int PersoneId)
        {
            clsBusinessPersone Bus = new clsBusinessPersone();
            Persone1 = Bus.FindPersoneByPerId(PersoneId);

            Persone1.PersoneID = PersoneId;
            LBLPersoneID.Text = PersoneId.ToString();
            LBLName.Text = Persone1.Firstname + " " + Persone1.SecondName + " " + Persone1.ThirdName + " " + Persone1.LastName;
            LBLPhone.Text = Persone1.Phone;
            LBLAddress.Text = Persone1.Address;
            LBLEmail.Text = Persone1.Email;
            LBLNATIONALNO.Text = Persone1.NationalNum;
            LBLDateofbirth.Text = Persone1.DateOfBirth.ToString();

            if (Persone1.Gendor == 2)
                LBLGendor.Text = "Male";
            else
                LBLGendor.Text = "Female";

            LBLCountry.Text = Persone1.GetCountryNameById(Persone1.CountryID);

            if (Persone1.ImgPath != "")
            {
                PBPerson.Load(Persone1.ImgPath);
            }
            else
            {
                if (Persone1.Gendor == 2)
                    PBPerson.Load(@"D:\DrivingSchool\(DVLD)\PeoplePicture\person_boy.png");
                else if (Persone1.Gendor == 1)
                    PBPerson.Load(@"D:\DrivingSchool\(DVLD)\PeoplePicture\person_girl.png");
                else
                    PBPerson.Load("D:\\DrivingSchool\\(DVLD)\\PeoplePicture\\person_boy.png");
            }
        }

        public void _FillControlsWithData(string NationalNO)
        {
            clsBusinessPersone Bus = new clsBusinessPersone();
            Persone1 = Bus.FindPersoneByNationalNo(NationalNO);

            if (Persone1 != null)
            {
                LBLPersoneID.Text = Persone1.PersoneID.ToString();
                LBLName.Text = Persone1.Firstname + " " + Persone1.SecondName + " " + Persone1.ThirdName + " " + Persone1.LastName;
                LBLPhone.Text = Persone1.Phone;
                LBLAddress.Text = Persone1.Address;
                LBLEmail.Text = Persone1.Email;
                LBLNATIONALNO.Text = Persone1.NationalNum;
                LBLDateofbirth.Text = Persone1.DateOfBirth.ToString();

                if (Persone1.Gendor == 2)
                    LBLGendor.Text = "Male";
                else
                    LBLGendor.Text = "Female";

                LBLCountry.Text = Persone1.GetCountryNameById(Persone1.CountryID);

                if (Persone1.ImgPath != "")
                {
                    PBPerson.Load(Persone1.ImgPath);
                }
                else
                {
                    if (Persone1.Gendor == 2)
                        PBPerson.Load(@"D:\DrivingSchool\(DVLD)\PeoplePicture\person_boy.png");
                    else if (Persone1.Gendor == 1)
                        PBPerson.Load(@"D:\DrivingSchool\(DVLD)\PeoplePicture\person_girl.png");
                    else
                        PBPerson.Load("D:\\DrivingSchool\\(DVLD)\\PeoplePicture\\person_boy.png");
                }
            }
            else
            {
                MessageBox.Show("The Persone You Add Is Not Exists");
            }
        }

        private void Reload()
        {
            string UIPersoneId = Persone1.PersoneID.ToString();
            Persone1 = Persone1.FindPersoneByPerId(Persone1.PersoneID);
            Persone1.PersoneID = int.Parse(UIPersoneId);
            _FillControlsWithData(Persone1.PersoneID);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Persone1 != null)
            {
                AddPersoneFrm Update = new AddPersoneFrm(Persone1.PersoneID);
                Update.ReloadDataFromShowdeatails += Reload;
                Update.ShowDialog();
            }
            else
            {
                MessageBox.Show("The Persone Not Exists In The System", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
        

    }
}
