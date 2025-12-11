using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsBusinessLayerDrivers
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        bool _Add()
        {
            this.DriverID =  clsDataAccessLayerDrivers.AddDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);
            return (DriverID != -1);
        }

        public bool save()
        {
            if (_Add())
            {
                return true;
            }

            return false;
        }

        public bool IsDriverExistByPersonID(int Person)
        {
            return clsDataAccessLayerDrivers.IsItAdriverAlreadyByPersoneID(Person);
        }

        public int GetDriverID(int perid)
        {
            return clsDataAccessLayerDrivers.GetDriverIDByPersonID(perid);
        }

        public DataTable GetDataFromDrivers()
        {
            return clsDataAccessLayerDrivers.getAllDrivers();
        }



    }
}
