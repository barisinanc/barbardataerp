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
            BitmapImage currentBitmapImage = new BitmapImage();
            MemoryStream memoryStream;
            byte[] byteArray;
            if (Path.ToUpper().EndsWith(".PSD"))
            {
                /*memoryStream = new MemoryStream();
                System.Drawing.Image bmp = BarisGorselDLL.Photo.Psd2Bitmap(Path);
                bmp.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
                bmp.Dispose();
                bmp = null;*/
                (BarisGorselDLL.Photo.Psd2Bitmap(Path)).Save("psd.temp");
                byteArray = File.ReadAllBytes("psd.temp");
                File.Delete("psd.temp");
                // System.Drawing.Image img = System.Drawing.Image.FromStream(memoryStream);
                // img.Save("c:\\sd.bmp");
            }
            else
            {
                byteArray = File.ReadAllBytes(Path);
            }
            memoryStream = new MemoryStream(byteArray, 0, byteArray.Length, false, false);
            byteArray = null;


            currentBitmapImage.BeginInit();
            currentBitmapImage.StreamSource = memoryStream;
            currentBitmapImage.EndInit();
            memoryStream.Close();
            memoryStream.Dispose();
            memoryStream = null;
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
