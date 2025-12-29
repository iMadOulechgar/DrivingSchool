using _DVLD_.AllAboutTest;
using BusinessLayer;
using DVLD_Buisness;
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
        private int _AppointmentID = -1;
        private clsTestType.enTestType _TestType;

        private int _TestID = -1;
        private clsBusinessTest _Test;

        public Take_Test(int AppointmentID , clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            _TestType = TestType;
        }

        private void Take_Test_Load(object sender, EventArgs e)
        {
            clTakeTest2.TestTypeID = _TestType;
            clTakeTest2.FillControleWithData(_AppointmentID);

            if (clTakeTest2.AppointmentID == -1)
                BTNsave.Enabled = false;
            else
                BTNsave.Enabled=true;

            int _TestID = clTakeTest2.TestID;

            if (_TestID != -1)
            {
                _Test = clsBusinessTest.Find(_TestID);

                if (_Test.TestResult)
                    RBpass.Checked = true;
                else
                    RBFail.Checked = true;
                textBox1.Text = _Test.Notes;

                RBFail.Enabled = false;
                RBpass.Enabled = false;
            }
            else
            {
                _Test = new clsBusinessTest();
            }
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
            "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No
                 )
            {
                return;
            }

            _Test.TestAppointmentID = _AppointmentID;
            _Test.TestResult = (RBpass.Checked) ? true : false;
            _Test.Notes = textBox1.Text.Trim();
            _Test.CreatedByUserID = clsGlobal.UserLogin.UserID;

            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BTNsave.Enabled = false;
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
