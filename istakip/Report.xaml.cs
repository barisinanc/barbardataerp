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
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : UserControl
    {
        public Report()
        {
            InitializeComponent();
            PersonelList personelsControl=new PersonelList();
            gridPersonel.Children.Add(personelsControl);
        }
        List<ImagePack> ListImages;
        List<Sepet> ListSepet;
        Cari SelectedCari;
        
    }
}
