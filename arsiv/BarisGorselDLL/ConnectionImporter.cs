using System.Data;
using System.Data.SqlClient;
using System;
using System.Text;

public class ConnectionImporter : System.IDisposable
{

    public virtual void Dispose()
    {
        if (!(_conn == null))
        {
            _conn.Close();
            _conn = null;
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
            if (_conn == null)
            {
                _conn = new SqlConnection(_connStr);
                _conn.Open();
            }
            return _conn;
        }
    }

    public ConnectionImporter()
    {
        _connStr = arsiv.Properties.Settings.Default.connectionStringMerkez;
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

