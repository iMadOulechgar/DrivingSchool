using _DVLD_.PeopleMenu;
using BusinessLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Windows.Forms;


namespace _DVLD_.Controls
{
    public partial class AddOrUpdatePersoneControle : UserControl
    {
        public AddOrUpdatePersoneControle()
        {
            InitializeComponent();

        }

        public event Action<int> PersoneIdByDelegate;
        public event Action CloseForm;
        public event Action FillPersoneInfo;
        public event Action WhenFrmClosedReturnDataToPersoneInfo;

        public clsBusinessPersone Persone1;

        private void _GetAllCountries()
        {
            clsBusinessPersone Persone = new clsBusinessPersone();
            DataTable Table = Persone.GetAllCountrys();

            foreach (DataRow item in Table.Rows)
            {
                CBCountries.Items.Add(item["CountryName"]);
            }
        }

        private void AddOrUpdatePeroneControle_Load(object sender, EventArgs e)
        {
            DTP.MaxDate = DateTime.Now.AddYears(-18);
            DTP.Value = DTP.MaxDate;
            _GetAllCountries();
            _FillControlsWithData();
        }

        private void _FillControlsWithData()
        {
            TBFirstname.Text = Persone1.Firstname;

            if (Persone1.SecondName != "")
                TBSecodnName.Text = Persone1.SecondName;

            if (Persone1.ThirdName != "")
                TBThirdName.Text = Persone1.ThirdName;

            TBLastName.Text = Persone1.LastName;
            TBPhone.Text = Persone1.Phone;
            TBAddress.Text = Persone1.Address;
            TBEmail.Text = Persone1.Email;
            TBNationalNumber.Text = Persone1.NationalNum;
            if (Persone1.DateOfBirth >= DTP.MinDate && Persone1.DateOfBirth <= DTP.MaxDate)
                DTP.Value = Persone1.DateOfBirth;

            if (Persone1.Gendor == 2)
                RBMale.Checked = true;

            if (Persone1.Gendor == 1)
                RBFemale.Checked = true;

            if (Persone1.CountryID != 0)
            {
                CBCountries.SelectedItem = Persone1.GetCountryNameById(Persone1.CountryID);
            }

            if (Persone1.ImgPath != "" && File.Exists(Persone1.ImgPath))
            {
                PBPerson.Load(Persone1.ImgPath);
            }
            else
            {
                if (Persone1.Gendor == 2)
                {
                    PBPerson.Load(@"D:\DrivingSchool\(DVLD)\PeoplePicture\person_boy.png");
                    Persone1.ImgPath = @"D:\DrivingSchool\(DVLD)\PeoplePicture\person_boy.png";
                }
                else if (Persone1.Gendor == 1)
                {
                    PBPerson.Load(@"D:\DrivingSchool\(DVLD)\PeoplePicture\person_girl.png");
                    Persone1.ImgPath = @"D:\DrivingSchool\(DVLD)\PeoplePicture\person_girl.png";
                }
                else
                {
                    Persone1.ImgPath = @"D:\DrivingSchool\(DVLD)\PeoplePicture\person_boy.png";
                    PBPerson.Load("D:\\DrivingSchool\\(DVLD)\\PeoplePicture\\person_boy.png");
                }

            }

        }

        void AddPictureTooFolder(string Source , string FileN)
        {
            string Destination = Path.Combine(Source, Path.GetFileName(FileN));
            if (!File.Exists(Destination))
            {
                File.Copy(FileN, Destination, true);
                Persone1.ImgPath = Destination;
            }

        }

        void DeletePictureFromFolder(string Source, string OldPath, string NewPath)
        {
            string DestinationPath = Path.Combine(Source, Path.GetFileName(OldPath));
            if (DestinationPath != @"D:\DrivingSchool\(DVLD)\PeoplePicture\person_boy.png")
            {
                if (DestinationPath != NewPath)
                {
                    File.Delete(DestinationPath);
                }
            }
        }       
            

        bool EmailValidating(string Text)
        {
            if (Text.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase) || Text.EndsWith("outlook.com", StringComparison.OrdinalIgnoreCase) || Text.EndsWith("hotmail.com", StringComparison.OrdinalIgnoreCase))
                return true;
            else if (Text == "")
                return true;

                
            return false;
        }

        int ErrorCount()
        {
            string[] Arry = { TBFirstname.Text, TBSecodnName.Text, TBThirdName.Text, TBLastName.Text,
                TBAddress.Text,TBPhone.Text,TBNationalNumber.Text
                };

            int FinalResult = 0;

            for (int i = 0; i < Arry.Length; i++)
            {
                if (Arry[i] == "" )
                {
                    FinalResult++;
                }
            }

            return (FinalResult == 0) ? 1 : FinalResult ;
        }

        bool CheckInputs()
        {
            if(TBFirstname.Text != "" && TBSecodnName.Text != "" && TBThirdName.Text != "" &&
                TBLastName.Text != "" && TBAddress.Text != "" && TBPhone.Text != "" &&
                TBNationalNumber.Text != "" && EmailValidating(TBEmail.Text))
            {
                return true;
            }
            return false;
        }

        private void _FillData()
        {
            Persone1.Firstname = TBFirstname.Text;
            Persone1.SecondName = TBSecodnName.Text;
            Persone1.ThirdName = TBThirdName.Text;
            Persone1.LastName = TBLastName.Text;
            Persone1.Address = TBAddress.Text;
            Persone1.Phone = TBPhone.Text;
            Persone1.NationalNum = TBNationalNumber.Text;
            Persone1.Email = TBEmail.Text;
            Persone1.DateOfBirth = DTP.Value;

            if (RBMale.Checked)
                Persone1.Gendor = 2;
            else
                Persone1.Gendor = 1;

            Persone1.CountryID = CBCountries.SelectedIndex + 1;
            
            if (PBPerson.ImageLocation != null)
            {
                DeletePictureFromFolder(@"D:\DrivingSchool\(DVLD)\PeoplePicture", Persone1.ImgPath, PBPerson.ImageLocation.ToString());
                AddPictureTooFolder(@"D:\DrivingSchool\(DVLD)\PeoplePicture", PBPerson.ImageLocation.ToString());
            }

        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            if (CheckInputs())
            {
                _FillData();

                if (Persone1.Save())
                {
                    MessageBox.Show("The Persone Saved Susscesfly");

                    PersoneIdByDelegate?.Invoke(Persone1.PersoneID);
                }
                else
                {
                    MessageBox.Show("Something Wrong In DB");
                }
            }
            else
            {
                MessageBox.Show($"There Is Like : [ {ErrorCount()} ] Controles Are Null, Please Fill All Data!");
            }
            

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string Name = openFileDialog1.FileName;
                PBPerson.Load(Name);
                linkLabel2.Visible = true;
            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (RBMale.Checked)
                PBPerson.Load(@"D:\DrivingSchool\(DVLD)\PeoplePicture\person_boy.png");
            else
                PBPerson.Load(@"D:\DrivingSchool\(DVLD)\PeoplePicture\person_girl.png");
        }

        private void TBEmail_Validating(object sender, CancelEventArgs e)
        {
            string VD = TBEmail.Text.Trim();

            if (!VD.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase) && !VD.EndsWith("outlook.com", StringComparison.OrdinalIgnoreCase) && !VD.EndsWith("hotmail.com", StringComparison.OrdinalIgnoreCase))
            {
                errorProvider1.SetError(TBEmail, "You Forget@Gmail/outlook/hotmail But Its Not Importent :)");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void RBMale_CheckedChanged(object sender, EventArgs e)
        {
            if (RBMale.Checked)
                PBPerson.Load(@"D:\DrivingSchool\(DVLD)\PeoplePicture\person_boy.png");
        }

        private void RBFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (RBFemale.Checked)
                PBPerson.Load(@"D:\DrivingSchool\(DVLD)\PeoplePicture\person_girl.png");
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            WhenFrmClosedReturnDataToPersoneInfo.Invoke();
            FillPersoneInfo?.Invoke();
            CloseForm?.Invoke();
        }

        private void TBNationalNumber_Validating(object sender, CancelEventArgs e)
        {
            if (Persone1.IsExists(TBNationalNumber.Text))
            {
                e.Cancel = true;
                TBNationalNumber.Focus();
                errorProvider1.SetError(TBNationalNumber,"This NationalNO Is Already Exist");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
