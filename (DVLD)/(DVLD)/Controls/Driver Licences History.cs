using _DVLD_.Licences;
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
    public partial class Driver_Licences_Hirtory : UserControl
    {
        public Driver_Licences_Hirtory()
        {
            InitializeComponent();
        }
        clsBusinessLayerLicences Licences;
        DataTable DtForLicence = new DataTable();
        DataTable DtForInternationalLicence = new DataTable();

        public void FillDatByLicenceIDDirect(int licenceID)
        {
            clsBusinessLayerLicences Lic = new clsBusinessLayerLicences();
            clsApplicationBusinessLayer App = new clsApplicationBusinessLayer();

            Licences = Lic.FindByLicenceID(licenceID); 
            DtForLicence = Lic.GetAllFromLicence(Licences.DriverID);

            DGVDrivers.Rows.Clear();

            foreach (DataRow Row in DtForLicence.Rows)
            {
                int Count = DGVDrivers.Rows.Add();

                DGVDrivers.Rows[Count].Cells[0].Value = Row["LicenceID"];
                DGVDrivers.Rows[Count].Cells[1].Value = Row["ApplicationID"];
                string ClassName = App.GetClassName((int)Row["LicenceClass"]);
                DGVDrivers.Rows[Count].Cells[2].Value = ClassName;
                DGVDrivers.Rows[Count].Cells[3].Value = Row["IssueDate"];
                DGVDrivers.Rows[Count].Cells[4].Value = Row["ExpirationDate"];
                DGVDrivers.Rows[Count].Cells[5].Value = Row["IsActive"];
            }

            LBLRec.Text = DGVDrivers.Rows.Count.ToString();
        }

        public void FillDataGridView(int AppID)
        {
            clsBusinessLayerLicences Bus = new clsBusinessLayerLicences();
            clsApplicationBusinessLayer App = new clsApplicationBusinessLayer();
            clsBusinessLayerLicences Lic = new clsBusinessLayerLicences();

            Licences = Bus.FindByAppID(AppID);

            DtForLicence = Lic.GetAllFromLicence(Licences.DriverID);

            DGVDrivers.Rows.Clear();

            foreach (DataRow Row in DtForLicence.Rows)
            {
                int Count = DGVDrivers.Rows.Add();

                DGVDrivers.Rows[Count].Cells[0].Value = Row["LicenceID"];
                DGVDrivers.Rows[Count].Cells[1].Value = Row["ApplicationID"];
                string ClassName = App.GetClassName((int)Row["LicenceClass"]);
                DGVDrivers.Rows[Count].Cells[2].Value = ClassName;
                DGVDrivers.Rows[Count].Cells[3].Value = Row["IssueDate"];
                DGVDrivers.Rows[Count].Cells[4].Value = Row["ExpirationDate"];
                DGVDrivers.Rows[Count].Cells[5].Value = Row["IsActive"];
            }

            LBLRec.Text = DGVDrivers.Rows.Count.ToString();
        }

        public void FillDataGridViewInternationalLicence()
        {
            clsBusinessLayerInternationalLicence International = new clsBusinessLayerInternationalLicence();

            DtForInternationalLicence = International.GetDataFromInternationaLicences(Licences.DriverID);

            foreach (DataRow Row in DtForInternationalLicence.Rows)
            {
                int Count = DGVInternationl.Rows.Add();
                DGVInternationl.Rows[Count].Cells[0].Value = Row["InternationalLicenceID"];
                DGVInternationl.Rows[Count].Cells[1].Value = Row["ApplicationID"];
                DGVInternationl.Rows[Count].Cells[2].Value = Row["IssuedUsingLocalLicenceID"];
                DGVInternationl.Rows[Count].Cells[3].Value = Row["IssueDate"];
                DGVInternationl.Rows[Count].Cells[4].Value = Row["ExpirationDate"];
                DGVInternationl.Rows[Count].Cells[5].Value = Row["IsActive"];
            }
            LBLRec.Text = DGVInternationl.Rows.Count.ToString();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrivingLicenceDetails Details = new frmDrivingLicenceDetails();
            Details.FillData((int)DGVDrivers.CurrentRow.Cells[0].Value);
            Details.Show();
        }
    }
}
