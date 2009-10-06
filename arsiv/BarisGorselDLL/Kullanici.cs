using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace arsiv.BarisGorselDLL
{
    class Kullanici:ConnectionImporter
    {
        public int Id;
        public string Ad;
        public string Sifre;
        public int SubeId;

        public List<Kullanici> kullanicilar()
    {
        Connect();
        SqlCommand cmd = new SqlCommand("Kullanicilar", Connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SubeId", Properties.Settings.Default.SubeId);
        DataTable dataTable = new DataTable();
        cmd.ExecuteNonQuery();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(dataTable);
        Connection.Close();
        Connection.Dispose();
        cmd.Dispose();
        adapter.Dispose();
        List<Kullanici> liste = new List<Kullanici>();
        foreach (DataRow row in dataTable.Rows)
        {
            liste.Add(new Kullanici { Id = Convert.ToInt32(row["Id"].ToString()), Ad = row["Ad"].ToString() });
        }
        dataTable.Dispose();
        Disconnect();
        return liste;
    }
    }
}
