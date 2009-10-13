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
           
            urun.Adi = textBoxName.Text.Trim();
            urun.BarkodNo = textBoxBarcodeNo.Text.Trim();
            urun.Marka = textBoxBrand.Text.Trim();
            urun.Model = textBoxModel.Text.Trim();
            urun.Kdv = int.Parse(textBoxKdv.Text.Trim());
            urun.Arsivle = checkBoxArchived.Checked;
            urun.Fiyat = decimal.Parse(textBoxPrice.Text.Trim());
            bool girildimi = urun.productAdd();
            if (girildimi==false)
            {
                MessageBox.Show("Ürün önceden girilmiş!");
            }
            else
            {
                cleanForm();
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
            textBoxPrice.Name = null;
            checkBoxArchived.Checked = false;
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
    }
}
