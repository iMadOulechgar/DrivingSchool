using _DVLD_.LicencesLocal_And_International;
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
    public partial class FilterLicences : UserControl
    {
        public FilterLicences()
        {
            InitializeComponent();
        }

        public event Action<bool> ChangeUILogic;
        public event Action<int,decimal> EditUILogic;
        public event Action<int,int, int, int> GetIds;
        bool ValidateTheLicenceID(string LicenceIDTextBox)
        {
            clsBusinessLayerLicences Lic = new clsBusinessLayerLicences();


            int LicenceID = int.Parse(LicenceIDTextBox);

            if (Lic.IsLicenceExists(LicenceID))
            {
                return true;
            }

            return false;
        }

        public void EnableFilter()
        {
            groupBox1.Enabled = true;
        }

        bool CheckIsExpired(int LicenceID)
        {
            clsBusinessLayerLicences Licence = new clsBusinessLayerLicences();

            if (Licence.CheckIsLicenceExpirated(LicenceID))
            {
                return true;
            }

            return false;
        }

        public clsBusinessPersone Persone1;
        public clsBusinessLayerLicences Licence;

        private void button2_Click(object sender, EventArgs e)
        {
            clsBusinessPersone persone = new clsBusinessPersone();
            clsBusinessLayerLicences Licences = new clsBusinessLayerLicences();
            clsApplicationBusinessLayer Application = new clsApplicationBusinessLayer();

            if (ValidateTheLicenceID(textBox1.Text))
            {
                driverLicenceInfo1.Licence = Licences.FindByLicenceID(int.Parse(textBox1.Text));
                driverLicenceInfo1.Application = Application.FindAppByAppID(driverLicenceInfo1.Licence.ApplicationID);
                driverLicenceInfo1.Person = persone.FindPersoneByPerId(driverLicenceInfo1.Application.App.AppPersoneId);
                driverLicenceInfo1._FillDataInControle();
                
                GetIds?.Invoke(driverLicenceInfo1.Application.App.ApplicationId, driverLicenceInfo1.Person.PersoneID, driverLicenceInfo1.Licence.DriverID, driverLicenceInfo1.Licence.LicenceClassID);
                
                if (CheckIsExpired(driverLicenceInfo1.Licence.LicenceID))
                {
                    ChangeUILogic?.Invoke(true);
                    EditUILogic?.Invoke(driverLicenceInfo1.Licence.LicenceID, driverLicenceInfo1.Licence.PaidFees);
                }
                else
                {
                    ChangeUILogic?.Invoke(false);
                    EditUILogic?.Invoke(driverLicenceInfo1.Licence.LicenceID, driverLicenceInfo1.Licence.PaidFees);
                    MessageBox.Show("Selected Licence Is Not Yet Expired , It WillBe Expired In " + driverLicenceInfo1.Licence.ExpirationDate.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("The Licence Not Found","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
    }
}
