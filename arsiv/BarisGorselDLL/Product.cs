﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace arsiv.BarisGorselDLL
{
    class Product : ConnectionImporter
    {
        public string BarkodNo;
        public string Adi;
        public string Marka;
        public string Model;
        public decimal Fiyat;
        public decimal AnaFiyat;
        public decimal Indirim;
        public int Kdv;
        public int Adet;
        public bool Arsivle;
        public DateTime TeslimTarihi;
        public int SepetIndex = -1;
        public int KullaniciId;

        public DataTable productSearch(string srchString) {
            Connect();
            SqlCommand cmd = new SqlCommand("UrunAra", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@veri", srchString);
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            adapter.Dispose();
            Disconnect();
            return dataTable;
        }

        public List<Product> sikKullanilan(string gelen)
        {
            Connect();
            SqlCommand cmd = new SqlCommand("UrunSikKullanilan", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BarkodNo", gelen);
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            adapter.Dispose();
            Disconnect();
            List<Product> urunler = new List<Product>();
            foreach (DataRow row in dataTable.Rows)
            {
                Product yeniUrun = new Product();
                yeniUrun.BarkodNo = row["BarkodNo"].ToString();
                if (yeniUrun.BarkodNo == "") { break; }
                yeniUrun.Adi = row["Urun"].ToString();
                yeniUrun.Marka = row["Marka"].ToString();
                yeniUrun.Model = row["Model"].ToString();
                try { yeniUrun.Fiyat = Convert.ToDecimal(row["Fiyat"]); }
                catch { yeniUrun.Fiyat = 0; }
                try { yeniUrun.AnaFiyat = Convert.ToDecimal(row["Fiyat"]); }
                catch { yeniUrun.AnaFiyat = 0; }
                try { yeniUrun.Kdv = Convert.ToInt32(row["Kdv"]); }
                catch { yeniUrun.Kdv = 0; }
                try { yeniUrun.Arsivle = Convert.ToBoolean(row["Arsivle"]); }
                catch { yeniUrun.Arsivle = false; }
                urunler.Add(yeniUrun);
                yeniUrun.Dispose();
            }
            return urunler;
        }

        public bool productAdd()
        {
            SqlCommand command = new SqlCommand("UrunEkle", Connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@BarkodNo", SqlDbType.NVarChar, 14);
            command.Parameters["@BarkodNo"].Value = BarkodNo.ToUpper();
            command.Parameters.Add("@Urun", SqlDbType.NVarChar, 50);
            command.Parameters["@Urun"].Value = StringEdit.FirstUpper(Adi);
            command.Parameters.Add("@Marka", SqlDbType.NVarChar);
            command.Parameters["@Marka"].Value = StringEdit.FirstUpper(Marka);
            command.Parameters.Add("@Model", SqlDbType.NVarChar, 50);
            command.Parameters["@Model"].Value = StringEdit.FirstUpper(Model);
            command.Parameters.Add("@Fiyat", SqlDbType.Money);
            command.Parameters["@Fiyat"].Value = Fiyat;
            command.Parameters.Add("@Kdv", SqlDbType.Int);
            command.Parameters["@Kdv"].Value = Kdv;
            command.Parameters.Add("@Arsivle", SqlDbType.TinyInt);
            command.Parameters["@Arsivle"].Value = Arsivle;
            bool durum = false;
            Connect();
            durum = Convert.ToBoolean(command.ExecuteNonQuery());
            command = null;
            command.Dispose();
            Disconnect();
            return durum;
        }

        public DataTable markaBul()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("Markalar", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@veri", Marka);
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            adapter.Dispose();
            Disconnect();
            return dataTable;
        }

        public DataTable urunBul()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("Urunler", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@veri", Adi);
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            adapter.Dispose();
            Disconnect();
            return dataTable;
        }
    }
}
