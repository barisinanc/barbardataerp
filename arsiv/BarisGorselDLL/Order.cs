﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace arsiv.BarisGorselDLL
{
    class Order:ConnectionImporter
    {
        public string CariNo;
        public string UrunBarkodNo;
        public int Adet;
        public decimal Indirim;
        public decimal Tutar;
        public int SubeId;
        public int SepetNo;
        public DateTime TeslimTarihi;

        public int addOrder()
        {
            SqlCommand cmd = new SqlCommand("KayitEkle", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (CariNo != null)
            { cmd.Parameters.AddWithValue("@CariNo", CariNo); }
            cmd.Parameters.AddWithValue("@UrunBarkodNo", UrunBarkodNo);
            cmd.Parameters.AddWithValue("@Adet", Adet);
            cmd.Parameters.AddWithValue("@Indirim", Indirim);
            cmd.Parameters.AddWithValue("@Tutar", Tutar);
            cmd.Parameters.AddWithValue("@SubeId", SubeId);
            cmd.Parameters.AddWithValue("@TeslimTarihi", TeslimTarihi);
            cmd.Parameters.Add("@SepetNo", SqlDbType.Int);
            //cmd.Parameters["@SepetNoDonen"].Direction = ParameterDirection.Output;
            //cmd.Parameters["@SepetNo"].Value = SepetNo;
            SepetNo = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            return SepetNo;
        }
    }
}
