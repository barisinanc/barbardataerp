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

        private void ayarOkut()
        {

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
            ConnectionStrings liste = new ConnectionStrings();
            foreach (ConnectionString cs in liste.ConnectionStringList())
            {
                comboBoxConnection.Items.Add(cs.ConectionString);
            }

            ConnectionTest test = new ConnectionTest();
            if (test.Test())
            {
                Settings.ConnectionId = comboBoxConnection.SelectedIndex;
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            baglanti();
            gir();
        }

        private void gir()
        {
            Settings.SelectedSube.SubeId = comboBoxSubeListe.SelectedIndex + 1;
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }
    }
}
