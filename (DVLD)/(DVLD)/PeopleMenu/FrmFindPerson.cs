using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DVLD_.PeopleMenu
{
    public partial class FrmFindPerson : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public FrmFindPerson()
        {
            InitializeComponent();
        }

        private void BTNcancel_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, personeFilterAndAdd1.PersonID);
        }
    }
}
