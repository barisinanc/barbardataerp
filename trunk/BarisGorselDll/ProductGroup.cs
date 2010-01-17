using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BarisGorselDLL
{
    public class ProductGroup:ConnectionImporter
    {
        private int _Id;
        public int Id { get{ return _Id;} set{_Id=value;} }
        private string _GrupAdi;
        public string GrupAdi { get { return _GrupAdi; } set { _GrupAdi = value; } }

        public List<ProductGroup> GetList()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("UrunAra", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            cmd = null;
            adapter.Dispose();
            adapter = null;
            Disconnect();
            List<ProductGroup> list = new List<ProductGroup>();
            foreach (DataRow row in dataTable.Rows)
            {
                ProductGroup yeniGrup = new ProductGroup();
                yeniGrup.Id = Convert.ToInt32(row["Id"].ToString());
                yeniGrup.GrupAdi = row["GrupAdi"].ToString();
                list.Add(yeniGrup);
                yeniGrup.Dispose();
                yeniGrup = null;
            }
            dataTable.Dispose();
            dataTable = null;
            return list;
         }
    }
}
