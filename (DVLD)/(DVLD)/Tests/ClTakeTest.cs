using _DVLD_.Properties;
using _DVLD_.TestForms;
using BusinessLayer;
using DVLD.Classes;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Buisness.clsTestType;

namespace _DVLD_.AllAboutTest
{
    public partial class ClTakeTest : UserControl
    {
        public ClTakeTest()
        {
            InitializeComponent();

        }

        private clsTestType.enTestType _TestType = enTestType.VisionTest;
        private int _TestID = -1;
        public clsTestType.enTestType TestTypeID
        {
            get
            {
                return _TestType;
            }
            set
            {
                _TestType = value;

                switch (_TestType)
                {

                    case clsTestType.enTestType.VisionTest:
                        {
                            groupBox1.Text = "Vision Test";
                            pictureBox1.Image = Resources.eye1;
                            break;
                        }

                    case clsTestType.enTestType.WrittenTest:
                        {
                            groupBox1.Text = "Written Test";
                            pictureBox1.Image = Resources.icons8_write_100;
                            break;
                        }
                    case clsTestType.enTestType.StreetTest:
                        {
                            groupBox1.Text = "Street Test";
                            pictureBox1.Image = Resources.icons8_driving_100;
                            break;
                        }
                }
            }
        }
        private int _TestAppointmentID = -1;

        clsLocalDrivingLicenseApplicaionBusiness _LocalDrivingLicenceApplication;
        clsBussinessLayerTestAppointment TestAppointment;
        private int _LocalDrivingLicenseApplicationID = -1;


        public int AppointmentID
        {
            get { return _TestAppointmentID; }
        }

        public int TestID
        {
            get { return _TestID; }
        }




        public void FillControleWithData(int TestAppointmentID)
        {
            _TestAppointmentID = TestAppointmentID;

            TestAppointment = clsBussinessLayerTestAppointment.Find(TestAppointmentID);

            if (TestAppointment == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }

            _TestID = TestAppointment.TestID;

            _LocalDrivingLicenseApplicationID = TestAppointment.LocalDrivingLicenceApplicationID;
            _LocalDrivingLicenceApplication = clsLocalDrivingLicenseApplicaionBusiness.FindByLocalDrivingAppLicenseID(TestAppointment.LocalDrivingLicenceApplicationID);

            if (_LocalDrivingLicenceApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LBLAPPID.Text = _LocalDrivingLicenceApplication.LocalDrivingLicenseApplicationID.ToString();
            LBLClass.Text = _LocalDrivingLicenceApplication.LicenceClassInfo.ClassName;
            LBLName.Text = _LocalDrivingLicenceApplication.PersonFullName;
            LBLTrial.Text = _LocalDrivingLicenceApplication.TotalTrialsPerTest(_TestType).ToString();
            LBLDate.Text = clsFormat.DateToShort(TestAppointment.AppointmentDate).ToString();
            LBLFees.Text = TestAppointment.PaidFees.ToString();
            LBLTestID.Text = (TestAppointment.TestID == -1) ? "Not Taken Yet" : TestAppointment.TestID.ToString();
        }


    }
}

