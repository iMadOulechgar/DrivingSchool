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

namespace _DVLD_.Detained
{
    public partial class frmListDetainedLicenses : Form
    {
        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        private DataTable _dtDetainedLicenses;

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            CBSelect.SelectedIndex = 0;

            _dtDetainedLicenses = clsBussinessLayerDetainedLicense.GetAllDataToDt();

            dgvDetainedLicenses.DataSource = _dtDetainedLicenses;
            LBLRec.Text = dgvDetainedLicenses.Rows.Count.ToString();

            if (dgvDetainedLicenses.Rows.Count > 0)
            {
                dgvDetainedLicenses.Columns[0].HeaderText = "D.ID";
                dgvDetainedLicenses.Columns[0].Width = 90;

                dgvDetainedLicenses.Columns[1].HeaderText = "L.ID";
                dgvDetainedLicenses.Columns[1].Width = 90;

                dgvDetainedLicenses.Columns[2].HeaderText = "D.Date";
                dgvDetainedLicenses.Columns[2].Width = 160;

                dgvDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[3].Width = 110;

                dgvDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[4].Width = 110;

                dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[5].Width = 160;

                dgvDetainedLicenses.Columns[6].HeaderText = "N.No.";
                dgvDetainedLicenses.Columns[6].Width = 90;

                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].Width = 330;

                dgvDetainedLicenses.Columns[8].HeaderText = "Rlease App.ID";
                dgvDetainedLicenses.Columns[8].Width = 150;

            }
        }

        private void CBSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBSelect.Text == "Is Released")
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDetails PersonDetails = new ShowDetails((string)dgvDetainedLicenses.CurrentRow.Cells[6].Value);
            PersonDetails.Show();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrivingLicenceDetails frm = new frmDrivingLicenceDetails((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsBusinessLayerLicences.Find((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value).DriverInfo.PersonID;
            FrmLicenceHistory History = new FrmLicenceHistory(PersonID);
            History.ShowDialog();
        }

        private void showDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenses Released = new frmReleaseDetainedLicenses((int)dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            Released.ShowDialog();
            frmListDetainedLicenses_Load(null, null);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (CBSelect.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "Is Released":
                    {
                        FilterColumn = "IsReleased";
                        break;
                    }
                    ;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = "";
                LBLRec.Text = dgvDetainedLicenses.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
                //in this case we deal with numbers not string.
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            LBLRec.Text = _dtDetainedLicenses.Rows.Count.ToString();
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReleased";
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
                _dtDetainedLicenses.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            LBLRec.Text = _dtDetainedLicenses.Rows.Count.ToString();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            showDetainLicenseToolStripMenuItem.Enabled = !(bool)dgvDetainedLicenses.CurrentRow.Cells[3].Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenses Released = new frmReleaseDetainedLicenses();
            Released.ShowDialog();
            frmListDetainedLicenses_Load(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDetainedLicense Detained = new FrmDetainedLicense();
            Detained.ShowDialog();
            frmListDetainedLicenses_Load(null, null);
        }
    }
}
