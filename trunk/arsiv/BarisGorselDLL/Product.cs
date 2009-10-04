using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace arsiv.BarisGorselDLL
{
    class Product : ConnectionImporter
    {
        public Product(string connectionString)
            :base(connectionString)
        {
        }

        public DataTable productSearch(string srchString) {
            
            SqlCommand cmd = new SqlCommand("UrunAra", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@veri", srchString);
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            adapter.Dispose();
            return dataTable;
        }


    }
}
