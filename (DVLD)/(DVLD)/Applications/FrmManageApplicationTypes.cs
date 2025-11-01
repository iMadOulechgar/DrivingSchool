using _DVLD_.Applications;
using DataAccessLayer;
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

        DataTable Data = new DataTable();

        void SetDataInDGV()
        {
            Data = clsDataAccessLayerApplicationType.GetAllApplicationTypes();

            dataGridView1.Rows.Clear();

            foreach (DataRow row in Data.Rows)
            {
                int Count = dataGridView1.Rows.Add();

                dataGridView1.Rows[Count].Cells[0].Value = row["ApplicationTypeID"];
                dataGridView1.Rows[Count].Cells[1].Value = row["ApplicationTypeTitle"];
                dataGridView1.Rows[Count].Cells[2].Value = row["ApplicationFees"];
            }
            LBLRec.Text = dataGridView1.RowCount.ToString();
        }

        private void FrmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            SetDataInDGV();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           FrmEditApplicationType Edit = new FrmEditApplicationType((int)dataGridView1.CurrentRow.Cells[0].Value);
            Edit.FillDataGridView += SetDataInDGV;
            Edit.ShowDialog();
        }
    }
}
