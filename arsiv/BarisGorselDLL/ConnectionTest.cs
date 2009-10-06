using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace arsiv.BarisGorselDLL
{
    class ConnectionTest:ConnectionImporter
    {
        public bool Test()
        {
            try { Connect(); return true; }
            catch { return false; }
        }
    }
}
