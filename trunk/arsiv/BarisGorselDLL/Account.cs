using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace arsiv.BarisGorselDLL
{
    class Account:ConnectionImporter
    {
        public long CariNo;
        public long SepetNo;
        public decimal Alinan;
        public decimal Borc;
        public string FaturaNo;
        public int SubeId;
        public DateTime Tarih;
        public int OdemeTuru=0;
        public string OdemeTuruAd;
        public void addAccount()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("HesapEkle", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CariNo", CariNo);
            cmd.Parameters.AddWithValue("@SepetNo", SepetNo);
            cmd.Parameters.AddWithValue("@Alinan", Alinan);
            cmd.Parameters.AddWithValue("@Borc", Borc);
            cmd.Parameters.AddWithValue("@FaturaNo", FaturaNo);
            cmd.Parameters.AddWithValue("@SubeId", SubeId);
            cmd.Parameters.AddWithValue("@OdemeTuru", OdemeTuru);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
            Disconnect();
        }

        public List<Account> gecmisOdemeler(out decimal toplamAlinan, out decimal toplamBorc)
        {
            Connect();
            List<Account> tumHesap = new List<Account>();
            SqlCommand cmd = new SqlCommand("CariHesap", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CariNo", CariNo);
            cmd.Parameters.AddWithValue("@SepetNo", SepetNo);
            cmd.Parameters.Add("@Alinan", SqlDbType.Money);
            cmd.Parameters["@Alinan"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Borc", SqlDbType.Money);
            cmd.Parameters["@Borc"].Direction = ParameterDirection.Output;
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            toplamAlinan = (decimal)cmd.Parameters["@Alinan"].Value;
            toplamBorc = (decimal)cmd.Parameters["@Borc"].Value;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            Connection.Close();
            Connection.Dispose();
            cmd.Dispose();
            cmd = null;
            adapter.Dispose();
            adapter = null;
            foreach (DataRow satir in dataTable.Rows)
            {
                Account yeniHesap = new Account();
                yeniHesap.Tarih = DateTime.Parse(satir["Tarih"].ToString());
                yeniHesap.Alinan = (decimal)satir["Alinan"];
                yeniHesap.Borc = (decimal)satir["Borc"];
                yeniHesap.OdemeTuruAd = (string)satir["OdemeTuru"];
                tumHesap.Add(yeniHesap);
                yeniHesap = null;
            }
            dataTable.Dispose();
            dataTable = null;
            Disconnect();
            return tumHesap;
        }
    }

}
