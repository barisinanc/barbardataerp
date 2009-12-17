using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace familytree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            Person eleman = new Person();
            var liste = from x in eleman.Liste()
                        select new{Id=x.Id, İsim = x.Name, Soyisim = x.Surmane};
            dataGridView1.DataSource = liste.ToList();
            
            eleman.Id = 1;
            Person sadf = eleman.Anneanne();
            Person ads= sadf.Gelin().Single();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Insert yeniInsert = new Insert();
            yeniInsert.Show();
        }
    }
}
