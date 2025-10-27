using _DVLD_.Controls;
using BusinessLayer;
using System;
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
            AddControle.CloseForm += CloseAddForm;
            AddControle.WhenFrmClosedReturnDataToPersoneInfo += InvokeFunFromFilter;
        }
        public AddPersoneFrm(int Id)
        {
            InitializeComponent();
            clsBusinessPersone BusinessLayer = new clsBusinessPersone();
            AddControle.Persone1 = BusinessLayer.FindPersoneByPerId(Id);
            LBLadd.Text = Id.ToString();
            label1.Text = "Update Persone";
            AddControle.CloseForm += CloseAddForm;
            AddControle.FillPersoneInfo += InvokeMyFunc;
        }

        public event Action ReloadDataFromShowdeatails;
        public event Action<int> GetDataFromFilterControle;

        private void delegateFromControle(int Persone)
        {
            LBLadd.Text = Persone.ToString();
        }
        
        void InvokeMyFunc()
        {
            ReloadDataFromShowdeatails.Invoke();
        }

        void InvokeFunFromFilter()
        {
            if (int.TryParse(LBLadd.Text, out int id))
            {
                GetDataFromFilterControle?.Invoke(id);
            }
            else
            {
                MessageBox.Show("You Didn't Add Yet Any Persone :/","Error",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        public void CloseAddForm()
        {
            this.Close();
        }

    }
}
