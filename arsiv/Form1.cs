﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace arsiv
{
    public partial class Form1 : Form
    {
        public bool isSearch=false;
        public Form1()
        {
            InitializeComponent();
            
            comboBoxPageLimit.SelectedIndex = 0;

            BarisGorselDLL.Order engOrder = new BarisGorselDLL.Order();
            GuncelleGridMethod(dataGridViewResult, engOrder.getMainScreen(Properties.Settings.Default.SubeId, 1, 30));
            GuncelleMethod(labelPage, "1/" + ((engOrder.toplam / 20) + 1));
            if (page >= (engOrder.toplam / pageLimit))
                buttonPageForward.Enabled = false;
            if (page == 1)
                buttonPageBacward.Enabled = false;


        }

        int page = 1;

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            page = 1;
            search();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBoxValue.KeyPress += new KeyPressEventHandler(textBoxValue_KeyPress);
            
                loadForms();
            
            this.textBoxValue.Focus();
        }

        void textBoxValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                isSearch = true;
                search();
            }
        }

        public string tur;
        private void search()
        {
            pageLimit = Convert.ToInt32(comboBoxPageLimit.SelectedItem.ToString());
            tur = comboBoxCategory.SelectedItem.ToString();
            Thread aramaIslemi = new Thread(makeSearch);
            aramaIslemi.Start();
            
        }

        private void makeSearch()
        {
            if (isSearch)
            {
                GuncelleMethod(labelStatus, "Aranıyor...");

                BarisGorselDLL.Search archiveEng = new BarisGorselDLL.Search();
                if (textBoxValue.Text == null)
                    archiveEng.veri = "";
                else
                    archiveEng.veri = textBoxValue.Text;
                if (dateBaslangic.Text == null)
                    archiveEng.dateBaslangic = Convert.ToDateTime("01/01/1996");
                else
                    archiveEng.dateBaslangic = Convert.ToDateTime(dateBaslangic.Text);
                if (dateBitis.Text == null)
                    archiveEng.dateBitis = DateTime.Now;
                else
                    archiveEng.dateBitis = Convert.ToDateTime(dateBitis.Text).AddDays(1);
                archiveEng.page = page;

                
                archiveEng.tur = tur;//comboBoxCategory
                archiveEng.pageLimit = Convert.ToInt32(pageLimit);//comboBoxPageLimit
                string selectedDepartments = "";
                for (int i = 0; i < checkedListBoxDepartment.Items.Count; i++)
                {
                    if (checkedListBoxDepartment.GetItemChecked(i))
                    {
                        selectedDepartments += (i + 1) + ",";
                    }
                }
                archiveEng.selectedDepartments = selectedDepartments;
                GuncelleGridMethod(dataGridViewResult, archiveEng.ArsivArama());
                
                
                
                int devam = archiveEng.devam;
                int count = archiveEng.count;
                                if (page == 1)
                {
                    GuncelleButtonMethod(buttonPageBacward, false);
                }
                else
                { GuncelleButtonMethod(buttonPageBacward, true); }
                                
                if (devam == 0)
                {
                    GuncelleButtonMethod(buttonPageForward, false);
                }
                else
                {
                    GuncelleButtonMethod(buttonPageForward, true);
                }
                
                if ((count % pageLimit) == 0)
                { GuncelleMethod(labelPage, page + "/" + (count / pageLimit)); }
                else
                { GuncelleMethod(labelPage, page + "/" + ((count / pageLimit) + 1)); }
                GuncelleMethod(labelStatus, count + " adet kayıt bulundu!");
                
            }
            else 
            {
                BarisGorselDLL.Order engOrder = new BarisGorselDLL.Order();
                GuncelleGridMethod(dataGridViewResult, engOrder.getMainScreen(Properties.Settings.Default.SubeId, page, pageLimit));
                GuncelleMethod(labelPage, page + "/" + ((engOrder.toplam / pageLimit) + 1));
                if (page >= (engOrder.toplam / pageLimit))
                    buttonPageForward.Enabled = false;
                if (page == 1)
                    buttonPageBacward.Enabled = false;
            }
        }

        public delegate void GuncelleButton(Button button, bool state);

        public void GuncelleButtonMethod(Button button, bool state)
        {
            if (button.InvokeRequired)
            {
                GuncelleButton theDelegate = new GuncelleButton(GuncelleButtonMethod);
                this.Invoke(theDelegate, new object[] { button, state });
            }
            else
            {
                button.Enabled = state;
            }
        }

        public delegate void Guncelle(Label label, string text);

        public void GuncelleMethod(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                Guncelle theDelegate = new Guncelle(GuncelleMethod);
                this.Invoke(theDelegate, new object[] { label, text });
            }
            else
            {
                label.Text = text;
            }
        }

        public delegate void GuncelleGrid(DataGridView grid, DataTable table);

        public void GuncelleGridMethod(DataGridView grid, DataTable table)
        {
            if (grid.InvokeRequired)
            {
                GuncelleGrid theDelegate = new GuncelleGrid(GuncelleGridMethod);
                this.Invoke(theDelegate, new object[] { grid, table });
            }
            else
            {
                grid.DataSource = table;
            }
        }

        
        
        
        int pageLimit = 30;
        //List<>
        private void loadForms()
        {
            BarisGorselDLL.Search doldurEng = new BarisGorselDLL.Search();
            foreach (DataRow row in doldurEng.listeler().Rows)
            { comboBoxCategory.Items.Add(row[1]); }
            comboBoxCategory.Items.Add("Satış");
            comboBoxCategory.Items.Add("Ürün");
            comboBoxCategory.SelectedIndex = 0;
            foreach (DataRow row in doldurEng.subeler().Rows)
            { checkedListBoxDepartment.Items.Add(row[1]); }

            checkedListBoxDepartment.SetItemChecked(0,true);
            checkedListBoxDepartment.SetItemChecked(1, true);
            checkedListBoxDepartment.SetItemChecked(2, true);
            comboBoxPageLimit.SelectedItem = "30";
        }

        private void buttonPageBacward_Click(object sender, EventArgs e)
        {
            page -= 1;
            search();
        }

        private void buttonPageForward_Click(object sender, EventArgs e)
        {
            page += 1;
            search();
        }

        private void comboBoxPageLimit_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageLimit = Convert.ToInt32(comboBoxPageLimit.SelectedItem);
            makeSearch();
        }

        private void buttonNewRecord_Click(object sender, EventArgs e)
        {
            FormNewRecord newRecordForm = new FormNewRecord();
            newRecordForm.FormClosed += new FormClosedEventHandler(newRecordForm_FormClosed);
            newRecordForm.Show();
        }

        void newRecordForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BarisGorselDLL.Order engOrder = new BarisGorselDLL.Order();
            GuncelleGridMethod(dataGridViewResult, engOrder.getMainScreen(Properties.Settings.Default.SubeId, 1, 30));
            GuncelleMethod(labelPage, "1/" + ((engOrder.toplam / 20) + 1));
            if (page >= (engOrder.toplam / pageLimit))
                buttonPageForward.Enabled = false;
            if (page == 1)
                buttonPageBacward.Enabled = false;
            ((Form)sender).Dispose();
        }

        private void buttonSearch_Click_1(object sender, EventArgs e)
        {
            isSearch = true;
            search();
        }

        private void dataGridViewResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isSearch == false)
            {
                FormEditRecord duzenle = new FormEditRecord();
                duzenle.FormClosed += new FormClosedEventHandler(duzenle_FormClosed);
                if (dataGridViewResult.CurrentRow.Cells[0].Value!=null)
                    duzenle.SepetId = long.Parse(dataGridViewResult.CurrentRow.Cells[0].Value.ToString());
                duzenle.Show();
            }
            else 
            {
                FormNewRecord siparis = new FormNewRecord();
                siparis.siparis(dataGridViewResult.CurrentRow.Cells[1].Value.ToString());
                siparis.Show();
            }
        }

        void duzenle_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form)sender).Dispose();
            (sender) = null;
            GC.Collect();
        }

        private void dataGridViewResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) {
                if (isSearch == false)
                {
                    FormEditRecord duzenle = new FormEditRecord();
                    duzenle.FormClosed += new FormClosedEventHandler(duzenle_FormClosed);
                    if (dataGridViewResult.CurrentRow.Cells[0].Value != null)
                        duzenle.SepetId = long.Parse(dataGridViewResult.CurrentRow.Cells[0].Value.ToString());
                    duzenle.Show();
                }
                else
                {
                    //TODO 
                }
            }
        }

        private void dataGridViewResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //TODO
        }

        private void toolStripRapor_Click(object sender, EventArgs e)
        {
            BarisGorselDLL.Barcode barkod = new BarisGorselDLL.Barcode();
            barkod.BarcodeNo = "BV0000000001";
            barkod.CariAdi = "BARAN KAYNAK";
            barkod.yazdir();
        }

        private void toolStripAbout_Click(object sender, EventArgs e)
        {
            About hakkinda = new About();
            hakkinda.Show();
        }

        private void stokGirişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStockIn stokGiris = new FormStockIn();
            stokGiris.Show();
        }
    }
}
