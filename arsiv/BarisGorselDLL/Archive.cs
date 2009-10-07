using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace arsiv.BarisGorselDLL
{
    class Archive:ConnectionImporter
    {
        public string ArsivNo;
        public long CariNo;
        public int TurId;
        public int SubeId;
        public long SepetNo;
        public string addArchive()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("ArsivEkle", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CariNo", CariNo);
            cmd.Parameters.AddWithValue("@TurId", TurId);
            cmd.Parameters.AddWithValue("@SubeId", SubeId);
            cmd.Parameters.AddWithValue("@SepetNo", SepetNo);
            cmd.Parameters.Add("@ArsivNo", SqlDbType.NVarChar,20);
            cmd.Parameters["@ArsivNo"].Direction = ParameterDirection.InputOutput;
            cmd.Parameters["@ArsivNo"].Value = ArsivNo;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            ArsivNo = cmd.Parameters["@ArsivNo"].Value.ToString();
            Disconnect();
            return ArsivNo;
        }

        public Archive sepettenArsiv(long sepetNo)
        {
            Archive yeniArsiv = new Archive();
            Connect();
            SqlCommand cmd = new SqlCommand("SepetNodanArsiv", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SepetNo", SepetNo);
            cmd.Parameters.Add("@ArsivNo", SqlDbType.Int);
            cmd.Parameters["@ArsivNo"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ArsivTuru", SqlDbType.Int);
            cmd.Parameters["@ArsivTuru"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            yeniArsiv.ArsivNo=cmd.Parameters["@ArsivNo"].Value.ToString();
            yeniArsiv.TurId = Convert.ToInt32(cmd.Parameters["@ArsivTuru"].Value.ToString());
            Disconnect();
            cmd.Dispose();
            return yeniArsiv;
        }
    }
}
