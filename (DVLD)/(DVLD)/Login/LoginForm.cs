using System;
using System.Windows.Forms;
using System.IO;
using BusinessLayer;

namespace _DVLD_
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        clsUserBusiness _User;

        private void BTNLogin_Click(object sender, EventArgs e)
        {
            _User = clsUserBusiness.FindByUsernameAndPassword(TBLoginUsername.Text.Trim(),TBLoginPassword.Text.Trim());

            if (_User != null)
            {
                if (checkBox1.Checked)
                {
                    //store username and password
                    clsGlobal.RememberUsernameAndPassword(TBLoginUsername.Text.Trim(), TBLoginPassword.Text.Trim());
                }
                else
                {
                    //store empty username and password
                    clsGlobal.RememberUsernameAndPassword("", "");
                }
                //incase the user is not active
                if (!_User.IsActive)
                {
                    TBLoginUsername.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsGlobal.UserLogin = _User;
                this.Hide();
                Main_MDI_ frm = new Main_MDI_(this);
                frm.ShowDialog();
            }
            else
            {
                TBLoginUsername.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            string Username = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref Username,ref Password))
            {
                TBLoginPassword.Text = Password;
                TBLoginUsername.Text = Username;
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }

        }
    }
}
