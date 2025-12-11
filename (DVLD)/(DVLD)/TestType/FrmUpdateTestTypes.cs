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
        public FrmUpdateTestTypes(int TestID)
        {
            InitializeComponent();
            clsBusinessTest busTestType = new clsBusinessTest();

            TestsTypes1 = busTestType.FindById(TestID);
        }

        clsBusinessTest TestsTypes1;
        public event Action FillDataBack;


        void _FillDataInUI()
        {
            TBtitle.Text = TestsTypes1.TestTypeTitle;
            TBFees.Text = TestsTypes1.TestTypeFees.ToString();
            TBDescription.Text = TestsTypes1.TestTypeDescription;
            LBLID.Text = TestsTypes1.TestTypeID.ToString();
        }

        void _SaveNewDataInDB()
        {
            TestsTypes1.TestTypeDescription = TBDescription.Text;
            TestsTypes1.TestTypeTitle = TBtitle.Text;
            TestsTypes1.TestTypeFees = Convert.ToDecimal(TBFees.Text);
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            FillDataBack?.Invoke();
            this.Close();
        }

        private void BTNsave_Click(object sender, EventArgs e)
        {
            _SaveNewDataInDB();

            if (TestsTypes1.Save())
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
            if (TestsTypes1 != null)
            {
                _FillDataInUI();
            }
        }
    }
}
