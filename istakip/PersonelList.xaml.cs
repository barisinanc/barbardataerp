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
    /// Interaction logic for PersonelList.xaml
    /// </summary>
    public partial class PersonelList : UserControl
    {
        public PersonelList()
        {
            InitializeComponent();
            fillList();
        }
        private Kullanici _selectedKullanici;
        public Kullanici selectedKullanici
        {
            get { return _selectedKullanici; }
            set {
                _selectedKullanici = value;
                if (UserSelected != null)
                {
                    UserSelected();
                }
            }
        }
        private List<Kullanici> kullanicilar;
        private void fillList()
        {
            MainGrid.Children.Clear();
            WrapPanel wrapPanel = new WrapPanel();
            MainGrid.Children.Add(wrapPanel);
            selectedKullanici = new Kullanici();
            kullanicilar=selectedKullanici.kullanicilar();
            foreach (Kullanici k in kullanicilar)
            {
                Image photo = new Image();
                photo.MaxHeight = 75;
                photo.VerticalAlignment = VerticalAlignment.Top;
                Label isim = new Label();
                isim.Content = k.Ad;
                isim.VerticalAlignment = VerticalAlignment.Bottom;
                Grid grid = new Grid();
                grid.Width = 90;
                grid.Height = 100;
                grid.Children.Add(photo);
                grid.Children.Add(isim);
                grid.Uid = k.Id.ToString();
                grid.Margin = new Thickness(5, 0, 5, 0);
                grid.Cursor = Cursors.Hand;
                wrapPanel.Children.Add(grid);
                grid.MouseDown += new MouseButtonEventHandler(grid_MouseDown);
            }
        }

        public delegate void UserSelectedEventHandler();
        public event UserSelectedEventHandler UserSelected;

        void grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            selectedKullanici = kullanicilar.Where(p => p.Id == Convert.ToInt32((sender as Grid).Uid)).First();
        }
    }
}
