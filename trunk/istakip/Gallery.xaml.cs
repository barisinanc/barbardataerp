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
using System.Windows.Media.Animation;

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
                if (!(_Path == "" || _Path == null))
                {
                    Thread islemFill = new Thread(new ThreadStart(delegate { fillImageList(_Path); }));
                    islemFill.SetApartmentState(ApartmentState.STA);
                    islemFill.Start();
                    watcher.Filter = "*.jpg";
                    watcher.Path = _Path;
                    watcher.EnableRaisingEvents = true;
                    
                }
            }
        }

        FileSystemWatcher watcher = new FileSystemWatcher();

        void watcher_Update(object sender, FileSystemEventArgs e)
        {
            Thread islemFill = new Thread(new ThreadStart(delegate { fillImageList(_Path); }));
            islemFill.SetApartmentState(ApartmentState.STA);
            islemFill.Start();
        }

        
        public Gallery()
        {            
            InitializeComponent();
            watcher.Renamed += new RenamedEventHandler(watcher_Update);
            watcher.Created += new FileSystemEventHandler(watcher_Update);
            watcher.Deleted += new FileSystemEventHandler(watcher_Update);
            watcher.Changed += new FileSystemEventHandler(watcher_Update);
            Uri adresSola = new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/rotate.png", UriKind.RelativeOrAbsolute);
            BitmapImage resimSola = new BitmapImage(adresSola);
            rotateLeftImage.Source = resimSola;
            Uri adresSaga = new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/rotate_cw.png", UriKind.RelativeOrAbsolute);
            BitmapImage resimSaga = new BitmapImage(adresSaga);
            rotateRightImage.Source = resimSaga;

            Uri adresSil = new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/delete.png", UriKind.RelativeOrAbsolute);
            BitmapImage resimSil = new BitmapImage(adresSil);
            selectedDelete.Source = resimSil;

            if (istakip.Properties.Settings.Default.GalleryPath != "")
            {
                Path = istakip.Properties.Settings.Default.GalleryPath;
            }
        }

       

        
        public List<ImagePack> ImageList = new List<ImagePack>();
        List<string> DirectoryList = new List<string>();
        private void fillImageList(string FolderPath)
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
                methodClear();
                foreach (string dir in Directory.GetDirectories(FolderPath).Where(p=>!p.EndsWith("_thumbs")))
                {
                    DirectoryList.Add(dir);
                    methodFolderFill(dir);
                }
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
                    methodGaleryFill(paket);
                }
            

        }

        private delegate void delegateClear();
        public void methodClear()
        {
            delegateClear del = new delegateClear(Clear);
            this.Dispatcher.Invoke(del);
        }

        private void Clear()
        {
            wrapPanelGallery.Children.Clear();
            ImageList.Clear();
        }
        private delegate void delegateGaleryFill(ImagePack img);
        public void methodGaleryFill(ImagePack img)
        {
           
                delegateGaleryFill del = new delegateGaleryFill(galeryFill);
                this.Dispatcher.Invoke(del, img);
            
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
            
            photo.Margin = new Thickness(0, 0, 0, 30);

            Uri adresDelete = new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Images/delete.png", UriKind.RelativeOrAbsolute);
            BitmapImage resimDelete = new BitmapImage(adresDelete);
            Image deleteImage = new Image();
            deleteImage.Source = resimDelete;
            deleteImage.Margin = new Thickness(0, 0, 6, 0);
            deleteImage.VerticalAlignment = VerticalAlignment.Bottom;
            deleteImage.HorizontalAlignment = HorizontalAlignment.Right;
            deleteImage.Height = 18;
            deleteImage.MouseDown += new MouseButtonEventHandler(deleteImage_MouseDown);
            deleteImage.Uid = img.Id.ToString();

            CheckBox check = new CheckBox();
            check.Checked += new RoutedEventHandler(check_Checked);
            check.Unchecked += new RoutedEventHandler(check_Unchecked);
            check.Uid = img.Id.ToString();
            check.Content = System.IO.Path.GetFileNameWithoutExtension(img.Name);
            check.Margin = new Thickness(0, 0, 6, 18);
            check.Height = 16;
            check.VerticalAlignment = VerticalAlignment.Bottom;
            check.HorizontalAlignment = HorizontalAlignment.Center;

            Grid grid = new Grid();
            grid.Uid = img.Id.ToString();
            grid.Children.Add(photo);
            grid.Children.Add(check);
            grid.Children.Add(deleteImage);
            grid.Height = sliderSize.Value;
            grid.Width = sliderSize.Value;
            //grid.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(50, 100, 150, 100));

            

            wrapPanelGallery.Children.Add(grid);
            grid.BeginAnimation(Grid.OpacityProperty, new DoubleAnimation(0.00, 1, new Duration(new TimeSpan(0, 0, 1))));
            grid.Margin = new Thickness(5, 5, 5, 5);
        }

        void deleteImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 1)
            {
                if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Onaylayın", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ImagePack image = ImageList.Where(p=>p.Id==Convert.ToInt32(((Image)sender).Uid)).Single();
                    File.Delete(image.Path);
                    File.Delete(image.ThumbPath);
                    wrapPanelGallery.Children.Remove((Grid)((Image)sender).Parent);
                    ImageList.Remove(image);
                }
            }
        }

        private delegate void delegateFolderFill(string path);
        public void methodFolderFill(string path)
        {

            delegateFolderFill del = new delegateFolderFill(folderFill);
            this.Dispatcher.Invoke(del, path);

        }

        private void folderFill(string path)
        {
            Image photo = new Image();
            //photo.MouseDown += new MouseButtonEventHandler(photo_MouseDown);
            Uri adres = new Uri(AppDomain.CurrentDomain.BaseDirectory+"/Images/folder.gif",UriKind.RelativeOrAbsolute);
            BitmapImage resim = new BitmapImage(adres);
            photo.Uid = path;
            photo.Source = resim;

            photo.Margin = new Thickness(0, 0, 0, 20);

            Label folderName = new Label();
            folderName.Content = new DirectoryInfo (path).Name;
            folderName.VerticalAlignment = VerticalAlignment.Bottom;
            folderName.HorizontalAlignment = HorizontalAlignment.Center;
            folderName.Margin = new Thickness(0, 0, 6, 0);
            
            Uri adresDelete = new Uri(AppDomain.CurrentDomain.BaseDirectory+"/Images/delete.png",UriKind.RelativeOrAbsolute);
            BitmapImage resimDelete = new BitmapImage(adresDelete);
            Image deleteFolder = new Image();
            deleteFolder.Source= resimDelete;
            deleteFolder.Margin = new Thickness(0, 0, 6, 0);
            deleteFolder.VerticalAlignment = VerticalAlignment.Bottom;
            deleteFolder.HorizontalAlignment = HorizontalAlignment.Right;
            deleteFolder.Height = 18;
            deleteFolder.MouseDown += new MouseButtonEventHandler(deleteFolder_MouseDown);
            deleteFolder.Uid = path;

            Grid grid = new Grid();
            grid.Uid = path;
            grid.Children.Add(photo);
            grid.Children.Add(folderName);
            grid.Children.Add(deleteFolder);
            
            grid.Height = sliderSize.Value;
            grid.Width = sliderSize.Value;
            //grid.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(50, 100, 150, 100));

            wrapPanelGallery.Children.Add(grid);
            grid.BeginAnimation(Grid.OpacityProperty, new DoubleAnimation(0.00, 1, new Duration(new TimeSpan(0, 0, 1))));
            grid.Margin = new Thickness(5, 5, 5, 5);
        }

        void deleteFolder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 1)
            {
                if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Onaylayın", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    
                    Directory.Delete(((Image)sender).Uid);
                    wrapPanelGallery.Children.Remove((Grid)((Image)sender).Parent);
                    DirectoryList.Remove(Uid);
                }
            }
        }

        void check_Unchecked(object sender, RoutedEventArgs e)
        {
            ImagePack secilen = ImageList.Where(p => p.Id == Convert.ToInt32(((CheckBox)sender).Uid)).Single();
            secilen.IsSelected = false;
            secilen.IsFlagged = false;
        }

        void check_Checked(object sender, RoutedEventArgs e)
        {
            ImagePack secilen = ImageList.Where(p => p.Id==Convert.ToInt32(((CheckBox)sender).Uid)).Single();
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
                foreach (Grid x in wrapPanelGallery.Children)
                {
                    x.Background = null;
                }
                Grid secilenGrid = this.wrapPanelGallery.Children.OfType<Grid>().Where(p=>p.Uid==secilen.Id.ToString()).First();
                secilenGrid.Background = Brushes.AntiqueWhite;
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
            imageFlag.IsChecked = image.IsFlagged;
            imageSelected.BeginAnimation(Image.OpacityProperty, new DoubleAnimation(0.00, 1, new Duration(new TimeSpan(0, 0, 0, 0, 300))));
            
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

        private void buttonPathSelect_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Path = dialog.SelectedPath;
            }
        }

        private void imageFlag_Checked(object sender, RoutedEventArgs e)
        {
            ImagePack secilen = ImageList.Where(p => p.IsClicked.Equals(true)).Single();
            secilen.IsFlagged = true;
            wrapPanelGallery.Children.OfType<Grid>().Where(p => p.Uid == secilen.Id.ToString()).Single().Children.OfType<CheckBox>().Single().IsChecked = true;
        }

        private void imageFlag_Unchecked(object sender, RoutedEventArgs e)
        {
            ImagePack secilen = ImageList.Where(p => p.IsClicked.Equals(true)).Single();
            secilen.IsFlagged = false;
        }

        private void gridSplitter1_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            gridDescription.Margin = new Thickness(0, imageSelected.ActualHeight + 10, 0, 0);
        }

        private void imageSelected_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            gridDescription.Margin = new Thickness(0, imageSelected.ActualHeight + 10, 0, 0);
        }

        private void selectedDelete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 1)
            {

                if (ImageList.Where(p => p.IsClicked.Equals(true)).Count() > 0)
                {
                    if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Onaylayın", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        ImagePack secilen = ImageList.Where(p => p.IsClicked.Equals(true)).Single();
                        File.Delete(secilen.Path);
                        File.Delete(secilen.ThumbPath);
                        wrapPanelGallery.Children.Remove(wrapPanelGallery.Children.OfType<Grid>().Where(p=>p.Uid==secilen.Id.ToString()).Single());
                        ImageList.Remove(secilen);
                        imageSelected.Source = null;
                    }
                   
                    
                }


                
            }
        }

        private void rotateLeftImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ((Image)(sender)).IsEnabled = false;
            if (ImageList.Where(p => p.IsClicked.Equals(true)).Count() > 0)
            {
                ImagePack secilen = ImageList.Where(p => p.IsClicked.Equals(true)).Single();
                secilen.Rotate(BarisGorselDLL.Photo.RotateTypes.Left);
                ShowImage();
                wrapPanelGallery.Children.OfType<Grid>().Where(p => p.Uid == secilen.Id.ToString()).First().Children.OfType<Image>().First().Source = secilen.ThumbRead();
            }
            ((Image)(sender)).IsEnabled = true;
        }

        private void rotateRightImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ((Image)(sender)).IsEnabled = false;
            if (ImageList.Where(p => p.IsClicked.Equals(true)).Count() > 0)
            {
                ImagePack secilen = ImageList.Where(p => p.IsClicked.Equals(true)).Single();
                secilen.Rotate(BarisGorselDLL.Photo.RotateTypes.Right);
                ShowImage();
                wrapPanelGallery.Children.OfType<Grid>().Where(p => p.Uid == secilen.Id.ToString()).First().Children.OfType<Image>().First().Source = secilen.ThumbRead();
            }
            ((Image)(sender)).IsEnabled = true;
        }

        private void buttonSaveText_Click(object sender, RoutedEventArgs e)
        {
            ImageList.Where(p => p.IsClicked.Equals(true)).Single().Description = textDescription.Text;
        }
 
    }
}
