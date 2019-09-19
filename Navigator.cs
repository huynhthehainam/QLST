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
    public partial class Navigator : Form
    {
        private MySql.Data.MySqlClient.MySqlConnection DBConnection;
        public Navigator(MySql.Data.MySqlClient.MySqlConnection DBConnection)
        {
            this.DBConnection = DBConnection;
            InitializeComponent();
        }

        private void CreateInvoiceButtonClick(object sender, EventArgs e)
        {
            NewInvoice NewInvoicePage = new NewInvoice(this.DBConnection);
            NewInvoicePage.ShowDialog();
        }

        private void DebtButtonClick(object sender, EventArgs e)
        {
            DebtView DebtViewPage = new DebtView(this.DBConnection);
            DebtViewPage.ShowDialog();

        }


    }
}