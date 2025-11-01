using _DVLD_.PeopleMenu;
using _DVLD_.Users;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DVLD_.Controls
{
    public partial class FilterControle : UserControl
    {
        public FilterControle()
        {
            InitializeComponent();
        }

        public event Action<int> FillDataByDelegateSearchINT;
        public event Action<string> FillDataByDelegateSearchSTR;
        public event Action<int> GetFunFromInfoPer;

        private void button1_Click(object sender, EventArgs e)
        {
            AddPersoneFrm Add = new AddPersoneFrm();
            Add.GetDataFromFilterControle += FunctionOfPersoneInfo;
            Add.ShowDialog();
        }

        void FunctionOfPersoneInfo(int PersoneId)
        {
            GetFunFromInfoPer?.Invoke(PersoneId);
        } 

        void SearchBySelectingWhatYouWant(string STR)
        {
            switch (STR)
            {
                case "NationalNo":
                    SearchByNationalNO();
                    break;
                case "PersoneID":
                    SearchByID();
                    break;

                case "None":
                    MessageBox.Show("Select What You Gonna Search For !!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                break;
            }
        }

        void SearchByNationalNO()
        {
            clsBusinessPersone Bus = new clsBusinessPersone();
            if (Bus.IsExists(textBox1.Text))
            {
                FillDataByDelegateSearchSTR?.Invoke(textBox1.Text);
            }
            else
            {
                MessageBox.Show("The Persone Not Exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void SearchByID()
        {
            clsBusinessPersone Bus = new clsBusinessPersone();
            if (Bus.IsExists(int.Parse(textBox1.Text)))
            {
                FillDataByDelegateSearchINT?.Invoke(int.Parse(textBox1.Text));
            }
            else
            {
                MessageBox.Show("The Persone Not Exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            SearchBySelectingWhatYouWant(comboBox1.SelectedItem.ToString());
            else
                MessageBox.Show("Fill What You Wanna Search For", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void fillfilter(int Id)
        {
            comboBox1.SelectedIndex = 0;
            textBox1.Text = Id.ToString();
        }


    }
}
