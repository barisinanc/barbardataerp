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
    public partial class FormNewRecord : Form
    {
        public FormNewRecord()
        {
            InitializeComponent();
            connectionString = Properties.Settings.Default.connectionStringDis;
        }

        private void FormNewRecord_Load(object sender, EventArgs e)
        {
            textBoxProductSearch.Focus();
            otoBoyutDegistir();
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
            BarisGorselDLL.Product engProduct = new arsiv.BarisGorselDLL.Product();
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
            dataGridViewProductSelect.SelectionChanged -= new EventHandler(dataGridViewProductSelect_SelectionChanged);
            dataGridViewProductSelect.DataSource = selectedProducts.ToList();
            dataGridViewProductSelect.SelectionChanged += new EventHandler(dataGridViewProductSelect_SelectionChanged);
            dataGridViewProductSelect.Rows[0].Selected = true;
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

        private void textBoxProductPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxProductDiscount_TextChanged(object sender, EventArgs e)
        {
            if (textBoxProductDiscount.Text == null || textBoxProductDiscount.Text=="") { textBoxProductDiscount.Text = "0"; }
            if (Convert.ToDecimal(textBoxProductDiscount.Text) <= SecilenUrun.Fiyat)
            {
                textBoxProductPrice.Text = (SecilenUrun.Fiyat - Convert.ToDecimal(textBoxProductDiscount.Text)).ToString();
            }
            else
            { textBoxProductPrice.Text = "0"; }
        }

        private void buttonProductInsert_Click(object sender, EventArgs e)
        {
            Urun yeniUrun = new Urun();
            yeniUrun.BarkodNo = labelProductSelectedBarcode.Text;
            yeniUrun.Adi = labelProductSelectedName.Text;
            yeniUrun.Marka = labelProductSelectedBrand.Text;
            yeniUrun.Model = labelProductSelectedModel.Text;
            yeniUrun.Arsivle = checkBoxArchived.Checked;
            decimal indirim = 0;
            decimal fiyat = 0;
            if (textBoxProductDiscount.Text == null || textBoxProductDiscount.Text == "") { indirim = 0; }
            else { indirim = Convert.ToDecimal(textBoxProductPrice.Text); }
            if (textBoxProductPrice.Text == null || textBoxProductPrice.Text == "") { fiyat = 0; }
            else { fiyat = Convert.ToDecimal(textBoxProductPrice.Text); }
            if (fiyat + indirim != SecilenUrun.Fiyat)
            {
                yeniUrun.Fiyat = Convert.ToDecimal(textBoxProductPrice.Text);
                if (fiyat >= SecilenUrun.Fiyat)
                {
                    yeniUrun.Fiyat = SecilenUrun.Fiyat;
                    yeniUrun.Indirim = 0;
                }
                else
                {
                    yeniUrun.Indirim = SecilenUrun.Fiyat - fiyat;
                    yeniUrun.Fiyat = fiyat;
                }
            }
            else
            {
                yeniUrun.Fiyat = fiyat;
                yeniUrun.Indirim = indirim;
            }
            yeniUrun.TeslimTarihi = DateTime.Parse(dateTimePickerDelivery.Value.ToShortDateString() +" "+ numericHour.Value.ToString() +":"+ numericMinute.Value.ToString());
            try { yeniUrun.Adet = Convert.ToInt32(numericProductCount.Value); }
            catch { yeniUrun.Adet = 1; }
            
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
            decimal bakiye= (from x in Sepet
                        select new {Tutar = x.Fiyat}).Sum(p=>p.Tutar);
            labelBakiye.Text = bakiye.ToString() + " TL";
            textBoxAlinanTutar.TextAlignChanged -= new EventHandler(textBoxAlinanTutar_TextChanged);
            textBoxAlinanTutar.Text = bakiye.ToString();
            textBoxAlinanTutar.TextAlignChanged += new EventHandler(textBoxAlinanTutar_TextChanged);
        }
        int arsivTipiSelected;
        
        private void archivLoader()
        {
            ArchiveTypes arsivTipi = new ArchiveTypes();
            groupBoxArchive.Visible = true;
            foreach (ArchiveTypes tip in arsivTipi.readTypes())
            {
                comboBoxArchiveType.Items.Add(tip.Ad);
            }
            comboBoxArchiveType.SelectedIndex = Properties.Settings.Default.ArsivTipi - 1;
            arsivTipiSelected = Properties.Settings.Default.ArsivTipi;
            arsivTipi.Dispose();
        }

        private void comboBoxArchiveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            arsivTipiSelected = comboBoxArchiveType.SelectedIndex + 1;
            Properties.Settings.Default.ArsivTipi = arsivTipiSelected;
            Properties.Settings.Default.Save();
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
                textBoxProductDiscount.TextChanged -= new EventHandler(textBoxProductDiscount_TextChanged);
                textBoxProductDiscount.Text = SecilenUrun.Indirim.ToString();
                textBoxProductDiscount.TextChanged += new EventHandler(textBoxProductDiscount_TextChanged);
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
            if(selectedCari.CariNo==null)
            {
                if (textBoxCariAd.Text.Trim() != "")
                {
                    selectedCari.Isim = textBoxCariAd.Text.Trim().ToUpper();
                    selectedCari.CepNo = textBoxCariCep.Text.Trim().ToUpper();
                    selectedCari.TelNo = textBoxCariTel.Text.Trim().ToUpper();
                    selectedCari.Aciklama = textBoxCariAciklama.Text.Trim().ToUpper();
                    selectedCari.Eposta = textBoxCariEposta.Text.Trim().ToUpper();
                    selectedCari.addCari();
                }
            }
            if (Sepet.Count > 0)
            {
                int arsiv = (from x in Sepet
                             where x.Arsivle == true
                             select x).Count();
                if (arsiv > 0 && selectedCari.CariNo == null)
                { MessageBox.Show("Müşteri bilgileri arşiv kaydı içeren ürünlerde zorunludur!"); }

                else if (arsiv > 0 && selectedCari.CariNo != null)
                {
                    saveAll();
                    this.Close();
                }
                else if (arsiv == 0 && selectedCari.CariNo != null)
                {
                    saveAll();
                    this.Close();
                }
                else if (arsiv == 0 && selectedCari.CariNo == null)
                {
                    if (borc > 0)
                    {
                        MessageBox.Show("Müşteri bilgileri girilmeyen satışta borç olamaz!");
                    }
                    else
                    {
                        saveAll();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Ürün seçilmeden kayıt yapılamaz!");
            }
        }

        private void saveAll()
        {
            string CariNo = "";
            conn = new SqlConnection(connectionString);
            conn.Open();
            CariNo = selectedCari.CariNo;
            bool arsivle = false;
            int sepetNo=0;
            foreach (Urun x in Sepet)
            {
                Order yeniCikis = new Order();
                if (x.Arsivle) { arsivle = true; }
                yeniCikis.CariNo = CariNo;
                yeniCikis.UrunBarkodNo = x.BarkodNo;
                yeniCikis.Adet = x.Adet;
                yeniCikis.Indirim = x.Indirim;
                yeniCikis.Tutar = x.Fiyat;
                yeniCikis.SubeId = Properties.Settings.Default.SubeId;
                yeniCikis.SepetNo = sepetNo;
                yeniCikis.TeslimTarihi = x.TeslimTarihi;
                sepetNo = yeniCikis.addOrder();
            }
            Account yeniHesap = new Account();
            yeniHesap.SepetNo = sepetNo;
            yeniHesap.SubeId = Properties.Settings.Default.SubeId;
            yeniHesap.CariNo = CariNo;
            yeniHesap.Borc=borc;
            yeniHesap.Alinan = (from x in Sepet
                                select new { Tutar = x.Fiyat }).Sum(p => p.Tutar)-borc;
            yeniHesap.addAccount();
            if (arsivle)
            {
                Archive yeniArsiv = new Archive();
                yeniArsiv.CariNo = CariNo;
                yeniArsiv.SepetNo = sepetNo;
                yeniArsiv.SubeId = Properties.Settings.Default.SubeId;
                yeniArsiv.TurId=arsivTipiSelected;
                yeniArsiv.addArchive();
            }
        }
        #region Tasarım
        private void otoBoyutDegistir()
        {
            groupBoxProductDetails.MouseEnter += new EventHandler(groupBoxProductDetails_Buyut);
            groupBoxProductDetails.GotFocus += new EventHandler(groupBoxProductDetails_Buyut);
            groupBoxProductDetails.LostFocus += new EventHandler(groupBoxProductDetails_Kucult);
            groupBoxProductDetails.MouseLeave += new EventHandler(groupBoxProductDetails_Kucult);
            foreach (Control x in groupBoxProductDetails.Controls)
            {
                x.MouseEnter += new EventHandler(groupBoxProductDetails_Buyut);
                x.GotFocus += new EventHandler(groupBoxProductDetails_Buyut);
                x.LostFocus += new EventHandler(groupBoxProductDetails_Kucult);
                x.MouseLeave += new EventHandler(groupBoxProductDetails_Kucult);
            }
        }
        private void groupBoxProductDetails_Buyut(object sender, EventArgs e)
        {
            groupBoxUrun.BringToFront();
            groupBoxUrun.Size = new Size { Height = 400, Width = groupBoxUrun.Size.Width };
            //groupBoxProductDetails.Size = new Size { Height = 150, Width = groupBoxProductDetails.Size.Width };
            groupBoxProductDetails.MouseLeave += new EventHandler(groupBoxProductDetails_Kucult);
        }

        void groupBoxProductDetails_Kucult(object sender, EventArgs e)
        {
            groupBoxUrun.Size = new Size { Height = 281, Width = groupBoxUrun.Size.Width };
            //groupBoxProductDetails.Size = new Size { Height = 88, Width = groupBoxProductDetails.Size.Width };
        }

        #endregion Tasarım
        decimal alinanTutar=0;
        decimal borc = 0;
        private void textBoxAlinanTutar_TextChanged(object sender, EventArgs e)
        {
            decimal toplam = (from x in Sepet
                              select new { Tutar = x.Fiyat }).Sum(p => p.Tutar);
            if (textBoxAlinanTutar.Text == null || textBoxAlinanTutar.Text == "")
            {
                textBoxAlinanTutar.TextAlignChanged -= new EventHandler(textBoxAlinanTutar_TextChanged);
                textBoxAlinanTutar.Text = "0";
                textBoxAlinanTutar.TextAlignChanged -= new EventHandler(textBoxAlinanTutar_TextChanged);
            }
            if ((Convert.ToDecimal(textBoxAlinanTutar.Text) < toplam))
            {
                borc = (toplam - (Convert.ToDecimal(textBoxAlinanTutar.Text)));
                labelBorc.Text = (borc).ToString();
            }
            else
            {
                labelParaUstu.Text = (Convert.ToDecimal(textBoxAlinanTutar.Text) - toplam).ToString() + " TL";
                borc = 0;
                labelBorc.Text = "0 TL";
            }
            alinanTutar = Convert.ToDecimal(textBoxAlinanTutar.Text);
        }

        

    }
}
