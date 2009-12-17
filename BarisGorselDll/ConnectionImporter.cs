using System.Data;
using System.Data.SqlClient;
using System;
using System.Text;

namespace BarisGorselDLL
{
    public class ConnectionImporter : System.IDisposable
    {
        private bool disposed = false;
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (!(_conn == null))
                    {
                        _conn.Close();
                        _conn.Dispose();
                        _conn = null;
                    }
                }
                disposed = true;

            }
        }

        private string _connStr;
        private SqlConnection _conn;

        public string ConnectionString
        {
            get
            {
                return _connStr;
            }
            set
            {
                _connStr = value;
            }
        }
        public SqlConnection Connection
        {
            get
            {
                return _conn;
            }
        }
        public void Connect()
        {

            if (_conn == null)
            {
                _conn = new SqlConnection(_connStr);
                _conn.Open();
                Connected = true;
            }
        }

        public void Disconnect()
        {
            Dispose();
        }

        public bool Connected;

        public ConnectionImporter()
        {
            _connStr = BarisGorselDLL.Properties.Settings.Default.connectionString;
        }

        public static object CN(object inObj)
        {
            if (inObj == DBNull.Value)
            {
                return null;
            }
            else
            {
                return inObj;
            }
        }
        public static int CNInt(object val)
        {
            if (val == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return (Convert.ToInt32(val));
            }
        }

        public static double CNDouble(object val)
        {
            if (val == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return (Convert.ToDouble(val));
            }
        }

        public static DateTime CNDateTime(object val)
        {
            if (val == DBNull.Value)
            {
                return new DateTime(1900, 1, 1);
            }
            else
            {
                return (Convert.ToDateTime(val));
            }
        }
        public static string CNString(object val)
        {
            if (val == DBNull.Value)
            {
                return "";
            }
            else
            {
                return (Convert.ToString(val));
            }
        }
    }

}