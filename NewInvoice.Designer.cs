namespace QLCH
{

    partial class NewInvoice
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Text = "Tạo hoá đơn mới";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.CustomerNameLabel.Location = new System.Drawing.Point(10, 10);
            this.CustomerNameLabel.Size = new System.Drawing.Size(100, 30);
            this.CustomerNameLabel.Text = "Tên khách hàng:";
            this.CustomerNameLabel.Font = LabelFont;
            this.Controls.Add(this.CustomerNameLabel);

            this.CustomerName.Location = new System.Drawing.Point(120, 10);
            this.CustomerName.Size = new System.Drawing.Size(200, 30);
            this.CustomerName.PlaceholderText = "Nhập tên khách hàng";
            this.CustomerName.TextChanged += new System.EventHandler(this.CustomerNameTextChanged);
            this.Controls.Add(this.CustomerName);

            this.IsWorkerLabel.Location = new System.Drawing.Point(325, 10);
            this.IsWorkerLabel.Size = new System.Drawing.Size(30, 30);
            this.IsWorkerLabel.Text = "Thợ";
            this.IsWorkerLabel.Font = LabelFont;
            this.Controls.Add(this.IsWorkerLabel);


            this.IsWorker.Location = new System.Drawing.Point(360, 10);
            this.IsWorker.Size = new System.Drawing.Size(30, 30);
            this.IsWorker.Checked = true;
            this.Controls.Add(this.IsWorker);

            this.CustomerInformationLabel.Location = new System.Drawing.Point(10, 45);
            this.CustomerInformationLabel.Size = new System.Drawing.Size(100, 30);
            this.CustomerInformationLabel.Text = "Thông tin:";
            this.CustomerInformationLabel.Font = LabelFont;
            this.Controls.Add(this.CustomerInformationLabel);

            this.CustomerInformation.Location = new System.Drawing.Point(120, 45);
            this.CustomerInformation.Size = new System.Drawing.Size(200, 30);
            this.CustomerInformation.PlaceholderText = "Nhập thông tin khách hàng";
            this.Controls.Add(this.CustomerInformation);

            this.CustomerDebtLabel.Location = new System.Drawing.Point(900, 10);
            this.CustomerDebtLabel.Size = new System.Drawing.Size(200, 30);
            this.CustomerDebtLabel.Text = "Nợ khách hàng";
            this.CustomerDebtLabel.Font = LabelFont;
            this.Controls.Add(this.CustomerDebtLabel);

            this.DebtDataView.Location = new System.Drawing.Point(900, 45);
            this.DebtDataView.Size = new System.Drawing.Size(400, 300);
            this.DebtDataView.AllowUserToAddRows = false;
            this.DebtDataView.RowHeadersVisible = false;
            this.Controls.Add(this.DebtDataView);

            this.CustomerHistoryLabel.Location = new System.Drawing.Point(900, 400);
            this.CustomerHistoryLabel.Size = new System.Drawing.Size(200, 30);
            this.CustomerHistoryLabel.Text = "Lịch sử mua hàng";
            this.CustomerHistoryLabel.Font = LabelFont;
            this.Controls.Add(this.CustomerHistoryLabel);

            this.CustomerHistoryView.Location = new System.Drawing.Point(900, 435);
            this.CustomerHistoryView.Size = new System.Drawing.Size(400, 300);
            this.CustomerHistoryView.AllowUserToAddRows = false;
            this.CustomerHistoryView.RowHeadersVisible = false;
            this.Controls.Add(this.CustomerHistoryView);

            this.CalendarForm.Location = new System.Drawing.Point(900, 750);
            this.CalendarForm.Size = new System.Drawing.Size(400, 200);
            this.CalendarForm.TitleBackColor = System.Drawing.Color.Red;
            this.CalendarForm.ShowTodayCircle = true;
            this.Controls.Add(this.CalendarForm);


            this.MHLabel.Location = new System.Drawing.Point(10, 80);
            this.MHLabel.Size = new System.Drawing.Size(50, 30);
            this.MHLabel.Text = "MH:";
            this.MHLabel.Font = LabelFont;
            this.Controls.Add(this.MHLabel);

            this.MH.Location = new System.Drawing.Point(65, 80);
            this.MH.Size = new System.Drawing.Size(150, 30);
            this.MH.PlaceholderText = "Nhập tên mặt hàng";
            this.MH.TextChanged += new System.EventHandler(this.MHTextChanged);
            this.Controls.Add(this.MH);

            this.QuantityLabels.Location = new System.Drawing.Point(220, 80);
            this.QuantityLabels.Size = new System.Drawing.Size(30, 30);
            this.QuantityLabels.Text = "SL:";
            this.QuantityLabels.Font = LabelFont;
            this.Controls.Add(this.QuantityLabels);

            this.Quantity.Location = new System.Drawing.Point(255, 80);
            this.Quantity.Size = new System.Drawing.Size(50, 30);
            this.Quantity.PlaceholderText = "Nhập SL";
            this.Controls.Add(this.Quantity);

            this.UnitLabel.Location = new System.Drawing.Point(310, 80);
            this.UnitLabel.Size = new System.Drawing.Size(40, 30);
            this.UnitLabel.Text = "ĐVT:";
            this.UnitLabel.Font = LabelFont;
            this.Controls.Add(this.UnitLabel);

            this.Unit.Location = new System.Drawing.Point(355, 80);
            this.Unit.Size = new System.Drawing.Size(60, 30);
            this.Unit.PlaceholderText = "Nhập ĐVT";
            this.Controls.Add(this.Unit);

            this.UnitPriceLabel.Location = new System.Drawing.Point(420, 80);
            this.UnitPriceLabel.Size = new System.Drawing.Size(30, 30);
            this.UnitPriceLabel.Text = "ĐG:";
            this.UnitPriceLabel.Font = LabelFont;
            this.Controls.Add(this.UnitPriceLabel);

            this.UnitPrice.Location = new System.Drawing.Point(455, 80);
            this.UnitPrice.Size = new System.Drawing.Size(100, 30);
            this.UnitPrice.PlaceholderText = "Nhập ĐG";
            this.Controls.Add(this.UnitPrice);

            this.NoticeLabel.Location = new System.Drawing.Point(560, 80);
            this.NoticeLabel.Size = new System.Drawing.Size(60, 30);
            this.NoticeLabel.Text = "Ghi chú:";
            this.NoticeLabel.Font = LabelFont;
            this.Controls.Add(this.NoticeLabel);

            this.Notice.Location = new System.Drawing.Point(625, 80);
            this.Notice.Size = new System.Drawing.Size(100, 30);
            this.Notice.PlaceholderText = "Nhập ghi chú";
            this.Controls.Add(this.Notice);

            this.AddButton.Location = new System.Drawing.Point(730, 80);
            this.AddButton.Size = new System.Drawing.Size(50, 30);
            this.AddButton.Text = "Thêm";
            this.AddButton.Click += new System.EventHandler(this.AddButtonClick);
            this.Controls.Add(AddButton);

            this.InvoiceDataView.Location = new System.Drawing.Point(10, 115);
            this.InvoiceDataView.Size = new System.Drawing.Size(800, 500);
            this.InvoiceDataView.Columns.Add("Index", "STT");
            this.InvoiceDataView.Columns.Add("IdWareHouse", "IdWareHouse");
            this.InvoiceDataView.Columns["IdWareHouse"].Visible = false;
            this.InvoiceDataView.Columns.Add("MH", "Tên MH");
            this.InvoiceDataView.Columns.Add("Quantity", "Số lượng");
            this.InvoiceDataView.Columns.Add("Unit", "ĐVT");
            this.InvoiceDataView.Columns.Add("UnitPrice", "Đơn giá");
            this.InvoiceDataView.Columns.Add("Notice", "Ghi chú");
            this.InvoiceDataView.Columns.Add("TotalPrice", "Thành tiền");
            System.Windows.Forms.DataGridViewButtonColumn DeleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            DeleteButton.HeaderText = "";
            DeleteButton.Text = "Xóa";
            DeleteButton.UseColumnTextForButtonValue = true;
            DeleteButton.Name = "Deletebutton";
            this.InvoiceDataView.Columns.Add(DeleteButton);
            this.InvoiceDataView.Columns.Add("DeleteButton", "");
            this.InvoiceDataView.AllowUserToAddRows = false;
            this.InvoiceDataView.RowHeadersVisible = false;
            this.InvoiceDataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InvoiceDataViewDeleteButton);
            this.InvoiceDataView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.InvoiceDataViewCellValueChanged);
            this.Controls.Add(this.InvoiceDataView);

            this.DepositLabel.Location = new System.Drawing.Point(10, 620);
            this.DepositLabel.Size = new System.Drawing.Size(100, 30);
            this.DepositLabel.Text = "Trả trước:";
            this.DepositLabel.Font = LabelFont;
            this.Controls.Add(this.DepositLabel);

            this.Deposit.Location = new System.Drawing.Point(115, 620);
            this.Deposit.Size = new System.Drawing.Size(100, 30);
            this.Deposit.Text = "0";
            this.Controls.Add(this.Deposit);

            this.TotalCostInvoiceLabel.Location = new System.Drawing.Point(10, 655);
            this.TotalCostInvoiceLabel.Size = new System.Drawing.Size(100, 30);
            this.TotalCostInvoiceLabel.Text = "Tổng cộng đơn hàng:";
            this.TotalCostInvoiceLabel.Font = LabelFont;
            this.Controls.Add(this.TotalCostInvoiceLabel);

            this.TotalCostInvoice.Location = new System.Drawing.Point(115, 655);
            this.TotalCostInvoice.Text = "0";
            this.Controls.Add(this.TotalCostInvoice);

            this.TotalCostPlusDebtLabel.Location = new System.Drawing.Point(10, 690);
            this.TotalCostPlusDebtLabel.Size = new System.Drawing.Size(100, 30);
            this.TotalCostPlusDebtLabel.Text = "Tổng cộng đơn hàng + nợ:";
            this.TotalCostPlusDebtLabel.Font = LabelFont;
            this.Controls.Add(this.TotalCostPlusDebtLabel);

            this.TotalCostPlusDebt.Location = new System.Drawing.Point(115, 690);
            this.TotalCostPlusDebt.Text = "0";
            this.Controls.Add(this.TotalCostPlusDebt);

            this.SaveButton.Location = new System.Drawing.Point(300, 655);
            this.SaveButton.Size = new System.Drawing.Size(100, 30);
            this.SaveButton.Text = "Lưu và in";
            this.SaveButton.Click += new System.EventHandler(this.SaveButtonClick);
            this.Controls.Add(this.SaveButton);

            this.ClockLabel.Location = new System.Drawing.Point(500, 10);
            this.ClockLabel.Size = new System.Drawing.Size(200, 60);
            this.ClockLabel.Text = System.DateTime.Now.ToString("HH:mm:ss");
            this.ClockLabel.Font = ClockFont;
            this.Controls.Add(this.ClockLabel);


            ClockTimer.Interval = 1000;
            ClockTimer.Tick += new System.EventHandler(this.ResetClock);
            ClockTimer.Start();


        }
        private System.Windows.Forms.MonthCalendar CalendarForm = new System.Windows.Forms.MonthCalendar();
        private System.Windows.Forms.Label ClockLabel = new System.Windows.Forms.Label();
        System.Drawing.Font ClockFont = new System.Drawing.Font("Arial", 20, System.Drawing.FontStyle.Bold);
        private System.Windows.Forms.Timer ClockTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.DataGridView CustomerHistoryView = new System.Windows.Forms.DataGridView();
        private System.Windows.Forms.Label CustomerDebtLabel = new System.Windows.Forms.Label();
        private System.Windows.Forms.Label CustomerHistoryLabel = new System.Windows.Forms.Label();
        private System.Windows.Forms.Button SaveButton = new System.Windows.Forms.Button();
        private System.Windows.Forms.Label TotalCostInvoiceLabel = new System.Windows.Forms.Label();
        private System.Windows.Forms.TextBox TotalCostInvoice = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.Label TotalCostPlusDebtLabel = new System.Windows.Forms.Label();
        private System.Windows.Forms.TextBox TotalCostPlusDebt = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.Label DepositLabel = new System.Windows.Forms.Label();
        private System.Windows.Forms.TextBox Deposit = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.Button AddButton = new System.Windows.Forms.Button();
        private System.Windows.Forms.Label IsWorkerLabel = new System.Windows.Forms.Label();
        private System.Windows.Forms.CheckBox IsWorker = new System.Windows.Forms.CheckBox();
        private System.Windows.Forms.Label NoticeLabel = new System.Windows.Forms.Label();
        private System.Windows.Forms.TextBox Notice = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.DataGridView InvoiceDataView = new System.Windows.Forms.DataGridView();
        private System.Windows.Forms.Label UnitPriceLabel = new System.Windows.Forms.Label();
        private System.Windows.Forms.TextBox UnitPrice = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.Label UnitLabel = new System.Windows.Forms.Label();
        private System.Windows.Forms.TextBox Unit = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.Label CustomerNameLabel = new System.Windows.Forms.Label();
        private System.Windows.Forms.TextBox CustomerName = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.Label CustomerInformationLabel = new System.Windows.Forms.Label();
        private System.Windows.Forms.TextBox CustomerInformation = new System.Windows.Forms.TextBox();
        private System.Drawing.Font LabelFont = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

        private System.Windows.Forms.DataGridView DebtDataView = new System.Windows.Forms.DataGridView();
        private System.Windows.Forms.Label MHLabel = new System.Windows.Forms.Label();
        private System.Windows.Forms.TextBox MH = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.Label QuantityLabels = new System.Windows.Forms.Label();
        private System.Windows.Forms.TextBox Quantity = new System.Windows.Forms.TextBox();
        #endregion
    }
}