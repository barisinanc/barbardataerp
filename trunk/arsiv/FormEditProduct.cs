using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BarisGorselDLL;

namespace arsiv
{
    public partial class FormEditProduct : Form
    {
        public string BarkodNo;
        public FormEditProduct()
        {
            InitializeComponent();
        }
        private void FormEditProduct_Load(object sender, EventArgs e)
        {
            loadForms();
            TurDoldur();
            loadTree();
        }

        private void TurDoldur()
        {
            ProductType tip = new ProductType();
            foreach (ProductType x in tip.turListesi())
            {
                comboBoxType.Items.Add(x.TurAdi);
            }
            comboBoxType.SelectedIndex = urun.Turu - 1;
        }

        private void loadTree()
        {
            ProductTree agac = new ProductTree();
            agac.AnaBarkodNo = BarkodNo;
            AltUrun = agac.FindNode();
            fillTree();
        }

        private void loadForms()
        {
            urun.BarkodNo = BarkodNo;
            urun.productGetByBarcode();
            labelBarkodNo.Text = urun.BarkodNo;
            textBoxName.TextChanged -= new EventHandler(textBoxName_TextChanged);
            textBoxName.Text = urun.Adi;
            textBoxName.TextChanged += new EventHandler(textBoxName_TextChanged);
            textBoxBrand.TextChanged -= new EventHandler(textBoxBrand_TextChanged);
            textBoxBrand.Text = urun.Marka;
            textBoxBrand.TextChanged += new EventHandler(textBoxBrand_TextChanged);
            textBoxModel.Text = urun.Model;
            textBoxPrice.Text = urun.Fiyat.ToString();
            textBoxKdv.Text = urun.Kdv.ToString();
            checkBoxArchived.Checked = urun.Arsivle;
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
            saveTree();
            this.Close();
        }

        private void saveTree()
        {
            foreach (ProductTree tree in AltUrun)
            {
                if (tree.Duzenle)
                {
                    tree.EditNode();
                }
                else if (tree.Sil)
                {
                    tree.EditNode();
                }
                else if (tree.Ekle)
                {
                    tree.insertTree();
                }
            }
        }

        Product urun = new Product();

        private void saveProduct()
        {
            urun.Adi = textBoxName.Text.Trim();
            urun.Marka = textBoxBrand.Text.Trim();
            urun.Model = textBoxModel.Text.Trim();
            urun.Kdv = int.Parse(textBoxKdv.Text.Trim());
            urun.Arsivle = checkBoxArchived.Checked;
            urun.Fiyat = decimal.Parse(textBoxPrice.Text.Trim().Replace(".",","));
            urun.productEdit();
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
            this.Close();
        }

        private void buttonProductDelete_Click(object sender, EventArgs e)
        {
            AltUrun[(dataGridViewTree.CurrentRow.Index)].Sil=true;
            fillTree();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            productSearch();
        }

        List<Product> Urunler = new List<Product>();
        private void productSearch()
        {
            BarisGorselDLL.Product engProduct = new BarisGorselDLL.Product();
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
        ProductTree SecilenUrun = new ProductTree();
        private void dataGridViewProductSelect_SelectionChanged(object sender, EventArgs e)
        {
            if (Urunler.Count > 0)
            {
                SecilenUrun.AltBarkodNo = Urunler[(dataGridViewProductSelect.CurrentRow.Index)].BarkodNo;
                SecilenUrun.Adi = Urunler[(dataGridViewProductSelect.CurrentRow.Index)].Adi;
                SecilenUrun.AnaBarkodNo = BarkodNo;
                SecilenUrun.Adet = 1;
                SecilenUrun.Sil = false;
                SecilenUrun.Duzenle = false;
                SecilenUrun.Ekle = true;
            }
        }
        List<ProductTree> AltUrun = new List<ProductTree>();

        private void buttonProductAdd_Click(object sender, EventArgs e)
        {
            int adet = 1;
            try { adet = Convert.ToInt32(textBoxAdet.Text); }
            catch { adet = 1; }
            SecilenUrun.Adet = adet;
            if (SecilenUrun.Id == 0)
            {
                AltUrun.Add(SecilenUrun);
            }
            else
            {
                int i = 0;
                foreach (ProductTree x in AltUrun)
                {
                    if (SecilenUrun.Id == x.Id)
                    {
                        break;
                    }
                    i++;
                }
                AltUrun[i] = SecilenUrun;
            }
            fillTree();
        }

        private void fillTree()
        {
            var liste = from x in AltUrun
                        where x.Sil!=true
                        select new { Barkod_No = x.AltBarkodNo, Adet = x.Adet, Stok = x.Adi + " " + x.Marka + " " + x.Model };
            dataGridViewTree.DataSource = liste.ToList();
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonTreeEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewTree.CurrentRow.Index>=0)
            {
                SecilenUrun = AltUrun[(dataGridViewTree.CurrentRow.Index)];
                
                SecilenUrun.Sil = false;
                SecilenUrun.Duzenle = true;
                SecilenUrun.Ekle = false;
                labelSelectedBarcode.Text = SecilenUrun.AltBarkodNo;
                textBoxAdet.Text = SecilenUrun.Adet.ToString();
            }
            

        }

        
    }
}
