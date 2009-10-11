using System;
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
    }
}
