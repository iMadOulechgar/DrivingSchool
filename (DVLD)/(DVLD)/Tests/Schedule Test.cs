using BusinessLayer;
using DataAccessLayer;
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
    public partial class Schedule_Test : Form
    {
        public Schedule_Test(int TypesTest , int LocalID,bool Islocked)
        {
            InitializeComponent();

            clsApplicationBusinessLayer Business = new clsApplicationBusinessLayer();
            clsBusinessPersone persone = new clsBusinessPersone();

            checkTest(TypesTest,Islocked);
            clTestAppointment1.ApplicationLocal = Business.GetDataByLocalID(LocalID);
            //clTestAppointment1.Per = persone.FindPersoneByPerId(clTestAppointment1.ApplicationLocal.App.AppPersoneId);
            clTestAppointment1.FillDataInApp(LocalID, TypesTest+1);
        }

        public Schedule_Test(int TypesTest, int LocalID , int Appointment,bool islocked)
        {
            InitializeComponent();

            clsBussinessLayerTestAndAppointment App = new clsBussinessLayerTestAndAppointment();
            clsApplicationBusinessLayer Business = new clsApplicationBusinessLayer();
            clsBusinessPersone persone = new clsBusinessPersone();

            checkTest(TypesTest, islocked);
            clTestAppointment1.ApplicationLocal = Business.GetDataByLocalID(LocalID);
            clTestAppointment1.Appointments = App.Find(Appointment);
            clTestAppointment1.FillDataInApp(LocalID, TypesTest + 1);
        }

        public event Action LoadDataInGrid;

        public bool IsRetake { get; set; } 

        void checkTest(int Num , bool Islocked)
        {
            switch (Num)
            {
                case 0:
                    clTestAppointment1.vision(Islocked);
                    break;

                case 1:
                    clTestAppointment1.Written(Islocked);
                    break;

                case 2:
                    clTestAppointment1.Street(Islocked);
                    break;
            }
        }

        private void Schedule_Test_Load(object sender, EventArgs e)
        {
            clTestAppointment1.showRetakeTest(IsRetake);
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            LoadDataInGrid?.Invoke();
            this.Close();
        }
    }
}
