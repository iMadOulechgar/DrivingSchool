using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsBusinessLayerLicences
    {
        enum enmode { Add = 1 , Update = 2}
        enmode Mode;

        public int LicenceID { get; set; }
        public int DriverID { get; set; }
        public int ApplicationID{ get; set; }
        public int LicenceClassID { get; set; }
        public DateTime IssueDate{ get; set; }
        public DateTime ExpirationDate{ get; set; }
        public string Notes{ get; set; }
        public decimal PaidFees{ get; set; }
        public bool IsActive{ get; set; }
        public byte IssueReason { get; set; }
        public int CreatedByUserID{ get; set; }


        public clsBusinessLayerLicences()
        {
            LicenceID = -1;
            DriverID = -1;
            ApplicationID = -1;
            LicenceClassID = -1;
            IssueDate = default(DateTime);
            ExpirationDate = default(DateTime);
            Notes = "";
            PaidFees = -1;
            IsActive = false;
            IssueReason = 0;
            CreatedByUserID = -1;

            Mode = enmode.Add;
        }

        public clsBusinessLayerLicences(int licenceid,int applicationid, int driverid, int licenceclassid, DateTime issuedate, DateTime expirationdate, string notes, decimal paidfees, bool isactive, byte issuereason, int createdbyuserid)
        {
            LicenceID = licenceid;
            DriverID = driverid;
            ApplicationID = applicationid;
            LicenceClassID = licenceclassid;
            IssueDate = issuedate;
            ExpirationDate = expirationdate;
            Notes = notes;
            PaidFees = paidfees;
            IsActive = isactive;
            IssueReason = issuereason;
            CreatedByUserID = createdbyuserid;

            Mode = enmode.Update;
        }

        bool _AddLicence()
        {
            this.LicenceID = clsDataAccessLayerLicences.AddLicence(this.ApplicationID,this.DriverID,this.LicenceClassID,this.IssueDate,this.ExpirationDate,this.Notes,this.PaidFees,this.IsActive,this.IssueReason,this.CreatedByUserID);
            return (this.LicenceID != -1);
        }

        public clsBusinessLayerLicences FindByAppID(int AppID)
        {
            int licenceid = -1, applicationid = AppID, driverid = -1, licenceclassid = -1, createdbyuserid = -1;
            DateTime issuedate = default(DateTime), expirationdate = default(DateTime);
            string notes = "";
            decimal paidfees = 0;
            bool isactive = false;
            byte issuereason = 0;

            if (clsDataAccessLayerLicences.FindLicenceByAppID(ref licenceid, ref applicationid, ref driverid, ref licenceclassid, ref issuedate, ref expirationdate, ref notes, ref paidfees, ref isactive, ref issuereason, ref createdbyuserid))
            {
                return new clsBusinessLayerLicences(licenceid, applicationid, driverid, licenceclassid, issuedate, expirationdate, notes, paidfees, isactive, issuereason, createdbyuserid);
            }
            else
            {
                return null;
            }
        }

        public clsBusinessLayerLicences FindByLicenceID(int LicenceID)
        {
            int applicationid = -1,LicenceId = LicenceID, driverid = -1, licenceclassid = -1, createdbyuserid = -1;
            DateTime issuedate = default(DateTime), expirationdate = default(DateTime);
            string notes = "";
            decimal paidfees = 0;
            bool isactive = false;
            byte issuereason = 0;

            if (clsDataAccessLayerLicences.FindLicenceByLicenceID(ref LicenceId, ref applicationid, ref driverid, ref licenceclassid, ref issuedate, ref expirationdate, ref notes, ref paidfees, ref isactive, ref issuereason, ref createdbyuserid))
            {
                return new clsBusinessLayerLicences(LicenceId, applicationid, driverid, licenceclassid, issuedate, expirationdate, notes, paidfees, isactive, issuereason, createdbyuserid);
            }
            else
            {
                return null;
            }
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enmode.Add:
                    if (_AddLicence())
                    {
                        return true;
                    }
                    break;
                case enmode.Update:
                    if (_AddLicence())
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }
            

            return false;
        }

        public DataTable GetAllFromLicencesByAppID(int Appid)
        {
            return clsDataAccessLayerLicences.GetAllFromLicenceTableByApplicationID(Appid);
        }

        public bool IsLicenceExists(int LicenceID)
        {
            return clsDataAccessLayerLicences.IsLicenceExists(LicenceID);
        }

        public bool CheckIsLicenceExpirated(int LicenceID)
        {
            return clsDataAccessLayerLicences.CheckIsLicenceExpiratedOrNot(LicenceID);
        }

        public bool ChangeActiveToInActive(int LicenceID)
        {
            return clsDataAccessLayerLicences.UpdateLicenceinActiveIt(LicenceID);
        }

        public bool IsExistsByAppID(int AppID)
        {
            return clsDataAccessLayerLicences.IsLicenceExistsByAppID(AppID);
        }

        public DataTable GetAllFromLicence(int DriverID)
        {
            return clsDataAccessLayerLicences.GetDataLicencesByDriverID(DriverID);
        }

        public bool IsLicenceActive(int LicenceID)
        {
            return clsDataAccessLayerLicences.IsLicenceExists(LicenceID);
        }

    }
}
