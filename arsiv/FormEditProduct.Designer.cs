namespace arsiv
{
    partial class FormEditProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditProduct));
            this.label4454 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxBrand = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewNames = new System.Windows.Forms.DataGridView();
            this.dataGridViewBrand = new System.Windows.Forms.DataGridView();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxArchived = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxKdv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelBarkodNo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewProductSelect = new System.Windows.Forms.DataGridView();
            this.buttonProductDelete = new System.Windows.Forms.Button();
            this.dataGridViewTree = new System.Windows.Forms.DataGridView();
            this.labelSelectedBarcode = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonProductAdd = new System.Windows.Forms.Button();
            this.textBoxProductSearch = new System.Windows.Forms.TextBox();
            this.textBoxAdet = new System.Windows.Forms.TextBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.buttonTreeEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBrand)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTree)).BeginInit();
            this.SuspendLayout();
            // 
            // label4454
            // 
            this.label4454.AutoSize = true;
            this.label4454.Location = new System.Drawing.Point(19, 28);
            this.label4454.Name = "label4454";
            this.label4454.Size = new System.Drawing.Size(61, 13);
            this.label4454.TabIndex = 1;
            this.label4454.Text = "Barkod No:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(86, 51);
            this.textBoxName.MaxLength = 50;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 10;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(28, 54);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(33, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Ürün:";
            // 
            // textBoxBrand
            // 
            this.textBoxBrand.Location = new System.Drawing.Point(86, 155);
            this.textBoxBrand.MaxLength = 50;
            this.textBoxBrand.Name = "textBoxBrand";
            this.textBoxBrand.Size = new System.Drawing.Size(100, 20);
            this.textBoxBrand.TabIndex = 20;
            this.textBoxBrand.TextChanged += new System.EventHandler(this.textBoxBrand_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Marka:";
            // 
            // dataGridViewNames
            // 
            this.dataGridViewNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNames.Location = new System.Drawing.Point(201, 51);
            this.dataGridViewNames.MultiSelect = false;
            this.dataGridViewNames.Name = "dataGridViewNames";
            this.dataGridViewNames.ReadOnly = true;
            this.dataGridViewNames.Size = new System.Drawing.Size(165, 87);
            this.dataGridViewNames.TabIndex = 2;
            this.dataGridViewNames.TabStop = false;
            this.dataGridViewNames.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNames_CellContentDoubleClick);
            // 
            // dataGridViewBrand
            // 
            this.dataGridViewBrand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBrand.Location = new System.Drawing.Point(201, 155);
            this.dataGridViewBrand.MultiSelect = false;
            this.dataGridViewBrand.Name = "dataGridViewBrand";
            this.dataGridViewBrand.ReadOnly = true;
            this.dataGridViewBrand.Size = new System.Drawing.Size(165, 87);
            this.dataGridViewBrand.TabIndex = 3;
            this.dataGridViewBrand.TabStop = false;
            this.dataGridViewBrand.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBrand_CellContentDoubleClick);
            // 
            // textBoxModel
            // 
            this.textBoxModel.Location = new System.Drawing.Point(86, 255);
            this.textBoxModel.MaxLength = 50;
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(100, 20);
            this.textBoxModel.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Model:";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(86, 294);
            this.textBoxPrice.MaxLength = 100;
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrice.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Fiyat:";
            // 
            // checkBoxArchived
            // 
            this.checkBoxArchived.AutoSize = true;
            this.checkBoxArchived.Location = new System.Drawing.Point(31, 359);
            this.checkBoxArchived.Name = "checkBoxArchived";
            this.checkBoxArchived.Size = new System.Drawing.Size(87, 17);
            this.checkBoxArchived.TabIndex = 60;
            this.checkBoxArchived.Text = "Arşivlenecek";
            this.checkBoxArchived.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(246, 375);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(39, 23);
            this.buttonCancel.TabIndex = 80;
            this.buttonCancel.Text = "İptal";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(291, 334);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 64);
            this.buttonSave.TabIndex = 70;
            this.buttonSave.Text = "Kaydet";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxKdv
            // 
            this.textBoxKdv.Location = new System.Drawing.Point(261, 298);
            this.textBoxKdv.MaxLength = 3;
            this.textBoxKdv.Name = "textBoxKdv";
            this.textBoxKdv.Size = new System.Drawing.Size(81, 20);
            this.textBoxKdv.TabIndex = 50;
            this.textBoxKdv.Text = "18";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Kdv:";
            // 
            // labelBarkodNo
            // 
            this.labelBarkodNo.AutoSize = true;
            this.labelBarkodNo.Location = new System.Drawing.Point(86, 28);
            this.labelBarkodNo.Name = "labelBarkodNo";
            this.labelBarkodNo.Size = new System.Drawing.Size(0, 13);
            this.labelBarkodNo.TabIndex = 81;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(197, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 94;
            this.label6.Text = "Ürün Tipi:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonTreeEdit);
            this.groupBox1.Controls.Add(this.dataGridViewProductSelect);
            this.groupBox1.Controls.Add(this.buttonProductDelete);
            this.groupBox1.Controls.Add(this.dataGridViewTree);
            this.groupBox1.Controls.Add(this.labelSelectedBarcode);
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonProductAdd);
            this.groupBox1.Controls.Add(this.textBoxProductSearch);
            this.groupBox1.Controls.Add(this.textBoxAdet);
            this.groupBox1.Location = new System.Drawing.Point(391, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 406);
            this.groupBox1.TabIndex = 93;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ürün Bileşenleri";
            // 
            // dataGridViewProductSelect
            // 
            this.dataGridViewProductSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductSelect.Location = new System.Drawing.Point(6, 41);
            this.dataGridViewProductSelect.Name = "dataGridViewProductSelect";
            this.dataGridViewProductSelect.Size = new System.Drawing.Size(343, 160);
            this.dataGridViewProductSelect.TabIndex = 81;
            // 
            // buttonProductDelete
            // 
            this.buttonProductDelete.Location = new System.Drawing.Point(274, 372);
            this.buttonProductDelete.Name = "buttonProductDelete";
            this.buttonProductDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonProductDelete.TabIndex = 89;
            this.buttonProductDelete.Text = "Seçileni Sil";
            this.buttonProductDelete.UseVisualStyleBackColor = true;
            this.buttonProductDelete.Click += new System.EventHandler(this.buttonProductDelete_Click);
            // 
            // dataGridViewTree
            // 
            this.dataGridViewTree.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTree.Location = new System.Drawing.Point(5, 235);
            this.dataGridViewTree.Name = "dataGridViewTree";
            this.dataGridViewTree.Size = new System.Drawing.Size(343, 131);
            this.dataGridViewTree.TabIndex = 81;
            // 
            // labelSelectedBarcode
            // 
            this.labelSelectedBarcode.AutoSize = true;
            this.labelSelectedBarcode.Location = new System.Drawing.Point(6, 214);
            this.labelSelectedBarcode.Name = "labelSelectedBarcode";
            this.labelSelectedBarcode.Size = new System.Drawing.Size(0, 13);
            this.labelSelectedBarcode.TabIndex = 88;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(169, 12);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 82;
            this.buttonSearch.Text = "Stok Ara";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 87;
            this.label2.Text = "_Adet";
            // 
            // buttonProductAdd
            // 
            this.buttonProductAdd.Location = new System.Drawing.Point(274, 205);
            this.buttonProductAdd.Name = "buttonProductAdd";
            this.buttonProductAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonProductAdd.TabIndex = 82;
            this.buttonProductAdd.Text = "Ekle";
            this.buttonProductAdd.UseVisualStyleBackColor = true;
            this.buttonProductAdd.Click += new System.EventHandler(this.buttonProductAdd_Click);
            // 
            // textBoxProductSearch
            // 
            this.textBoxProductSearch.Location = new System.Drawing.Point(6, 15);
            this.textBoxProductSearch.Name = "textBoxProductSearch";
            this.textBoxProductSearch.Size = new System.Drawing.Size(128, 20);
            this.textBoxProductSearch.TabIndex = 86;
            // 
            // textBoxAdet
            // 
            this.textBoxAdet.Location = new System.Drawing.Point(84, 207);
            this.textBoxAdet.Name = "textBoxAdet";
            this.textBoxAdet.Size = new System.Drawing.Size(67, 20);
            this.textBoxAdet.TabIndex = 83;
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(257, 24);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(106, 21);
            this.comboBoxType.TabIndex = 92;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // buttonTreeEdit
            // 
            this.buttonTreeEdit.Location = new System.Drawing.Point(6, 372);
            this.buttonTreeEdit.Name = "buttonTreeEdit";
            this.buttonTreeEdit.Size = new System.Drawing.Size(100, 23);
            this.buttonTreeEdit.TabIndex = 90;
            this.buttonTreeEdit.Text = "Seçileni Düzenle";
            this.buttonTreeEdit.UseVisualStyleBackColor = true;
            this.buttonTreeEdit.Click += new System.EventHandler(this.buttonTreeEdit_Click);
            // 
            // FormEditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 430);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.labelBarkodNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxKdv);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.checkBoxArchived);
            this.Controls.Add(this.dataGridViewBrand);
            this.Controls.Add(this.dataGridViewNames);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxBrand);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxModel);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label4454);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEditProduct";
            this.Text = "Ürün Düzenleme";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormEditProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBrand)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4454;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxBrand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewNames;
        private System.Windows.Forms.DataGridView dataGridViewBrand;
        private System.Windows.Forms.TextBox textBoxModel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxArchived;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxKdv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelBarkodNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewProductSelect;
        private System.Windows.Forms.Button buttonProductDelete;
        private System.Windows.Forms.DataGridView dataGridViewTree;
        private System.Windows.Forms.Label labelSelectedBarcode;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonProductAdd;
        private System.Windows.Forms.TextBox textBoxProductSearch;
        private System.Windows.Forms.TextBox textBoxAdet;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Button buttonTreeEdit;
    }
}