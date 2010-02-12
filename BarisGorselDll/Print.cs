using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace BarisGorselDLL
{
    public class Print:ConnectionImporter
    {
        FileInfo _Dosya;
        Order _Siparis;
        Archive _Arsiv;
        CardType _KartTipi=CardType.Parlak;
        CardSize _Ebat;
        int _Adet=1;
        private DateTime _TarihBaslangic;
        private DateTime _TarihBitis;
        private Priority _Onem=Priority.Normal;
        private string _Server;
        private Kullanici _Personel;
        private Cari _Cari;
        private int _Id;
        private string oldPath;
        private string fileOrgName;

        /// <summary>
        /// After Printing
        /// </summary>
        public event EventHandler Printed;

        /// <summary>
        /// Print file saved
        /// </summary>
        public event EventHandler Saved;

        /// <summary>
        /// Print query deleted
        /// </summary>
        public event EventHandler Deleted;

        public event EventHandler Updated;

        
        private Print(FileInfo file)
        {
            _Dosya = file;
        }

        private Print()
        {

        }

        /// <summary>
        /// Basılacak fotoğraf adedi
        /// </summary>
        public int Adet
        {
            get
            {
                return _Adet;
            }
            set
            {
                if (!(_Adet == null || _Adet == 0))
                {
                    _Adet = value;
                    oldPath = Dosya.FullName;
                    Dosya = new FileInfo(ServerPath(fileOrgName));
                    UpdateServer();
                }
                else
                {
                    _Adet = value;
                }
            }
        }

        /// <summary>
        /// Fotoğrafın arşiv bilgileri
        /// </summary>
        public Archive Arsiv
        {
            get
            {
                return _Arsiv;
            }
            set
            {
                _Arsiv = value;
            }
        }

        /// <summary>
        /// Dosya bilgileri
        /// </summary>
        public FileInfo Dosya
        {
            get
            {
                return _Dosya;
            }
            set
            {
                _Dosya = value;
            }
        }

        /// <summary>
        /// Kart ebatı
        /// </summary>
        public CardSize Ebat
        {
            get
            {
                return _Ebat;
            }
            set
            {

                if (_Ebat != null)
                {
                    _Ebat = value;
                    oldPath = Dosya.FullName;
                    Dosya = new FileInfo(ServerPath(fileOrgName));
                    UpdateServer();
                }
                else
                {
                    _Ebat = value;
                }
                
            }
        }

        /// <summary>
        /// Kart tipi
        /// </summary>
        public CardType KartTipi
        {
            get
            {
                return _KartTipi;
            }
            set
            {
                if (_KartTipi != null)
                {
                    _KartTipi = value;
                    oldPath = Dosya.FullName;
                    Dosya = new FileInfo(ServerPath(fileOrgName));
                    UpdateServer();
                }
                else
                {
                    _KartTipi = value;
                }
            }
        }

        /// <summary>
        /// Sipariş bilgileri
        /// </summary>
        public Order Siparis
        {
            get
            {
                if (_Siparis == null)
                {
                    _Siparis = new Order();
                    _Siparis.SepetNo = 0;
                }
                return _Siparis;
            }
            set
            {
                _Siparis = value;
            }
        }

        /// <summary>
        /// Başlangıç tarihi
        /// </summary>
        public DateTime TarihBaslangic
        {
            get
            {
                return _TarihBaslangic;
            }
            set
            {
                _TarihBaslangic = value;
            }
        }

        /// <summary>
        /// Bitiş tarihi
        /// </summary>
        public DateTime TarihBitis
        {
            get
            {
                return _TarihBitis;
            }
            set
            {
                _TarihBitis = value;
            }
        }

        /// <summary>
        /// Önem derecesi
        /// </summary>
        public Priority Onem
        {
            get
            {
                return _Onem;
            }
            set
            {
                if (_Onem != null)
                {
                    _Onem = value;
                    oldPath = Dosya.FullName;
                    Dosya = new FileInfo(ServerPath(fileOrgName));
                    UpdateServer();
                }
                else
                {
                    _Onem = value;
                }
            }
        }

        /// <summary>
        /// Sunucu dosya yolu
        /// </summary>
        public string Server
        {
            get
            {
                _Server = Properties.Settings.Default.printServerPath;
                return _Server;
            }
        }

        /// <summary>
        /// Baskıyı gönderen personel bilgileri
        /// </summary>
        public Kullanici Personel
        {
            get
            {
                return _Personel;
            }
            set
            {
                _Personel = value;
            }
        }

        /// <summary>
        /// Müşteri bilgileri
        /// </summary>
        public Cari Cari
        {
            get
            {
                return _Cari;
            }
            set
            {
                _Cari = value;
            }
        }

        /// <summary>
        /// Veritabanındaki Id numarası
        /// </summary>
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }


        /// <summary>
        /// Clientteki dosyadan sunucu için yer döndürür
        /// </summary>
        private string ServerPath(string fileName)
        {
            //[Tarih]+[Sepetno-PersonelAdi]+[Ebat-KartTürü]+[Adet-DosyaAdı]
            fileOrgName = fileName;
            return Server + DateTime.Now.ToString("dd.MM.yyyy")
               + "\\" + Siparis.SepetNo.ToString().PadRight(11,'0') + "-" + Personel.Ad
               + "\\" + Ebat.ToString().Replace("E", "") + KartTipi.ToString()
               + "\\" + Adet.ToString() + "_" + fileName;
        }


        private void CopyServer(FileInfo clientFile)
        {
            string path = ServerPath(clientFile.Name);
            if (!Directory.Exists(Directory.GetParent(path).FullName))
            { Directory.GetParent(path).Create(); }
            File.Copy(clientFile.FullName, path);
            Dosya = new FileInfo(path);
        }

        private void DeleteServer()
        {
            Dosya.Delete();
            CleanFolder(Dosya.FullName);
        }

        private void UpdateServer()
        {
            if (!Directory.GetParent(Dosya.FullName).Exists)
            { Directory.GetParent(Dosya.FullName).Create(); }
            File.Move(oldPath, Dosya.FullName);
            CleanFolder(oldPath);
        }

        private void CleanFolder(string filePath)
        {
            IEnumerable<string> fileNames =
                   Directory.GetFiles(Directory.GetParent(filePath).FullName).Where(
                       f => f.EndsWith(".jpg")
                           || f.EndsWith(".JPG")
                           || f.EndsWith(".bmp")
                           || f.EndsWith(".BMP")
                           || f.EndsWith(".png")
                           || f.EndsWith(".PNG")
                           || f.EndsWith(".tiff")
                           || f.EndsWith(".TIFF")
                           || f.EndsWith(".tif")
                           || f.EndsWith(".TIF")
                   );
            DirectoryInfo parent;
            if (fileNames.Count() == 0)
            {
                parent = Directory.GetParent(Directory.GetParent(filePath).FullName);
                Directory.GetParent(filePath).Delete();
                if (parent.GetDirectories().Count() == 0)
                {
                    parent.Delete();
                    if (parent.Parent.GetDirectories().Count() == 0)
                    {
                        parent.Parent.Delete();
                    }
                }
            }
        }

        public void Finished()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("BaskiBitir", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", _Id);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
            Disconnect();
            DeleteServer();
        }

        public void Save(FileInfo clientFile)
        {
            CopyServer(clientFile);
            
            Connect();
            SqlCommand cmd = new SqlCommand("BaskiEkle", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DosyaAdi", _Dosya.Name);
            cmd.Parameters.AddWithValue("@Adet", _Adet);
            cmd.Parameters.AddWithValue("@Onem", _Onem.ToString("D"));
            cmd.Parameters.AddWithValue("@KullaniciId", _Personel.Id);
            cmd.Parameters.AddWithValue("@SepetNo", _Siparis.SepetNo);
            cmd.Parameters.AddWithValue("@UrunBarkodNo", _Siparis.BarkodNo);
            cmd.Parameters.AddWithValue("@KartTipi", _KartTipi.ToString("D"));
            cmd.Parameters.AddWithValue("@Ebat", _Ebat.ToString());
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
            Disconnect();

        }

        public void Delete()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("BaskiSil", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", _Id);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
            Disconnect();
            DeleteServer();
            
        }

        public void Update()
        {
            Connect();
            SqlCommand cmd = new SqlCommand("BaskiGuncelle", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", _Id);
            cmd.Parameters.AddWithValue("@Adet", _Adet);
            cmd.Parameters.AddWithValue("@Onem", _Onem.ToString("D"));
            cmd.Parameters.AddWithValue("@KartTipi", _KartTipi.ToString("D"));
            cmd.Parameters.AddWithValue("@Ebat", _Ebat.ToString());
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
            Disconnect();
            
        }

        /// <summary>
        /// Sıradaki baskıların listesini verir
        /// </summary>
        public List<Print> GetList()
        {
            Connect();
            List<Print> liste = new List<Print>();
            SqlCommand cmd = new SqlCommand("BaskiListele", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
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
                Print yeniBaski = new Print();
                yeniBaski._Id = Int32.Parse(satir["Id"].ToString());
                yeniBaski._TarihBaslangic = DateTime.Parse(satir["Tarih"].ToString());
                yeniBaski._Adet = Int32.Parse(satir["Adet"].ToString());
                yeniBaski._Ebat = (CardSize)Enum.Parse(typeof(CardSize), satir["Ebat"].ToString());
                yeniBaski._KartTipi = (CardType)Enum.ToObject(typeof(CardType), int.Parse(satir["KartTipi"].ToString()));
                yeniBaski._Personel = new Kullanici { Ad = satir["PersonelAdi"].ToString(), Id= int.Parse(satir["PersonelId"].ToString()) };
                yeniBaski._Onem = (Priority)Enum.ToObject(typeof(Priority), int.Parse(satir["Onem"].ToString()));
                yeniBaski._Siparis = new Order { SepetNo = long.Parse(satir["SpetNo"].ToString()), BarkodNo = satir["UrunBarkodNo"].ToString(), Adi = satir["Urun"].ToString(), Marka = satir["Marka"].ToString(), Model = satir["Model"].ToString() };
                liste.Add(yeniBaski);
                yeniBaski = null;
            }
            dataTable.Dispose();
            dataTable = null;
            Disconnect();
            return liste;
        }

        /// <summary>
        /// Biten işlerin listesini verir
        /// </summary>
        /// <param name="GosterimAdedi">Kaç adet listelenecek?</param>
        public List<Print> GetListFinished(int GosterimAdedi)
        {
            Connect();
            List<Print> liste = new List<Print>();
            SqlCommand cmd = new SqlCommand("BaskiBitenListele", Connection);
            cmd.CommandType = CommandType.StoredProcedure;
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
                Print yeniBaski = new Print();
                yeniBaski._Id = Int32.Parse(satir["Id"].ToString());
                yeniBaski._TarihBaslangic = DateTime.Parse(satir["TarihBaslangic"].ToString());
                yeniBaski._TarihBitis = DateTime.Parse(satir["TarihBitis"].ToString());
                yeniBaski._Adet = Int32.Parse(satir["Adet"].ToString());
                yeniBaski._Ebat = (CardSize)Enum.Parse(typeof(CardSize), satir["Ebat"].ToString());
                yeniBaski._KartTipi = (CardType)Enum.ToObject(typeof(CardType), int.Parse(satir["KartTipi"].ToString()));
                yeniBaski._Personel = new Kullanici { Ad = satir["PersonelAdi"].ToString(), Id = int.Parse(satir["PersonelId"].ToString()) };
                yeniBaski._Onem = (Priority)Enum.ToObject(typeof(Priority), int.Parse(satir["Onem"].ToString()));
                yeniBaski._Siparis = new Order { SepetNo = long.Parse(satir["SpetNo"].ToString()), BarkodNo = satir["UrunBarkodNo"].ToString(), Adi = satir["Urun"].ToString(), Marka = satir["Marka"].ToString(), Model = satir["Model"].ToString() };
                liste.Add(yeniBaski);
                yeniBaski = null;
            }
            dataTable.Dispose();
            dataTable = null;
            Disconnect();
            return liste;
        }

        public enum CardSize
        {
            E10x15,
            E13X18,
            E9X13,
            E15x21,
            E20x25,
            E26x38,
            E30x40,
            E30x70,
            E30x90
        }

        public enum CardType
        { Mat=1, YariMat=2, Parlak=0, Ipekli=3, Metal=4 }

        public enum Priority
        { High=0, Normal=1, Low=2 }
    }
}
