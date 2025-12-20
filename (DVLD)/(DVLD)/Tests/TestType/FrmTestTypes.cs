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

namespace _DVLD_.About_Test
{
    public partial class FrmTestTypes : Form
    {
        public FrmTestTypes()
        {
            InitializeComponent();
        }

        private DataTable _dtAllTestTypes;

        private void FrmTestTypes_Load(object sender, EventArgs e)
        {
            _dtAllTestTypes = clsBusinessTestTypes.GetDataFromTestTypes();
            dgvTestTypes.DataSource = _dtAllTestTypes;
            LBLRec.Text = dgvTestTypes.Rows.Count.ToString();

            if (_dtAllTestTypes.Rows.Count > 0) {
                dgvTestTypes.Columns[0].HeaderText = "ID";
                dgvTestTypes.Columns[0].Width = 120;

                dgvTestTypes.Columns[1].HeaderText = "Title";
                dgvTestTypes.Columns[1].Width = 200;

                dgvTestTypes.Columns[2].HeaderText = "Description";
                dgvTestTypes.Columns[2].Width = 400;

                dgvTestTypes.Columns[3].HeaderText = "Fees";
                dgvTestTypes.Columns[3].Width = 100;
            }
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUpdateTestTypes Update = new FrmUpdateTestTypes((clsBusinessTestTypes.enTestTypes)dgvTestTypes.CurrentRow.Cells[0].Value);
            Update.ShowDialog();
            FrmTestTypes_Load(null,null);
        }
    }
}
