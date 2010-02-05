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
        List<ImagePack> ListImages;
        List<Sepet> ListSepet;
        Cari SelectedCari;
        Gallery galeri;
        ProductSelect productControl;
        CariSelect cariControl;
        Report reportControl;
        public ModulSiparis()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            menuler.SelectionChanged += new Menu.SelectionChangedEventHandler(menuler_SelectionChanged);
            MainGrid.Children.Add(menuler);
            menuler.Selected = Menu.MenuType.Photo;

            //cropControl crop = new cropControl();
            //MainGrid.Children.Add(crop);
        }

        void menuler_SelectionChanged()
        {
            gridModule.Children.Clear();
            if (menuler.Selected == Menu.MenuType.Photo)
            {
                galeri = new Gallery();
                galeri.ImageList = ListImages;
                gridModule.Children.Add(galeri);
                galeri.Saved += new Gallery.SavedEventHandler(galeri_Saved);
                galeri.Cancelled += new Gallery.CancelledEventHandler(galeri_Cancelled);
            }
            else if (menuler.Selected == Menu.MenuType.Product)
            {
                productControl = new ProductSelect();
                productControl.sepet = ListSepet;
                gridModule.Children.Add(productControl);
                productControl.Saved += new ProductSelect.SavedEventHandler(productControl_Saved);
                productControl.Cancelled += new ProductSelect.CancelledEventHandler(productControl_Cancelled);
            }
            else if (menuler.Selected == Menu.MenuType.Customer)
            {
                cariControl = new CariSelect();
                cariControl.selectedCari = SelectedCari;
                gridModule.Children.Add(cariControl);
                cariControl.Saved += new CariSelect.SavedEventHandler(cariControl_Saved);
                cariControl.Cancelled += new CariSelect.CancelledEventHandler(cariControl_Cancelled);
            }
            else if (menuler.Selected == Menu.MenuType.Report)
            {
                reportControl = new Report();
                reportControl.SelectedCari = SelectedCari;
                //reportControl.ListImages = (List<BarisGorselDLL.ImagePack>)ListImages;//TODO!!
                if (ListImages != null)
                {
                    List<BarisGorselDLL.ImagePack> newImages = new List<BarisGorselDLL.ImagePack>();
                    foreach (ImagePack img in ListImages)
                    {
                        newImages.Add(img);
                    }
                    reportControl.ListImages = newImages;
                }
                reportControl.ListSepet = ListSepet;
                gridModule.Children.Add(reportControl);
            }
        }

        void productControl_Cancelled()
        {
            menuler.Selected = Menu.MenuType.Photo;
        }

        void productControl_Saved()
        {
            ListSepet = productControl.sepet;
            menuler.Selected = Menu.MenuType.Customer;
        }

        void cariControl_Cancelled()
        {
            menuler.Selected = Menu.MenuType.Product;
        }

        void cariControl_Saved()
        {
            SelectedCari = cariControl.selectedCari;
            menuler.Selected = Menu.MenuType.Report;
        }

        void galeri_Cancelled()
        {
            menuler.Selected = Menu.MenuType.Photo;
        }

        void galeri_Saved()
        {
            ListImages = galeri.ImageList.Where(p=>p.IsSelected==true).ToList();
            menuler.Selected = Menu.MenuType.Product;
        }
       

 


      
        
    }
}
