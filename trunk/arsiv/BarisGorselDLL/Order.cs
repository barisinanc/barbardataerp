using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace arsiv.BarisGorselDLL
{
    class Order:ConnectionImporter
    {
        public string CariNo;
        public string UrunBarkodNo;
        public int Adet;
        public decimal Indirim;
        public decimal Tutar;
        public int SubeId;
        public int SepetNo;
        public DateTime TeslimTarihi;
        
        public int devam;
        public int toplam;


        public int addOrder()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("KayitEkle", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (CariNo != null)
            { cmd.Parameters.AddWithValue("@CariNo", CariNo); }
            cmd.Parameters.AddWithValue("@UrunBarkodNo", UrunBarkodNo);
            cmd.Parameters.AddWithValue("@Adet", Adet);
            cmd.Parameters.AddWithValue("@Indirim", Indirim);
            cmd.Parameters.AddWithValue("@Tutar", Tutar);
            cmd.Parameters.AddWithValue("@SubeId", SubeId);
            cmd.Parameters.AddWithValue("@TeslimTarihi", TeslimTarihi);
            cmd.Parameters.Add("@SepetNo", SqlDbType.Int);
            cmd.Parameters["@SepetNo"].Direction = ParameterDirection.InputOutput;
            cmd.Parameters["@SepetNo"].Value = SepetNo;
            cmd.ExecuteNonQuery();
            SepetNo = Convert.ToInt32(cmd.Parameters["@SepetNo"].Value.ToString());
            cmd.Dispose();
            Disconnect();
            return SepetNo;
        }

        public DataTable getMainScreen(int SubeNo, int Sayfa, int Adet) 
        {
            Connect();
            SqlCommand cmd = new SqlCommand("AnaEkran", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SubeId", SubeNo);
            cmd.Parameters.AddWithValue("@sayfa", Sayfa);
            cmd.Parameters.AddWithValue("@adet", Adet);
            cmd.Parameters.Add("@toplam", SqlDbType.Int);
            cmd.Parameters["@toplam"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@devam", SqlDbType.TinyInt);
            cmd.Parameters["@devam"].Direction = ParameterDirection.Output;
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            toplam = Convert.ToInt32(cmd.Parameters["@toplam"].Value.ToString());
            devam = Convert.ToInt32(cmd.Parameters["@devam"].Value.ToString());
            cmd.Dispose();
            Disconnect();
            return dt;
        }
    }
}
