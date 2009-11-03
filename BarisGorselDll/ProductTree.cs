using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BarisGorselDLL
{
    public class ProductTree:Product
    {
        public int Id;
        public string AnaBarkodNo;
        public string AltBarkodNo;
        public int Adet;
        public bool Sil;
        public bool Duzenle;
        public bool Ekle;
        public string Ad;


        public void insertTree()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("UrunAgaciEkle", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BarkodNo", AnaBarkodNo);
            cmd.Parameters.AddWithValue("@AltUrun", AltBarkodNo);
            cmd.Parameters.AddWithValue("@Adet", Adet);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Disconnect();
        }

        public List<ProductTree> FindNode()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("UrunAgaciGetir", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AnaBarkodNo", AnaBarkodNo);
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            adapter.Dispose();
            List<ProductTree> liste = new List<ProductTree>();
            foreach(DataRow row in dataTable.Rows)
            {
                ProductTree urun = new ProductTree();
                urun.BarkodNo = AnaBarkodNo;
                urun.AnaBarkodNo = AnaBarkodNo;
                urun.Adet = Convert.ToInt32(row["Adet"].ToString());
                urun.Id = Convert.ToInt32(row["Id"].ToString());
                urun.AltBarkodNo = row["AltUrun"].ToString();
                urun.productGetByBarcode();
                liste.Add(urun);
            }
            dataTable.Dispose();
            Disconnect();
            return liste;
        }

        public void EditNode()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("UrunAgaciDuzenle", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@AnaBarkodNo", AnaBarkodNo);
            cmd.Parameters.AddWithValue("@AltBarkodNo", AltBarkodNo);
            cmd.Parameters.AddWithValue("@Adet", Adet);
            cmd.Parameters.AddWithValue("@Sil", Sil);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Disconnect();
        }
    }
}
