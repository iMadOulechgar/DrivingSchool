using _DVLD_.PeopleMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DVLD_
{
    public partial class Main_MDI_ : Form
    {
        public Main_MDI_()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagePeople MP = new ManagePeople();
            MP.ShowDialog();
        }
    }
}
