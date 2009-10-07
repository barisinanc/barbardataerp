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
            cariFillMethod();
            sepetDoldur();
            personelListesiDoldur();
            otoBoyutDegistir();
            textBoxProductSearch.Focus();
            this.Text += " - Sepet No:" + SepetId + " - Cari No:" + selectedCari.CariNo;
        }
        Archive arsiv;
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
                    //
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
        Product SecilenUrun = new Product();
        List<Product> Sepet = new List<Product>();
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
            dateTimePickerDelivery.Value = DateTime.Now;
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
                textBoxProductPrice.Text = (SecilenUrun.AnaFiyat - Convert.ToDecimal(textBoxProductDiscount.Text)).ToString();
            }
            else
            { textBoxProductPrice.Text = "0"; }
        }

        private void buttonProductInsert_Click(object sender, EventArgs e)
        {
            if (labelProductSelectedBarcode.Text.Trim() != "")
            {
                Product yeniUrun = new Product();
                yeniUrun.BarkodNo = labelProductSelectedBarcode.Text;
                yeniUrun.Adi = labelProductSelectedName.Text;
                yeniUrun.Marka = labelProductSelectedBrand.Text;
                yeniUrun.Model = labelProductSelectedModel.Text;
                yeniUrun.Arsivle = checkBoxArchived.Checked;
                yeniUrun.AnaFiyat = SecilenUrun.AnaFiyat;
                yeniUrun.KullaniciId = comboBoxKullanici.SelectedIndex + 1;
                decimal indirim = 0;
                decimal fiyat = 0;
                if (textBoxProductDiscount.Text == null || textBoxProductDiscount.Text == "") { indirim = 0; }
                else { indirim = Convert.ToDecimal(textBoxProductPrice.Text); }
                if (textBoxProductPrice.Text == null || textBoxProductPrice.Text == "") { fiyat = 0; }
                else { fiyat = Convert.ToDecimal(textBoxProductPrice.Text); }
                if (fiyat + indirim != SecilenUrun.AnaFiyat)
                {
                    yeniUrun.Fiyat = Convert.ToDecimal(textBoxProductPrice.Text);
                    if (fiyat >= SecilenUrun.AnaFiyat)
                    {
                        yeniUrun.Fiyat = SecilenUrun.AnaFiyat;
                        yeniUrun.Indirim = 0;
                    }
                    else
                    {
                        yeniUrun.Indirim = SecilenUrun.AnaFiyat - fiyat;
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
            comboBoxArchiveType.SelectedIndex = arsiv.TurId - 1;
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
                Sepet.Remove(Sepet[dataGridViewProductSelected.CurrentRow.Index]);
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
            long sepetNo = SepetId;
            foreach (Product x in Sepet)
            {
                Order yeniCikis = new Order();
                yeniCikis.CariNo = CariNo;
                yeniCikis.UrunBarkodNo = x.BarkodNo;
                yeniCikis.Adet = x.Adet;
                yeniCikis.Indirim = x.Indirim;
                yeniCikis.Tutar = x.Fiyat;
                yeniCikis.SubeId = Properties.Settings.Default.SubeId;
                yeniCikis.SepetNo = sepetNo;
                yeniCikis.TeslimTarihi = x.TeslimTarihi;
                sepetNo = yeniCikis.Guncelle();
            }
            Account yeniHesap = new Account();
            yeniHesap.SepetNo = sepetNo;
            yeniHesap.SubeId = Properties.Settings.Default.SubeId;
            yeniHesap.CariNo = CariNo;
            yeniHesap.Borc=borc;
            yeniHesap.Alinan = (from x in Sepet
                                select new { Tutar = x.Fiyat }).Sum(p => p.Tutar)-borc;
            yeniHesap.addAccount();
            
        }
        #region Tasarım
        private void otoBoyutDegistir()
        {
            groupBoxProductDetails.MouseEnter += new EventHandler(groupBoxProductDetails_Buyut);
            groupBoxProductDetails.MouseHover += new EventHandler(groupBoxProductDetails_Buyut);
            groupBoxProductDetails.GotFocus += new EventHandler(groupBoxProductDetails_Buyut);
            groupBoxProductDetails.LostFocus += new EventHandler(groupBoxProductDetails_Kucult);
            groupBoxProductDetails.MouseLeave += new EventHandler(groupBoxProductDetails_Kucult);
            groupBoxProductDetails.MouseCaptureChanged += new EventHandler(groupBoxProductDetails_Kucult);
            foreach (Control x in groupBoxProductDetails.Controls)
            {
                x.MouseMove += new MouseEventHandler(groupBoxProductDetails_Buyut);
                x.MouseEnter += new EventHandler(groupBoxProductDetails_Buyut);
                x.MouseHover += new EventHandler(groupBoxProductDetails_Buyut);
                x.GotFocus += new EventHandler(groupBoxProductDetails_Buyut);
                x.LostFocus += new EventHandler(groupBoxProductDetails_Kucult);
                x.MouseLeave += new EventHandler(groupBoxProductDetails_Kucult);
                x.MouseCaptureChanged += new EventHandler(groupBoxProductDetails_Buyut);
            }
            textBoxAciklama.Parent = groupBoxProductDetails;
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

        private void comboBoxKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SonKullaniciId = comboBoxKullanici.SelectedIndex + 1;
            Properties.Settings.Default.Save();
        }

        private void buttonCariGuncelle_Click(object sender, EventArgs e)
        {

        }
    }
}
