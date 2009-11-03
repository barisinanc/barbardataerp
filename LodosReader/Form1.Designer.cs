namespace binaryreader
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
            this.checkedListBoxListe = new System.Windows.Forms.CheckedListBox();
            this.progressBarStatus = new System.Windows.Forms.ProgressBar();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.listBoxStatus = new System.Windows.Forms.ListBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.buttonPath = new System.Windows.Forms.Button();
            this.folderBrowserDialogPath = new System.Windows.Forms.FolderBrowserDialog();
            this.comboBoxListe = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.comboBoxSube = new System.Windows.Forms.ComboBox();
            this.textBoxDataSource = new System.Windows.Forms.TextBox();
            this.groupBoxVeritabani = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDataCatalog = new System.Windows.Forms.TextBox();
            this.textBoxDataUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDataPassword = new System.Windows.Forms.MaskedTextBox();
            this.checkBoxDataIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxVeritabani.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBoxListe
            // 
            this.checkedListBoxListe.FormattingEnabled = true;
            this.checkedListBoxListe.Location = new System.Drawing.Point(9, 169);
            this.checkedListBoxListe.Name = "checkedListBoxListe";
            this.checkedListBoxListe.Size = new System.Drawing.Size(116, 244);
            this.checkedListBoxListe.TabIndex = 0;
            this.checkedListBoxListe.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxListe_SelectedIndexChanged);
            this.checkedListBoxListe.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxListe_ItemCheck);
            // 
            // progressBarStatus
            // 
            this.progressBarStatus.Location = new System.Drawing.Point(144, 169);
            this.progressBarStatus.Name = "progressBarStatus";
            this.progressBarStatus.Size = new System.Drawing.Size(322, 23);
            this.progressBarStatus.TabIndex = 1;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(143, 420);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(131, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Başlat";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(335, 417);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(131, 23);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "Durdur";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // listBoxStatus
            // 
            this.listBoxStatus.FormattingEnabled = true;
            this.listBoxStatus.Location = new System.Drawing.Point(144, 212);
            this.listBoxStatus.Name = "listBoxStatus";
            this.listBoxStatus.Size = new System.Drawing.Size(322, 199);
            this.listBoxStatus.TabIndex = 5;
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(141, 145);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(184, 13);
            this.labelPath.TabIndex = 6;
            this.labelPath.Text = "Lütfen asistan data klasörünü seçiniz.";
            // 
            // buttonPath
            // 
            this.buttonPath.Location = new System.Drawing.Point(9, 140);
            this.buttonPath.Name = "buttonPath";
            this.buttonPath.Size = new System.Drawing.Size(116, 23);
            this.buttonPath.TabIndex = 7;
            this.buttonPath.Text = "Asistan Data Seç";
            this.buttonPath.UseVisualStyleBackColor = true;
            this.buttonPath.Click += new System.EventHandler(this.buttonPath_Click);
            // 
            // folderBrowserDialogPath
            // 
            this.folderBrowserDialogPath.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // comboBoxListe
            // 
            this.comboBoxListe.FormattingEnabled = true;
            this.comboBoxListe.Location = new System.Drawing.Point(9, 422);
            this.comboBoxListe.Name = "comboBoxListe";
            this.comboBoxListe.Size = new System.Drawing.Size(116, 21);
            this.comboBoxListe.TabIndex = 8;
            this.comboBoxListe.SelectedIndexChanged += new System.EventHandler(this.comboBoxListe_SelectedIndexChanged);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(144, 197);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 13);
            this.labelStatus.TabIndex = 9;
            // 
            // comboBoxSube
            // 
            this.comboBoxSube.FormattingEnabled = true;
            this.comboBoxSube.Location = new System.Drawing.Point(380, 113);
            this.comboBoxSube.Name = "comboBoxSube";
            this.comboBoxSube.Size = new System.Drawing.Size(86, 21);
            this.comboBoxSube.TabIndex = 10;
            this.comboBoxSube.SelectedIndexChanged += new System.EventHandler(this.comboBoxSube_SelectedIndexChanged);
            // 
            // textBoxDataSource
            // 
            this.textBoxDataSource.Location = new System.Drawing.Point(84, 18);
            this.textBoxDataSource.Name = "textBoxDataSource";
            this.textBoxDataSource.Size = new System.Drawing.Size(94, 20);
            this.textBoxDataSource.TabIndex = 11;
            this.textBoxDataSource.Text = ".\\SQLEXPRESS";
            // 
            // groupBoxVeritabani
            // 
            this.groupBoxVeritabani.Controls.Add(this.buttonConnect);
            this.groupBoxVeritabani.Controls.Add(this.checkBoxDataIntegratedSecurity);
            this.groupBoxVeritabani.Controls.Add(this.textBoxDataPassword);
            this.groupBoxVeritabani.Controls.Add(this.label4);
            this.groupBoxVeritabani.Controls.Add(this.label3);
            this.groupBoxVeritabani.Controls.Add(this.textBoxDataUser);
            this.groupBoxVeritabani.Controls.Add(this.textBoxDataCatalog);
            this.groupBoxVeritabani.Controls.Add(this.label2);
            this.groupBoxVeritabani.Controls.Add(this.label1);
            this.groupBoxVeritabani.Controls.Add(this.textBoxDataSource);
            this.groupBoxVeritabani.Location = new System.Drawing.Point(12, 8);
            this.groupBoxVeritabani.Name = "groupBoxVeritabani";
            this.groupBoxVeritabani.Size = new System.Drawing.Size(319, 126);
            this.groupBoxVeritabani.TabIndex = 12;
            this.groupBoxVeritabani.TabStop = false;
            this.groupBoxVeritabani.Text = "Veritabanı Ayarları";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Data Source=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Initial Catalog=";
            // 
            // textBoxDataCatalog
            // 
            this.textBoxDataCatalog.Location = new System.Drawing.Point(84, 44);
            this.textBoxDataCatalog.Name = "textBoxDataCatalog";
            this.textBoxDataCatalog.Size = new System.Drawing.Size(94, 20);
            this.textBoxDataCatalog.TabIndex = 14;
            this.textBoxDataCatalog.Text = "Arsiv";
            // 
            // textBoxDataUser
            // 
            this.textBoxDataUser.Location = new System.Drawing.Point(84, 71);
            this.textBoxDataUser.Name = "textBoxDataUser";
            this.textBoxDataUser.Size = new System.Drawing.Size(94, 20);
            this.textBoxDataUser.TabIndex = 15;
            this.textBoxDataUser.Text = "sa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "User Id=";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Password=";
            // 
            // textBoxDataPassword
            // 
            this.textBoxDataPassword.Location = new System.Drawing.Point(84, 97);
            this.textBoxDataPassword.Name = "textBoxDataPassword";
            this.textBoxDataPassword.PasswordChar = '*';
            this.textBoxDataPassword.Size = new System.Drawing.Size(94, 20);
            this.textBoxDataPassword.TabIndex = 18;
            // 
            // checkBoxDataIntegratedSecurity
            // 
            this.checkBoxDataIntegratedSecurity.AutoSize = true;
            this.checkBoxDataIntegratedSecurity.Checked = true;
            this.checkBoxDataIntegratedSecurity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDataIntegratedSecurity.Location = new System.Drawing.Point(198, 72);
            this.checkBoxDataIntegratedSecurity.Name = "checkBoxDataIntegratedSecurity";
            this.checkBoxDataIntegratedSecurity.Size = new System.Drawing.Size(115, 17);
            this.checkBoxDataIntegratedSecurity.TabIndex = 19;
            this.checkBoxDataIntegratedSecurity.Text = "Integrated Security";
            this.checkBoxDataIntegratedSecurity.UseVisualStyleBackColor = true;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(198, 94);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(115, 23);
            this.buttonConnect.TabIndex = 20;
            this.buttonConnect.Text = "Bağlan";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(350, 12);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(116, 87);
            this.buttonAbout.TabIndex = 13;
            this.buttonAbout.Text = "Hakkında";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Şube";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 456);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.comboBoxSube);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.comboBoxListe);
            this.Controls.Add(this.buttonPath);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.listBoxStatus);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.progressBarStatus);
            this.Controls.Add(this.checkedListBoxListe);
            this.Controls.Add(this.groupBoxVeritabani);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Veri Eşitleyici - Bar&Bar Data";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxVeritabani.ResumeLayout(false);
            this.groupBoxVeritabani.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxListe;
        private System.Windows.Forms.ProgressBar progressBarStatus;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ListBox listBoxStatus;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Button buttonPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogPath;
        private System.Windows.Forms.ComboBox comboBoxListe;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox comboBoxSube;
        private System.Windows.Forms.TextBox textBoxDataSource;
        private System.Windows.Forms.GroupBox groupBoxVeritabani;
        private System.Windows.Forms.TextBox textBoxDataCatalog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox textBoxDataPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDataUser;
        private System.Windows.Forms.CheckBox checkBoxDataIntegratedSecurity;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Label label5;


    }
}

