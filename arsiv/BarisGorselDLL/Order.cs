using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace arsiv.BarisGorselDLL
{
    class Order:Sepet
    {
        public long CariNo;
        public int SubeId;
        public long SepetNo;
        public int devam;
        public int toplam;

        public long addOrder()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("KayitEkle", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (CariNo != 0)
            { cmd.Parameters.AddWithValue("@CariNo", CariNo); }
            cmd.Parameters.AddWithValue("@UrunBarkodNo", BarkodNo);
            cmd.Parameters.AddWithValue("@Adet", Adet);
            cmd.Parameters.AddWithValue("@Indirim", Indirim);
            cmd.Parameters.AddWithValue("@Tutar", Fiyat);
            cmd.Parameters.AddWithValue("@SubeId", SubeId);
            cmd.Parameters.AddWithValue("@TeslimTarihi", TeslimTarihi);
            cmd.Parameters.AddWithValue("@KullaniciId", KullaniciId);
            cmd.Parameters.Add("@SepetNo", SqlDbType.BigInt);
            cmd.Parameters["@SepetNo"].Direction = ParameterDirection.InputOutput;
            cmd.Parameters["@SepetNo"].Value = SepetNo;
            cmd.ExecuteNonQuery();
            SepetNo = (long)cmd.Parameters["@SepetNo"].Value;
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

        public void Guncelle()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("SiparisGuncelle", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CariNo", CariNo);
            cmd.Parameters.AddWithValue("@UrunBarkodNo", BarkodNo);
            cmd.Parameters.AddWithValue("@Adet", Adet);
            cmd.Parameters.AddWithValue("@Indirim", Indirim);
            cmd.Parameters.AddWithValue("@Tutar", Fiyat);
            cmd.Parameters.AddWithValue("@SubeId", Properties.Settings.Default.SubeId);
            cmd.Parameters.AddWithValue("@SepetNo", SepetNo);
            cmd.Parameters.AddWithValue("@TeslimTarihi", TeslimTarihi);
            cmd.Parameters.AddWithValue("@Aciklama", Aciklama);
            cmd.Parameters.AddWithValue("@KullaniciId", KullaniciId);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Disconnect();
        }


        public void Sil()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("SiparisSil", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Disconnect();
        }
    }
}
