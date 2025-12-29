using _DVLD_.Controls;
using BusinessLayer;
using DataAccessLayer;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace _DVLD_.PeopleMenu
{
    public partial class ManagePeople : Form
    {
        public ManagePeople()
        {
            InitializeComponent();
        }

        private static DataTable _DtAllPeople = BusinessLayer.clsPersone.GetAllRowsFromPeople();
        private DataTable _DtPeople = _DtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

        private void _RefreshPeoplList()
        {
            _DtAllPeople = BusinessLayer.clsPersone.GetAllRowsFromPeople();
            _DtPeople = _DtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

            DGVmanagePeople.DataSource = _DtPeople;
            LBLRec.Text = DGVmanagePeople.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPersoneFrm frm = new AddPersoneFrm();
            frm.ShowDialog();
        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {
            DGVmanagePeople.DataSource = _DtPeople;
            CBSelect.SelectedIndex = 0;
            LBLRec.Text = DGVmanagePeople.Rows.Count.ToString();

            if (DGVmanagePeople.Rows.Count > 0)
            {
                DGVmanagePeople.Columns[0].HeaderText = "Person ID";
                DGVmanagePeople.Columns[0].Width = 110;

                DGVmanagePeople.Columns[1].HeaderText = "National No.";
                DGVmanagePeople.Columns[1].Width = 120;

                DGVmanagePeople.Columns[2].HeaderText = "First Name";
                DGVmanagePeople.Columns[2].Width = 120;

                DGVmanagePeople.Columns[3].HeaderText = "Second Name";
                DGVmanagePeople.Columns[3].Width = 140;

                DGVmanagePeople.Columns[4].HeaderText = "Third Name";
                DGVmanagePeople.Columns[4].Width = 120;

                DGVmanagePeople.Columns[5].HeaderText = "Last Name";
                DGVmanagePeople.Columns[5].Width = 120;

                DGVmanagePeople.Columns[6].HeaderText = "Gendor";
                DGVmanagePeople.Columns[6].Width = 120;

                DGVmanagePeople.Columns[7].HeaderText = "Date Of Birth";
                DGVmanagePeople.Columns[7].Width = 140;

                DGVmanagePeople.Columns[8].HeaderText = "Nationality";
                DGVmanagePeople.Columns[8].Width = 120;

                DGVmanagePeople.Columns[9].HeaderText = "Phone";
                DGVmanagePeople.Columns[9].Width = 120;

                DGVmanagePeople.Columns[10].HeaderText = "Email";
                DGVmanagePeople.Columns[10].Width = 170;
            }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form Frm = new AddPersoneFrm((int)DGVmanagePeople.CurrentRow.Cells[0].Value);
            Frm.ShowDialog();
            _RefreshPeoplList();
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Wanna Delete This Persone ? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
                if (BusinessLayer.clsPersone.DeletePersoneById((int)DGVmanagePeople.CurrentRow.Cells[0].Value)) {
                    MessageBox.Show("Persone Deleted Sucssesfly", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    _RefreshPeoplList();
                }
                else
                {
                    MessageBox.Show("You Can Not Delete This Persone Reference To Other Tables ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (CBSelect.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (textBox1.Text.Trim() == "" || FilterColumn == "None")
            {
                _DtPeople.DefaultView.RowFilter = "";
                LBLRec.Text = DGVmanagePeople.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID")
                //in this case we deal with integer not string.

                _DtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, textBox1.Text.Trim());
            else
                _DtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, textBox1.Text.Trim());

            LBLRec.Text = DGVmanagePeople.Rows.Count.ToString();

        }

        private void CBSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Visible = (CBSelect.SelectedItem.ToString() != "None");

            if (textBox1.Visible)
            {
                textBox1.Text = "";
                textBox1.Focus();
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDetails Showfrm = new ShowDetails((int)DGVmanagePeople.CurrentRow.Cells[0].Value);
            Showfrm.ShowDialog();
            _RefreshPeoplList();
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id is selected.
            if (CBSelect.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void DGVmanagePeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Frm = new AddPersoneFrm();
            Frm.ShowDialog();
             _RefreshPeoplList();
        }
    }
}
