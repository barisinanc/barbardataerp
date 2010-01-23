using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace BarisGorselDLL.UserControls
{
    public class moneyTextBox : System.Windows.Forms.TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e) {

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44 && e.KeyChar != 9 && e.KeyChar != 13)
                e.KeyChar = (char)0;

        }

        protected override void OnGotFocus(EventArgs e)
        {
            this.SelectAll();
        }

        protected override void OnClick(EventArgs e)
        {
            this.SelectAll();
        }
    }
}
