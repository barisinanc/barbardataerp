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
            this.buttonNewRecord = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnSearch = new System.Windows.Forms.ToolStripButton();
            this.buttonPageBacward = new System.Windows.Forms.Button();
            this.buttonPageForward = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewResult = new System.Windows.Forms.DataGridView();
            this.comboBoxPageLimit = new System.Windows.Forms.ComboBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.checkedListBoxDepartment = new System.Windows.Forms.CheckedListBox();
            this.groupBoxSearch.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPage
            // 
            this.labelPage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(631, 292);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(0, 13);
            this.labelPage.TabIndex = 10;
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSearch.Controls.Add(this.comboBoxCategory);
            this.groupBoxSearch.Controls.Add(this.labelStatus);
            this.groupBoxSearch.Controls.Add(this.textBoxValue);
            this.groupBoxSearch.Controls.Add(this.buttonSearch);
            this.groupBoxSearch.Controls.Add(this.checkedListBoxDepartment);
            this.groupBoxSearch.Controls.Add(this.labelPage);
            this.groupBoxSearch.Location = new System.Drawing.Point(12, 50);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(959, 101);
            this.groupBoxSearch.TabIndex = 14;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Arama";
            this.groupBoxSearch.Visible = false;
            // 
            // buttonNewRecord
            // 
            this.buttonNewRecord.Name = "buttonNewRecord";
            this.buttonNewRecord.Size = new System.Drawing.Size(77, 24);
            this.buttonNewRecord.Text = "&Yeni Kayıt";
            this.buttonNewRecord.Click += new System.EventHandler(this.buttonNewRecord_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonNewRecord, this.tsbtnSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(983, 25);
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
            // buttonPageBacward
            // 
            this.buttonPageBacward.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonPageBacward.Location = new System.Drawing.Point(848, 616);
            this.buttonPageBacward.Name = "buttonPageBacward";
            this.buttonPageBacward.Size = new System.Drawing.Size(54, 23);
            this.buttonPageBacward.TabIndex = 18;
            this.buttonPageBacward.Text = "<";
            this.buttonPageBacward.UseVisualStyleBackColor = true;
            // 
            // buttonPageForward
            // 
            this.buttonPageForward.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonPageForward.Location = new System.Drawing.Point(903, 616);
            this.buttonPageForward.Name = "buttonPageForward";
            this.buttonPageForward.Size = new System.Drawing.Size(54, 23);
            this.buttonPageForward.TabIndex = 19;
            this.buttonPageForward.Text = ">";
            this.buttonPageForward.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 621);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Adet listele";
            // 
            // dataGridViewResult
            // 
            this.dataGridViewResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResult.Location = new System.Drawing.Point(12, 50);
            this.dataGridViewResult.Name = "dataGridViewResult";
            this.dataGridViewResult.Size = new System.Drawing.Size(959, 553);
            this.dataGridViewResult.TabIndex = 17;
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
            this.comboBoxPageLimit.Location = new System.Drawing.Point(12, 618);
            this.comboBoxPageLimit.Name = "comboBoxPageLimit";
            this.comboBoxPageLimit.Size = new System.Drawing.Size(63, 21);
            this.comboBoxPageLimit.TabIndex = 20;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(478, 13);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCategory.TabIndex = 14;
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(13, 74);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(350, 13);
            this.labelStatus.TabIndex = 16;
            this.labelStatus.Text = "Bir arşiv numarası, isim veya telefon numarası giriniz ve ara tuşuna basınız";
            // 
            // textBoxValue
            // 
            this.textBoxValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxValue.Location = new System.Drawing.Point(16, 48);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(281, 20);
            this.textBoxValue.TabIndex = 12;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonSearch.Location = new System.Drawing.Point(303, 48);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 13;
            this.buttonSearch.Text = "Ara";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxDepartment
            // 
            this.checkedListBoxDepartment.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkedListBoxDepartment.FormattingEnabled = true;
            this.checkedListBoxDepartment.Location = new System.Drawing.Point(822, 38);
            this.checkedListBoxDepartment.Name = "checkedListBoxDepartment";
            this.checkedListBoxDepartment.Size = new System.Drawing.Size(123, 49);
            this.checkedListBoxDepartment.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 656);
            this.Controls.Add(this.buttonPageBacward);
            this.Controls.Add(this.buttonPageForward);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewResult);
            this.Controls.Add(this.comboBoxPageLimit);
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
                dataGridViewResult.Location = new System.Drawing.Point(12, 50);
                dataGridViewResult.Size = new System.Drawing.Size(959, 553);
            }
            else
            {
                tsbtnSearch.Checked = true;
                groupBoxSearch.Visible = true;
                dataGridViewResult.Location = new System.Drawing.Point(12, 160);
                dataGridViewResult.Size = new System.Drawing.Size(959, 443);
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
    }
}

