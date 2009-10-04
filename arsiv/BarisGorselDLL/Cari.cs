using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace arsiv.BarisGorselDLL
{
    class Cari : ConnectionImporter
    {
        public string CariNo;
        public DateTime Tarih;
        public string Isim;
        public string TelNo;
        public string CepNo;
        public string Eposta;
        public DateTime DogumTarihi;
        public string Aciklama;
        public int VergiNo;
        public string VergiDairesi;
        public string Adres;
        public int IlKod;
        public string Ilce;
        public int GrupNo1;
        public int GrupNo2;
        public int GrupNo3;

        public string addCari()
        {
            CariNo = null;
            SqlCommand cmd = new SqlCommand("CariEkle", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Isim", Isim);
            cmd.Parameters.AddWithValue("@TelNo", TelNo);
            cmd.Parameters.AddWithValue("@CepNo", CepNo);
            cmd.Parameters.AddWithValue("@Eposta", Eposta);
            cmd.Parameters.AddWithValue("@Aciklama", Aciklama);
            cmd.Parameters.AddWithValue("@VergiNo", VergiNo);
            cmd.Parameters.AddWithValue("@VergiDairesi", VergiDairesi);
            cmd.Parameters.AddWithValue("@Adres", Adres);
            cmd.Parameters.AddWithValue("@IlKod", IlKod);
            cmd.Parameters.AddWithValue("@Ilce", Ilce);
            cmd.Parameters.AddWithValue("@GrupNo1", GrupNo1);
            cmd.Parameters.AddWithValue("@GrupNo2", GrupNo2);
            cmd.Parameters.AddWithValue("@GrupNo3", GrupNo3);
            cmd.Parameters.AddWithValue("@SubeId", Properties.Settings.Default.SubeId);
            cmd.Parameters.Add("@CariNo", SqlDbType.NVarChar);
            cmd.Parameters["@CariNo"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            return cmd.Parameters["@CariNo"].Value.ToString();
        }
    }
}
