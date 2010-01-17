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
using System.Windows.Shapes;
using System.IO;

namespace istakip
{
    /// <summary>
    /// Interaction logic for PhotoView.xaml
    /// </summary>
    public partial class PhotoView : Window
    {
        public PhotoView(string path)
        {
            InitializeComponent();
            _path = path;
        }
        private string _path;
        public PhotoView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            image1.Source = ImageRead(_path);
        }

        private BitmapImage ImageRead(string path)
        {
            // Avoid locks on file.
            byte[] byteArray = File.ReadAllBytes(path);
            MemoryStream memoryStream = new MemoryStream(byteArray, 0, byteArray.Length, false, false);
            byteArray = null;

            BitmapImage currentBitmapImage = new BitmapImage();
            currentBitmapImage.BeginInit();
            currentBitmapImage.StreamSource = memoryStream;
            currentBitmapImage.EndInit();
            return currentBitmapImage;
        }

    }
}
