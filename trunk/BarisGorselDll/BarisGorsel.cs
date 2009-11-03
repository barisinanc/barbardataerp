using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarisGorselDLL
{

    public class BarisGorsel
    {

    }


    public static class StringEdit
    {
        public static string FirstUpper(string text)
        {
            if (text != "")
            {
                return text.Substring(0, 1).ToUpper() + text.Substring(1, text.Length - 1).ToLower();
            }
            return "";
        }
    }

}
