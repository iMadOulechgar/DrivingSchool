using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DVLD_.LicencesLocal_And_International
{
    public partial class frmReplaceForLostOrDamage : Form
    {
        public frmReplaceForLostOrDamage()
        {
            InitializeComponent();
        }

        private void frmReplaceForLostOrDamage_Load(object sender, EventArgs e)
        {
            controleReplaceForDamageOrLost1.UiLogicLoad();
        }
    }
}
