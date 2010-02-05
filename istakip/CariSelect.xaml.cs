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
        private Cari _selectedCari = new Cari();
        public Cari selectedCari
        {
            get
            {
                return _selectedCari;
            }
            set
            {
                if (value != null)
                {
                    _selectedCari = value;
                    textBoxAdSoyad.Text = _selectedCari.Isim;
                    textBoxCepTel.Value = _selectedCari.CepNo;
                    textBoxTel.Value = _selectedCari.TelNo;
                    labelCariStatus.Content = _selectedCari.CariNo + " numaralı cari seçildi";
                    
                }
            }
        }
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
            selectCari();
        }

        private void selectCari()
        {
            if (dataGridSearch.SelectedIndex > -1)
            {
                _selectedCari = Cariler[dataGridSearch.SelectedIndex];
                textBoxAdSoyad.Text = _selectedCari.Isim;
                textBoxCepTel.Value = _selectedCari.CepNo;
                textBoxTel.Value = _selectedCari.TelNo;
                labelCariStatus.Content = _selectedCari.CariNo + " numaralı cari seçildi";
                if (CariSelected != null)
                { CariSelected(); }
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
            if ((_selectedCari==null||_selectedCari.CariNo == 0) && textBoxAdSoyad.Text != "")
            {
                _selectedCari = new Cari();
                _selectedCari.Isim = textBoxAdSoyad.Text.Trim();
                _selectedCari.TelNo = textBoxTel.Value.ToString();
                _selectedCari.CepNo = textBoxCepTel.Value.ToString();
                _selectedCari.CariNo= _selectedCari.addCari();
            }
            if (textBoxAdSoyad.Text != "")
            {
                Saved();
            }
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            _selectedCari.Isim = textBoxAdSoyad.Text;
            _selectedCari.CepNo = textBoxCepTel.Value.ToString();
            _selectedCari.TelNo = textBoxTel.Value.ToString();
            Search();
        }

        private void Search()
        {
            Cariler = selectedCari.araCariler();
            dataGridSearch.AutoGenerateColumns = true;
            dataGridSearch.Columns.Clear();
            var list = from x in Cariler
                       select new { İsim = x.Isim, CepNo = x.CepNo, TelNo = x.TelNo, Eposta = x.Eposta, Adres = x.Adres, No = x.CariNo };
            dataGridSearch.ItemsSource = list.ToList();
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxAdSoyad.Text = "";
            textBoxCepTel.Value=null;
            textBoxTel.Value = null;
            _selectedCari = null;
            labelCariStatus.Content = "Yeni Müşteri";
        }

        private void dataGridSearch_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            selectCari();
        }


    }
}
