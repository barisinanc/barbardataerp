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
        public string CariNo;
        public int SepetNo;
        public decimal Alinan;
        public decimal Borc;
        public string FaturaNo;
        public int SubeId;
        public int OdemeTuru=0;
        public void addAccount()
        {
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
        }
    }

}
