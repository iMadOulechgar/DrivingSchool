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

        DataTable Dt = new DataTable();

        void FillDataGridView()
        {
            clsBusinessLayerDrivers Driver = new clsBusinessLayerDrivers();

            Dt = Driver.GetDataFromDrivers();

            DGVDrivers.Rows.Clear();

            foreach (DataRow Row in Dt.Rows)
            {
                int Count = DGVDrivers.Rows.Add();

                DGVDrivers.Rows[Count].Cells[0].Value = Row["DriverID"];
                DGVDrivers.Rows[Count].Cells[1].Value = Row["PersonID"];
                DGVDrivers.Rows[Count].Cells[2].Value = Row["NationalNo"];
                DGVDrivers.Rows[Count].Cells[3].Value = Row["FullName"];
                DGVDrivers.Rows[Count].Cells[4].Value = Row["CreatedDate"];

                if((bool)Row["IsActive"] == true)
                    DGVDrivers.Rows[Count].Cells[5].Value = 1;
                else
                    DGVDrivers.Rows[Count].Cells[5].Value = 0;
            }

            LBLRec.Text = DGVDrivers.Rows.Count.ToString();
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAllDrivers_Load(object sender, EventArgs e)
        {
            FillDataGridView();
            _FillCBWithColumns();
        }

        void _FillCBWithColumns()
        {
            foreach (DataGridViewColumn Columns in DGVDrivers.Columns)
            {
                if (Columns.HeaderText != "Date") {
                    CBSelect.Items.Add(Columns.HeaderText);
                }
            }
            CBSelect.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string comboboxSelect = CBSelect.SelectedItem.ToString();
            string text = textBox1.Text.Trim();

            DGVDrivers.Rows.Clear();

            foreach (DataRow Row in Dt.Rows)
            {
                if (string.IsNullOrEmpty(textBox1.Text) || Row[comboboxSelect].ToString().IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0)
                {

                    int Count = DGVDrivers.Rows.Add();

                    DGVDrivers.Rows[Count].Cells[0].Value = Row["DriverID"];
                    DGVDrivers.Rows[Count].Cells[1].Value = Row["PersonID"];
                    DGVDrivers.Rows[Count].Cells[2].Value = Row["NationalNo"];
                    DGVDrivers.Rows[Count].Cells[3].Value = Row["FullName"];
                    DGVDrivers.Rows[Count].Cells[4].Value = Row["CreatedDate"];
                    DGVDrivers.Rows[Count].Cells[5].Value = Row["IsActive"];

                }
            }
        }
    }
}
