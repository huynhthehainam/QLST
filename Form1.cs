using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            string QuerryLogin = "Select * from qlch.password";
            MySqlCommand Command = new MySqlCommand(QuerryLogin, this.DBConnection);
            DataTable PasswordTable = new DataTable();
            MySqlDataAdapter Adapter = new MySqlDataAdapter(Command);
            Adapter.Fill(PasswordTable);
            Console.WriteLine(PasswordTable);
            NewInvoice Tmp = new NewInvoice(this.DBConnection);
            this.Hide();
            Tmp.ShowDialog();
            this.Close();
            // if (this.PasswordBox.Text == PasswordTable.Rows[0]["Password"].ToString())
            // {
            //     Navigator NaviPage = new Navigator(this.DBConnection);
            //     this.Hide();
            //     NaviPage.ShowDialog();
            //     this.Close();

            // }
        }

        private void PasswordBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.LoginButton.PerformClick();
            }
        }

    }
}
