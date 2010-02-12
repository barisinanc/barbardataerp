using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BarisGorselDLL
{
    public class Kullanici:ConnectionImporter
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
            cmd.Parameters.AddWithValue("@SubeId", BarisGorselDLL.Properties.Settings.Default.SubeId);
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

        public Kullanici(int KulId)
        {
            Id = KulId;
            findKullaniciFromId();
        }

        public Kullanici()
        { }

        public void findKullaniciFromId()
        {
            Connect();
            List<Cari> tumCariler = new List<Cari>();
            SqlCommand cmd = new SqlCommand("KullaniciBul", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
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
                Ad = satir["Ad"].ToString();
                Sifre = satir["Sifre"].ToString();
                SubeId = int.Parse(satir["SubeId"].ToString());
                break;
            }
            dataTable.Dispose();
            dataTable = null;
            Disconnect();
        }
    }
}
