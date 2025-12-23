using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DVLD_.AllAboutTest
{
    public partial class ClTakeTest : UserControl
    {
        public ClTakeTest()
        {
            InitializeComponent();

        }

        public clsApplicationBusinessLayer ApplicationLocal;
        public clsBusinessPersone Per;
        clsBussinessLayerTestAndAppointment App = new clsBussinessLayerTestAndAppointment();

        public void vision()
        {
            pictureBox1.Image = Properties.Resources.eye;
            groupBox1.Text = "Vision Test";
        }

        public void Written()
        {
            pictureBox1.Image = Properties.Resources.icons8_write_100;
            groupBox1.Text = "Written Test";
        }

        public void Street()
        {
            pictureBox1.Image = Properties.Resources.icons8_driving_100;
            groupBox1.Text = "Street Test";
        }

        public void _FillControleWithData(int TrialNum,int TestTypeID)
        {

            LBLFees.Text = Convert.ToInt32(App.GetPaidFees(TestTypeID)).ToString();
            LBLTrial.Text = TrialNum.ToString();
            LBLName.Text = Per.FullName;
        }


    }
}

