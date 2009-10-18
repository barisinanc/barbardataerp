using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using arsiv.BarisGorselDLL;

namespace arsiv
{
    public partial class FormAddProduct : Form
    {
        public FormAddProduct()
        {
            InitializeComponent();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length >= 3)
            {
                urun.Adi = textBoxName.Text.Trim();
                dataGridViewNames.DataSource = urun.urunBul();
            }
        }

        private void textBoxBrand_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBrand.Text.Length >= 3)
            {
                urun.Marka = textBoxBrand.Text.Trim();
                dataGridViewBrand.DataSource = urun.markaBul();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveProduct();
        }
        Product urun = new Product();
        private void saveProduct()
        {
           
            urun.Adi = textBoxName.Text.ToUpper().Trim();
            urun.BarkodNo = textBoxBarcodeNo.Text.ToUpper().Trim();
            urun.Marka = textBoxBrand.Text.Trim();
            urun.Model = textBoxModel.Text.Trim();
            urun.Kdv = int.Parse(textBoxKdv.Text.Trim());
            urun.Arsivle = checkBoxArchived.Checked;
            urun.Fiyat = decimal.Parse(textBoxPrice.Text.Trim().Replace(".",","));
            urun.Turu = comboBoxType.SelectedIndex + 1;
            bool girildimi = urun.productAdd();
            if (girildimi==false)
            {
                MessageBox.Show("Ürün önceden girilmiş!");
            }
            else
            {
                AgacKaydet();
                cleanForm();
            }

        }

        private void AgacKaydet()
        {
            foreach (Product urun in AltUrun)
            {
                ProductTree dal = new ProductTree();
                dal.AnaBarkodNo = textBoxBarcodeNo.Text.ToUpper().Trim();
                dal.AltBarkodNo = urun.BarkodNo;
                dal.Adet = urun.Adet;
                dal.insertTree();
            }
        }

        private void cleanForm()
        {
            textBoxBarcodeNo.Text = null;
            textBoxBrand.TextChanged -= new EventHandler(textBoxBrand_TextChanged);
            textBoxBrand.Text = null;
            textBoxBrand.TextChanged += new EventHandler(textBoxBrand_TextChanged);
            textBoxKdv.Text = null;
            textBoxModel.Text = null;
            textBoxName.TextChanged -= new EventHandler(textBoxName_TextChanged);
            textBoxName.Text = null;
            textBoxName.TextChanged += new EventHandler(textBoxName_TextChanged);
            textBoxPrice.Text = null;
            checkBoxArchived.Checked = false;
            textBoxProductSearch.Text = null;
            Urunler.Clear();
            dataGridViewProductSelect.SelectionChanged -= new EventHandler(dataGridViewProductSelect_SelectionChanged);
            dataGridViewProductSelect.DataSource = null;
            dataGridViewProductSelect.SelectionChanged += new EventHandler(dataGridViewProductSelect_SelectionChanged);
            textBoxAdet.Text = null;
            AltUrun.Clear();
            dataGridViewTree.DataSource = null;
        }

        private void dataGridViewNames_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxName.TextChanged -= new EventHandler(textBoxName_TextChanged);
            textBoxName.Text = dataGridViewNames.SelectedCells[0].Value.ToString();
            textBoxName.TextChanged += new EventHandler(textBoxName_TextChanged);
        }

        private void dataGridViewBrand_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxBrand.TextChanged -= new EventHandler(textBoxBrand_TextChanged);
            textBoxBrand.Text = dataGridViewBrand.SelectedCells[0].Value.ToString();
            textBoxBrand.TextChanged += new EventHandler(textBoxBrand_TextChanged);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            cleanForm();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            productSearch();
        }

        List<Product> Urunler = new List<Product>();
        private void productSearch()
        {
            BarisGorselDLL.Product engProduct = new arsiv.BarisGorselDLL.Product();
            DataTable dataTable = engProduct.productSearch(textBoxProductSearch.Text);
            Urunler.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                Product yeniUrun = new Product();
                yeniUrun.BarkodNo = row["BarkodNo"].ToString();
                yeniUrun.Adi = row["Urun"].ToString();
                yeniUrun.Marka = row["Marka"].ToString();
                yeniUrun.Model = row["Model"].ToString();
                try { yeniUrun.Fiyat = Convert.ToDecimal(row["Fiyat"]); }
                catch { yeniUrun.Fiyat = 0; }
                try { yeniUrun.AnaFiyat = Convert.ToDecimal(row["Fiyat"]); }
                catch { yeniUrun.AnaFiyat = 0; }
                try { yeniUrun.Kdv = Convert.ToInt32(row["Kdv"]); }
                catch { yeniUrun.Kdv = 0; }
                try { yeniUrun.Arsivle = Convert.ToBoolean(row["Arsivle"]); }
                catch { yeniUrun.Arsivle = false; }
                Urunler.Add(yeniUrun);
                yeniUrun.Dispose();
            }
            if (Urunler.Count > 0)
            {
                var selectedProducts = from x in Urunler
                                       select new { Barkod_No = x.BarkodNo, Ürün = x.Adi + " " + x.Marka + " " + x.Model, Fiyat = x.Fiyat };
                dataGridViewProductSelect.SelectionChanged -= new EventHandler(dataGridViewProductSelect_SelectionChanged);
                dataGridViewProductSelect.DataSource = selectedProducts.ToList();
                dataGridViewProductSelect.SelectionChanged += new EventHandler(dataGridViewProductSelect_SelectionChanged);
                dataGridViewProductSelect.Rows[0].Selected = true;
            }
            else
            {
                dataGridViewProductSelect.DataSource = null;
            }
            dataTable.Dispose();
            engProduct.Dispose();
        }
        Product SecilenUrun = new Product();
        private void dataGridViewProductSelect_SelectionChanged(object sender, EventArgs e)
        {
            if (Urunler.Count > 0)
            {
                SecilenUrun = Urunler[(dataGridViewProductSelect.CurrentRow.Index)];
            }
        }
        List<Product> AltUrun = new List<Product>();

        private void buttonProductAdd_Click(object sender, EventArgs e)
        {
            int adet = 0;
            try{ adet=Convert.ToInt32(textBoxAdet.Text);}
            catch {adet=1;}
            SecilenUrun.Adet = adet;
            AltUrun.Add(SecilenUrun);
            fillTree();
        }

        private void dataGridViewTree_SelectionChanged(object sender, EventArgs e)
        {/*
            if (AltUrun.Count > 0)
            {
                SecilenUrun = AltUrun[(dataGridViewTree.CurrentRow.Index)];
            }*/
        }

        private void fillTree()
        {
            var liste = from x in AltUrun
                        select new {Barkod_No = x.BarkodNo, Adet = x.Adet, Stok = x.Adi+" "+x.Marka+ " "+x.Model};
            dataGridViewTree.DataSource = liste.ToList();

        }

        private void buttonProductDelete_Click(object sender, EventArgs e)
        {
            AltUrun.Remove(AltUrun[(dataGridViewTree.CurrentRow.Index)]);
            fillTree();
        }

        private void FormAddProduct_Load(object sender, EventArgs e)
        {
            TurDoldur();
        }

        private void TurDoldur()
        {
            ProductType tip = new ProductType();
            foreach (ProductType x in tip.turListesi())
            {
                comboBoxType.Items.Add(x.TurAdi);
            }
        }

    }
}
