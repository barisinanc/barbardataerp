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
    }
}
