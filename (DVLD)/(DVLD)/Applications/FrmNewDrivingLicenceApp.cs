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

namespace _DVLD_.Applications
{
    public partial class FrmNewDrivingLicenceApp : Form
    {
        public FrmNewDrivingLicenceApp()
        {
            InitializeComponent();
        }

        public clsApplicationBusinessLayer Applications = new clsApplicationBusinessLayer();

        void _FillDataFromUiToDb()
        {
            int LicenceID = 1;
            LicenceID += CBLicenceClasses.SelectedIndex;
            
            Applications.App.AppDate = DateTime.Now;
            Applications.App.AppStatus = 1;
            Applications.App.AppType = 1;
            Applications.App.CreatedByUserID = clsGlobal.UserLogin.UserID;
            Applications.App.AppPersoneId = personeFilterAndAdd1.Persone1.PersonID;
            Applications.App.LastStatusDate = DateTime.Now;
            Applications.App.PaidFees = Convert.ToDecimal(LBLFees.Text);
            Applications.LocalApp.LicenceClasses = LicenceID;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        void WriteLicencesClassInCB()
        {
            clsApplicationBusinessLayer App = new clsApplicationBusinessLayer();

            DataTable TableLicenceClasses = App.GetAllLicenceClasses();

            foreach (DataRow Row in TableLicenceClasses.Rows)
            {
                string Phrase = (string)Row["ClassName"];
                CBLicenceClasses.Items.Add(Phrase);
            }
        }

        private void NewFrmDrivingLicenceApp_Load(object sender, EventArgs e)
        {
            WriteLicencesClassInCB();
            LBLDate.Text = DateTime.Now.ToString();
            LBLCreatedBY.Text = clsGlobal.UserLogin.UserName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (personeFilterAndAdd1.Persone1 != null)
                Tab.SelectedIndex = 1;
            else
                MessageBox.Show("The Person Is Empty Search For The PersonID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            int IdClass = 1;
                
               IdClass += CBLicenceClasses.SelectedIndex;

            if (!Applications.Exists(personeFilterAndAdd1.Persone1.PersonID, IdClass)) 
            {
                _FillDataFromUiToDb();

                if (Applications.Save())
                {
                    BTNsave.Enabled = false;
                    LBLDrivingLicenAPP.Text = Applications.App.ApplicationId.ToString();
                    MessageBox.Show("The Date Saved Succesfly ", "Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error , The Data Not Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("This Persone Is Already Ordered For This Licence", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            
        }

    }
}
