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

namespace _DVLD_.About_Test
{
    public partial class FrmUpdateTestTypes : Form
    {
        clsBusinessTestTypes.enTestTypes _TestTypeID = clsBusinessTestTypes.enTestTypes.VisionTest;
        clsBusinessTestTypes _Tests;
        public FrmUpdateTestTypes(clsBusinessTestTypes.enTestTypes TestType)
        {
            InitializeComponent();
            _TestTypeID = TestType;
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Tests.Save())
            {
                MessageBox.Show("The Data Saved Succesfly :)");
            }
            else
            {
                MessageBox.Show("SomeThing Wrong , Data Not Saved");
            }
        }

        private void FrmUpdateTestTypes_Load(object sender, EventArgs e)
        {
            _Tests = clsBusinessTestTypes.FindById(_TestTypeID);

            if (_Tests != null)
            {
                LBLID.Text = ((int)_TestTypeID).ToString();
                TBtitle.Text = _Tests.TestTypeTitle;
                TBDescription.Text = _Tests.TestTypeDescription;
                TBFees.Text = _Tests.TestTypeFees.ToString();
            }
            else
            {
                MessageBox.Show("Could not find Test Type with id = " + _TestTypeID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void TBtitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBtitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBtitle, "Title cannot be empty!");
            }
            else
                errorProvider1.SetError(TBtitle, null);
        }

        private void TBDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBtitle, "Desc cannot be empty!");
            }
            else
                errorProvider1.SetError(TBtitle, null);
        }

        private void TBFees_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TBFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBFees, "Fees cannot be empty!");
                return;
            }
            else
                errorProvider1.SetError(TBFees, null);
            

            if (!clsValidation.IsNumber(TBFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBFees, "Invalid Number.");
            }
            else
                errorProvider1.SetError(TBFees, null);
        }
    }
}
