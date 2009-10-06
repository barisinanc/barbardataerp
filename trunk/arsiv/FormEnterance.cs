using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using arsiv.BarisGorselDLL;
namespace arsiv
{
    public partial class FormEnterance : Form
    {
        public FormEnterance()
        {
            InitializeComponent();
        }

        private void FormEnterance_Load(object sender, EventArgs e)
        {
            subeDoldur();
        }

        private void subeDoldur()
        {
            Sube subeler = new Sube();
            foreach(Sube s in subeler.tumSubeler())
            {
                comboBoxSubeListe.Items.Add(s.SubeAdi);
            }
            subeler.Dispose();
            comboBoxSubeListe.SelectedIndex = Properties.Settings.Default.SubeId - 1;
        }

        private void baglantiDoldur()
        {
            comboBoxConnection.Items.Add("Dış");
            comboBoxConnection.Items.Add("İç");
            comboBoxConnection.Items.Add("Yerel");
            comboBoxConnection.SelectedIndex = 0;
        }

        private void baglanti()
        {
            if (comboBoxConnection.SelectedIndex == 0)
            {  }
            else if (comboBoxConnection.SelectedIndex == 1)
            { }
            else if (comboBoxConnection.SelectedIndex == 2)
            { }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            gir();
        }

        private void gir()
        {
            Properties.Settings.Default.SubeId = comboBoxSubeListe.SelectedIndex+1;
            Properties.Settings.Default.Save();
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }
    }
}
