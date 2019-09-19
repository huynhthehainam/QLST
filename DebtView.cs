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
    public partial class DebtView : Form
    {
        MySqlConnection DBConnecttion;
        DataTable DebtTable = new DataTable();
        DataTable CustomerTable = new DataTable();
        public DebtView(MySqlConnection DBConnecttion)
        {
            InitializeComponent();
            this.DBConnecttion = DBConnecttion;
            MySqlDataAdapter AdapterGetCustomer = new MySqlDataAdapter("Select * from qlch.customer",this.DBConnecttion);
            AdapterGetCustomer.Fill(CustomerTable);
            AutoCompleteStringCollection CustomerSuggestList = new AutoCompleteStringCollection();
            foreach(DataRow Row in CustomerTable.Rows) {
                CustomerSuggestList.Add(Row["Name"].ToString());
            }
            this.Search.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.Search.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.Search.AutoCompleteCustomSource = CustomerSuggestList;
            MySqlDataAdapter AdapterGetDebt = new MySqlDataAdapter("Select * from qlch.debt", DBConnecttion);
            AdapterGetDebt.Fill(DebtTable);
            this.DebtTableView.DataSource = DebtTable;
            this.DebtTableView.Columns["Number"].DefaultCellStyle.Format = "N0";
            this.DebtTableView.Columns["Id"].Visible = false;
            this.DebtTableView.Columns["CustomerName"].HeaderText = "Tên khách hàng";
            this.DebtTableView.Columns["Number"].HeaderText = "Tiền nợ";
            DataGridViewButtonColumn AddNumberButton = new DataGridViewButtonColumn();
            AddNumberButton.HeaderText = "";
            AddNumberButton.Text = "Thêm nợ";
            AddNumberButton.Name = "AddNumber";
            AddNumberButton.UseColumnTextForButtonValue = true;
            this.DebtTableView.Columns.Add(AddNumberButton);
            DataGridViewButtonColumn ReduceNumberButton = new DataGridViewButtonColumn();
            ReduceNumberButton.HeaderText = "";
            ReduceNumberButton.Text = "Giảm nợ";
            ReduceNumberButton.Name = "ReduceNumber";
            ReduceNumberButton.UseColumnTextForButtonValue = true;
            this.DebtTableView.Columns.Add(ReduceNumberButton);
            DataGridViewButtonColumn DeleteButton = new DataGridViewButtonColumn();
            DeleteButton.HeaderText = "";
            DeleteButton.Text = "Xoá";
            DeleteButton.Name = "DeleteButton";
            DeleteButton.UseColumnTextForButtonValue = true;
            this.DebtTableView.Columns.Add(DeleteButton);


        }
        private void SearchTextChanged(object sender, EventArgs e)
        {
            if (this.Search.Text != "")
            {
                BindingSource BindingSouceDebt = new BindingSource();
                BindingSouceDebt.DataSource = this.DebtTableView.DataSource;
                BindingSouceDebt.Filter = string.Format("CustomerName = '{0}'", this.Search.Text);
                this.DebtTableView.DataSource = BindingSouceDebt;
            }
        }
        private void DebtViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.DebtTableView.Columns["AddNumber"].Index && e.RowIndex >= 0)
            {

            }
            else if (e.ColumnIndex == this.DebtTableView.Columns["ReduceNumber"].Index && e.RowIndex >= 0)
            {

            }
            else if (e.ColumnIndex == this.DebtTableView.Columns["DeleteButton"].Index && e.RowIndex >= 0)
            {

            }
        }
    }
}