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
        }

        private List<Product> productList;

        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            Product newProduct = new Product();
            productList = (newProduct.productSearch(textBoxSearch.Text, null, null));
            var selectedProducts = from x in productList
                                   select new { Barkod_No = x.BarkodNo, Ürün = x.Adi + " " + x.Marka + " " + x.Model, Fiyat = x.Fiyat.ToString("N") };
            dataGridProducts.AutoGenerateColumns = true;
            dataGridProducts.Columns.Clear();
            dataGridProducts.ItemsSource = selectedProducts.ToList();
        }
    }
}
