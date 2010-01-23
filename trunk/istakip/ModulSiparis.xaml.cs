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
    public partial class ModulSiparis : Window
    {
        Menu menuler = new Menu();
        public ModulSiparis()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            menuler.SelectionChanged += new Menu.SelectionChangedEventHandler(menuler_SelectionChanged);
            MainGrid.Children.Add(menuler);
            menuler.Selected = Menu.MenuType.Photo;
        }

        void menuler_SelectionChanged()
        {
            gridModule.Children.Clear();
            if (menuler.Selected == Menu.MenuType.Photo)
            {
                Gallery galeri = new Gallery();
                gridModule.Children.Add(galeri);
                galeri.Saved += new Gallery.SavedEventHandler(galeri_Saved);
                galeri.Cancelled += new Gallery.CancelledEventHandler(galeri_Cancelled);
            }
            else if (menuler.Selected == Menu.MenuType.Product)
            {
                ProductSelect productControl = new ProductSelect();
                gridModule.Children.Add(productControl);
            }
            else if (menuler.Selected == Menu.MenuType.Customer)
            {
                CariSelect cariControl = new CariSelect();
                gridModule.Children.Add(cariControl);
                cariControl.Saved += new CariSelect.SavedEventHandler(cariControl_Saved);
                cariControl.Cancelled += new CariSelect.CancelledEventHandler(cariControl_Cancelled);
            }
            else if (menuler.Selected == Menu.MenuType.Report)
            {

            }
        }

        void cariControl_Cancelled()
        {
            menuler.Selected = Menu.MenuType.Product;
        }

        void cariControl_Saved()
        {
            menuler.Selected = Menu.MenuType.Report;
        }

        void galeri_Cancelled()
        {
            menuler.Selected = Menu.MenuType.Photo;
        }

        void galeri_Saved()
        {
            menuler.Selected = Menu.MenuType.Product;
        }
       

 


      
        
    }
}
