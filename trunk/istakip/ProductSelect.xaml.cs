﻿using System;
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
    /// Interaction logic for ProductSelect.xaml
    /// </summary>
    public partial class ProductSelect : UserControl
    {
        public ProductSelect()
        {
            InitializeComponent();
            detailDate.DisplayDateStart = DateTime.Today;
            detailDate.SelectedDate = DateTime.Today;
            detailTime.SelectedTime = DateTime.Now.AddHours(2).TimeOfDay;
            dataGridProducts.SelectedCellsChanged += new Microsoft.Windows.Controls.SelectedCellsChangedEventHandler(dataGridProducts_SelectedCellsChanged);
        }

        void dataGridProducts_SelectedCellsChanged(object sender, Microsoft.Windows.Controls.SelectedCellsChangedEventArgs e)
        {
            SecilenUrun = productList[((Microsoft.Windows.Controls.DataGrid)sender).SelectedIndex];
        }

        private List<Product> productList;
        private List<Sepet> _sepet = new List<Sepet>();
        public List<Sepet> sepet
        {
            get
            {
                return _sepet;
            }
            set
            {
                if (value != null)
                {
                    _sepet = value;
                    cartGridFill();
                }
            }

        }
        private Product _SecilenUrun;
        private Product SecilenUrun
        {
            get
            {
                return _SecilenUrun;
            }
            set
            {
                _SecilenUrun = value;
                productDetailsFill();
            }
        }

        private void productDetailsFill()
        {
            detailBarcode.Content = SecilenUrun.BarkodNo;
            detailBrand.Content = SecilenUrun.Marka;
            detailModel.Content = SecilenUrun.Model;
            detailName.Content = SecilenUrun.Adi;
            detailCount.Value = 1;
            detailDate.SelectedDate = DateTime.Today;
            detailDiscount.Value = 0;
            detailTime.SelectedTime = DateTime.Now.TimeOfDay.Add(new TimeSpan(0,30,0));
            detailText.Text = null;
            detailPrice.Value = (double)SecilenUrun.Fiyat;
            
            checkBoxArchive.IsChecked = SecilenUrun.Arsivle;
        }

        private void productDetailsClean()
        {
            detailBarcode.Content = "Lütfen bir ürün seçiniz";
            detailBrand.Content = "";
            detailModel.Content = "";
            detailName.Content = "";
            detailCount.Value = 1;
            detailDate.SelectedDate = DateTime.Today;
            detailDiscount.Value = 0;
            detailTime.SelectedTime = DateTime.Now.TimeOfDay.Add(new TimeSpan(2, 0, 0));
            detailText.Text = null;
            detailPrice.Value = 0;
            checkBoxArchive.IsChecked = SecilenUrun.Arsivle;
        }

        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            Product newProduct = new Product();
            productList = (newProduct.productSearch(textBoxSearch.Text, null, null));
            var selectedProducts = from x in productList
                                   select new { Barkod_No = x.BarkodNo, Ürün = x.Adi + " " + x.Marka + " " + x.Model, Fiyat = x.Fiyat.ToString("N")+"TL" };
            dataGridProducts.AutoGenerateColumns = true;
            dataGridProducts.Columns.Clear();
            dataGridProducts.ItemsSource = selectedProducts.ToList();
        }

        private void buttonCartAdd_Click(object sender, RoutedEventArgs e)
        {
            Sepet yeniSiparis = new Sepet(SecilenUrun);
            yeniSiparis.Aciklama = detailText.Text.Trim();
            yeniSiparis.Adet = (int)detailCount.Value;
            yeniSiparis.Arsivle = checkBoxArchive.IsChecked.Value;
            yeniSiparis.Indirim = (decimal)detailDiscount.Value;
            yeniSiparis.Fiyat = (decimal)detailPrice.Value;
            yeniSiparis.TeslimTarihi = detailDate.SelectedDate.Value.Add(detailTime.SelectedTime.Value);
            if (yeniSiparis.SepetIndex == -1)
            {
                yeniSiparis.SepetIndex = sepet.Count;
                _sepet.Add(yeniSiparis);
            }
            else
            {
                _sepet[yeniSiparis.SepetIndex] = yeniSiparis;
            }
            cartGridFill();

        }

        private void cartGridFill()
        {
            var sepetData = from x in _sepet
                            select new { Barkod_No = x.BarkodNo, Ürün = x.Adi, Marka = x.Marka, Model = x.Model, Adet = x.Adet, Fiyat = x.Fiyat + "TL", İndirim = x.Indirim + "TL", Teslim_Tarihi = x.TeslimTarihi };
            dataGridCart.AutoGenerateColumns = true;
            dataGridCart.Columns.Clear();
            dataGridCart.ItemsSource = sepetData.ToList();
        }

        private void buttonCartRemove_Click(object sender, RoutedEventArgs e)
        {
            sepet.RemoveAt(dataGridCart.SelectedIndex);
            cartGridFill();
        }

        private void buttonCartEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridCart.SelectedIndex > -1)
            {
                SecilenUrun = _sepet[dataGridCart.SelectedIndex];
            }
        }

        private void detailDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (detailDate.SelectedDate > DateTime.Today)
            {
                detailTime.SelectedTime = TimeSpan.Parse("10:00");
            }
        }
        public delegate void SavedEventHandler();
        public event SavedEventHandler Saved;
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (Saved != null)
            { Saved(); }
        }

        public delegate void CancelledEventHandler();
        public event CancelledEventHandler Cancelled;

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (Cancelled != null)
            { Cancelled(); }
        }

        private void detailCount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_SecilenUrun != null)
            {
                decimal fiyat = 0;
                fiyat = _SecilenUrun.Fiyat * (decimal)detailCount.Value;
                detailPrice.Value = (double)(fiyat);
            }
        }
    }
}