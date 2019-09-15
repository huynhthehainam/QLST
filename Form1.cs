using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            if (this.PasswordBox.Text == "1")
            {
                Navigator NaviPage = new Navigator();
                this.Hide();
                NaviPage.ShowDialog();
                this.Close();
            }
        }

        private void PasswordBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) {
                this.LoginButton.PerformClick();
            }
        }

    }
}
