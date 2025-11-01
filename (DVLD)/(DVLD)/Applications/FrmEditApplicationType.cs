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

namespace _DVLD_.Applications
{
    public partial class FrmEditApplicationType : Form
    {
        public FrmEditApplicationType(int AppID)
        {
            InitializeComponent();

            clsBusinessApplicationType App = new clsBusinessApplicationType();
            AppType = App.Find(AppID);
        }

        clsBusinessApplicationType AppType ;

        public event Action FillDataGridView;

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            FillDataGridView?.Invoke();
            this.Close();
        }

        void _FillUiWithData()
        {
            if (AppType != null)
            {
                LBLAPPID.Text = AppType.AppId.ToString();
                TBFees.Text = AppType.AppFees.ToString();
                TBtitle.Text = AppType.AppTitle.ToString();
            }
            else
            {
                MessageBox.Show("The Object Is NUll", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        void _FillFromUItoDB()
        {
            AppType.AppTitle = TBtitle.Text;
            AppType.AppFees = Convert.ToDecimal(TBFees.Text);
        }

        private void FrmEditApplicationType_Load(object sender, EventArgs e)
        {
            _FillUiWithData();
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            _FillFromUItoDB();

            if (AppType.Save())
            {
                MessageBox.Show("Saved Succesfly :)","Confirmed",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Something Wrong ):", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
