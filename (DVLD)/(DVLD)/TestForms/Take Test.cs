using _DVLD_.AllAboutTest;
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

namespace _DVLD_.TestForms
{
    public partial class Take_Test : Form
    {
        public Take_Test(int TestApp , int num , int LocalID , int Trial,int TestTypeID)
        {
            InitializeComponent();

            TestAppointmentID = TestApp;

            clsApplicationBusinessLayer App = new clsApplicationBusinessLayer();
            clsBusinessPersone Persone = new clsBusinessPersone();

            checkTest(num);

            clTakeTest2.ApplicationLocal = App.GetDataByLocalID(LocalID);
            //clTakeTest2.Per = Persone.FindPersoneByPerId(clTakeTest2.ApplicationLocal.App.AppPersoneId);
            clTakeTest2._FillControleWithData(Trial,TestTypeID);
        }

        public event Action LoadDataAfterSaving;

        private int TestAppointmentID { get; set; }

        clsBussinessLayerTestAndAppointment TakeTest = new clsBussinessLayerTestAndAppointment();

        void _FillDataFromControles()
        {
            TakeTest.testOrAppointment = 2;

            if (textBox1.Text != "")
                TakeTest.Test.Notes = textBox1.Text;
            else
                TakeTest.Test.Notes = "";

            if (RBpass.Checked == true)
            {
                clsBussinessLayerTestAndAppointment retakeTheTestType = new clsBussinessLayerTestAndAppointment();
                TakeTest.Test.TestResult = 1;
                retakeTheTestType.UpdateTheOrder(clTakeTest2.ApplicationLocal.App.ApplicationId, 1);
            }
            else
            {
                TakeTest.Test.TestResult = 0;
            }
                

            TakeTest.Test.CreateByUserID = clsGlobal.UserLogin.UserID;
            TakeTest.Test.TestAppointID = TestAppointmentID;
        }

        void Save()
        {
            _FillDataFromControles();

            if (TakeTest.Save())
            {
                TakeTest.Lock(TestAppointmentID);
                LoadDataAfterSaving?.Invoke();
                this.Close();
            }
            else
            {
                MessageBox.Show("Something Wrong with save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void checkTest(int Num)
        {
            switch (Num)
            {
                case 0:
                    clTakeTest2.vision();
                    break;

                case 1:
                    clTakeTest2.Written();
                    break;

                case 2:
                    clTakeTest2.Street();
                    break;
            }
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
