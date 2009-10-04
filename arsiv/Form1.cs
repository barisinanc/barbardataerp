using System;
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
        public Form1()
        {
            InitializeComponent();
            connectionString = Properties.Settings.Default.connectionStringDis;
        }

        int page = 1;

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            page = 1;
            search();
        }
        string connectionString;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBoxValue.KeyPress += new KeyPressEventHandler(textBoxValue_KeyPress);
            if (connectionControl())
            {
                loadForms();
            }
            else
            {
                MessageBox.Show("Sunucuyla bağlantı sağlanamadı!");
            }
            this.textBoxValue.Focus();
        }

        void textBoxValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                search();
            }
        }
        int count = 0;
        private void search()
        {
            Thread islemAra = new Thread(makeSearch);
            islemAra.Start();
        }

        private void makeSearch()
        {
            GuncelleMethod(labelStatus, "Aranıyor...");
            count = 0;
            conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("Listele", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            if (textBoxValue.Text != null)
            {
                cmd.Parameters.AddWithValue("@veri", textBoxValue.Text.Trim());
            }
            else
            {
                cmd.Parameters.AddWithValue("@veri", "");
            }
            string selectedDepartments="";
            for (int i = 0; i < checkedListBoxDepartment.Items.Count; i++)
            {
                if (checkedListBoxDepartment.GetItemChecked(i))
                {
                    selectedDepartments += (i+1) + ",";
                }
            }
            cmd.Parameters.AddWithValue("@SubeId", selectedDepartments);
            cmd.Parameters.AddWithValue("@sayfa", page);
            cmd.Parameters.AddWithValue("@adet", pageLimit);
            cmd.Parameters.Add("@toplam", SqlDbType.Int);
            cmd.Parameters["@toplam"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@devam", SqlDbType.Int);
            cmd.Parameters["@devam"].Direction = ParameterDirection.Output;
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            count = (int)cmd.Parameters["@toplam"].Value;
            int devam = (int)cmd.Parameters["@devam"].Value;
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
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            conn.Close();
            conn.Dispose();
            cmd.Dispose();
            adapter.Dispose();
            GuncelleGridMethod(dataGridViewResult, dataTable);
            GuncelleMethod(labelStatus, count + " adet kayıt bulundu!");
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

        private DataTable DataRead(string procedureName)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            conn.Close();
            conn.Dispose();
            cmd.Dispose();
            adapter.Dispose();
            return dataTable;
        }
        SqlConnection conn;
        private bool connectionControl()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                return true;
            }
            catch
            {
                //MessageBox.Show("Bağlantı sağlanamadı!");
            }

            return false;
        }
        int pageLimit = 30;
        private void loadForms()
        {
            foreach (DataRow row in DataRead("Listeler").Rows)
            { comboBoxCategory.Items.Add(row[1]); }
            comboBoxCategory.SelectedIndex = 0;
            foreach (DataRow row in DataRead("Subeler").Rows)
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
        }

        private void buttonNewRecord_Click(object sender, EventArgs e)
        {
            Form newRecordForm = new FormNewRecord();
            newRecordForm.Show();
        }
    }
}
