using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BarisGorselDLL
{
    public class Baris2Import:ConnectionImporter
    {
        public void Import(SqlConnection ConnBaris2)
        {
            ConnBaris2.Open();
            string sql = "SELECT [arsiv_no],[ad] FROM [arsiv] WHERE NOT [arsiv_no]='1'";
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(sql, ConnBaris2);
            DataSet myDataSet = new DataSet();
            mySqlDataAdapter.Fill(myDataSet, "arsiv");
            ConnBaris2.Close();
            ConnBaris2.Dispose();
            ConnBaris2=null;
            sql=null;
            mySqlDataAdapter.Dispose();
            mySqlDataAdapter=null;
            DataTable myDataTable = myDataSet.Tables["arsiv"];
            Connect();
            foreach (DataRow row in myDataTable.Rows)
            {
                SqlCommand cmd = new SqlCommand("Baris2Import", Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Isim", row["Ad"].ToString().Trim());
                cmd.Parameters.AddWithValue("@ArsivNo", row["arsiv_no"].ToString().Trim());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
            }
            myDataTable.Dispose();
            myDataTable = null;
            Disconnect();
        }
    }
}
