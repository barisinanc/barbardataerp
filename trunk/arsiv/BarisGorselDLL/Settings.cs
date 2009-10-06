using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace arsiv.BarisGorselDLL
{
    class Settings
    {
        public static global::System.String ConnectionString;
        private static int _connectionId;
        public static global::System.Int32 ConnectionId
        {
            get { return _connectionId; }
            set
            {
                _connectionId = Properties.Settings.Default.ConnectionId;
                Properties.Settings.Default.Save();
                _connectionId = value;
            }
        }
        private static Sube _Sube;
        public static global::arsiv.BarisGorselDLL.Sube SelectedSube
        {
            get
            {
                _Sube.SubeId = Properties.Settings.Default.SubeId;
                return _Sube;
            }
            set
            {
                _Sube = value; Properties.Settings.Default.SubeId = _Sube.SubeId;
                Properties.Settings.Default.Save();
            }
        }

    }
}
