using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace arsiv.BarisGorselDLL
{
    class Sepet:ConnectionImporter
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

        public List<Product> sepetGetir(long SepetNo)
        {
            List<Product> liste = new List<Product>();
            Connect();
            SqlCommand cmd = new SqlCommand("SepetGetir", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SepetNo", SepetNo);
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            adapter.Dispose();
            int i=0;
            foreach (DataRow satir in dataTable.Rows)
            {
                Product yeniSepet = new Product();
                yeniSepet.BarkodNo = satir["BarkodNo"].ToString();
                yeniSepet.Adi = satir["Adi"].ToString();
                yeniSepet.Marka = satir["Marka"].ToString();
                yeniSepet.Model = satir["Fiyat"].ToString();
                yeniSepet.Fiyat = decimal.Parse(satir["Fiyat"].ToString());
                yeniSepet.AnaFiyat = decimal.Parse(satir["AnaFiyat"].ToString());
                yeniSepet.Indirim = decimal.Parse(satir["Indirim"].ToString());
                yeniSepet.Kdv = Convert.ToInt32(satir["Kdv"].ToString());
                yeniSepet.Adet = Convert.ToInt32(satir["Adet"].ToString());
                try {  yeniSepet.Arsivle = Convert.ToBoolean(satir["Arsivle"]); }
                catch {  yeniSepet.Arsivle = false; }
                yeniSepet.TeslimTarihi = DateTime.Parse(satir["TeslimTarihi"].ToString());
                yeniSepet.SepetIndex = i;
                try { yeniSepet.KullaniciId = Convert.ToInt32(satir["KullaniciId"].ToString()); }
                catch { yeniSepet.KullaniciId = 0; }
                liste.Add(yeniSepet);
                yeniSepet.Dispose();
                i++;
            }
            Disconnect();
            return liste;
        }
    }
}
