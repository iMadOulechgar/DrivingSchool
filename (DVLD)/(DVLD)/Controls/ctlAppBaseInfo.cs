using BusinessLayer;
using DVLD.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace _DVLD_.Controls
{
    public partial class ctlAppBaseInfo : UserControl
    {

        private clsApplication _Application;
        private int _ApplicationID;
                
        public int ApplicationId{

            get { return _ApplicationID; }
        
        }

        public ctlAppBaseInfo()
        {
            InitializeComponent();
        }

        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsApplication.FindBaseApplication(ApplicationID);
            if (_Application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                _FillApplicationInfo();
        }

        private void _FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationId;
            lblApplicationID.Text = _Application.ApplicationId.ToString();
            lblStatus.Text = _Application.StatusText;
            lblType.Text = _Application.ApplicationTypeInfo.AppTitle;
            lblFees.Text = _Application.PaidFees.ToString();
            lblApplicant.Text = _Application.PersonInfo.FullName.ToString();
            lblDate.Text = clsFormat.DateToShort(_Application.AppDate);
            lblStatusDate.Text = clsFormat.DateToShort(_Application.LastStatusDate);
            lblCreatedByUser.Text = _Application.CreatedByUserInfo.UserName;
        }

        public void ResetApplicationInfo()
        {
            _ApplicationID = -1;

            lblApplicationID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblType.Text = "[????]";
            lblFees.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblDate.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblCreatedByUser.Text = "[????]";

        }



    }
}
