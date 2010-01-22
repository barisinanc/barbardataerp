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
using Microsoft.Win32;
using System.IO;
using System.Threading;
using BarisGorselDLL;
using System.Windows.Media.Animation;

namespace istakip
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            
            this.WindowState = WindowState.Maximized;
            Gallery galeri = new Gallery();
            gridGallery.Children.Add(galeri);
        }

        CariSelect yeniArama;
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            if (yeniArama != null)
            {
                yeniArama.Close();
            }
            Cari yeniCari = new Cari();
            yeniCari.Isim = textBoxAdSoyad.Text;
            yeniCari.TelNo = textBoxTel.Text;
            yeniCari.CepNo = textBoxCepTel.Text;
            yeniArama = new CariSelect(yeniCari);
            this.MainGrid.Children.Add(yeniArama);
            
            yeniArama.BeginAnimation(UserControl.OpacityProperty, new DoubleAnimation(0.00, 1, new Duration(new TimeSpan(0, 0, 0, 0, 300))));
            yeniArama.CariSelected += new CariSelect.CariSelectedEventHandler(yeniArama_CariSelected);
            yeniArama.Closed += new CariSelect.ClosedEventHandler(yeniArama_Closed);
        }

        void yeniArama_Closed()
        {
            this.MainGrid.Children.Remove(yeniArama);
        }

        void yeniArama_CariSelected()
        {
            selectedCari = yeniArama.selectedCari;
            textBoxAdSoyad.Text = selectedCari.Isim;
            textBoxCepTel.Text = selectedCari.CepNo;
            textBoxTel.Text = selectedCari.TelNo;
            labelCariStatus.Content = selectedCari.CariNo + " numaralı cari seçildi";
        }

        Cari selectedCari;

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxAdSoyad.Text = "";
            textBoxCepTel.Text = "";
            textBoxTel.Text = "";
            selectedCari = null;
            labelCariStatus.Content = "Yeni Müşteri";
        }

        private void buttonProductSelect_Click(object sender, RoutedEventArgs e)
        {
            ProductSelect urunler = new ProductSelect();
            MainGrid.Children.Add(urunler);
        }
      

      
        
    }
}
