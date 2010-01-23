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
    public partial class Popup : UserControl
    {
        public Cari selectedCari= new Cari();
        List<Cari> Cariler = new List<Cari>();
        public Popup(Cari nCari)
        {
            InitializeComponent();
            
            Cariler = nCari.araCariler();
            dataGridSearch.AutoGenerateColumns = true;
            dataGridSearch.Columns.Clear();
            var list = from x in Cariler
                       select new { İsim = x.Isim, CepNo = x.CepNo, TelNo = x.TelNo, Eposta = x.Eposta, Adres = x.Adres, Tarih = x.Tarih, No = x.CariNo };
            dataGridSearch.ItemsSource = list.ToList();
            
        }

        public delegate void CariSelectedEventHandler();
        public event CariSelectedEventHandler CariSelected;

        public delegate void ClosedEventHandler();
        public event ClosedEventHandler Closed;

        private void buttonSearchSelect_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridSearch.SelectedIndex > -1)
            {
                selectedCari = Cariler[dataGridSearch.SelectedIndex];
                this.CariSelected();
                this.Closed();
            } 
        }

        private void buttonSearchCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Closed();
        }

        public void Close()
        {
            this.Closed();
        }


    }
}
