using System;
using System.Windows.Forms;

namespace _DVLD_
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private Main_MDI_ Main = new Main_MDI_();

        private void BTNLogin_Click(object sender, EventArgs e)
        {
            Main.Show();
            this.Hide();
        }
    }
}
