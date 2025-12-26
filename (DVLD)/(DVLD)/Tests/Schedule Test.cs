using BusinessLayer;
using DataAccessLayer;
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

namespace _DVLD_.TestForms
{
    public partial class Schedule_Test : Form
    {

        private int _LocalDrivingLicenseID = -1;
        private clsTestType.enTestType _TestsType;
        private int _AppointmentID = -1;
        public Schedule_Test(int localDrivingLicenceID , clsTestType.enTestType TestType ,int AppointmentID = -1)
        {
            InitializeComponent();

            _LocalDrivingLicenseID = localDrivingLicenceID;
            _TestsType = TestType;
            _AppointmentID = AppointmentID;
        }

        private void Schedule_Test_Load(object sender, EventArgs e)
        {
            clTestAppointment1.TestTypeID = _TestsType;
            clTestAppointment1.LoadInfo(_LocalDrivingLicenseID, _AppointmentID);
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
