using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DVLD_.Licences
{
    public partial class FrmLicenceHistory : Form
    {
        private int _PersonID = -1;
        public FrmLicenceHistory()
        {
            InitializeComponent();
        }

        public FrmLicenceHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }


        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void driver_Licences_Hirtory1_Load(object sender, EventArgs e)
        {
            if (_PersonID != -1)
            {
                personeFilterAndAdd1.LoadPersonInfo(_PersonID);
                personeFilterAndAdd1.FilterEnabled = false;
                driver_Licences_Hirtory1.LoadDataByPersonID(_PersonID);
            }
            else
            {
                personeFilterAndAdd1.Enabled = true;
                personeFilterAndAdd1.FilterFocus();
            }
        }

        private void personeFilterAndAdd1_OnPersonSelected(int obj)
        {
            _PersonID = obj;

            if (_PersonID == -1)
            {
                //driver_Licences_Hirtory1.Clear();
            }
            else
            {
                driver_Licences_Hirtory1.LoadDataByPersonID(_PersonID);
            }
        }
    }
}
