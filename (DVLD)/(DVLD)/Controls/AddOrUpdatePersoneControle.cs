using _DVLD_.PeopleMenu;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
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

            if(Persone1.SecondName != "")
            TBSecodnName.Text = Persone1.SecondName;

            if(Persone1.ThirdName != "")
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
                else
                    RBFemale.Checked = true;

            if (Persone1.CountryID != 0)
            {
                CBCountries.SelectedIndex = Persone1.CountryID;
            }
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

            if (RBFemale.Checked)
                Persone1.Gendor = 2;
            else
                Persone1.Gendor = 1;

                Persone1.CountryID = CBCountries.SelectedIndex;

            if (PBPerson.ImageLocation != null)
                Persone1.ImgPath = PBPerson.ImageLocation;
            else
                Persone1.ImgPath = " ";
            
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            _FillData();

            if (Persone1.Save())
            {
                MessageBox.Show("The Persone Saved Susscesfly");

                    PersoneIdByDelegate?.Invoke(Persone1.PersoneID);           
            }
            else
            {
                MessageBox.Show("You Cant Do That :/");
            }

        }

           


        }
}
