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

        DataTable Dt = new DataTable();

        void _FillDataGridView()
        {
            clsUserBusiness user = new clsUserBusiness();

             Dt = user.GetAllUsersFromDB();

            dataGridView1.Rows.Clear();

            foreach (DataRow Row in Dt.Rows)
            {
                int count = dataGridView1.Rows.Add();

                dataGridView1.Rows[count].Cells[0].Value = Row["UserID"];
                dataGridView1.Rows[count].Cells[1].Value = Row["PersoneID"];
                dataGridView1.Rows[count].Cells[2].Value = Row["FullName"];
                dataGridView1.Rows[count].Cells[3].Value = Row["UserName"];
                dataGridView1.Rows[count].Cells[4].Value = Row["IsActive"];
            }
            LBLRec.Text = dataGridView1.Rows.Count.ToString();
        }
        
        void _defaultSelection()
        {
            CBSelect.Items.Add("None");
            CBSelect.SelectedIndex = 0;
            comboBox1.Items.Add("All");
            CBSelect.SelectedIndex = 0;
            comboBox1.Items.Add("Yes");
            comboBox1.Items.Add("No");
        }

        void _FillComboBox()
        {
            foreach (DataGridViewColumn Column in dataGridView1.Columns)
            {
                CBSelect.Items.Add(Column.HeaderText);
            }
        }

        void comboBoxLogic(string Selected)
        {
            if (Selected == "None")
            {
                textBox1.Visible = false;
                comboBox1.Visible = false;
            }else if (Selected == "IsActive")
            {
                comboBox1.SelectedIndex = 0;
                comboBox1.Visible = true;
                textBox1.Visible = false;
            }
            else
            {
                textBox1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAddUsers UserAdd = new FrmAddUsers();
            UserAdd.WhenTheUserGetAddedOrEdited += _FillDataGridView;
            UserAdd.ShowDialog();
        }

        private void UserManagment_Load(object sender, EventArgs e)
        {
            _defaultSelection();
            _FillDataGridView();
            _FillComboBox();
        }

        private void CBSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxLogic(CBSelect.SelectedItem.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Yes")
            {
                dataGridView1.Rows.Clear();

                foreach (DataRow Row in Dt.Rows)
                {
                    if ((bool)Row["IsActive"])
                    {
                        int count = dataGridView1.Rows.Add();
                        dataGridView1.Rows[count].Cells[0].Value = Row["UserID"];
                        dataGridView1.Rows[count].Cells[1].Value = Row["PersoneID"];
                        dataGridView1.Rows[count].Cells[2].Value = Row["FullName"];
                        dataGridView1.Rows[count].Cells[3].Value = Row["UserName"];
                        dataGridView1.Rows[count].Cells[4].Value = Row["IsActive"];
                    }
                }
            }
            else if (comboBox1.SelectedItem == "No")
            {
                dataGridView1.Rows.Clear();

                foreach (DataRow Row in Dt.Rows)
                {
                    if ((bool)Row["IsActive"] == false)
                    {
                        int count = dataGridView1.Rows.Add();
                        dataGridView1.Rows[count].Cells[0].Value = Row["UserID"];
                        dataGridView1.Rows[count].Cells[1].Value = Row["PersoneID"];
                        dataGridView1.Rows[count].Cells[2].Value = Row["FullName"];
                        dataGridView1.Rows[count].Cells[3].Value = Row["UserName"];
                        dataGridView1.Rows[count].Cells[4].Value = Row["IsActive"];
                    }
                }
            }
            else
            {
                _FillDataGridView();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string Column = CBSelect.SelectedItem.ToString();
            string Text = textBox1.Text.Trim();

            dataGridView1.Rows.Clear();

            foreach (DataRow Row in Dt.Rows) {

                if (string.IsNullOrEmpty(Text) || Row[Column].ToString().IndexOf(Text,StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    int count = dataGridView1.Rows.Add();
                    dataGridView1.Rows[count].Cells[0].Value = Row["UserID"];
                    dataGridView1.Rows[count].Cells[1].Value = Row["PersoneID"];
                    dataGridView1.Rows[count].Cells[2].Value = Row["FullName"];
                    dataGridView1.Rows[count].Cells[3].Value = Row["UserName"];
                    dataGridView1.Rows[count].Cells[4].Value = Row["IsActive"];
                }
            }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAddUsers Update = new FrmAddUsers((int)dataGridView1.CurrentRow.Cells[0].Value);
            Update.WhenTheUserGetAddedOrEdited += _FillDataGridView;
            Update.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsUserBusiness bus = new clsUserBusiness();
            if (MessageBox.Show("Are You Sure You Wanna Delete This User?","Answer",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (bus.DeleteUser((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("The User Deleted Succesfly :)", "Resp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _FillDataGridView();
                }
                else
                {
                    MessageBox.Show("Something Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChangePasswordFrm password = new ChangePasswordFrm((int)dataGridView1.CurrentRow.Cells[0].Value, (int)dataGridView1.CurrentRow.Cells[1].Value);
            password.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserDetails Details = new ShowUserDetails((int)dataGridView1.CurrentRow.Cells[0].Value, (int)dataGridView1.CurrentRow.Cells[1].Value);
            Details.ShowDialog();
        }
    }
}
