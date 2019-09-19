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
        public NewInvoice(MySql.Data.MySqlClient.MySqlConnection DBConnection)
        {
            this.DBConnection = DBConnection;
            InitializeComponent();
            MySqlDataAdapter AdapterGetDebt = new MySqlDataAdapter("Select * from qlch.debt", this.DBConnection);
            DataTable DebtTable = new DataTable();
            AdapterGetDebt.Fill(DebtTable);
            DebtTable.Columns.Add("Name", typeof(string)).SetOrdinal(2);
            this.DebtDataView.DataSource = DebtTable;
            this.DebtDataView.Columns["Id"].Visible = false;
            this.DebtDataView.Columns["CustomerName"].HeaderText = "Tên khách hàng";
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
            this.CustomerHistoryView.DataSource = InvoiceTable;
            this.CustomerHistoryView.Columns["Id"].Visible = false;
            this.CustomerHistoryView.Columns["CustomerName"].HeaderText = "Tên khách hàng";
            this.CustomerHistoryView.Columns["TotalMoney"].HeaderText = "Tổng tiền";
            this.CustomerHistoryView.Columns["Deposit"].HeaderText = "Tiền cọc";
            this.CustomerHistoryView.Columns["Date"].HeaderText = "Ngày";
            DataGridViewButtonColumn RestoreButton = new DataGridViewButtonColumn();
            RestoreButton.HeaderText = "";
            RestoreButton.Text = "Khôi phục";
            RestoreButton.UseColumnTextForButtonValue = true;
            RestoreButton.Name = "RestoreButton";
            this.CustomerHistoryView.Columns.Add(RestoreButton);
            DataGridViewButtonColumn DeleteButton = new DataGridViewButtonColumn();
            DeleteButton.HeaderText = "";
            DeleteButton.Text = "Xóa";
            DeleteButton.UseColumnTextForButtonValue = true;
            DeleteButton.Name = "Deletebutton";
            this.InvoiceDataView.Columns.Add(DeleteButton);
            this.InvoiceDataView.Columns["TotalPrice"].DefaultCellStyle.Format = "N0";
            this.InvoiceDataView.Columns["UnitPrice"].DefaultCellStyle.Format = "N0";
           
        }


        private void ResetClock(object sender, EventArgs e)
        {
            this.ClockLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void PreviewInvoice()
        {
            string HTML = @"
                                <!DOCTYPE html>
                                <html lang=""en"">
                                <head>
                                <title>PrintPreview</title>
                                <style>
                                table, th, td {
                                border: 1px solid black;
                                border-collapse: collapse;
                                }
                                table.noborder, table.noborder th, table.noborder td {
                                border: 0px;
                                }
                                </style>
                                <meta charset=""utf-8"">
                                </head>
                                <body>
                                <div align=right>Ngày " + DateTime.Now.ToString("dd/MM/yyyy") + @"</div>
                                <div align=left>NHÀ MÁY TÔN - CỬA HÀNG SẮT THÉP</div>
                                <h2>HOÀNG CƯỜNG</h2>
                                <div>Địa chỉ: 0279, Quảng Thành 1, xã Nghĩa Thành, huyện Châu Đức, tỉnh BRVT</div>
                                <div align=left>Tên Khách Hàng: " + this.CustomerName.Text + @"
                                <br>Thông tin: " + this.CustomerInformation.Text + @"
                                <h1 align=center>Đơn hàng</h1>
                                <div style=""margin-left:10%;margin-right:10%"">
                                <table style=""width:100%"">
                                <col width=50>
                                <col width=300>
                                <col width=200>
                                <col width=100>
                                <col width=100>
                                <col width=200>

                                <col width=200>
                                <tr>
                                <th align=center>STT</th>
                                <th align=center>Mặt hàng</th><th align=center>Ghi chú</th>
                                <th align=center>Số lượng</th>
                                <th align=center>Đơn vị tính</th>
                                <th align=center>Đơn giá</th>
                                <th align=center>Thành tiền</th>
                                </tr>
                                "; ;
            foreach (DataGridViewRow Row in this.InvoiceDataView.Rows)
            {
                HTML += "<tr><td align=center>" + Row.Cells["Index"].Value.ToString() + "</td>" + "<td>" + Row.Cells["GoodsCode"].Value.ToString() + "</td>" + "<td>" + Row.Cells["Notice"].Value.ToString() + "</td>" + "<td align=right>" + Row.Cells["Quantity"].Value.ToString()
                + "</td>" + "<td align=center>" + Row.Cells["Unit"].Value.ToString() + "</td>" + "<td align=right>" + Int32.Parse(Row.Cells["UnitPrice"].Value.ToString()).ToString("N0") + "</td>" + "<td align=right>" + Int32.Parse(Row.Cells["TotalPrice"].Value.ToString()).ToString("N0") + "</td>" + "</tr>";
            }
            HTML += @"
                                </table></div>
                                <div>
                                <br>
                                <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Người
                                mua hàng
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                Người bán hàng

                                <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Kí tên
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;       Kí tên
                                </div>
                                </body></html>";
            // this.FooterHTML;
            this.InvoicePreview.DocumentText = HTML;
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            if (this.CustomerName.Text != "")
            {
                int IdInvoice = 0;
                DataRow[] CustomerTableIdFilt = CustomerTable.Select(string.Format("Name ='{0}'", this.CustomerName.Text));
                if (CustomerTableIdFilt.Length == 0)
                {
                    MySqlCommand AddNewCustomerCommand = new MySqlCommand(string.Format("Insert into qlch.customer(Name,Information) values('{0}','{1}')", this.CustomerName.Text, this.CustomerInformation.Text), DBConnection);
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
                    MySqlCommand AddNewInvoiceCommand = new MySqlCommand(string.Format("insert into qlch.invoice(Id, CustomerName, TotalMoney, Deposit, Date) values('{0}','{1}','{2}','{3}','{4}')", IdInvoice.ToString(), this.CustomerName.Text, this.TotalCostInvoice.Text, this.Deposit.Text, DateTime.Now.ToString("yyyyMMdd")), DBConnection);
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

                DataRow[] CustomerNameFilt = CustomerTable.Select(string.Format("Name = '{0}'", this.CustomerName.Text));
                if (CustomerNameFilt.Length > 0)
                {
                    this.CustomerInformation.Text = CustomerNameFilt[0]["Information"].ToString();
                }
                BindingSource BindingSouceDebt = new BindingSource();
                BindingSouceDebt.DataSource = this.DebtDataView.DataSource;
                BindingSouceDebt.Filter = string.Format("CustomerName = '{0}'", this.CustomerName.Text);
                this.DebtDataView.DataSource = BindingSouceDebt;

                BindingSource BindingSouceHistory = new BindingSource();
                BindingSouceHistory.DataSource = this.CustomerHistoryView.DataSource;
                BindingSouceHistory.Filter = string.Format("CustomerName = '{0}'", this.CustomerName.Text);
                this.DebtDataView.DataSource = BindingSouceHistory;

                this.PreviewInvoice();
            }
        }

        private void InvoiceDataViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.CalculateTotalCost();
            this.PreviewInvoice();
        }
        private void InvoiceDataViewDeleteButton(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.InvoiceDataView.Columns["DeleteButton"].Index && e.RowIndex >= 0)
            {
                this.InvoiceDataView.Rows.RemoveAt(e.RowIndex);
                this.CalculateTotalCost();
                this.PreviewInvoice();
            }
        }
        private void CustomerHistoryViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.CustomerHistoryView.Columns["RestoreButton"].Index && e.RowIndex >= 0)
            {

            }
        }
        private void CalculateTotalCost()
        {
            int TotalCost = 0;
            foreach (DataGridViewRow Row in this.InvoiceDataView.Rows)
            {
                TotalCost += Int32.Parse(Row.Cells["TotalPrice"].Value.ToString());
            }
            this.TotalCostInvoice.Text = TotalCost.ToString();
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            if (this.MH.Text != "" && int.TryParse(this.Quantity.Text, out int n) && this.Unit.Text != "" && int.TryParse(this.UnitPrice.Text, out int n1))
            {
                DataRow[] WareHouseTableFilt = WareHouseTable.Select(string.Format("Name = '{0}'", this.MH.Text));
                if (WareHouseTableFilt.Length > 0)
                {
                    this.InvoiceDataView.Rows.Add(this.InvoiceDataView.Rows.Count + 1, WareHouseTableFilt[0]["Id"], this.MH.Text, Int32.Parse(this.Quantity.Text), this.Unit.Text, Int32.Parse(this.UnitPrice.Text), this.Notice.Text, (int)float.Parse(this.Quantity.Text) * float.Parse(this.UnitPrice.Text));
                }
                this.CalculateTotalCost();
                this.ResetTextBox();
                this.PreviewInvoice();
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