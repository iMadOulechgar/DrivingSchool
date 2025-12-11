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

        public clsUserBusiness Bus = new clsUserBusiness();
        private Main_MDI_ Main = new Main_MDI_();

        void SaveDataONFile()
        {
            string Path = @"D:\DrivingSchool\(DVLD)\(DVLD)\Users\RememberMe.txt";
            string Text = TBLoginUsername.Text.Trim() + @"\" + TBLoginPassword.Text.Trim();

            if (File.Exists(Path))
            {
                string Read = File.ReadAllText(Path);
                int GetIndexOf = Read.IndexOf(@"\");
                TBLoginUsername.Text = Read.Substring(0, GetIndexOf).Trim();
                string Pass = Read.Remove(0, GetIndexOf + 1).Trim();
                TBLoginPassword.Text = Pass;
            } 

            if (checkBox1.Checked == true)
            {
              if (!File.Exists(Path))
              {
                  File.AppendAllText(Path,TBLoginUsername.Text+@"\"+TBLoginPassword.Text+"\n".Trim());
              }
            }
            else if(checkBox1.Checked == false)
            {
                File.Delete(Path);
            }
        }

        private void BTNLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        void Login()
        {
            if (CheckLoginInfo())
            {
                Main.ShowDialog();
                SaveDataONFile();
            }
            else
            {
                MessageBox.Show("invalid Username/Passwod","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private bool CheckLoginInfo()
        {
            if (TBLoginPassword.Text != "" && TBLoginUsername.Text != "")
            {
                Bus.UserName = TBLoginUsername.Text.Trim();
                Bus.Password = TBLoginPassword.Text.Trim();
                if (Bus.CheckLoginUser())
                {
                    clsGlobal.UserLogin = Bus.Find(Bus.UserName);
                    return true;
                }
            }

            return false;
        } 

        private void LoginForm_Load(object sender, EventArgs e)
        {
            SaveDataONFile();
        }
    }
}
