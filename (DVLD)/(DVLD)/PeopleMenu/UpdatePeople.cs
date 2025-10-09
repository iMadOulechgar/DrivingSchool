using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DVLD_.PeopleMenu
{
    public partial class UpdatePeople : Form
    {
        public UpdatePeople(int Id)
        {
            InitializeComponent();

            label3.Text = Id.ToString();
            clsBusinessPersone Per = new clsBusinessPersone();
            UpdateControle.Persone1 = Per.FindPersoneByPerId(Id);
            UpdateControle.Persone1.PersoneID = Id;
        }

      
    }
}
