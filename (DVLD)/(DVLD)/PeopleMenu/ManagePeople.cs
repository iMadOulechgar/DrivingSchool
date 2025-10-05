using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BusinessLayer;

namespace _DVLD_.PeopleMenu
{
    public partial class ManagePeople : Form
    {
        public ManagePeople()
        {
            InitializeComponent();
        }

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
            DGVmanagePeople.DataSource = Per.GetAllRowsFromPeople();

            LBLRec.Text = (DGVmanagePeople.RowCount - 1).ToString();
        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {
            _FillTheDataGridView();
            _GetAllColumnsFromGrid();
        }



    }
}
