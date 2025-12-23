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

namespace _DVLD_.AllAboutTest
{
    public partial class ClTestAppointment : UserControl
    {
        public ClTestAppointment()
        {
            InitializeComponent();
        }

        public clsApplicationBusinessLayer ApplicationLocal;
        public clsBusinessPersone Per;
        public clsBussinessLayerTestAndAppointment Appointments = new clsBussinessLayerTestAndAppointment();

        public void FillDataInApp(int localId,int Type)    
        {
            Appointments.TestAppointement.LocalDrivingLicenceApplicationID = localId;
            Appointments.TestAppointement.TestTypeID = Type;

            LBLAPPID.Text = localId.ToString();
            LBLfees.Text = Convert.ToInt32(Appointments.GetPaidFees(Appointments.TestAppointement.TestTypeID)).ToString();
            LBLTrial.Text = Appointments.Trial(localId, Type).ToString();
            LBLNAME.Text = Per.FullName;
            if (Appointments.TestAppointement.TestAppointmentID != -1)
            {
                LBLAppointmentID.Text = Appointments.TestAppointement.TestAppointmentID.ToString();
            }
        }

        void FillDataInDB()
        {
            Appointments.TestAppointement.AppointmentDate = dateTimePicker1.Value;
            Appointments.TestAppointement.CreatedByUser = clsGlobal.UserLogin.UserID;
            Appointments.TestAppointement.IsLocked = false;
        }

        public event Action LoadDataGridview;

        public void showRetakeTest(bool result)
        {
            if (result) { 
                groupBox2.Enabled = true;
                label14.Text = "5";
                label13.Text = (int.Parse(LBLfees.Text)+int.Parse(label14.Text)).ToString();
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }

        public void vision(bool IsLocked)
        {
            pictureBox1.Image = Properties.Resources.eye;
            
            if (IsLocked)
            {
                label18.Visible = true;
                dateTimePicker1.Enabled = false;
                BTNsave.Enabled = false;
            }
            else
            {
                label18.Visible = false;
            }
        }

        public void Written(bool IsLocked)
        {
            pictureBox1.Image = Properties.Resources.icons8_write_100;

            if (IsLocked)
            {
                label18.Visible = true;
                dateTimePicker1.Enabled = false;
                BTNsave.Enabled = false;
            }
            else
            {
                label18.Visible = false;
            }
        }

        public void Street(bool IsLocked)
        {
            pictureBox1.Image = Properties.Resources.icons8_driving_100;

            if (IsLocked)
            {
                label18.Visible = true;
                dateTimePicker1.Enabled = false;
                BTNsave.Enabled = false;
            }
            else
            {
                label18.Visible = false;
            }
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            FillDataInDB();
            Appointments.testOrAppointment = 1;
            if (Appointments.Save())
            {
                MessageBox.Show("Data Saved Succsefly :)","Confirm",MessageBoxButtons.OK,MessageBoxIcon.Information);
                LoadDataGridview?.Invoke();
            }
            else
            {
                MessageBox.Show("The Appointement Not Added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

    }
}
