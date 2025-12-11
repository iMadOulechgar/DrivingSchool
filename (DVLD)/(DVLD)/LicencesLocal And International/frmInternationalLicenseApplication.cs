using _DVLD_.Licences;
using _DVLD_.PeopleMenu;
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

namespace _DVLD_.LicencesLocal_And_International
{
    public partial class frmInternationalLicenseApplication : Form
    {

        DataTable Dt = new DataTable();

        clsBusinessPersone Person;
        clsApplicationBusinessLayer App;
        clsBusinessLayerLicences Licence;

        void FillDataGridView()
        {
            clsBusinessLayerInternationalLicence InternationalLicense = new clsBusinessLayerInternationalLicence();
            Dt = InternationalLicense.GetDataFromInternationaLicences();

            DGVInternatioanlLicense.Rows.Clear();

            foreach (DataRow Row in Dt.Rows)
            {
                int Count = DGVInternatioanlLicense.Rows.Add();

                DGVInternatioanlLicense.Rows[Count].Cells[0].Value = Row["InternationalLicenceID"];
                DGVInternatioanlLicense.Rows[Count].Cells[1].Value = Row["ApplicationID"];
                DGVInternatioanlLicense.Rows[Count].Cells[2].Value = Row["DriverID"];
                DGVInternatioanlLicense.Rows[Count].Cells[3].Value = Row["IssuedUsingLocalLicenceID"];
                DGVInternatioanlLicense.Rows[Count].Cells[4].Value = Row["IssueDate"];
                DGVInternatioanlLicense.Rows[Count].Cells[5].Value = Row["ExpirationDate"];
                DGVInternatioanlLicense.Rows[Count].Cells[6].Value = Row["IsActive"];
            }

            LBLRec.Text = DGVInternatioanlLicense.Rows.Count.ToString();
        }

        public frmInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            FillDataGridView();
            _FillCBWithColumns();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsApplicationBusinessLayer Application = new clsApplicationBusinessLayer();

            App = Application.FindAppByAppID((int)DGVInternatioanlLicense.CurrentRow.Cells[1].Value);

            ShowDetails Details = new ShowDetails(App.App.AppPersoneId);
            Details.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsBusinessLayerLicences Lic = new clsBusinessLayerLicences();
            clsApplicationBusinessLayer Application = new clsApplicationBusinessLayer();

            Licence = Lic.FindByLicenceID((int)DGVInternatioanlLicense.CurrentRow.Cells[3].Value);
            App = Application.FindAppByAppID(Licence.ApplicationID);

            FrmLicenceHistory History = new FrmLicenceHistory();
            History.FillData(App.App.AppPersoneId,App.App.ApplicationId);

            History.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrivingLicenceDetails Details =new frmDrivingLicenceDetails();
            Details.FillData((int)DGVInternatioanlLicense.CurrentRow.Cells[3].Value);

            Details.ShowDialog();
        }

        void _FillCBWithColumns()
        {
            CBSelect.Items.Add("None");
            foreach (DataGridViewColumn Columns in DGVInternatioanlLicense.Columns)
            {
                CBSelect.Items.Add(Columns.HeaderText);
            }
            CBSelect.SelectedIndex = 0;
        }

        private void CBSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBSelect.SelectedItem == "None")
            {
                textBox1.Visible = false;
            }
            else
            {
                textBox1.Visible = true;
            }
        }
    }
}
