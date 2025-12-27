using _DVLD_.PeopleMenu;
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

namespace _DVLD_.Drivers
{
    public partial class frmAllDrivers : Form
    {
        public frmAllDrivers()
        {
            InitializeComponent();
        }

        private DataTable _dtAllDrivers;

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAllDrivers_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;

            _dtAllDrivers = clsBusinessLayerDrivers.GetAllDrivers();
            DGVDrivers.DataSource = _dtAllDrivers;
            
            LBLRec.Text = DGVDrivers.Rows.Count.ToString();

            if (DGVDrivers.Rows.Count > 0)
            {
                DGVDrivers.Columns[0].HeaderText = "Driver ID";
                DGVDrivers.Columns[0].Width = 120;

                DGVDrivers.Columns[1].HeaderText = "Person ID";
                DGVDrivers.Columns[1].Width = 120;

                DGVDrivers.Columns[2].HeaderText = "National No.";
                DGVDrivers.Columns[2].Width = 140;

                DGVDrivers.Columns[3].HeaderText = "Full Name";
                DGVDrivers.Columns[3].Width = 320;

                DGVDrivers.Columns[4].HeaderText = "Date";
                DGVDrivers.Columns[4].Width = 170;

                DGVDrivers.Columns[5].HeaderText = "Active Licenses";
                DGVDrivers.Columns[5].Width = 150;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
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
                _dtAllDrivers.DefaultView.RowFilter = "";
                LBLRec.Text = DGVDrivers.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "NationalNo")
                //in this case we deal with numbers not string.
                _dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, textBox1.Text.Trim());
            else
                _dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, textBox1.Text.Trim());

            LBLRec.Text = _dtAllDrivers.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Visible = (cbFilterBy.Text != "None");
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Driver ID" || cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDetails Details = new ShowDetails((int)DGVDrivers.CurrentRow.Cells[1].Value);
            Details.ShowDialog();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
