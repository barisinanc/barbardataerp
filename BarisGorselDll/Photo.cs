using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace BarisGorselDLL
{
    public class Photo
    {
        private string _path;
        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                Bmp = new Bitmap(value);
                _path = value;
            }
        }

        public Bitmap Bmp;

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }


        public void JpegSave(ref Bitmap bmp, string FilePath, long quality)
        {
            // Get a bitmap.
            //Bitmap bmp1 = new Bitmap(FilePath);

            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);

            // Create an Encoder object based on the GUID
            // for the Quality parameter category.
            System.Drawing.Imaging.Encoder myEncoder =
                        System.Drawing.Imaging.Encoder.Quality;

            // Create an EncoderParameters object.
            // An EncoderParameters object has an array of EncoderParameter
            // objects. In this case, there is only one
            // EncoderParameter object in the array.
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, quality);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp.Save(FilePath, jgpEncoder, myEncoderParameters);
            jgpEncoder = null;
            myEncoder = null;
            myEncoderParameters.Dispose();
            myEncoderParameters = null;
            myEncoderParameter.Dispose();
            myEncoderParameter = null;
        }

        public void JpegSave(string path, long quality)
        {
            // Get a bitmap.
            //Bitmap bmp1 = new Bitmap(FilePath);

            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);

            // Create an Encoder object based on the GUID
            // for the Quality parameter category.
            System.Drawing.Imaging.Encoder myEncoder =
                        System.Drawing.Imaging.Encoder.Quality;

            // Create an EncoderParameters object.
            // An EncoderParameters object has an array of EncoderParameter
            // objects. In this case, there is only one
            // EncoderParameter object in the array.
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, quality);
            myEncoderParameters.Param[0] = myEncoderParameter;
            this.Bmp.Save(path, jgpEncoder, myEncoderParameters);
            jgpEncoder = null;
            myEncoder = null;
            myEncoderParameters.Dispose();
            myEncoderParameters = null;
            myEncoderParameter.Dispose();
            myEncoderParameter = null;
        }

        public enum RotateTypes
        {
            Left, Right
        }

        public void Rotate(ref Bitmap bmp, RotateTypes rotate)
        {
            if (rotate == RotateTypes.Right)
            {
                bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else
            {
                bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
        }

        public void Rotate(RotateTypes rotate)
        {
            if (rotate == RotateTypes.Right)
            {
                this.Bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else
            {
                this.Bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
        }

        public static Bitmap Psd2Bitmap(string Path)
        {
            PhotoshopFile.PsdFile psd = new PhotoshopFile.PsdFile();
            psd.Load(Path);
            Bitmap bmp = PhotoshopFile.ImageDecoder.DecodeImage(psd);
            

            /*
            MagickNet.Magick.Init();
            MagickNet.Image img = new MagickNet.Image(Path);
            //string temp = System.IO.Path.GetTempPath()+System.IO.Path.GetFileNameWithoutExtension(Path)+".jpg";
            
            Bitmap bmp = new Bitmap(MagickNet.Image.ToBitmap(img));
            MagickNet.Magick.Term();
            //temp = null;
            img.Dispose();
            img = null;
          * */
            return bmp;
        }

     
        public static string ThumbPathCreator(string _Path)
        {
            string folderPath = System.IO.Path.GetFullPath(_Path).Replace(System.IO.Path.GetFileName(_Path), "") + "_thumbs\\";
            if (!System.IO.Directory.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
                File.SetAttributes(folderPath, FileAttributes.NotContentIndexed | FileAttributes.Hidden | FileAttributes.System);
            }

            return folderPath + System.IO.Path.GetFileName(_Path) + ".thumb";
            
        }

        public static string ThumbFolderCreator(string _Path)
        {
            string folderPath = System.IO.Path.GetFullPath(_Path) + "_thumbs\\";
            if (!System.IO.Directory.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
                File.SetAttributes(folderPath, FileAttributes.NotContentIndexed | FileAttributes.Hidden | FileAttributes.System);
            }

            return folderPath;

        }

        public static void ThumbCreate(string Path, Size size)
        {
            FileInfo fileInfo = new FileInfo(Path);
            Image img;
            if (fileInfo.Extension.ToUpper() == "PSD")
            {
                img = Photo.Psd2Bitmap(Path);
            }
            else
            {
                img = Image.FromFile(Path);
            }

            int height = size.Height;
            int width = size.Width;
            decimal ratio = ((decimal)img.Size.Width / (decimal)img.Size.Height);

            if (img.Size.Width > img.Size.Height)
            {
                height = (int)((decimal)height / ratio);
            }
            else
            {
                width = (int)((decimal)width * ratio);
            }
            img = img.GetThumbnailImage(width, height, null, new System.IntPtr());
            Bitmap bmp = new Bitmap(img);
            img.Dispose();
            img = null;
            Photo ph = new Photo();
            ph.JpegSave(ref bmp, ThumbPathCreator(Path), 80);
            ph = null;
            bmp.Dispose();
            bmp = null;
            GC.Collect();
        }

        public static void ThumbCreate(string Path)
        {
            FileInfo fileInfo = new FileInfo(Path);
            Image img;
            if (fileInfo.Extension.ToUpper() == ".PSD")
            {
                img = Photo.Psd2Bitmap(Path);
            }
            else
            {
                img = Image.FromFile(Path);
            }
            int height = 300;
            int width = 300;
            decimal ratio = ((decimal)img.Size.Width / (decimal)img.Size.Height);

            if (img.Size.Width > img.Size.Height)
            {
                height = (int)((decimal)height / ratio);
            }
            else 
            {
                width = (int)((decimal)width * ratio);
            }

            img = img.GetThumbnailImage(width, height, null, new System.IntPtr());
            Bitmap bmp = new Bitmap(img);
            img.Dispose();
            img = null;
            Photo ph = new Photo();
            ph.JpegSave(ref bmp, ThumbPathCreator(Path), 80);
            ph = null;
            
            bmp.Dispose();
            bmp = null;
            GC.Collect();
        }


        public static byte[] BmpToBytes_Serialization(Bitmap bmp)
        {
            // stream to save the bitmap to
            MemoryStream ms = new MemoryStream();
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            bf.Serialize(ms, bmp);

            // read to end
            byte[] bmpBytes = ms.GetBuffer();
            bmp.Dispose();
            ms.Close();

            return bmpBytes;
        }

    }

}

