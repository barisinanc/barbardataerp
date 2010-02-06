using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace BarisGorselDLL
{
    public class Barcode
    {

        private PrintDocument printDocument = new PrintDocument();
        public string BarcodeNo;
        public string CariAdi;
        public string Aciklama;
        public string Aciklama2;
        public bool Preview = false;
        public bool Dialog = false;
        public short Count = 1;
        public void yazdir()
        {
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            PrintDialog pd = new PrintDialog();
            if (Preview)
            {
                PrintPreviewDialog pre = new PrintPreviewDialog();
                pre.Document = printDocument;
                pre.ShowDialog();
            }
            //printDocument.Print();
            pd.Document = printDocument;
            pd.PrinterSettings.Copies = Count;
            if (Dialog)
            {
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    pd.Document.Print();
                }
            }
            else
            {
                pd.Document.Print();
            }
            GC.Collect();
        }

        void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(Create(), 0, 0);//99012 large address olcak dymo 330da
        }

        public Bitmap Create()
        {
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE128;
            b.IncludeLabel = false;
            b.ImageFormat = ImageFormat.Bmp;
            Image imageBarcode = b.Encode(type, BarcodeNo.Trim(), Color.Black, Color.White, 265, 75);
            Bitmap newBarcode = new Bitmap(275,140);
            Graphics graph = Graphics.FromImage(newBarcode);
            graph.DrawImage(imageBarcode, -10, 0);
            Font footerFont = new Font("Times New Roman", 12, FontStyle.Regular);
            Font footerFont2 = new Font("Times New Roman", 11, FontStyle.Regular);
            graph.DrawString(BarcodeNo.ToUpper().Trim(), footerFont, Brushes.Black, 5, 78);
            graph.DrawString(CariAdi, footerFont, Brushes.Black, 97, 78);
            graph.DrawString(Aciklama, footerFont2, Brushes.Black, 5, 95);
            graph.DrawString(Aciklama2, footerFont2, Brushes.Black, 5, 110);
            /*
            Font footerFont = new Font("Arial", 12, FontStyle.Regular);
            Font footerFont2 = new Font("Arial", 12, FontStyle.Regular);
            graph.DrawString(BarcodeNo.ToUpper().Trim(), footerFont, Brushes.Black, 5, 82);
            graph.DrawString(CariAdi, footerFont, Brushes.Black, 120, 82);
            graph.DrawString(Aciklama, footerFont2, Brushes.Black, 5, 95);
            graph.DrawString(Aciklama2, footerFont, Brushes.Black, 5, 110);*/
            return newBarcode;
        }

        public void SetValues(string arsivNo,string Ad, DateTime date, string alinan, string borc, Sepet sepet)
        {
            BarcodeNo = arsivNo;
            CariAdi = Ad;
            Aciklama = "Teslim:" + date.Day.ToString().PadLeft(2, '0') + "." + date.Month.ToString().PadLeft(2, '0') + "." + date.Year.ToString().Substring(2, 2) + " " + date.Hour.ToString() + ":" + date.Minute.ToString();
            if (sepet != null)
            { Aciklama += " - " + sepet.Adi + " " + sepet.Marka; }
            Aciklama2 = "Alınan:" + alinan + "TL - Borç:" + borc + "TL";
        }
    }
}
