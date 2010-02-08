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
using System.Windows.Shapes;

namespace PersonelClient
{
    /// <summary>
    /// Interaction logic for UserSelect.xaml
    /// </summary>
    public partial class UserSelect : Window
    {
        public UserSelect()
        {
            InitializeComponent();
            BarisGorselDLL.Kullanici kullaniciEng = new BarisGorselDLL.Kullanici();
            List<BarisGorselDLL.Kullanici> kullancilar = kullaniciEng.kullanicilar();
            foreach (BarisGorselDLL.Kullanici x in kullancilar) 
            {
                ComboBoxItem yeni = new ComboBoxItem();
                cmbUserName.Items.Add(x.Ad);
            }
            cmbUserName.SelectedIndex = 0;
            
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
