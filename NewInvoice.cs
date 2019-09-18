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
        private DataTable InvoiceTable = new DataTable();
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

            MySqlDataAdapter AdapterGetInvoice = new MySqlDataAdapter("Select * from qlch.invoice", this.DBConnection);
            AdapterGetInvoice.Fill(InvoiceTable);
            InvoiceTable.Columns.Add("CustomerName", typeof(string)).SetOrdinal(2);
            foreach (DataRow Row in InvoiceTable.Rows)
            {
                Row["CustomerName"] = DBSupport.ConvertIdCustomerToCustomerName(Row["IdCustomer"].ToString(), this.DBConnection);
            }
            this.CustomerHistoryView.DataSource = InvoiceTable;
            this.CustomerHistoryView.Columns["Id"].Visible = false;
            this.CustomerHistoryView.Columns["IdCustomer"].Visible = false;
            this.CustomerHistoryView.Columns["CustomerName"].HeaderText = "Tên khách hàng";
            this.CustomerHistoryView.Columns["TotalMoney"].HeaderText = "Tổng tiền";
            this.CustomerHistoryView.Columns["Deposit"].HeaderText = "Tiền cọc";
            this.CustomerHistoryView.Columns["Date"].HeaderText = "Ngày";
        }
        private void ResetClock(object sender, EventArgs e)
        {
            this.ClockLabel.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            if (this.CustomerName.Text != "")
            {
                int IdInvoice = 0;
                if (this.IdCustomer == -1)
                {
                    int IdCustomerInsert = 0;
                    while (true)
                    {
                        DataRow[] CustomerTableIdFilt = CustomerTable.Select(string.Format("Id = '{0}'", IdCustomerInsert.ToString()));
                        if (CustomerTableIdFilt.Length == 0)
                        {
                            break;
                        }
                        else
                        {
                            IdCustomerInsert++;
                        }
                    }
                    this.IdCustomer = IdCustomerInsert;
                    Console.WriteLine(this.IdCustomer);
                    MySqlCommand AddNewCustomerCommand = new MySqlCommand(string.Format("Insert into qlch.customer(Id,Name,Information) values('{0}','{1}','{2}')", this.IdCustomer.ToString(), this.CustomerName.Text, this.CustomerInformation.Text), DBConnection);
                    AddNewCustomerCommand.ExecuteNonQuery();
                }
                if (this.InvoiceDataView.RowCount > 0)
                {
                    while (true)
                    {
                        DataRow[] InvoicetableIdFilt = InvoiceTable.Select(string.Format("Id = '{0}'", IdInvoice));
                        if (InvoicetableIdFilt.Length == 0)
                        {
                            break;
                        }
                        else
                        {
                            IdInvoice++;
                        }
                    }
                    MySqlCommand AddNewInvoiceCommand = new MySqlCommand(string.Format("insert into qlch.invoice(Id, IdCustomer, TotalMoney, Deposit, Date) values('{0}','{1}','{2}','{3}','{4}')", IdInvoice.ToString(), IdCustomer.ToString(), this.TotalCostInvoice.Text, this.Deposit.Text, DateTime.Now.ToString("yyyyMMdd")), DBConnection);
                    AddNewInvoiceCommand.ExecuteNonQuery();
                    foreach (DataGridViewRow RowView in this.InvoiceDataView.Rows)
                    {
                        MySqlCommand AddNewInvoiceDetailCommand = new MySqlCommand(string.Format("insert into qlch.invoicedetail(IdInvoice,IdWareHouse,Quantity,Unit,Notice,UnitPrice,TotalPrice) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", IdInvoice,
                            RowView.Cells["IdWareHouse"].Value.ToString(),
                            RowView.Cells["Quantity"].Value.ToString(),
                            RowView.Cells["Unit"].Value.ToString(),
                            RowView.Cells["Notice"].Value.ToString(),
                            RowView.Cells["UnitPrice"].Value.ToString(),
                            RowView.Cells["TotalPrice"].Value.ToString()), this.DBConnection);
                        AddNewInvoiceDetailCommand.ExecuteNonQuery();
                    }
                }
            }
            this.Close();
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

        private void InvoiceDataViewCellValueChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            int TotalCost = 0;
            foreach (DataGridViewRow Row in this.InvoiceDataView.Rows)
            {
                TotalCost += Int32.Parse(Row.Cells["TotalPrice"].Value.ToString());
            }
            this.TotalCostInvoice.Text = TotalCost.ToString();
            Console.WriteLine("HHIHIHIHI");
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            if (this.MH.Text != "" && int.TryParse(this.Quantity.Text, out int n) && this.Unit.Text != "" && int.TryParse(this.UnitPrice.Text, out int n1))
            {
                DataRow[] WareHouseTableFilt = WareHouseTable.Select(string.Format("Name = '{0}'", this.MH.Text));
                if (WareHouseTableFilt.Length > 0)
                {
                    Button DeleteButton =  new Button();
                    
                    this.InvoiceDataView.Rows.Add(this.InvoiceDataView.Rows.Count, WareHouseTableFilt[0]["Id"], this.MH.Text, this.Quantity.Text, this.Unit.Text, this.UnitPrice.Text, this.Notice.Text, (int)float.Parse(this.Quantity.Text) * float.Parse(this.UnitPrice.Text));
                }
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