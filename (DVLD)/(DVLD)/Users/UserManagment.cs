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

namespace _DVLD_.Users
{
    public partial class UserManagment : Form
    {
        public UserManagment()
        {
            InitializeComponent();
        }

        


        private void button1_Click(object sender, EventArgs e)
        {
            FrmAddUsers UserAdd = new FrmAddUsers();
            UserAdd.ShowDialog();
        }

        private void UserManagment_Load(object sender, EventArgs e)
        {
            clsUserBusiness user = new clsUserBusiness();
            dataGridView1.DataSource = user.GetAllUsersFromDB();
        }
    }
}
