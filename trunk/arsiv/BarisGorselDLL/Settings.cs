using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace arsiv.BarisGorselDLL
{
    class Settings
    {
        public static global::System.String ConnectionString;
        private static Sube _Sube;
        public static global::arsiv.BarisGorselDLL.Sube SelectedSube
        {
            get { return _Sube; }
            set
            {
                _Sube = value; Properties.Settings.Default.SubeId = _Sube.SubeId;
                Properties.Settings.Default.Save();
            }
        }

    }
}
