using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using arsiv.BarisGorselDLL;

namespace arsiv
{
    public partial class FormStockIn : Form
    {
        public FormStockIn()
        {
            InitializeComponent();
        }

        private void FormStockIn_Load(object sender, EventArgs e)
        {

        }

        private void subeFill()
        {
            Sube subeler = new Sube();

            foreach (Sube s in subeler.tumSubeler())
            {
                comboBoxSube.Items.Add(s.SubeAdi);
            }
            comboBoxSube.SelectedIndex = 0;
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
                fillSelection();
            }
        }

        private void fillSelection()
        {
            labelBarkodNo.Text = SecilenUrun.BarkodNo;
            labelProductName.Text = SecilenUrun.Adi + " " + SecilenUrun.Marka + " " + SecilenUrun.Model;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            productSearch();
        }
        #region Cari
        /*
        bool boolCariAra = true;
        private void textBoxCariAd_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length >= 5)
            {
                cariAra();
            }
        }

        private void textBoxCariTel_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length >= 4)
            {
                cariAra();
            }
        }

        private void textBoxCariCep_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length >= 4)
            {
                cariAra();
            }
        }

        private void textBoxCariEposta_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length >= 5)
            {
                cariAra();
            }
        }

        private void textBoxCariAciklama_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length >= 5)
            {
                cariAra();
            }
        }*/
        List<Cari> Cariler = new List<Cari>();
        private void cariAra()
        {
            Cariler.Clear();
            Cari cariAra = new Cari();
            cariAra.Isim = textBoxCariAd.Text;
            cariAra.TelNo = textBoxCariTel.Text.Trim().Replace(" ", "");
            cariAra.CepNo = textBoxCariCep.Text;
            cariAra.Eposta = textBoxCariEposta.Text.Trim();
            cariAra.Aciklama = textBoxCariAciklama.Text.Trim();
            Cariler = cariAra.araCariler();

            var cariList = from x in Cariler
                           select new { İsim = x.Isim, Cep_Tel = x.CepNo, Telefon = x.TelNo, Eposta = x.Eposta, Açıklama = x.Aciklama };
            dataGridViewCari.DataSource = cariList.ToList();
            cariList = null;
        }

        Cari selectedCari = new Cari();

        private void dataGridViewCari_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cariSelectedMethod();
        }

        private void buttonCariSec_Click(object sender, EventArgs e)
        {
            cariSelectedMethod();
        }

        private void cariSelectedMethod()
        {
            selectedCari = Cariler[dataGridViewCari.CurrentRow.Index];
            textBoxCariAd.Text = selectedCari.Isim;
            textBoxCariCep.Text = selectedCari.CepNo;
            textBoxCariTel.Text = selectedCari.TelNo;
            textBoxCariEposta.Text = selectedCari.Eposta;
            textBoxCariAciklama.Text = selectedCari.Aciklama;
            dataGridColorSelected(dataGridViewCari);
        }



        private void dataGridColorSelected(DataGridView grid)
        {
            foreach (DataGridViewRow satir in grid.Rows)
            {
                foreach (DataGridViewCell hucre in satir.Cells)
                {
                    hucre.Style.BackColor = Color.White;
                }
            }
            foreach (DataGridViewCell hucre in grid.Rows[grid.CurrentRow.Index].Cells)
            {
                hucre.Style.BackColor = Color.Red;
            }
        }

        private void buttonCariBirak_Click(object sender, EventArgs e)
        {
            //selectedCari = null;
            foreach (DataGridViewCell hucre in dataGridViewCari.Rows[dataGridViewCari.CurrentRow.Index].Cells)
            {
                hucre.Style.BackColor = Color.White;
            }
            selectedCari.CariNo = 0;
            selectedCari.Isim = "";
            textBoxCariAd.Text = null;
            textBoxCariCep.Text = null;
            textBoxCariTel.Text = null;
            textBoxCariEposta.Text = null;
            textBoxCariAciklama.Text = null;
        }
        private void buttonCariAra_Click(object sender, EventArgs e)
        {
            cariAra();
        }

        private void buttonCariGuncelle_Click(object sender, EventArgs e)
        {
            selectedCari.Isim = textBoxCariAd.Text.ToUpper();
            selectedCari.CepNo = textBoxCariCep.Text.Trim().Replace(" ", "");
            selectedCari.TelNo = textBoxCariTel.Text.Trim().Replace(" ", "");
            selectedCari.Eposta = textBoxCariEposta.Text.Trim();
            selectedCari.Aciklama = textBoxCariAciklama.Text.Trim();
            try { selectedCari.VergiNo = Convert.ToInt32(textBoxCariVergiNo.Text.Trim()); }
            catch { selectedCari.VergiNo = 0; }
            selectedCari.VergiDairesi = textBoxCariVergiDairesi.Text.Trim();
            selectedCari.CariGuncelle();
            MessageBox.Show("Cari bilgileri güncellendi!");
        }
        #endregion Cari

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonSube_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSube.Checked)
            {
                groupBoxSube.Visible = true; groupBoxCari.Visible = false;
            }
            else
            {
                groupBoxSube.Visible = false; groupBoxCari.Visible = true;
            }
           
        }

        private void radioButtonCari_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCari.Checked)
            {
                groupBoxCari.Visible = true; groupBoxSube.Visible = false;
            }
            else
            { groupBoxCari.Visible = false; groupBoxSube.Visible = true; }
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {

        }
    }
}
