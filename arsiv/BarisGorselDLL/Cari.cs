﻿using System;
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

        public string addCari()
        {
            CariNo = null;
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
            cmd.Parameters.Add("@CariNo", SqlDbType.NVarChar,16);
            cmd.Parameters["@CariNo"].Direction = ParameterDirection.InputOutput;
            cmd.Parameters["@CariNo"].Value = CariNo;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            CariNo = cmd.Parameters["@CariNo"].Value.ToString();
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
            adapter.Dispose();
            foreach (DataRow satir in dataTable.Rows)
            {
                Cari yeniCari = new Cari();
                yeniCari.CariNo = satir["CariNo"].ToString();
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
            Disconnect();
            return tumCariler;
        }
    }
}
