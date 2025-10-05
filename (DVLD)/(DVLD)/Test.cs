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
using DataAccessLayer;

namespace _DVLD_
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                clsBusinessPersone persone = new clsBusinessPersone();

                clsBusinessPersone Per =  persone.FindPersoneByPerId(2);

                label2.Text = Per.Firstname + " " + Per.LastName;
                
        }
    }
}
