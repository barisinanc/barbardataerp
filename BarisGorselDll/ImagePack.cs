using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace BarisGorselDLL
{
    public class ImagePack:ConnectionImporter
    {
        private string _Path;
        public string Path
        {
            get
            {
                return _Path;
            }
            set
            {
                _Path = value;
                IsThumbCreated();
                _ThumbPath = BarisGorselDLL.Photo.ThumbPathCreator(value);
            }
        }

        

        private void IsThumbCreated()
        {
            if (!File.Exists(BarisGorselDLL.Photo.ThumbPathCreator(_Path)))
            {
                BarisGorselDLL.Photo.ThumbCreate(_Path);
            }
        }
        public string Name { get; set; }
        private string _ThumbPath;
        public string ThumbPath
        {
            get
            {
                return _ThumbPath;
            }
            set
            {
                _ThumbPath = value;
            }
        }
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                _IsSelected = value;
                if (SelectionChanged != null)
                { SelectionChanged(); }
            }
        }
        private bool _IsSelected;
        public delegate void SelectionChangedHandler();
        public event SelectionChangedHandler SelectionChanged;
        private bool _IsClicked;
        public bool IsClicked
        {
            get
            {
                return _IsClicked;
            }
            set
            {
                _IsClicked = value;
                if (ClickChanged != null)
                {
                    ClickChanged();
                }
            }
        }
        public delegate void ClickChangedHandler();
        public event ClickChangedHandler ClickChanged;

        public bool IsFlagged
        {
            get { return _IsFlagged; }
            set
            {
                _IsFlagged = value;
                if (FlagChanged != null)
                {
                    FlagChanged();
                }
            }
        }
        private bool _IsFlagged;
        public delegate void FlagChangedHandler();
        public event FlagChangedHandler FlagChanged;

        public int Id;
        public string Description;
        public string ArsivNo;
        public int Adet=1;
        public bool IsRaw;
        public DateTime Date;
        public void Rotate(BarisGorselDLL.Photo.RotateTypes rotateType)
        {
            Photo foto = new Photo();
            foto.Path = Path;
            foto.Rotate(rotateType);
            foto.JpegSave(foto.Path, 96);
            foto.Path = ThumbPath;
            foto.Rotate(rotateType);
            foto.JpegSave(foto.Path, 96);
            foto = null;
        }
        public void Save()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("ArsivDosyaEkle", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ArsivNo", ArsivNo);
            cmd.Parameters.AddWithValue("@DosyaAdi", Name);
            cmd.Parameters.AddWithValue("@Adet", Adet);
            cmd.Parameters.AddWithValue("@Aciklama", Description);
            cmd.Parameters.AddWithValue("@Secim", IsFlagged);
            cmd.Parameters.AddWithValue("@Ham", IsRaw);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
            Disconnect();
        }

        public List<ImagePack> liste(string Arsiv_No)
        {
            Connect();
            List<ImagePack> liste = new List<ImagePack>();
            SqlCommand cmd = new SqlCommand("ArsivDosyaListele", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ArsivNo", Arsiv_No);
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
                ImagePack newImage = new ImagePack();
                newImage.Id = Convert.ToInt32(satir["Id"].ToString());
                newImage.ArsivNo = satir["ArsivNo"].ToString();
                newImage.Name = satir["DosyaAdi"].ToString();
                newImage.Adet = Convert.ToInt32(satir["Adet"].ToString());
                newImage.Description = satir["Aciklama"].ToString();
                newImage.IsFlagged = bool.Parse(satir["Secim"].ToString());
                newImage.Date = DateTime.Parse(satir["Tarih"].ToString());
                newImage.IsRaw = bool.Parse(satir["Ham"].ToString());
                // Dosyaların bulunup pakete eklenmesi
                ArchiveStorage dosya = new ArchiveStorage();
                newImage.Path = dosya.FindPath(newImage);
                liste.Add(newImage);
                liste = null;
            }
            dataTable.Dispose();
            dataTable = null;
            Disconnect();
            return liste;
        }
        public void Delete()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("ArsivDosyaSil", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ArsivNo", ArsivNo);
            cmd.Parameters.AddWithValue("@DosyaAdi", Name);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
            Disconnect();

        }

        public System.Drawing.Bitmap ImageRead()
        {
            // Avoid locks on file.
            byte[] byteArray = File.ReadAllBytes(Path);
            MemoryStream memoryStream = new MemoryStream(byteArray, 0, byteArray.Length, false, false);
            byteArray = null;

            System.Drawing.Bitmap currentBitmapImage=new System.Drawing.Bitmap(memoryStream);
            
            //memoryStream.Dispose();
            //memoryStream = null;
            //byteArray = null;
            return currentBitmapImage;
        }

        public System.Drawing.Bitmap ThumbRead()
        {
            // Avoid locks on file.
            byte[] byteArray = File.ReadAllBytes(ThumbPath);
            MemoryStream memoryStream = new MemoryStream(byteArray, 0, byteArray.Length, false, false);
            byteArray = null;

            System.Drawing.Bitmap currentBitmapImage = new System.Drawing.Bitmap(memoryStream);
            
            memoryStream.Dispose();
            memoryStream = null;
            byteArray = null;
            return currentBitmapImage;
        }
    }
}
