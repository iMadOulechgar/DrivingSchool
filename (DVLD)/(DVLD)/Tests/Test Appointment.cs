using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DVLD_.TestForms
{
    public partial class Test_Appointment : Form
    {
        public int TypeTest { get; set; }

        public event Action TestsLoad;

        public Test_Appointment(int localDrivingLicenceAppID,int passedTest,int TestType)
        {
            InitializeComponent();

           
        }



        private void Test_Appointment_Load(object sender, EventArgs e)
        {
                    }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
            
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            TestsLoad?.Invoke();
            this.Close();
        }
    }
}
