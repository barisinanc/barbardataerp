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
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            } return null;
        }

        public void JpegDondur(string FilePath, int Aci)
        {
            //Load a bitmap from file

            Bitmap bm = (Bitmap)Image.FromFile(FilePath);



            //Get the list of available encoders

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();



            //find the encoder with the image/jpeg mime-type

            ImageCodecInfo ici = null;

            foreach (ImageCodecInfo codec in codecs)
            {

                if (codec.MimeType == "image/jpeg")

                    ici = codec;

            }



            //Create a collection of encoder parameters (we only need one in the collection)

            EncoderParameters ep = new EncoderParameters();



            //We'll save images with 25%, 50%, 75% and 100% quality as compared with the original

            for (int x = 25; x < 101; x += 25)
            {

                //Create an encoder parameter for quality with an appropriate level setting

                ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)x);

                //Save the image with a filename that indicates the compression quality used

                bm.Save("C:\\quality" + x.ToString() + ".jpg", ici, ep);

            }
        }


    }
}
