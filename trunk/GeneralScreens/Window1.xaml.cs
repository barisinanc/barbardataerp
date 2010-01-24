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
using System.Windows.Forms;

namespace GeneralScreens
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            arsiv.Form1 arsivForm = new arsiv.Form1();
            arsivForm.Show();
            this.Close();
        }

        private void studyo_Click(object sender, RoutedEventArgs e)
        {
            istakip.ModulSiparis istakipForm = new istakip.ModulSiparis();
            istakipForm.Show();
            this.Close();
        }

        private void baski_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Yapim Asamasinda:)");
        }
    }
}
