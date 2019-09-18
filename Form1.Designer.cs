namespace QLCH
{
    partial class Form1
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
            try
            {
                DBConnection = new MySql.Data.MySqlClient.MySqlConnection(this.DBConnectionString);
                DBConnection.Open();
                System.Console.WriteLine("MySQL Version: {0}", DBConnection.ServerVersion);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Không thể kết nối tới dữ liệu!");
                System.Console.WriteLine("Error: {0}", ex.ToString());
                this.Close();
            }
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CloseEvent);

            this.PasswordBox.Location = new System.Drawing.Point(400, 225);
            this.PasswordBox.Size = new System.Drawing.Size(100, 30);
            this.PasswordBox.UseSystemPasswordChar = true;
            this.PasswordBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordBoxKeyDown);
            this.Controls.Add(PasswordBox);

            this.PassLabel.Location = new System.Drawing.Point(300, 225);
            this.PassLabel.Size = new System.Drawing.Size(100, 30);
            this.PassLabel.Text = "Mật khẩu:";
            this.PassLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Controls.Add(PassLabel);

            this.StoreName.Location = new System.Drawing.Point(150, 20);
            this.StoreName.Size = new System.Drawing.Size(600, 50);
            this.StoreName.Text = "Cửa hàng sắt thép HOÀNG CƯỜNG";
            this.StoreName.Font = StoreNameFont;

            this.Controls.Add(StoreName);

            this.LoginButton.Location = new System.Drawing.Point(350, 300);
            this.LoginButton.Size = new System.Drawing.Size(100, 30);
            this.LoginButton.Text = "Đăng nhập";
            this.LoginButton.Click += new System.EventHandler(this.LoginButtonClick);
            this.Controls.Add(LoginButton);

        }
        private string DBConnectionString = @"server = localhost; userid = root; password = kid1412; database = qlch";
        private System.Windows.Forms.TextBox PasswordBox = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.Label PassLabel = new System.Windows.Forms.Label();
        private System.Windows.Forms.Label StoreName = new System.Windows.Forms.Label();

        private System.Drawing.Font StoreNameFont = new System.Drawing.Font("Arial", 24, System.Drawing.FontStyle.Bold);

        private System.Windows.Forms.Button LoginButton = new System.Windows.Forms.Button();
        private MySql.Data.MySqlClient.MySqlConnection DBConnection;
        #endregion
    }
}

