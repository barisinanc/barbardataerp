using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BarisGorselDLL
{
    public class ProductType:ConnectionImporter
    {
        public int Id;
        public string TurAdi;

        public List<ProductType> turListesi()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("UrunTurleri", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            adapter.Dispose();
            Disconnect();
            List<ProductType> liste = new List<ProductType>();
            foreach (DataRow satir in dataTable.Rows)
            {
                liste.Add(new ProductType { Id = Convert.ToInt32(satir["Id"].ToString()), TurAdi = satir["TurAdi"].ToString() });
            }
            dataTable.Dispose();
            return liste;
        }
    }
}
