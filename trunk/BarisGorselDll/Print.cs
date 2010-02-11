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
                _Adet = value;
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
                _Ebat = value;
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
                _KartTipi = value;
            }
        }

        /// <summary>
        /// Sipariş bilgileri
        /// </summary>
        public Order Siparis
        {
            get
            {
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
                _Onem = value;
            }
        }

        /// <summary>
        /// Sunucu dosya yolu
        /// </summary>
        public string Server
        {
            get
            {
                return _Server;
            }
            set
            {
                _Server = value;
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
            //TODO biten işler dosyaları silinecek
        }

        public void Save()
        {
            //TODO iş dosyaları dizine kopyalanacak
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
            //İş Dosyaları Silinecek
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
            //Dosyanın adedine göre ismi değişecek
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
