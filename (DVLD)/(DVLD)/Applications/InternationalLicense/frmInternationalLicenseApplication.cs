using _DVLD_.Licences;
using _DVLD_.PeopleMenu;
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

namespace _DVLD_.LicencesLocal_And_International
{
    public partial class frmInternationalLicenseApplication : Form
    {

        private DataTable _dtInternationalLicenseApplications;

        public frmInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            _dtInternationalLicenseApplications = clsInternationalLicense.GetAllInternationalLicenses();
            CBSelect.SelectedIndex = 0;

            dgvInternationalLicenses.DataSource = _dtInternationalLicenseApplications;
            LBLRec.Text = dgvInternationalLicenses.Rows.Count.ToString();

            if (dgvInternationalLicenses.Rows.Count > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicenses.Columns[0].Width = 160;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 150;

                dgvInternationalLicenses.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenses.Columns[2].Width = 130;

                dgvInternationalLicenses.Columns[3].HeaderText = "L.License ID";
                dgvInternationalLicenses.Columns[3].Width = 130;

                dgvInternationalLicenses.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[4].Width = 180;

                dgvInternationalLicenses.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[5].Width = 180;

                dgvInternationalLicenses.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[6].Width = 120;
            }
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonId = clsBusinessLayerLicences.Find((int)dgvInternationalLicenses.CurrentRow.Cells[3].Value).DriverInfo.PersonID;
            ShowDetails Details = new ShowDetails(PersonId);
            Details.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonId = clsBusinessLayerLicences.Find((int)dgvInternationalLicenses.CurrentRow.Cells[3].Value).DriverInfo.PersonID;
            FrmLicenceHistory His = new FrmLicenceHistory(PersonId);
            His.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternationLicenceDetailsInfo international = new InternationLicenceDetailsInfo((int)dgvInternationalLicenses.CurrentRow.Cells[0].Value);
            international.ShowDialog();
        }

       
        private void CBSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBSelect.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;
            }
            else
            {
                txtFilterValue.Visible = (CBSelect.Text != "None");
                cbIsReleased.Visible = false;
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsReleased.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            LBLRec.Text = _dtInternationalLicenseApplications.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InternationalLicensesApp frm = new InternationalLicensesApp();
            frm.ShowDialog();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (CBSelect.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenceID";
                    break;
                case "Application ID":
                    {
                        FilterColumn = "ApplicationID";
                        break;
                    }
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenceID";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;


                default:
                    FilterColumn = "None";
                    break;
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
                LBLRec.Text = dgvInternationalLicenses.Rows.Count.ToString();
                return;
            }

            _dtInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());

            LBLRec.Text = _dtInternationalLicenseApplications.Rows.Count.ToString();
        }
    }
}
