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
            galeryFill();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Filter = "*.jpg";
            watcher.Path = @"d:\kimlik";
            watcher.EnableRaisingEvents = true;
            watcher.Renamed += new RenamedEventHandler(watcher_Renamed);
            watcher.Created += new FileSystemEventHandler(watcher_Created);
        }

        void watcher_Created(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show(e.Name);
        }

        void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            MessageBox.Show(e.Name);
        }

        private void galeryFill()
        {
            for (int i = 0; i < 10; i++)
            {
                Uri adres = new Uri(@"D:\kimlik\Yeni klasör\IMG_7187.JPG");
                Image photo = new Image();
                photo.MouseDown += new MouseButtonEventHandler(photo_MouseDown);
                BitmapImage resim = new BitmapImage(adres);
                photo.Source = resim;
                photo.Width = sliderSize.Value;
                photo.Height = (resim.Height / resim.Width) * sliderSize.Value;
                photo.Margin = new Thickness(0, 0, 0, 20);
                
                CheckBox check = new CheckBox();
                check.Content = System.IO.Path.GetFileNameWithoutExtension(adres.LocalPath);
                check.Margin = new Thickness(0, 0, 6, 0);
                check.Height = 16;
                check.VerticalAlignment = VerticalAlignment.Bottom;
                check.HorizontalAlignment = HorizontalAlignment.Center;
                Grid grid = new Grid();
                grid.Children.Add(photo);
                grid.Children.Add(check);
                grid.Height = photo.Height;
                grid.Width = photo.Width;
                wrapPanelGallery.Children.Add(grid);
                grid.Margin = new Thickness(5, 5, 5, 5);
            }
        }

        void photo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 1)
            {
                BitmapImage selectedImage = ((BitmapImage)(((Image)sender).Source));
                imageSelected.Source = selectedImage;
            }
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                PhotoView viewer = new PhotoView(((BitmapImage)(((Image)sender).Source)).UriSource.LocalPath);
                viewer.Show();
                viewer.WindowState = WindowState.Maximized;
                viewer.Topmost = true;
            }
        }

        private void sliderSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            foreach (Grid g in wrapPanelGallery.Children)
            {
                double width = ((Image)g.Children[0]).ActualWidth;
                double height = ((Image)g.Children[0]).ActualHeight;
                g.Width = sliderSize.Value;
                g.Height = (height / width) * sliderSize.Value;
                ((Image)g.Children[0]).Width=g.Width;
                ((Image)g.Children[0]).Height = g.Height;
            }
        }

        private Image selectedImage;

        private void buttonLeft_Click(object sender, RoutedEventArgs e)
        {
            ((Button)(sender)).IsEnabled = false;
            BarisGorselDLL.Photo foto = new BarisGorselDLL.Photo();
            foto.Path = @"C:\DSC_7233.JPG";
            foto.Rotate(BarisGorselDLL.Photo.RotateTypes.Left);
            foto.JpegSave(foto.Path, 100);
            ((Button)(sender)).IsEnabled = true;
        }

        private void buttonRight_Click(object sender, RoutedEventArgs e)
        {
            ((Button)(sender)).IsEnabled = false;
            BarisGorselDLL.Photo foto = new BarisGorselDLL.Photo();
            foto.Path = @"C:\DSC_7233.JPG";
            foto.Rotate(BarisGorselDLL.Photo.RotateTypes.Left);
            foto.JpegSave(foto.Path, 100);
            ((Button)(sender)).IsEnabled = true;
        }

        
    }
}
