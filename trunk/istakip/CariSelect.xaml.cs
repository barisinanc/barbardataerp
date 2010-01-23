using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BarisGorselDLL;

namespace istakip
{
    /// <summary>
    /// Interaction logic for CariSelect.xaml
    /// </summary>
    public partial class CariSelect : UserControl
    {
        public Cari selectedCari= new Cari();
        List<Cari> Cariler = new List<Cari>();
        public CariSelect()
        {
            InitializeComponent();            
        }

        public delegate void CariSelectedEventHandler();
        public event CariSelectedEventHandler CariSelected;

        public delegate void CancelledEventHandler();
        public event CancelledEventHandler Cancelled;

        private void buttonSearchSelect_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridSearch.SelectedIndex > -1)
            {
                selectedCari = Cariler[dataGridSearch.SelectedIndex];
                textBoxAdSoyad.Text = selectedCari.Isim;
                textBoxCepTel.Text = selectedCari.CepNo;
                textBoxTel.Text = selectedCari.TelNo;
                labelCariStatus.Content = selectedCari.CariNo + " numaralı cari seçildi";
                this.CariSelected();
            } 
        }

        private void buttonSearchCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Cancelled();
        }

        public void Cancel()
        {
            this.Cancelled();
        }

        public delegate void SavedEventHandler();
        public event SavedEventHandler Saved;

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCari.CariNo == 0)
            {
                selectedCari.CariNo= selectedCari.addCari();
            }
            Saved();
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Search()
        {
            Cariler = selectedCari.araCariler();
            dataGridSearch.AutoGenerateColumns = true;
            dataGridSearch.Columns.Clear();
            var list = from x in Cariler
                       select new { İsim = x.Isim, CepNo = x.CepNo, TelNo = x.TelNo, Eposta = x.Eposta, Adres = x.Adres, Tarih = x.Tarih, No = x.CariNo };
            dataGridSearch.ItemsSource = list.ToList();
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxAdSoyad.Text = "";
            textBoxCepTel.Text = "";
            textBoxTel.Text = "";
            selectedCari = null;
            labelCariStatus.Content = "Yeni Müşteri";
        }


    }
}
