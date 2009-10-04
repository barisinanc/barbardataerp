using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace arsiv
{
    public partial class FormAddProduct : Form
    {
        public FormAddProduct()
        {
            InitializeComponent();
            connectionString = Properties.Settings.Default.connectionStringDis;
            
        }
        string connectionString;
        private DataTable DataRead(string procedureName, string veri)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@veri", veri);
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

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length >= 3)
            {
                dataGridViewNames.DataSource = DataRead("Urunler", textBoxName.Text);
            }
        }

        private void textBoxBrand_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBrand.Text.Length >= 3)
            {
                dataGridViewBrand.DataSource = DataRead("Markalar", textBoxName.Text);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveProduct();
        }

        private void saveProduct()
        {
            conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("UrunEkle", conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add("@BarkodNo", SqlDbType.NVarChar);
            command.Parameters["@BarkodNo"].Value = StringEdit.FirstUpper(textBoxBarcodeNo.Text.Trim());
            command.Parameters.Add("@Urun", SqlDbType.NVarChar);
            command.Parameters["@Urun"].Value = StringEdit.FirstUpper(textBoxName.Text.Trim());
            command.Parameters.Add("@Marka", SqlDbType.NVarChar);
            command.Parameters["@Marka"].Value = StringEdit.FirstUpper(textBoxBrand.Text.Trim());
            command.Parameters.Add("@Model", SqlDbType.NVarChar);
            command.Parameters["@Model"].Value = StringEdit.FirstUpper(textBoxModel.Text.Trim());
            command.Parameters.Add("@Fiyat", SqlDbType.Money);
            command.Parameters["@Fiyat"].Value = textBoxPrice.Text.Trim();
            command.Parameters.Add("@Kdv", SqlDbType.Int);
            command.Parameters["@Kdv"].Value = textBoxKdv.Text.Trim();
            command.Parameters.Add("@Arsivle", SqlDbType.TinyInt);
            command.Parameters["@Arsivle"].Value = checkBoxArchived.Checked;
            int durum = 0;
            try
            {
                conn.Open();
                durum = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            {
                conn.Close();
                if (durum == 1)
                {
                    cleanForm();
                }
                else
                {
                    MessageBox.Show("Bu kayıt önceden eklenmiş!");
                }
            }
        }

        private void cleanForm()
        {
            textBoxBarcodeNo.Text = null;
            textBoxBrand.Text = null;
            textBoxKdv.Text = null;
            textBoxModel.Text = null;
            textBoxName.Text = null;
            textBoxPrice.Name = null;
            checkBoxArchived.Checked = false;
        }

        private void dataGridViewNames_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxName.Text = dataGridViewNames.SelectedCells[0].Value.ToString();
        }

        private void dataGridViewBrand_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxBrand.Text = dataGridViewBrand.SelectedCells[0].Value.ToString();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            cleanForm();
        }
    }
}
