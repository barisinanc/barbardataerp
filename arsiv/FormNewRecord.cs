using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace arsiv
{
    public partial class FormNewRecord : Form
    {
        public FormNewRecord()
        {
            InitializeComponent();
            connectionString = Properties.Settings.Default.connectionStringDis;
        }
        string connectionString;
        
        private DataTable DataRead(string procedureName)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            conn.Close();
            conn.Dispose();
            cmd.Dispose();
            adapter.Dispose();
            return dataTable;
        }
        SqlConnection conn;
        
        #region Product
        List<Urun> Urunler = new List<Urun>();
        Urun SecilenUrun = new Urun();
        List<Urun> Sepet = new List<Urun>();
        private void textBoxProductSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxProductSearch.Text.Length >= 3)
            {
                productSearch();
            }
            else if (textBoxProductSearch.Text.Length == 0)
            {
                Urunler.Clear();
                cleanProductDetails();
                dataGridViewProductSelect.DataSource = Urunler;
            }
        }

        private void cleanProductDetails()
        {

            labelProductSelectedName.Text = "Bir ürün seçiniz.";
            labelProductSelectedBrand.Text = null;
            labelProductSelectedModel.Text = null;
            labelProductSelectedBarcode.Text = null;
            textBoxProductPrice.Text = null;
            checkBoxArchived.Visible = false;
            numericProductCount.Value = 1;
            textBoxProductDiscount.Text = "0";
            dateTimePickerDelivery.Value = DateTime.Now.AddHours(2);
        }

        private void buttonProductSearch_Click(object sender, EventArgs e)
        {
            productSearch();
        }

        private void productSearch()
        {
            BarisGorselDLL.Product engProduct = new arsiv.BarisGorselDLL.Product(connectionString);
            DataTable dataTable = engProduct.productSearch(textBoxProductSearch.Text);
            Urunler.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                Urun yeniUrun = new Urun();
                yeniUrun.BarkodNo = row["BarkodNo"].ToString();
                yeniUrun.Adi = row["Urun"].ToString();
                yeniUrun.Marka = row["Marka"].ToString();
                yeniUrun.Model = row["Model"].ToString();
                try { yeniUrun.Fiyat = Convert.ToDecimal(row["Fiyat"]); }
                catch { yeniUrun.Fiyat = 0; }
                try { yeniUrun.Kdv = Convert.ToInt32(row["Kdv"]); }
                catch { yeniUrun.Kdv = 0; }
                try { yeniUrun.Arsivle = Convert.ToBoolean(row["Arsivle"]); }
                catch { yeniUrun.Arsivle = false; }
                Urunler.Add(yeniUrun);
            }
            var selectedProducts = from x in Urunler
                                    select new { Barkod_No = x.BarkodNo, Ürün = x.Adi+" "+x.Marka+" "+x.Model, Fiyat = x.Fiyat };
            
            dataGridViewProductSelect.DataSource = selectedProducts.ToList();
            
        }

        private void dataGridViewProductSelect_SelectionChanged(object sender, EventArgs e)
        {
            if (Urunler.Count > 0)
            {
                SecilenUrun = Urunler[(dataGridViewProductSelect.CurrentRow.Index)];
                fillProductDetails();
            }
        }

        private void fillProductDetails()
        {
            if (SecilenUrun != null)
            {
                labelProductSelectedName.Text = SecilenUrun.Adi;
                labelProductSelectedBrand.Text = SecilenUrun.Marka;
                labelProductSelectedModel.Text = SecilenUrun.Model;
                labelProductSelectedBarcode.Text = SecilenUrun.BarkodNo;
                textBoxProductPrice.Text = SecilenUrun.Fiyat.ToString();
                dateTimePickerDelivery.Value = DateTime.Today;
                numericHour.Value = DateTime.Now.AddHours(1).Hour;
                numericMinute.Value = DateTime.Now.Minute;
                if (SecilenUrun.Arsivle)
                {
                    checkBoxArchived.Visible = true;
                    checkBoxArchived.Checked = true;

                }
                else
                {
                    checkBoxArchived.Visible = false;
                    checkBoxArchived.Checked = false;
                }
            }
        }

        

        private void buttonProductInsert_Click(object sender, EventArgs e)
        {
            Urun yeniUrun = new Urun();
            yeniUrun.BarkodNo = labelProductSelectedBarcode.Text;
            yeniUrun.Adi = labelProductSelectedName.Text;
            yeniUrun.Marka = labelProductSelectedBrand.Text;
            yeniUrun.Model = labelProductSelectedModel.Text;
            yeniUrun.Arsivle = checkBoxArchived.Checked;
            try { yeniUrun.Fiyat = Convert.ToDecimal(textBoxProductPrice.Text); }
            catch { yeniUrun.Fiyat = 0; }
            yeniUrun.TeslimTarihi = DateTime.Parse(dateTimePickerDelivery.Value.ToShortDateString() +" "+ numericHour.Value.ToString() +":"+ numericMinute.Value.ToString());
            try { yeniUrun.Adet = Convert.ToInt32(numericProductCount.Value); }
            catch { yeniUrun.Adet = 1; }
            try { yeniUrun.Indirim = Convert.ToInt32(textBoxProductDiscount.Text); }
            catch { yeniUrun.Indirim = 0; }
            Sepet.Add(yeniUrun);
            sepetGridRefresh();
        }

        private void sepetGridRefresh()
        {
            
                var sepetData = from x in Sepet
                                select new { Barkod_No = x.BarkodNo, Ürün = x.Adi, Marka = x.Marka, Model = x.Model, Adet = x.Adet, Fiyat = x.Fiyat, İndirim = x.Indirim, Teslim_Tarihi =x.TeslimTarihi };
                dataGridViewProductSelected.DataSource = sepetData.ToList();
                int arsivlenecek = (from x in Sepet
                                    where x.Arsivle==true
                                   select new { adet = x.Arsivle }).Count();
                if (arsivlenecek > 0)
                { groupBoxArchive.Visible = true; archivLoader(); }
                else
                { groupBoxArchive.Visible = false; }
            
        }

        private void archivLoader()
        {
            groupBoxArchive.Visible = true;
            foreach (DataRow row in DataRead("Listeler").Rows)
            { comboBoxArchiveType.Items.Add(row[1]); }
        }

        

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonProductSelectedEdit_Click(object sender, EventArgs e)
        {
            editProductSelection();
        }

        private void dataGridViewProductSelected_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editProductSelection();
        }

        private void editProductSelection()
        {
            if (Sepet.Count > 0)
            {
                SecilenUrun = Sepet[dataGridViewProductSelected.CurrentRow.Index];

                labelProductSelectedName.Text = SecilenUrun.Adi;
                labelProductSelectedBrand.Text = SecilenUrun.Marka;
                labelProductSelectedModel.Text = SecilenUrun.Model;
                labelProductSelectedBarcode.Text = SecilenUrun.BarkodNo;
                textBoxProductPrice.Text = SecilenUrun.Fiyat.ToString();
                dateTimePickerDelivery.Value = SecilenUrun.TeslimTarihi;
                numericHour.Value = SecilenUrun.TeslimTarihi.Hour;
                numericMinute.Value = SecilenUrun.TeslimTarihi.Minute;
                if (SecilenUrun.Arsivle)
                {
                    checkBoxArchived.Visible = true;
                    checkBoxArchived.Checked = true;

                }
                else
                {
                    checkBoxArchived.Visible = false;
                    checkBoxArchived.Checked = false;
                }
            }
        }

        private void buttonProductAdd_Click(object sender, EventArgs e)
        {
            Form formProductAdd = new FormAddProduct();
            formProductAdd.Show();
        }

        private void buttonProductSelectedDelete_Click(object sender, EventArgs e)
        {
            if (Sepet.Count > 0)
            {
                Sepet.Remove(Sepet[dataGridViewProductSelected.CurrentRow.Index]);
                sepetGridRefresh();
            }
        }

        #endregion Product

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
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("CariAra", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Isim", textBoxCariAd.Text);
                cmd.Parameters.AddWithValue("@TelNo", textBoxCariTel.Text);
                cmd.Parameters.AddWithValue("@CepNo", textBoxCariCep.Text);
                cmd.Parameters.AddWithValue("@Eposta", textBoxCariEposta.Text);
                cmd.Parameters.AddWithValue("@Aciklama", textBoxCariAciklama.Text);
                DataTable dataTable = new DataTable();
                cmd.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
                adapter.Dispose();
                Cariler.Clear();
                foreach (DataRow satir in dataTable.Rows)
                {
                    Cari yeniCari = new Cari();
                    yeniCari.CariNo = satir["CariNo"].ToString();
                    //yeniCari.Tarih = DateTime.Parse(satir["Tarih"].ToString());
                    yeniCari.Isim = satir["Isim"].ToString();
                    yeniCari.TelNo = satir["TelNo"].ToString();
                    yeniCari.CepNo = satir["CepNo"].ToString();
                    yeniCari.Eposta = satir["Eposta"].ToString();
                    yeniCari.Aciklama = satir["Aciklama"].ToString();
                    Cariler.Add(yeniCari);
                    yeniCari = null;
                }

                var cariList = from x in Cariler
                               select new { İsim = x.Isim, Cep_Tel = x.CepNo, Telefon = x.TelNo, Eposta = x.Eposta, Açıklama = x.Aciklama };
                dataGridViewCari.DataSource = cariList.ToList();
                cariList = null;
                dataTable.Dispose();
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
            foreach (DataGridViewCell hucre in grid.Rows[grid.CurrentRow.Index].Cells)
            {
                hucre.Style.BackColor = Color.Red;
            }
        }

        private void buttonCariBirak_Click(object sender, EventArgs e)
        {
            selectedCari = null;
            foreach (DataGridViewCell hucre in dataGridViewCari.Rows[dataGridViewCari.CurrentRow.Index].Cells)
            {
                hucre.Style.BackColor = Color.White;
            }
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
       
        #endregion Cari

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveAll();
        }

        private void saveAll()
        {
            string CariNo = "";
            conn = new SqlConnection(connectionString);
            conn.Open();
            if (selectedCari == null)
            {
                SqlCommand cmd = new SqlCommand("CariEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Isim", textBoxCariAd.Text);
                cmd.Parameters.AddWithValue("@TelNo", textBoxCariTel.Text);
                cmd.Parameters.AddWithValue("@CepNo", textBoxCariCep.Text);
                cmd.Parameters.AddWithValue("@Eposta", textBoxCariEposta.Text);
                cmd.Parameters.AddWithValue("@Aciklama", textBoxCariAciklama.Text);
                cmd.Parameters.Add("@CariNo", SqlDbType.NVarChar);
                cmd.Parameters["@CariNo"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                CariNo = cmd.Parameters["@CariNo"].Value.ToString();
                cmd.Dispose();
                Cariler.Clear();
            }
            else
            { CariNo = selectedCari.CariNo; }
            SqlCommand cmd2 = new SqlCommand("KayitEkle", conn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@Isim", textBoxCariAd.Text);
            cmd2.Parameters.AddWithValue("@TelNo", textBoxCariTel.Text);
            cmd2.Parameters.AddWithValue("@CepNo", textBoxCariCep.Text);
            cmd2.Parameters.AddWithValue("@Eposta", textBoxCariEposta.Text);
            cmd2.Parameters.AddWithValue("@Aciklama", textBoxCariAciklama.Text);
            cmd2.ExecuteNonQuery();
            cmd2.Dispose();

        }

        
    }
}
