using _DVLD_.Properties;
using BusinessLayer;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Buisness.clsTestType;

namespace _DVLD_.TestForms
{
    public partial class Test_Appointment : Form
    {
        private DataTable dtAppointments;
        private int _LocalDrivingLicenseAppID;
        private clsTestType.enTestType _TestTypes;

        public Test_Appointment(int localDrivingLicenceAppID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenseAppID = localDrivingLicenceAppID;
            _TestTypes = TestType;
        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestTypes)
            {

                case clsTestType.enTestType.VisionTest:
                    {
                        LBLTitle.Text = "Vision Test Appointments";
                        this.Text = LBLTitle.Text;
                        pbTestTypeImage.Image = Resources.eye1;
                        break;
                    }

                case clsTestType.enTestType.WrittenTest:
                    {
                        LBLTitle.Text = "Written Test Appointments";
                        this.Text = LBLTitle.Text;
                        pbTestTypeImage.Image = Resources.icons8_write_100;
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        LBLTitle.Text = "Street Test Appointments";
                        this.Text = LBLTitle.Text;
                        pbTestTypeImage.Image = Resources.icons8_driving_100;
                        break;
                    }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Schedule_Test Schedule = new Schedule_Test(_LocalDrivingLicenseAppID, _TestTypes, (int)DGVAppointments.CurrentRow.Cells[0].Value);
            Schedule.ShowDialog();
            Test_Appointment_Load(null,null);
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplicaionBusiness Local = clsLocalDrivingLicenseApplicaionBusiness.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseAppID);

            if (Local.IsThereAnActiveScheduledTest(_TestTypes))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsBusinessTest LastTest = Local.GetLastTestPerTestType(_TestTypes);

            if (LastTest == null)
            {
                Schedule_Test Frm = new Schedule_Test(_LocalDrivingLicenseAppID,_TestTypes);
                Frm.ShowDialog();
                Test_Appointment_Load(null, null);
                return;
            }

            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Schedule_Test frm1 = new Schedule_Test
                (LastTest.TestAppointmentInfo.LocalDrivingLicenceApplicationID, _TestTypes);
            frm1.ShowDialog();
            Test_Appointment_Load(null, null);
        }

        private void Test_Appointment_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();

            ctrlDrivingLicenseApp1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseAppID);
            dtAppointments = clsBussinessLayerTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseAppID,(int)_TestTypes);

            DGVAppointments.DataSource = dtAppointments;
            LBLRec.Text = dtAppointments.Rows.Count.ToString();

            if (DGVAppointments.Rows.Count > 0)
            {
                DGVAppointments.Columns[0].HeaderText = "Appointment ID";
                DGVAppointments.Columns[0].Width = 150;

                DGVAppointments.Columns[1].HeaderText = "Appointment Date";
                DGVAppointments.Columns[1].Width = 200;

                DGVAppointments.Columns[2].HeaderText = "Paid Fees";
                DGVAppointments.Columns[2].Width = 150;

                DGVAppointments.Columns[3].HeaderText = "Is Locked";
                DGVAppointments.Columns[3].Width = 100;
            }
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Take_Test Test = new Take_Test((int)DGVAppointments.CurrentRow.Cells[0].Value,_TestTypes);
            Test.ShowDialog();
            Test_Appointment_Load(null,null);
        }
    }
}
