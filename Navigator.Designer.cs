namespace QLCH
{
    partial class Navigator
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
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Text = "Trang điều hướng";


            this.CreateNewInvoice.Location = new System.Drawing.Point(20, 20);
            this.CreateNewInvoice.Size = new System.Drawing.Size(100, 30);
            this.CreateNewInvoice.Text = "Tạo hóa đơn";
            this.Click += new System.EventHandler(this.CreateInvoiceButtonClick);

            this.Controls.Add(CreateNewInvoice);

            this.DebtButton.Location = new System.Drawing.Point(140, 20);
            this.DebtButton.Size = new System.Drawing.Size(100, 30);
            this.DebtButton.Text = "Xem bảng nợ";
            this.DebtButton.Click += new System.EventHandler(this.DebtButtonClick);
            this.Controls.Add(DebtButton);

            this.PriceListButton.Location = new System.Drawing.Point(20, 60);
            this.PriceListButton.Size = new System.Drawing.Size(100, 30);
            this.PriceListButton.Text = "Xem bảng giá";

            this.Controls.Add(PriceListButton);

            this.OldCustomerInvoice.Location =  new System.Drawing.Point(140,60);
            this.OldCustomerInvoice.Size = new System.Drawing.Size(100,30);
            this.OldCustomerInvoice.Text = "Xem đơn hàng";
            this.Controls.Add(OldCustomerInvoice);
        }

        private System.Windows.Forms.Button CreateNewInvoice = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button PriceListButton = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button DebtButton = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button OldCustomerInvoice = new System.Windows.Forms.Button();
        #endregion
    }
}