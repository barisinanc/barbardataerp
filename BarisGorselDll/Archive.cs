using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BarisGorselDLL
{
    public class Archive:ConnectionImporter
    {
        public string ArsivNo;
        public long CariNo;
        public int TurId;
        public int SubeId;
        public long SepetNo;
        public string addArchive()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("ArsivEkle", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CariNo", CariNo);
            cmd.Parameters.AddWithValue("@TurId", TurId);
            cmd.Parameters.AddWithValue("@SubeId", SubeId);
            cmd.Parameters.AddWithValue("@SepetNo", SepetNo);
            cmd.Parameters.Add("@ArsivNo", SqlDbType.NVarChar,20);
            cmd.Parameters["@ArsivNo"].Direction = ParameterDirection.InputOutput;
            cmd.Parameters["@ArsivNo"].Value = ArsivNo;
            cmd.ExecuteNonQuery();
            ArsivNo = cmd.Parameters["@ArsivNo"].Value.ToString();
            cmd.Dispose();
            cmd = null;
            Disconnect();
            return ArsivNo;
        }

        public List<ImagePack> getImages()
        {
            Connect();
            List<ImagePack> list = new List<ImagePack>();
            SqlCommand cmd = new SqlCommand("ArsivDosyaListele", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ArsivNo", ArsivNo);
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
                ImagePack yeniImage = new ImagePack();
                yeniImage.Id = Int32.Parse( satir["Id"].ToString());
                yeniImage.ArsivNo = satir["ArsivNo"].ToString();
                yeniImage.Name = satir["DosyaAdi"].ToString();
                yeniImage.Adet = Int32.Parse(satir["Adet"].ToString());
                yeniImage.Description = satir["Aciklama"].ToString();
                yeniImage.IsFlagged = bool.Parse(satir["Secim"].ToString());
                yeniImage.Date = DateTime.Parse(satir["Tarih"].ToString());
                yeniImage.IsRaw = bool.Parse(satir["Ham"].ToString());
                list.Add(yeniImage);
                yeniImage = null;
            }
            dataTable.Dispose();
            dataTable = null;
            Disconnect();
            ArchiveStorage storage = new ArchiveStorage();
            //Dosya olanları veritabanındakiler ile eşleştirme
            foreach (ImagePack imgFile in storage.getImages(ArsivNo))
            {
                if (list.Where(p => p.Name == imgFile.Name).Count() > 0)
                {
                    ImagePack img = list.Where(p => p.Name == imgFile.Name).First();
                    img.Path = imgFile.Path;
                }
                else
                {
                    //Dosya ver da veritabanında yoksa
                    ImagePack yeniImage = new ImagePack();
                    yeniImage = imgFile;
                    yeniImage.Adet = 1;
                    yeniImage.Save();
                    list.Add(yeniImage);
                }
            }
            //veritabanında olup dosya yoksa
            List<ImagePack> tempList = list;
            foreach (ImagePack img in tempList)
            {
                if (img.Path == "" || img.Path == null)
                {
                    img.Delete();
                    list.Remove(list.Where(p => p.Id==img.Id).First());
                }
            }
            return list;
        }

        public Archive sepettenArsiv(long sepetNo)
        {
            Archive yeniArsiv = new Archive();
            Connect();
            SqlCommand cmd = new SqlCommand("SepetNodanArsiv", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SepetNo", sepetNo);
            cmd.Parameters.Add("@ArsivNo", SqlDbType.NVarChar,20);
            cmd.Parameters["@ArsivNo"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ArsivTuru", SqlDbType.Int);
            cmd.Parameters["@ArsivTuru"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            yeniArsiv.ArsivNo=cmd.Parameters["@ArsivNo"].Value.ToString();
            yeniArsiv.TurId = Convert.ToInt32(cmd.Parameters["@ArsivTuru"].Value.ToString());
            Disconnect();
            cmd.Dispose();
            cmd = null;
            return yeniArsiv;
        }

        public void TurGuncelle()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("ArsivTipiGuncelle", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ArsivNo", ArsivNo);
            cmd.Parameters.AddWithValue("@TurId", TurId);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
            Disconnect();
        }

        public DataTable LodosUyuzu()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("Karaktersiz", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            cmd.Dispose();
            cmd = null;
            Disconnect();
            return dt;
        }

        public void LodosUpdate(int Id, string Name, string Description, string Phone, string Email)
        {
            Connect();
            SqlCommand cmd = new SqlCommand("LodosUpdate", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
            Disconnect();
        }
        
    }
}
