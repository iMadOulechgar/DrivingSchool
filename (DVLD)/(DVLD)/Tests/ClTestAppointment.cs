using _DVLD_.Properties;
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
using static DVLD_Buisness.clsTestType;

namespace _DVLD_.AllAboutTest
{
    public partial class ClTestAppointment : UserControl
    {
        public ClTestAppointment()
        {
            InitializeComponent();
        }

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 };
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private clsLocalDrivingLicenseApplicaionBusiness _LocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsBussinessLayerTestAppointment _TestAppointment;
        private int _TestAppointmentID = -1;

        public clsTestType.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {

                    case clsTestType.enTestType.VisionTest:
                        {
                            LBLTitle.Text = "Vision Test";
                            PBTests.Image = Resources.icons8_eyes_64;
                            break;
                        }

                    case clsTestType.enTestType.WrittenTest:
                        {
                            LBLTitle.Text = "Written Test";
                            PBTests.Image = Resources.icons8_write_100;
                            break;
                        }
                    case clsTestType.enTestType.StreetTest:
                        {
                            LBLTitle.Text = "Street Test";
                            PBTests.Image = Resources.icons8_driving_100;
                            break;
                        }
                }
            }
        }


        public void LoadInfo(int LocalDrivingLicenseAppID , int AppointmentID = -1)
        {
            if (AppointmentID != -1)
                _Mode = enMode.Update;
            else
                _Mode = enMode.AddNew;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseAppID;
            _TestAppointmentID = AppointmentID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplicaionBusiness.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BTNsave.Enabled = false;
                return;
            }

            if (_LocalDrivingLicenseApplication.DoesAttendTestType(_TestTypeID))
                _CreationMode = enCreationMode.RetakeTestSchedule;
            else
                _CreationMode = enCreationMode.FirstTimeSchedule;

            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                LBLRetakeFees.Text = clsBusinessApplicationType.Find((int)clsApplicationBusinessLayer.enApplicationType.RetakeTest).AppFees.ToString();
                gbRetakeTest.Enabled = true;
                LBLTitle.Text = "Schedule Retake Test";
                LBLAppointmentID.Text = "0";
            }
            else
            {
                gbRetakeTest.Enabled = false;
                LBLTitle.Text = "Schedule Retake Test";
                LBLAppointmentID.Text = "N/A";
                LBLRetakeFees.Text = "0";
            }

            LBLAPPID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            LBLClass.Text = _LocalDrivingLicenseApplication.LicenceClassInfo.ClassName;
            LBLNAME.Text = _LocalDrivingLicenseApplication.PersonFullName;
            LBLTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();


            if (_Mode == enMode.AddNew)
            {
                dateTimePicker1.MinDate = DateTime.Now;
                LBLAppointmentID.Text = "N/A";
                LBLfees.Text = clsTestType.Find(_TestTypeID).Fees.ToString();
            }
            else
            {
                if (!_LoadTestAppointmentData())
                    return;
            }

            LBLTotalFees.Text = (Convert.ToSingle(LBLfees) + Convert.ToSingle(LBLRetakeFees)).ToString();

            if (!_HandleActiveTestAppointmentConstraint())
                return;
            if (!_HandleAppointmentLockedConstraint())
                return;
            if (!_HandlePrviousTestConstraint())
                return;


        }


        private bool _HandlePrviousTestConstraint()
        {
            //we need to make sure that this person passed the prvious required test before apply to the new test.
            //person cannno apply for written test unless s/he passes the vision test.
            //person cannot apply for street test unless s/he passes the written test.

            switch (TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    //in this case no required prvious test to pass.
                    LBLmessage.Visible = false;

                    return true;

                case clsTestType.enTestType.WrittenTest:
                    //Written Test, you cannot sechdule it before person passes the vision test.
                    //we check if pass visiontest 1.
                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest))
                    {
                        LBLmessage.Text = "Cannot Sechule, Vision Test should be passed first";
                        LBLmessage.Visible = true;
                        BTNsave.Enabled = false;
                        dateTimePicker1.Enabled = false;
                        return false;
                    }
                    else
                    {
                        LBLmessage.Visible = false;
                        BTNsave.Enabled = true;
                        dateTimePicker1.Enabled = true;
                    }

                    return true;

                case clsTestType.enTestType.StreetTest:

                    //Street Test, you cannot sechdule it before person passes the written test.
                    //we check if pass Written 2.
                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest))
                    {
                        LBLmessage.Text = "Cannot Sechule, Written Test should be passed first";
                        LBLmessage.Visible = true;
                        BTNsave.Enabled = false;
                        dateTimePicker1.Enabled = false;
                        return false;
                    }
                    else
                    {
                        LBLmessage.Visible = false;
                        BTNsave.Enabled = true;
                        dateTimePicker1.Enabled = true;
                    }

                    return true;

            }
            return true;

        }

        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (_Mode == enMode.AddNew && clsLocalDrivingLicenseApplicaionBusiness.IsThereAnActiveScheduledTest(_LocalDrivingLicenseApplicationID, _TestTypeID))
            {
                LBLmessage.Text = "Person Already have an active appointment for this test";
                BTNsave.Enabled = false;
                dateTimePicker1.Enabled = false;
                return false;
            }

            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            //if appointment is locked that means the person already sat for this test
            //we cannot update locked appointment
            if (_TestAppointment.IsLocked)
            {
                LBLmessage.Visible = true;
                LBLmessage.Text = "Person already sat for the test, appointment loacked.";
                dateTimePicker1.Enabled = false;
                BTNsave.Enabled = false;
                return false;
            }
            else
                LBLmessage.Visible = false;

            return true;
        }

        private bool _LoadTestAppointmentData()
        {
            _TestAppointment = clsBussinessLayerTestAppointment.Find(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID.ToString(),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BTNsave.Enabled = false;
                return false;
            }

            LBLfees.Text = _TestAppointment.PaidFees.ToString();

            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                dateTimePicker1.MinDate = DateTime.Now;
            else
                dateTimePicker1.MinDate = _TestAppointment.AppointmentDate;


            dateTimePicker1.Value = _TestAppointment.AppointmentDate;

            if (_TestAppointment.RetakeTestID == -1)
            {
                LBLRetakeFees.Text = "0";
                LBLAppointmentID.Text = "N/A";
            }
            else
            {
                LBLRetakeFees.Text = _TestAppointment.RetakeTestInfo.PaidFees.ToString();
                groupBox1.Enabled = true;
                LBLTitle.Text = "Schedule Retake Test";
                LBLAppointmentID.Text = _TestAppointment.RetakeTestID.ToString();
            }
            return true;
        }

        private bool _HandleRetakeApplication()
        {
            //this will decide to create a seperate application for retake test or not.
            // and will create it if needed , then it will linkit to the appoinment.
            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                //incase the mode is add new and creation mode is retake test we should create a seperate application for it.
                //then we linke it with the appointment.

                //First Create Applicaiton 
                clsApplicationBusinessLayer Application = new clsApplicationBusinessLayer();

                Application.AppPersoneId = _LocalDrivingLicenseApplication.AppPersoneId;
                Application.AppDate = DateTime.Now;
                Application.AppType = (int)clsApplicationBusinessLayer.enApplicationType.RetakeTest;
                Application.AppStatus = clsApplicationBusinessLayer.enApplicationStatus.Completed;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = clsBusinessApplicationType.Find((int)clsApplicationBusinessLayer.enApplicationType.RetakeTest).AppFees;
                Application.CreatedByUserID = clsGlobal.UserLogin.UserID;

                if (!Application.Save())
                {
                    _TestAppointment.RetakeTestID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestID = Application.ApplicationId;

            }
            return true;
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplication())
                return;

            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LocalDrivingLicenceApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dateTimePicker1.Value;
            _TestAppointment.PaidFees = Convert.ToDecimal(LBLfees.Text);
            _TestAppointment.CreatedByUser = clsGlobal.UserLogin.UserID;

            if (_TestAppointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
