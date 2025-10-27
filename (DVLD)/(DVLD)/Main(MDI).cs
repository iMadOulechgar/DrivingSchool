using _DVLD_.PeopleMenu;
using _DVLD_.Users;
using System;
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManagment User = new UserManagment();
            User.ShowDialog();
        }
    }
}
