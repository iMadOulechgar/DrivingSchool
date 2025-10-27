using _DVLD_.Controls;
using BusinessLayer;
using System;
using System.Data;
using System.Data.Common;
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

        DataTable Dt = new DataTable();

        private void button1_Click(object sender, EventArgs e)
        {
            AddPersoneFrm frm = new AddPersoneFrm();
            frm.ShowDialog();
        }

        private void _GetAllColumnsFromGrid()
        {
            CBSelect.Items.Add("None");

            foreach (DataGridViewColumn Column in DGVmanagePeople.Columns)
            {
                CBSelect.Items.Add(Column.HeaderText);
            }
            CBSelect.SelectedIndex = 0;
        }

        private void _FillTheDataGridView()
        {
            clsBusinessPersone Per = new clsBusinessPersone();

            Dt = Per.GetAllRowsFromPeople();

            DGVmanagePeople.Rows.Clear();

            foreach (DataRow Row in Dt.Rows)
            {
                int Counter = DGVmanagePeople.Rows.Add();

                DGVmanagePeople.Rows[Counter].Cells[0].Value = Row["PersoneID"];
                DGVmanagePeople.Rows[Counter].Cells[1].Value = Row["NationalNo"];
                DGVmanagePeople.Rows[Counter].Cells[2].Value = Row["FirstName"];
                DGVmanagePeople.Rows[Counter].Cells[3].Value = Row["SecondName"];
                DGVmanagePeople.Rows[Counter].Cells[4].Value = Row["ThirdName"];
                DGVmanagePeople.Rows[Counter].Cells[5].Value = Row["LastName"];
                DGVmanagePeople.Rows[Counter].Cells[6].Value = Row["DateOfBirth"];
                DGVmanagePeople.Rows[Counter].Cells[7].Value = Row["Gendor"];
                DGVmanagePeople.Rows[Counter].Cells[8].Value = Row["Address"];
                DGVmanagePeople.Rows[Counter].Cells[9].Value = Row["Phone"];
                DGVmanagePeople.Rows[Counter].Cells[10].Value = Row["Email"];
            }
            LBLRec.Text = (DGVmanagePeople.RowCount).ToString();
            Per = null;
        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {
            _FillTheDataGridView();
            _GetAllColumnsFromGrid();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddPersoneFrm Update = new AddPersoneFrm((int)DGVmanagePeople.CurrentRow.Cells[0].Value);
            Update.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsBusinessPersone Bus = new clsBusinessPersone();

            if (MessageBox.Show("Are You Sure You Wanna Delete This Persone ? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
                Bus.DeletePersoneById((int)DGVmanagePeople.CurrentRow.Cells[0].Value);
                MessageBox.Show("Persone Deleted Sucssesfly", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                _FillTheDataGridView();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string Column = CBSelect.SelectedItem.ToString();
            string Text = textBox1.Text.ToString();

            DGVmanagePeople.Rows.Clear();

            foreach (DataRow Row in Dt.Rows){

            if (string.IsNullOrEmpty(Text) || Row[Column].ToString().IndexOf(Text,StringComparison.OrdinalIgnoreCase) >=0)
            {
                int Counter = DGVmanagePeople.Rows.Add();

                DGVmanagePeople.Rows[Counter].Cells[0].Value = Row["PersoneID"];
                DGVmanagePeople.Rows[Counter].Cells[1].Value = Row["NationalNo"];
                DGVmanagePeople.Rows[Counter].Cells[2].Value = Row["FirstName"];
                DGVmanagePeople.Rows[Counter].Cells[3].Value = Row["SecondName"];
                DGVmanagePeople.Rows[Counter].Cells[4].Value = Row["ThirdName"];
                DGVmanagePeople.Rows[Counter].Cells[5].Value = Row["LastName"];
                DGVmanagePeople.Rows[Counter].Cells[6].Value = Row["DateOfBirth"];
                DGVmanagePeople.Rows[Counter].Cells[7].Value = Row["Gendor"];
                DGVmanagePeople.Rows[Counter].Cells[8].Value = Row["Address"];
                DGVmanagePeople.Rows[Counter].Cells[9].Value = Row["Phone"];
                DGVmanagePeople.Rows[Counter].Cells[10].Value = Row["Email"];
            }
        }
            LBLRec.Text = DGVmanagePeople.RowCount.ToString();

        }

        private void CBSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBSelect.SelectedItem.ToString() == "None")
            {
                textBox1.Visible = false;
            }
            else
            {
                textBox1.Visible = true;
            }
            
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDetails Showfrm = new ShowDetails((int)DGVmanagePeople.CurrentRow.Cells[0].Value);
            Showfrm.ShowDialog();
        }

        bool CheckComboBox(string N1 , string N2)
        {
            if (CBSelect.SelectedItem.ToString() == N1 || CBSelect.SelectedItem.ToString() == N2)
                return true;

            return false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char C = e.KeyChar;
            if (CheckComboBox("PersoneID", "Gendor"))
            {
                if (!char.IsNumber(C) && !char.IsControl(C))
                    e.Handled = true;
            }
        }
    }
}
