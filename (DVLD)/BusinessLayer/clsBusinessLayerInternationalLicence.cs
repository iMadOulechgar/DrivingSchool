using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsBusinessLayerInternationalLicence
    {

        enum enmode { Add=1,Update=2}
        enmode Mode;

        public int InternationalLicenceID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenceID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive {  get; set; }
        public int CreatedByUserID { get; set; }

        public clsBusinessLayerInternationalLicence()
        {
            InternationalLicenceID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenceID = -1;
            IssueDate = default(DateTime);
            ExpirationDate = default(DateTime);
            IsActive = false;
            CreatedByUserID = -1;

            Mode = enmode.Add;
        }

        public clsBusinessLayerInternationalLicence(int intLicenceID,int appID,int driverID,int licenceID,DateTime issuedate, DateTime expirationdate,bool isactive,int createdbyuserid)
        {
            InternationalLicenceID = intLicenceID;
            ApplicationID = appID;
            DriverID = driverID;
            LicenceID = licenceID;
            IssueDate = issuedate;
            ExpirationDate = expirationdate;
            IsActive = isactive;
            CreatedByUserID = createdbyuserid;
        }

        public bool _AddInterNationalLicense()
        {
            this.InternationalLicenceID = clsDataAccessLayerInternationalLicences.AddInternationalLicence(ApplicationID, DriverID, LicenceID, IssueDate, ExpirationDate, IsActive,CreatedByUserID);
            return (this.InternationalLicenceID != -1);
        }

        public clsBusinessLayerInternationalLicence FindInternationalLicence(int InternationalLicenceID)
        {
            int intLicenceID = InternationalLicenceID, appID = -1, driverID = -1, licenceID = -1, createdbyuserid = -1;
                DateTime issuedate = default(DateTime), expirationdate = default(DateTime);
                bool isactive = false;
            if (clsDataAccessLayerInternationalLicences.FindInterNationalLicence(ref intLicenceID , ref appID, ref driverID, ref licenceID, ref issuedate, ref expirationdate, ref isactive, ref createdbyuserid))
            {
                return new clsBusinessLayerInternationalLicence(intLicenceID, appID, driverID, licenceID, issuedate, expirationdate, isactive,createdbyuserid);
            }
            else
            {
                return null;
            }
        }

        public clsBusinessLayerInternationalLicence FindInternationalLicenceByLicenceID(int LicenceID)
        {
            int intLicenceID = -1, appID = -1, driverID = -1, licenceID = LicenceID, createdbyuserid = -1;
            DateTime issuedate = default(DateTime), expirationdate = default(DateTime);
            bool isactive = false;
            if (clsDataAccessLayerInternationalLicences.FindInterNationalLicenceByLicenceID(ref intLicenceID, ref appID, ref driverID, ref licenceID, ref issuedate, ref expirationdate, ref isactive, ref createdbyuserid))
            {
                return new clsBusinessLayerInternationalLicence(intLicenceID, appID, driverID, licenceID, issuedate, expirationdate, isactive, createdbyuserid);
            }
            else
            {
                return null;
            }
        }


        public bool save()
        {
            switch (Mode)
            {
                case enmode.Add:
                    if (_AddInterNationalLicense())
                    {
                        return true;
                    }
                    break;
                case enmode.Update:
                    break;
            }

            return false;
        }

        public bool CheckIsThereAlreadyAnInternationalLicence(int LocalLicenceID)
        {
            return clsDataAccessLayerInternationalLicences.IsThePersonHaveAlreadyInternationalLicence(LocalLicenceID);
        }

        public DataTable GetDataFromInternationaLicences(int LicenceID)
        {
            return clsDataAccessLayerInternationalLicences.GetAllFromInternationalLicenceTableByApplicationID(LicenceID);
        }

        public DataTable GetDataFromInternationaLicences()
        {
            return clsDataAccessLayerInternationalLicences.GetAllFromInternationalLicenceTable();
        }
    }
}
