namespace QLCH
{
    partial class DebtView
    {
        private System.ComponentModel.IContainer Components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (Components != null))
            {
                Components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.Components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Text = "Bảng nợ";

            this.DebtTableView.Location = new System.Drawing.Point(10, 45);
            this.DebtTableView.Size = new System.Drawing.Size(600, 400);
            this.DebtTableView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DebtViewCellContentClick);
            this.Controls.Add(this.DebtTableView);

            this.SaveExitButton.Location = new System.Drawing.Point(630, 100);
            this.SaveExitButton.Size = new System.Drawing.Size(100, 30);
            this.SaveExitButton.Text = "Lưu và thoát";
            this.Controls.Add(this.SaveExitButton);

            this.SearchLabel.Location = new System.Drawing.Point(10, 10);
            this.SearchLabel.Size = new System.Drawing.Size(100, 30);
            this.SearchLabel.Text = "Tìm kiếm";
            this.SearchLabel.Font = LabelFont;
            this.Controls.Add(this.SearchLabel);

            this.Search.Location = new System.Drawing.Point(115, 10);
            this.Search.Size = new System.Drawing.Size(200, 30);
            this.Search.PlaceholderText = "Nhập tên khách hàng";
            this.Search.TextChanged += new System.EventHandler(this.SearchTextChanged);
            this.Controls.Add(Search);

        }
        private System.Drawing.Font LabelFont = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);
        private System.Windows.Forms.Label SearchLabel = new System.Windows.Forms.Label();
        private System.Windows.Forms.TextBox Search = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.DataGridView DebtTableView = new System.Windows.Forms.DataGridView();
        private System.Windows.Forms.Button SaveExitButton = new System.Windows.Forms.Button();
        #endregion
    }
}