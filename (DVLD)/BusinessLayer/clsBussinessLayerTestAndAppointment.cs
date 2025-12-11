using DataAccessLayer;
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
    public class clsBussinessLayerTestAndAppointment
    {
        enum enAppOrTest { Appointment = 1,Test = 2}

        enAppOrTest AppOrTest;
        enum enmode { Add = 1, Update = 2 }

        enmode Mode;

        public struct stTestAppointement
        {
            public int TestAppointmentID { get; set; }
            public int TestTypeID { get; set; }
            public int LocalDrivingLicenceApplicationID { get; set; }
            public DateTime AppointmentDate { get; set; }
            public decimal PaidFees { get; set; }
            public int CreatedByUser { get; set; }
            public bool IsLocked { get; set; }
        }

        public struct stTest
        {
            public int TestID { get; set; }
            public int TestAppointID { get; set; }
            public byte TestResult { get; set; }
            public string Notes { get; set; }
            public int CreateByUserID { get; set; }
        }

        public stTest Test;
        public stTestAppointement TestAppointement;
        public int testOrAppointment {get;set;}

        enAppOrTest FromNumberTooEnum(int Num)
        {
            return (enAppOrTest)Num;
        }

        public clsBussinessLayerTestAndAppointment()
        {
                TestAppointement.TestAppointmentID = -1;
                TestAppointement.TestTypeID = -1;
                TestAppointement.AppointmentDate = default(DateTime);
                TestAppointement.PaidFees = 0;
                TestAppointement.CreatedByUser = -1;
                TestAppointement.IsLocked = false;

                Test.TestID = -1;
                Test.TestAppointID = -1;
                Test.TestResult = 0;
                Test.Notes = "";
                Test.CreateByUserID = -1;

            Mode = enmode.Add;
        }

        public clsBussinessLayerTestAndAppointment(int appID, int TestTypeID, int LDLAID, DateTime AppointmentDate,decimal PaidFees , int CreatedByUser , bool islocked)
        {
            TestAppointement.TestAppointmentID = appID;
            TestAppointement.TestTypeID = TestTypeID;
            TestAppointement.LocalDrivingLicenceApplicationID = LDLAID;
            TestAppointement.AppointmentDate = AppointmentDate;
            TestAppointement.PaidFees = PaidFees;
            TestAppointement.CreatedByUser = CreatedByUser;
            TestAppointement.IsLocked = islocked;

             Mode = enmode.Update;
        }


         

        

        public bool IsRowsExist(int Localid , int TypeTest)
        {
            return clsDataAccessLayerTestAppointmentAndTest.IsRowsExists(Localid, TypeTest);
        }

        public bool CheckIfHasAlreadyAnAppoinActive(int TestType)
        {
            return clsDataAccessLayerTestAppointmentAndTest.CheckIfIsThereAlreadyAnAppointment(TestType);
        }

        public DataTable GetDataAppointment(int LocalId,int TypeTest)
        {
            return clsDataAccessLayerTestAppointmentAndTest.GetAllAppointmentFromDB(LocalId, TypeTest);
        }

        private bool _AddTest()
        {
            int TestResultId = clsDataAccessLayerTestAppointmentAndTest.AddTest(this.Test.TestAppointID, this.Test.TestResult, this.Test.Notes, this.Test.CreateByUserID);
            return (TestResultId != -1);
        }

        private bool _AddTestAppointement()
        {
            int Num = -1;
            Num = clsDataAccessLayerTestAppointmentAndTest.AddTestAppointment(this.TestAppointement.TestTypeID,this.TestAppointement.LocalDrivingLicenceApplicationID,this.TestAppointement.AppointmentDate,this.TestAppointement.PaidFees,this.TestAppointement.CreatedByUser,this.TestAppointement.IsLocked);
            return (Num != -1);
        }

        private bool _Update()
        {
            return clsDataAccessLayerTestAppointmentAndTest.UpdateDateOfAnAppointment(this.TestAppointement.TestAppointmentID,this.TestAppointement.AppointmentDate);
        }

        public clsBussinessLayerTestAndAppointment Find(int AppID)
        {

            DateTime AppointmentDate = default(DateTime);
            int appID = AppID, TestTypeID = -1, LDLAID = -1, CreatedByUser = -1;
                decimal PaidFees = -1;
                bool islocked = false;


            if (clsDataAccessLayerTestAppointmentAndTest.FindAppinttmentByAppID(ref appID, ref TestTypeID, ref LDLAID, ref AppointmentDate, ref PaidFees, ref CreatedByUser, ref islocked))
            {
                return new clsBussinessLayerTestAndAppointment(appID,TestTypeID,LDLAID,AppointmentDate,PaidFees,CreatedByUser,islocked);
            }
            else
            {
                return null;
            }
        }

        public decimal GetPaidFees(int TestTypeID)
        {
            return clsDataAccessLayerTestAppointmentAndTest.PaidFees(TestTypeID);
        }

        public bool Save()
        {
            AppOrTest = FromNumberTooEnum(testOrAppointment);

            if (AppOrTest == enAppOrTest.Appointment)
            {
                switch (Mode)
                {
                    case enmode.Add:
                        if (_AddTestAppointement())
                        {
                            return true;
                        }
                        break;
                    case enmode.Update:
                        if (_Update())
                        {
                            return true;
                        }
                        break;
                }
            }
            else
            {
                switch (Mode)
                {
                    case enmode.Add:
                        if (_AddTest())
                        {
                            return true;
                        }
                     break;
                }
            }

            return false;
        }
       
        public bool checkResult(int localID,int TestType)
        {
            return clsDataAccessLayerTestAppointmentAndTest.CheckIfPass(localID, TestType);
        }

        public bool UpdateTheOrder(int AppID , int Type)
        {
            return clsDataAccessLayerTestAppointmentAndTest.UpdateAppTypeByAppId(AppID,Type);
        }

        public bool Lock(int AppTestID)
        {
            return clsDataAccessLayerTestAppointmentAndTest.LockTheAppointmentWhenTheTestIsFinish(AppTestID); 
        }

        public int Trial(int ID , int Type)
        {
            return clsDataAccessLayerTestAppointmentAndTest.GetTrialByLDLIDandTestType(ID , Type);
        }
        
        public int CheckIsItCompleted(int LocalID)
        {
            return clsDataAccessLayerTestAppointmentAndTest.GetTestTypeByLocalID(LocalID);
        }


    }
}
