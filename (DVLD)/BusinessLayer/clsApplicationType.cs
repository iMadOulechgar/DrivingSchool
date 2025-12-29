using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsApplicationType
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int AppId { get; set; }
        public string AppTitle { get; set; }
        public decimal AppFees { get; set; }

        public clsApplicationType(int id , string title , decimal fees) { 
            AppId = id;
            AppTitle = title;
            AppFees = fees;
            Mode = enMode.Update;
        }

        public clsApplicationType()
        {
            AppId = 0;
            AppTitle = "";
            AppFees = 0;
            Mode = enMode.AddNew;
        }

        public static clsApplicationType Find(int AppId)
        {
            string Title = "";
            decimal fees = 0;

            if (clsDataAccessLayerApplicationType.FindByAppTypeID(AppId,ref Title,ref fees))
            {
                return new clsApplicationType(AppId, Title, fees);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewApplicationType()
        {
            this.AppId = clsDataAccessLayerApplicationType.AddNewApplicationType(this.AppTitle, this.AppFees);

            return (this.AppId != -1);
        }

        public static DataTable GetAllFromAppTypes()
        {
            return clsDataAccessLayerApplicationType.GetAllApplicationTypes();
        }

        private bool _Update()
        {
            return clsDataAccessLayerApplicationType.UpdateAppType(this.AppId,this.AppTitle,this.AppFees);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationType())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _Update();
            }

            return false;
        }

        public DataTable GetAllManageApp()
        {
            return clsDataAccessLayerApplicationType.GetAllApplicationTypes();
        }

        public decimal GetFeesByAppTypeID(int TypeID)
        {
            return clsDataAccessLayerApplicationType.GetFeesByTypeID(TypeID);
        }

        public string GetAppTypesNameByAppID(int AppID)
        {
            return clsDataAccessLayerApplicationType.GetApplicationTypesByAppID(AppID);
        }

    }
}
