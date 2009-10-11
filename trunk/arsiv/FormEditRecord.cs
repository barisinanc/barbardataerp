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
    public partial class FormEditRecord : Form
    {
        public long SepetId;

        public FormEditRecord()
        {
            InitializeComponent();
        }

        #region Forma dışardan gelen bilgiler
        /*
        public List<Product> GelenSepet
        {
            get
            {
                return Sepet;
            }
            set
            {
                Sepet.AddRange(value);
            }
        }
        public Cari GelenCari
        {
            get
            {
                return selectedCari;
            }
            set
            {
                selectedCari = value;
            }
        }
         */
        #endregion Forma dışardan gelen bilgiler
        

        private void FormNewRecord_Load(object sender, EventArgs e)
        {
            odemeListesiDoldur();
            cariFillMethod();
            bakiyeDoldur();
            sepetDoldur();
            personelListesiDoldur();
            textBoxProductSearch.Focus();
            this.Text += " - Sepet No:" + SepetId + " - Cari No:" + selectedCari.CariNo;
        }
        Archive arsiv;

        private void odemeListesiDoldur()
        {
            OdemeTuru tur = new OdemeTuru();
            foreach (OdemeTuru x in tur.OdemeTurleri())
            {
                comboBoxOdemeTipi.Items.Add(x.Ad);
            }
            comboBoxOdemeTipi.SelectedIndex = 0;
        }

        private void sepetDoldur()
        {
            BarisGorselDLL.Sepet liste = new Sepet();
            Sepet.AddRange(liste.sepetGetir(SepetId));
            foreach (Product p in Sepet)
            {
                if (p.Arsivle)
                {
                    arsiv = new Archive();
                    arsiv = arsiv.sepettenArsiv(SepetId);
                    archivLoader();
                }
            }
            sepetGridRefresh();
        }

        private void personelListesiDoldur()
        {
            Kullanici kullanici = new Kullanici();
            foreach (Kullanici k in kullanici.kullanicilar())
            {
                comboBoxKullanici.Items.Add(k.Ad);
            }
            if (Properties.Settings.Default.SonKullaniciId != 0)
            {
                comboBoxKullanici.SelectedIndex = Properties.Settings.Default.SonKullaniciId-1;
            }
            else
            {
                comboBoxKullanici.SelectedIndex = 0;
            }

        }

        private void comboBoxKullanici_Click(object sender, EventArgs e)
        {
            comboBoxKullanici.DroppedDown = true;
        }
        
        #region Product
        List<Product> Urunler = new List<Product>();
        Sepet SecilenUrun = new Sepet();
        List<Sepet> Sepet = new List<Sepet>();
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
            dateTimePickerDelivery.Value = DateTime.Now;
        }

        private void buttonProductSearch_Click(object sender, EventArgs e)
        {
            productSearch();
        }

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
            }
            if (Urunler.Count > 0)
            {
            var selectedProducts = from x in Urunler
                                    select new { Barkod_No = x.BarkodNo, Ürün = x.Adi+" "+x.Marka+" "+x.Model, Fiyat = x.Fiyat };
            dataGridViewProductSelect.SelectionChanged -= new EventHandler(dataGridViewProductSelect_SelectionChanged);
            dataGridViewProductSelect.DataSource = selectedProducts.ToList();
            dataGridViewProductSelect.SelectionChanged += new EventHandler(dataGridViewProductSelect_SelectionChanged);
            dataGridViewProductSelect.Rows[0].Selected = true;
            }
            else
            {
                dataGridViewProductSelect.DataSource = null;
            }
        }

        private void dataGridViewProductSelect_SelectionChanged(object sender, EventArgs e)
        {
            if (Urunler.Count > 0)
            {
                SecilenUrun.AddProduct(Urunler[(dataGridViewProductSelect.CurrentRow.Index)]);
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

        private void numericProductCount_ValueChanged(object sender, EventArgs e)
        {
            textBoxProductPrice.Text = (SecilenUrun.Fiyat * numericProductCount.Value).ToString();
        }

        private void textBoxProductDiscount_TextChanged(object sender, EventArgs e)
        {
            if (textBoxProductDiscount.Text == null || textBoxProductDiscount.Text == "") { textBoxProductDiscount.Text = "0"; }
            if (Convert.ToDecimal(textBoxProductDiscount.Text) <= SecilenUrun.Fiyat * numericProductCount.Value)
            {
                textBoxProductPrice.Text = ((SecilenUrun.AnaFiyat * numericProductCount.Value) - Convert.ToDecimal(textBoxProductDiscount.Text)).ToString();
            }
            else
            { textBoxProductPrice.Text = "0"; }
        }

        private void buttonProductInsert_Click(object sender, EventArgs e)
        {
            if (labelProductSelectedBarcode.Text.Trim() != "")
            {
                Sepet yeniUrun = new Sepet();
                yeniUrun.BarkodNo = labelProductSelectedBarcode.Text;
                yeniUrun.Adi = labelProductSelectedName.Text;
                yeniUrun.Marka = labelProductSelectedBrand.Text;
                yeniUrun.Model = labelProductSelectedModel.Text;
                yeniUrun.Arsivle = checkBoxArchived.Checked;
                yeniUrun.AnaFiyat = SecilenUrun.AnaFiyat * numericProductCount.Value;
                yeniUrun.KullaniciId = comboBoxKullanici.SelectedIndex + 1;
                yeniUrun.Id = SecilenUrun.Id;
                if (yeniUrun.Id != 0)
                { yeniUrun.Degisti = true; }
                decimal indirim = 0;
                decimal fiyat = 0;
                if (textBoxProductDiscount.Text == null || textBoxProductDiscount.Text == "") { indirim = 0; }
                else { indirim = Convert.ToDecimal(textBoxProductPrice.Text); }
                if (textBoxProductPrice.Text == null || textBoxProductPrice.Text == "") { fiyat = 0; }
                else { fiyat = Convert.ToDecimal(textBoxProductPrice.Text); }
                if (fiyat + indirim != yeniUrun.AnaFiyat)
                {
                    yeniUrun.Fiyat = Convert.ToDecimal(textBoxProductPrice.Text);
                    if (fiyat >= yeniUrun.AnaFiyat)
                    {
                        //yeniUrun.Fiyat = SecilenUrun.AnaFiyat;
                        yeniUrun.Indirim = 0;
                    }
                    else
                    {
                        yeniUrun.Indirim = yeniUrun.AnaFiyat - fiyat;
                        yeniUrun.Fiyat = fiyat;
                    }
                }
                else
                {
                    yeniUrun.Fiyat = fiyat;
                    yeniUrun.Indirim = indirim;
                }
                yeniUrun.TeslimTarihi = DateTime.Parse(dateTimePickerDelivery.Value.ToShortDateString() + " " + numericHour.Value.ToString() + ":" + numericMinute.Value.ToString());
                try { yeniUrun.Adet = Convert.ToInt32(numericProductCount.Value); }
                catch { yeniUrun.Adet = 1; }
                if (SecilenUrun.SepetIndex == -1)
                {
                    Sepet.Add(yeniUrun);
                }
                else
                {
                    Sepet[SecilenUrun.SepetIndex] = yeniUrun;
                }
                sepetGridRefresh();
            }
        }

        

        private void sepetGridRefresh()
        {
            
                var sepetData = from x in Sepet
                                where x.Sil==false
                                select new { Barkod_No = x.BarkodNo, Ürün = x.Adi+" "+x.Marka+" "+x.Model, Adet = x.Adet, Fiyat = x.Fiyat, İndirim = x.Indirim, Teslim_Tarihi =x.TeslimTarihi };
                dataGridViewProductSelected.DataSource = sepetData.ToList();
                int arsivlenecek = (from x in Sepet
                                    where x.Arsivle==true
                                   select new { adet = x.Arsivle }).Count();
                if (arsivlenecek > 0)
                { groupBoxArchive.Visible = true;  }
                else
                { groupBoxArchive.Visible = false; }
            decimal bakiye= (from x in Sepet
                             where x.Sil == false
                        select new {Tutar = x.Fiyat}).Sum(p=>p.Tutar);
            labelBakiye.Text = bakiye.ToString() + " TL";
            textBoxAlinanTutar.TextAlignChanged -= new EventHandler(textBoxAlinanTutar_TextChanged);
            textBoxAlinanTutar.Text = "0";
            textBoxAlinanTutar.TextAlignChanged += new EventHandler(textBoxAlinanTutar_TextChanged);
        }
        private void archivLoader()
        {
            ArchiveTypes arsivTipi = new ArchiveTypes();
            groupBoxArchive.Visible = true;
            foreach (ArchiveTypes tip in arsivTipi.readTypes())
            {
                comboBoxArchiveType.Items.Add(tip.Ad);
            }
            comboBoxArchiveType.SelectedIndex = arsiv.TurId - 1;
            arsivTipi.Dispose();
        }

        private void comboBoxArchiveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            arsiv.TurId = comboBoxArchiveType.SelectedIndex + 1;
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
                comboBoxKullanici.SelectedIndex = SecilenUrun.KullaniciId-1;
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
                SecilenUrun.SepetIndex = dataGridViewProductSelected.CurrentRow.Index;
                

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
                Sepet[dataGridViewProductSelected.CurrentRow.Index].Sil=true;
                Sepet[dataGridViewProductSelected.CurrentRow.Index].Degisti = true;
                sepetGridRefresh();
                detailsClean();
            }
        }

        private void detailsClean()
        {
            labelProductSelectedName.Text = "Bir ürün seçiniz!";
            labelProductSelectedBrand.Text = null;
            labelProductSelectedModel.Text = null;
            labelProductSelectedBarcode.Text = null;
            textBoxProductPrice.Text = null;
            textBoxProductDiscount.TextChanged -= new EventHandler(textBoxProductDiscount_TextChanged);
            textBoxProductDiscount.Text = "0";
            textBoxProductDiscount.TextChanged += new EventHandler(textBoxProductDiscount_TextChanged);
            dateTimePickerDelivery.Value = DateTime.Now;
            numericHour.Value = DateTime.Now.Hour;
            numericMinute.Value = DateTime.Now.Minute;
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
   
        Cari selectedCari = new Cari();

        private void cariFillMethod()
        {
            selectedCari = selectedCari.sepetNodanCari(SepetId);
            textBoxCariAd.Text = selectedCari.Isim;
            textBoxCariCep.Text = selectedCari.CepNo;
            textBoxCariTel.Text = selectedCari.TelNo;
            textBoxCariEposta.Text = selectedCari.Eposta;
            textBoxCariAciklama.Text = selectedCari.Aciklama;
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


        #endregion Cari

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            if (Sepet.Count > 0)
            {
                int arsiv = (from x in Sepet
                             where x.Arsivle == true
                             select x).Count();
                if (arsiv > 0 && selectedCari.CariNo == 0)
                { MessageBox.Show("Müşteri bilgileri arşiv kaydı içeren ürünlerde zorunludur!"); }

                else if (arsiv > 0 && selectedCari.CariNo != 0)
                {
                    saveAll();
                    this.Close();
                }
                else if (arsiv == 0 && selectedCari.CariNo != 0)
                {
                    saveAll();
                    this.Close();
                }
                else if (arsiv == 0 && selectedCari.CariNo == 0)
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
            long CariNo = selectedCari.CariNo;
            foreach (Sepet x in Sepet)
            {
                Order yeniCikis = new Order();
                yeniCikis.CariNo = CariNo;
                yeniCikis.BarkodNo = x.BarkodNo;
                yeniCikis.Adet = x.Adet;
                yeniCikis.Indirim = x.Indirim;
                yeniCikis.Fiyat = x.Fiyat;
                yeniCikis.SubeId = Properties.Settings.Default.SubeId;
                yeniCikis.SepetNo = SepetId;
                yeniCikis.Id = x.Id;
                yeniCikis.TeslimTarihi = x.TeslimTarihi;
                if (x.Degisti)
                {
                    if (x.Sil == false)
                    { yeniCikis.Guncelle(); }
                    else
                    { yeniCikis.SepetSil(); }
                }
                else
                { yeniCikis.addOrder(); }
            }
            if (arsiv != null)
            {
                arsiv.TurGuncelle();
            }
            Account yeniHesap = new Account();
            yeniHesap.SepetNo = SepetId;
            yeniHesap.SubeId = Properties.Settings.Default.SubeId;
            yeniHesap.CariNo = CariNo;
            yeniHesap.OdemeTuru = comboBoxOdemeTipi.SelectedIndex + 1;
            yeniHesap.Borc=borc;
            yeniHesap.Alinan = (from x in Sepet
                                select new { Tutar = x.Fiyat }).Sum(p => p.Tutar)-borc;
            if (yeniHesap.Alinan > decimal.Parse("0"))
            {
                yeniHesap.addAccount();
            }
            
        }
        
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

        private void comboBoxKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SonKullaniciId = comboBoxKullanici.SelectedIndex + 1;
            Properties.Settings.Default.Save();
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

        private void bakiyeDoldur()
        {

            
        }

    }
}
