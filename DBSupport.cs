using MySql.Data.MySqlClient;
using System.Data;
namespace QLCH
{
    public class DBSupport
    {
        private MySql.Data.MySqlClient.MySqlConnection DBConnection;
        public DBSupport(MySql.Data.MySqlClient.MySqlConnection DBConnection)
        {
            this.DBConnection = DBConnection;
        }
        public static string ConvertIdCustomerToCustomerName(string Id, MySqlConnection DBConnection)
        {
            string Result = "";
            DataTable CustomerTable = new DataTable();
            MySqlDataAdapter AdapterGetCustomerTable = new MySqlDataAdapter("Select * from qlch.customer", DBConnection);
            AdapterGetCustomerTable.Fill(CustomerTable);
            foreach (DataRow Row in CustomerTable.Rows)
            {
                if (Row["Id"].ToString() == Id)
                {
                    Result = Row["Name"].ToString();
                }
            }
            return Result;
        }
    }
}