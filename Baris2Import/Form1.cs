using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Baris2Import
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Esitle_Click(object sender, EventArgs e)
        {
            Esitle.Enabled = false;
            BarisGorselDLL.Baris2Import import = new BarisGorselDLL.Baris2Import();
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=arsiv;Integrated Security=True";
            SqlConnection mySqlConnection = new SqlConnection(connectionString);
            import.Import(mySqlConnection);
            import = null;
            GC.Collect();
            Esitle.Enabled = true;
            MessageBox.Show("Veriler Aktarıldı!");
        }

    }
}
