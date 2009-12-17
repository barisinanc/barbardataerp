using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BarisGorselDLL
{
    public class Database:ConnectionImporter
    {
        private List<string> _Tables;
        public List<string> Tables
        {
            get
            {
                GetTables();
                return _Tables;
            }
        }
        private void GetTables()
        {
            _Tables = new List<string>();
            Connect();
            SqlCommand cmd = new SqlCommand("TableList", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            cmd = null;
            adapter.Dispose();
            adapter = null;
            foreach (DataRow satir in dataTable.Rows)
            {
                _Tables.Add(satir[0].ToString());
            }
            Disconnect();
        }
    }
}
