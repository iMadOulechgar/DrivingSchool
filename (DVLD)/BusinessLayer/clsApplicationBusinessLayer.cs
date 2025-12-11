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


namespace BusinessLayer
{
    public class clsApplicationBusinessLayer
    {
        public enum enMode { Add = 1 , Update = 2 , Stop = 3}

        public enMode Mode ;

        public struct Applications
        {
            public int ApplicationId { get; set; }
            public int AppPersoneId { get; set; }
            public DateTime AppDate { get; set; }
            public byte AppStatus { get; set; }
            public int AppType { get; set; }
            public DateTime LastStatusDate { get; set; }
            public decimal PaidFees { get; set; }
            public int CreatedByUserID { get; set; }
        }

        public struct LocalDrivingLicenceApp
        {
            public int LocalDrivingLicenceAppLicationID { get; set; }
            public int AppID { get; set; }
            public int LicenceClasses { get; set; }
        } 
        
        public Applications App;
        public LocalDrivingLicenceApp LocalApp;

        public clsApplicationBusinessLayer()
        {
            App.ApplicationId = -1;
            App.AppPersoneId = -1;
            App.AppDate = default(DateTime);
            App.AppStatus = 0;
            App.LastStatusDate = default(DateTime);
            App.PaidFees = default(decimal);
            App.CreatedByUserID = -1;

            Mode = enMode.Add;
        }

        public clsApplicationBusinessLayer(int local , int appid , int licenceclass , int personeid , DateTime Date , int apptypeid , byte status ,DateTime LastStatus , decimal fees , int createdbyuser)

        {
            App.ApplicationId = appid;
            App.AppPersoneId = personeid;
            App.AppDate = Date;
            App.AppType = apptypeid;
            App.AppStatus = status;
            App.LastStatusDate = LastStatus;
            App.PaidFees = fees;
            App.CreatedByUserID = createdbyuser;
            LocalApp.LocalDrivingLicenceAppLicationID = local;
            LocalApp.AppID = appid;
            LocalApp.LicenceClasses = licenceclass;

            Mode = enMode.Update;
        }

        public clsApplicationBusinessLayer(int appid, int personeid, DateTime Date, int apptypeid, byte status, DateTime LastStatus, decimal fees, int createdbyuser)

        {
            App.ApplicationId = appid;
            App.AppPersoneId = personeid;
            App.AppDate = Date;
            App.AppType = apptypeid;
            App.AppStatus = status;
            App.LastStatusDate = LastStatus;
            App.PaidFees = fees;
            App.CreatedByUserID = createdbyuser;

            Mode = enMode.Update;
        }

        public bool Exists(int PersonID, int LicenceClass)
        {
            return clsDataAccessLayerApplication.CheckPersoneHasSameOrder(PersonID, LicenceClass);
        }

        private bool _AddLocalDrivingLicenceApplication()
        {
            App.ApplicationId = clsDataAccessLayerApplication.AddApplication(App.AppPersoneId,App.AppDate, App.AppStatus, App.AppType,App.LastStatusDate,App.PaidFees,App.CreatedByUserID);
            LocalApp.LocalDrivingLicenceAppLicationID = clsDataAccessLayerApplication.AddLocalDrivingLicenceApp(App.ApplicationId, LocalApp.LicenceClasses);
            return (App.ApplicationId != -1 && LocalApp.LocalDrivingLicenceAppLicationID != -1);
        }

        private bool _AddApp()
        {
            App.ApplicationId = clsDataAccessLayerApplication.AddApplication(App.AppPersoneId, App.AppDate, App.AppStatus, App.AppType, App.LastStatusDate, App.PaidFees, App.CreatedByUserID);
            return (App.ApplicationId != -1);
        }

        public bool SaveAddAppCanBeChange()
        {
            if (_AddApp())
            {
                return true;
            }
            return false;
        } 

        private bool _UpdateAppCompleted()
        {
            return clsDataAccessLayerApplication.UpdateApplicationComplet(this.App.ApplicationId);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddLocalDrivingLicenceApplication())
                    {
                        Mode = enMode.Stop;
                        return true;
                    }
                break;
                    case enMode.Update:
                    if (_UpdateAppCompleted())
                    {
                        return true;
                    }
                    break;
            }

            return false;

        }

        public DataTable GetAllLicenceClasses()
        {
            return clsDataAccessLayerApplication.GetAllLicenceClassesNames();
        }

        public DataTable GetLDLAFromView()
        {
            return clsDataAccessLayerApplication.GetLocalDrivingLicenceAppFromView();
        }

        public bool Cancel(int LocalID)
        {
            return clsDataAccessLayerApplication.CancelTheOrder(LocalID);
        }

        public int GetPersoneIDFromLDLA(int ID)
        {
            return clsDataAccessLayerApplication.GetPersoneIdByLocalDrivingLicenceApp(ID);
        }

        public clsApplicationBusinessLayer FindAppByAppID(int RefAppID)
        {
            int personeid = -1, apptypeid = -1, createdbyuser = -1;
            DateTime Date = default(DateTime), LastStatus = default(DateTime);
                byte status = 0;
                decimal fees = 0; 

            if (clsDataAccessLayerApplication.FindApplicationByID(RefAppID, ref personeid, ref Date, ref apptypeid, ref status, ref LastStatus, ref fees, ref createdbyuser))
            {
                return new clsApplicationBusinessLayer(RefAppID, personeid, Date, apptypeid, status, LastStatus, fees, createdbyuser);
            }
            else
            {
                return null;
            }
        }

        public clsApplicationBusinessLayer GetDataByLocalID(int LocalDrivingLicenceAppID)
        {
            int RefAppID = -1, LicenceClass = -1;
            int AppID = -1, PersoneID = -1, AppTypeID = -1, CreatedByUserID = -1;
            DateTime Date = default(DateTime), LastDateStatus = default(DateTime);
            byte Status = 0;
            decimal Fees = -1;


            if (clsDataAccessLayerApplication.GetLDLAByID(LocalDrivingLicenceAppID, ref RefAppID, ref LicenceClass))
            {
                if (clsDataAccessLayerApplication.FindApplicationByID(RefAppID, ref PersoneID,ref Date ,ref AppTypeID , ref Status,ref LastDateStatus ,ref Fees , ref CreatedByUserID))
                {
                    return new clsApplicationBusinessLayer(LocalDrivingLicenceAppID, RefAppID, LicenceClass, PersoneID, Date, AppTypeID, Status, LastDateStatus, Fees, CreatedByUserID);
                }
            }

            return null;
        }

        public string GetClassName(int Id)
        {
            return clsDataAccessLayerApplication.GetLicenceClassesNameByID(Id);
        }

        public bool DeteleOrderLocal(int Delete)
        {
            return clsDataAccessLayerApplication.DeleteFromLocal(Delete);
        }


    }
}
