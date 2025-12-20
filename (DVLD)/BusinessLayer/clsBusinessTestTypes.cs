using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsBusinessTestTypes
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enTestTypes { VisionTest = 1 , WrittenTest = 2 ,StreetTest = 3};
        public enTestTypes TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

       
        public clsBusinessTestTypes(enTestTypes TestType, string title , string description , decimal fees)
        {
            TestTypeID = TestType;
            TestTypeTitle = title;
            TestTypeDescription = description;
            TestTypeFees = fees;
            Mode = enMode.Update;
        }

        public clsBusinessTestTypes() {
            TestTypeID = 0;
            TestTypeTitle = "";
            TestTypeDescription = "";
            TestTypeFees = 0;
            Mode = enMode.AddNew;
        }

        public static DataTable GetDataFromTestTypes()
        {
            return clsDataAccessLayerTypeTests.GetALlDataFromDB();
        }

        public static clsBusinessTestTypes FindById(enTestTypes TestType)
        {
            string title = "",Description ="";
            decimal fees = 0;

            if (clsDataAccessLayerTypeTests.Find((int)TestType, ref title , ref Description , ref fees))
            {
                return new clsBusinessTestTypes(TestType, title,Description,fees);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewTestType()
        {
            this.TestTypeID = (enTestTypes)clsDataAccessLayerTypeTests.AddNewTestType(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);

            return ((int)this.TestTypeID != -1);
        }

        private bool _Update()
        {
            return clsDataAccessLayerTypeTests.Update((int)this.TestTypeID,this.TestTypeTitle,this.TestTypeDescription,this.TestTypeFees);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
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

    }
}
