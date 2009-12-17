namespace familytree
{
    partial class Insert
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
            this.textBoxIsim = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSoyisim = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.datebirthdate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxMotherFather = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxCouple = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxDeath = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonAddPhoto = new System.Windows.Forms.Button();
            this.comboBoxSex = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxIsim
            // 
            this.textBoxIsim.Location = new System.Drawing.Point(94, 6);
            this.textBoxIsim.Name = "textBoxIsim";
            this.textBoxIsim.Size = new System.Drawing.Size(100, 20);
            this.textBoxIsim.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "İsim";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Soyisim";
            // 
            // textBoxSoyisim
            // 
            this.textBoxSoyisim.Location = new System.Drawing.Point(94, 32);
            this.textBoxSoyisim.Name = "textBoxSoyisim";
            this.textBoxSoyisim.Size = new System.Drawing.Size(100, 20);
            this.textBoxSoyisim.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Doğum Tarihi";
            // 
            // datebirthdate
            // 
            this.datebirthdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datebirthdate.Location = new System.Drawing.Point(94, 55);
            this.datebirthdate.Name = "datebirthdate";
            this.datebirthdate.Size = new System.Drawing.Size(100, 20);
            this.datebirthdate.TabIndex = 4;
            // 
            // comboBoxMotherFather
            // 
            this.comboBoxMotherFather.FormattingEnabled = true;
            this.comboBoxMotherFather.Location = new System.Drawing.Point(94, 82);
            this.comboBoxMotherFather.Name = "comboBoxMotherFather";
            this.comboBoxMotherFather.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMotherFather.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Anne/Baba";
            // 
            // comboBoxCouple
            // 
            this.comboBoxCouple.FormattingEnabled = true;
            this.comboBoxCouple.Location = new System.Drawing.Point(94, 109);
            this.comboBoxCouple.Name = "comboBoxCouple";
            this.comboBoxCouple.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCouple.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Eş Durumu";
            // 
            // comboBoxDeath
            // 
            this.comboBoxDeath.FormattingEnabled = true;
            this.comboBoxDeath.Location = new System.Drawing.Point(94, 136);
            this.comboBoxDeath.Name = "comboBoxDeath";
            this.comboBoxDeath.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDeath.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Sağ/Ölü";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonAddPhoto
            // 
            this.buttonAddPhoto.Location = new System.Drawing.Point(327, 107);
            this.buttonAddPhoto.Name = "buttonAddPhoto";
            this.buttonAddPhoto.Size = new System.Drawing.Size(79, 23);
            this.buttonAddPhoto.TabIndex = 7;
            this.buttonAddPhoto.Text = "Fotoğraf Ekle";
            this.buttonAddPhoto.UseVisualStyleBackColor = true;
            // 
            // comboBoxSex
            // 
            this.comboBoxSex.FormattingEnabled = true;
            this.comboBoxSex.Location = new System.Drawing.Point(94, 163);
            this.comboBoxSex.Name = "comboBoxSex";
            this.comboBoxSex.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSex.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Cinsiyet";
            // 
            // pictureBoxPhoto
            // 
            this.pictureBoxPhoto.Location = new System.Drawing.Point(327, 12);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(79, 89);
            this.pictureBoxPhoto.TabIndex = 8;
            this.pictureBoxPhoto.TabStop = false;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(327, 161);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "Ekle";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // Insert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 204);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.pictureBoxPhoto);
            this.Controls.Add(this.buttonAddPhoto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxSex);
            this.Controls.Add(this.comboBoxDeath);
            this.Controls.Add(this.comboBoxCouple);
            this.Controls.Add(this.comboBoxMotherFather);
            this.Controls.Add(this.datebirthdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSoyisim);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxIsim);
            this.Name = "Insert";
            this.Text = "Kişi Ekleme";
            this.Load += new System.EventHandler(this.Insert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIsim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSoyisim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datebirthdate;
        private System.Windows.Forms.ComboBox comboBoxMotherFather;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxCouple;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxDeath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonAddPhoto;
        private System.Windows.Forms.ComboBox comboBoxSex;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBoxPhoto;
        private System.Windows.Forms.Button buttonAdd;
    }
}