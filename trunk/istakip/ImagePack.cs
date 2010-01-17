using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Media.Imaging;

namespace istakip
{
    public class ImagePack:BarisGorselDLL.ImagePack
    {
        public BitmapImage ImageRead()
        {
            // Avoid locks on file.
            byte[] byteArray = File.ReadAllBytes(Path);
            MemoryStream memoryStream = new MemoryStream(byteArray, 0, byteArray.Length, false, false);
            byteArray = null;

            BitmapImage currentBitmapImage = new BitmapImage();
            currentBitmapImage.BeginInit();
            currentBitmapImage.StreamSource = memoryStream;
            currentBitmapImage.EndInit();
            //memoryStream.Dispose();
            //memoryStream = null;
            //byteArray = null;
            return currentBitmapImage;
        }

        public BitmapImage ThumbRead()
        {
            // Avoid locks on file.
            byte[] byteArray = File.ReadAllBytes(ThumbPath);
            MemoryStream memoryStream = new MemoryStream(byteArray, 0, byteArray.Length, false, false);
            byteArray = null;

            BitmapImage currentBitmapImage = new BitmapImage();
            currentBitmapImage.BeginInit();
            currentBitmapImage.StreamSource = memoryStream;
            currentBitmapImage.EndInit();
            memoryStream.Dispose();
            memoryStream = null;
            byteArray = null;
            return currentBitmapImage;
        }
    }
}
