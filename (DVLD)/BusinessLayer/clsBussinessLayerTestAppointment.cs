using DataAccessLayer;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace BusinessLayer
{
    public class clsBussinessLayerTestAppointment
    {

        enum enmode { Add = 1, Update = 2 }

        enmode Mode = enmode.Add;

            public int TestAppointmentID { get; set; }
            public clsTestType.enTestType TestTypeID { get; set; }
            public int LocalDrivingLicenceApplicationID { get; set; }
            public DateTime AppointmentDate { get; set; }
            public decimal PaidFees { get; set; }
            public int CreatedByUser { get; set; }
            public bool IsLocked { get; set; }    
            public int RetakeTestID { get; set; }
            public clsApplicationBusinessLayer RetakeTestInfo { get; set; }    

            public int TestID
            {
                get { return _GetTestID(); }
            }

            private int _GetTestID()
            {
               return clsDataAccessLayerTestAppointment.GetTestID(TestAppointmentID);
            }

        public clsBussinessLayerTestAppointment()
        {
            TestAppointmentID = -1;
            TestTypeID = clsTestType.enTestType.VisionTest;
            AppointmentDate = default(DateTime);
            PaidFees = 0;
            CreatedByUser = -1;
            IsLocked = false;
            RetakeTestID = -1;

            Mode = enmode.Add;
        }

        public clsBussinessLayerTestAppointment(int appID, clsTestType.enTestType testtypeid, int LDLAID, DateTime appointmentdate,decimal paidfees, int createdbyuser, bool islocked , int retakeid)
        {
            TestAppointmentID = appID;
            TestTypeID = testtypeid;
            LocalDrivingLicenceApplicationID = LDLAID;
            AppointmentDate = appointmentdate;
            PaidFees = paidfees;
            CreatedByUser = createdbyuser;
            IsLocked = islocked;
            RetakeTestID = retakeid;
            RetakeTestInfo = clsApplicationBusinessLayer.FindBaseApplication(RetakeTestID);
             Mode = enmode.Update;
        }

        private bool _AddNewTestAppointment()
        {
            //call DataAccess Layer 

            this.TestAppointmentID = clsDataAccessLayerTestAppointment.AddNewTestAppointment((int)this.TestTypeID, this.LocalDrivingLicenceApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUser, this.RetakeTestID);

            return (this.TestAppointmentID != -1);
        }

        private bool _UpdateTestAppointment()
        {
            //call DataAccess Layer 

            return clsDataAccessLayerTestAppointment.UpdateTestAppointment(this.TestAppointmentID, (int)this.TestTypeID, this.LocalDrivingLicenceApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUser, this.IsLocked, this.RetakeTestID);
        }

        public static clsBussinessLayerTestAppointment Find(int TestAppointmentID)
        {
            int testtype = -1 , LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now; decimal PaidFees = 0;
            int CreatedByUserID = -1; bool IsLocked = false; int RetakeTestApplicationID = -1;

            if (clsDataAccessLayerTestAppointment.GetTestAppointmentInfoByID(TestAppointmentID, ref testtype, ref LocalDrivingLicenseApplicationID,
            ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))

                return new clsBussinessLayerTestAppointment(TestAppointmentID, (clsTestType.enTestType)testtype, LocalDrivingLicenseApplicationID,
             AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            else
                return null;

        }

        public static clsBussinessLayerTestAppointment GetLastTestAppointment(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            int TestAppointmentID = -1;
            DateTime AppointmentDate = DateTime.Now; decimal PaidFees = 0;
            int CreatedByUserID = -1; bool IsLocked = false; int RetakeTestApplicationID = -1;

            if (clsDataAccessLayerTestAppointment.GetLastTestAppointment(LocalDrivingLicenseApplicationID,TestTypeID,
                ref TestAppointmentID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))

                return new clsBussinessLayerTestAppointment(TestAppointmentID, (clsTestType.enTestType)TestTypeID, LocalDrivingLicenseApplicationID,
             AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            else
                return null;
        }

        public static DataTable GetAllTestAppointments()
        {
            return clsDataAccessLayerTestAppointment.GetAllTestAppointments();
        }

        public DataTable GetApplicationTestAppointmentsPerTestType(int TestTypeID)
        {
            return clsDataAccessLayerTestAppointment.GetApplicationTestAppointmentsPerTestType(this.LocalDrivingLicenceApplicationID, TestTypeID);
        }

        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsDataAccessLayerTestAppointment.GetApplicationTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enmode.Add:
                    if (_AddNewTestAppointment())
                    {

                        Mode = enmode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enmode.Update:

                    return _UpdateTestAppointment();

            }

            return false;
        }




    }
}
