using _DVLD_.Licences;
using BusinessLayer;
using DVLD_Buisness;
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

        int _DriverID = -1;
        private clsBusinessLayerDrivers _Driver;
        private DataTable DtForLicence ;
        private DataTable DtForInternationalLicence;

        void _LoadLocalLicense()
        {
            DtForLicence = clsBusinessLayerDrivers.GetLicenses(_DriverID);

            dgvLocalLicensesHistory.DataSource = DtForLicence;
            LBLRecLocal.Text = dgvLocalLicensesHistory.Rows.Count.ToString();

            if (dgvLocalLicensesHistory.Rows.Count > 0)
            {
                dgvLocalLicensesHistory.Columns[0].HeaderText = "Lic.ID";
                dgvLocalLicensesHistory.Columns[0].Width = 110;

                dgvLocalLicensesHistory.Columns[1].HeaderText = "App.ID";
                dgvLocalLicensesHistory.Columns[1].Width = 110;

                dgvLocalLicensesHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalLicensesHistory.Columns[2].Width = 270;

                dgvLocalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicensesHistory.Columns[3].Width = 170;

                dgvLocalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicensesHistory.Columns[4].Width = 170;

                dgvLocalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvLocalLicensesHistory.Columns[5].Width = 110;
            }
        }

        void _LoadInternationalLicenses()
        {
            DtForInternationalLicence = clsInternationalLicense.GetDriverInternationalLicenses(_DriverID);

            dgvInternationalLicensesHistory.DataSource = DtForInternationalLicence;
            LBLRecInternational.Text = dgvInternationalLicensesHistory.Rows.Count.ToString();

            if (dgvInternationalLicensesHistory.Rows.Count > 0)
            {
                dgvInternationalLicensesHistory.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicensesHistory.Columns[0].Width = 160;

                dgvInternationalLicensesHistory.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicensesHistory.Columns[1].Width = 130;

                dgvInternationalLicensesHistory.Columns[2].HeaderText = "L.License ID";
                dgvInternationalLicensesHistory.Columns[2].Width = 130;

                dgvInternationalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicensesHistory.Columns[3].Width = 180;

                dgvInternationalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicensesHistory.Columns[4].Width = 180;

                dgvInternationalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvInternationalLicensesHistory.Columns[5].Width = 120;

            }
        }

        public void LoadDataByPersonID(int PersonID)
        {
            _Driver = clsBusinessLayerDrivers.FindByPersonID(PersonID);

            if (_Driver == null)
            {
                MessageBox.Show("This Person Hes Not A Driver choose An Other One", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DriverID = _Driver.DriverID;

            _LoadLocalLicense();
            _LoadInternationalLicenses();
        } 

        public void LoadDataByDriverID(int DriverID)
        {
            _Driver = clsBusinessLayerDrivers.FindByPersonID(DriverID);

            if (_Driver == null)
            {
                MessageBox.Show("This Person Hes Not A Driver choose An Other One", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DriverID = _Driver.DriverID;

            _LoadLocalLicense();
            _LoadInternationalLicenses();
        }

        public void Clear()
        {
            DtForInternationalLicence.Clear();
            DtForLicence.Clear();
        }


        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrivingLicenceDetails Details = new frmDrivingLicenceDetails((int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value);
            Details.ShowDialog();
        }
    }
}
