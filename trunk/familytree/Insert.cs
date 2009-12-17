using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace familytree
{

    public partial class Insert : Form
    {
        private class ComboboxItem
        {
            public int Id;
            public string Text;
        }
        public Insert()
        {
            InitializeComponent();
        }

        private void Insert_Load(object sender, EventArgs e)
        {
            Lists_Initializer();
        }

        private void Lists_Initializer()
        {
            comboBoxDeath.Items.Add("Sağ");
            comboBoxDeath.Items.Add("Ölü");

            comboBoxMotherFather.Items.Add("Kayıtlı Değil");
            Lists listeler = new Lists();

            //comboBoxMotherFather.DataSource = listeler.comboParent().AsDataView();
            
        }
  
    }
}
