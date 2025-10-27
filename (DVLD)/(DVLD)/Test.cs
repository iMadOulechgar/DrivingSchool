using BusinessLayer;
using System;
using System.Windows.Forms;

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

            clsBusinessPersone Per = persone.FindPersoneByPerId(5);

            label2.Text = Per.Firstname + " " + Per.LastName;

        }
    }
}
