namespace arsiv
{
    partial class FormEnterance
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
            this.comboBoxSubeListe = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.comboBoxConnection = new System.Windows.Forms.ComboBox();
            this.labelConnection = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxSubeListe
            // 
            this.comboBoxSubeListe.FormattingEnabled = true;
            this.comboBoxSubeListe.Location = new System.Drawing.Point(104, 102);
            this.comboBoxSubeListe.Name = "comboBoxSubeListe";
            this.comboBoxSubeListe.Size = new System.Drawing.Size(95, 21);
            this.comboBoxSubeListe.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Şube:";
            // 
            // buttonEnter
            // 
            this.buttonEnter.Location = new System.Drawing.Point(242, 99);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(75, 23);
            this.buttonEnter.TabIndex = 2;
            this.buttonEnter.Text = "Giriş";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // comboBoxConnection
            // 
            this.comboBoxConnection.FormattingEnabled = true;
            this.comboBoxConnection.Location = new System.Drawing.Point(104, 71);
            this.comboBoxConnection.Name = "comboBoxConnection";
            this.comboBoxConnection.Size = new System.Drawing.Size(95, 21);
            this.comboBoxConnection.TabIndex = 3;
            // 
            // labelConnection
            // 
            this.labelConnection.AutoSize = true;
            this.labelConnection.Location = new System.Drawing.Point(50, 74);
            this.labelConnection.Name = "labelConnection";
            this.labelConnection.Size = new System.Drawing.Size(48, 13);
            this.labelConnection.TabIndex = 4;
            this.labelConnection.Text = "Bağlantı:";
            // 
            // FormEnterance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 210);
            this.Controls.Add(this.labelConnection);
            this.Controls.Add(this.comboBoxConnection);
            this.Controls.Add(this.buttonEnter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSubeListe);
            this.Name = "FormEnterance";
            this.Text = "FormEnterance";
            this.Load += new System.EventHandler(this.FormEnterance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSubeListe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.ComboBox comboBoxConnection;
        private System.Windows.Forms.Label labelConnection;
    }
}