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
        public long CariNo;
        public DateTime Tarih;
        private string _Isim;
        public string Isim { get { return _Isim; } set { _Isim = value; _Isim = _Isim.ToUpper(); } }
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

        public long addCari()
        {
            CariNo = 0;
            Connect();
            SqlCommand cmd = new SqlCommand("CariEkle", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Isim", _Isim);
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
            cmd.Parameters.Add("@CariNo", SqlDbType.BigInt);
            cmd.Parameters["@CariNo"].Direction = ParameterDirection.InputOutput;
            cmd.Parameters["@CariNo"].Value = CariNo;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
            CariNo = (long)cmd.Parameters["@CariNo"].Value;
            Disconnect();
            return CariNo;
        }

        public List<Cari> araCariler()
        {
            Connect();
            List<Cari> tumCariler = new List<Cari>();
            SqlCommand cmd = new SqlCommand("CariAra", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Isim", _Isim);
            cmd.Parameters.AddWithValue("@TelNo", TelNo);
            cmd.Parameters.AddWithValue("@CepNo", CepNo);
            cmd.Parameters.AddWithValue("@Eposta", Eposta);
            cmd.Parameters.AddWithValue("@Aciklama", Aciklama);
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
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
                Cari yeniCari = new Cari();
                yeniCari.CariNo = long.Parse(satir["CariNo"].ToString());
                //yeniCari.Tarih = DateTime.Parse(satir["Tarih"].ToString());
                yeniCari.Isim = satir["Isim"].ToString();
                yeniCari.TelNo = satir["TelNo"].ToString();
                yeniCari.CepNo = satir["CepNo"].ToString();
                yeniCari.Eposta = satir["Eposta"].ToString();
                yeniCari.Aciklama = satir["Aciklama"].ToString();
                tumCariler.Add(yeniCari);
                yeniCari = null;
            }
            dataTable.Dispose();
            dataTable = null;
            Disconnect();
            return tumCariler;
        }

        public void CariGuncelle()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("CariGuncelle", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CariNo", CariNo);
            cmd.Parameters.AddWithValue("@Isim", _Isim);
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
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
            Disconnect();
        }

        public Cari sepetNodanCari(long sepetno)
        {
            Connect();
            SqlCommand cmd = new SqlCommand("SepetNodanCari", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SepetNo", sepetno);
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            adapter.Dispose();
            Disconnect();
            Cari yeniCari = new Cari();
            foreach (DataRow satir in dataTable.Rows)
            {
                yeniCari.CariNo = long.Parse(satir["CariNo"].ToString());
                //yeniCari.Tarih = DateTime.Parse(satir["Tarih"].ToString());
                yeniCari.Isim = satir["Isim"].ToString();
                yeniCari.TelNo = satir["TelNo"].ToString();
                yeniCari.CepNo = satir["CepNo"].ToString();
                yeniCari.Eposta = satir["Eposta"].ToString();
                yeniCari.Aciklama = satir["Aciklama"].ToString();
                break;
            }
            dataTable.Dispose();
            return yeniCari;
        }
    }
}
