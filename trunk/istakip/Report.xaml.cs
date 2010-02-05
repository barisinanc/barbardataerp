using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BarisGorselDLL;
namespace istakip
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : UserControl
    {
        public Report()
        {
            InitializeComponent();
            archiveLoader();
        }
        BarisGorselDLL.Barcode barkod;
        private void Tester()
        {            
            if (!(SelectedCari == null || ListImages==null || ListSepet == null))
            {
                barkod = new BarisGorselDLL.Barcode();
                barkod.SetValues("0000000000", SelectedCari.Isim, _ListSepet.First().TeslimTarihi, "0", borc.ToString("N"));
                BitmapSource barcodeImage = PhotoConvert.BitmapImagetoBitmap(barkod.Create());
                imageBarcode.Width = barcodeImage.Width;
                imageBarcode.Height = barcodeImage.Height;
                imageBarcode.Source = barcodeImage;
                personelsControl = new PersonelList();
                personelsControl.UserSelected += new PersonelList.UserSelectedEventHandler(personelsControl_UserSelected);
                gridPersonel.Children.Add(personelsControl);
            }
        }
        PersonelList personelsControl;
        Kullanici selectedKullanici;
        void personelsControl_UserSelected()
        {
            selectedKullanici= personelsControl.selectedKullanici;
            Save();
            GC.Collect();
        }
        private List<BarisGorselDLL.ImagePack> _ListImages;
        public List<BarisGorselDLL.ImagePack> ListImages
        {
            get { return _ListImages; }
            set
            {
                _ListImages = value;
                if (ListImages != null)
                {
                    labelPhoto.Content = ListImages.Count + " adet fotoğraf seçildi.";
                    Tester();
                }
            }
        }
        decimal borc = 0;
        private List<Sepet> _ListSepet;
        public List<Sepet> ListSepet
        {
            get { return _ListSepet; }
            set
            {
                _ListSepet = value;
                if (ListSepet != null)
                {
                    borc = 0;
                    foreach (Product x in ListSepet)
                    {
                        borc += x.Fiyat - x.Indirim;
                    }
                    labelTotal.Content = "Toplam " + borc.ToString("N") + " TL";
                    Tester();
                }
            }
        }
        private Cari _SelectedCari;
        public Cari SelectedCari
        {
            get { return _SelectedCari; }
            set
            {
                _SelectedCari = value;
                if (_SelectedCari != null)
                {
                    labelIsim.Content = SelectedCari.Isim;
                    Tester();
                }
            }
        }
        int arsivTipiSelected;

        private void archiveLoader()
        {
            ArchiveTypes arsivTip = new ArchiveTypes();
            foreach (ArchiveTypes tip in arsivTip.readTypes())
            {
                arsivTipi.Items.Add(tip.Ad);
            }
            arsivTipi.SelectedIndex = BarisGorselDLL.Properties.Settings.Default.ArsivTipi - 1;
            arsivTipiSelected = BarisGorselDLL.Properties.Settings.Default.ArsivTipi;
            arsivTip.Dispose();
        }

        private void arsivTipi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            arsivTipiSelected = arsivTipi.SelectedIndex + 1;
            BarisGorselDLL.Properties.Settings.Default.ArsivTipi = arsivTipiSelected;
            BarisGorselDLL.Properties.Settings.Default.Save();
        }

        private void Save()
        {
            if (SelectedCari.CariNo == 0)
            {
                SelectedCari.addCari();
            }

            long CariNo = 0;

            CariNo = SelectedCari.CariNo;
            bool arsivle = false;
            long sepetNo = 0;
            decimal borc = 0;
            foreach (Product x in ListSepet)
            {
                Order yeniCikis = new Order();
                if (x.Arsivle) { arsivle = true; }
                yeniCikis.CariNo = CariNo;
                yeniCikis.BarkodNo = x.BarkodNo;
                yeniCikis.Adet = x.Adet;
                yeniCikis.Indirim = x.Indirim;
                yeniCikis.Fiyat = x.Fiyat;
                yeniCikis.SubeId = BarisGorselDLL.Properties.Settings.Default.SubeId;
                yeniCikis.SepetNo = sepetNo;
                yeniCikis.TeslimTarihi = x.TeslimTarihi;
                yeniCikis.KullaniciId = x.KullaniciId;
                sepetNo = yeniCikis.addOrder();
                borc += x.Fiyat - x.Indirim;
            }
            Account yeniHesap = new Account();
            yeniHesap.SepetNo = sepetNo;
            yeniHesap.SubeId = BarisGorselDLL.Properties.Settings.Default.SubeId;
            yeniHesap.CariNo = CariNo;
            yeniHesap.Borc = borc;
            yeniHesap.Alinan = 0;
            yeniHesap.OdemeTuru = 1;
            /*(from x in Sepet
                            select new { Tutar = x.Fiyat }).Sum(p => p.Tutar)-borc;*/
            yeniHesap.addAccount();

            if (arsivle)
            {
                Archive yeniArsiv = new Archive();
                yeniArsiv.CariNo = CariNo;
                yeniArsiv.SepetNo = sepetNo;
                yeniArsiv.SubeId = BarisGorselDLL.Properties.Settings.Default.SubeId;
                yeniArsiv.TurId = arsivTipiSelected;
                yeniArsiv.addArchive();

                foreach (ImagePack img in ListImages.Where(p=>p.IsSelected==true))
                {
                    img.ArsivNo = yeniArsiv.ArsivNo;
                    img.Save();
                }
                ArchiveStorage store = new ArchiveStorage(SelectedCari);
                store.Save(ListImages);
                barkod.BarcodeNo = yeniArsiv.ArsivNo;
                barkod.Count = (short)numericBarcodeCount.Value;
                if (checkBoxBarcode.IsChecked.Value)
                {
                    barkod.yazdir();
                }
            }

            
        }

        
    }
}
