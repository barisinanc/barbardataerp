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
    /// Interaction logic for ProductSelect.xaml
    /// </summary>
    public partial class ProductSelect : UserControl
    {
        public ProductSelect()
        {
            InitializeComponent();
            dataGridProducts.SelectedCellsChanged += new Microsoft.Windows.Controls.SelectedCellsChangedEventHandler(dataGridProducts_SelectedCellsChanged);
        }

        void dataGridProducts_SelectedCellsChanged(object sender, Microsoft.Windows.Controls.SelectedCellsChangedEventArgs e)
        {
            SecilenUrun = productList[((Microsoft.Windows.Controls.DataGrid)sender).SelectedIndex];
        }

        private List<Product> productList;
        public List<Sepet> sepet = new List<Sepet>();
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
            yeniSiparis.SepetIndex = sepet.Count;
            sepet.Add(yeniSiparis);
            cartGridFill();
        }

        private void cartGridFill()
        {
            var sepetData = from x in sepet
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
    }
}
