using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace arsiv.BarisGorselDLL
{
    class Barcode
    {

        private PrintDocument printDocument = new PrintDocument();
        public string BarcodeNo;
        public string CariAdi;
        public void yazdir()
        {
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            PrintDialog pd = new PrintDialog();
            PrintPreviewDialog pre = new PrintPreviewDialog();
            pre.Document = printDocument;
            pre.ShowDialog();
            //printDocument.Print();
            pd.Document = printDocument;
            
            if (pd.ShowDialog() == DialogResult.OK)
            {
                pd.Document.Print();
            }
        }

        void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(Create(), 2, 5);
            Font footerFont = new Font("Courier", 14, FontStyle.Bold);
            e.Graphics.DrawString(CariAdi, footerFont, Brushes.Black, 40, 110);
            e.Graphics.DrawString(BarcodeNo.ToUpper().Trim(), footerFont, Brushes.Black, 55, 92);
            /*e.Graphics.DrawImage(Create(), 2, 70);
            Font footerFont = new Font("Courier", 14, FontStyle.Bold);
            e.Graphics.DrawString(CariAdi, footerFont, Brushes.Black, 40, 175);
            e.Graphics.DrawString(BarcodeNo.ToUpper().Trim(), footerFont, Brushes.Black, 55, 157);*/
        }

        private Image Create()
        {
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE128;
            b.IncludeLabel = false;
            b.ImageFormat = ImageFormat.Bmp;
            return b.Encode(type, BarcodeNo.Trim(), Color.Black, Color.White, 255, 85);
        }
        
    }
}
