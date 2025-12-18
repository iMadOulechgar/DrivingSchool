using _DVLD_.PeopleMenu;
using _DVLD_.Users;
using BusinessLayer;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _DVLD_.Controls
{
    public partial class PersoneFilterAndAdd : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> OnPersonSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }

        private bool _ShowAddPerson = true;

        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value;
                BtnAddNewPer.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                groupBox1.Enabled = _FilterEnabled;
            }
        }

        public PersoneFilterAndAdd()
        {
            InitializeComponent();
        }

        public clsBusinessPersone Persone1;

        public void FilterFocus()
        {
            TBSearch.Focus();
        }

        public int PersonID
        {
            get { return personInfo1.PersonID; }
        }

        public clsBusinessPersone SelectedPersonInfo
        {
            get { return personInfo1.SelectedPersonInfo; }
        }

        public event Action<int> GetFunFromInfoPer;

        private void button1_Click(object sender, EventArgs e)
        {
             AddPersoneFrm frm1 = new AddPersoneFrm();
            frm1.DataBack += DataBackEvent; // Subscribe to the event
            frm1.ShowDialog();
        }

        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received

            CBSearch.SelectedIndex = 1;
            TBSearch.Text = PersonID.ToString();
            personInfo1.LoadPersonInfo(PersonID);
        }

        public void LoadPersonInfo(int PersonID)
        {
            CBSearch.SelectedIndex = 1;
            TBSearch.Text = PersonID.ToString();
            FindNow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();
        }

        private void FindNow()
        {
            switch (CBSearch.Text)
            {
                case "Person ID":
                    personInfo1.LoadPersonInfo(int.Parse(TBSearch.Text));
                    break;
                case "National No.":
                    personInfo1.LoadPersonInfo(TBSearch.Text);
                    break;

                default:
                    break;
            }

            if (OnPersonSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnPersonSelected(personInfo1.PersonID);

        }

        public void fillfilter(int Id)
        {
            CBSearch.SelectedIndex = 0;
            TBSearch.Text = Id.ToString();
            groupBox1.Enabled = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (CBSearch.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
