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
        public float FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUserBusiness CreatedByUserInfo;
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public clsUserBusiness ReleasedByUserInfo;
        public int ReleaseApplicationID { get; set; }
        

        public clsBussinessLayerDetainedLicense()
        {
            DetainID = -1;
            LicenceID = -1;
            DetainDate = default(DateTime);
            FineFees = -1;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = default(DateTime);
            ReleasedByUserID = -1;
            ReleaseApplicationID = -1;

            Mode = enMode.Add;
        }

        public clsBussinessLayerDetainedLicense( int detainID, int licenceID, DateTime detainDate, float fineFees, int createdByUserID, bool isReleased, DateTime releasedDate, int releasedByUserID, int releasedAppID)
        {
            DetainID = detainID;
            LicenceID = licenceID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            CreatedByUserInfo = clsUserBusiness.FindByUserID(CreatedByUserID);
            IsReleased = isReleased;
            ReleaseDate = releasedDate;
            ReleasedByUserID = releasedByUserID;
            ReleasedByUserInfo = clsUserBusiness.FindByUserID(ReleasedByUserID);
            ReleaseApplicationID = releasedAppID;

            Mode = enMode.Update;
        }

        public static bool IsLicenseDetained(int Licence)
        {
            return clsDataAccessLayerDetained.IsLicenseDetained(Licence);
        }

        bool _AddDetain()
        {
            this.DetainID =  clsDataAccessLayerDetained.AddingDetainedLicence(this.LicenceID, this.DetainDate, this.FineFees, this.CreatedByUserID);
            return (this.DetainID != -1);
        }

        private bool _UpdateDetainedLicense()
        {
            //call DataAccess Layer 

            return clsDataAccessLayerDetained.UpdateDetainedLicense(
                this.DetainID, this.LicenceID, this.DetainDate, this.FineFees, this.CreatedByUserID);
        }

        public static clsBussinessLayerDetainedLicense FindDetainedLicenceByLicenceID(int Licence)
        {
            int detainID = -1, createdByUserID = -1, releasedByUserID = -1, releasedAppID = -1;
            DateTime detainDate = default(DateTime), releasedDate = default(DateTime);
            bool isReleased = false;
            float fineFees = 0;

            if (clsDataAccessLayerDetained.GetDetainedLicenseInfoByLicenseID(ref detainID, Licence, ref detainDate, ref fineFees, ref createdByUserID, ref isReleased, ref releasedDate, ref releasedByUserID, ref releasedAppID))
            {
                return new clsBussinessLayerDetainedLicense(detainID, Licence, detainDate, fineFees, createdByUserID, isReleased, releasedDate, releasedByUserID, releasedAppID);
            }
            else
            {
                return null;
            }
        }

        public static clsBussinessLayerDetainedLicense FindDetainedLicenceByDetainID(int DetainID)
        {
            int LicenseID = -1; DateTime DetainDate = DateTime.Now;
            float FineFees = 0; int CreatedByUserID = -1;
            bool IsReleased = false; DateTime ReleaseDate = DateTime.MaxValue;
            int ReleasedByUserID = -1; int ReleaseApplicationID = -1;

            if (clsDataAccessLayerDetained.GetDetainedLicenseInfoByID(DetainID,
            ref LicenseID, ref DetainDate,
            ref FineFees, ref CreatedByUserID,
            ref IsReleased, ref ReleaseDate,
            ref ReleasedByUserID, ref ReleaseApplicationID))

                return new clsBussinessLayerDetainedLicense(DetainID,
                     LicenseID, DetainDate,
                     FineFees, CreatedByUserID,
                     IsReleased, ReleaseDate,
                     ReleasedByUserID, ReleaseApplicationID);
            else
                return null;

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
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateDetainedLicense();
            }
        
            return false;
        }

        public static DataTable GetAllDataToDt()
        {
            return clsDataAccessLayerDetained.GetDataFromDetainAndReleaseLicenses();
        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, int ReleaseApplicationID)
        {
            return clsDataAccessLayerDetained.ReleaseDetainedLicense(this.DetainID,
                   ReleasedByUserID, ReleaseApplicationID);
        }
        
    }
}
