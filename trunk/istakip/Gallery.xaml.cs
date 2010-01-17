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
using System.IO;
using System.Threading;

namespace istakip
{
    /// <summary>
    /// Interaction logic for Gallery.xaml
    /// </summary>
    public partial class Gallery : UserControl
    {
        private string _Path;
        public string Path
        {
            get { return _Path; }
            set {
                _Path = value;

                labelPath.Content = _Path;
                labelPath.ToolTip = _Path;

                istakip.Properties.Settings.Default.GalleryPath = _Path;
                istakip.Properties.Settings.Default.Save();

                Thread islemFill = new Thread(new ThreadStart(delegate { fillImageList(_Path); }));
                islemFill.SetApartmentState(ApartmentState.STA);
                islemFill.Start();
            }
        }
        public Gallery()
        {            
            InitializeComponent();
            if (istakip.Properties.Settings.Default.GalleryPath != "")
            {
                Path = istakip.Properties.Settings.Default.GalleryPath;
            }
        }
        List<ImagePack> ImageList = new List<ImagePack>();

        private void fillImageList(string FolderPath)
        {
            try
            {
                IEnumerable<string> fileNames =
                    Directory.GetFiles(FolderPath).Where(f => !f.Contains(".thumb")).Where(
                        f => f.EndsWith(".jpg")
                            || f.EndsWith(".JPG")
                            || f.EndsWith(".bmp")
                            || f.EndsWith(".BMP")
                            || f.EndsWith(".png")
                            || f.EndsWith(".PNG")
                            || f.EndsWith(".psd")
                            || f.EndsWith(".PSD")
                    );

                int i = 0;
                ImageList.Clear();
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
            Image photo = new Image();
            photo.MouseDown += new MouseButtonEventHandler(photo_MouseDown);
            BitmapImage resim = null;
            if (!img.Name.EndsWith(".psd"))
            {
                resim = img.ThumbRead();
            }
            else
            {
                
            }
            photo.Uid = img.Id.ToString();
            photo.Source = resim;
            
            photo.Margin = new Thickness(0, 0, 0, 20);

            CheckBox check = new CheckBox();
            check.Checked += new RoutedEventHandler(check_Checked);
            check.Unchecked += new RoutedEventHandler(check_Unchecked);
            check.Uid = img.Id.ToString();
            check.Content = System.IO.Path.GetFileNameWithoutExtension(img.Name);
            check.Margin = new Thickness(0, 0, 6, 0);
            check.Height = 16;
            check.VerticalAlignment = VerticalAlignment.Bottom;
            check.HorizontalAlignment = HorizontalAlignment.Center;
            Grid grid = new Grid();
            grid.Uid = img.Id.ToString();
            grid.Children.Add(photo);
            grid.Children.Add(check);
            grid.Height = sliderSize.Value;
            grid.Width = sliderSize.Value;
            grid.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(50, 100, 150, 100));

            wrapPanelGallery.Children.Add(grid);
            grid.Margin = new Thickness(5, 5, 5, 5);
        }
        void check_Unchecked(object sender, RoutedEventArgs e)
        {
            ImagePack secilen = ImageList.Where(p => p.Id == Convert.ToInt32(((CheckBox)sender).Uid)).Single();
            secilen.IsSelected = false;
        }

        void check_Checked(object sender, RoutedEventArgs e)
        {
            ImagePack secilen = ImageList.Where(p => p.Id==Convert.ToInt32(((CheckBox)sender).Uid)).Single();//TODO Uidden git bul değiştir
            secilen.IsSelected = true;
        }

        void photo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 1)
            {
                foreach (ImagePack p in ImageList)
                {
                    p.IsClicked = false;
                }
                ImagePack secilen = ImageList.Where(p => p.Id.Equals(Convert.ToInt32(((Image)sender).Uid))).Single();
                secilen.IsClicked = true;
                ShowImage();
            }
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                ImagePack secilen = ImageList.Where(p => p.IsClicked.Equals(true)).Single();
                PhotoView viewer = new PhotoView(secilen.Path);
                viewer.Show();
                viewer.WindowState = WindowState.Maximized;
                viewer.Topmost = true;
            }
        }


        private void ShowImage()
        {
            ImagePack image = ImageList.Where(p => p.IsClicked.Equals(true)).Single();
            imageSelected.Source = image.ImageRead();
            labelFileName.Content = image.Name;
        }

        private void sliderSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            foreach (Grid g in wrapPanelGallery.Children)
            {
                double width = ((Image)g.Children[0]).ActualWidth;
                double height = ((Image)g.Children[0]).ActualHeight;

                g.Width = sliderSize.Value;
                g.Height = sliderSize.Value;
                /*if (((Image)g.Children[0]).Width > ((Image)g.Children[0]).Height)
                {
                    ((Image)g.Children[0]).Width = sliderSize.Value;
                    ((Image)g.Children[0]).Height = (int)(((decimal)((Image)g.Children[0]).ActualHeight / (decimal)((Image)g.Children[0]).ActualWidth) * (decimal)sliderSize.Value);
                }
                else
                {
                    ((Image)g.Children[0]).Height = sliderSize.Value;
                    ((Image)g.Children[0]).Width = (int)(((decimal)((Image)g.Children[0]).ActualWidth / (decimal)((Image)g.Children[0]).ActualHeight) * (decimal)sliderSize.Value);
                }
                */
            }
        }



        private void buttonLeft_Click(object sender, RoutedEventArgs e)
        {
            ((Button)(sender)).IsEnabled = false;
            if (ImageList.Where(p => p.IsClicked.Equals(true)).Count() > 0)
            {
                ImagePack secilen = ImageList.Where(p => p.IsClicked.Equals(true)).Single();
                secilen.Rotate(BarisGorselDLL.Photo.RotateTypes.Left);
                ShowImage();
                foreach (Grid x in wrapPanelGallery.Children.OfType<Grid>())
                {
                    if (x.Uid == secilen.Id.ToString())
                    {
                        x.Children.OfType<Image>().Single().Source = secilen.ThumbRead();
                        break;
                    }
                }
            }
            ((Button)(sender)).IsEnabled = true;
        }

        private void buttonRight_Click(object sender, RoutedEventArgs e)
        {
            ((Button)(sender)).IsEnabled = false;
            if (ImageList.Where(p => p.IsClicked.Equals(true)).Count() > 0)
            {
                ImagePack secilen = ImageList.Where(p => p.IsClicked.Equals(true)).Single();
                secilen.Rotate(BarisGorselDLL.Photo.RotateTypes.Right);
                ShowImage();
                foreach (Grid x in wrapPanelGallery.Children.OfType<Grid>())
                {
                    if (x.Uid == secilen.Id.ToString())
                    {
                        x.Children.OfType<Image>().Single().Source = secilen.ThumbRead();
                        break;
                    }
                }
            }
            ((Button)(sender)).IsEnabled = true;

        }

        private void buttonPathSelect_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Path = dialog.SelectedPath;
            }
        }
 
    }
}
