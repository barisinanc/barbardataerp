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
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGridViewResult = new System.Windows.Forms.DataGridView();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.checkedListBoxDepartment = new System.Windows.Forms.CheckedListBox();
            this.labelPage = new System.Windows.Forms.Label();
            this.buttonPageForward = new System.Windows.Forms.Button();
            this.buttonPageBacward = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.comboBoxPageLimit = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.buttonNewRecord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).BeginInit();
            this.groupBoxSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxValue
            // 
            this.textBoxValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxValue.Location = new System.Drawing.Point(6, 19);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(281, 20);
            this.textBoxValue.TabIndex = 0;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonSearch.Location = new System.Drawing.Point(293, 19);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Ara";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // dataGridViewResult
            // 
            this.dataGridViewResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResult.Location = new System.Drawing.Point(6, 74);
            this.dataGridViewResult.Name = "dataGridViewResult";
            this.dataGridViewResult.Size = new System.Drawing.Size(947, 446);
            this.dataGridViewResult.TabIndex = 2;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(486, 19);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCategory.TabIndex = 3;
            // 
            // checkedListBoxDepartment
            // 
            this.checkedListBoxDepartment.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkedListBoxDepartment.FormattingEnabled = true;
            this.checkedListBoxDepartment.Location = new System.Drawing.Point(830, 19);
            this.checkedListBoxDepartment.Name = "checkedListBoxDepartment";
            this.checkedListBoxDepartment.Size = new System.Drawing.Size(123, 49);
            this.checkedListBoxDepartment.TabIndex = 4;
            // 
            // labelPage
            // 
            this.labelPage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(631, 538);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(0, 13);
            this.labelPage.TabIndex = 10;
            // 
            // buttonPageForward
            // 
            this.buttonPageForward.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonPageForward.Location = new System.Drawing.Point(897, 533);
            this.buttonPageForward.Name = "buttonPageForward";
            this.buttonPageForward.Size = new System.Drawing.Size(54, 23);
            this.buttonPageForward.TabIndex = 9;
            this.buttonPageForward.Text = ">";
            this.buttonPageForward.UseVisualStyleBackColor = true;
            this.buttonPageForward.Click += new System.EventHandler(this.buttonPageForward_Click);
            // 
            // buttonPageBacward
            // 
            this.buttonPageBacward.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonPageBacward.Location = new System.Drawing.Point(842, 533);
            this.buttonPageBacward.Name = "buttonPageBacward";
            this.buttonPageBacward.Size = new System.Drawing.Size(54, 23);
            this.buttonPageBacward.TabIndex = 8;
            this.buttonPageBacward.Text = "<";
            this.buttonPageBacward.UseVisualStyleBackColor = true;
            this.buttonPageBacward.Click += new System.EventHandler(this.buttonPageBacward_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(3, 45);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(350, 13);
            this.labelStatus.TabIndex = 11;
            this.labelStatus.Text = "Bir arşiv numarası, isim veya telefon numarası giriniz ve ara tuşuna basınız";
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
            this.comboBoxPageLimit.Location = new System.Drawing.Point(6, 535);
            this.comboBoxPageLimit.Name = "comboBoxPageLimit";
            this.comboBoxPageLimit.Size = new System.Drawing.Size(63, 21);
            this.comboBoxPageLimit.TabIndex = 12;
            this.comboBoxPageLimit.SelectedIndexChanged += new System.EventHandler(this.comboBoxPageLimit_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 538);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Adet listele";
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSearch.Controls.Add(this.buttonPageBacward);
            this.groupBoxSearch.Controls.Add(this.comboBoxCategory);
            this.groupBoxSearch.Controls.Add(this.buttonPageForward);
            this.groupBoxSearch.Controls.Add(this.labelStatus);
            this.groupBoxSearch.Controls.Add(this.textBoxValue);
            this.groupBoxSearch.Controls.Add(this.label1);
            this.groupBoxSearch.Controls.Add(this.dataGridViewResult);
            this.groupBoxSearch.Controls.Add(this.labelPage);
            this.groupBoxSearch.Controls.Add(this.comboBoxPageLimit);
            this.groupBoxSearch.Controls.Add(this.buttonSearch);
            this.groupBoxSearch.Controls.Add(this.checkedListBoxDepartment);
            this.groupBoxSearch.Location = new System.Drawing.Point(12, 50);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(959, 594);
            this.groupBoxSearch.TabIndex = 14;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Arama";
            // 
            // buttonNewRecord
            // 
            this.buttonNewRecord.Location = new System.Drawing.Point(12, 12);
            this.buttonNewRecord.Name = "buttonNewRecord";
            this.buttonNewRecord.Size = new System.Drawing.Size(287, 35);
            this.buttonNewRecord.TabIndex = 15;
            this.buttonNewRecord.Text = "&Yeni Kayıt";
            this.buttonNewRecord.UseVisualStyleBackColor = true;
            this.buttonNewRecord.Click += new System.EventHandler(this.buttonNewRecord_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 656);
            this.Controls.Add(this.buttonNewRecord);
            this.Controls.Add(this.groupBoxSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barış Görsel Arşiv  (ALPHA) - Bar&Bar Data";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).EndInit();
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dataGridViewResult;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.CheckedListBox checkedListBoxDepartment;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.Button buttonPageForward;
        private System.Windows.Forms.Button buttonPageBacward;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox comboBoxPageLimit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.Button buttonNewRecord;
    }
}

