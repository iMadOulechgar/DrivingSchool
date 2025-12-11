using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsBusinessTest
    {

        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

       
        public clsBusinessTest(int Id , string title , string description , decimal fees)
        {
            TestTypeID = Id;
            TestTypeTitle = title;
            TestTypeDescription = description;
            TestTypeFees = fees;
        }

        public clsBusinessTest() {
            TestTypeID = 0;
            TestTypeTitle = "";
            TestTypeDescription = "";
            TestTypeFees = 0;
        }


        public DataTable GetDataFromTestTypes()
        {
            return clsDataAccessLayerTypeTests.GetALlDataFromDB();
        }

        public clsBusinessTest FindById(int Id)
        {
            string title = "",Description ="";
            decimal fees = 0;

            if (clsDataAccessLayerTypeTests.Find(ref Id ,ref title , ref Description , ref fees))
            {
                return new clsBusinessTest(Id, title,Description,fees);
            }
            else
            {
                return null;
            }
        }

        private bool _Update()
        {
            return clsDataAccessLayerTypeTests.Update(this.TestTypeID,this.TestTypeTitle,this.TestTypeDescription,this.TestTypeFees);
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
