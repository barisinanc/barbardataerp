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
        public decimal Borc;
        public decimal Alacak;
        public string FaturaNo;
        public int SubeId;
        public void addAccount()
        {
            SqlCommand cmd = new SqlCommand("HesapEkle", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CariNo", CariNo);
            cmd.Parameters.AddWithValue("@SepetNo", SepetNo);
            cmd.Parameters.AddWithValue("@Borc", Borc);
            cmd.Parameters.AddWithValue("@Alacak", Alacak);
            cmd.Parameters.AddWithValue("@FaturaNo", FaturaNo);
            cmd.Parameters.AddWithValue("@SubeId", SubeId);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
    }

}
