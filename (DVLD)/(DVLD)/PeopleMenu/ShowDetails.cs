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

namespace _DVLD_.PeopleMenu
{
    public partial class ShowDetails : Form
    {
        public ShowDetails(int PerID)
        {
            InitializeComponent();
            personInfo1._FillControlsWithData(PerID);
            //personInfo1.Persone1 = Bus.FindPersoneByPerId(PerID);
            //personInfo1.Persone1.PersoneID = PerID;
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
