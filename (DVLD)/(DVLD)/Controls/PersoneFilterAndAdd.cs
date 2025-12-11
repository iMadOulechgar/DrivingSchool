using _DVLD_.PeopleMenu;
using _DVLD_.Users;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _DVLD_.Controls
{
    public partial class PersoneFilterAndAdd : UserControl
    {
        public PersoneFilterAndAdd()
        {
            InitializeComponent();
        }

        public clsBusinessPersone Persone1;

        public event Action<int> GetFunFromInfoPer;

        private void button1_Click(object sender, EventArgs e)
        {
            AddPersoneFrm Add = new AddPersoneFrm();
            Add.GetDataFromFilterControle += FunctionOfPersoneInfo;
            Add.ShowDialog();
        }

        void FunctionOfPersoneInfo(int PersoneId)
        {
            GetFunFromInfoPer?.Invoke(PersoneId);
        }

        void SearchBySelectingWhatYouWant(string STR)
        {
            switch (STR)
            {
                case "NationalNo":
                    SearchByNationalNO();
                    break;
                case "PersoneID":
                    SearchByID();
                    break;

                case "None":
                    MessageBox.Show("Select What You Gonna Search For !!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                    break;
            }
        }

        void SearchByNationalNO()
        {
            clsBusinessPersone Bus = new clsBusinessPersone();
            if (Bus.IsExists(textBox1.Text.Trim()))
            {
                _FillControlsWithData(textBox1.Text.Trim());
            }
            else
            {
                MessageBox.Show("The Persone Not Exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void SearchByID()
        {
            clsBusinessPersone Bus = new clsBusinessPersone();
            int PerId = int.Parse(textBox1.Text);

            if (Bus.IsExists(PerId))
            {
                _FillControlsWithData(PerId);
            }
            else
            {
                MessageBox.Show("The Persone Not Exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                SearchBySelectingWhatYouWant(comboBox1.SelectedItem.ToString());
            else
                MessageBox.Show("Fill What You Wanna Search For", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void fillfilter(int Id)
        {
            comboBox1.SelectedIndex = 0;
            textBox1.Text = Id.ToString();
            groupBox1.Enabled = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddPersoneFrm Update = new AddPersoneFrm(int.Parse(LBLPersoneID.Text));
            Update.ShowDialog();
        }
    }
}
