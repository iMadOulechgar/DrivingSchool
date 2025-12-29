using DVLD_Buisness;
using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsLocalDrivingLicenseApplicaionBusiness : clsApplication
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LocalDrivingLicenseApplicationID { set; get; }
        public int LicenseClassID { set; get; }
        public clsLicenseClass LicenceClassInfo;
        public string PersonFullName
        {
            get
            {
                return base.PersonInfo.FullName;
            }
        }

        public clsLocalDrivingLicenseApplicaionBusiness()

        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;


            Mode = enMode.AddNew;

        }

        private clsLocalDrivingLicenseApplicaionBusiness(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, int ApplicationTypeID,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             decimal PaidFees, int CreatedByUserID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationId = ApplicationID;
            this.AppPersoneId = ApplicantPersonID;
            base.PersonInfo = clsPersone.FindPersoneByPerId(AppPersoneId);
            this.AppDate = ApplicationDate;
            this.AppType =(int)ApplicationTypeID;
            this.AppStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;
            this.LicenceClassInfo = clsLicenseClass.Find(LicenseClassID);
            Mode = enMode.Update;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            //call DataAccess Layer 

            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication
                (
                this.ApplicationId, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            //call DataAccess Layer 

            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication
                (
                this.LocalDrivingLicenseApplicationID, this.ApplicationId, this.LicenseClassID);
        }

        public static clsLocalDrivingLicenseApplicaionBusiness FindByLocalDrivingAppLicenseID(int LocalDrivingLicenseApplicationID)
        { 
            int ApplicationID = -1, LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByID
                (LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID);


            if (IsFound)
            {
                //now we find the base application
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                //we return new object of that person with the right data
                return new clsLocalDrivingLicenseApplicaionBusiness(
                    LocalDrivingLicenseApplicationID, Application.ApplicationId,
                    Application.AppPersoneId,
                                     Application.AppDate, Application.AppType,
                                    (enApplicationStatus)Application.AppStatus, Application.LastStatusDate,
                                     Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;
        }

        public static clsLocalDrivingLicenseApplicaionBusiness FindByApplicationID(int ApplicationID)
        {
            // 
            int LocalDrivingLicenseApplicationID = -1, LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByApplicationID
                (ApplicationID, ref LocalDrivingLicenseApplicationID, ref LicenseClassID);


            if (IsFound)
            {
                //now we find the base application
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                return new clsLocalDrivingLicenseApplicaionBusiness(
                     LocalDrivingLicenseApplicationID, Application.ApplicationId,
                     Application.AppPersoneId,
                                      Application.AppDate, Application.AppType,
                                     (enApplicationStatus)Application.AppStatus, Application.LastStatusDate,
                                      Application.PaidFees, Application.CreatedByUserID, LicenseClassID);

            }
            else
                return null;
        }

        public bool Save()
        {
            //Because of inheritance first we call the save method in the base class,
            //it will take care of adding all information to the application table.
            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())
                return false;


            //After we save the main application now we save the sub application.
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLocalDrivingLicenseApplication();

            }

            return false;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }

        public bool Delete()
        {
            bool IsLocalDrivingApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;
            //First we delete the Local Driving License Application
            IsLocalDrivingApplicationDeleted = clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID);

            if (!IsLocalDrivingApplicationDeleted)
                return false;
            //Then we delete the base Application
            IsBaseApplicationDeleted = base.Detele();
            return IsBaseApplicationDeleted;

        }

        public bool DoesPassTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesAttendTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public byte TotalTrialsPerTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool IsThereAnActiveScheduledTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public clsBusinessTest GetLastTestPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsBusinessTest.FindLastTestPerPersonAndLicenseClass(this.ApplicationId, this.LicenseClassID, TestTypeID);
        }

        public bool PassedAllTests()
        {
            return clsBusinessTest.PassedAllTests(this.LocalDrivingLicenseApplicationID);
        }

        public int GetActiveLicenseID()
        {//this will get the license id that belongs to this application
            return clsBusinessLayerLicences.GetActiveLicenseIDByPersonID(this.AppPersoneId, this.LicenseClassID);
        }

        public int IssueLicenseForTheFirtTime(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;

            clsBusinessLayerDrivers Driver = clsBusinessLayerDrivers.FindByPersonID(this.AppPersoneId);

            if (Driver == null)
            {
                //we check if the driver already there for this person.
                Driver = new clsBusinessLayerDrivers();

                Driver.PersonID = this.AppPersoneId;
                Driver.CreatedByUserID = CreatedByUserID;
                if (Driver.save())
                {
                    DriverID = Driver.DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID = Driver.DriverID;
            }
            //now we diver is there, so we add new licesnse

            clsBusinessLayerLicences License = new clsBusinessLayerLicences();
            License.ApplicationID = this.ApplicationId;
            License.DriverID = DriverID;
            License.LicenseClass = this.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(this.LicenceClassInfo.DefaultValidityLength);
            License.Notes = Notes;
            License.PaidFees = this.LicenceClassInfo.ClassFees;
            License.IsActive = true;
            License.IssueReason = clsBusinessLayerLicences.enIssueReason.FirstTime;
            License.CreatedByUserID = CreatedByUserID;

            if (License.Save())
            {
                //now we should set the application status to complete.
                this.SetComplete();
                return License.LicenseID;
            }
            else
                return -1;
        }

        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }

    }
}
