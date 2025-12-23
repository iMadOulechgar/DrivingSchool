using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DVLD_.Controls
{
    public partial class DriverLicenceInfo : UserControl
    {
        public DriverLicenceInfo()
        {
            InitializeComponent();
        }

        public clsApplicationBusinessLayer Application;
        public clsBusinessPersone Person;
        public clsBusinessLayerLicences Licence;

        string GetAppType(int AppID)
        {
            clsBusinessApplicationType TypesName = new clsBusinessApplicationType();
             return TypesName.GetAppTypesNameByAppID(AppID); 
        }

       

    }
}
