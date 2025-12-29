using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Deployment.Internal;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static BusinessLayer.clsApplication;
using static System.Net.Mime.MediaTypeNames;


namespace BusinessLayer
{
    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };

        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };

        public int ApplicationId { get; set; }
        public int AppPersoneId { get; set; }
        public clsPersone PersonInfo;
        public DateTime AppDate { get; set; }
        public enApplicationStatus AppStatus { get; set; }
        public int AppType { get; set; }
        public clsApplicationType ApplicationTypeInfo;
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUserBusiness CreatedByUserInfo;
        public string StatusText
        {
            get
            {
                switch (AppStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }
        }

        public clsApplication()
        {
            ApplicationId = -1;
            AppPersoneId = -1;
            AppDate = default(DateTime);
            AppStatus = enApplicationStatus.New;
            AppType = -1;
            LastStatusDate = default(DateTime);
            PaidFees = default(decimal);
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        public clsApplication(int appid, int personeid, DateTime Date, int apptypeid, enApplicationStatus status, DateTime LastStatus, decimal fees, int createdbyuser)
        {
            ApplicationId = appid;
            AppPersoneId = personeid;
            PersonInfo = clsPersone.FindPersoneByPerId(personeid);
            AppDate = Date;
            AppType = apptypeid;
            ApplicationTypeInfo = clsApplicationType.Find(apptypeid);
            AppStatus = status;
            LastStatusDate = LastStatus;
            PaidFees = fees;
            CreatedByUserID = createdbyuser;
            CreatedByUserInfo = clsUserBusiness.FindByUserID(createdbyuser);

            Mode = enMode.Update;
        }

        private bool _AddApp()
        {
            this.ApplicationId = clsDataAccessLayerApplication.AddNewApplication(AppPersoneId, AppDate, AppType, (byte)AppStatus, LastStatusDate, PaidFees, CreatedByUserID);
            return (this.ApplicationId != -1);
        }

        private bool _UpdateAppCompleted()
        {
            return clsDataAccessLayerApplication.UpdateApplication(this.ApplicationId,this.AppPersoneId,this.AppDate,this.AppType,(byte)this.AppStatus,this.LastStatusDate,this.PaidFees,this.CreatedByUserID);
        }

        public bool Cancel()
        {
            return clsDataAccessLayerApplication.UpdateStatus(ApplicationId, 2);
        }

        public bool SetComplete()
        {
            return clsDataAccessLayerApplication.UpdateStatus(ApplicationId, 3);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddApp())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateAppCompleted();
            }

            return false;

        }

        public static clsApplication FindBaseApplication(int RefAppID)
        {
            int personeid = -1, apptypeid = -1, createdbyuser = -1;
            DateTime Date = default(DateTime), LastStatus = default(DateTime);
                byte status = 0;
                decimal fees = 0; 

            if (clsDataAccessLayerApplication.GetApplicationInfoByID(RefAppID, ref personeid, ref Date, ref apptypeid, ref status, ref LastStatus, ref fees, ref createdbyuser))
            {
                return new clsApplication(RefAppID, personeid, Date, apptypeid, (enApplicationStatus)status, LastStatus, fees, createdbyuser);
            }
            else
            {
                return null;
            }
        }

        public bool DeteleApp(int Delete)
        {
            return clsDataAccessLayerApplication.DeleteApplication(Delete);
        }

        public bool Detele()
        {
            return clsDataAccessLayerApplication.DeleteApplication(this.ApplicationId);
        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            return clsDataAccessLayerApplication.IsApplicationExist(ApplicationID);
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return clsDataAccessLayerApplication.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }

        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID)
        {
            return DoesPersonHaveActiveApplication(this.ApplicationId, ApplicationTypeID);
        }

        public static int GetActiveApplicationID(int PersonID, enApplicationType ApplicationTypeID)
        {
            return clsDataAccessLayerApplication.GetActiveApplicationID(PersonID, (int)ApplicationTypeID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsDataAccessLayerApplication.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

        public int GetActiveApplicationID(enApplicationType ApplicationTypeID)
        {
            return GetActiveApplicationID(this.ApplicationId, ApplicationTypeID);
        }




    }
}
