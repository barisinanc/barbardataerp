using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;

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

        public Bitmap PsdImage(string Path)
        {
            MagickNet.Magick.Init();
            MagickNet.Image img = new MagickNet.Image(Path);
            string temp = System.IO.Path.GetTempPath()+System.IO.Path.GetFileNameWithoutExtension(Path)+".jpg";
            img.Write(temp);
            MagickNet.Magick.Term();
            Bitmap bmp = new Bitmap(temp);
            temp = null;
            return bmp;
        }

     
        public static string ThumbPathCreator(string _Path)
        {
            return System.IO.Path.GetFullPath(_Path).Replace(System.IO.Path.GetFileName(_Path), "") + System.IO.Path.GetFileNameWithoutExtension(_Path) + "_thumb.jpg";
        }

        public static void ThumbCreate(string Path, Size size)
        {
            Image img = Image.FromFile(Path);
            decimal ratio = img.Width / img.Height;
            int height = size.Height;
            int width = size.Width;
            if (img.Height > img.Height)
            {
                width = Convert.ToInt32(ratio * height);
            }
            else
            {
                height = Convert.ToInt32(ratio / width);
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
            Image img = Image.FromFile(Path);
            Path = System.IO.Path.ChangeExtension(Path, ".jpg");
            int height = 400;
            int width = 400;
            decimal ratio = ((decimal)img.Size.Width / (decimal)img.Size.Height);
            height = (int)((decimal)width / ratio);
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

    }

}

