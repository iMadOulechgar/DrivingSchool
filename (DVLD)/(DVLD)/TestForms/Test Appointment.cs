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

            clsApplicationBusinessLayer Bus = new clsApplicationBusinessLayer();

            localDrivingLicenceAppInfoAndApplicationInfo1.Application = Bus.GetDataByLocalID(localDrivingLicenceAppID);

            if (localDrivingLicenceAppInfoAndApplicationInfo1.Application != null)
            {
                localDrivingLicenceAppInfoAndApplicationInfo1._FillControlesWithData(passedTest);
            }

            TypeTest = TestType;
        }

        void _FillDataGridView()
        {
            clsBussinessLayerTestAndAppointment TestApp = new clsBussinessLayerTestAndAppointment();
            clsBussinessLayerTestAndAppointment Appointment = new clsBussinessLayerTestAndAppointment();

           DataTable Dt = TestApp.GetDataAppointment(localDrivingLicenceAppInfoAndApplicationInfo1.Application.LocalApp.LocalDrivingLicenceAppLicationID, TypeTest );

            DGVAppointments.Rows.Clear();

            if (!Appointment.IsRowsExist(localDrivingLicenceAppInfoAndApplicationInfo1.Application.LocalApp.LocalDrivingLicenceAppLicationID, TypeTest))
                DGVAppointments.ColumnHeadersVisible = false;
            else
            {
                DGVAppointments.ColumnHeadersVisible = true;
                foreach (DataRow Row in Dt.Rows)
                {
                    int Counter = DGVAppointments.Rows.Add();

                    DGVAppointments.Rows[Counter].Cells[0].Value = Row["TestAppointmentID"];
                    DGVAppointments.Rows[Counter].Cells[1].Value = Row["AppointmentDate"];
                    DGVAppointments.Rows[Counter].Cells[2].Value = Row["PaidFees"];
                    DGVAppointments.Rows[Counter].Cells[3].Value = Row["IsLocked"];

                }
            }
                label3.Text = (DGVAppointments.RowCount).ToString();
        }

        private void Test_Appointment_Load(object sender, EventArgs e)
        {
            
                _FillDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Schedule_Test TakeAppointment = new Schedule_Test(TypeTest - 1, localDrivingLicenceAppInfoAndApplicationInfo1.Application.LocalApp.LocalDrivingLicenceAppLicationID,false);
            clsBussinessLayerTestAndAppointment Appoin = new clsBussinessLayerTestAndAppointment();

            TakeAppointment.LoadDataInGrid += _FillDataGridView;

            if (!Appoin.IsRowsExist(localDrivingLicenceAppInfoAndApplicationInfo1.Application.LocalApp.LocalDrivingLicenceAppLicationID, TypeTest))
            {
                TakeAppointment.ShowDialog();
                return;
            }

            if (!Appoin.CheckIfHasAlreadyAnAppoinActive(TypeTest))
            {
                if (!Appoin.checkResult(localDrivingLicenceAppInfoAndApplicationInfo1.Application.LocalApp.LocalDrivingLicenceAppLicationID, TypeTest))
                {
                    Appoin.UpdateTheOrder(localDrivingLicenceAppInfoAndApplicationInfo1.Application.App.ApplicationId,2);
                    TakeAppointment.IsRetake = true;
                    TakeAppointment.ShowDialog();
                }
                else
                {
                    MessageBox.Show("You already Pass This Test :) ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You Need too Pass This Appointement First Then You Can Order Again ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Take_Test Test = new Take_Test((int)DGVAppointments.CurrentRow.Cells[0].Value, TypeTest - 1, localDrivingLicenceAppInfoAndApplicationInfo1.Application.LocalApp.LocalDrivingLicenceAppLicationID,DGVAppointments.RowCount -1, TypeTest);

            if ((bool)DGVAppointments.CurrentRow.Cells[3].Value != true)
            {
                Test.LoadDataAfterSaving += _FillDataGridView;
                Test.ShowDialog();
            }
            else
            {
                MessageBox.Show("The TestIs Locked Please Take Another Appointement :)");
            } 
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Schedule_Test Edit = new Schedule_Test(TypeTest-1, localDrivingLicenceAppInfoAndApplicationInfo1.Application.LocalApp.LocalDrivingLicenceAppLicationID, (int)DGVAppointments.CurrentRow.Cells[0].Value, (bool)DGVAppointments.CurrentRow.Cells[3].Value);
            clsBussinessLayerTestAndAppointment App = new clsBussinessLayerTestAndAppointment();
            if (App.Trial(localDrivingLicenceAppInfoAndApplicationInfo1.Application.LocalApp.LocalDrivingLicenceAppLicationID, TypeTest - 1) != -1)
            {
                Edit.IsRetake = true;
                Edit.ShowDialog();
            }
            else
            {
                Edit.ShowDialog();
            }
            
            
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            TestsLoad?.Invoke();
            this.Close();
        }
    }
}
