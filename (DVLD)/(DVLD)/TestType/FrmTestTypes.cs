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

        DataTable dt = new DataTable();

        void _FillDataInDataGridView()
        {
            clsBusinessTest Bus = new clsBusinessTest();
            dt = Bus.GetDataFromTestTypes();

            dataGridView1.Rows.Clear();

            foreach (DataRow Row in dt.Rows)
            {
                int count = dataGridView1.Rows.Add();

                dataGridView1.Rows[count].Cells[0].Value = Row["TestTypeID"];
                dataGridView1.Rows[count].Cells[1].Value = Row["TestTypeTitle"];
                dataGridView1.Rows[count].Cells[2].Value = Row["TestTypeDescription"];
                dataGridView1.Rows[count].Cells[3].Value = Row["TestTypeFees"];
            }
            LBLRec.Text = dataGridView1.Rows.Count.ToString();
        }

        private void FrmTestTypes_Load(object sender, EventArgs e)
        {
            _FillDataInDataGridView();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUpdateTestTypes Update = new FrmUpdateTestTypes((int)dataGridView1.CurrentRow.Cells[0].Value);
            Update.FillDataBack += _FillDataInDataGridView;
            Update.ShowDialog();
        }
    }
}
