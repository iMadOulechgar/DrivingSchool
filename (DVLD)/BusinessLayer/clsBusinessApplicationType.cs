using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsBusinessApplicationType
    {
        public int AppId { get; set; }
        public string AppTitle { get; set; }
        public decimal AppFees { get; set; }

        public clsBusinessApplicationType(int id , string title , decimal fees) { 
            AppId = id;
            AppTitle = title;
            AppFees = fees;
        }

        public clsBusinessApplicationType()
        {
            AppId = 0;
            AppTitle = "";
            AppFees = 0;
        }

        public clsBusinessApplicationType Find(int AppId)
        {
            string Title = "";
            decimal fees = 0;

            if (clsDataAccessLayerApplicationType.FindByAppTypeID(ref AppId,ref Title,ref fees))
            {
                return new clsBusinessApplicationType(AppId, Title, fees);
            }
            else
            {
                return null;
            }
        }

        public DataTable GetAllFromAppTypes()
        {
            return clsDataAccessLayerApplicationType.GetAllApplicationTypes();
        }

        private bool _Update()
        {
            return clsDataAccessLayerApplicationType.UpdateAppType(this.AppId,this.AppTitle,this.AppFees);
        }

        public bool Save()
        {
            if (_Update())
            {
                return true;
            }

            return false;   
        }



    }
}
