using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace istakip
{
    class PhotoConvert
    {
        public static BitmapSource BitmapImagetoBitmap(Bitmap bitmap)
        {
            System.Windows.Media.Imaging.BitmapSource bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(

                    bitmap.GetHbitmap(),

                    IntPtr.Zero,

                    System.Windows.Int32Rect.Empty,

System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
            return bitmapSource;
        }
    }
}
