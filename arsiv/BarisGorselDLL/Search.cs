using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace arsiv.BarisGorselDLL
{
    class Search : ConnectionImporter
    {
        public string veri;
        public string selectedDepartments;
        public int page;
        public int pageLimit;
        public string tur;
        public int count;
        public int devam;
        public DateTime dateBaslangic;
        public DateTime dateBitis;
        public DataTable ArsivArama()
        {

            Connect();
            SqlCommand cmd = new SqlCommand("ArsivArama", Connection);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@veri", veri);
            cmd.Parameters.AddWithValue("@SubeId", selectedDepartments);
            cmd.Parameters.AddWithValue("@sayfa", page);
            cmd.Parameters.AddWithValue("@adet", pageLimit);
            cmd.Parameters.AddWithValue("@turId", tur);
            cmd.Parameters.AddWithValue("@tarihbas", dateBaslangic);
            cmd.Parameters.AddWithValue("@tarihbit", dateBitis);
            cmd.Parameters.Add("@toplam", SqlDbType.Int);
            cmd.Parameters["@toplam"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@devam", SqlDbType.Int);
            cmd.Parameters["@devam"].Direction = ParameterDirection.Output;
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(dataTable);
            count = (int)cmd.Parameters["@toplam"].Value;
            devam = (int)cmd.Parameters["@devam"].Value;
            Disconnect();
            cmd.Dispose();
            return dataTable;
        }


    }
}
