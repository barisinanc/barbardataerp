using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace arsiv.BarisGorselDLL
{
    class ArchiveTypes:ConnectionImporter
    {
        public int Id;
        public string Ad;
        public List<ArchiveTypes> readTypes()
        {
            if (Connection.State == ConnectionState.Closed)
            { Connection.Open(); }
            SqlCommand cmd = new SqlCommand("ArsivTipleri", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            Connection.Close();
            Connection.Dispose();
            cmd.Dispose();
            adapter.Dispose();
            List<ArchiveTypes> ArsivTipleri = new List<ArchiveTypes>();
            foreach (DataRow row in dataTable.Rows)
            { 
                ArchiveTypes yeniArsivTipi =new ArchiveTypes();
                yeniArsivTipi.Id= Convert.ToInt32(row[0].ToString());
                yeniArsivTipi.Ad=row[1].ToString();
                ArsivTipleri.Add(yeniArsivTipi);
                yeniArsivTipi = null;
            }
            return ArsivTipleri;
        }
    }
}
