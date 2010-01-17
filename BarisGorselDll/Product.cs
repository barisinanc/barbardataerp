using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BarisGorselDLL;

namespace BarisGorselDLL
{
    public class Product : ConnectionImporter
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
        public int Turu;

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
            cmd = null;
            adapter.Dispose();
            adapter = null;
            Disconnect();
            return dataTable;
        }

        public List<Product> productSearch(string srchString, ProductGroup Group1, ProductGroup Group2)
        {
            Connect();
            SqlCommand cmd = new SqlCommand("UrunAra", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@veri", srchString);
            if (Group1 != null)
            { cmd.Parameters.AddWithValue("@grup1", Group1.Id); }
            if (Group2 != null)
            { cmd.Parameters.AddWithValue("@grup2", Group2.Id); }
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            cmd = null;
            adapter.Dispose();
            adapter = null;
            Disconnect();
            List<Product> Urunler = new List<Product>();
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
                Urunler.Add(yeniUrun);
                yeniUrun.Dispose();
            }
            dataTable.Dispose();
            dataTable = null;
            return Urunler;
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
            Connect();
            SqlCommand command = new SqlCommand("UrunEkle", Connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@BarkodNo", SqlDbType.NVarChar, 14);
            command.Parameters["@BarkodNo"].Value = BarkodNo.ToUpper();
            command.Parameters.Add("@Urun", SqlDbType.NVarChar, 50);
            command.Parameters["@Urun"].Value = StringEdit.FirstUpper(Adi);
            command.Parameters.Add("@Marka", SqlDbType.NVarChar, 50);
            command.Parameters["@Marka"].Value = StringEdit.FirstUpper(Marka);
            command.Parameters.Add("@Model", SqlDbType.NVarChar, 50);
            command.Parameters["@Model"].Value = StringEdit.FirstUpper(Model);
            command.Parameters.Add("@Fiyat", SqlDbType.Money);
            command.Parameters["@Fiyat"].Value = Fiyat;
            command.Parameters.Add("@Kdv", SqlDbType.Int);
            command.Parameters["@Kdv"].Value = Kdv;
            command.Parameters.Add("@Arsivle", SqlDbType.TinyInt);
            command.Parameters["@Arsivle"].Value = Arsivle;
            command.Parameters.Add("@UrunTuru", SqlDbType.TinyInt);
            command.Parameters["@UrunTuru"].Value = Turu;
            bool durum = false;
            durum = Convert.ToBoolean(command.ExecuteNonQuery());
            command.Dispose();
            Disconnect();
            return durum;
        }

        public void productEdit()
        {
            Connect();
            SqlCommand command = new SqlCommand("UrunDuzenle", Connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@BarkodNo", SqlDbType.NVarChar, 14);
            command.Parameters["@BarkodNo"].Value = BarkodNo.ToUpper();
            command.Parameters.Add("@Urun", SqlDbType.NVarChar, 50);
            command.Parameters["@Urun"].Value = StringEdit.FirstUpper(Adi);
            command.Parameters.Add("@Marka", SqlDbType.NVarChar, 50);
            command.Parameters["@Marka"].Value = StringEdit.FirstUpper(Marka);
            command.Parameters.Add("@Model", SqlDbType.NVarChar, 50);
            command.Parameters["@Model"].Value = StringEdit.FirstUpper(Model);
            command.Parameters.Add("@Fiyat", SqlDbType.Money);
            command.Parameters["@Fiyat"].Value = Fiyat;
            command.Parameters.Add("@Kdv", SqlDbType.Int);
            command.Parameters["@Kdv"].Value = Kdv;
            command.Parameters.Add("@Arsivle", SqlDbType.TinyInt);
            command.Parameters["@Arsivle"].Value = Arsivle;
            command.ExecuteNonQuery();
            command.Dispose();
            Disconnect();
        }

        public void productGetByBarcode()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("UrunAraBarkodNo", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BarkodNo", BarkodNo);
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            adapter.Dispose();
            Disconnect();
            foreach (DataRow row in dataTable.Rows)
            {
                Adi = row["Urun"].ToString();
                Marka = row["Marka"].ToString();
                Model = row["Model"].ToString();
                try { Fiyat = Convert.ToDecimal(row["Fiyat"]); }
                catch { Fiyat = 0; }
                try { Kdv = Convert.ToInt32(row["Kdv"]); }
                catch { Kdv = 0; }
                try { Arsivle = Convert.ToBoolean(row["Arsivle"]); }
                catch { Arsivle = false; }
                try { Turu = Convert.ToInt32(row["Tur"]); }
                catch { Turu = 0; }
                break;
            }
            dataTable.Dispose();
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
