using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace _DVLD_.Users
{
    public partial class UserManagment : Form
    {
        public UserManagment()
        {
            InitializeComponent();
        }

        private static DataTable _DtAllUsers;
        
        

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAddUsers UserAdd = new FrmAddUsers();
            UserAdd.ShowDialog();
        }

        private void UserManagment_Load(object sender, EventArgs e)
        {
            _DtAllUsers = clsUserBusiness.GetAllUsersFromDB();

            dgvUsers.DataSource = _DtAllUsers;

            CBSelect.SelectedIndex = 0;

            LBLRec.Text = dgvUsers.Rows.Count.ToString();

            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 110;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 120;

                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 350;

                dgvUsers.Columns[3].HeaderText = "UserName";
                dgvUsers.Columns[3].Width = 120;

                dgvUsers.Columns[4].HeaderText = "Is Active";
                dgvUsers.Columns[4].Width = 120;
            }


        }

        private void CBSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBSelect.Text == "Is Active")
            {
                textBox1.Visible = false;
                comboBox1.Visible = true;
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                textBox1.Visible = (CBSelect.Text != "None");
                comboBox1.Visible = false;
                textBox1.Text = "";
                textBox1.Focus();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = comboBox1.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "All")
                _DtAllUsers.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _DtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            LBLRec.Text = _DtAllUsers.Rows.Count.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (CBSelect.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (textBox1.Text.Trim() == "" || FilterColumn == "None")
            {
                _DtAllUsers.DefaultView.RowFilter = "";
                LBLRec.Text = dgvUsers.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                //in this case we deal with numbers not string.
                _DtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, textBox1.Text.Trim());
            else
                _DtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, textBox1.Text.Trim());

            LBLRec.Text = _DtAllUsers.Rows.Count.ToString();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAddUsers Update = new FrmAddUsers((int)dgvUsers.CurrentRow.Cells[0].Value);
            Update.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Wanna Delete This User?","Answer",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (clsUserBusiness.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("The User Deleted Succesfly :)", "Resp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UserManagment_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Something Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChangePasswordFrm password = new ChangePasswordFrm((int)dgvUsers.CurrentRow.Cells[0].Value);
            password.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserDetails Details = new ShowUserDetails((int)dgvUsers.CurrentRow.Cells[0].Value);
            Details.ShowDialog();
        }
    }
}
