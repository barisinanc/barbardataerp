using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BarisGorselDLL;

namespace arsiv
{
    public partial class Lodoskaraktersizi : Form
    {
        public Lodoskaraktersizi()
        {
            InitializeComponent();
        }

        private void Lodoskaraktersizi_Load(object sender, EventArgs e)
        {
            Archive aaaa = new Archive();
            foreach (DataRow satir in aaaa.LodosUyuzu().Rows)
            {
                aaaa.LodosUpdate(Convert.ToInt32(satir[0].ToString()),
                    temizle(satir[1].ToString()),
                    temizle(satir[2].ToString()),
                    temizle(satir[3].ToString()),
                    temizle(satir[4].ToString()));
            }
        }

        private string temizle(string giren)
        {
            string str = "";
            foreach (char c in giren)
            {
                if (c.GetHashCode() != 0)
                { str += c; }
            }
            return str.Trim();
        }
    }
}
