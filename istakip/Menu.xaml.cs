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

namespace istakip
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
            loadMenu();
            gridPhoto.MouseDown += new MouseButtonEventHandler(gridPhoto_MouseDown);
            gridProduct.MouseDown += new MouseButtonEventHandler(gridProduct_MouseDown);
            gridReport.MouseDown += new MouseButtonEventHandler(gridReport_MouseDown);
            gridCustomer.MouseDown += new MouseButtonEventHandler(gridCustomer_MouseDown);
        }

        public enum MenuType{Product, Customer, Report, Photo}
        public MenuType _Selected;
        public MenuType Selected
        {
            get { return _Selected; }
            set {
                _Selected = value;
                if (_Selected == Menu.MenuType.Photo)
                {
                    BackgroundChanger(gridPhoto);
                }
                else if (_Selected == Menu.MenuType.Product)
                {
                    BackgroundChanger(gridProduct);
                }
                else if (_Selected == Menu.MenuType.Customer)
                {
                    BackgroundChanger(gridCustomer);
                }
                else if (_Selected == Menu.MenuType.Report)
                {
                    BackgroundChanger(gridReport);
                }
                
                if(SelectionChanged!=null)
                SelectionChanged();

            }
        }

        private void BackgroundChanger(object sender)
        {
            foreach (Grid g in ((Grid)((Grid)sender).Parent).Children.OfType<Grid>())
            {
                g.Background = Brushes.White;
            }
            ((Grid)sender).Background = Brushes.LightGreen;
        }

        void gridCustomer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 1)
            {
                Selected = MenuType.Customer;
            }
        }

        void gridReport_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 1)
            {
                Selected = MenuType.Report;
            }
        }

        void gridProduct_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 1)
            {
                Selected = MenuType.Product;
            }
        }

        void gridPhoto_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 1)
            {
                Selected = MenuType.Photo;
            }
        }

        public delegate void SelectionChangedEventHandler();
        public event SelectionChangedEventHandler SelectionChanged;

        private void loadMenu()
        {
            Uri adresPhoto = new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/photo.png", UriKind.RelativeOrAbsolute);
            BitmapImage resimPhoto = new BitmapImage(adresPhoto);
            imagePhoto.Source = resimPhoto;

            Uri adresProduct = new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/shopping_cart.png", UriKind.RelativeOrAbsolute);
            BitmapImage resimProduct = new BitmapImage(adresProduct);
            imageProduct.Source = resimProduct;

            Uri adresCustomer = new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/customer.png", UriKind.RelativeOrAbsolute);
            BitmapImage resimCustomer = new BitmapImage(adresCustomer);
            imageCustomer.Source = resimCustomer;

            Uri adresReport = new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/report_ok.png", UriKind.RelativeOrAbsolute);
            BitmapImage resimReport = new BitmapImage(adresReport);
            imageReport.Source = resimReport;

        }
    }
}
