using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace arsiv.BarisGorselDLL
{
    class Sepet:Product
    {
        public int Id;
        public bool Degisti;
        public string Aciklama;
        public bool Sil;

        public List<Sepet> sepetGetir(long SepetNo)
        {
            List<Sepet> liste = new List<Sepet>();
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
                Sepet yeniSepet = new Sepet();
                yeniSepet.Id = Convert.ToInt32(satir["Id"].ToString());
                yeniSepet.BarkodNo = satir["BarkodNo"].ToString();
                yeniSepet.Adi = satir["Adi"].ToString();
                yeniSepet.Marka = satir["Marka"].ToString();
                yeniSepet.Model = satir["Model"].ToString();
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

        public Sepet()
        {
        }

        public Sepet(Product product)
        {
            this.Adet = 1;
            this.Adi = product.Adi;
            this.AnaFiyat = product.AnaFiyat;
            this.Arsivle = product.Arsivle;
            this.BarkodNo = product.BarkodNo;
            this.Degisti = false;
            this.Fiyat = product.Fiyat;
            this.Id = 0;
            this.Indirim = product.Indirim;
            this.Kdv = product.Kdv;
            this.Marka = product.Marka;
            this.Model = product.Model;
            this.TeslimTarihi = product.TeslimTarihi;
            this.SepetIndex=product.SepetIndex;
        }

        public void AddProduct(Product product)
        {
            this.Adet = 1;
            this.Adi = product.Adi;
            this.AnaFiyat = product.AnaFiyat;
            this.Arsivle = product.Arsivle;
            this.BarkodNo = product.BarkodNo;
            this.Degisti = false;
            this.Fiyat = product.Fiyat;
            this.Id = 0;
            this.Indirim = product.Indirim;
            this.Kdv = product.Kdv;
            this.Marka = product.Marka;
            this.Model = product.Model;
            this.TeslimTarihi = product.TeslimTarihi;
            this.SepetIndex = product.SepetIndex;
        }

        
    }
}
