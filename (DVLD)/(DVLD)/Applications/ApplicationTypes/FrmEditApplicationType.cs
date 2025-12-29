using _DVLD_.GlobalClasses;
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
        clsApplicationType _AppTypes;
        private int _ApplicationID;
        public FrmEditApplicationType(int AppID)
        {
            InitializeComponent();
            _ApplicationID = AppID;
        }


        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEditApplicationType_Load(object sender, EventArgs e)
        {
            _AppTypes = clsApplicationType.Find(_ApplicationID);

            if (_AppTypes != null)
            {
                LBLAPPID.Text = _AppTypes.AppId.ToString();
                TBtitle.Text = _AppTypes.AppTitle.ToString();
                TBFees.Text = _AppTypes.AppFees.ToString();
            }
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _AppTypes.AppTitle = TBtitle.Text.Trim();
            _AppTypes.AppFees = Convert.ToDecimal(TBFees.Text.Trim());

            if (_AppTypes.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    
        private void TBtitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBtitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBtitle, "Fill Data");
            }
            else
                errorProvider1.Clear();
        }

        private void TBFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBtitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBtitle, "Invalid Number");
                return;
            }
            else
                errorProvider1.Clear();

            if (!clsValidation.IsNumber(TBFees.Text.Trim()))
            {
                errorProvider1.SetError(TBFees, TBFees.Text.Trim());
            }
            else
            {
                errorProvider1.Clear();
            }
        
        
        }
    }
}
