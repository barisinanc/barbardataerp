using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace arsiv
{

    class BarisGorsel
    {

    }

    public static class Ayarlar
    {
       public static string SubeId;
    }

    public static class StringEdit
    {
        public static string FirstUpper(string text)
        {
            return text.Substring(0, 1).ToUpper() + text.Substring(1, text.Length - 1).ToLower();
        }
    }

    public class Urun
    {
        public string BarkodNo;
        public string Adi;
        public string Marka;
        public string Model;
        public decimal Fiyat;
        public decimal Indirim;
        public int Kdv;
        public int Adet;
        public bool Arsivle;
        public DateTime TeslimTarihi;
    }

}
