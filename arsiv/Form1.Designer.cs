namespace arsiv
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelPage = new System.Windows.Forms.Label();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateBaslangic = new System.Windows.Forms.DateTimePicker();
            this.dateBitis = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.checkedListBoxDepartment = new System.Windows.Forms.CheckedListBox();
            this.buttonNewRecord = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripRapor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.stokGirişiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokÇıkışıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokDurumuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonGider = new System.Windows.Forms.ToolStripButton();
            this.buttonPageBacward = new System.Windows.Forms.Button();
            this.buttonPageForward = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewResult = new System.Windows.Forms.DataGridView();
            this.comboBoxPageLimit = new System.Windows.Forms.ComboBox();
            this.groupBoxSearch.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPage
            // 
            this.labelPage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(829, 688);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(0, 13);
            this.labelPage.TabIndex = 10;
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSearch.Controls.Add(this.label3);
            this.groupBoxSearch.Controls.Add(this.dateBaslangic);
            this.groupBoxSearch.Controls.Add(this.dateBitis);
            this.groupBoxSearch.Controls.Add(this.label2);
            this.groupBoxSearch.Controls.Add(this.comboBoxCategory);
            this.groupBoxSearch.Controls.Add(this.labelStatus);
            this.groupBoxSearch.Controls.Add(this.textBoxValue);
            this.groupBoxSearch.Controls.Add(this.buttonSearch);
            this.groupBoxSearch.Controls.Add(this.checkedListBoxDepartment);
            this.groupBoxSearch.Location = new System.Drawing.Point(12, 28);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(984, 89);
            this.groupBoxSearch.TabIndex = 14;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Arama";
            this.groupBoxSearch.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(405, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Tarih";
            // 
            // dateBaslangic
            // 
            this.dateBaslangic.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBaslangic.Location = new System.Drawing.Point(452, 46);
            this.dateBaslangic.Name = "dateBaslangic";
            this.dateBaslangic.Size = new System.Drawing.Size(93, 20);
            this.dateBaslangic.TabIndex = 19;
            this.dateBaslangic.Value = new System.DateTime(1996, 1, 1, 0, 0, 0, 0);
            // 
            // dateBitis
            // 
            this.dateBitis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBitis.Location = new System.Drawing.Point(551, 47);
            this.dateBitis.Name = "dateBitis";
            this.dateBitis.Size = new System.Drawing.Size(93, 20);
            this.dateBitis.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Aranan";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(452, 19);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCategory.TabIndex = 14;
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(3, 50);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(350, 13);
            this.labelStatus.TabIndex = 16;
            this.labelStatus.Text = "Bir arşiv numarası, isim veya telefon numarası giriniz ve ara tuşuna basınız";
            // 
            // textBoxValue
            // 
            this.textBoxValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxValue.Location = new System.Drawing.Point(6, 22);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(281, 20);
            this.textBoxValue.TabIndex = 12;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonSearch.Location = new System.Drawing.Point(293, 20);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 13;
            this.buttonSearch.Text = "Ara";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click_1);
            // 
            // checkedListBoxDepartment
            // 
            this.checkedListBoxDepartment.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkedListBoxDepartment.FormattingEnabled = true;
            this.checkedListBoxDepartment.Location = new System.Drawing.Point(746, 19);
            this.checkedListBoxDepartment.Name = "checkedListBoxDepartment";
            this.checkedListBoxDepartment.Size = new System.Drawing.Size(125, 64);
            this.checkedListBoxDepartment.TabIndex = 15;
            // 
            // buttonNewRecord
            // 
            this.buttonNewRecord.Name = "buttonNewRecord";
            this.buttonNewRecord.Size = new System.Drawing.Size(63, 22);
            this.buttonNewRecord.Text = "&Yeni Kayıt";
            this.buttonNewRecord.Click += new System.EventHandler(this.buttonNewRecord_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonNewRecord,
            this.tsbtnSearch,
            this.toolStripRapor,
            this.toolStripSeparator1,
            this.toolStripAbout,
            this.toolStripButton1,
            this.toolStripButtonGider});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnSearch
            // 
            this.tsbtnSearch.Name = "tsbtnSearch";
            this.tsbtnSearch.Size = new System.Drawing.Size(46, 22);
            this.tsbtnSearch.Text = "Arama";
            this.tsbtnSearch.Click += new System.EventHandler(this.tsbtnSearch_Click);
            // 
            // toolStripRapor
            // 
            this.toolStripRapor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripRapor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRapor.Image")));
            this.toolStripRapor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRapor.Name = "toolStripRapor";
            this.toolStripRapor.Size = new System.Drawing.Size(42, 22);
            this.toolStripRapor.Text = "Rapor";
            this.toolStripRapor.Click += new System.EventHandler(this.toolStripRapor_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripAbout
            // 
            this.toolStripAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripAbout.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAbout.Image")));
            this.toolStripAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAbout.Name = "toolStripAbout";
            this.toolStripAbout.Size = new System.Drawing.Size(61, 22);
            this.toolStripAbout.Text = "Hakkında";
            this.toolStripAbout.Click += new System.EventHandler(this.toolStripAbout_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stokGirişiToolStripMenuItem,
            this.stokÇıkışıToolStripMenuItem,
            this.stokDurumuToolStripMenuItem});
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(43, 22);
            this.toolStripButton1.Text = "Stok";
            // 
            // stokGirişiToolStripMenuItem
            // 
            this.stokGirişiToolStripMenuItem.Name = "stokGirişiToolStripMenuItem";
            this.stokGirişiToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.stokGirişiToolStripMenuItem.Text = "Stok Girişi";
            this.stokGirişiToolStripMenuItem.Click += new System.EventHandler(this.stokGirişiToolStripMenuItem_Click);
            // 
            // stokÇıkışıToolStripMenuItem
            // 
            this.stokÇıkışıToolStripMenuItem.Name = "stokÇıkışıToolStripMenuItem";
            this.stokÇıkışıToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.stokÇıkışıToolStripMenuItem.Text = "Stok Çıkışı";
            // 
            // stokDurumuToolStripMenuItem
            // 
            this.stokDurumuToolStripMenuItem.Name = "stokDurumuToolStripMenuItem";
            this.stokDurumuToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.stokDurumuToolStripMenuItem.Text = "Stok Durumu";
            // 
            // toolStripButtonGider
            // 
            this.toolStripButtonGider.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonGider.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonGider.Image")));
            this.toolStripButtonGider.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGider.Name = "toolStripButtonGider";
            this.toolStripButtonGider.Size = new System.Drawing.Size(39, 22);
            this.toolStripButtonGider.Text = "Gider";
            // 
            // buttonPageBacward
            // 
            this.buttonPageBacward.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonPageBacward.Location = new System.Drawing.Point(878, 682);
            this.buttonPageBacward.Name = "buttonPageBacward";
            this.buttonPageBacward.Size = new System.Drawing.Size(54, 23);
            this.buttonPageBacward.TabIndex = 18;
            this.buttonPageBacward.Text = "<";
            this.buttonPageBacward.UseVisualStyleBackColor = true;
            this.buttonPageBacward.Click += new System.EventHandler(this.buttonPageBacward_Click);
            // 
            // buttonPageForward
            // 
            this.buttonPageForward.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonPageForward.Location = new System.Drawing.Point(933, 682);
            this.buttonPageForward.Name = "buttonPageForward";
            this.buttonPageForward.Size = new System.Drawing.Size(54, 23);
            this.buttonPageForward.TabIndex = 19;
            this.buttonPageForward.Text = ">";
            this.buttonPageForward.UseVisualStyleBackColor = true;
            this.buttonPageForward.Click += new System.EventHandler(this.buttonPageForward_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 687);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "_Adet listele";
            // 
            // dataGridViewResult
            // 
            this.dataGridViewResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewResult.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResult.Location = new System.Drawing.Point(12, 28);
            this.dataGridViewResult.MultiSelect = false;
            this.dataGridViewResult.Name = "dataGridViewResult";
            this.dataGridViewResult.ReadOnly = true;
            this.dataGridViewResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewResult.Size = new System.Drawing.Size(984, 650);
            this.dataGridViewResult.TabIndex = 17;
            this.dataGridViewResult.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewResult_CellDoubleClick);
            this.dataGridViewResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewResult_CellClick);
            this.dataGridViewResult.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridViewResult_KeyPress);
            // 
            // comboBoxPageLimit
            // 
            this.comboBoxPageLimit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxPageLimit.FormattingEnabled = true;
            this.comboBoxPageLimit.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.comboBoxPageLimit.Location = new System.Drawing.Point(17, 684);
            this.comboBoxPageLimit.Name = "comboBoxPageLimit";
            this.comboBoxPageLimit.Size = new System.Drawing.Size(63, 21);
            this.comboBoxPageLimit.TabIndex = 20;
            this.comboBoxPageLimit.SelectedValueChanged += new System.EventHandler(this.comboBoxPageLimit_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 717);
            this.Controls.Add(this.buttonPageBacward);
            this.Controls.Add(this.buttonPageForward);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewResult);
            this.Controls.Add(this.comboBoxPageLimit);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBoxSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barış Görsel Arşiv  (ALPHA) - Bar&Bar Data";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void tsbtnSearch_Click(object sender, System.EventArgs e)
        {

            if (tsbtnSearch.Checked == true)
            {
                groupBoxSearch.Visible = false;
                tsbtnSearch.Checked = false;
                isSearch = false;
                
                makeSearch();
                labelStatus.Text = "";
                dataGridViewResult.Location = new System.Drawing.Point(12, 50);
                dataGridViewResult.Size = new System.Drawing.Size(984, 630);
                dataGridViewResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                
                
            }
            else
            {
                comboBoxCategory.SelectedIndex = 0;
                tsbtnSearch.Checked = true;
                groupBoxSearch.Visible = true;
                if (comboBoxCategory.SelectedItem == null)
                    comboBoxCategory.SelectedIndex = 0;
                dataGridViewResult.Location = new System.Drawing.Point(12, 120);
                dataGridViewResult.Size = new System.Drawing.Size(984, 560);
                dataGridViewResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            }
        }

        #endregion

        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.ToolStripButton buttonNewRecord;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnSearch;
        private System.Windows.Forms.Button buttonPageBacward;
        private System.Windows.Forms.Button buttonPageForward;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewResult;
        private System.Windows.Forms.ComboBox comboBoxPageLimit;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.CheckedListBox checkedListBoxDepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateBaslangic;
        private System.Windows.Forms.DateTimePicker dateBitis;
        private System.Windows.Forms.ToolStripButton toolStripRapor;
        private System.Windows.Forms.ToolStripButton toolStripAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem stokGirişiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokÇıkışıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokDurumuToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonGider;
    }
}

