using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BarisGorselDLL
{
    public class OdemeTuru:ConnectionImporter
    {
        public int Id;
        public string Ad;
        public List<OdemeTuru> OdemeTurleri()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("OdemeTurleri", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            adapter.Dispose();
            Disconnect();
            List<OdemeTuru> liste = new List<OdemeTuru>();
            foreach (DataRow satir in dataTable.Rows)
            {
                liste.Add(new OdemeTuru { Id = Convert.ToInt32(satir["Id"].ToString()), Ad = satir["Ad"].ToString() });
            }
            dataTable.Dispose();
            return liste;
        }

    }
}
