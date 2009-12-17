using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarisGorselDLL
{
    public class Settings
    {
        public static global::System.String ConnectionString;
        private static int _connectionId;
        public static global::System.Int32 ConnectionId
        {
            get { return _connectionId; }
            set
            {
                _connectionId = BarisGorselDLL.Properties.Settings.Default.ConnectionId;
                BarisGorselDLL.Properties.Settings.Default.Save();
                _connectionId = value;
            }
        }
        private static Sube _Sube = new Sube();
        public static global::BarisGorselDLL.Sube SelectedSube
        {
            get
            {
                _Sube.SubeId = BarisGorselDLL.Properties.Settings.Default.SubeId;
                return _Sube;
            }
            set
            {
                _Sube = value; 
                BarisGorselDLL.Properties.Settings.Default.SubeId = _Sube.SubeId;
                BarisGorselDLL.Properties.Settings.Default.Save();
            }
        }

    }
}
