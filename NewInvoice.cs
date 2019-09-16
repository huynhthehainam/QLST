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
    public partial class NewInvoice : Form
    {
        private MySql.Data.MySqlClient.MySqlConnection DBConnection;
        private DataTable WareHouseTable = new DataTable();
        private DataTable CustomerTable = new DataTable();
        private int IdCustomer = -1;
        public NewInvoice(MySql.Data.MySqlClient.MySqlConnection DBConnection)
        {
            this.DBConnection = DBConnection;
            InitializeComponent();
            MySqlDataAdapter AdapterGetDebt = new MySqlDataAdapter("Select * from qlch.debt", this.DBConnection);
            DataTable DebtTable = new DataTable();
            AdapterGetDebt.Fill(DebtTable);
            DebtTable.Columns.Add("Name", typeof(string)).SetOrdinal(2);
            foreach (DataRow Row in DebtTable.Rows)
            {
                Row["Name"] = DBSupport.ConvertIdCustomerToCustomerName(Row["Id"].ToString(), this.DBConnection);
            }
            this.DebtDataView.DataSource = DebtTable;
            this.DebtDataView.Columns["Id"].Visible = false;
            this.DebtDataView.Columns["IdCustomer"].Visible = false;
            this.DebtDataView.Columns["Name"].HeaderText = "Tên khách hàng";
            this.DebtDataView.Columns["Number"].HeaderText = "Tiền nợ";
            this.DebtDataView.Columns["Number"].DefaultCellStyle.Format = "N0";
            AutoCompleteStringCollection SuggestListCollection = new AutoCompleteStringCollection();
            MySqlDataAdapter AdapterGetWareHouse = new MySqlDataAdapter("select * from qlch.warehouse", this.DBConnection);
            AdapterGetWareHouse.Fill(WareHouseTable);
            foreach (DataRow Row in this.WareHouseTable.Rows)
            {
                SuggestListCollection.Add(Row["Name"].ToString());
            }
            this.MH.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.MH.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.MH.AutoCompleteCustomSource = SuggestListCollection;
            MySqlDataAdapter AdapterGetCustomer = new MySqlDataAdapter("Select * from qlch.customer", this.DBConnection);
            AdapterGetCustomer.Fill(CustomerTable);
            AutoCompleteStringCollection SuggestCustomerCollection = new AutoCompleteStringCollection();
            foreach (DataRow Row in CustomerTable.Rows)
            {
                SuggestCustomerCollection.Add(Row["Name"].ToString());
            }
            this.CustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.CustomerName.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.CustomerName.AutoCompleteCustomSource = SuggestCustomerCollection;
        }

        private void CustomerNameTextChanged(object sender, EventArgs e)
        {
            if (this.CustomerName.Text != "")
            {
                foreach (DataRow Row in CustomerTable.Rows)
                {
                    if (Row["Name"].ToString() == this.CustomerName.Text)
                    {
                        this.IdCustomer = Int32.Parse(Row["Id"].ToString());
                        this.CustomerInformation.Text = Row["Information"].ToString();
                        break;
                    }

                }
            }
        }

        private void InvoiceDataViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            if (this.MH.Text != "" && int.TryParse(this.Quantity.Text, out int n) && this.Unit.Text != "" && int.TryParse(this.UnitPrice.Text, out int n1))
            {
                this.InvoiceDataView.Rows.Add(this.InvoiceDataView.Rows.Count, this.MH.Text, this.Quantity.Text, this.Unit.Text, this.UnitPrice.Text, this.Notice.Text, (int)float.Parse(this.Quantity.Text) * float.Parse(this.UnitPrice.Text));
                ResetTextBox();
            }
        }
        private void ResetTextBox()
        {
            this.MH.Text = "";
            this.Quantity.Text = "";
            this.Unit.Text = "";
            this.Notice.Text = "";
            this.UnitPrice.Text = "";
            this.Quantity.BackColor = Color.White;
            this.Unit.BackColor = Color.White;
            this.UnitPrice.BackColor = Color.White;
            this.Notice.BackColor = Color.White;
            this.MH.BackColor = Color.White;
        }
        private void MHTextChanged(object sender, EventArgs e)
        {
            foreach (DataRow Row in this.WareHouseTable.Rows)
            {
                if (Row["Name"].ToString() == this.MH.Text)
                {
                    this.Quantity.Text = "0";
                    this.Unit.Text = Row["Unit"].ToString();
                    if (!this.IsWorker.Checked)
                    {
                        this.UnitPrice.Text = (0.01 * Int32.Parse(Row["PricePerWeight"].ToString()) * Int32.Parse(Row["Weight"].ToString()) * (100 + Int32.Parse(Row["InterestPercentCustomer"].ToString()))).ToString();
                    }
                    else
                    {
                        this.UnitPrice.Text = (0.01 * Int32.Parse(Row["PricePerWeight"].ToString()) * Int32.Parse(Row["Weight"].ToString()) * (100 + Int32.Parse(Row["InterestPercentWorker"].ToString()))).ToString();
                    }
                    if (int.Parse(Row["Quantity"].ToString()) < 5)
                    {
                        this.Quantity.BackColor = Color.Violet;
                        this.Unit.BackColor = Color.Violet;
                        this.UnitPrice.BackColor = Color.Violet;
                        this.Notice.BackColor = Color.Violet;
                        this.MH.BackColor = Color.Violet;
                    }
                    else
                    {
                        this.Quantity.BackColor = Color.White;
                        this.Unit.BackColor = Color.White;
                        this.UnitPrice.BackColor = Color.White;
                        this.Notice.BackColor = Color.White;
                        this.MH.BackColor = Color.White;
                    }
                    break;
                }

            }

        }
    }

}