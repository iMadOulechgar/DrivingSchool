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


namespace _DVLD_.PeopleMenu
{
    public partial class AddPersoneFrm : Form
    {
        public AddPersoneFrm()
        {
            InitializeComponent();
            AddControle.Persone1 = new clsBusinessPersone();
            AddControle.PersoneIdByDelegate += delegateFromControle;
        }

        private void delegateFromControle(int Persone)
        {
             LBLadd.Text = Persone.ToString();
        }

    }
}
