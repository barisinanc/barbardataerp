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

            //Uri adres = new Uri(@"C:\galeri.psd");
            /*BarisGorselDLL.Photo ph = new BarisGorselDLL.Photo();
            System.Drawing.Bitmap bmp = ph.PsdImage(@"C:\galeri.PSD");
            image1.Source = PhotoConvert.BitmapImagetoBitmap(bmp);*/
            MessageBox.Show(fun(6).ToString());
            Thread islemFill = new Thread(new ThreadStart(delegate{fillImageList("D:\\kimlik");}));
            islemFill.SetApartmentState(ApartmentState.STA);
            islemFill.Start();
            
        }

        private double fun(double x)
        {
            if (x > 2)
                return fun(x - 1) + fun(x / 2);
            else
                return 1;
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

        private class ImagePack
        {
            private string _Path;
            public string Path
            {
                get
                {
                    return _Path;
                }
                set
                {
                    _Path = value;
                    IsThumbCreated();
                    _ThumbPath = BarisGorselDLL.Photo.ThumbPathCreator(value);
                }
            }

            private void IsThumbCreated()
            {
                if (!File.Exists(BarisGorselDLL.Photo.ThumbPathCreator(_Path)))
                {
                    BarisGorselDLL.Photo.ThumbCreate(_Path);
                }
            }
            public string Name { get; set; }
            private string _ThumbPath;
            public string ThumbPath
            {
                get
                {
                    return _ThumbPath;
                }
                set
                {
                    _ThumbPath = value;
                }
            }
            public bool IsSelected;
            public bool IsClicked;
            public int Id;
        }

        List<ImagePack> ImageList = new List<ImagePack>();

        private void fillImageList(string FolderPath)
        {
            try
            {
                IEnumerable<string> fileNames =
                    Directory.GetFiles(FolderPath).Where(f => !f.Contains("_thumb.jpg")).Where(
                        f => f.EndsWith(".jpg")
                            || f.EndsWith(".bmp")
                            || f.EndsWith(".png")
                            || f.EndsWith(".psd")
                    );

                int i = 0;
                foreach (string x in fileNames)
                {
                    i++;
                    FileInfo file = new FileInfo(x);
                    ImagePack paket = new ImagePack();
                    paket.Path = file.FullName;
                    paket.Name = file.Name;
                    paket.IsClicked = false;
                    paket.IsSelected = false;
                    paket.Id = i;
                    ImageList.Add(paket);
                }
                
            }
            catch { }
            methodGaleryFill();
            
        }
        private delegate void delegateGaleryFill(ImagePack img);
        public void methodGaleryFill()
        {
            foreach (ImagePack img in ImageList)
            {
                delegateGaleryFill del = new delegateGaleryFill(galeryFill);
                this.Dispatcher.Invoke(del, img);
            }
        }

        private void galeryFill(ImagePack img)
        {
                Uri adres = new Uri(img.ThumbPath);
                Image photo = new Image();
                photo.MouseDown += new MouseButtonEventHandler(photo_MouseDown);
                BitmapImage resim=null;
                if (!img.Name.EndsWith(".psd"))
                {
                    resim = new BitmapImage(adres);
                }
                else
                {
                    
                }
                photo.Uid = img.Id.ToString();
                photo.Source = resim;
                photo.Width = sliderSize.Value;
                photo.Height = (resim.Height / resim.Width) * sliderSize.Value;
                photo.Margin = new Thickness(0, 0, 0, 20);
                
                CheckBox check = new CheckBox();
                check.Content = System.IO.Path.GetFileNameWithoutExtension(img.Name);
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

        void photo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 1)
            {
                foreach (ImagePack p in ImageList)
                {
                    p.IsClicked = false;
                }
                ImagePack secilen = ImageList.Where(p => p.Id.Equals(((Image)sender).Uid)).Single();
                secilen.IsClicked = true;
            }
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                PhotoView viewer = new PhotoView(((BitmapImage)(((Image)sender).Source)).UriSource.LocalPath);
                viewer.Show();
                viewer.WindowState = WindowState.Maximized;
                viewer.Topmost = true;
            }
        }

        private void imageClicked(int Id)
        {
            //BitmapImage selectedImage = ((BitmapImage)(((Image)sender).Source));
            //imageSelected.Source = selectedImage;
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
