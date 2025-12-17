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

        DataTable Dt = new DataTable();

        void _FillCBWithColumns()
        {
            CBSelect.Items.Add("None");
            foreach (DataGridViewColumn Columns in DGVDetainedLicenses.Columns)
            {
                CBSelect.Items.Add(Columns.HeaderText);
            }
            CBSelect.SelectedIndex = 0;
        }

        void FillDataInDataGridView()
        {
            clsBussinessLayerDetainedLicense Detain = new clsBussinessLayerDetainedLicense();

            Dt = Detain.GetAllDataToDt();
            
            DGVDetainedLicenses.Rows.Clear();

            foreach (DataRow Row in Dt.Rows)
            {
                int Count = DGVDetainedLicenses.Rows.Add();

                DGVDetainedLicenses.Rows[Count].Cells[0].Value = Row["DetainID"];
                DGVDetainedLicenses.Rows[Count].Cells[1].Value = Row["LicenceID"];
                DGVDetainedLicenses.Rows[Count].Cells[2].Value = Row["DetainDate"];
                DGVDetainedLicenses.Rows[Count].Cells[3].Value = Row["IsReleased"];
                DGVDetainedLicenses.Rows[Count].Cells[4].Value = Row["FineFees"];
                DGVDetainedLicenses.Rows[Count].Cells[5].Value = Row["ReleasedDate"];
                DGVDetainedLicenses.Rows[Count].Cells[6].Value = Row["NationalNo"];
                DGVDetainedLicenses.Rows[Count].Cells[7].Value = Row["FullName"];
                DGVDetainedLicenses.Rows[Count].Cells[8].Value = Row["ReleaseApplicationID"];
            }
            LBLRec.Text = DGVDetainedLicenses.Rows.Count.ToString();
        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            FillDataInDataGridView();
            _FillCBWithColumns();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string comboboxSelect = CBSelect.SelectedItem.ToString();
            string text = textBox1.Text.Trim();

            DGVDetainedLicenses.Rows.Clear();

            foreach (DataRow Row in Dt.Rows)
            {
                if (string.IsNullOrEmpty(textBox1.Text) || Row[comboboxSelect].ToString().IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    int Count = DGVDetainedLicenses.Rows.Add();

                    DGVDetainedLicenses.Rows[Count].Cells[0].Value = Row["DetainID"];
                    DGVDetainedLicenses.Rows[Count].Cells[1].Value = Row["LicenceID"];
                    DGVDetainedLicenses.Rows[Count].Cells[2].Value = Row["DetainDate"];
                    DGVDetainedLicenses.Rows[Count].Cells[3].Value = Row["IsReleased"];
                    DGVDetainedLicenses.Rows[Count].Cells[4].Value = Row["FineFees"];
                    DGVDetainedLicenses.Rows[Count].Cells[5].Value = Row["ReleasedDate"];
                    DGVDetainedLicenses.Rows[Count].Cells[6].Value = Row["NationalNo"];
                    DGVDetainedLicenses.Rows[Count].Cells[7].Value = Row["FullName"];
                    DGVDetainedLicenses.Rows[Count].Cells[8].Value = Row["ReleaseApplicationID"];
                }
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDetails PersonDetails = new ShowDetails((string)DGVDetainedLicenses.CurrentRow.Cells[6].Value);
            PersonDetails.Show();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrivingLicenceDetails details = new frmDrivingLicenceDetails();
            details.FillData((int)DGVDetainedLicenses.CurrentRow.Cells[1].Value);
            details.ShowDialog();
        }
        clsBusinessPersone Person;
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLicenceHistory History = new FrmLicenceHistory();
            clsBusinessPersone Per = new clsBusinessPersone();
            //Person = Per.FindPersoneByNationalNo((string)DGVDetainedLicenses.CurrentRow.Cells[6].Value);
            History.FillByDetained(Person.PersonID, (int)DGVDetainedLicenses.CurrentRow.Cells[1].Value);
            History.ShowDialog();
        }

        private void showDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenses Released = new frmReleaseDetainedLicenses((int)DGVDetainedLicenses.CurrentRow.Cells[1].Value);
            Released.ShowDialog();
        }
    }
}
