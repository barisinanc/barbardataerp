using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BarisGorselDLL
{
    public class Task:ConnectionImporter
    {
        public Order siparis;
        public Cari cari;
        private DateTime _baslangicTarihi;
        public DateTime baslangicTarihi { get { return _baslangicTarihi; } }
        private DateTime _bitisTarihi;
        public DateTime bitisTarihi { get { return _bitisTarihi; } }
        public Kullanici kullanici;
        public WorkCenter isMerkezi;
        public Sube sube;
        public Archive arsiv;

        /// <summary>Fill WorkCenter.Id and Sube.Id!</summary>
        public List<Task> GetList(WorkCenter isMerkezi, Sube sube)
        {
            
            Connect();
            List<Task> liste = new List<Task>();
            SqlCommand cmd = new SqlCommand("IsSorgu", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@isMerkeziId", isMerkezi.Id);
            cmd.Parameters.AddWithValue("@SubeId", sube.SubeId);
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            cmd.Dispose();
            cmd = null;
            adapter.Dispose();
            adapter = null;
            foreach (DataRow satir in dataTable.Rows)
            {
                Task yeniTask = new Task();                
                Cari yeniCari = new Cari();
                yeniCari.CariNo = long.Parse(satir["CariNo"].ToString());
                yeniCari.Isim = satir["Isim"].ToString();
                yeniTask.cari = yeniCari;
                Order yeniOrder = new Order();
                yeniOrder.BarkodNo=satir["UrunBarkodNo"].ToString();
                yeniOrder.SepetNo=long.Parse(satir["SepetNo"].ToString());
                yeniOrder.Adi = satir["Urun"].ToString();
                yeniOrder.Marka = satir["Marka"].ToString();
                yeniOrder.Model = satir["Model"].ToString();
                yeniTask.siparis=yeniOrder;
                Archive yeniArsiv = new Archive();
                yeniArsiv.ArsivNo = satir["ArsivNo"].ToString();
                yeniTask.arsiv = yeniArsiv;
                liste.Add(yeniTask);
                yeniCari = null;
            }
            dataTable.Dispose();
            dataTable = null;
            Disconnect();
            return liste;
        }
        /// <summary>Fill Kullanici.Id, Order.SepetNo and Order.BarkodNo!</summary>
        public void SetTask(Kullanici user, Order siparis)
        {
            Connect();
            SqlCommand cmd = new SqlCommand("IsAtama", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@KullaniciId",user.Id);
            cmd.Parameters.AddWithValue("@SepetNo", siparis.SepetNo);
            cmd.Parameters.AddWithValue("@UrunBarkodNo", siparis.BarkodNo);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
            Disconnect();
        }
        /// <summary>Fill Order.SepetNo and Order.BarkodNo!</summary>
        public void EndTask(Order siparis)
        {
            Connect();
            SqlCommand cmd = new SqlCommand("IsBitir", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SepetNo", siparis.SepetNo);
            cmd.Parameters.AddWithValue("@UrunBarkodNo", siparis.BarkodNo);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
            Disconnect();
        }
    }
}
