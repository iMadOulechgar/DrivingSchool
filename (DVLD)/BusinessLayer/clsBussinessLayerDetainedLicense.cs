using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsBussinessLayerDetainedLicense
    {

        enum enMode { Add = 1 , Update = 2 }
        enMode Mode;

        public int DetainID {  get; set; }
        public int LicenceID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }


        public clsBussinessLayerDetainedLicense()
        {
            DetainID = -1;
            LicenceID = -1;
            DetainDate = default(DateTime);
            FineFees = default(decimal);
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = default(DateTime);
            ReleasedByUserID = -1;
            ReleaseApplicationID = -1;

            Mode = enMode.Add;
        }

        public clsBussinessLayerDetainedLicense( int detainID, int licenceID, DateTime detainDate, decimal fineFees, int createdByUserID, bool isReleased, DateTime releasedDate, int releasedByUserID, int releasedAppID)
        {
            DetainID = detainID;
            LicenceID = licenceID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleaseDate = releasedDate;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releasedAppID;

            Mode = enMode.Update;
        }

        public bool IsAlreadyDetained(int Licence)
        {
            return clsDataAccessLayerDetained.IsLicenseDetained(Licence);
        }

        bool _AddDetain()
        {
            this.DetainID =  clsDataAccessLayerDetained.AddingDetainedLicence(this.LicenceID, this.DetainDate, this.FineFees, this.CreatedByUserID, this.IsReleased);
            return (this.DetainID != -1);
        }

        public clsBussinessLayerDetainedLicense FindDetainedLicenceByLicenceID(int Licence)
        {
            int detainID = -1, licenceID = Licence, createdByUserID = -1, releasedByUserID = -1, releasedAppID = -1;
            DateTime detainDate = default(DateTime), releasedDate = default(DateTime);
            bool isReleased = false;
            decimal fineFees = default(decimal);

            if (clsDataAccessLayerDetained.FindDetainedByLicenceID(ref detainID, ref licenceID, ref detainDate, ref fineFees, ref createdByUserID, ref isReleased, ref releasedDate, ref releasedByUserID, ref releasedAppID))
            {
                return new clsBussinessLayerDetainedLicense(detainID, licenceID, detainDate, fineFees, createdByUserID, isReleased, releasedDate, releasedByUserID, releasedAppID);
            }
            else
            {
                return null;
            }
        }

        bool _Update()
        {
            return clsDataAccessLayerDetained.UpdateDetainedToReleased(this.DetainID,this.IsReleased,this.ReleaseDate,this.ReleasedByUserID,this.ReleaseApplicationID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddDetain())
                    {
                        return true;
                    }
                    break;
                case enMode.Update:
                    if (_Update())
                    {
                        return true;
                    }
                    break;
            }
        
            return false;
        }

        public DataTable GetAllDataToDt()
        {
            return clsDataAccessLayerDetained.GetDataFromDetainAndReleaseLicenses();
        }

    }
}
