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
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public clsPersone PersonInfo;
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public clsBusinessLayerDrivers()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;
            Mode = enMode.AddNew;
        }

        public clsBusinessLayerDrivers(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            this.PersonInfo = clsPersone.FindPersoneByPerId(PersonID);

            Mode = enMode.Update;
        }

        bool _Add()
        {
            this.DriverID =  clsDataAccessLayerDrivers.AddNewDriver(this.PersonID, this.CreatedByUserID);
            return (DriverID != -1);
        }

        bool _Update()
        {
            return clsDataAccessLayerDrivers.UpdateDriver(this.DriverID,this.PersonID,this.CreatedByUserID);
        }

        public bool save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_Add())
                    {
                        Mode = enMode.Update;
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

        public static clsBusinessLayerDrivers FindByDriverID(int DriverID)
        {
            int PersonID = -1; int CreatedByUserID = -1; DateTime CreatedDate = DateTime.Now;

            if (clsDataAccessLayerDrivers.GetDriverInfoByDriverID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))

                return new clsBusinessLayerDrivers(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }

        public static clsBusinessLayerDrivers FindByPersonID(int PersonID)
        {

            int DriverID = -1; int CreatedByUserID = -1; DateTime CreatedDate = DateTime.Now;

            if (clsDataAccessLayerDrivers.GetDriverInfoByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate))

                return new clsBusinessLayerDrivers(DriverID, PersonID, CreatedByUserID, CreatedDate);
            else
                return null;

        }

        public bool IsDriverExistByPersonID(int Person)
        {
            return clsDataAccessLayerDrivers.IsItAdriverAlreadyByPersoneID(Person);
        }

        public int GetDriverID(int perid)
        {
            return clsDataAccessLayerDrivers.GetDriverIDByPersonID(perid);
        }

        public static DataTable GetAllDrivers()
        {
            return clsDataAccessLayerDrivers.getAllDrivers();
        }

        public static DataTable GetLicenses(int DriverID)
        {
            return clsBusinessLayerLicences.GetDriverLicenses(DriverID);
        }

    }
}
