using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DVLD_.Licences
{
    public partial class Issue_Driving_Licence : Form
    {

        public Issue_Driving_Licence(int localID,int passedTest)
        {
            InitializeComponent();

        }


        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void BTNsave_Click(object sender, EventArgs e)
        {
        }
    }
}
