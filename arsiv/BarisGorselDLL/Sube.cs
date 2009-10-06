using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace arsiv.BarisGorselDLL
{
    class Sube:ConnectionImporter
    {
        public int SubeId;
        public string SubeAdi;
        public List<Sube> tumSubeler()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("Subeler", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            Connection.Close();
            Connection.Dispose();
            cmd.Dispose();
            adapter.Dispose();
            List<Sube> liste = new List<Sube>();
            foreach (DataRow row in dataTable.Rows)
            {
                liste.Add(new Sube { SubeId = Convert.ToInt32(row["SubeId"].ToString()), SubeAdi = row["Sube"].ToString() });
            }
            dataTable.Dispose();
            Disconnect();
            return liste;
        }
    }
}
