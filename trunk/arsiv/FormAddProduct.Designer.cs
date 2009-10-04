namespace arsiv
{
    partial class FormAddProduct
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
            this.textBoxBarcodeNo = new System.Windows.Forms.TextBox();
            this.labelBarcodeNo = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBrand)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxBarcodeNo
            // 
            this.textBoxBarcodeNo.Location = new System.Drawing.Point(86, 25);
            this.textBoxBarcodeNo.MaxLength = 12;
            this.textBoxBarcodeNo.Name = "textBoxBarcodeNo";
            this.textBoxBarcodeNo.Size = new System.Drawing.Size(100, 20);
            this.textBoxBarcodeNo.TabIndex = 0;
            // 
            // labelBarcodeNo
            // 
            this.labelBarcodeNo.AutoSize = true;
            this.labelBarcodeNo.Location = new System.Drawing.Point(19, 28);
            this.labelBarcodeNo.Name = "labelBarcodeNo";
            this.labelBarcodeNo.Size = new System.Drawing.Size(61, 13);
            this.labelBarcodeNo.TabIndex = 1;
            this.labelBarcodeNo.Text = "Barkod No:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(86, 51);
            this.textBoxName.MaxLength = 50;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 0;
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
            this.textBoxBrand.Location = new System.Drawing.Point(86, 216);
            this.textBoxBrand.MaxLength = 50;
            this.textBoxBrand.Name = "textBoxBrand";
            this.textBoxBrand.Size = new System.Drawing.Size(100, 20);
            this.textBoxBrand.TabIndex = 0;
            this.textBoxBrand.TextChanged += new System.EventHandler(this.textBoxBrand_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Marka:";
            // 
            // dataGridViewNames
            // 
            this.dataGridViewNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNames.Location = new System.Drawing.Point(201, 51);
            this.dataGridViewNames.Name = "dataGridViewNames";
            this.dataGridViewNames.Size = new System.Drawing.Size(240, 150);
            this.dataGridViewNames.TabIndex = 2;
            this.dataGridViewNames.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNames_CellContentDoubleClick);
            // 
            // dataGridViewBrand
            // 
            this.dataGridViewBrand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBrand.Location = new System.Drawing.Point(201, 216);
            this.dataGridViewBrand.Name = "dataGridViewBrand";
            this.dataGridViewBrand.Size = new System.Drawing.Size(240, 150);
            this.dataGridViewBrand.TabIndex = 3;
            this.dataGridViewBrand.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBrand_CellContentDoubleClick);
            // 
            // textBoxModel
            // 
            this.textBoxModel.Location = new System.Drawing.Point(86, 379);
            this.textBoxModel.MaxLength = 50;
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(100, 20);
            this.textBoxModel.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Model:";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(86, 418);
            this.textBoxPrice.MaxLength = 100;
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrice.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 421);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Fiyat:";
            // 
            // checkBoxArchived
            // 
            this.checkBoxArchived.AutoSize = true;
            this.checkBoxArchived.Location = new System.Drawing.Point(31, 456);
            this.checkBoxArchived.Name = "checkBoxArchived";
            this.checkBoxArchived.Size = new System.Drawing.Size(87, 17);
            this.checkBoxArchived.TabIndex = 4;
            this.checkBoxArchived.Text = "Arşivlenecek";
            this.checkBoxArchived.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(316, 475);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(39, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "İptal";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(366, 434);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 64);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Kaydet";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxKdv
            // 
            this.textBoxKdv.Location = new System.Drawing.Point(261, 418);
            this.textBoxKdv.MaxLength = 3;
            this.textBoxKdv.Name = "textBoxKdv";
            this.textBoxKdv.Size = new System.Drawing.Size(81, 20);
            this.textBoxKdv.TabIndex = 7;
            this.textBoxKdv.Text = "18";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 425);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Kdv:";
            // 
            // FormAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 510);
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
            this.Controls.Add(this.labelBarcodeNo);
            this.Controls.Add(this.textBoxBarcodeNo);
            this.Name = "FormAddProduct";
            this.Text = "FormAddProduct";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBrand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBarcodeNo;
        private System.Windows.Forms.Label labelBarcodeNo;
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
    }
}