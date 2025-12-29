using _DVLD_.Applications;
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

namespace _DVLD_.Application
{
    public partial class FrmManageApplicationTypes : Form
    {
        public FrmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private DataTable _DtAppTypes;

        private void FrmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _DtAppTypes = clsApplicationType.GetAllFromAppTypes();

            dataGridView1.DataSource = _DtAppTypes;

            LBLRec.Text = dataGridView1.Rows.Count.ToString();

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 110;

                dataGridView1.Columns[1].HeaderText = "Title";
                dataGridView1.Columns[1].Width = 400;

                dataGridView1.Columns[2].HeaderText = "Fees";
                dataGridView1.Columns[2].Width = 100;
            }
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEditApplicationType Edit = new FrmEditApplicationType((int)dataGridView1.CurrentRow.Cells[0].Value);
            Edit.ShowDialog();
            FrmManageApplicationTypes_Load(null, null);
        }
    }
}
