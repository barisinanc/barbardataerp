using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BarisGorselDLL;
using System.Data;
using System.Data.SqlClient;


namespace familytree
{
    class Lists:ConnectionImporter
    {
        public DataTable comboParent() 
        {
            ConnectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=familytree;Integrated Security=True";
            Connect();
            SqlCommand cmd = new SqlCommand("USP_FAMILYTREE_MARRIAGE_COMBOBOX", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cmd.Dispose();
            cmd = null;
            adapter.Dispose();
            adapter = null;

            return dt;
        }

        public DataTable comboCouple(int sex)
        {
            ConnectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=familytree;Integrated Security=True";
            Connect();
            SqlCommand cmd = new SqlCommand("USP_FAMILYTREE_COUPLE_COMBOBOX", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sex", sex);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cmd.Dispose();
            cmd = null;
            adapter.Dispose();
            adapter = null;
            return dt;
        }
    }
}
