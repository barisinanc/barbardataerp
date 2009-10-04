namespace arsiv
{
    partial class FormNewRecord
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewRecord));
            this.textBoxCariAd = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxArchiveNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCariTel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCariEposta = new System.Windows.Forms.TextBox();
            this.dateTimePickerDelivery = new System.Windows.Forms.DateTimePicker();
            this.groupBoxCari = new System.Windows.Forms.GroupBox();
            this.buttonCariAra = new System.Windows.Forms.Button();
            this.buttonCariBirak = new System.Windows.Forms.Button();
            this.buttonCariSec = new System.Windows.Forms.Button();
            this.textBoxCariAciklama = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxCariCep = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewCari = new System.Windows.Forms.DataGridView();
            this.groupBoxUrun = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericMinute = new System.Windows.Forms.NumericUpDown();
            this.numericHour = new System.Windows.Forms.NumericUpDown();
            this.labelProductSelectedBarcode = new System.Windows.Forms.Label();
            this.labelProductSelectedModel = new System.Windows.Forms.Label();
            this.labelProductSelectedBrand = new System.Windows.Forms.Label();
            this.labelProductSelectedName = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBoxArchived = new System.Windows.Forms.CheckBox();
            this.numericProductCount = new System.Windows.Forms.NumericUpDown();
            this.buttonProductInsert = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxProductPrice = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxProductDiscount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonProductSelectedDelete = new System.Windows.Forms.Button();
            this.buttonProductEdit = new System.Windows.Forms.Button();
            this.buttonProductSelectedEdit = new System.Windows.Forms.Button();
            this.buttonProductAdd = new System.Windows.Forms.Button();
            this.buttonProductSearch = new System.Windows.Forms.Button();
            this.textBoxProductSearch = new System.Windows.Forms.TextBox();
            this.dataGridViewProductSelect = new System.Windows.Forms.DataGridView();
            this.dataGridViewProductSelected = new System.Windows.Forms.DataGridView();
            this.comboBoxArchiveType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxArchive = new System.Windows.Forms.GroupBox();
            this.buttonCariGuncelle = new System.Windows.Forms.Button();
            this.groupBoxCari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCari)).BeginInit();
            this.groupBoxUrun.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericProductCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductSelected)).BeginInit();
            this.groupBoxArchive.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCariAd
            // 
            this.textBoxCariAd.Location = new System.Drawing.Point(74, 21);
            this.textBoxCariAd.Name = "textBoxCariAd";
            this.textBoxCariAd.Size = new System.Drawing.Size(129, 20);
            this.textBoxCariAd.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(629, 614);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Kaydet";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(710, 614);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "İptal";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxArchiveNo
            // 
            this.textBoxArchiveNo.Location = new System.Drawing.Point(79, 39);
            this.textBoxArchiveNo.Name = "textBoxArchiveNo";
            this.textBoxArchiveNo.Size = new System.Drawing.Size(96, 20);
            this.textBoxArchiveNo.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Arşiv No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ad Soyad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Telefon:";
            // 
            // textBoxCariTel
            // 
            this.textBoxCariTel.Location = new System.Drawing.Point(74, 73);
            this.textBoxCariTel.Name = "textBoxCariTel";
            this.textBoxCariTel.Size = new System.Drawing.Size(129, 20);
            this.textBoxCariTel.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "E-posta:";
            // 
            // textBoxCariEposta
            // 
            this.textBoxCariEposta.Location = new System.Drawing.Point(74, 99);
            this.textBoxCariEposta.Name = "textBoxCariEposta";
            this.textBoxCariEposta.Size = new System.Drawing.Size(129, 20);
            this.textBoxCariEposta.TabIndex = 9;
            // 
            // dateTimePickerDelivery
            // 
            this.dateTimePickerDelivery.Location = new System.Drawing.Point(253, 61);
            this.dateTimePickerDelivery.Name = "dateTimePickerDelivery";
            this.dateTimePickerDelivery.Size = new System.Drawing.Size(115, 20);
            this.dateTimePickerDelivery.TabIndex = 80;
            // 
            // groupBoxCari
            // 
            this.groupBoxCari.Controls.Add(this.buttonCariGuncelle);
            this.groupBoxCari.Controls.Add(this.buttonCariAra);
            this.groupBoxCari.Controls.Add(this.buttonCariBirak);
            this.groupBoxCari.Controls.Add(this.buttonCariSec);
            this.groupBoxCari.Controls.Add(this.textBoxCariAd);
            this.groupBoxCari.Controls.Add(this.textBoxCariAciklama);
            this.groupBoxCari.Controls.Add(this.label10);
            this.groupBoxCari.Controls.Add(this.textBoxCariEposta);
            this.groupBoxCari.Controls.Add(this.label4);
            this.groupBoxCari.Controls.Add(this.label2);
            this.groupBoxCari.Controls.Add(this.textBoxCariCep);
            this.groupBoxCari.Controls.Add(this.textBoxCariTel);
            this.groupBoxCari.Controls.Add(this.label7);
            this.groupBoxCari.Controls.Add(this.label3);
            this.groupBoxCari.Controls.Add(this.dataGridViewCari);
            this.groupBoxCari.Location = new System.Drawing.Point(12, 449);
            this.groupBoxCari.Name = "groupBoxCari";
            this.groupBoxCari.Size = new System.Drawing.Size(664, 159);
            this.groupBoxCari.TabIndex = 11;
            this.groupBoxCari.TabStop = false;
            this.groupBoxCari.Text = "Müşteri Bilgileri";
            // 
            // buttonCariAra
            // 
            this.buttonCariAra.Location = new System.Drawing.Point(210, 21);
            this.buttonCariAra.Name = "buttonCariAra";
            this.buttonCariAra.Size = new System.Drawing.Size(43, 72);
            this.buttonCariAra.TabIndex = 15;
            this.buttonCariAra.Text = "Ara";
            this.buttonCariAra.UseVisualStyleBackColor = true;
            this.buttonCariAra.Click += new System.EventHandler(this.buttonCariAra_Click);
            // 
            // buttonCariBirak
            // 
            this.buttonCariBirak.Location = new System.Drawing.Point(608, 85);
            this.buttonCariBirak.Name = "buttonCariBirak";
            this.buttonCariBirak.Size = new System.Drawing.Size(49, 60);
            this.buttonCariBirak.TabIndex = 14;
            this.buttonCariBirak.Text = "Bırak";
            this.buttonCariBirak.UseVisualStyleBackColor = true;
            this.buttonCariBirak.Click += new System.EventHandler(this.buttonCariBirak_Click);
            // 
            // buttonCariSec
            // 
            this.buttonCariSec.Location = new System.Drawing.Point(608, 19);
            this.buttonCariSec.Name = "buttonCariSec";
            this.buttonCariSec.Size = new System.Drawing.Size(49, 60);
            this.buttonCariSec.TabIndex = 13;
            this.buttonCariSec.Text = "Seç";
            this.buttonCariSec.UseVisualStyleBackColor = true;
            this.buttonCariSec.Click += new System.EventHandler(this.buttonCariSec_Click);
            // 
            // textBoxCariAciklama
            // 
            this.textBoxCariAciklama.Location = new System.Drawing.Point(73, 125);
            this.textBoxCariAciklama.Name = "textBoxCariAciklama";
            this.textBoxCariAciklama.Size = new System.Drawing.Size(130, 20);
            this.textBoxCariAciklama.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Açıklama:";
            // 
            // textBoxCariCep
            // 
            this.textBoxCariCep.Location = new System.Drawing.Point(74, 47);
            this.textBoxCariCep.Name = "textBoxCariCep";
            this.textBoxCariCep.Size = new System.Drawing.Size(129, 20);
            this.textBoxCariCep.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Cep Telefon:";
            // 
            // dataGridViewCari
            // 
            this.dataGridViewCari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCari.Location = new System.Drawing.Point(259, 19);
            this.dataGridViewCari.Name = "dataGridViewCari";
            this.dataGridViewCari.RowHeadersWidth = 20;
            this.dataGridViewCari.Size = new System.Drawing.Size(343, 126);
            this.dataGridViewCari.TabIndex = 12;
            this.dataGridViewCari.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCari_CellContentDoubleClick);
            // 
            // groupBoxUrun
            // 
            this.groupBoxUrun.Controls.Add(this.groupBox1);
            this.groupBoxUrun.Controls.Add(this.buttonProductSelectedDelete);
            this.groupBoxUrun.Controls.Add(this.buttonProductEdit);
            this.groupBoxUrun.Controls.Add(this.buttonProductSelectedEdit);
            this.groupBoxUrun.Controls.Add(this.buttonProductAdd);
            this.groupBoxUrun.Controls.Add(this.buttonProductSearch);
            this.groupBoxUrun.Controls.Add(this.textBoxProductSearch);
            this.groupBoxUrun.Controls.Add(this.dataGridViewProductSelect);
            this.groupBoxUrun.Controls.Add(this.dataGridViewProductSelected);
            this.groupBoxUrun.Location = new System.Drawing.Point(12, 12);
            this.groupBoxUrun.Name = "groupBoxUrun";
            this.groupBoxUrun.Size = new System.Drawing.Size(854, 431);
            this.groupBoxUrun.TabIndex = 12;
            this.groupBoxUrun.TabStop = false;
            this.groupBoxUrun.Text = "Ürün Bilgileri";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericMinute);
            this.groupBox1.Controls.Add(this.numericHour);
            this.groupBox1.Controls.Add(this.labelProductSelectedBarcode);
            this.groupBox1.Controls.Add(this.labelProductSelectedModel);
            this.groupBox1.Controls.Add(this.labelProductSelectedBrand);
            this.groupBox1.Controls.Add(this.labelProductSelectedName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.checkBoxArchived);
            this.groupBox1.Controls.Add(this.dateTimePickerDelivery);
            this.groupBox1.Controls.Add(this.numericProductCount);
            this.groupBox1.Controls.Add(this.buttonProductInsert);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxProductPrice);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxProductDiscount);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(6, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 88);
            this.groupBox1.TabIndex = 92;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detaylar";
            // 
            // numericMinute
            // 
            this.numericMinute.Location = new System.Drawing.Point(529, 59);
            this.numericMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericMinute.Name = "numericMinute";
            this.numericMinute.Size = new System.Drawing.Size(39, 20);
            this.numericMinute.TabIndex = 95;
            // 
            // numericHour
            // 
            this.numericHour.Location = new System.Drawing.Point(481, 59);
            this.numericHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericHour.Name = "numericHour";
            this.numericHour.Size = new System.Drawing.Size(39, 20);
            this.numericHour.TabIndex = 95;
            // 
            // labelProductSelectedBarcode
            // 
            this.labelProductSelectedBarcode.AutoSize = true;
            this.labelProductSelectedBarcode.Location = new System.Drawing.Point(162, 18);
            this.labelProductSelectedBarcode.Name = "labelProductSelectedBarcode";
            this.labelProductSelectedBarcode.Size = new System.Drawing.Size(0, 13);
            this.labelProductSelectedBarcode.TabIndex = 94;
            // 
            // labelProductSelectedModel
            // 
            this.labelProductSelectedModel.AutoSize = true;
            this.labelProductSelectedModel.Location = new System.Drawing.Point(17, 62);
            this.labelProductSelectedModel.Name = "labelProductSelectedModel";
            this.labelProductSelectedModel.Size = new System.Drawing.Size(0, 13);
            this.labelProductSelectedModel.TabIndex = 93;
            // 
            // labelProductSelectedBrand
            // 
            this.labelProductSelectedBrand.AutoSize = true;
            this.labelProductSelectedBrand.Location = new System.Drawing.Point(17, 39);
            this.labelProductSelectedBrand.Name = "labelProductSelectedBrand";
            this.labelProductSelectedBrand.Size = new System.Drawing.Size(0, 13);
            this.labelProductSelectedBrand.TabIndex = 93;
            // 
            // labelProductSelectedName
            // 
            this.labelProductSelectedName.AutoSize = true;
            this.labelProductSelectedName.Location = new System.Drawing.Point(17, 18);
            this.labelProductSelectedName.Name = "labelProductSelectedName";
            this.labelProductSelectedName.Size = new System.Drawing.Size(67, 13);
            this.labelProductSelectedName.TabIndex = 93;
            this.labelProductSelectedName.Text = "Ürün Seçiniz";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(178, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 81;
            this.label11.Text = "Teslim Tarihi:";
            // 
            // checkBoxArchived
            // 
            this.checkBoxArchived.AutoSize = true;
            this.checkBoxArchived.Location = new System.Drawing.Point(590, 66);
            this.checkBoxArchived.Name = "checkBoxArchived";
            this.checkBoxArchived.Size = new System.Drawing.Size(57, 17);
            this.checkBoxArchived.TabIndex = 92;
            this.checkBoxArchived.Text = "Arşivle";
            this.checkBoxArchived.UseVisualStyleBackColor = true;
            // 
            // numericProductCount
            // 
            this.numericProductCount.Location = new System.Drawing.Point(203, 34);
            this.numericProductCount.Name = "numericProductCount";
            this.numericProductCount.Size = new System.Drawing.Size(75, 20);
            this.numericProductCount.TabIndex = 30;
            this.numericProductCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonProductInsert
            // 
            this.buttonProductInsert.Location = new System.Drawing.Point(590, 36);
            this.buttonProductInsert.Name = "buttonProductInsert";
            this.buttonProductInsert.Size = new System.Drawing.Size(105, 22);
            this.buttonProductInsert.TabIndex = 90;
            this.buttonProductInsert.Text = "Kaydet";
            this.buttonProductInsert.UseVisualStyleBackColor = true;
            this.buttonProductInsert.Click += new System.EventHandler(this.buttonProductInsert_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(165, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Adet:";
            // 
            // textBoxProductPrice
            // 
            this.textBoxProductPrice.Location = new System.Drawing.Point(322, 34);
            this.textBoxProductPrice.Name = "textBoxProductPrice";
            this.textBoxProductPrice.Size = new System.Drawing.Size(88, 20);
            this.textBoxProductPrice.TabIndex = 40;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(407, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Teslim Saati:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(434, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "İndirim:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(284, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Fiyat:";
            // 
            // textBoxProductDiscount
            // 
            this.textBoxProductDiscount.Location = new System.Drawing.Point(480, 34);
            this.textBoxProductDiscount.Name = "textBoxProductDiscount";
            this.textBoxProductDiscount.Size = new System.Drawing.Size(88, 20);
            this.textBoxProductDiscount.TabIndex = 50;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(519, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(10, 13);
            this.label13.TabIndex = 96;
            this.label13.Text = ":";
            // 
            // buttonProductSelectedDelete
            // 
            this.buttonProductSelectedDelete.Location = new System.Drawing.Point(749, 328);
            this.buttonProductSelectedDelete.Name = "buttonProductSelectedDelete";
            this.buttonProductSelectedDelete.Size = new System.Drawing.Size(96, 23);
            this.buttonProductSelectedDelete.TabIndex = 20;
            this.buttonProductSelectedDelete.Text = "Siparişi İptal Et";
            this.buttonProductSelectedDelete.UseVisualStyleBackColor = true;
            this.buttonProductSelectedDelete.Click += new System.EventHandler(this.buttonProductSelectedDelete_Click);
            // 
            // buttonProductEdit
            // 
            this.buttonProductEdit.Location = new System.Drawing.Point(749, 46);
            this.buttonProductEdit.Name = "buttonProductEdit";
            this.buttonProductEdit.Size = new System.Drawing.Size(96, 23);
            this.buttonProductEdit.TabIndex = 19;
            this.buttonProductEdit.Text = "Ürünü Düzenle";
            this.buttonProductEdit.UseVisualStyleBackColor = true;
            // 
            // buttonProductSelectedEdit
            // 
            this.buttonProductSelectedEdit.Location = new System.Drawing.Point(749, 279);
            this.buttonProductSelectedEdit.Name = "buttonProductSelectedEdit";
            this.buttonProductSelectedEdit.Size = new System.Drawing.Size(96, 23);
            this.buttonProductSelectedEdit.TabIndex = 15;
            this.buttonProductSelectedEdit.Text = "Siparişi Düzenle";
            this.buttonProductSelectedEdit.UseVisualStyleBackColor = true;
            this.buttonProductSelectedEdit.Click += new System.EventHandler(this.buttonProductSelectedEdit_Click);
            // 
            // buttonProductAdd
            // 
            this.buttonProductAdd.Location = new System.Drawing.Point(749, 156);
            this.buttonProductAdd.Name = "buttonProductAdd";
            this.buttonProductAdd.Size = new System.Drawing.Size(96, 23);
            this.buttonProductAdd.TabIndex = 18;
            this.buttonProductAdd.Text = "Yeni Ürün";
            this.buttonProductAdd.UseVisualStyleBackColor = true;
            this.buttonProductAdd.Click += new System.EventHandler(this.buttonProductAdd_Click);
            // 
            // buttonProductSearch
            // 
            this.buttonProductSearch.Location = new System.Drawing.Point(171, 16);
            this.buttonProductSearch.Name = "buttonProductSearch";
            this.buttonProductSearch.Size = new System.Drawing.Size(51, 23);
            this.buttonProductSearch.TabIndex = 15;
            this.buttonProductSearch.Text = "Ara";
            this.buttonProductSearch.UseVisualStyleBackColor = true;
            this.buttonProductSearch.Click += new System.EventHandler(this.buttonProductSearch_Click);
            // 
            // textBoxProductSearch
            // 
            this.textBoxProductSearch.Location = new System.Drawing.Point(6, 19);
            this.textBoxProductSearch.Name = "textBoxProductSearch";
            this.textBoxProductSearch.Size = new System.Drawing.Size(147, 20);
            this.textBoxProductSearch.TabIndex = 10;
            this.textBoxProductSearch.TextChanged += new System.EventHandler(this.textBoxProductSearch_TextChanged);
            // 
            // dataGridViewProductSelect
            // 
            this.dataGridViewProductSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductSelect.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewProductSelect.Location = new System.Drawing.Point(6, 46);
            this.dataGridViewProductSelect.MultiSelect = false;
            this.dataGridViewProductSelect.Name = "dataGridViewProductSelect";
            this.dataGridViewProductSelect.RowHeadersWidth = 20;
            this.dataGridViewProductSelect.Size = new System.Drawing.Size(736, 133);
            this.dataGridViewProductSelect.TabIndex = 20;
            this.dataGridViewProductSelect.SelectionChanged += new System.EventHandler(this.dataGridViewProductSelect_SelectionChanged);
            // 
            // dataGridViewProductSelected
            // 
            this.dataGridViewProductSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductSelected.Location = new System.Drawing.Point(6, 279);
            this.dataGridViewProductSelected.Name = "dataGridViewProductSelected";
            this.dataGridViewProductSelected.RowHeadersWidth = 20;
            this.dataGridViewProductSelected.Size = new System.Drawing.Size(736, 146);
            this.dataGridViewProductSelected.TabIndex = 2;
            this.dataGridViewProductSelected.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProductSelected_CellContentDoubleClick);
            // 
            // comboBoxArchiveType
            // 
            this.comboBoxArchiveType.FormattingEnabled = true;
            this.comboBoxArchiveType.Location = new System.Drawing.Point(79, 11);
            this.comboBoxArchiveType.Name = "comboBoxArchiveType";
            this.comboBoxArchiveType.Size = new System.Drawing.Size(96, 21);
            this.comboBoxArchiveType.TabIndex = 60;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Arşiv Tipi:";
            // 
            // groupBoxArchive
            // 
            this.groupBoxArchive.Controls.Add(this.label1);
            this.groupBoxArchive.Controls.Add(this.textBoxArchiveNo);
            this.groupBoxArchive.Controls.Add(this.comboBoxArchiveType);
            this.groupBoxArchive.Controls.Add(this.label5);
            this.groupBoxArchive.Location = new System.Drawing.Point(682, 468);
            this.groupBoxArchive.Name = "groupBoxArchive";
            this.groupBoxArchive.Size = new System.Drawing.Size(184, 68);
            this.groupBoxArchive.TabIndex = 91;
            this.groupBoxArchive.TabStop = false;
            this.groupBoxArchive.Text = "Arşiv Bilgileri";
            this.groupBoxArchive.Visible = false;
            // 
            // buttonCariGuncelle
            // 
            this.buttonCariGuncelle.Location = new System.Drawing.Point(210, 100);
            this.buttonCariGuncelle.Name = "buttonCariGuncelle";
            this.buttonCariGuncelle.Size = new System.Drawing.Size(43, 53);
            this.buttonCariGuncelle.TabIndex = 16;
            this.buttonCariGuncelle.Text = "Guncelle";
            this.buttonCariGuncelle.UseVisualStyleBackColor = true;
            // 
            // FormNewRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 642);
            this.Controls.Add(this.groupBoxUrun);
            this.Controls.Add(this.groupBoxCari);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxArchive);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormNewRecord";
            this.Text = "Yeni Kayıt";
            this.TopMost = true;
            this.groupBoxCari.ResumeLayout(false);
            this.groupBoxCari.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCari)).EndInit();
            this.groupBoxUrun.ResumeLayout(false);
            this.groupBoxUrun.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericProductCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductSelected)).EndInit();
            this.groupBoxArchive.ResumeLayout(false);
            this.groupBoxArchive.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCariAd;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxArchiveNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCariTel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCariEposta;
        private System.Windows.Forms.DateTimePicker dateTimePickerDelivery;
        private System.Windows.Forms.GroupBox groupBoxCari;
        private System.Windows.Forms.DataGridView dataGridViewCari;
        private System.Windows.Forms.GroupBox groupBoxUrun;
        private System.Windows.Forms.ComboBox comboBoxArchiveType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonProductInsert;
        private System.Windows.Forms.DataGridView dataGridViewProductSelected;
        private System.Windows.Forms.NumericUpDown numericProductCount;
        private System.Windows.Forms.Button buttonProductSearch;
        private System.Windows.Forms.TextBox textBoxProductSearch;
        private System.Windows.Forms.Button buttonProductSelectedEdit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxProductPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxProductDiscount;
        private System.Windows.Forms.Button buttonProductEdit;
        private System.Windows.Forms.Button buttonProductAdd;
        private System.Windows.Forms.TextBox textBoxCariCep;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonProductSelectedDelete;
        private System.Windows.Forms.DataGridView dataGridViewProductSelect;
        private System.Windows.Forms.TextBox textBoxCariAciklama;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxArchive;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBoxArchived;
        private System.Windows.Forms.Label labelProductSelectedModel;
        private System.Windows.Forms.Label labelProductSelectedBrand;
        private System.Windows.Forms.Label labelProductSelectedName;
        private System.Windows.Forms.Label labelProductSelectedBarcode;
        private System.Windows.Forms.NumericUpDown numericMinute;
        private System.Windows.Forms.NumericUpDown numericHour;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonCariSec;
        private System.Windows.Forms.Button buttonCariBirak;
        private System.Windows.Forms.Button buttonCariAra;
        private System.Windows.Forms.Button buttonCariGuncelle;
    }
}