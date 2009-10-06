using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace arsiv.BarisGorselDLL
{
    class ConnectionString
    {
        public int ConnectionId;
        public string ConectionString;
    }
    class ConnectionStrings
    {
        public ConnectionString Dis = new ConnectionString { ConnectionId = 1, ConectionString = @"Data Source=merkez.barisgorsel.com;Initial Catalog=arsiv;User Id=sa;Password=kay123" };
        public ConnectionString Ic = new ConnectionString { ConnectionId = 2, ConectionString = @"Data Source=192.168.2.3;Initial Catalog=arsiv;User Id=sa;Password=kay123" };
        public ConnectionString Yerel = new ConnectionString { ConnectionId = 3, ConectionString = @"Data Source=BARAN\SQLEXPRESS;Initial Catalog=LodosArsiv;Integrated Security=True" };
        public List<ConnectionString> ConnectionStringList()
        {
            List<ConnectionString> liste = new List<ConnectionString>();
            liste.Add(Dis);
            liste.Add(Ic);
            liste.Add(Yerel);
            return liste;
        }
    }
}
