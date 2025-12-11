using _DVLD_.Licences;
using _DVLD_.TestForms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace _DVLD_.Applications
{
    public partial class FrmLocalDrivingLicenceApp : Form
    {
        public FrmLocalDrivingLicenceApp()
        {
            InitializeComponent();
        }

        DataTable Dt = new DataTable();

        void _FillCBWithColumns()
        {
            foreach (DataGridViewColumn Columns in DGVLocalDrivingLicenceApp.Columns)
            {
                CBSelect.Items.Add(Columns.HeaderText);
            }
            CBSelect.SelectedIndex = 0;
        }

        void _FillDataInDGV()
        {
            clsApplicationBusinessLayer App = new clsApplicationBusinessLayer();

            Dt = App.GetLDLAFromView();

            DGVLocalDrivingLicenceApp.Rows.Clear();

            foreach (DataRow Row in Dt.Rows)
            {
                int Count = DGVLocalDrivingLicenceApp.Rows.Add();

                DGVLocalDrivingLicenceApp.Rows[Count].Cells[0].Value = Row["LocalDrivingLicenceApplicationID"];
                        string LicenceType = App.GetClassName((int)Row["LicenceClassID"]);
                DGVLocalDrivingLicenceApp.Rows[Count].Cells[1].Value = LicenceType;
                DGVLocalDrivingLicenceApp.Rows[Count].Cells[2].Value = Row["NationalNo"];
                DGVLocalDrivingLicenceApp.Rows[Count].Cells[3].Value = Row["FullName"];
                DGVLocalDrivingLicenceApp.Rows[Count].Cells[4].Value = Row["ApplicationDate"];
                DGVLocalDrivingLicenceApp.Rows[Count].Cells[5].Value = Row["PassedTestCount"];
                DGVLocalDrivingLicenceApp.Rows[Count].Cells[6].Value = Row["Status"];
            }
            LBLRec.Text = DGVLocalDrivingLicenceApp.Rows.Count.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmNewDrivingLicenceApp Licence = new FrmNewDrivingLicenceApp();
            Licence.ShowDialog();
        }

        private void FrmLocalDrivingLicenceApp_Load(object sender, EventArgs e)
        {
            _FillDataInDGV();
            _FillCBWithColumns();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string comboboxSelect = CBSelect.SelectedItem.ToString();
            string text = textBox1.Text.Trim();

            DGVLocalDrivingLicenceApp.Rows.Clear();

            foreach (DataRow Row in Dt.Rows)
            {
                if (string.IsNullOrEmpty(textBox1.Text) || Row[comboboxSelect].ToString().IndexOf(text,StringComparison.OrdinalIgnoreCase)>=0) {

                    int Count = DGVLocalDrivingLicenceApp.Rows.Add();

                    DGVLocalDrivingLicenceApp.Rows[Count].Cells[0].Value = Row["LocalDrivingLicenceID"];
                    DGVLocalDrivingLicenceApp.Rows[Count].Cells[1].Value = Row["ClassName"];
                    DGVLocalDrivingLicenceApp.Rows[Count].Cells[2].Value = Row["NationalNo"];
                    DGVLocalDrivingLicenceApp.Rows[Count].Cells[3].Value = Row["FullName"];
                    DGVLocalDrivingLicenceApp.Rows[Count].Cells[4].Value = Row["ApplicationDate"];
                    DGVLocalDrivingLicenceApp.Rows[Count].Cells[5].Value = Row["PassedTest"];
                    DGVLocalDrivingLicenceApp.Rows[Count].Cells[6].Value = Row["Status"];

                }
            }

        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsApplicationBusinessLayer Application = new clsApplicationBusinessLayer();

            int LDLA = (int)DGVLocalDrivingLicenceApp.CurrentRow.Cells[0].Value;
            string CheckIfItsCancelledAlready = (string)DGVLocalDrivingLicenceApp.CurrentRow.Cells[6].Value;

            if (CheckIfItsCancelledAlready != "Cancelled")
            {
                if (MessageBox.Show("Are You Sure You Wanna Cancel This Order ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (Application.Cancel(LDLA))
                    {
                        MessageBox.Show(" The Order Cancelled Succesfly :)", "Conferm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _FillDataInDGV();
                    }
                    
                    else
                    {
                        MessageBox.Show("SomeThingWrongIN DB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    }
                }
            }
            else
            {
                MessageBox.Show("This Persone Is Already Cancelled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void ProccesOfTest(int PassedTest,string Status)
        {
            if (Status == "Cancelled")
            {
                showApplicationDetailsToolStripMenuItem.Enabled = false;
                editApplicationToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                sechduleDriveTestToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showApplicationDetailsToolStripMenuItem.Enabled = false;
                showPersoneLicenseHistoryToolStripMenuItem.Enabled = false;
                sechduleTestToolStripMenuItem.Enabled = false;
                showLicenToolStripMenuItem.Enabled = false;
                return;
            }else if (Status == "Completed")
            {
                showApplicationDetailsToolStripMenuItem.Enabled = true;
                showLicenToolStripMenuItem.Enabled = true;
                showPersoneLicenseHistoryToolStripMenuItem.Enabled = true;
                editApplicationToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                sechduleTestToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                return;
            }
            else
            {
                switch (PassedTest)
                {
                    case 0:
                        sechduleWrittenTestToolStripMenuItem.Enabled = false;
                        sechduleDriveTestToolStripMenuItem.Enabled = false;
                        issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                        showLicenToolStripMenuItem.Enabled = false;
                        showApplicationDetailsToolStripMenuItem.Enabled = true;
                        editApplicationToolStripMenuItem.Enabled = true;
                        deleteApplicationToolStripMenuItem.Enabled = true;
                        cancelApplicationToolStripMenuItem.Enabled = true;
                        sechduleTestToolStripMenuItem.Enabled = true;
                        break;

                    case 1:
                        issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                        showLicenToolStripMenuItem.Enabled = false;
                        sechToolStripMenuItem.Enabled = false;
                        sechduleDriveTestToolStripMenuItem.Enabled = false;
                        showApplicationDetailsToolStripMenuItem.Enabled = true;
                        editApplicationToolStripMenuItem.Enabled = true;
                        deleteApplicationToolStripMenuItem.Enabled = true;
                        cancelApplicationToolStripMenuItem.Enabled = true;
                        sechduleTestToolStripMenuItem.Enabled = true;
                        break;

                    case 2:
                        issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                        showLicenToolStripMenuItem.Enabled = false;
                        sechToolStripMenuItem.Enabled = false;
                        sechduleWrittenTestToolStripMenuItem.Enabled = false;
                        editApplicationToolStripMenuItem.Enabled = true;
                        deleteApplicationToolStripMenuItem.Enabled = true;
                        cancelApplicationToolStripMenuItem.Enabled = true;
                        sechduleTestToolStripMenuItem.Enabled = true;
                        break;

                    case 3:
                        editApplicationToolStripMenuItem.Enabled = true;
                        deleteApplicationToolStripMenuItem.Enabled = true;
                        cancelApplicationToolStripMenuItem.Enabled = true;
                        showPersoneLicenseHistoryToolStripMenuItem.Enabled = true;
                        showApplicationDetailsToolStripMenuItem.Enabled = true;
                        issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                        sechduleTestToolStripMenuItem.Enabled = false;

                        if (Status == "NEW")
                            showLicenToolStripMenuItem.Enabled = false;
                        break;
                }
            }
                

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            ProccesOfTest((int)DGVLocalDrivingLicenceApp.CurrentRow.Cells[5].Value, (string)DGVLocalDrivingLicenceApp.CurrentRow.Cells[6].Value);
        }

        private void sechToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test_Appointment Test = new Test_Appointment((int)DGVLocalDrivingLicenceApp.CurrentRow.Cells[0].Value, (int)DGVLocalDrivingLicenceApp.CurrentRow.Cells[5].Value, 1);
            Test.TestsLoad += _FillDataInDGV;
            Test.ShowDialog();
        }

        private void sechduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test_Appointment Test = new Test_Appointment((int)DGVLocalDrivingLicenceApp.CurrentRow.Cells[0].Value, (int)DGVLocalDrivingLicenceApp.CurrentRow.Cells[5].Value, 2);
            Test.TestsLoad += _FillDataInDGV;
            Test.ShowDialog();
        }

        private void sechduleDriveTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test_Appointment Test = new Test_Appointment((int)DGVLocalDrivingLicenceApp.CurrentRow.Cells[0].Value, (int)DGVLocalDrivingLicenceApp.CurrentRow.Cells[5].Value, 3);
            Test.TestsLoad += _FillDataInDGV;
            Test.ShowDialog();
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Issue_Driving_Licence Licence = new Issue_Driving_Licence((int)DGVLocalDrivingLicenceApp.CurrentRow.Cells[0].Value, (int)DGVLocalDrivingLicenceApp.CurrentRow.Cells[5].Value);
            Licence.ShowDialog();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsApplicationBusinessLayer Bus = new clsApplicationBusinessLayer();
            Bus.DeteleOrderLocal((int)DGVLocalDrivingLicenceApp.CurrentRow.Cells[0].Value);
        }

        private void showLicenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrivingLicenceDetails frm = new frmDrivingLicenceDetails((int)DGVLocalDrivingLicenceApp.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showPersoneLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLicenceHistory History = new FrmLicenceHistory((int)DGVLocalDrivingLicenceApp.CurrentRow.Cells[0].Value);
            History.ShowDialog();
        }
    }
}
